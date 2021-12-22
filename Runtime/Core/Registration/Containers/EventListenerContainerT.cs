using Depra.EventSystem.Runtime.Core.Registration.Listeners;

namespace Depra.EventSystem.Runtime.Core.Registration.Containers
{
    public interface IEventListenerContainer<in T> : IEventListenerContainer, IEventListener<T>
    {
    }
}