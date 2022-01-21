using Depra.Events.Runtime.Bus.Configuration;
using Depra.Events.Runtime.Bus.Subscription.Enums;
using Depra.Events.Runtime.Core.Subscription.Tokens.Factory;
using Depra.Toolkit.Configuration.Runtime;
using Depra.Toolkit.Configuration.Runtime.Attributes;
using UnityEngine;

namespace Depra.Events.Integrations.Unity.Configuration
{
    [Config("Events")]
    public class EventHandlerConfig : ObjectConfig<EventHandlerConfig>, IEventHandlerConfiguration
    {
        [SerializeField] private HandlerPriority _priority = HandlerPriority.Medium;
        [SerializeReference, SubclassSelector] private ISubscriptionTokenFactory _tokenFactory;

        [SerializeField] private bool _throwSubscriberException;
        [SerializeField] private bool _throwNullException;

        public ISubscriptionTokenFactory TokenFactory => _tokenFactory;

        public bool ThrowSubscriberException => _throwSubscriberException;
        public bool ThrowNullException => _throwNullException;

        public HandlerPriority Priority => _priority;

        internal EventHandlerConfig()
        {
            _tokenFactory = new GuidSubscriptionTokenFactory();
        }
    }
}