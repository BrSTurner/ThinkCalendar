using Think.Calendar.Domain.Mediator.CommandValidations;
using Think.Calendar.Domain.Mediator.Messages;
using Think.Calendar.Domain.Model;

namespace Think.Calendar.Domain.Mediator.Commands
{
    public class UpdateCalendarEventCommand : Command<CalendarEvent>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Email { get; set; }

        public UpdateCalendarEventCommand()
        {

        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCalendarEventValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
