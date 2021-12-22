using System;
using Depra.EventSystem.Runtime.Core.Dispose;
using Depra.EventSystem.Runtime.Core.Managers;
using Depra.EventSystem.Runtime.Core.Registration.Containers;
using Depra.Toolkit.Serialization.CustomSR;
using UnityEngine;
using UnityEngine.Events;
using Void = Depra.EventSystem.Integrations.Toolkit.SO.Structs.Void;

namespace Depra.EventSystem.Integrations.Toolkit.Registration.Listeners
{
    [Serializable]
    [CustomSerializeReferenceName("Single")]
    public class SingleEventContainer : IEventListenerContainer<Void>
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public UnityEvent Action { get; set; }

        protected readonly EventDisposal Disposal = new EventDisposal();

        public void OnEventInvoked(Void item)
        {
            Action.Invoke();
        }

        public void Subscribe()
        {
            EventManager.Add(Name, _ => OnEventInvoked(default)).AddTo(Disposal);
        }

        public void Unsubscribe()
        {
            Disposal.Dispose();
        }
    }
}