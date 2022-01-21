using System;
using Depra.Events.Runtime.Bus.Subscription.Enums;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Core.Subscription.Tokens.Factory;

namespace Depra.Events.Runtime.Bus.Configuration
{
    public interface IEventHandlerConfiguration
    {
        HandlerPriority Priority { get; }
        ISubscriptionTokenFactory TokenFactory { get; }

        bool ThrowSubscriberException { get; }
        bool ThrowNullException { get; }

        // public ISubscriptionToken GenerateToken(Type eventType)
        // {
        //     return TokenFactory.Create(eventType);
        // }
    }
}