using F1Sharp;

namespace Core.Entities;

public class Result : BaseEntity
{
    public Event Event { get; set; }
    public List<LeaderBoardEntry> LeaderBoard { get; set; }
}