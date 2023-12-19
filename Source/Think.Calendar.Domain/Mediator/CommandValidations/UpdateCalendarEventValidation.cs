using FluentValidation;
using Think.Calendar.Domain.Mediator.Commands;

namespace Think.Calendar.Domain.Mediator.CommandValidations
{
    public class UpdateCalendarEventValidation : AbstractValidator<UpdateCalendarEventCommand>
    {
        public UpdateCalendarEventValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Event Id is mandatory for updates");

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Event Id is mandatory for updates");

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
