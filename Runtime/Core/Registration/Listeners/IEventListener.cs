namespace Depra.Events.Runtime.Core.Registration.Listeners
{
    public interface IEventListener
    {
        void Subscribe();
        void Unsubscribe();
    }
}