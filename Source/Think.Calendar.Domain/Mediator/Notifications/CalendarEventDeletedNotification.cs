using Think.Calendar.Domain.Mediator.Messages;

namespace Think.Calendar.Domain.Mediator.Notifications
{
    public class CalendarEventDeletedNotification : MediatorEvent
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public string Email { get; set; }
    }
}
