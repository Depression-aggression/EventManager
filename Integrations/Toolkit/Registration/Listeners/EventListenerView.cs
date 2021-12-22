using Depra.EventSystem.Runtime.Core.Registration.Containers;
using Depra.EventSystem.Runtime.Core.Registration.Listeners;
using Depra.Toolkit.Serialization.CustomSR;
using UnityEngine;

namespace Depra.EventSystem.Integrations.Toolkit.Registration.Listeners
{
    public class EventListenerView : MonoBehaviour, IEventListener
    {
        [field: SR]
        [field: SerializeReference]
        public IEventListenerContainer[] Events { get; private set; }

        public void Subscribe()
        {
            foreach (var eventData in Events)
            {
                eventData.Subscribe();
            }
        }

        public void Unsubscribe()
        {
            foreach (var eventData in Events)
            {
                eventData.Unsubscribe();
            }
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }
    }
}