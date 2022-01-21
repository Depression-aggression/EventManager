using System;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;

namespace Depra.Events.Runtime.Core.Subscription.Interfaces
{
    public interface ISubscription : IEquatable<ISubscriptionToken>
    {
        ISubscriptionToken SubscriptionToken { get; }
        
        new bool Equals(ISubscriptionToken token);
    }
    
    public interface ISubscription<in T> : ISubscription
    {
        /// <summary>
        /// Publish to the subscriber.
        /// </summary>
        /// <param name="argument"></param>
        void Publish(T argument);
    }
}