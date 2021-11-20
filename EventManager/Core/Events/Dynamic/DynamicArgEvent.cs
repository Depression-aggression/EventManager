﻿using System;
using System.Collections.Generic;
using Depra.EventManager.Core.Events.Base;

namespace Depra.EventManager.Core.Events.Dynamic
{
    public class DynamicArgEvent : EventBase 
    {
        private readonly Dictionary<string, List<Action<dynamic>>> _events = new Dictionary<string, List<Action<dynamic>>>();

        public void Add(string key, Action<dynamic> action)
        {
            if (_events.ContainsKey(key) == false)
            {
                _events.Add(key,new List<Action<dynamic>>());
            }
            _events[key].Add(action);
        }

        public void Remove(string key, Action<dynamic> action)
        {
            if (_events.TryGetValue(key, out var list))
            {
                list.Remove(action);
            }
        }

        public void Invoke(string key, dynamic value)
        {
            if (_events.TryGetValue(key, out var lastInvokeList) == false)
            {
                return;
            }

            foreach (var action in lastInvokeList)
            {
                action?.Invoke(value);
            }
        }
    }
}