using System;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Core.Subscription.Tokens.Base;

namespace Depra.Events.Runtime.Bus.Subscription.Tokens
{
    public class StringToken : SubscriptionToken<string>
    {
        internal StringToken(string key, Type eventItemType)
        {
            Token = key;
            EventItemType = eventItemType;
        }

        protected override string ConvertTokenToString(string token)
        {
            return token;
        }
    }
}