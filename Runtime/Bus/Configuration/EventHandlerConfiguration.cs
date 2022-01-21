using Depra.Events.Runtime.Bus.Subscription.Enums;
using Depra.Events.Runtime.Core.Subscription.Tokens.Factory;

namespace Depra.Events.Runtime.Bus.Configuration
{
    public class EventHandlerConfiguration : IEventHandlerConfiguration
    {
        /// <summary>
        /// Determines whether or not Subscriber exceptions are thrown.
        /// </summary>
        /// <remarks>
        /// This is false by default, which will cause EventBus to catch &
        /// swallow any unhandled exceptions from subscribers.
        /// When this is true, any exceptions thrown by a subscriber will be thrown -
        /// this will cause any subsequent subscribers to not receive the event.
        /// </remarks>
        public bool ThrowSubscriberException { get; set; }

        public bool ThrowNullException { get; set; }

        public HandlerPriority Priority { get; set; } = HandlerPriority.Medium;

        public ISubscriptionTokenFactory TokenFactory { get; set; } = new GuidSubscriptionTokenFactory();

        internal static readonly EventHandlerConfiguration Default;

        static EventHandlerConfiguration()
        {
            Default = new EventHandlerConfiguration
            {
                TokenFactory = new GuidSubscriptionTokenFactory(),
                ThrowSubscriberException = false,
                ThrowNullException = false
            };
        }
    }
}