using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Data.Models;

public class Place : BaseModel, IAggregateRoot, IHasSequence
{
    public string ArborId { get; set; }
    public virtual Place EnclosedBy { get; set; }
    public Guid EnclosedById { get; set; }
    public string Name { get; set; }
    public int PlaceType { get; set; }
    public float? Latitude { get; set; }
    public float? Longitude { get; set; }
    public string? Code { get; set; }
    public virtual List<Place> Enclosing { get; set; }
    
    public string SequenceType => "Place";

    public bool NeedsSequence => String.IsNullOrEmpty(ArborId);

    public void SetSequence(int sequence)
    {
        ArborId = $"P{sequence:0000}";
    }
}
