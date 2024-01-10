using Microsoft.AspNetCore.Mvc;
using API.Services.Interfaces;
using Core.Entities;
using Core.Entities.Dto;

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
        
        // GET: api/event
        // Get current event
        [HttpGet]
        [Route("/currentevent")]
        public async Task<ActionResult<EventDto>> GetCurrentEvent([FromServices] IEventService eventService)
        {
            EventDto currentEvent = await eventService.GetCurrentEvent();
            
            return Ok(currentEvent);
        }                
        
        // GET: api/event
        // Get current event
        [HttpGet]
        [Route("/currentevent/results")]
        public async Task<ActionResult<Result>> GetCurrentEventResults([FromServices] IEventService eventService)
        {
            Result currentEvent = await eventService.GetCurrentEventResults();
            
            return Ok(currentEvent);
        }
        
        // GET: api/event
        // Get current event
        [HttpGet]
        [Route("/results/{id}")]
        public async Task<ActionResult<Result>> GetEventResults([FromServices] IEventService eventService, int id)
        {
            Result currentEvent = await eventService.GetEventResults(id);
            
            return Ok(currentEvent);
        }

        [HttpGet]
        [Route("/track/{id}")]
        public async Task<ActionResult<String>> GetTrackNameById([FromServices] IEventService eventService, int id)
        {
            String track = eventService.GetTrackNameById(id);

            return Ok(track);
        }
    }
}