using System;
using System.Collections.Generic;
using Depra.Events.Runtime.Core.Events.Base;

namespace Depra.Events.Runtime.Core.Events.Dynamic
{
    internal class DynamicSubscriptionContainer : Dictionary<string, List<Action<dynamic[]>>>
    {
    }
    
    public class DynamicArgsEvent : IEvent
    {
        private readonly DynamicSubscriptionContainer _subscriptions;

        public DynamicArgsEvent()
        {
            _subscriptions = new DynamicSubscriptionContainer();
        }
        
        public void Add(string key, Action<dynamic[]> action) 
        {
            if (_subscriptions.ContainsKey(key) == false)
            {
                _subscriptions.Add(key, new List<Action<dynamic[]>>());
            }
            
            _subscriptions[key].Add(action);
        }

        public void Remove(string key, Action<dynamic[]> action)
        {
            if (_subscriptions.TryGetValue(key, out var val))
            {
                val.Remove(action);
            }
        }
        
        public void Invoke(string key, params dynamic[] parameters)
        {
            if (_subscriptions.TryGetValue(key, out var actions) == false)
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

