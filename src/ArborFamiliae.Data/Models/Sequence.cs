using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Data.Models;

public class Sequence : BaseModel, IAggregateRoot
{
    public virtual string SequenceType { get; set; }
    public virtual int NextValue { get; set; }
}
