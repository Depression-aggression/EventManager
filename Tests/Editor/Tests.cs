using Depra.EventSystem.Core;
using Depra.EventSystem.Core.Dispose;
using NUnit.Framework;

namespace Depra.EventSystem.Tests
{
    public class Tests
    {
        private readonly EventDisposal _disposal = new EventDisposal();

        [Test]
        public void Single_Event_Successfully_Invoked()
        {
            var eventARaised = false;
            var eventBRaised = false;
        
            Core.EventManager.Add("SingleA", () => { eventARaised = true; }).AddTo(_disposal);
            Core.EventManager.Add("SingleB", () => { eventBRaised = true; }).AddTo(_disposal);
        
            Core.EventManager.Invoke("SingleA");
            Assert.IsTrue(eventARaised);
        
            Core.EventManager.Invoke("SingleB");
            Assert.IsTrue(eventBRaised);

            _disposal.Dispose();
        }

        [Test]
        public void Object_Event_Successfully_Invoked()
        {
            var eventARaised = false;
            var eventBRaised = false;
        
            Core.EventManager.Add("ObjectsA", objects => { eventARaised = true; }).AddTo(_disposal);
            Core.EventManager.Add("ObjectsB", objects => { eventBRaised = true; }).AddTo(_disposal);
        
            Core.EventManager.InvokeArray("ObjectsA");
            Assert.IsTrue(eventARaised);
        
            Core.EventManager.InvokeArray("ObjectsB");
            Assert.IsTrue(eventBRaised);
        
            _disposal.Dispose();
        }

        [Test]
        public void Dynamic_Event_Successfully_Invoked()
        {
            var eventARaised = false;
            var eventBRaised = false;
        
            DynamicEventManager.Add("DynamicA", dynamic => { eventARaised = true; }).AddTo(_disposal);
            DynamicEventManager.Add("DynamicB", dynamic => { eventBRaised = true; }).AddTo(_disposal);
        
            DynamicEventManager.InvokeArray("DynamicA");
            Assert.IsTrue(eventARaised);
        
            DynamicEventManager.InvokeArray("DynamicB");
            Assert.IsTrue(eventBRaised);
        
            _disposal.Dispose();
        }
    }
}