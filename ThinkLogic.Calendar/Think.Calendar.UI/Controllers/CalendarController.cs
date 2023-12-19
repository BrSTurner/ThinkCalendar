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
            if (!ValidateSelectedDate(selectedDate))
                return BadRequest("This date is not valid");

            var model = selectedDate.HasValue ? new CalendarViewModel(selectedDate.Value) : new CalendarViewModel();

            model.Events = await _service.GetEventsByDateAsync(model.SelectedDate);

            return View(model);
        }
    }
}
