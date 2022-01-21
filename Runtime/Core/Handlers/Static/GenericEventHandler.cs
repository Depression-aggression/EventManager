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
    internal class GenericEventHandler : EventHandlerBase<IEvent, Type>
    {
        private static readonly object SubscriptionsLock = new();

        public SubscriptionResult Subscribe<TPayload>(string key, Action<TPayload> action)
        {
            ValidateAction(action);

            var type = typeof(TPayload);
            var token = GlobalSubscriptionTokenFactory.Create(key, type);

            lock (SubscriptionsLock)
            {
                if (Container.ContainsKey(type) == false)
                {
                    Container.Add(type, new List<ISubscription>());
                }

                var genericSubscription = new GenericSubscription<TPayload>(action, token);
                Container[type].Add(genericSubscription);

                var result = new SubscriptionResult(token, new DisposeContainer(() => Unsubscribe<TPayload>(key)));
                return result;
            }
        }

        public void Unsubscribe<TPayload>(string key)
        {
            Unsubscribe(key, typeof(TPayload));
        }

        private void Unsubscribe(string key, Type type)
        {
            var token = GlobalSubscriptionTokenFactory.Create(key, HandledType);

            lock (SubscriptionsLock)
            {
                if (Container.TryGetValue(type, out var allSubscriptions) == false)
                {
                    return;
                }

                var subscriptionToRemove = allSubscriptions.FirstOrDefault(x => x.Equals(token));
                if (subscriptionToRemove != null)
                {
                    Container[type].Remove(subscriptionToRemove);
                }
            }
        }

        public void Publish<TPayload>(string key, TPayload arg)
        {
            var token = GlobalSubscriptionTokenFactory.Create(key, HandledType);
            var type = typeof(TPayload);

            var allSubscriptions = new List<ISubscription>();

            lock (SubscriptionsLock)
            {
                if (Container.ContainsKey(type))
                {
                    allSubscriptions = Container[type];
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
                    var genericSubscription = subscription as GenericSubscription<TPayload>;
                    genericSubscription?.Publish(arg);
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
            Container.Clear();
            //
            // foreach (var subscriptions in Container.Values)
            // {
            //     foreach (var subscription in subscriptions)
            //     {
            //         subscription.
            //     }
            // }
        }

        internal GenericEventHandler(GenericSubscriptionContainer container,
            IEventHandlerConfiguration configuration = null) : base(container)
        {
        }

        private void ValidateAction<TPayload>(Action<TPayload> action)
        {
            ValidationUtility.ValidateAction(action, Configuration.ThrowNullException);
        }

        #endregion
    }
    
    internal class GenericSubscriptionContainer : Dictionary<Type, List<ISubscription>>,
        ISubscriptionContainer<ISubscription, Type>
    {
    }
}