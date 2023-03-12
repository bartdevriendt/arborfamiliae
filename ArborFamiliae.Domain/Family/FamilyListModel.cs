namespace ArborFamiliae.Domain.Family;

public class FamilyListModel : BaseDomainModel
{
    public string ArborId { get; set; }
    public string Father { get; set; }
    public string Mother { get; set; }
    public string Relationship { get; set; }
    public string MarriageDate { get; set; }
}
