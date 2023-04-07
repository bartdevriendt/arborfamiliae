using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArborFamiliae.Domain.Events;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Shared.Services;

public interface IPersonEventService : ITransient
{
    Task<List<EventAddEditModel>> GetEventsForPerson(Guid personId);
    Task<EventAddEditModel> GetEventById(Guid id);

    Task<EventAddEditModel> AddEditEventForPerson(
        Guid personId,
        EventAddEditModel model
    );
}