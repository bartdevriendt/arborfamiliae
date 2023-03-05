﻿using Bogus;
using Person = ArborFamiliae.Data.Models.Person;

namespace ArborFamiliae.Services.IntegrationTests.Fixtures;

public sealed class PersonFaker : Faker<Person>
{
    public PersonFaker()
    {
        RuleFor(x => x.Id, f => Guid.NewGuid());
        RuleFor(x => x.ArborId, f => f.Lorem.Text());
        RuleFor(x => x.GenderId, f => f.PickRandom(HelperStuff.Genders));
        RuleFor(x => x.IsPrivate, f => f.Random.Bool());
        RuleFor(x => x.PrimaryName, (faker, person) => new ArborNameFaker(person).Generate(1).First());

    }
}