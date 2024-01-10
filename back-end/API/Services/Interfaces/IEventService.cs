using Core.Entities;
using Core.Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Interfaces;

public interface IEventService
{
    Task<EventDto> CreateEvent (CreateEventDto createEvent);
    Task<EventDto> GetCurrentEvent();
    Task<EventDto> GetEvent(int id);
    Task<List<EventDto>> GetAllEvents();
    Task<Result> GetCurrentEventResults();
    Task<Result> GetEventResults(int id);
    string GetTrackNameById(int id);
}