﻿using System;
using System.Collections.Generic;
using Depra.EventManager.Core.Dispose;
using Depra.EventManager.Core.Events.Base;
using Depra.EventManager.Core.Events.Static;

namespace Depra.EventManager.Core.Handler.Static
{
    public static class GenericEventHandler
    {
        private static readonly Dictionary<Type, EventBase> Events = new Dictionary<Type, EventBase>();

        public static DisposeContainer Add<T>(string key, Action<T> action)
        {
            var type = typeof(T);
            
            GenericEvent<T> genericEvent;
            if (Events.ContainsKey(type) == false)
            {
                genericEvent = new GenericEvent<T>();
                Events.Add(type, genericEvent);
            }
            else
            {
                genericEvent = Events[type] as GenericEvent<T>;
            }

            genericEvent?.Add(key, action);

            return new DisposeContainer(() => Remove(key, action));
        }

        public static void Remove<T>(string key, Action<T> action)
        {
            if (Events.TryGetValue(typeof(T), out var baseEvent) == false)
            {
                return;
            }

            var genericEvent = baseEvent as GenericEvent<T>;
            genericEvent?.Remove(key, action);
        }

        public static void Invoke<T>(string key, T arg)
        {
            if (Events.TryGetValue(typeof(T), out var baseEvent) == false)
            {
                return;
            }
            
            var genericEvent = baseEvent as GenericEvent<T>;
            genericEvent?.Invoke(key, arg);
        }
    }
}