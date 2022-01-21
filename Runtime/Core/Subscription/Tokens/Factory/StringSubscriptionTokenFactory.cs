using System;
using Depra.Events.Runtime.Bus.Subscription.Tokens;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Core.Subscription.Tokens.Base;
using Depra.Events.Runtime.Core.Utils;

namespace Depra.Events.Runtime.Core.Subscription.Tokens.Factory
{
    [Serializable]
    public class StringSubscriptionTokenFactory : ISubscriptionTokenFactory<string>
    {
        public SubscriptionToken<string> Create(string key, Type eventType, bool throwExceptionIfNotValid = false)
        {
            ValidationUtility.ValidateKey(key, throwExceptionIfNotValid);
            return new StringToken(key, eventType);
        }
    }
}