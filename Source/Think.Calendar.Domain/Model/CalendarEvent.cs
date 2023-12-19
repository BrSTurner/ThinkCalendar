namespace Think.Calendar.Domain.Model
{
    public class CalendarEvent : Entity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Email { get; set; }
        public CalendarEvent(){}

        public CalendarEvent(string title, string description, string location, DateTime startDate, DateTime endDate, string email = "") 
        {
            Title = title;
            Description = description;
            Location = location;
            StartDate = startDate;
            EndDate = endDate;
            CreatedAt = DateTime.Now;
            Email = email;
        }

        public void Update(string title, string description, string location, DateTime startDate, DateTime endDate, string email)
        {
            Title = title;
            Description = description;
            Location = location;
            StartDate = startDate;
            EndDate = endDate;
            UpdatedAt = DateTime.Now;
            Email = email;
        }

    }
}
