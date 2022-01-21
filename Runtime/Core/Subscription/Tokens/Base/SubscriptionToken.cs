using System;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;

namespace Depra.Events.Runtime.Core.Subscription.Tokens.Base
{
    public abstract class SubscriptionToken : ISubscriptionToken, IEquatable<SubscriptionToken>
    {
        public abstract string InternalToken { get; }

        public Type EventItemType { get; protected set; }

        public bool Equals(SubscriptionToken other)
        {
            return string.Equals(InternalToken, other?.InternalToken);
        }

        bool ISubscriptionToken.Validate()
        {
            return InternalToken.Equals(string.Empty);
        }
    }
}