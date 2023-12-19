using FluentValidation;
using Think.Calendar.Domain.Mediator.Commands;

namespace Think.Calendar.Domain.Mediator.CommandValidations
{
    public class AddCalendarEventValidation : AbstractValidator<AddCalendarEventCommand>
    {
        public AddCalendarEventValidation()
        {

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Event title is mandatory");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Event description is mandatory");

            RuleFor(x => x.Location)
                .NotEmpty()
                .WithMessage("Event location is mandatory");

            RuleFor(x => x.StartDate)
                .NotEmpty()
                .WithMessage("Event start date is mandatory");

            RuleFor(x => x.EndDate)
                .NotEmpty()
                .WithMessage("Event end date is mandatory");

            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate)
                .WithMessage("Event cannot start after the end date");
        }
    }
}
