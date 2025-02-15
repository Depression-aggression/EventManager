namespace Depra.Events.Runtime.Core.Registration.Listeners
{
    public interface IEventListener<in T> : IEventListener
    {
        void OnEventInvoked(T item);
    }
}