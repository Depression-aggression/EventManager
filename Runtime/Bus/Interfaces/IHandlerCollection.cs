using System.Collections.Generic;
using Depra.EventSystem.Core.Bus.Interfaces;

namespace Depra.EventSystem.Runtime.Core.Bus.Interfaces
{
    public interface IHandlerCollection
    {
        IEventBus Bus { get; }

        void AddHandlers(IList<IHandler> list);

        void RemoveSubscription(SubscriptionToken subscription);
    }
}