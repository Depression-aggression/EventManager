using System;
using System.Runtime.Serialization;
using Depra.Events.Runtime.Bus.Interfaces;

namespace Depra.Events.Runtime.Bus.Exceptions
{
    /// <summary>
    /// Is thrown, when attempting to register proxy, that is already registered.
    /// </summary>
    [Serializable]
    public class AlreadyRegisteredException : Exception
    {
        public IEventBus EventBus { get; }

        public object EventProxy { get; }

        public AlreadyRegisteredException()
        {
        }

        public AlreadyRegisteredException(object eventProxy, IEventBus eventBus) : base(
            GetDefaultMessage(eventProxy, eventBus))
        {
            EventProxy = eventProxy;
            EventBus = eventBus;
        }

        public AlreadyRegisteredException(string message) : base(message)
        {
        }

        public AlreadyRegisteredException(string message, Exception inner) : base(message, inner)
        {
        }

        protected static string GetDefaultMessage(object eventProxy, IEventBus eventBus)
        {
            return $"Event proxy: {eventProxy} was already registered on this event bus";
        }

        protected AlreadyRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}