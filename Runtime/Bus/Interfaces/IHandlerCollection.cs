using System.Collections.Generic;

namespace Depra.EventSystem.Runtime.Bus.Interfaces
{
    public interface IHandlerCollection
    {
        IEventBus Bus { get; }

        void AddHandlers(IList<IHandler> list);

        void RemoveSubscription(SubscriptionToken subscription);
    }
}