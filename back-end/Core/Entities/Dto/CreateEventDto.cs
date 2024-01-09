using F1Sharp;

namespace Core.Entities.Dto;

public class CreateEventDto
{
    public string EventName { get; set; }
    public Track TrackId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}