using F1Sharp;

namespace Core.Entities.Dto;

public class CreateLapDto
{
    public int LapTimeInMS { get; set; }
    public Track TrackId { get; set; }
}