using Microsoft.AspNetCore.Mvc;
using Think.Calendar.Application.Services.Interrfaces;
using Think.Calendar.Domain.Mediator.Commands;
using Think.Calendar.Domain.Notificator.Interfaces;

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
            var model = new AddCalendarEventCommand();
            
            if (!ValidateSelectedDate(selectedDate))
                return BadRequest("This date is not valid");

            if (selectedDate.HasValue)
            {
                model.StartDate = selectedDate.Value;
                model.EndDate = selectedDate.Value.AddMinutes(30);
            }

            SetMaxAndMinDate();

            return View(model);
        }

        [HttpPost("Event/Create")]
        public async Task<IActionResult> Create(AddCalendarEventCommand command)
        {
            var model = await _service.AddNewAsync(command);

            if (HasDomainErrors())
                return View(command);

            return RedirectToAction("Index", "Event", new { id = model.Id });
        }

        [HttpGet("Event/Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) 
                return NotFound();

            var result = await _service.GetEventByIdAsync(id);

            if (result == null) 
                return NotFound();

            SetMaxAndMinDate();

            return View(result);
        }

        [HttpPost("Event/Edit")]
        public async Task<IActionResult> Edit(UpdateCalendarEventCommand command)
        {
            var model = await _service.UpdateAsync(command);
            return RedirectToAction("Index", "Event", new { id = model.Id });
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
