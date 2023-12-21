using API.Database;
using API.Database.Interfaces;
using AutoMapper;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Core.Entities;
using Core.Entities.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace API.Services;

public class LapService : ILapService
{
    private readonly ILapRepository _lapRepository;
    private readonly IMapper _mapper;
    private IMemoryCache _memoryCache;

    public LapService(ILapRepository lapRepository, IMapper mapper, IMemoryCache memoryCache)
    {
        _lapRepository = lapRepository;
        _mapper = mapper;
        _memoryCache = memoryCache;
    }

    public async Task<LapDto> CreateLap(CreateLapDto createLap)
    {
        IMemoryStore memoryStore = new MemoryStore(_memoryCache);

        var timeSpan = TimeSpan.FromMilliseconds(createLap.LapTimeInMS);

        Lap lap = _mapper.Map<Lap>(createLap);

        lap.UserId = Convert.ToInt32(memoryStore.GetCachedData("CurrentActiveUser"));
        lap.LapTime = $"{timeSpan.Minutes:D1}:{timeSpan.Seconds:D2}.{timeSpan.Milliseconds:D3}";
        lap.TimeSet = DateTime.Now;

        Lap result = await _lapRepository.AddAsync(lap);
        return _mapper.Map<LapDto>(result);
    }

    public async Task<LapDto> GetLap(int id)
    {
        Lap result = await _lapRepository.GetFirstAsync(m => m.Id == id);
        return _mapper.Map<LapDto>(result);
    }
}