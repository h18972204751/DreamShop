using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace EventBusRabbitMQ
{
    /// <summary>
    /// 实现RabbitMQ的连接和释放接口
    /// </summary>
    public class DefaultRabbitMQPersistentConnection: IRabbitMQPersistentConnection
    {
        /// <summary>
        /// 连接工厂
        /// </summary>
        private readonly IConnectionFactory _connectionFactory;
        /// <summary>
        /// 重试次数
        /// </summary>
        private readonly int _retryCount;
        /// <summary>
        /// 连接
        /// </summary>
        IConnection _connection;
        bool _disposed;
        /// <summary>
        /// 锁
        /// </summary>
        object sync_root = new object();

        public DefaultRabbitMQPersistentConnection(IConnectionFactory connectionFactory,  int retryCount = 5)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            _retryCount = retryCount;
        }
        public bool IsConnected
        {
            get
            {
                return _connection != null && _connection.IsOpen && !_disposed;
            }
        }

        /// <summary>
        /// 创建并返回一个新的通道、会话和模型。
        /// </summary>
        /// <returns></returns>
        public IModel CreateModel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("没有可用的RabbitMQ连接来执行此操作");
            }

            return _connection.CreateModel();
        }
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            if (_disposed) return;

            _disposed = true;

            try
            {
                _connection.Dispose();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public bool TryConnect()
        {
            Console.WriteLine("RabbitMQ客户端正在尝试连接");
            lock (sync_root)
            {
                var policy = RetryPolicy.Handle<SocketException>()
                    .Or<BrokerUnreachableException>()
                    .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                    {
                        Console.WriteLine($"RabbitMQ客户端在{time}s ({ex.Message})");
                    }
                );
                //在策略中执行指定的操作。
                policy.Execute(() =>
                {
                    //创建到指定端点的连接
                    _connection = _connectionFactory
                          .CreateConnection();
                });
                if (IsConnected)
                {
                    _connection.ConnectionShutdown += OnConnectionShutdown;
                    _connection.CallbackException += OnCallbackException;
                    _connection.ConnectionBlocked += OnConnectionBlocked;

                    Console.WriteLine($"RabbitMQ客户端获得了一个到'{_connection.Endpoint.HostName}'的持久连接，并订阅了失败事件");

                    return true;
                }
                else
                {
                    Console.WriteLine("致命错误:RabbitMQ连接无法创建和打开");

                    return false;
                }


            }
        }


        private void OnConnectionBlocked(object sender, ConnectionBlockedEventArgs e)
        {
            if (_disposed) return;

            Console.WriteLine("一个RabbitMQ连接被关闭。在贯通……");

            TryConnect();
        }

        void OnCallbackException(object sender, CallbackExceptionEventArgs e)
        {
            if (_disposed) return;

            Console.WriteLine("一个RabbitMQ连接抛出异常。在贯通……");

            TryConnect();
        }

        void OnConnectionShutdown(object sender, ShutdownEventArgs reason)
        {
            if (_disposed) return;

            Console.WriteLine("一个RabbitMQ连接正在关闭。在贯通……");

            TryConnect();
        }
    }
}
