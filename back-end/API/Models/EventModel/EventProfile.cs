using AutoMapper;
using Core.Entities;
using Core.Entities.Dto;

namespace API.Models.EventModel;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<CreateEventDto, Event>();

        CreateMap<Event, EventDto>();
    }
}