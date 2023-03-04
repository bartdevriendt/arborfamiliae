using System;

namespace ArborFamiliae.Domain.Exceptions;

public class DateException : Exception
{
    public DateException(string message)
        : base(message) { }

    public DateException(string message, Exception innerException)
        : base(message, innerException) { }
}
