using System;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Core.Subscription.Tokens.Base;

namespace Depra.Events.Runtime.Bus.Subscription.Tokens
{
    internal class IndexToken : SubscriptionToken<int>
    {
        internal IndexToken(Type eventItemType, int index)
        {
            Token = index;
            EventItemType = eventItemType;
        }

        protected override string ConvertTokenToString(int token)
        {
            return token.ToString();
        }
    }
}