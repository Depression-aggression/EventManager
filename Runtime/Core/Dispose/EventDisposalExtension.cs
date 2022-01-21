using Depra.Events.Runtime.Bus.Subscription;

namespace Depra.Events.Runtime.Core.Dispose
{
    public static class EventDisposalExtension
    {
        public static DisposeContainer AddTo(this DisposeContainer container, EventDisposal disposal)
        {
            disposal.Add(container);
            return container;
        }

        public static SubscriptionResult AddTo(this SubscriptionResult subscriptionResult, EventDisposal disposal)
        {
            var container = subscriptionResult.Container.AddTo(disposal);
            return subscriptionResult;
        }
    }
}