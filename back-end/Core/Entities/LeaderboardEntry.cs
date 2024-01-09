using F1Sharp;

namespace Core.Entities;

public class LeaderBoardEntry : BaseEntity
{
    public User User { get; set; }
    public Lap Lap { get; set; }
}