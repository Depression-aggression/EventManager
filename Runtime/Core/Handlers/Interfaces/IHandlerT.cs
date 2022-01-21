using System;
using Depra.Events.Runtime.Core.Events.Base;
using Depra.Events.Runtime.Core.Handlers.Interfaces;

namespace Depra.Events.Runtime.Bus.Subscription.Interfaces
{
    internal interface IHandler<in TEvent> : IHandler where TEvent : IEvent
    {
        /// <summary>
        /// Handler action.
        /// </summary>
        Action<TEvent> Action { get; }
        
        /// <summary>
        /// Called when appropriate message is being dispatched.
        /// </summary>
        /// <param name="eventObj"></param>
        void Handle(TEvent eventObj);
    }
}