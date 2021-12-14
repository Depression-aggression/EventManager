using System;
using UnityEngine.Events;
using Void = Depra.EventSystem.Runtime.ScriptableEvents.Structs.Void;

namespace Depra.EventSystem.Runtime.ScriptableEvents.UnityEvents
{
    [Serializable]
    public class UnityVoidEvent : UnityEvent<Void>
    {
    }
}