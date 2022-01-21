using System;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Core.Subscription.Tokens.Base;

namespace Depra.Events.Runtime.Core.Subscription.Tokens.Factory
{
    public interface ISubscriptionTokenFactory
    {
        ISubscriptionToken Create(Type eventType);
    }

    public interface ISubscriptionTokenFactory<T> where T : IEquatable<T>
    {
        SubscriptionToken<T> Create(T input, Type type, bool throwExceptionIfNotValid = false);
    }
}