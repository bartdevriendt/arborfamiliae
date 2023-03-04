using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Data.Models;

public class ArborEvent : BaseModel, IAggregateRoot, IHasSequence
{
    public string ArborId { get; set; }
    public ArborDate? EventDate { get; set; }
    public int EventType { get; set; }
    public string? Description { get; set; }
    public virtual Place? Place { get; set; }
    public bool IsPrivate { get; set; }
    public string SequenceType => "Event";

    public void SetSequence(int sequence)
    {
        ArborId = $"E{sequence:0000}";
    }
}
