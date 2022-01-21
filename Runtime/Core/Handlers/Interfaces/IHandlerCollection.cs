using System.Collections.Generic;
using Depra.Events.Runtime.Bus.Interfaces;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Core.Handlers.Interfaces;

namespace Depra.Events.Runtime.Bus.Subscription.Interfaces
{
    internal interface IHandlerCollection
    {
        IEventBus Bus { get; }

        void AddHandlers(IList<IHandler> list);

        void RemoveSubscription(ISubscriptionToken subscription);
    }
}