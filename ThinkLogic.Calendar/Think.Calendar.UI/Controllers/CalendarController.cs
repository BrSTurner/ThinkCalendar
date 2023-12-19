using Microsoft.AspNetCore.Mvc;
using Think.Calendar.Application.Model;
using Think.Calendar.Application.Services.Interrfaces;
using Think.Calendar.Domain.Notificator.Interfaces;
using Think.Calendar.UI.Models;

namespace Think.Calendar.UI.Controllers
{
    public class CalendarController : ThinkCalendarController
    {
        private readonly ICalendarEventService _service;
        public CalendarController(
            INotificator notificator,
            ICalendarEventService service) : base(notificator)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]DateTime? selectedDate = null)
        {
            if (selectedDate.HasValue)
            {
                var today = DateTime.Now;
                var firstDayInTheMonth = new DateTime(today.Year, today.Month, 1).Date;
                var lastDayInTheMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month))
                    .AddHours(23)
                    .AddMinutes(59)
                    .AddSeconds(59);            

                if(selectedDate < firstDayInTheMonth || selectedDate > lastDayInTheMonth)
                {
                    return NotFound();
                }
            }

            var model = selectedDate.HasValue ? new CalendarViewModel(selectedDate.Value) : new CalendarViewModel();

            model.Events = await _service.GetEventsByDateAsync(model.SelectedDate);

            return View(model);
        }
    }
}
