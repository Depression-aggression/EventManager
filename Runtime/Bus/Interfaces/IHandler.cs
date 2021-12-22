using System;
using Depra.EventSystem.Runtime.Bus.Enums;
using Depra.EventSystem.Runtime.Core.Events.Base;

namespace Depra.EventSystem.Runtime.Bus.Interfaces
{
    public interface IHandler
    {
        Type HandledType { get; }
        
        SubscriptionToken Subscription { get; set; }
        
        HandlerPriority Priority { get; }
    }

    public interface IHandler<TEvent> : IHandler where TEvent : IEvent
    {
        /// <summary>
        /// Handler action
        /// </summary>
        Action<TEvent> Action { get; }

        /// <summary>
        /// Called when appropriate message is being dispatched
        /// </summary>
        /// <param name="eventObj"></param>
        void Handle(TEvent eventObj);
    }
}