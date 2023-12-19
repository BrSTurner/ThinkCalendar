using Think.Calendar.Domain.Mediator.Messages;

namespace Think.Calendar.Domain.Mediator.Notifications
{
    public class CalendarEventCreatedNotification : MediatorEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Email { get; set; }

        public CalendarEventCreatedNotification()
        {
            
        }

        public CalendarEventCreatedNotification(string title, string description, string location, DateTime startDate, DateTime endDate, string email)
        {
            Title = title;
            Description = description; 
            Location = location;
            StartDate = startDate;                
            EndDate = endDate;
            Email = email;
        }
    }
}
