using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArborFamiliae.Data.Models
{
    public class Gender : BaseModel
    {
        public virtual int SortOrder { get; set; }
        public virtual string Description { get; set; }
    }
}
