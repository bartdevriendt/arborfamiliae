namespace ArborFamiliae.Data.Models;

public class FamilyChild : BaseModel
{
    public virtual Family Family { get; set; }
    public Guid FamilyId { get; set; }
    public virtual Person Child { get; set; }
    public Guid ChildId { get; set; }
}
