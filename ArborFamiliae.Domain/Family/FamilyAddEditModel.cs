using System;

namespace ArborFamiliae.Domain.Family;

public class FamilyAddEditModel : BaseDomainModel
{
    public Guid? FatherId { get; set; }
    public string FatherDisplayName { get; set; }
    public string FatherBirthDate { get; set; }
    public string FatherDeathDate { get; set; }

    public Guid? MotherId { get; set; }
    public string MotherDisplayName { get; set; }
    public string MotherBirthDate { get; set; }
    public string MotherDeathDate { get; set; }

    public string ArborId { get; set; }
}
