using Depra.Events.Runtime.Core.Registration.Containers;
using Depra.Events.Runtime.Core.Registration.Listeners;
using UnityEngine;

namespace Depra.Events.Integrations.Unity.Registration.Listeners
{
    public class EventHandlerBehavior : MonoBehaviour, IEventListener
    {
        [field: SerializeReference, SubclassSelector]
        public IEventListenerContainer[] Events { get; set; }

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