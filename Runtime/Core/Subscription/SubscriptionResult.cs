using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Core.Dispose;
using Depra.Events.Runtime.Bus.Subscription.Tokens;

namespace Depra.Events.Runtime.Bus.Subscription
{
    public readonly struct SubscriptionResult
    {
        public ISubscriptionToken Token { get; }
        public DisposeContainer Container { get; }

        public SubscriptionResult(ISubscriptionToken token, DisposeContainer container)
        {
            Token = token;
            Container = container;
        }
    }
}