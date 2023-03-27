using System;
using ArborFamiliae.Domain.Enums;

namespace ArborFamiliae.Domain.Events;

public class EventAddEditModel : BaseDomainModel
{
    public EventRole Role { get; set; }
    public EventType Type { get; set; }
    public ArborDateModel? Date { set; get; }
    public string ArborId { get; set; }
    public Guid? PlaceId { get; set; }
    public string? PlaceName { get; set; }
    public string? Description { get; set; }
}
