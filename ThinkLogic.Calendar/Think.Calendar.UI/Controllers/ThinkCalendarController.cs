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
    }
}
