using System;
using Depra.EventSystem.Integrations.Toolkit.SO.Events;
using Depra.EventSystem.Runtime.Core.Registration.Containers;
using Depra.Toolkit.Serialization.CustomSR;
using UnityEngine;
using UnityEngine.Events;
using Void = Depra.EventSystem.Integrations.Toolkit.SO.Structs.Void;

namespace Depra.EventSystem.Integrations.Toolkit.Registration.Listeners
{
    [Serializable]
    [CustomSerializeReferenceName("Scriptable")]
    public class GameEventContainer : IEventListenerContainer<Void>
    {
        [SerializeField] private VoidGameEvent _event;
        [SerializeField] private UnityEvent _unityEventResponse;

        public void OnEventInvoked(Void item)
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