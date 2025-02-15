﻿using System;
using Depra.Events.Runtime.Core.Dispose;
using Depra.Events.Runtime.Core.Handlers.Dynamic;

namespace Depra.Events.Runtime.Managers
{
    public static class DynamicEventManager
    {
        #region Add event

        /// <summary>
        /// Subscribes a event that takes dynamic argument.
        /// </summary>
        /// <param name="key">String event key</param>
        /// <param name="action">Event action</param>
        /// <returns>Return dispose container</returns>
        public static DisposeContainer Add(string key, Action<dynamic> action) => DynamicArgHandler.Add(key, action);
        
        /// <summary>
        /// Subscribes a event that takes an unspecified amount dynamic arguments.
        /// </summary>
        /// <param name="key">String event key</param>
        /// <param name="action">Event action</param>
        /// <returns>Return dispose container</returns>
        public static DisposeContainer Add(string key, Action<dynamic[]> action) => DynamicArgsHandler.Add(key, action);
       
        #endregion

        #region Remove event
        
        /// <summary>
        /// Remove dynamic event.
        /// </summary>
        /// <param name="key">String event key</param>
        /// <param name="action">Event action</param>
        public static void Remove(string key, Action<dynamic> action) => DynamicArgHandler.Remove(key, action);
        
        /// <summary>
        /// Remove unspecified amount dynamics event.
        /// </summary>
        /// <param name="key">String event key</param>
        /// <param name="action">Event action</param>
        public static void Remove(string key, Action<dynamic[]> action) => DynamicArgsHandler.Remove(key, action);
        
        #endregion
        
        #region Invoke event
        
        /// <summary>
        /// Invoke dynamic events.
        /// </summary>
        /// <param name="key">String event key</param>
        /// <param name="value">Dynamic argument</param>
        public static void Invoke(string key, dynamic value) => DynamicArgHandler.Invoke(key, value);
        
        /// <summary>
        /// Invoke unspecified amount dynamics event.
        /// </summary>
        /// <param name="key">String event key</param>
        /// <param name="value">Dynamic arguments</param>
        public static void InvokeArray(string key, params dynamic[] value) => DynamicArgsHandler.Invoke(key, value);
        
        #endregion
    }
}