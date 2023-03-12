using ArborFamiliae.Domain.Enums;

namespace ArborFamiliae.Domain.Places;

public class PlaceAddEditModel : BaseDomainModel
{
    public string Name { get; set; }
    public string? Code { get; set; }
    public PlaceType PlaceType { get; set; } = PlaceType.UNKNOWN;
    public string ArborId { get; set; }
    public string? Description { get; set; }
}
