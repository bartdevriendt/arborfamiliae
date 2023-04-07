using ArborFamiliae.Domain.Events;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Shared.Services;

public interface IDateParserService : ITransient
{
    ArborDateModel? ParseDate(string text);
}