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
        public virtual Name Name { get; set; }
        public virtual Guid NameId { get; set; }

        public virtual string SurnameValue { get; set; }
        public virtual string Prefix { get; set; }
        public virtual bool Primary { get; set; }
        public virtual string Connector { get; set; }
        public virtual SurnameType OriginType { get; set; }
    }
}
