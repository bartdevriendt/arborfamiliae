using ArborFamiliae.Data;
using ArborFamiliae.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArborFamiliae.Services
{
    public class PersonService
    {
        private ArborFamiliaeContext context;

        public PersonService(ArborFamiliaeContext context)
        {
            this.context = context;
        }

        public List<Person> GetAllPersons()
        {
            return context.Persons.ToList();
        }
    }
}
