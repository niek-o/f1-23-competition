using API.Database;
using AutoMapper;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Core.Entities;
using Core.Entities.Dto;
using Core.Exceptions;

namespace API.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly F1DbContext _context;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateUser(CreateUserDto createUser)
    {
        try
        {
            User checkIfExisting = await _userRepository.GetFirstAsync(m =>
                m.FirstName == createUser.FirstName
                && m.LastName == createUser.LastName
                && m.Email == createUser.Email);

            return _mapper.Map<UserDto>(checkIfExisting);
        }
        catch
        {
            User user = _mapper.Map<User>(createUser);

            User result = await _userRepository.AddAsync(user);
            return _mapper.Map<UserDto>(result);
        }
    }

    public async Task<UserDto> GetUser(int id)
    {
        User result = await _userRepository.GetFirstAsync(m => m.Id == id);
        return _mapper.Map<UserDto>(result);
    }
}