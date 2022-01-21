using Depra.Events.Runtime.Core.Dispose;
using Depra.Events.Runtime.Managers;
using UnityEngine;

namespace Depra.Events.Example
{
    public class EventManagerUsage : MonoBehaviour
    {
        private readonly EventDisposal _disposal = new EventDisposal();

        private void Awake()
        {
            ExampleAddEvents();
        }

        private void ExampleAddEvents()
        {
            EventManager.Subscribe("Example1", () =>
            {
                //Example1
            }).AddTo(_disposal);

            EventManager.Subscribe<int>("Example2", intValue =>
            {
                //Example2
            }).AddTo(_disposal);

            EventManager.Subscribe("Example3", objects =>
            {
                //Example3
            }).AddTo(_disposal);

            DynamicEventManager.Add("Example4", o =>
            {
                //Example4
            }).AddTo(_disposal);

            DynamicEventManager.Add("Example5", objects =>
            {
                //Example5
            }).AddTo(_disposal);
        }

        private void ExampleInvokeEvents()
        {
            EventManager.PublishArray("Example1");

            EventManager.PublishArray("Example2", 1);

            EventManager.PublishArray("Example3", 1, 2, "example_data");

            DynamicEventManager.Invoke("Example4", "example_data");

            DynamicEventManager.Invoke("Example4", 1);

            DynamicEventManager.InvokeArray("Example5", 1, 2, "example_data");
        }

        private void OnDestroy()
        {
            _disposal.Dispose();
        }
    }
}