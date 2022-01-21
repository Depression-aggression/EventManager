using System;
using Depra.Events.Integrations.Toolkit.SO.Events;
using Depra.Events.Runtime.Core.Registration.Containers;
using UnityEngine;
using UnityEngine.Events;
using Void = Depra.Events.Integrations.Toolkit.SO.Structs.Void;

namespace Depra.Events.Integrations.Toolkit.Registration.Listeners
{
    [Serializable]
    [AddTypeMenu("Scriptable")]
    public class GameEventContainer : IEventListenerContainer<SO.Structs.Void>
    {
        [SerializeField] private VoidGameEvent _event;
        [SerializeField] private UnityEvent _unityEventResponse;

        public void OnEventInvoked(SO.Structs.Void item)
        {
            _unityEventResponse.Invoke();
        }

        public void Subscribe()
        {
            _event.RegisterListener(this);
        }

        public void Unsubscribe()
        {
            _event.UnregisterListener(this);
        }
    }
}