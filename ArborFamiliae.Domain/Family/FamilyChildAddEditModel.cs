using System;

namespace ArborFamiliae.Domain.Family;

public class FamilyChildAddEditModel : BaseDomainModel
{
    public int Order { get; set; }
    public string ArborId { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string BirthDate { get; set; }
    public string PaternalRelation { get; set; }
    public string MaternalRelation { get; set; }
    public Guid? PersonId { get; set; }
    public Guid FamiliyId { get; set; }
}
