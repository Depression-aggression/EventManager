using System;
using System.Collections.Generic;
using UnityEngine;

namespace Depra.Events.Runtime.Core.Events.Base
{
    public class EventEntry
    {
        public uint InvocationCount { get; set; } = 0;
        public List<object> Listeners { get; }
        public List<Delegate> Handlers { get; }
        public List<HandlerFlags> Flags { get; }

        public int Count => Listeners.Count;
        
        public EventEntry()
        {
            Listeners = new List<object>();
            Handlers = new List<Delegate>();
            Flags = new List<HandlerFlags>();
        }

        public bool HasFlag(int i, HandlerFlags flag)
        {
            return (Flags[i] & flag) == flag;
        }
        
        public void SetFlag(int i, HandlerFlags flag, bool value)
        {
            if (value)
            {
                Flags[i] |= flag;
            }
            else
            {
                Flags[i] &= ~flag;
            }
        }
        
        public void Add(object listener, Delegate handler, HandlerFlags flag)
        {
            Debug.Assert(Listeners.Count == Handlers.Count);
            
            // If not in a handler, don't set this flag as it would ignore first nested handler.
            if (InvocationCount == 0)
            {
                flag &= HandlerFlags.DontInvokeIfAddedInAHandler;
            }

            Listeners.Add(listener);
            Handlers.Add(handler);
            Flags.Add(flag);
        }

        public void NullifyAt(int i)
        {
            Debug.Assert(Listeners.Count == Handlers.Count);
            
            Listeners[i] = null;
            Handlers[i] = null;
            Flags[i] = HandlerFlags.None;
        }

        public void RemoveAt(int i)
        {
            Debug.Assert(Listeners.Count == Handlers.Count);
            
            Listeners.RemoveAt(i);
            Handlers.RemoveAt(i);
            Flags.RemoveAt(i);
        }
    }
}