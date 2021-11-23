using System;
using Depra.EventManager.Core.Dispose;
using Depra.EventManager.Core.Handler.Static;

namespace Depra.EventManager.Core
{
    public static class EventManager
    {
        #region Add events
       
        /// <summary>
        /// Subscribe event.
        /// Single event, dont take arguments.
        /// </summary>
        /// <param name="key">String key</param>
        /// <param name="action">Event action</param>
        /// <returns>Return dispose container</returns>
        public static DisposeContainer Add(string key, Action action) => SingleEventHandler.Add(key, action);
        
        /// <summary>
        /// Subscribe event.
        /// Generic event, take T Argument.
        /// </summary>
        /// <param name="key">String key</param>
        /// <param name="action">Event action</param>
        /// <typeparam name="T">Argument type</typeparam>
        /// <returns>Return dispose container</returns>
        public static DisposeContainer Add<T>(string key, Action<T> action) => GenericEventHandler.Add(key, action);

        /// <summary>
        /// Subscribe event.
        /// Take an unspecified amount arguments.
        /// </summary>
        /// <param name="key">String key</param>
        /// <param name="action">Event action</param>
        /// <returns>Return dispose container</returns>
        public static DisposeContainer Add(string key, Action<object[]> action) => ObjectArgsHandler.Add(key, action);
       
        #endregion
        
        #region Remove events
       
        /// <summary>
        /// Remove single event.
        /// </summary>
        /// <param name="key">String key</param>
        /// <param name="action">Event action</param>
        public static void Remove(string key, Action action) => SingleEventHandler.Remove(key, action);
        
        /// <summary>
        /// Remove generic event.
        /// </summary>
        /// <param name="key">String key</param>
        /// <param name="action">Event action</param>
        /// <typeparam name="T">Argument type</typeparam>
        public static void Remove<T>(string key, Action<T> action) => GenericEventHandler.Remove(key, action);
        
        /// <summary>
        /// Remove unspecified amount event.
        /// </summary>
        /// <param name="key">String key</param>
        /// <param name="action">Event action</param>
        public static void Remove(string key, Action<object[]> action) => ObjectArgsHandler.Remove(key, action);
       
        #endregion

        #region Invoke events
        
        /// <summary>
        /// Invoke single event.
        /// </summary>
        /// <param name="key">String event key</param>
        public static void Invoke(string key) => SingleEventHandler.Invoke(key);
        
        /// <summary>
        /// Invoke generic event.
        /// </summary>
        /// <param name="key">String event key</param>
        /// <param name="value">T argument variable</param>
        /// <typeparam name="T">Argument type</typeparam>
        public static void Invoke<T>(string key, T value) => GenericEventHandler.Invoke(key, value);
        
        /// <summary>
        /// Invoke unspecified amount event.
        /// </summary>
        /// <param name="key">String event key</param>
        /// <param name="value">Unspecified amount value</param>
        public static void InvokeArray(string key,params object[] value) => ObjectArgsHandler.Invoke(key, value);
        
        #endregion
    }
}