namespace Depra.EventSystem.Runtime.Bus.Configuration
{
    public interface IEventBusConfiguration
    {
        bool ThrowSubscriberException { get; }
    }
}