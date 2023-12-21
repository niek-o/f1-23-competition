using AutoMapper;
using Core.Entities;
using Core.Entities.Dto;

namespace API.Models.LapModel;

public class LapProfile : Profile
{
    public LapProfile()
    {
        CreateMap<CreateLapDto, Lap>();

        CreateMap<Lap, LapDto>();
    }
}