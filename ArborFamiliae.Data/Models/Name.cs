using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArborFamiliae.Data.Models
{
    public class Name : BaseModel
    {
        public virtual bool IsPrivate { get; set; }
        public virtual string FirstName { get; set; }
        public virtual List<Surname> Surnames { get; set; } = new();
        public virtual string Suffix { get; set; }
        public virtual string Title { get; set; }
        public virtual string Call { get; set; }
        public virtual string Nickname { get; set; }
        public virtual string FamiliyNickName { get; set; }
        public virtual NameType NameType { get; set; }
        public virtual Guid NameTypeId { get; set; }

        public Surname PrimarySurname => Surnames.First(x => x.Primary);
    }
}
