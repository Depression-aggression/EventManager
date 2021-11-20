using System;
using Depra.EventManager.Core.Dispose;
using Depra.EventManager.Core.Events.Static;

namespace Depra.EventManager.Core.Handler.Static
{
    public static class ObjectArgsHandler
    {
        private static ObjectArgsEvent _events;

        public static DisposeContainer Add(string key, Action<object[]> action)
        {
            _events ??= new ObjectArgsEvent();
            _events.Add(key, action);

            return new DisposeContainer(() =>Remove(key, action));
        }

        public static void Remove(string key, Action<object[]> action)
        {
            _events?.Remove(key, action);
        }

        public static void Invoke(string key, params object[] arg)
        {
            _events?.Invoke(key);
        }
    }
}