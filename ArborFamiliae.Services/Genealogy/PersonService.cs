using ArborFamiliae.Data;
using ArborFamiliae.Data.Models;
using ArborFamiliae.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArborFamiliae.Domain.Person;

namespace ArborFamiliae.Services.Genealogy
{
    public class PersonService : IScoped
    {
        private ArborFamiliaeContext context;

        public PersonService(ArborFamiliaeContext context)
        {
            this.context = context;
        }

        public List<PersonListModel> GetAllPersons()
        {
            var persons = context.Persons.ToList();
            return persons
                .Select(
                    p =>
                        new PersonListModel
                        {
                            BirthDate = "",
                            Gender = p.Gender.Description,
                            Id = p.Id,
                            Surname = p.PrimaryName.Surnames[0].SurnameValue,
                            FirstName = p.PrimaryName.FirstName,
                            DeathDate = "",
                            ArborId = p.ArborId
                        }
                )
                .ToList();
        }
    }
}
