using System.Collections.Generic;
using Depra.Events.Runtime.Core.Subscription.Interfaces;

namespace Depra.Events.Runtime.Core.Subscription.Containers
{
    internal interface ISubscriptionContainer<TSubscription, TToken> : IDictionary<TToken, List<TSubscription>>
        where TSubscription : ISubscription
    {
    }
}