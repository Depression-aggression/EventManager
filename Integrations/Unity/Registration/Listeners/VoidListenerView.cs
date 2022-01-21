using Depra.Events.Integrations.Toolkit.SO.Events;
using Depra.Events.Integrations.Toolkit.SO.Structs;
using Depra.Events.Integrations.Toolkit.SO.UnityEvents;
using UnityEngine;

namespace Depra.Events.Integrations.Toolkit.Registration.Listeners
{
    public class VoidListenerView : GenericEventListenerView<Void, IRegisteredEvent<Void>, UnityVoidEvent>
    {
    }
}