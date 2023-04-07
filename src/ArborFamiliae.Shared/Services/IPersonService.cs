using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArborFamiliae.Domain.Person;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Shared.Services;

public interface IPersonService : ITransient
{
    Task<List<PersonListModel>> GetPersonsFiltered(Guid? gender);
    Task<List<PersonListModel>> GetAllPersons();
    Task<PersonAddEditModel> GetPersonById(Guid id);
    Task<PersonAddEditModel?> GetPersonByArborId(string arborId);
    Task<PersonAddEditModel> AddEditPerson(PersonAddEditModel model);
}