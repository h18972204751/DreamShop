using Autofac;
using EventBus;
using EventBus.Abstractions;
using EventBus.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        const string  Autofac_Scope_Name= "eshop_event_bus";

        /// <summary>
        /// mq的连接和释放
        /// </summary>
        private readonly IRabbitMQPersistentConnection _persistentConnection;
        /// <summary>
        /// 事件处理接口
        /// </summary>
        private readonly IEventBusSubscriptionsManager _subsManager;

        private readonly ILifetimeScope _autofac;
        private IModel  _iModel;
        /// <summary>
        /// 队列名称
        /// </summary>
        private string _queueName;
        public EventBusRabbitMQ(IRabbitMQPersistentConnection persistentConnection, ILifetimeScope autofac,
            IEventBusSubscriptionsManager subsManager, string queueName = null)
        {
            _persistentConnection= persistentConnection?? throw new ArgumentNullException(nameof(persistentConnection));
            _autofac = autofac;
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
            //重试机制...后面补上   

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
        /// 订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            var eventName = _subsManager.GetEventKey<T>();

            DoInternalSubscription(eventName);
            _subsManager.AddSubscription<T,TH>();
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
                //创建信道
                using (var channel = _persistentConnection.CreateModel())
                {
                    //queue 队列名称
                    //exchange 交换器名称
                    //routingKey 路由key
                    //arguments 其它的一些参数
                    //绑定
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
                //绑定消息接收后的事件委托
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
        /// 绑定消息接收后的事件委托
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
                if (message.ToLowerInvariant().Contains("throw-fake-exception"))
                    throw new InvalidOperationException($"异常:{message}");
                await ProcessEvent(eventName, message);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"{ex}---异常:{message}");
            }
            //确认一个或多个已传递的消息
            _iModel.BasicAck(eventArgs.DeliveryTag, false);
        }





        /// <summary>
        /// 创建消费信道进行消息处理
        /// </summary>
        /// <returns></returns>
        private IModel CreateConsumerChannel()
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }
            //创建信道
            var channel = _persistentConnection.CreateModel();
            //申明Exchange
            channel.ExchangeDeclare(Exchange_Name, "direct");

            //durable：true、false  true：在服务器重启时，能够存活
            //exclusive ：是否为当前连接的专用队列，在连接断开后，会自动删除该队列，生产环境中应该很少用到吧。
            //autodelete：当没有任何消费者使用时，自动删除该队列。this means that the queue will be deleted when there are no more processes consuming messages from it.
            //实例化绑定Channel的消费者实例
            channel.QueueDeclare(_queueName, true, false, false, null);

            channel.CallbackException += (sender, ea) =>
            {
                _iModel.Dispose();
                _iModel = CreateConsumerChannel();
                StartBasicConsume();
            };
            return channel;
        }

        /// <summary>
        /// 获取事件的处理器信息
        /// </summary>
        /// <returns></returns>
        public async Task ProcessEvent(string eventName,string message) 
        {
            //查询信息是否存在
            if (_subsManager.HasSubscriptionsForEvent(eventName))
            {
                using (var scope = _autofac.BeginLifetimeScope(Autofac_Scope_Name))
                {
                    //获取处理器
                    var subscriptions = _subsManager.GetHandlersForEvent(eventName);
                    foreach (var subscription in subscriptions)
                    {
                        //// Di + 反射调用，处理事件

                        if (subscription.IsDynamic)
                        {
                            var handler = scope.ResolveOptional(subscription.HandlerType) as IDynamicIntegrationEventHandler;
                            if (handler == null)
                                continue;
                            dynamic eventData = JObject.Parse(message);

                            await Task.Yield();
                            await handler.Handle(eventData);
                        }
                        else
                        {
                            var handler = scope.ResolveOptional(subscription.HandlerType);
                            if (handler == null)
                                continue;
                            var eventType = _subsManager.GetEventTypeByName(eventName);
                            var integrationEvent = JsonConvert.DeserializeObject(message, eventType);
                            var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);

                            await Task.Yield();
                            await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { integrationEvent });
                        }
                    }

                }
            }
            else
                Console.WriteLine($"没有RabbitMQ事件订阅:{eventName}");

        }


        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        public void Unsubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            _subsManager.RemoveSubscription<T, TH>();
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <param name="eventName"></param>
        public void UnsubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler
        {
            _subsManager.RemoveDynamicSubscription<TH>(eventName);
        }


        public void Dispose()
        {
            if (_iModel != null)
                _iModel.Dispose();
            _subsManager.Clear();
        }


        

       
    }
}
