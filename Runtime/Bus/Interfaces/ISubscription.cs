using Depra.EventSystem.Runtime.Core.Events.Base;

namespace Depra.EventSystem.Runtime.Bus.Interfaces
{
    public interface ISubscription
    {
        /// <summary>
        /// Token returned to the subscriber
        /// </summary>
        SubscriptionToken SubscriptionToken { get; }

        /// <summary>
        /// Publish to the subscriber
        /// </summary>
        /// <param name="eventBase"></param>
        void Publish(IEvent eventBase);
    }
}