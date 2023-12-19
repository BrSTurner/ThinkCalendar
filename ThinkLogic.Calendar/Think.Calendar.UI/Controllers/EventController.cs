using Microsoft.AspNetCore.Mvc;
using Think.Calendar.Application.Model;
using Think.Calendar.Application.Services.Interrfaces;
using Think.Calendar.Domain.Mediator.Commands;
using Think.Calendar.Domain.Notificator.Interfaces;
using Think.Calendar.Domain.Repositories.Interfaces;

namespace Think.Calendar.UI.Controllers
{
    public class EventController : ThinkCalendarController
    {
        private readonly ICalendarEventService _service;
        public EventController(
            INotificator notificator,
            ICalendarEventService service) : base(notificator)
        {
            _service = service;
        }

        [HttpGet("Event/Index/{id:int}")]
        public async Task<IActionResult> Index(int id)
        {
            var calendarEvent = await _service.GetEventByIdAsync(id);

            if(calendarEvent == null)
                return NotFound();

            return View(calendarEvent);
        }

        [HttpGet("Event/Create")]
        public IActionResult Create(DateTime? selectedDate = null)
        {
            AddCalendarEventCommand model = null;

            if(selectedDate.HasValue)
            {
                model = new AddCalendarEventCommand();
                model.StartDate = selectedDate.Value;
                model.EndDate = selectedDate.Value.AddMinutes(30);
            }

            return View(model);
        }

        [HttpPost("Event/Create")]
        public async Task<IActionResult> Create(AddCalendarEventCommand command)
        {
            var model = await _service.AddNewAsync(command);

            if (HasDomainErrors())
                return View(command);

            return View("Index", model);
        }

        [HttpGet("Event/Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) 
                return NotFound();

            var result = await _service.GetEventByIdAsync(id);

            if (result == null) 
                return NotFound();

            return View(result);
        }

        [HttpPost("Event/Edit")]
        public async Task<IActionResult> Edit(UpdateCalendarEventCommand command)
        {
            var model = await _service.UpdateAsync(command);
            return View("Index", model);
        }

        [HttpGet("Event/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) 
                return NotFound();

            var result = await _service.GetEventByIdAsync(id);

            if (result == null) 
                return NotFound();

            return View(result);
        }

        [HttpPost("Event/Delete/{id:int}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _service.DeleteAsync(id);

            return RedirectToAction("Index", "Calendar");            
        }
    }
}
