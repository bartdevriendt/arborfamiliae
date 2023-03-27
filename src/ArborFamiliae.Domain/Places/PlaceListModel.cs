using System;

namespace ArborFamiliae.Domain.Places;

public class PlaceListModel : BaseDomainModel
{
    public string Name { get; set; }
    public string ArborId { get; set; }
    public string Type { get; set; }
    public string? Code { get; set; }

    public Guid? ParentPlaceId { get; set; }
}
