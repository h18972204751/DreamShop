using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Abstractions
{
    /// <summary>
    /// 发布订阅接口(事件总线接口)
    /// </summary>
    public interface  IEventBus
    {
        //Publish 方法很简单。 事件总线会向订阅该事件的任何微服务或外部应用程序，广播经过它的集成事件。 该方法由发布事件的微服务使用。

        //Subscribe 方法（你可能有多个实现，具体取决于参数）由要接收事件的微服务使用。 此方法具有两个参数。 第一个是要订阅的集成事件 (IntegrationEvent)。 第二个参数是名为 IIntegrationEventHandler<T> 的集成事件处理程序（或回调方法），用于在接收者微服务获得集成事件消息时执行。
        //发布的内容（消息）必须是IntegrationEvent及其子类
        //订阅事件必须指明要订阅事件的类型，并附带处理器类型
        //处理器必须是IIntegrationEventHandler的实现类



        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="event"></param>
        void Publish(IntegrationEvent @event);


        /// <summary>
        /// 订阅
        /// </summary>
        void Subscribe<T,TH>() where T: IntegrationEvent where TH: IIntegrationEventHandler<T>;

        /// <summary>
        /// 订阅(动态)
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <param name="eventName"></param>
        void SubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler;



        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IntegrationEvent;


        /// <summary>
        /// 取消订阅（动态）
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <param name="eventName"></param>
        void UnsubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler;

        
    }
}
