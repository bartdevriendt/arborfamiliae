using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArborFamiliae.Data.Models
{

    
    public class Person : BaseModel
    {

        public string ArborId { get; set; }
        public virtual Guid GenderId { get; set; }
        public Gender Gender { get; set; }
        public bool Private { get; set; }

        public Name PrimaryName { get; set; }

        public List<Name> AlternateNames { get; set; }

        public bool IsPrivate { get; set; }


    }
}
