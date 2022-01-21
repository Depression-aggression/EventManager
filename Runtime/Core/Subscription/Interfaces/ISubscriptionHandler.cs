using System;
using Depra.Events.Runtime.Bus.Subscription.Enums;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;

namespace Depra.Events.Runtime.Bus.Subscription.Interfaces
{
    public interface ISubscriptionHandler
    {
        Type HandledType { get; }
        
        ISubscriptionToken Subscription { get; set; }
        
        HandlerPriority Priority { get; }
    }
}