using EventBus.Abstractions;
using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventBus
{
    /// <summary>
    /// 事件处理实现类
    /// </summary>
    public partial class InMemoryEventBusSubscriptionsManager : IEventBusSubscriptionsManager
    {
        /// <summary>
        /// 定义的事件名称和事件订阅的字典映射（1:N）
        /// </summary>
        private readonly Dictionary<string, List<SubscriptionInfo>> _handlers;

        /// <summary>
        /// 保存所有的事件处理类型
        /// </summary>
        private readonly List<Type> _eventTypes;

        /// <summary>
        /// 定义事件移除后事件
        /// </summary>
        public event EventHandler<string> OnEventRemoved;

        /// <summary>
        /// 事件处理实现类 构造函数初始化
        /// </summary>
        public InMemoryEventBusSubscriptionsManager()
        {
            _handlers = new Dictionary<string, List<SubscriptionInfo>>();
            _eventTypes = new List<Type>();
        }

        public bool IsEmpty => !_handlers.Keys.Any();

        public void Clear() => _handlers.Clear();

        /// <summary>
        /// 添加动态类型事件订阅（需要手动指定事件名称）
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <param name="eventName"></param>
        public void AddDynamicSubscription<TH>(string eventName) where TH : IDynamicIntegrationEventHandler
        {
            DoAddSubscription(typeof(TH), eventName,true);
        }


        /// <summary>
        /// 添加强类型事件订阅（事件名称为事件源类型）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        public void AddSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>
        {

            var eventName = GetEventKey<T>();
            DoAddSubscription(typeof(TH), eventName, false);
            if (!_eventTypes.Contains(typeof(T)))
                _eventTypes.Add(typeof(T));
        }

        /// <summary>
        /// 移除动态类型事件订阅
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <param name="eventName"></param>
        public void RemoveDynamicSubscription<TH>(string eventName)where TH : IDynamicIntegrationEventHandler
        {
            var handlerToRemove = FindDynamicSubscriptionToRemove<TH>(eventName);
            DoRemoveHandler(eventName, handlerToRemove);
        }

        /// <summary>
        /// 移除强类型事件订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        public void RemoveSubscription<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IntegrationEvent
        {
            var handlerToRemove = FindSubscriptionToRemove<T, TH>();
            var eventName = GetEventKey<T>();
            DoRemoveHandler(eventName, handlerToRemove);
        }

        /// <summary>
        /// 获取指定事件的订阅信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent
        {
            var key = GetEventKey<T>();
            return GetHandlersForEvent(key);
        }
        /// <summary>
        /// 获取指定事件的订阅信息
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName) => _handlers[eventName];


        /// <summary>
        /// 移除事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="subsToRemove"></param>
        private void DoRemoveHandler(string eventName, SubscriptionInfo subsToRemove)
        {
            if (eventName is not null)
            {
                _handlers[eventName].Remove(subsToRemove);
                if (!_handlers[eventName].Any())
                {
                    _handlers.Remove(eventName);
                    var eventType = _eventTypes.SingleOrDefault(e => e.Name == eventName);
                    if (eventType is not null)
                        _eventTypes.Remove(eventType);
                    RaiseOnEventRemoved(eventName);
                }
            }
        }

        /// <summary>
        /// 移除后执行的事件
        /// </summary>
        /// <param name="eventName"></param>
        public void RaiseOnEventRemoved(string eventName)
        {
            var handler = OnEventRemoved;
            handler?.Invoke(this, eventName);
        }

        /// <summary>
        /// 添加事件订阅
        /// </summary>
        /// <param name="handlerType">处理器类型</param>
        /// <param name="eventName">事件名</param>
        /// <param name="isDynamic"></param>
        private void DoAddSubscription(Type handlerType, string eventName, bool isDynamic)
        {
            if (!HasSubscriptionsForEvent(eventName))
            {
                _handlers.Add(eventName, new List<SubscriptionInfo>());
            }

            if (_handlers[eventName].Any(s => s.HandlerType == handlerType))
            {
                throw new ArgumentException(
                    $"处理器类型 {handlerType.Name} 已经注册 '{eventName}'", nameof(handlerType));
            }

            if (isDynamic)
            {
                _handlers[eventName].Add(SubscriptionInfo.Dynamic(handlerType));
            }
            else
            {
                _handlers[eventName].Add(SubscriptionInfo.Typed(handlerType));
            }
        }



        /// <summary>
        /// 获取动态事件
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <param name="eventName"></param>
        /// <returns></returns>
        private SubscriptionInfo FindDynamicSubscriptionToRemove<TH>(string eventName) where TH : IDynamicIntegrationEventHandler
        {
            return DoFindSubscriptionToRemove(eventName, typeof(TH));
        }

        /// <summary>
        /// 获取事件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        /// <returns></returns>
        private SubscriptionInfo FindSubscriptionToRemove<T, TH>()
             where T : IntegrationEvent
             where TH : IIntegrationEventHandler<T>
        {
            var eventName = GetEventKey<T>();
            return DoFindSubscriptionToRemove(eventName, typeof(TH));
        }

        /// <summary>
        /// 获取事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="handlerType"></param>
        /// <returns></returns>
        private SubscriptionInfo DoFindSubscriptionToRemove(string eventName, Type handlerType)
        {
            if (!HasSubscriptionsForEvent(eventName))
            {
                return null;
            }

            return _handlers[eventName].SingleOrDefault(s => s.HandlerType == handlerType);

        }

        public bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent
        {
            var key = GetEventKey<T>();
            return HasSubscriptionsForEvent(key);
        }
        public bool HasSubscriptionsForEvent(string eventName) => _handlers.ContainsKey(eventName);

        public Type GetEventTypeByName(string eventName) => _eventTypes.SingleOrDefault(t => t.Name == eventName);


        public string GetEventKey<T>()
        {
            return typeof(T).Name;
        }
    }
}
