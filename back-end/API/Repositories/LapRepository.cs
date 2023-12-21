using API.Database;
using API.Repositories.Interfaces;
using Core.Entities;

namespace API.Repositories;

public class LapRepository : BaseRepository<Lap>, ILapRepository
{
    public LapRepository(F1DbContext context) : base(context)
    {
    }
}