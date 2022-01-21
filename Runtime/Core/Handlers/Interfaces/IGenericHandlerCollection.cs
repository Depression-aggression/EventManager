using Depra.Events.Runtime.Core.Events.Base;

namespace Depra.Events.Runtime.Bus.Subscription.Interfaces
{
    internal interface IHandlerCollection<in TEvent> : IHandlerCollection where TEvent : IEvent
    {
        void Handle(TEvent eventObject);
    }
}