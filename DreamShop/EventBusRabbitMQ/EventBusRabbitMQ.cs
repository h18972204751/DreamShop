using EventBus;
using EventBus.Abstractions;
using EventBus.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ
{
    public class EventBusRabbitMQ : IEventBus, IDisposable
    {
        /// <summary>
        /// 交换机名称
        /// </summary>
        const string Exchange_Name = "eshop_event_bus";
        /// <summary>
        /// mq的连接和释放
        /// </summary>
        private readonly IRabbitMQPersistentConnection _persistentConnection;
        /// <summary>
        /// 事件处理接口
        /// </summary>
        private readonly IEventBusSubscriptionsManager _subsManager;


        private IModel  _iModel;
        /// <summary>
        /// 队列名称
        /// </summary>
        private string _queueName;
        public EventBusRabbitMQ(IRabbitMQPersistentConnection persistentConnection,
            IEventBusSubscriptionsManager subsManager, string queueName = null)
        {
            _persistentConnection= persistentConnection?? throw new ArgumentNullException(nameof(persistentConnection));
            _subsManager = subsManager ?? new InMemoryEventBusSubscriptionsManager();
            _queueName = queueName;
            _iModel = CreateConsumerChannel();
            _subsManager.OnEventRemoved += SubsManager_OnEventRemoved;

        }
        /// <summary>
        /// 事件移除后 将队列和交换器解绑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventName"></param>
        private void SubsManager_OnEventRemoved(object sender,string eventName)
        {
            //mq是否连接
            if (!_persistentConnection.IsConnected)
                _persistentConnection.TryConnect();

            using (var channel = _persistentConnection.CreateModel())
            {
                //将队列与交换器解绑
                channel.QueueUnbind(queue: _queueName,
                    exchange: Exchange_Name,
                    routingKey: eventName);
                if (_subsManager.IsEmpty)
                {
                    _queueName = string.Empty;
                    _iModel.Close();
                }

            }

        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="event"></param>
        public void Publish(IntegrationEvent @event)
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }
            //重试机制 暂定

            //获取名称
            var eventName = @event.GetType().Name;
            //创建信道
            using (var channel = _persistentConnection.CreateModel())
            {
                //创建一个type=direct的交换器 (可以简化ExchangeDeclare(Exchange_Name,"direct")) 
                channel.ExchangeDeclare(exchange:Exchange_Name,type:"direct");
                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);
                //构造一个完全空的内容头，以便与基本内容类一起使用。
                var properties = channel.CreateBasicProperties();
                //指定为2 消息持久化
                properties.DeliveryMode = 2;
                //发布
                channel.BasicPublish(exchange: Exchange_Name,
                    routingKey: eventName,
                    mandatory: true,////指定mandatory: true告知服务器当根据指定的routingKey和消息找不到对应的队列时，直接返回消息给生产者。
                    basicProperties: properties,
                    body: body);

            }

        }

        /// <summary>
        /// 订阅
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <param name="eventName"></param>
        public void SubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler
        {

            DoInternalSubscription(eventName);
            _subsManager.AddDynamicSubscription<TH>(eventName);
            StartBasicConsume();
        }



        /// <summary>
        /// 事件订阅逻辑
        /// </summary>
        /// <param name="eventName"></param>
        private void DoInternalSubscription(string eventName)
        {
            var containsKey = _subsManager.HasSubscriptionsForEvent(eventName);
            if (!containsKey)
            {
                if (!_persistentConnection.IsConnected)
                {
                    _persistentConnection.TryConnect();
                }
                using (var channel = _persistentConnection.CreateModel())
                {
                    //queue 队列名称
                    //exchange 交换器名称
                    //routingKey 路由key
                    //arguments 其它的一些参数
                    channel.QueueBind(_queueName,Exchange_Name, eventName);
                }


            }

        }
        /// <summary>
        /// 注册Received事件委托处理消息接收事件
        /// </summary>
        private void StartBasicConsume()
        {
            if (_iModel != null)
            {
                //回调事件EventingBasicConsumer，用于处理接收到的消息。
                var consumer = new AsyncEventingBasicConsumer(_iModel);
                consumer.Received += Consumer_Received;

                //定义基础消费者
                _iModel.BasicConsume(_queueName, false, consumer);

            }
            else 
            {
                //加日志
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        public async Task Consumer_Received(object sender, BasicDeliverEventArgs eventArgs)
        {
            var eventName = eventArgs.RoutingKey;
            var message = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }





        public void Dispose()
        {
            if (_iModel != null)
                _iModel.Dispose();

        }


        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

       
    }
}
