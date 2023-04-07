using System;
using System.Collections.Generic;
using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Shared.Services;

public interface IEnumService : ITransient
{
    List<EnumListType<T>> GetEnumTypes<T>() where T : struct, Enum;
}