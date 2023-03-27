namespace ArborFamiliae.Data.Models;

public class PersonEvent : BaseModel
{
    public virtual Person Person { get; set; }
    public Guid PersonId { get; set; }
    public virtual ArborEvent Event { get; set; }
    public Guid EventId { get; set; }
    public int EventRole { get; set; }
}
