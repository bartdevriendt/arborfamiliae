using System;
using ArborFamiliae.Domain.Enums;

namespace ArborFamiliae.Domain.Places;

public class PlaceAddEditModel : BaseDomainModel
{
    public string Name { get; set; }
    public string? Code { get; set; }
    public PlaceType PlaceType { get; set; } = PlaceType.UNKNOWN;
    public string ArborId { get; set; }
    public float? Latitude { get; set; }
    public float? Longitude { get; set; }

    public Guid? ParentPlaceId { get; set; }
    public string ParentPlaceName { get; set; }
}
