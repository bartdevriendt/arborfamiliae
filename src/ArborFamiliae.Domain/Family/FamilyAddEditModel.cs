using System;
using System.Collections.Generic;
using ArborFamiliae.Domain.Events;

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

    public List<FamilyChildAddEditModel> Children { get; set; } = new();
    public List<FamilyChildAddEditModel> DeletedChildren { get; set; } = new();
    public List<EventAddEditModel> Events { get; set; } = new();

    public List<EventAddEditModel> DeletedEvents { get; set; } = new();
}
