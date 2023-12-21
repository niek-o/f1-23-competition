using API.Database;
using API.Repositories.Interfaces;
using Core.Entities;

namespace API.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(F1DbContext context) : base(context)
    {
    }
}