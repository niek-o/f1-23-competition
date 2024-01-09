﻿using F1Sharp;

namespace Core.Entities;

public class Event : BaseEntity
{
    public int Id { get; set; }
    public string EventName { get; set; }
    public Track TrackId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}