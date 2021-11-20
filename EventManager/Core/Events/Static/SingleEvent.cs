﻿using System;
using System.Collections.Generic;
using Depra.EventManager.Core.Events.Base;

namespace Depra.EventManager.Core.Events.Static
{
    public class SingleEvent : EventBase
    {
        private readonly Dictionary<string, List<Action>> _events = new Dictionary<string, List<Action>>();

        public void Add(string key, Action action)
        {
            if (_events.ContainsKey(key) == false)
            {
                _events.Add(key, new List<Action>());
            }

            _events[key].Add(action);
        }
        public void Remove(string key, Action action)
        {
            if (_events.TryGetValue(key, out var list))
            {
                list.Remove(action);
            }
        }

        public void Invoke(string key)
        {
            if (_events.TryGetValue(key, out var lastInvokeList) == false)
            {
                return;
            }
            
            foreach (var action in lastInvokeList)
            {
                action?.Invoke();
            }
        }

    }
}