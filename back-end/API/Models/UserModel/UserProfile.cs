using AutoMapper;
using Core.Entities;
using Core.Entities.Dto;

namespace API.Models.UserModel;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();

        CreateMap<User, UserDto>();
    }
}