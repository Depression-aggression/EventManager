using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Depra.Events.Runtime.Bus.Configuration;
using Depra.Events.Runtime.Bus.Interfaces;
using Depra.Events.Runtime.Bus.Subscription;
using Depra.Events.Runtime.Bus.Subscription.Tokens;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Core.Dispose;
using Depra.Events.Runtime.Core.Events.Base;
using Depra.Events.Runtime.Core.Subscription;
using Depra.Events.Runtime.Core.Subscription.Containers;
using Depra.Events.Runtime.Core.Subscription.Interfaces;
using Depra.Events.Runtime.Core.Subscription.Tokens.Base;

namespace Depra.Events.Runtime.Bus
{
    internal class BusSubscriptionContainer : Dictionary<Type, List<ISubscription<IEvent>>>,
        ISubscriptionContainer<ISubscription<IEvent>, Type>
    {
    }
    
    /// <summary>
    /// Implements <see cref="IEventBus"/>.
    /// </summary>
    public class EventBus : IEventBus
    {
        private readonly BusSubscriptionContainer _subscriptions;
        private readonly IEventHandlerConfiguration _eventHandlerConfiguration;

        private static readonly object SubscriptionsLock = new object();

        public EventBus(IEventHandlerConfiguration configuration = null)
        {
            _eventHandlerConfiguration = configuration ?? EventHandlerConfiguration.Default;
            _subscriptions = new BusSubscriptionContainer();
        }

        /// <summary>
        /// Subscribes to the specified event type with the specified action.
        /// </summary>
        /// <typeparam name="TEvent">The type of event</typeparam>
        /// <param name="action">The Action to invoke when an event of this type is published</param>
        /// <returns>A <see cref="SubscriptionToken"/> to be used when calling <see cref="Unsubscribe"/></returns>
        public SubscriptionResult Subscribe<TEvent>(Action<TEvent> action) where TEvent : class, IEvent
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            lock (SubscriptionsLock)
            {
                var eventType = typeof(TEvent);

                if (_subscriptions.ContainsKey(eventType) == false)
                {
                    _subscriptions.Add(eventType, new List<ISubscription<IEvent>>());
                }

                var token = new StringToken("", eventType); 
                //_eventHandlerConfiguration.GenerateToken(eventType);
                var subscription = new Subscription<TEvent>(action, token);
                _subscriptions[eventType].Add(subscription);

                var result = new SubscriptionResult(token, new DisposeContainer(null));

                return result;
            }
        }

        /// <summary>
        /// Unsubscribe from the Event type related to the specified <see cref="SubscriptionToken"/>
        /// </summary>
        /// <param name="token">The <see cref="SubscriptionToken"/> received from calling the Subscribe method</param>
        public void Unsubscribe(ISubscriptionToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            lock (SubscriptionsLock)
            {
                if (_subscriptions.ContainsKey(token.EventItemType) == false)
                {
                    return;
                }

                var allSubscriptions = _subscriptions[token.EventItemType];
                var subscriptionToRemove = allSubscriptions.FirstOrDefault(x => x.Equals(token));

                if (subscriptionToRemove != null)
                {
                    _subscriptions[token.EventItemType].Remove(subscriptionToRemove);
                }
            }
        }

        /// <summary>
        /// Publishes the specified event to any subscribers for the <see cref="TEvent"/> event type.
        /// </summary>
        /// <typeparam name="TEvent">The type of event</typeparam>
        /// <param name="eventItem">Event to publish</param>
        public void Publish<TEvent>(TEvent eventItem) where TEvent : IEvent
        {
            if (eventItem == null)
            {
                throw new ArgumentNullException(nameof(eventItem));
            }

            var allSubscriptions = new List<ISubscription<IEvent>>();
            var eventType = typeof(TEvent);
            
            lock (SubscriptionsLock)
            {
                if (_subscriptions.ContainsKey(eventType))
                {
                    allSubscriptions = _subscriptions[eventType].ToList();
                }
            }

            for (var index = 0; index < allSubscriptions.Count; index++)
            {
                var subscription = allSubscriptions[index];
                try
                {
                    subscription.Publish(eventItem);
                }
                catch (Exception)
                {
                    if (_eventHandlerConfiguration.ThrowSubscriberException)
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Publishes the specified event to any subscribers for the <see cref="TEvent"/> event type asychronously.
        /// </summary>
        /// <remarks>
        /// This is a wrapper call around the synchronous  method as this method is naturally synchronous (CPU Bound).
        /// </remarks>
        /// <typeparam name="TEvent">The type of event</typeparam>
        /// <param name="eventItem">Event to publish</param>
        public void PublishAsync<TEvent>(TEvent eventItem) where TEvent : IEvent
        {
            PublishAsyncInternal(eventItem, null);
        }

        /// <summary>
        /// Publishes the specified event to any subscribers for the <see cref="TEvent"/> event type asychronously.
        /// </summary>
        /// <remarks>
        /// This is a wrapper call around the synchronous  method as this method is naturally synchronous (CPU Bound).
        /// </remarks>
        /// <typeparam name="TEvent">The type of event</typeparam>
        /// <param name="eventItem">Event to publish</param>
        /// <param name="callback"><see cref="AsyncCallback"/> that is called on completion</param>
        public void PublishAsync<TEvent>(TEvent eventItem, AsyncCallback callback) where TEvent : IEvent
        {
            PublishAsyncInternal(eventItem, callback);
        }

        #region Private Methods

        private void PublishAsyncInternal<TEvent>(TEvent eventItem, AsyncCallback callback) where TEvent : IEvent
        {
            var publishTask = new Task<bool>(() =>
            {
                Publish(eventItem);
                return true;
            });

            publishTask.Start();
            if (callback == null)
            {
                return;
            }

            var tcs = new TaskCompletionSource<bool>();
            publishTask.ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    tcs.TrySetException(t.Exception.InnerExceptions);
                }
                else if (t.IsCanceled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(t.Result);
                }

                callback?.Invoke(tcs.Task);
            }, TaskScheduler.Default);
        }

        #endregion
    }
}