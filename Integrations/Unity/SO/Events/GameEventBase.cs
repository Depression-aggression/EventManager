using System.Collections.Generic;
using Depra.Events.Runtime.Core.Registration.Listeners;
using Depra.Events.Runtime.Core.Registration;
using UnityEngine;

namespace Depra.Events.Integrations.Toolkit.SO.Events
{
    public abstract class GameEventBase<T> : ScriptableObject, IRegisteredEvent<T>
    {
        private readonly HashSet<IEventListener<T>> _listeners = new HashSet<IEventListener<T>>();
        
        public void Invoke(T item)
        {
            foreach (var listener in _listeners)
            {
                listener.OnEventInvoked(item);
            }
        }

        public void RegisterListener(IEventListener<T> listener)
        {
            _listeners.Add(listener);
        }

        public void UnregisterListener(IEventListener<T> listener)
        {
            _listeners.Remove(listener);
        }
    }
}