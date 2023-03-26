using System.ComponentModel;
using System.Reflection;
using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Services.Resources;
using ArborFamiliae.Shared.Interfaces;
using Microsoft.Extensions.Localization;

namespace ArborFamiliae.Services.Common;

public class EnumService : IScoped
{
    private IStringLocalizer<ArborFamiliaeResources> _stringLocalizer;

    public EnumService(IStringLocalizer<ArborFamiliaeResources> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
    }

    public List<EnumListType<T>> GetEnumTypes<T>() where T : struct, Enum
    {
        var type = typeof(T);
        var result = Enum.GetValues<T>()
            .Select(
                x =>
                    new EnumListType<T>
                    {
                        Value = x,
                        Description = 
                            type.GetMember(x.ToString())
                                .First()
                                .GetCustomAttribute<DescriptionAttribute>()
                                ?.Description ?? x.ToString()
                        
                    }
            )
            .ToList();

        foreach (var listType in result)
        {
            listType.Description = _stringLocalizer[listType.Description];
        }
        
        return result;
    }
}
