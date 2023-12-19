using Think.Calendar.Domain.Mediator.CommandValidations;
using Think.Calendar.Domain.Mediator.Messages;
using Think.Calendar.Domain.Model;

namespace Think.Calendar.Domain.Mediator.Commands
{
    public class AddCalendarEventCommand : Command<CalendarEvent>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Email { get; set; }

        public AddCalendarEventCommand()
        {
            StartDate = DateTime.Now.Date;
            EndDate = DateTime.Now.Date.AddMinutes(30);
        }

        public override bool IsValid()
        {
            ValidationResult = new AddCalendarEventValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
