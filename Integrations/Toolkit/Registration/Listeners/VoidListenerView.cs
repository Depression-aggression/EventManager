using Depra.EventSystem.Integrations.Toolkit.SO.Events;
using Depra.EventSystem.Integrations.Toolkit.SO.Structs;
using Depra.EventSystem.Integrations.Toolkit.SO.UnityEvents;
using UnityEngine;

namespace Depra.EventSystem.Integrations.Toolkit.Registration.Listeners
{
    public class VoidListenerView : GenericEventListenerView<Void, IRegisteredEvent<Void>, UnityVoidEvent>
    {
    }
}