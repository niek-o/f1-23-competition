using API.Database;
using API.Repositories.Interfaces;
using Core.Entities;

namespace API.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(F1DbContext context) : base(context)
    {
    }
}