using System;
using Depra.Events.Runtime.Bus.Subscription.Tokens;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;

namespace Depra.Events.Runtime.Core.Subscription.Tokens.Factory
{
    [Serializable]
    public class GuidSubscriptionTokenFactory : ISubscriptionTokenFactory
    {
        public ISubscriptionToken Create(Type eventType)
        {
            return new GuidToken(eventType);
        }
    }
}