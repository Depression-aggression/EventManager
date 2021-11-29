using System;
using Depra.EventSystem.Core.Bus.Interfaces;
using Depra.EventSystem.Core.Events.Base;

namespace Depra.EventSystem.Core.Bus
{
    internal class Subscription<TEventBase> : ISubscription where TEventBase : EventBase
    {
        public SubscriptionToken SubscriptionToken { get; }

        private readonly Action<TEventBase> _action;
        
        public Subscription(Action<TEventBase> action, SubscriptionToken token)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            SubscriptionToken = token ?? throw new ArgumentNullException(nameof(token));
        }

        public void Publish(EventBase eventItem)
        {
            if (!(eventItem is TEventBase))
            {
                throw new ArgumentException("Event Item is not the correct type.");
            }

            _action.Invoke(eventItem as TEventBase);
        }
    }
}