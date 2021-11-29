namespace Depra.EventSystem.Core.Bus.Configuration
{
    public interface IEventBusConfiguration
    {
        bool ThrowSubscriberException { get; }
    }
}