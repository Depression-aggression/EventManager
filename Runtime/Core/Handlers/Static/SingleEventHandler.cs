using System;
using Depra.EventSystem.Runtime.Core.Dispose;
using Depra.EventSystem.Runtime.Core.Events.Static;

namespace Depra.EventSystem.Runtime.Core.Handlers.Static
{
    public static class SingleEventHandler
    {
        private static SingleEvent _singleEvents;

        public static DisposeContainer Add(string key, Action action)
        {
            _singleEvents ??= new SingleEvent();
            _singleEvents.Add(key, action);

            return new DisposeContainer(() => Remove(key, action));
        }

        public static void Remove(string key, Action action)
        {
            _singleEvents?.Remove(key, action);
        }

        public static void Invoke(string key)
        {
            _singleEvents?.Invoke(key);
        }
    }
}