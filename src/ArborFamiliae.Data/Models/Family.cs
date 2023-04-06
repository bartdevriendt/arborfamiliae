using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Data.Models;

public class Family : BaseModel, IAggregateRoot, IHasSequence
{
    public string ArborId { get; set; }
    public virtual Person? Father { get; set; }
    public Guid? FatherId { get; set; }
    public virtual Person? Mother { get; set; }
    public Guid? MotherId { get; set; }
    public bool IsPrivate { get; set; }

    public virtual List<FamilyChild> Children { get; set; } = new();
    public virtual List<FamilyEvent> Events { get; set; } = new();
    public string SequenceType => "Family";

    public void SetSequence(int sequence)
    {
        ArborId = $"F{sequence:0000}";
    }

    public bool NeedsSequence => String.IsNullOrEmpty(ArborId);
}
