using Depra.Events.Runtime.Core.Events.Base;
using Depra.Events.Runtime.Core.Registration.Listeners;

namespace Depra.Events.Integrations.Toolkit.SO.Events
{
    public interface IRegisteredEvent<T> : IEvent
    {
        void Invoke(T value);

        void RegisterListener(IEventListener<T> listener);

        void UnregisterListener(IEventListener<T> listener);
    }
}