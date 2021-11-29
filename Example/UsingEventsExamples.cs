using Depra.EventSystem.Core;
using Depra.EventSystem.Core.Dispose;
using UnityEngine;

namespace Depra.EventSystem.Example
{
   public class UsingEventsExamples : MonoBehaviour
   {
      private readonly EventDisposal _disposal = new EventDisposal();

      private void Awake()
      {
         ExampleAddEvents();
      }

      private void ExampleAddEvents()
      {
         Core.EventManager.Add("Example1", () =>
         {
            //Example1
         }).AddTo(_disposal);
      
         Core.EventManager.Add<int>("Example2", intValue =>
         {
            //Example2
         }).AddTo(_disposal);
      
         Core.EventManager.Add("Example3", objects =>
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
         Core.EventManager.InvokeArray("Example1");

         Core.EventManager.InvokeArray("Example2", 1);
      
         Core.EventManager.InvokeArray("Example3", 1, 2, "example_data");
      
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
