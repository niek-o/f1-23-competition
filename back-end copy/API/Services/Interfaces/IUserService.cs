using Core.Entities.Dto;

namespace API.Services.Interfaces;

public interface IUserService
{
    Task<UserDto> CreateUser(CreateUserDto createUser);
    Task<UserDto> GetUser(int id);
}