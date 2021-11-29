using System;
using System.Collections.Generic;
using Depra.EventSystem.Core.Events.Base;

namespace Depra.EventSystem.Core.Events.Static
{
    public class FuncEvent : EventBase
    {
        // private readonly Dictionary<string, List<Func<T>>> _delegates = new Dictionary<string, List<Delegate>>();
        //
        // public void Add(string key, Delegate action)
        // {
        //     if (_delegates.ContainsKey(key) == false)
        //     {
        //         _delegates.Add(key, new List<Delegate>());
        //     }
        //
        //     _delegates[key].Add(action);
        // }
        //
        // public void Remove(string key, Delegate action)
        // {
        //     if (_delegates.TryGetValue(key, out var list))
        //     {
        //         list.Remove(action);
        //     }
        // }
        //
        // public void Invoke(string key)
        // {
        //     if (_delegates.TryGetValue(key, out var lastInvokeList) == false)
        //     {
        //         return;
        //     }
        //
        //     foreach (var action in lastInvokeList)
        //     {
        //         action.DynamicInvoke();
        //     }
        // }
    }
}