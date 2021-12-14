using UnityEngine;

namespace Depra.EventSystem.Runtime.ScriptableEvents.Events
{
    [CreateAssetMenu(fileName = "Single Event", menuName = "Game/Events/Single", order = 51)]
    public class SingleEvent : GameEventBase<float>
    {
    }
}