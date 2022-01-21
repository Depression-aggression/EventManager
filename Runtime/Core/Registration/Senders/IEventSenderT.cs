namespace Depra.Events.Runtime.Core.Registration.Senders
{
    public interface IEventSender<in T>
    {
        void Send(T eventBase);
    }
}