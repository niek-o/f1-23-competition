using F1Sharp;

namespace Core.Entities;

public class Lap : BaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string LapTime { get; set; }
    public int LapTimeInMS { get; set; }
    public DateTime TimeSet { get; set; }
    public Track TrackId { get; set; }
    public int EventId { get; set; }
}