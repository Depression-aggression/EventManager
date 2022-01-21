using System;
using Depra.Extensions;
using Depra.Extensions.Exceptions;

namespace Depra.Events.Runtime.Core.Utils
{
    internal static class ValidationUtility
    {
        internal static void ValidateKey(string keyValue, bool throwException)
        {
            if (throwException && keyValue.IsNullOrEmpty())
            {
                throw new EmptyException($"Passed key is empty!");
            }
        }

        internal static void ValidateAction(Action action, bool throwException)
        {
            if (throwException && action == null)
            {
                throw new NullReferenceException("Passed action is null!");
            }
        }

        internal static void ValidateAction<T>(Action<T> action, bool throwException)
        {
            if (throwException && action == null)
            {
                throw new NullReferenceException("Passed action is null!");
            }
        }
    }
}
