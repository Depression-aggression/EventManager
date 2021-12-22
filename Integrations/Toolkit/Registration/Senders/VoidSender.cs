using Depra.EventSystem.Integrations.Toolkit.SO.Events;
using Depra.EventSystem.Integrations.Toolkit.SO.Structs;
using Depra.EventSystem.Runtime.Core.Registration.Senders;
using Depra.Toolkit.Serialization.Interfaces.Runtime;
using NaughtyAttributes;
using UnityEngine;

namespace Depra.EventSystem.Integrations.Toolkit.Registration.Senders
{
    public class VoidSender : MonoBehaviour, IEventSender
    {
        [SerializeField] private InterfaceReference<IRegisteredEvent<Void>> _event;

        [Button]
        public void Send()
        {
            _event?.Value?.Invoke(new Void());
        }
    }
}