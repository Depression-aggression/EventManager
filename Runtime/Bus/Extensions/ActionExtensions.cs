using System;
using System.Collections.Generic;

namespace Depra.Events.Runtime.Bus.Extensions
{
    public static class ActionExtensions
    {
        public static void Each<T>(this IEnumerable<T> elements, Action action)
        {
            if (elements == null)
            {
                return;
            }
            
            foreach (var unused in elements)
            {
                action();
            }
        }
        
        public static void Each<T>(this IEnumerable<T> elements, Action<T> action)
        {
            if (elements == null)
            {
                return;
            }

            foreach (var element in elements)
            {
                action(element);
            }
        }
    }
}