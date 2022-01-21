using Depra.Events.Runtime.Core.Dispose;
using Depra.Events.Runtime.Managers;
using NUnit.Framework;

namespace Depra.Events.Tests.Editor
{
    public class DynamicEventsTests
    {
        private EventDisposal _disposal;

        [SetUp]
        public void Setup()
        {
            _disposal = new EventDisposal();
        }

        [TearDown]
        public void Teardown()
        {
            _disposal.Dispose();
        }
        
        [Test]
        public void Dynamic_Event_Successfully_Invoked()
        {
            var eventARaised = false;
            var eventBRaised = false;
        
            DynamicEventManager.Add("DynamicA", dynamic => { eventARaised = true; }).AddTo(_disposal);
            DynamicEventManager.Add("DynamicB", dynamic => { eventBRaised = true; }).AddTo(_disposal);
        
            Assert.IsFalse(eventARaised);
            DynamicEventManager.InvokeArray("DynamicA");
            Assert.IsTrue(eventARaised);
        
            Assert.IsFalse(eventBRaised);
            DynamicEventManager.InvokeArray("DynamicB");
            Assert.IsTrue(eventBRaised);
        }
    }
}