namespace Core.Entities.Dto;

public class CreateEventDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string EventName { get; set; }
}