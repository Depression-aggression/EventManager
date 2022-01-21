using System;
using Depra.Events.Runtime.Bus.Configuration;
using Depra.Events.Runtime.Core.Events.Base;
using Depra.Events.Runtime.Core.Handlers.Interfaces;
using Depra.Events.Runtime.Core.Subscription.Containers;
using Depra.Events.Runtime.Core.Subscription.Interfaces;

namespace Depra.Events.Runtime.Core.Handlers.Generic
{
    internal abstract class EventHandlerBase<TEvent, TToken> : IHandler, IDisposable where TEvent : class, IEvent
    {
        public Type HandledType { get; }
        
        internal ISubscriptionContainer<ISubscription, TToken> Container { get; }

        protected IEventHandlerConfiguration Configuration { get; }

        internal abstract void UnsubscribeAll();
        
        internal EventHandlerBase(ISubscriptionContainer<ISubscription, TToken> container,
            IEventHandlerConfiguration configuration = null)
        {
            Container = container;
            Configuration = configuration ?? new EventHandlerConfiguration();
            HandledType = typeof(TEvent);
        }

        public void Dispose()
        {
            UnsubscribeAll();
        }
    }
}