using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Domain.Events;
using ArborFamiliae.Domain.Person;
using ArborFamiliae.Services.Specifications;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Services.Genealogy
{
    public class PersonService : ITransient
    {
        private IReadRepository<Person> _personReadRepository;
        private IRepository<Person> _personRepository;
        private PersonEventService _personEventService;
        private IRepository<ArborEvent> _arborEventRepository;
        public PersonService(
            IReadRepository<Person> personReadRepository,
            IRepository<Person> personRepository, PersonEventService personEventService, IRepository<ArborEvent> arborEventRepository)
        {
            _personReadRepository = personReadRepository;
            _personRepository = personRepository;
            _personEventService = personEventService;
            _arborEventRepository = arborEventRepository;
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
            PersonAddEditModel result = new()
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

            result.Events = await _personEventService.GetEventsForPerson(id); 

            return result;
        }
        
        public async Task<PersonAddEditModel?> GetPersonByArborId(string arborId)
        {
            var p = await _personReadRepository.FirstOrDefaultAsync(new PersonByArborIdSpecification(arborId));
            if (p == null) return null;
            
            PersonAddEditModel result = new()
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

            result.Events = await _personEventService.GetEventsForPerson(result.Id); 

            return result;
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
            model.ArborId = p.ArborId;
            
            foreach (var personEvent in model.Events)
            {

                if (personEvent.ListType != EventListType.Person) continue;
            
                var arborEvent = new ArborEvent();
                if (personEvent.Id == Guid.Empty)
                {
                    arborEvent.Id = Guid.NewGuid();
                    PersonEvent fe = new PersonEvent();
                    fe.Id = Guid.NewGuid();
                    fe.Person = p;
                    fe.Event = arborEvent;
                    fe.EventRole = (int)personEvent.Role;
                    p.Events.Add(fe);
                    personEvent.Id = arborEvent.Id;
                
                }
                else 
                {
                    arborEvent = p.Events.FirstOrDefault(x => x.EventId == personEvent.Id)?.Event ?? throw new Exception("Event not found");
                }
                arborEvent.Description = personEvent.Description;
                arborEvent.EventDate = ToArborDate(personEvent.Date);
                arborEvent.EventType = (int)personEvent.Type;
                arborEvent.PlaceId = personEvent.PlaceId;
            
            }

        

            await _personRepository.UpdateAsync(p);

            List<ArborEvent> deleteArborEvent = new();
        

            foreach (var deletedEvent in model.DeletedEvents)
            {
                if (deletedEvent.ListType != EventListType.Person) continue;
            
                var familyEvent = p.Events.FirstOrDefault(x => x.EventId == deletedEvent.Id) ?? throw new Exception("Event not found");
                deleteArborEvent.Add(await _arborEventRepository.GetByIdAsync(familyEvent.Event.Id));
            
                p.Events.Remove(familyEvent);
            
            
            }
        
        
            await _personRepository.UpdateAsync(p);

            if (deleteArborEvent.Count > 0)
            {
                await _arborEventRepository.DeleteRangeAsync(deleteArborEvent);    
            }

            return model;
        }
        
        private ArborDate ToArborDate(ArborDateModel arborDateModel)
        {
            return new ArborDate
            {
                Text = arborDateModel.Text,
                Calendar = (int)arborDateModel.Calendar,
                Day = arborDateModel.Day,
                Day2 = arborDateModel.Day2,
                Modifier = (int)arborDateModel.Modifier,
                Month = arborDateModel.Month,
                Month2 = arborDateModel.Month2,
                Year = arborDateModel.Year,
                Year2 = arborDateModel.Year2,
                NewYear = (int)arborDateModel.NewYear,
                Quality = (int)arborDateModel.Quality,
                SlashDate1 = arborDateModel.SlashDate1,
                SortValue = arborDateModel.SortValue,
                SlashDate2 = arborDateModel.SlashDate2
            };
        }
    }
    
    
}
