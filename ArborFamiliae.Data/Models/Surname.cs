using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArborFamiliae.Data.Models
{
    public enum SurnameType
    {
        Unknown = -1,
        Custom = 0,
        None = 1,
        Inherited = 2,
        Given = 3,
        Taken = 4,
        Patronymic = 5,
        Matronymic = 6,
        Feudal = 7,
        Pseudonym = 8,
        Patrilineal = 9,
        Matrilineal = 10,
        Occupation = 11,
        Location = 12
    }

    public class Surname : BaseModel
    {
        public Name Name { get; set; }
        public Guid NameId { get; set; }

        public string SurnameValue { get; set; }
        public string Prefix { get; set; }
        public bool Primary { get; set; }
        public string Connector { get; set; }
        public SurnameType OriginType { get; set; }
    }
}
