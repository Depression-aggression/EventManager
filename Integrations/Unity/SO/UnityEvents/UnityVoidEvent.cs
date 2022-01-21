using System;
using UnityEngine.Events;
using Void = Depra.Events.Integrations.Toolkit.SO.Structs.Void;

namespace Depra.Events.Integrations.Toolkit.SO.UnityEvents
{
    [Serializable]
    public class UnityVoidEvent : UnityEvent<Structs.Void>
    {
    }
}