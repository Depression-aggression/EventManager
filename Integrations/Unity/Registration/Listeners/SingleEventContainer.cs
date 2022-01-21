using System;
using Depra.Events.Runtime.Core.Dispose;
using Depra.Events.Runtime.Core.Registration.Containers;
using Depra.Events.Runtime.Managers;
using UnityEngine;
using UnityEngine.Events;
using Void = Depra.Events.Integrations.Toolkit.SO.Structs.Void;

namespace Depra.Events.Integrations.Toolkit.Registration.Listeners
{
    [Serializable]
    [AddTypeMenu("Single")]
    public class SingleEventContainer : IEventListenerContainer<SO.Structs.Void>
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public UnityEvent Action { get; set; }

        protected readonly EventDisposal Disposal = new EventDisposal();

        public void OnEventInvoked(SO.Structs.Void item)
        {
            Action.Invoke();
        }

        public void Subscribe()
        {
            EventManager.Subscribe(Name, _ => OnEventInvoked(default)).AddTo(Disposal);
        }

        public void Unsubscribe()
        {
            Disposal.Dispose();
        }
    }
}