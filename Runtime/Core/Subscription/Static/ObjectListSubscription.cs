using System;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Core.Subscription.Interfaces;

namespace Depra.Events.Runtime.Core.Subscription
{
    internal class ObjectListSubscription : ISubscription
    {
        public ISubscriptionToken SubscriptionToken { get; }

        private readonly Action<object[]> _action;

        public void Publish(params object[] args)
        {
            _action.Invoke(args);
        }
        
        internal ObjectListSubscription(Action<object[]> action, ISubscriptionToken token)
        {
            _action = action;
            SubscriptionToken = token ?? throw new ArgumentNullException(nameof(token));
        }

        public bool Equals(ISubscriptionToken other)
        {
            return other != null && SubscriptionToken.InternalToken.Equals(other.InternalToken);
        }
    }
}