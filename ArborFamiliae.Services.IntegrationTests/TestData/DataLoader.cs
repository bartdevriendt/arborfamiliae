using ArborFamiliae.Data;
using ArborFamiliae.Data.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArborFamiliae.Services.IntegrationTests.TestData;

public class DataLoader
{
    private ArborFamiliaeContext _context;

    public DataLoader(ArborFamiliaeContext context)
    {
        _context = context;
    }

    public void LoadData(string json)
    {
        var dataObject = (JObject)JsonConvert.DeserializeObject(json);
        if (dataObject == null)
            return;

        if (dataObject.ContainsKey("genders"))
        {
            LoadGenders(dataObject["genders"]);
        }
        if (dataObject.ContainsKey("sequences"))
        {
            LoadSequences(dataObject["sequences"]);
        }
        if (dataObject.ContainsKey("persons"))
        {
            LoadPersons(dataObject["persons"]);
        }

        if (dataObject.ContainsKey("personevents"))
        {
            LoadPersonEvents(dataObject["personevents"]);
        }
    }

    private void LoadPersonEvents(JToken? personEvents)
    {
        foreach (var pe in personEvents)
        {
            PersonEvent personEvent = new PersonEvent();
            personEvent.Id = Guid.NewGuid();
            personEvent.Person = FindPerson(pe["personid"].Value<string>());

            ArborEvent arborEvent = new ArborEvent();
            arborEvent.Id = Guid.NewGuid();
            arborEvent.ArborId = pe["arborid"].Value<string>();
            arborEvent.Description = pe["description"].Value<string>();
            arborEvent.EventType = pe["eventtype"].Value<int>();
            arborEvent.Place = null;
            arborEvent.IsPrivate = pe["private"].Value<bool>();
            arborEvent.EventDate = ConvertToDate(pe["date"]);
            personEvent.Event = arborEvent;

            _context.PersonEvents.Add(personEvent);
        }

        _context.SaveChanges();
    }

    private void LoadSequences(JToken sequences)
    {
        foreach (var seq in sequences)
        {
            Sequence sequence = new Sequence()
            {
                Id = Guid.NewGuid(),
                SequenceType = seq["type"].Value<string>(),
                NextValue = seq["value"].Value<int>()
            };
            _context.Sequences.Add(sequence);
        }

        _context.SaveChanges();
    }

    private void LoadPersons(JToken persons)
    {
        foreach (var dataPerson in persons)
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                Gender = FindGender(dataPerson["gender"].Value<string>()),
                ArborId = dataPerson["arborid"].Value<string>(),
                IsPrivate = false
            };

            foreach (var dataName in dataPerson["names"])
            {
                Name name = new Name()
                {
                    Id = Guid.NewGuid(),
                    IsPrivate = false,
                    Person = person,
                    IsPrimary = dataName["primary"].Value<bool>(),
                    Call = dataName["call"].Value<string>(),
                    Nickname = dataName["nickname"].Value<string>(),
                    Suffix = dataName["suffix"].Value<string>(),
                    Title = dataName["title"].Value<string>(),
                    FirstName = dataName["firstname"].Value<string>(),
                    NameType = dataName["nametype"].Value<int>(),
                    FamiliyNickName = dataName["familynick"].Value<string>()
                };

                person.Names.Add(name);

                foreach (var dataSurname in dataName["surnames"])
                {
                    Surname surname = new Surname()
                    {
                        Id = Guid.NewGuid(),
                        Name = name,
                        Connector = dataSurname["connector"].Value<string>(),
                        Prefix = dataSurname["prefix"].Value<string>(),
                        OriginType = (SurnameType)dataSurname["surnametype"].Value<int>(),
                        SurnameValue = dataSurname["namevalue"].Value<string>(),
                        Primary = dataSurname["primary"].Value<bool>()
                    };

                    name.Surnames.Add(surname);
                }
            }

            _context.Persons.Add(person);
        }

        _context.SaveChanges();
    }

    private ArborDate ConvertToDate(JToken token)
    {
        return new ArborDate
        {
            Calendar = token["calendar"].Value<int>(),
            Modifier = token["modifier"].Value<int>(),
            Quality = token["quality"].Value<int>(),
            Day = token["day"].Value<int>(),
            Day2 = token["day2"].Value<int>(),
            Month2 = token["month2"].Value<int>(),
            Month = token["month"].Value<int>(),
            Year = token["year"].Value<int>(),
            Year2 = token["year2"].Value<int>(),
            NewYear = token["newYear"].Value<int>(),
            Text = token["text"].HasValues ? token["text"].Value<string?>() : null,
            SlashDate2 = token["slashDate2"].Value<bool>(),
            SlashDate1 = token["slashDate1"].Value<bool>(),
        };
    }

    private void LoadGenders(JToken genders)
    {
        int sortOrder = 0;
        foreach (var gender in genders)
        {
            Gender g = new Gender()
            {
                Id = Guid.NewGuid(),
                Description = gender["description"].Value<string>(),
                SortOrder = sortOrder++
            };

            _context.Genders.Add(g);
        }

        _context.SaveChanges();
    }

    private Gender FindGender(string gender)
    {
        return _context.Genders.First(g => g.Description == gender);
    }

    private Person FindPerson(string personId)
    {
        return _context.Persons.First(p => p.ArborId == personId);
    }
}
