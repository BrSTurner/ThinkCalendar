using Microsoft.AspNetCore.Mvc;
using Think.Calendar.Domain.Notificator.Interfaces;

namespace Think.Calendar.UI.Controllers
{
    public abstract class ThinkCalendarController : Controller
    {
        protected readonly INotificator _notificator;

        public ThinkCalendarController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool HasErrors() => _notificator.HasErrors();
        protected IReadOnlyList<string> GetErrorMessages() => _notificator.GetNotifications();

        protected bool HasDomainErrors()
        {
            if (HasErrors())
            {
                ViewBag.Errors = GetErrorMessages();
                return true;
            }

            return false;
        }

        protected virtual void SetMaxAndMinDate()
        {
            ViewBag.MinDate = GetFirstDayOfTheMonth();
            ViewBag.MaxDate = GetLastDayOfTheMonth();
        }

        protected virtual bool ValidateSelectedDate(DateTime? selectedDate = null)
        {
            if (!selectedDate.HasValue)
                return true;

            var firstDayInTheMonth = GetFirstDayOfTheMonth();
            var lastDayInTheMonth = GetLastDayOfTheMonth();

            return (selectedDate >= firstDayInTheMonth && selectedDate <= lastDayInTheMonth);
        }

        protected DateTime GetFirstDayOfTheMonth()
        {
            var today = DateTime.Today;
            return new DateTime(today.Year, today.Month, 1).Date;
        }

        protected DateTime GetLastDayOfTheMonth()
        {
            var today = DateTime.Today;
            return new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month))
                        .AddHours(23)
                        .AddMinutes(59)
                        .AddSeconds(59);
        }
    }
}
