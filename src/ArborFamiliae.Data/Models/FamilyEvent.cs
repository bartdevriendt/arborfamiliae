namespace ArborFamiliae.Data.Models;

public class FamilyEvent : BaseModel
{
    public virtual Family Family { get; set; }
    public Guid FamilyId { get; set; }
    public virtual ArborEvent Event { get; set; }
    public Guid EventId { get; set; }
    public int EventRole { get; set; }
}