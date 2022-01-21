using System;
using Depra.Events.Runtime.Core.Events.Base;

namespace Depra.Events.Runtime.Core.Handlers.Interfaces
{
    internal interface IHandler
    {
        Type HandledType { get; }
    }
}