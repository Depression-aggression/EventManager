using Depra.Events.Integrations.Toolkit.SO.Events;
using Depra.Events.Integrations.Toolkit.SO.Structs;
using Depra.Events.Runtime.Core.Registration.Senders;
using Depra.Toolkit.Serialization.Interfaces.Runtime;
using NaughtyAttributes;
using UnityEngine;

namespace Depra.Events.Integrations.Toolkit.Registration.Senders
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