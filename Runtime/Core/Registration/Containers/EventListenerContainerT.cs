using Depra.Events.Runtime.Core.Registration.Listeners;

namespace Depra.Events.Runtime.Core.Registration.Containers
{
    public interface IEventListenerContainer<in T> : IEventListenerContainer, IEventListener<T>
    {
    }
}