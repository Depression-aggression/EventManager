using System;
using Depra.Events.Runtime.Core.Dispose;
using Depra.Events.Runtime.Core.Events.Dynamic;

namespace Depra.Events.Runtime.Core.Handlers.Dynamic
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