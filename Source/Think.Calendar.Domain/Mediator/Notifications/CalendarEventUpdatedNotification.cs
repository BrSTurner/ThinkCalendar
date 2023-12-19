using Think.Calendar.Domain.Mediator.Messages;

namespace Think.Calendar.Domain.Mediator.Notifications
{
    public class CalendarEventUpdatedNotification : MediatorEvent
    {
        public string PreviousTitle { get; set; }
        public string PreviousDescription { get; set; }
        public string PreviousLocation { get; set; }
        public DateTime PreviousStartDate { get; set; }
        public DateTime PreviousEndDate { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Email { get; set; }

        public CalendarEventUpdatedNotification()
        {
            

        }

        public CalendarEventUpdatedNotification(string previousTitle, string previousDescription, string previousLocation, DateTime previousStartDate, DateTime previousEndDate, string email)
        {
            PreviousTitle = previousTitle;
            PreviousDescription = previousDescription;
            PreviousLocation = previousLocation;
            PreviousStartDate = previousStartDate;
            PreviousEndDate = previousEndDate;
            Email = email;
        }
    }
}
