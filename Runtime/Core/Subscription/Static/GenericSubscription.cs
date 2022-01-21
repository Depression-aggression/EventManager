using System;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Core.Subscription.Interfaces;

namespace Depra.Events.Runtime.Core.Subscription
{
    internal class GenericSubscription<T> : ISubscription<T>
    {
        public ISubscriptionToken SubscriptionToken { get; }
        internal Type EventItemType { get; }

        private readonly Action<T> _action;
        
        public void Publish(T argument)
        {
            _action?.Invoke(argument);
        }

        internal GenericSubscription(Action<T> action, ISubscriptionToken token)
        {
            _action = action;
            SubscriptionToken = token;
            EventItemType = typeof(T);
        }
        
        public bool Equals(ISubscriptionToken other)
        {
            return SubscriptionToken.InternalToken.Equals(other?.InternalToken);
        }
    }
}