using ArborFamiliae.Domain.Person;
using ArborFamiliae.Services.Genealogy;
using ArborFamiliae.Services.IntegrationTests.Fixtures;
using Microsoft.EntityFrameworkCore;

namespace ArborFamiliae.Services.IntegrationTests.Genealogy;

public class PersonServiceTests : TestBase
{
    [Test]
    public async Task Test_LoadAllPersons()
    {
        // arrange
        var personService = GetService<PersonService>();
        // act
        var persons = await personService.GetAllPersons();

        // assert
        await Verify(persons).ToTask();
    }

    [Test]
    public async Task Test_LoadPersonById()
    {
        // arrange
        var dbContext = GetDbContext();
        var personOrig = await dbContext.Persons.OrderBy(x => x.ArborId).FirstOrDefaultAsync();
        var personService = GetService<PersonService>();

        // act
        var person = await personService.GetPersonById(personOrig.Id);

        // assert
        await Verify(person).ToTask();
    }

    [Test]
    public async Task Test_AddPerson()
    {
        // arrange
        var dbContext = GetDbContext();
        PersonAddEditModel model = new PersonAddEditModel();
        model.Id = Guid.Empty;
        model.Gender = HelperStuff.Genders.First();
        model.PreferredCall = "TestCall";
        model.PreferredSurname = "TestSurname";
        model.PreferredGivenName = "TestGiven";
        model.PreferredNick = "TestNick";
        model.PreferredTitle = "TestTitle";
        model.PreferredSurnamePrefix = "TestSurnamePrefix";
        var personService = GetService<PersonService>();
        // act
        var added = await personService.AddEditPerson(model);
        var person = await personService.GetPersonById(added.Id);
        // assert
        await Verify(person).ToTask();
    }

    [Test]
    public async Task Test_EditPerson()
    {
        // arrange
        var dbContext = GetDbContext();
        var personOrig = await dbContext.Persons.OrderBy(x => x.ArborId).FirstOrDefaultAsync();
        var personService = GetService<PersonService>();
        var model = await personService.GetPersonById(personOrig.Id);
        model.PreferredCall = "TestCall";
        model.PreferredSurname = "TestSurname";
        model.PreferredGivenName = "TestGiven";
        model.PreferredNick = "TestNick";
        model.PreferredTitle = "TestTitle";
        model.PreferredSurnamePrefix = "TestSurnamePrefix";
        model.Gender = HelperStuff.Genders.FirstOrDefault(x => x != model.Gender);

        // act
        var edited = await personService.AddEditPerson(model);
        var person = await personService.GetPersonById(edited.Id);
        // assert
        await Verify(person).ToTask();
    }
}
