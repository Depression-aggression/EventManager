using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Bus.Subscription.Tokens;

namespace Depra.Events.Runtime.Bus.Subscription.Interfaces
{
    public interface IProxy
    {
        ISubscriptionToken Subscription { get; }
    }
}