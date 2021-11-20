using Depra.EventManager.Core;
using Depra.EventManager.Core.Dispose;
using UnityEngine;

public class Example : MonoBehaviour
{
   private readonly EventDisposal _disposal = new EventDisposal();

   private void Awake()
   {
      ExampleAddEvents();
   }

   private void ExampleAddEvents()
   {
      EventManager.Add("Example1", () =>
      {
         //Example1
      }).AddTo(_disposal);
      
      EventManager.Add<int>("Example2", intValue =>
      {
         //Example2
      }).AddTo(_disposal);
      
      EventManager.Add("Example3", objects =>
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
      EventManager.Invoke("Example1");

      EventManager.Invoke("Example2", 1);
      
      EventManager.Invoke("Example3", 1, 2, "example_data");
      
      DynamicEventManager.Invoke("Example4", "example_data");
      
      DynamicEventManager.Invoke("Example4", 1);

      DynamicEventManager.Invoke("Example5", 1, 2, "example_data");
   }

   private void OnDestroy()
   {
      _disposal.Dispose();
   }
}
