using System;
using Depra.EventSystem.Core.Bus;
using Depra.EventSystem.Core.Bus.Interfaces;
using Depra.EventSystem.Runtime.Core.Events.Base;

namespace Depra.EventSystem.Runtime.Core.Bus.Extensions
{
    public static class EventBusExtensions
    {
        public static void Publish(this EventBase eventBase, IEventBus eventBus)
        {
            eventBus.Publish(eventBase);
        }

        public static void PublishAsync(this EventBase eventBase, IEventBus eventBus)
        {
            eventBus.PublishAsync(eventBase);
        }

        public static void PublishAsync(this EventBase eventBase, IEventBus eventBus, AsyncCallback asyncCallback)
        {
            eventBus.PublishAsync(eventBase, asyncCallback);
        }

        public static void Unsubscribe(this SubscriptionToken token, IEventBus eventBus)
        {
            eventBus.Unsubscribe(token);
        }
    }
}