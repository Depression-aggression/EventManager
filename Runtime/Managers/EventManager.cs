using System;
using Depra.Events.Runtime.Bus.Subscription;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Bus.Unity;
using Depra.Events.Runtime.Core.Events.Base;
using Depra.Events.Runtime.Core.Handlers.Static;
using Depra.Events.Runtime.Core.Dispose;
using Depra.Events.Runtime.Core.Subscription.Containers;

namespace Depra.Events.Runtime.Managers
{
    public static class EventManager
    {
        private static readonly VoidEventHandler VoidHandler;
        private static readonly GenericEventHandler GenericHandler;
        private static readonly ObjectArgsHandler ObjectArgsHandler;

        static EventManager()
        {
            VoidHandler = new VoidEventHandler(new VoidSubscriptionContainer());
            GenericHandler = new GenericEventHandler(new GenericSubscriptionContainer());
            ObjectArgsHandler = new ObjectArgsHandler(new ObjectSubscriptionContainer());
        }

        public static void UnsubscribeAll()
        {
            VoidHandler.UnsubscribeAll();
            GenericHandler.UnsubscribeAll();
            ObjectArgsHandler.UnsubscribeAll();
        }

        #region Add events

        /// <summary>
        /// Subscribes a Single event that takes no arguments.
        /// </summary>
        /// <param name="key">String key</param>
        /// <param name="action">Event action</param>
        /// <returns>Return dispose container</returns>
        public static SubscriptionResult Subscribe(string key, Action action)
        {
            return VoidHandler.Subscribe(key, action);
        }

        /// <summary>
        /// Subscribes a Specific event.
        /// </summary>
        /// <param name="action">Event action</param>
        /// <typeparam name="TEvent">Specific event type</typeparam>
        /// <returns>Return dispose container</returns>
        public static SubscriptionResult Subscribe<TEvent>(Action<TEvent> action) where TEvent : class, IEvent
        {
            return GlobalEventBus.Instance.Subscribe(action);
        }

        /// <summary>
        /// Subscribes a Generic event that takes arguments.
        /// </summary>
        /// <param name="key">String key</param>
        /// <param name="action">Event action</param>
        /// <typeparam name="T">Argument type</typeparam>
        /// <returns>Return dispose container</returns>
        public static SubscriptionResult Subscribe<T>(string key, Action<T> action)
        {
            return GenericHandler.Subscribe(key, action);
        }

        /// <summary>
        /// Subscribes a Object event that takes unspecified amount arguments.
        /// </summary>
        /// <param name="key">String key</param>
        /// <param name="action">Event action with <see cref="object"/> args</param>
        /// <returns>Return dispose container</returns>
        public static SubscriptionResult Subscribe(string key, Action<object[]> action)
        {
            return ObjectArgsHandler.Subscribe(key, action);
        }

        #endregion

        #region Remove events

        /// <summary>
        /// Removes Single event.
        /// </summary>
        /// <param name="key">String key</param>
        public static void Unsubscribe(string key)
        {
            VoidHandler.Unsubscribe(key);
        }

        /// <summary>
        /// Removes Specific event.
        /// </summary>
        /// <param name="token">Subscription token</param>
        public static void Unsubscribe(ISubscriptionToken token)
        {
            GlobalEventBus.Instance.Unsubscribe(token);
        }

        /// <summary>
        /// Removes Generic event.
        /// </summary>
        /// <param name="key">String key</param>
        /// <param name="action">Event action</param>
        /// <typeparam name="T">Argument type</typeparam>
        public static void Unsubscribe<T>(string key, Action<T> action)
        {
            GenericHandler.Unsubscribe<T>(key);
        }

        /// <summary>
        /// Removes unspecified amount event.
        /// </summary>
        /// <param name="key">String key</param>
        /// <param name="action">Event action with <see cref="object"/> args</param>
        public static void Unsubscribe(string key, Action<object[]> action)
        {
            ObjectArgsHandler.Unsubscribe(key);
        }

        #endregion

        #region Invoke events

        /// <summary>
        /// Invokes Single event.
        /// </summary>
        /// <param name="key">String event key</param>
        public static void Publish(string key)
        {
            VoidHandler.Publish(key);
        }

        /// <summary>
        /// Invokes Specific event.
        /// </summary>
        /// <param name="eventItem">Specific event</param>
        public static void Publish<TEvent>(TEvent eventItem) where TEvent : class, IEvent
        {
            GlobalEventBus.Publish(eventItem);
        }

        /// <summary>
        /// Invokes Generic event.
        /// </summary>
        /// <param name="key">String event key</param>
        /// <param name="value">T argument variable</param>
        /// <typeparam name="T">Argument type</typeparam>
        public static void Publish<T>(string key, T value)
        {
            GenericHandler.Publish(key, value);
        }

        /// <summary>
        /// Invokes unspecified amount event.
        /// </summary>
        /// <param name="key">String event key</param>
        /// <param name="values">Unspecified amount value</param>
        public static void PublishArray(string key, params object[] values)
        {
            ObjectArgsHandler.Publish(key, values);
        }

        #endregion
    }
}