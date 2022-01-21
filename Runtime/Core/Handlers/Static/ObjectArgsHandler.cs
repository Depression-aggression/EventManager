using System;
using System.Collections.Generic;
using System.Linq;
using Depra.Events.Runtime.Bus.Configuration;
using Depra.Events.Runtime.Bus.Subscription;
using Depra.Events.Runtime.Core.Dispose;
using Depra.Events.Runtime.Core.Events.Base;
using Depra.Events.Runtime.Core.Handlers.Generic;
using Depra.Events.Runtime.Core.Subscription;
using Depra.Events.Runtime.Core.Subscription.Containers;
using Depra.Events.Runtime.Core.Subscription.Interfaces;
using Depra.Events.Runtime.Core.Subscription.Tokens.Factory;
using Depra.Events.Runtime.Core.Utils;

namespace Depra.Events.Runtime.Core.Handlers.Static
{
    internal class ObjectArgsHandler : EventHandlerBase<IEvent, string>
    {
        private static readonly object SubscriptionsLock = new();

        public SubscriptionResult Subscribe(string key, Action<object[]> action)
        {
            ValidateAction(action);
            var token = GlobalSubscriptionTokenFactory.Create(key, HandledType);

            lock (SubscriptionsLock)
            {
                if (Container.ContainsKey(key) == false)
                {
                    Container.Add(key, new List<ISubscription>());
                }

                var subscription = new ObjectListSubscription(action, token);
                Container[key].Add(subscription);

                var result = new SubscriptionResult(token, new DisposeContainer(() => Unsubscribe(key)));
                return result;
            }
        }

        public void Unsubscribe(string key)
        {
            var token = GlobalSubscriptionTokenFactory.Create(key, HandledType);

            lock (SubscriptionsLock)
            {
                if (Container.TryGetValue(key, out var allSubscriptions) == false)
                {
                    return;
                }

                var subscriptionToRemove = allSubscriptions.FirstOrDefault(x => x.Equals(token));
                if (subscriptionToRemove != null)
                {
                    Container[key].Remove(subscriptionToRemove);
                }
            }
        }

        public void Publish(string key, params object[] args)
        {
            var token = GlobalSubscriptionTokenFactory.Create(key, HandledType);
            var allSubscriptions = new List<ISubscription>();

            lock (SubscriptionsLock)
            {
                if (Container.ContainsKey(key))
                {
                    allSubscriptions = Container[key].ToList();
                }
            }
            
            for (var index = 0; index < allSubscriptions.Count; index++)
            {
                var subscription = allSubscriptions[index];
                if (subscription.Equals(token) == false)
                {
                    continue;
                }

                try
                {
                    var objectListSubscription = subscription as ObjectListSubscription;
                    objectListSubscription?.Publish(args);
                }
                catch (Exception)
                {
                    if (Configuration.ThrowSubscriberException)
                    {
                        throw;
                    }
                }
            }
        }

        #region Internal Methods

        internal override void UnsubscribeAll()
        {
            foreach (var key in Container.Keys)
            {
                Unsubscribe(key);
            }
        }

        internal ObjectArgsHandler(ISubscriptionContainer<ISubscription, string> container,
            IEventHandlerConfiguration configuration = null) : base(container, configuration)
        {
        }

        private void ValidateAction(Action<object[]> action)
        {
            ValidationUtility.ValidateAction(action, Configuration.ThrowNullException);
        }

        #endregion
    }
    
    internal class ObjectSubscriptionContainer : SubscriptionContainer<string>
    {
    }
}