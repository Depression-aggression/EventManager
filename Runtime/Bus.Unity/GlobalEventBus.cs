using Depra.EventSystem.Runtime.Core.Events.Base;

namespace Depra.EventSystem.Runtime.Bus.Unity
{
    public class GlobalEventBus : EventBus
    {
        public static GlobalEventBus Instance => _instance ??= new GlobalEventBus();

        private static GlobalEventBus _instance;

        public new static void Publish<TEvent>(TEvent eventBase) where TEvent : IEvent
        {
            ((EventBus)Instance).Publish(eventBase);
        }
    }
}