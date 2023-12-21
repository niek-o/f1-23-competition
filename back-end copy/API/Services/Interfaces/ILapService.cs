using Core.Entities.Dto;

namespace API.Services.Interfaces;

public interface ILapService
{
    Task<LapDto> CreateLap(CreateLapDto createLap);
    Task<LapDto> GetLap(int id);
}