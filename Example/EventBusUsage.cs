using Depra.Events.Runtime.Bus;
using UnityEngine;

namespace Depra.Events.Example
{
    public class EventBusUsage : MonoBehaviour
    {
        public void ExamplePublishMessage()
        {
            EventBus bus = new EventBus();
            //bus.Publish();
        }
    }
}