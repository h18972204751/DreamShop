using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Abstractions
{
    public interface  IEventBus
    {

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="RoutingKey"></param>
        /// <param name="Model"></param>
        void Publish(string RoutingKey, object Model);


        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="QueusName">队列名</param>
        /// <param name="RoutingKey">路由键</param>
        /// <param name="ExchangeName">交换器名</param>
        void Subscribe(string QueusName, string RoutingKey, string ExchangeName = "");

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="QueusName"></param>
        /// <param name="RotingKey"></param>
        void UnSubscribe(string QueusName, string RotingKey);





    }
}
