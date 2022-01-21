using System;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Core.Subscription.Tokens.Base;

namespace Depra.Events.Runtime.Core.Subscription.Tokens
{
    public class GuidToken : SubscriptionToken<Guid>
    {
        internal GuidToken(Type eventItemType)
        {
            Token = Guid.NewGuid();
            EventItemType = eventItemType;
        }

        protected override string ConvertTokenToString(Guid token)
        {
            return token.ToString();
        }
    }
}