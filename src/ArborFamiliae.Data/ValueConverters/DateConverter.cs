using System.Text.Json;
using ArborFamiliae.Data.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArborFamiliae.Data.ValueConverters;

public class DateConverter : ValueConverter<ArborDate, string?>
{
    public DateConverter()
        : base(
            v => JsonSerializer.Serialize(v, typeof(ArborDate), new JsonSerializerOptions()),
            v => JsonSerializer.Deserialize<ArborDate>(v, new JsonSerializerOptions()) ?? null
        ) { }
}
