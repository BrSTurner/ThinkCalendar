namespace Think.Calendar.Domain.Notificator.Interfaces
{
    public interface INotificator
    {
        void AddError(string message);

        IReadOnlyList<string> GetNotifications();

        bool HasErrors();
    }
}
