using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArborFamiliae.Domain.Events;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Shared.Services;

public interface IFamilyEventService : ITransient
{
    Task<List<EventAddEditModel>> GetEventsForFamily(Guid familyId);
}