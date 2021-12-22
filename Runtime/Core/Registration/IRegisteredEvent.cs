using Depra.EventSystem.Runtime.Core.Events.Base;
using Depra.EventSystem.Runtime.Core.Registration.Listeners;

namespace Depra.EventSystem.Integrations.Toolkit.SO.Events
{
    public interface IRegisteredEvent<T> : IEvent
    {
        void Invoke(T value);

        void RegisterListener(IEventListener<T> listener);

        void UnregisterListener(IEventListener<T> listener);
    }
}