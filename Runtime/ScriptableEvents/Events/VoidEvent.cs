using UnityEngine;
using Void = Depra.EventSystem.Runtime.ScriptableEvents.Structs.Void;

namespace Depra.EventSystem.Runtime.ScriptableEvents.Events
{
    [CreateAssetMenu(fileName = "Void Event", menuName = "Game/Events/Void", order = 51)]
    public class VoidEvent : GameEventBase<Void>
    {
        public void Invoke() => Invoke(new Void());
    }
}
