using System;

namespace Depra.Events.Runtime.Bus.Subscription.Tokens.Base
{
    /// <summary>
    /// A Token representing a Subscription.
    /// </summary>
    public interface ISubscriptionToken
    {
        string InternalToken { get; }
        Type EventItemType { get; }

        bool Validate();
    }
}