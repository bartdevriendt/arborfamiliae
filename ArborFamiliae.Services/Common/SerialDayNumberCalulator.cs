using System.Globalization;
using ArborFamiliae.Domain.Events;
using ArborFamiliae.Domain.Exceptions;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Services.Common;

public class SerialDayNumberCalulator : IScoped
{
    private const int _GRG_SDN_OFFSET = 32045;
    private const int _GRG_DAYS_PER_5_MONTHS = 153;
    private const int _GRG_DAYS_PER_4_YEARS = 1461;
    private const int _GRG_DAYS_PER_400_YEARS = 146097;

    public int CalculateSdn((int, int, int) date, DateCalendar calendar)
    {
        if (calendar == DateCalendar.CAL_GREGORIAN)
        {
            return GregorianSdn(date.Item1, date.Item2, date.Item3);
        }

        throw new DateException($"Sdn calculator not implemented for calendar {calendar}");
    }

    private int GregorianSdn(int year, int month, int day)
    {
        if (year < 0)
            year += 4801;
        else
            year += 4800;

        if (month > 2)
            month -= 3;
        else
        {
            month += 9;
            year -= 1;
        }

        return DivideRound(DivideRound(year, 100) * _GRG_DAYS_PER_400_YEARS, 4)
            + DivideRound((year % 100) * _GRG_DAYS_PER_4_YEARS, 4)
            + DivideRound(month * _GRG_DAYS_PER_5_MONTHS + 2, 5)
            + day
            - _GRG_SDN_OFFSET;
    }

    private int DivideRound(int a, int b)
    {
        return (int)Math.Floor(a / (double)b);
    }
}
