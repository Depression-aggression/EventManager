using System;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Core.Events.Base;
using Depra.Events.Runtime.Core.Subscription.Interfaces;

namespace Depra.Events.Runtime.Core.Subscription
{
    internal class Subscription<TEvent> : ISubscription<IEvent> where TEvent : class, IEvent
    {
        public ISubscriptionToken SubscriptionToken { get; }
        public Type EventItemType { get; }

        private readonly Action<TEvent> _action;

        public Subscription(Action<TEvent> action, ISubscriptionToken token)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            SubscriptionToken = token ?? throw new ArgumentNullException(nameof(token));
            EventItemType = typeof(TEvent);
        }

        public void Publish(TEvent eventItem)
        {
            _action.Invoke(eventItem);
        }
        
        public void Publish(IEvent eventItem)
        {
            var concreteEvent = (TEvent)eventItem;
            if (concreteEvent == null)
            {
                throw new ArgumentException("Event Item is not the correct type.");
            }

            _action.Invoke(concreteEvent);
        }

        #region Overrides

        internal bool Validate()
        {
            return SubscriptionToken.Validate();
        }

        public bool Equals(ISubscriptionToken token)
        {
            return SubscriptionToken.InternalToken.Equals(token?.InternalToken);
        }

        public override string ToString()
        {
            return SubscriptionToken.InternalToken;
        }
        
        #endregion
    }
}