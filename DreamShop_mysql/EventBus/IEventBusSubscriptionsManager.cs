using EventBus.Abstractions;
using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;
using static EventBus.InMemoryEventBusSubscriptionsManager;

namespace EventBus
{
    /// <summary>
    /// 事件处理接口
    /// </summary>
    public interface IEventBusSubscriptionsManager
    {
        bool IsEmpty { get; }

        /// <summary>
        /// 定义事件移除后事件
        /// </summary>
        event EventHandler<string> OnEventRemoved;

        /// <summary>
        /// 添加订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        void AddSubscription<T,TH>()
            where T:IntegrationEvent
            where TH: IIntegrationEventHandler<T>;


        /// <summary>
        /// 动态添加订阅
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <param name="eventName"></param>
        void AddDynamicSubscription<TH>(string eventName) where TH : IDynamicIntegrationEventHandler;

        /// <summary>
        /// 移除订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        void RemoveSubscription<T,TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        /// <summary>
        /// 动态移除订阅
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <param name="eventName"></param>
        void RemoveDynamicSubscription<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler;
        /// <summary>
        /// 查看是否有订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent;

        /// <summary>
        /// 动态查看是否有订阅
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        bool HasSubscriptionsForEvent(string eventName);

        /// <summary>
        /// 获取事件的Type
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        Type GetEventTypeByName(string eventName);


        /// <summary>
        /// 获取指定事件的订阅信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent;

        /// <summary>
        /// 获取指定事件的订阅信息
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);

        /// <summary>
        /// 获取事件名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        string GetEventKey<T>();

        /// <summary>
        /// 清除
        /// </summary>
        void Clear();
    }
}
