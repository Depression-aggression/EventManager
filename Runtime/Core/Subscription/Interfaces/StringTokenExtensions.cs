namespace Depra.Events.Runtime.Bus.Subscription.Interfaces
{
    public static class StringTokenExtensions
    {
        public static bool ValidateToken(string key)
        {
            return string.IsNullOrWhiteSpace(key) == false;
        }
    }
}