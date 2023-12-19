using Think.Calendar.Domain.Notificator.Interfaces;

namespace Think.Calendar.Domain.Notificator
{
    public class Notificator : INotificator
    {
        private readonly IList<string> _notifications;
        public Notificator() 
        {
            _notifications = new List<string>();
        }

        public void AddError(string message) => _notifications.Add(message);

        public IReadOnlyList<string> GetNotifications() => _notifications.AsReadOnly();

        public bool HasErrors() => _notifications.Any();
        
    }
}
