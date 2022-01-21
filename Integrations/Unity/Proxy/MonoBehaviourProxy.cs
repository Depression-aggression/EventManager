using Depra.Events.Runtime.Bus.Subscription.Interfaces;
using Depra.Events.Runtime.Bus.Subscription.Tokens.Base;
using Depra.Events.Runtime.Bus.Subscription.Tokens;
using UnityEngine;

namespace Depra.Events.Integrations.Unity.Proxy
{
    public class MonoBehaviourProxy : MonoBehaviour, IProxy
    {
        public ISubscriptionToken Subscription => throw new System.NotImplementedException();
    }
}