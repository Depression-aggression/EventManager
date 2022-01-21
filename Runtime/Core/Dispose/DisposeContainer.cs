using System;

namespace Depra.Events.Runtime.Core.Dispose
{
    public struct DisposeContainer
    {
        private Action _disposeAction;

        public DisposeContainer(Action disposeAction)
        {
            _disposeAction = disposeAction;
        }
        
        public void Invoke()
        {
            _disposeAction?.Invoke();
            _disposeAction = null;
        }
    }
}
