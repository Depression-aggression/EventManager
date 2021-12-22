using System;
using UnityEngine.Events;
using Void = Depra.EventSystem.Integrations.Toolkit.SO.Structs.Void;

namespace Depra.EventSystem.Integrations.Toolkit.SO.UnityEvents
{
    [Serializable]
    public class UnityVoidEvent : UnityEvent<Void>
    {
    }
}