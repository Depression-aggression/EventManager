using UnityEngine;
using Void = Depra.Events.Integrations.Toolkit.SO.Structs.Void;

namespace Depra.Events.Integrations.Toolkit.SO.Events
{
    [CreateAssetMenu(fileName = "Event Void", menuName = "Events/Void", order = 51)]
    public class VoidGameEvent : GameEventBase<Structs.Void>
    {
        public void Invoke() => Invoke(new Structs.Void());
    }
}
