using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArborFamiliae.Data.Models
{
    public class Name : BaseModel
    {
        public bool IsPrivate { get; set; }
        public string FirstName { get; set; }
        public List<Surname> Surnames { get; set; } = new();
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string Call { get; set; }
        public string Nickname { get; set; }
        public string FamiliyNickName { get; set; }
        public NameType NameType { get; set; }
        public Guid NameTypeId { get; set; }

        public Surname PrimarySurname => Surnames.First(x => x.Primary);
    }
}
