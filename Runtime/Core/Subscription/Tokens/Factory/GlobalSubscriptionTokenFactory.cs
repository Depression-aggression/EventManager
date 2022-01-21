using System;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;

namespace Depra.Events.Runtime.Core.Subscription.Tokens.Factory
{
    public class GlobalSubscriptionTokenFactory : ISubscriptionTokenFactory
    {
        private readonly GuidSubscriptionTokenFactory _guidTokenFactory;
        private static readonly StringSubscriptionTokenFactory StringTokenFactory = new StringSubscriptionTokenFactory();
        
        public GlobalSubscriptionTokenFactory()
        {
            _guidTokenFactory = new GuidSubscriptionTokenFactory();
        }
        
        public ISubscriptionToken Create(Type eventType) => _guidTokenFactory.Create(eventType);

        public static ISubscriptionToken Create(string key, Type eventType) => StringTokenFactory.Create(key, eventType);
    }
}