using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArborFamiliae.Domain.Family;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Shared.Services;

public interface IFamilyService : ITransient
{
    Task<List<FamilyListModel>> LoadAllFamilies();
    Task<FamilyAddEditModel> GetFamilyById(Guid familyId);
    Task<FamilyAddEditModel?> GetFamilyByArborId(string arborId);
    Task<FamilyAddEditModel> AddEditFamily(FamilyAddEditModel model);
}