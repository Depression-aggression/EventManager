using System;

namespace Depra.Events.Runtime.Core.Events.Base
{
    [Flags]
    public enum HandlerFlags
    {
        None = 0,
        OnlyIfActiveAndEnabled = 1 << 0,
        Once = 1 << 1,
        DontInvokeIfAddedInAHandler = 1 << 2,
        IsUnityObject = 1 << 3
    }
}