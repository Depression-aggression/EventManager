using System;
using Depra.EventSystem.Core.Dispose;
using Depra.EventSystem.Core.Events.Dynamic;

namespace Depra.EventSystem.Core.Handlers.Dynamic
{
    public static class DynamicArgHandler
    {
        private static DynamicArgEvent _events;

        public static DisposeContainer Add(string key, Action<dynamic> action)
        {
            _events ??= new DynamicArgEvent();
            _events.Add(key, action);

            return new DisposeContainer(() => Remove(key, action));
        }

        public static void Remove(string key, Action<dynamic> action)
        {
            _events?.Remove(key, action);
        }

        public static void Invoke(string key, dynamic value)
        {
            if (_events != null)
            {
                _events.Invoke(key, value);
            }
        }
    }
}