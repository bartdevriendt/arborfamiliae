using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Data.Models;

public class Sequence : BaseModel, IAggregateRoot
{
    public string SequenceType { get; set; }
    public int NextValue { get; set; }
}
