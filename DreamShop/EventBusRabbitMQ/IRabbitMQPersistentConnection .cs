﻿using RabbitMQ.Client;
using System;

namespace EventBusRabbitMQ
{
    /// <summary>
    /// 检查RabbitMQ的连接和释放：
    /// </summary>
    public interface IRabbitMQPersistentConnection : IDisposable
    {

        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();

    }
}
