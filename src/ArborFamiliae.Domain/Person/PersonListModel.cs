namespace ArborFamiliae.Domain.Person
{
    public class PersonListModel : BaseDomainModel
    {

        public string ArborId { get; set; }
        
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string DeathDate { get; set; }

        public string FullName { get => Surname + ", " + FirstName; }
    }
}