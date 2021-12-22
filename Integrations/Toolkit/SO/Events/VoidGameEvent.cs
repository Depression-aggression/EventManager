using UnityEngine;
using Void = Depra.EventSystem.Integrations.Toolkit.SO.Structs.Void;

namespace Depra.EventSystem.Integrations.Toolkit.SO.Events
{
    [CreateAssetMenu(fileName = "Event Void", menuName = "Events/Void", order = 51)]
    public class VoidGameEvent : GameEventBase<Void>
    {
        public void Invoke() => Invoke(new Void());
    }
}
