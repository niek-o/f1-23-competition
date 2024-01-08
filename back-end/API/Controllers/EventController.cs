using API.Database;
using API.Database.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using API.Services.Interfaces;
using Core.Entities.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        // GET: api/event/{id}
        [HttpGet]
        [Route("/event/{id}")]
        public async Task<ActionResult<EventDto>> GetUsers([FromServices] IEventService eventService, int id)
        {
            return Ok(await eventService.GetEvent(id));
        }

        // GET: api/event
        // Get current event
        [HttpGet]
        [Route("/event")]
        public async Task<ActionResult<EventDto>> GetCurrentEvent([FromServices] IEventService eventService)
        {
            return Ok(await eventService.GetCurrentEvent());
        }
        
        [HttpPost]
        [Route("/event")]
        public async Task<ActionResult<EventDto>> CreateEvent([FromServices] IEventService eventService, CreateEventDto createEvent)
        {
            EventDto createdEvent = await eventService.CreateEvent(createEvent);

            return Ok(createdEvent);
        }
        
        // GET: api/events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpGet]
        [Route("/events")]
        public async Task<ActionResult<List<EventDto>>> PostUser([FromServices] IEventService eventService)
        {
            return Ok(await eventService.GetAllEvents());
        }
    }
}