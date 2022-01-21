using System;

namespace Depra.Events.Runtime.Core.Subscription.Tokens.Base
{
    public abstract class SubscriptionToken<T> : SubscriptionToken where T : IEquatable<T>
    {
        public T Token { get; set; }

        public override string InternalToken => ConvertTokenToString(Token);

        protected abstract string ConvertTokenToString(T token);
        
        public bool Equals(SubscriptionToken<T> other)
        {
            return InternalToken.Equals(other.InternalToken);
        }
    }
}