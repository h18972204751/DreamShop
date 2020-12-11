using System;

namespace EventBus
{
    public partial class InMemoryEventBusSubscriptionsManager : IEventBusSubscriptionsManager
    {
        /// <summary>
        /// 是否为Dynamic类型  以及这个Event所对应的处理器的类型 
        /// </summary>
        public class SubscriptionInfo
        {
            /// <summary>
            /// 是否为Dynamic类型
            /// </summary>
            public bool IsDynamic { get; }

            /// <summary>
            /// Event所对应的处理器的类型
            /// </summary>
            public Type HandlerType { get; }

            private SubscriptionInfo(bool isDynamic, Type handlerType)
            {
                IsDynamic = isDynamic;
                HandlerType = handlerType;
            }

            /// <summary>
            /// Dynamic类型
            /// </summary>
            /// <param name="handlerType"></param>
            /// <returns></returns>
            public static SubscriptionInfo Dynamic(Type handlerType)
            {
                return new SubscriptionInfo(true, handlerType);
            }
            /// <summary>
            /// 不为Dynamic类型
            /// </summary>
            /// <param name="handlerType"></param>
            /// <returns></returns>
            public static SubscriptionInfo Typed(Type handlerType)
            {
                return new SubscriptionInfo(false, handlerType);
            }
        }
    }
}