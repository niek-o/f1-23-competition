using AutoMapper;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Core.Entities;
using Core.Entities.Dto;

namespace API.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public EventService(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<EventDto> CreateEvent(CreateEventDto createEvent)
    {
        Event mappedEvent = _mapper.Map<Event>(createEvent);

        Event result = await _eventRepository.AddAsync(mappedEvent);
        return _mapper.Map<EventDto>(result);
    }

    public async Task<EventDto> GetEvent(int id)
    {
        Event result = await _eventRepository.GetFirstAsync(m => m.Id == id);
        return _mapper.Map<EventDto>(result);
    }

    public async Task<EventDto> GetCurrentEvent()
    {
        DateTime dateTime = DateTime.Now;
        Event result =
            await _eventRepository.GetFirstAsync(m => dateTime >= m.StartDate && m.EndDate >= dateTime);
        return _mapper.Map<EventDto>(result);
    }
    
    public async Task<List<EventDto>> GetAllEvents()
    {
        List<Event> result =
            await _eventRepository.GetAllAsync(m => m.Id >= 0);
        return _mapper.Map<List<EventDto>>(result);
    }
}