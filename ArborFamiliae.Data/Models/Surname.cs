using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArborFamiliae.Data.Models
{
    public class Surname : BaseModel
    {
        public Name Name { get; set; }
        public Guid NameId { get; set; }

        public string SurnameValue { get; set; }
        public string Prefix { get; set; }
        public bool Primary { get; set; }
        public string Connector { get; set; }

    }
}
