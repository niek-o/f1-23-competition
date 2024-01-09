using F1Sharp;

namespace Core.Entities.Dto;

public class LapDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string LapTime { get; set; }
    public int LapTimeInMS { get; set; }
    public DateTime TimeSet { get; set; }
    public Track TrackId { get; set; }
    public int EventId { get; set; }
}