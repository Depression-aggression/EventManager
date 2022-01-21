using System;
using System.Collections.Generic;

namespace Depra.Events.Runtime.Core.Dispose
{
    public class EventDisposal : IDisposable
    {
        private readonly List<DisposeContainer> _disposeActions;

        public EventDisposal()
        {
            _disposeActions = new List<DisposeContainer>();
        }
        
        public void Add(DisposeContainer container)
        {
            _disposeActions.Add(container);
        }

        public void Dispose()
        {
            while (_disposeActions.Count > 0)
            {
                var container = _disposeActions[0];
                _disposeActions.Remove(container);
                container.Invoke();
            }
        }
    }
}