using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Domain.Person;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Services.Genealogy
{
    public class PersonService : IScoped
    {
        //private ArborFamiliaeContext context;
        private IReadRepository<Person> _personReadRepository;
        private IRepository<Person> _personRepository;

        public PersonService(
            IReadRepository<Person> personReadRepository,
            IRepository<Person> personRepository
        )
        {
            _personReadRepository = personReadRepository;
            _personRepository = personRepository;
        }

        public async Task<List<PersonListModel>> GetAllPersons()
        {
            var persons = await _personReadRepository.ListAsync();
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
                .OrderBy(p => p.ArborId)
                .ToList();
        }

        public async Task<PersonAddEditModel> GetPersonById(Guid id)
        {
            var p = await _personReadRepository.GetByIdAsync(id);
            return new PersonAddEditModel
            {
                Id = p.Id,
                Gender = p.GenderId,
                PreferredTitle = p.PrimaryName.Title,
                PreferredNick = p.PrimaryName.Nickname,
                PreferredSuffix = p.PrimaryName.Suffix,
                PreferredSurname = p.PrimaryName.PrimarySurname.SurnameValue,
                PreferredCall = p.PrimaryName.Call,
                PreferredNameType = (NameType)p.PrimaryName.NameType,
                PreferredSurnamePrefix = p.PrimaryName.PrimarySurname.Prefix,
                PreferredGivenName = p.PrimaryName.FirstName,
                ArborId = p.ArborId
            };
        }

        public async Task<PersonAddEditModel> AddEditPerson(PersonAddEditModel model)
        {
            Person? p = null;
            bool isNew = false;
            if (model.Id == Guid.Empty)
            {
                p = new Person();
                p.Id = Guid.NewGuid();
                var name = new Name();
                name.Id = Guid.NewGuid();
                name.IsPrimary = true;
                name.Surnames.Add(new Surname() { Id = Guid.NewGuid(), Primary = true });
                p.Names.Add(name);
                isNew = true;
            }
            else
            {
                p = await _personReadRepository.GetByIdAsync(model.Id);
            }

            p.GenderId = model.Gender;
            p.IsPrivate = false;
            p.PrimaryName.NameType = (int)model.PreferredNameType;
            p.PrimaryName.FirstName = model.PreferredGivenName;
            p.PrimaryName.Call = model.PreferredCall;
            p.PrimaryName.Nickname = model.PreferredNick;
            p.PrimaryName.Suffix = model.PreferredSuffix;
            p.PrimaryName.Title = model.PreferredTitle;
            p.PrimaryName.FamiliyNickName = "";
            p.PrimaryName.PrimarySurname.SurnameValue = model.PreferredSurname;
            p.PrimaryName.PrimarySurname.Prefix = model.PreferredSurnamePrefix;

            if (isNew)
            {
                await _personRepository.AddAsync(p);
            }
            else
            {
                await _personRepository.UpdateAsync(p);
            }

            model.Id = p.Id;
            return model;
        }
    }
}
