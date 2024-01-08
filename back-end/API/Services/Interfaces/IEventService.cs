using Core.Entities.Dto;

namespace API.Services.Interfaces;

public interface IEventService
{
    Task<EventDto> CreateEvent (CreateEventDto createEvent);
    Task<EventDto> GetCurrentEvent();
    Task<EventDto> GetEvent(int id);
    Task<List<EventDto>> GetAllEvents();
}