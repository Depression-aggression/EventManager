using System.Collections.Generic;
using Depra.Events.Runtime.Core.Subscription.Interfaces;

namespace Depra.Events.Runtime.Core.Subscription.Containers
{
    internal abstract class SubscriptionContainer<TToken> : Dictionary<TToken, List<ISubscription>>,
        ISubscriptionContainer<ISubscription, TToken>
    {
    }
}