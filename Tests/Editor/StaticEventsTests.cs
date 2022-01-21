using Depra.Events.Runtime.Core.Dispose;
using Depra.Events.Runtime.Managers;
using NUnit.Framework;

namespace Depra.Events.Tests.Editor
{
    public class StaticEventsTests
    {
        private EventDisposal _disposal;

        private bool _actionHandlerHit;

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
        public void Single_Event_Successfully_Invoked()
        {
            var eventARaised = false;
            var eventBRaised = false;

            EventManager.Subscribe("SingleA", () => { eventARaised = true; }).AddTo(_disposal);
            EventManager.Subscribe("SingleB", () => { eventBRaised = true; }).AddTo(_disposal);

            Assert.IsFalse(eventARaised);
            EventManager.Publish("SingleA");
            Assert.IsTrue(eventARaised);

            Assert.IsFalse(eventBRaised);
            EventManager.Publish("SingleB");
            Assert.IsTrue(eventBRaised);
        }

        [Test]
        public void Generic_Event_Successfully_Invoked()
        {
            var eventARaised = false;
            var eventBRaised = false;

            EventManager.Subscribe<TestObject>("GenericA", _ => { eventARaised = true; }).AddTo(_disposal);
            EventManager.Subscribe<TestObject>("GenericB", _ => { eventBRaised = true; }).AddTo(_disposal);

            Assert.IsFalse(eventARaised);
            EventManager.Publish("GenericA", new TestObject());
            Assert.IsTrue(eventARaised);

            Assert.IsFalse(eventBRaised);
            EventManager.Publish("GenericB", new TestObject());
            Assert.IsTrue(eventBRaised);
        }

        [Test]
        public void Object_Event_Successfully_Invoked()
        {
            var eventARaised = false;
            var eventBRaised = false;

            EventManager.Subscribe("ObjectsA", objects => { eventARaised = true; }).AddTo(_disposal);
            EventManager.Subscribe("ObjectsB", objects => { eventBRaised = true; }).AddTo(_disposal);

            Assert.IsFalse(eventARaised);
            EventManager.PublishArray("ObjectsA");
            Assert.IsTrue(eventARaised);

            Assert.IsFalse(eventBRaised);
            EventManager.PublishArray("ObjectsB");
            Assert.IsTrue(eventBRaised);
        }
    }
}