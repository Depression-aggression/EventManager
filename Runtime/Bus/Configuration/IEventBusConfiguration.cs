namespace Depra.EventSystem.Runtime.Core.Bus.Configuration
{
    public interface IEventBusConfiguration
    {
        bool ThrowSubscriberException { get; }
    }
}