using System;
using System.Collections.Generic;
using Depra.EventManager.Core.Events.Base;

namespace Depra.EventManager.Core.Events.Dynamic
{
    public class DynamicArgsEvent : EventBase
    {
        private readonly Dictionary<string, List<Action<dynamic[]>>> _actions = new Dictionary<string, List<Action<dynamic[]>>>();

        public void Add(string key, Action<dynamic[]> action) 
        {
            if (_actions.ContainsKey(key) == false)
            {
                _actions.Add(key, new List<Action<dynamic[]>>());
            }
            
            _actions[key].Add(action);
        }

        public void Remove(string key, Action<dynamic[]> action)
        {
            if (_actions.TryGetValue(key, out var val))
            {
                val.Remove(action);
            }
        }
        
        public void Invoke(string key, params dynamic[] parameters)
        {
            if (_actions.TryGetValue(key, out var actions) == false)
            {
                return;
            }

            foreach (var action in actions)
            {
                action?.Invoke(parameters);
            }
        }
    }
}

