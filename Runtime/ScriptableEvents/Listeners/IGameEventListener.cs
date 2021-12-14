namespace Depra.EventSystem.Runtime.ScriptableEvents.Listeners
{
    public interface IGameEventListener<T>
    {
        void OnEventInvoked(T item);
    }
}