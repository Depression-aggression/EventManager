using Depra.EventSystem.Runtime.Core.Events.Base;

namespace Depra.EventSystem.Runtime.Bus.Interfaces
{
    public interface IHandlerCollection<TEvent> : IHandlerCollection where TEvent : IEvent
    {
        void Handle(TEvent eventObject);
    }
}