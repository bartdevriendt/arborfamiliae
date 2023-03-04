using ArborFamiliae.Services.Common;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Services.Genealogy;

public class EventService : IScoped
{
    private DateCalculationService _dateCalculationService;

    public EventService(DateCalculationService dateCalculationService)
    {
        _dateCalculationService = dateCalculationService;
    }
    
    
}