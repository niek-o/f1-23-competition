using API.Database;
using API.Database.Interfaces;
using AutoMapper;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Core.Entities;
using Core.Entities.Dto;
using F1Sharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NuGet.Protocol;

namespace API.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private F1DbContext _context;
    private int _currentEventId;

    public EventService(IEventRepository eventRepository, IMapper mapper, F1DbContext context)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _context = context;

        DateTime dateTime = DateTime.Now;

        var eventResult =
            from events in _context.Events
            where dateTime >= events.StartDate
            where events.EndDate >= dateTime
            select new
            {
                Id = events.Id
            };

        try
        {
            _currentEventId = eventResult.First().Id;
        }
        catch
        {
            _currentEventId = -1;
        }
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
            await _eventRepository.GetFirstAsync(m =>
                dateTime >= m.StartDate && m.EndDate >= dateTime && m.Id == _currentEventId);

        return _mapper.Map<EventDto>(result);
    }

    public async Task<List<EventDto>> GetAllEvents()
    {
        List<Event> result =
            await _eventRepository.GetAllAsync(m => m.Id >= 0);
        return _mapper.Map<List<EventDto>>(result);
    }

    public async Task<Result> GetEventResults(int id)
    {
        var eventResult =
            from events in _context.Events
            join laps in _context.Laps on events.Id equals laps.EventId
            where events.Id == id
            select new Event
            {
                Id = events.Id,
                TrackId = events.TrackId,
                EventName = events.EventName,
                EndDate = events.EndDate,
                StartDate = events.StartDate
            };

        var usersResult =
            from user in _context.Users
            join laps in _context.Laps on user.Id equals laps.UserId
            where laps.EventId == id
            select user;

        var distinctusers = usersResult.ToList().GroupBy(u => u.Id)
            .Select(g => g.First());

        var eventQueryResult = await eventResult.FirstAsync();

        List<LeaderBoardEntry> leaderBoardEntries = new List<LeaderBoardEntry>();

        foreach (User distinctuser in distinctusers)
        {
            var lapsResult =
                from laps in _context.Laps
                where laps.EventId == id
                where laps.UserId == distinctuser.Id
                where laps.TrackId == eventQueryResult.TrackId
                select laps;

            var lapQueryResult = lapsResult.ToList();

            foreach (Lap lap in lapQueryResult)
            {
                {
                    leaderBoardEntries.Add(new LeaderBoardEntry
                    {
                        Lap = lap,
                        User = distinctuser
                    });
                }
            }
        }

        var endResult = new Result
        {
            Event = eventQueryResult,
            LeaderBoard = leaderBoardEntries
        };

        return endResult;
    }

    public Task<Result> GetCurrentEventResults()
    {
        return GetEventResults(_currentEventId);
    }

    public String GetTrackNameById(int id)
    {
        var trackItem = (Track)id;

        return trackItem.ToString();
    }
}