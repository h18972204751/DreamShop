using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

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
    }
}
