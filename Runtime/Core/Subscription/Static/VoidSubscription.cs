using System;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Core.Subscription.Interfaces;

namespace Depra.Events.Runtime.Core.Subscription
{
    internal class VoidSubscription : ISubscription
    {
        public ISubscriptionToken SubscriptionToken { get; }

        public string Token => SubscriptionToken.InternalToken;
        public Type EventItemType { get; }

        private readonly Action _action;

        public VoidSubscription(Action action, ISubscriptionToken token)
        {
            _action = action;
            SubscriptionToken = token ?? throw new ArgumentNullException(nameof(token));
            EventItemType = typeof(void);
        }

        public void Publish()
        {
            _action.Invoke();
        }

        public bool Equals(ISubscriptionToken other)
        {
            return other != null && Token.Equals(other.InternalToken);
        }
    }
}