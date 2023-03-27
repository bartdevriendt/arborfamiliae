using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Domain.Person;
using ArborFamiliae.Services.Specifications;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Services.Genealogy
{
    public class PersonService : ITransient
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

        private List<PersonListModel> ConvertToDomain(List<Person> persons)
        {
            var result = new List<PersonListModel>();

            foreach (var p in persons)
            {
                var model = new PersonListModel
                {
                    BirthDate = "",
                    Gender = p.Gender.Description,
                    Id = p.Id,
                    Surname = p.PrimaryName?.Surnames[0].SurnameValue,
                    FirstName = p.PrimaryName?.FirstName,
                    DeathDate = "",
                    ArborId = p.ArborId
                };

                var birth = p.Events.FirstOrDefault(
                    e => ((EventType)e.Event.EventType) == EventType.BIRTH
                );
                if (birth != null)
                {
                    model.BirthDate = birth.Event.EventDate?.Text;
                }

                var death = p.Events.FirstOrDefault(
                    e => ((EventType)e.Event.EventType) == EventType.DEATH
                );
                if (death != null)
                {
                    model.DeathDate = death.Event.EventDate?.Text;
                }

                result.Add(model);
            }

            result = result.OrderBy(p => p.Surname).ToList();
            
            return result;
        }

        public async Task<List<PersonListModel>> GetPersonsFiltered(Guid? gender)
        {
            var persons = await _personReadRepository.ListAsync(
                new PersonListSpecification(gender)
            );

            return ConvertToDomain(persons);
        }

        public async Task<List<PersonListModel>> GetAllPersons()
        {
            var persons = await _personReadRepository.ListAsync(new PersonListSpecification());

            return ConvertToDomain(persons);
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
