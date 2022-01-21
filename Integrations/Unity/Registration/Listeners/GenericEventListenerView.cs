using Depra.Events.Integrations.Toolkit.SO.Events;
using Depra.Events.Runtime.Core.Registration.Listeners;
using Depra.Toolkit.Serialization.Interfaces.Runtime;
using UnityEngine;
using UnityEngine.Events;

namespace Depra.Events.Integrations.Toolkit.Registration.Listeners
{
    public class GenericEventListenerView<T, E, UER> : MonoBehaviour, IEventListener<T>
        where E : class, IRegisteredEvent<T> where UER : UnityEvent<T>
    {
        [SerializeField] private InterfaceReference<E> _event;
        [SerializeField] private UER _unityEventResponse;

        public void Subscribe()
        {
            _event?.Value?.RegisterListener(this);
        }

        public void Unsubscribe()
        {
            _event?.Value?.UnregisterListener(this);
        }

        public void OnEventInvoked(T item)
        {
            _unityEventResponse?.Invoke(item);
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