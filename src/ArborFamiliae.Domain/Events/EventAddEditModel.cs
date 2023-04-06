using System;
using ArborFamiliae.Domain.Enums;

namespace ArborFamiliae.Domain.Events;

public class EventAddEditModel : BaseDomainModel
{
    public EventListType ListType { get; set; }
    
    public string Category { get; set; }
    public EventRole Role { get; set; }
    public string RoleDescription { get; set; }
    public EventType Type { get; set; }
    public string TypeDescription { get; set; }
    public ArborDateModel? Date { set; get; }
    
    public string DateText { get; set; }
    public string ArborId { get; set; }
    public Guid? PlaceId { get; set; }
    public string? PlaceName { get; set; }
    public string? Description { get; set; }
    
    public string? Participants { get; set; }
}
