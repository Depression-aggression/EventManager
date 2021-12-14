using Depra.EventSystem.Runtime.Core.Events.Base;

namespace Depra.EventSystem.Runtime.Core.Bus.Interfaces
{
    public interface IHandlerCollection<TEvent> : IHandlerCollection where TEvent : EventBase
    {
        void Handle(TEvent eventObject);
    }
}