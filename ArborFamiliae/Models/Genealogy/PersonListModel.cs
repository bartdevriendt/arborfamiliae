using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArborFamiliae.Models.Genealogy
{
    public class PersonListModel
    {

        public string Surname { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfDeath { get; set; }

        public string FullName { get => Surname + ", " + FirstName; }
    }
}
