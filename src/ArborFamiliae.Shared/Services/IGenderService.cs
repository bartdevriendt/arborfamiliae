using System.Collections.Generic;
using System.Threading.Tasks;
using ArborFamiliae.Domain.Person;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Shared.Services;

public interface IGenderService : ITransient
{
    Task<List<GenderModel>> GetGenders();
}