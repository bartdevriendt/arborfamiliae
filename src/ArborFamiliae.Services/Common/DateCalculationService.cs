using ArborFamiliae.Domain.Events;
using ArborFamiliae.Domain.Exceptions;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Services.Common;

public class DateCalculationService : IScoped
{
    private SerialDayNumberCalulator _serialDayNumberCalulator;

    public DateCalculationService(SerialDayNumberCalulator serialDayNumberCalulator)
    {
        _serialDayNumberCalulator = serialDayNumberCalulator;
    }

    public ArborDateModel GenerateDate(
        int year,
        int month,
        int day,
        bool slash = false,
        int year2 = 0,
        int month2 = 0,
        int day2 = 0,
        bool slash2 = false,
        DateQuality quality = DateQuality.QUAL_NONE,
        DateModifier modifier = DateModifier.MOD_NONE,
        DateCalendar calendar = DateCalendar.CAL_GREGORIAN,
        DateNewYear newYear = DateNewYear.NEWYEAR_JAN1,
        string? text = null
    )
    {
        if (newYear != DateNewYear.NEWYEAR_JAN1 && CalendarHasFixedNewYear(calendar))
        {
            throw new DateException($"May not adjust newyear to {newYear} for calendar {calendar}");
        }

        ArborDateModel result = new ArborDateModel();

        result.Year = year;
        result.Month = month;
        result.Day = day;
        result.SlashDate1 = slash;
        result.SlashDate2 = slash2;
        result.Year2 = year2;
        result.Month2 = month2;
        result.Day2 = day2;
        result.Calendar = calendar;
        result.Modifier = modifier;
        result.Quality = quality;
        result.NewYear = newYear;
        result.Text = text;

        CalculateSortValue(result);

        if (result.SlashDate1 && result.Calendar != DateCalendar.CAL_JULIAN)
        {
            result.Calendar = DateCalendar.CAL_JULIAN;
            CalculateSortValue(result);
        }

        int year_delta = AdjustNewYear(result);

        if (result.Modifier != DateModifier.MOD_TEXTONLY) { }

        return null;
    }

    private void CalculateSortValue(ArborDateModel dateModel)
    {
        (int, int, int) date = ZeroAdjust(dateModel.Year, dateModel.Month, dateModel.Day);

        if (date.Item1 == 0 && date.Item2 == 0 && date.Item3 == 0)
            dateModel.SortValue = 0;
        else
        {
            dateModel.SortValue = _serialDayNumberCalulator.CalculateSdn(date, dateModel.Calendar);
        }
    }

    private bool CalendarHasFixedNewYear(DateCalendar calendar)
    {
        if (
            calendar == DateCalendar.CAL_GREGORIAN
            || calendar == DateCalendar.CAL_JULIAN
            || calendar == DateCalendar.CAL_SWEDISH
        )
            return false;

        return true;
    }

    private (int, int, int) ZeroAdjust(int year, int month, int day)
    {
        year = year == 0 ? 1 : year;
        month = Math.Max(month, 1);
        day = Math.Max(day, 1);

        return (year, month, day);
    }

    private int AdjustNewYear(ArborDateModel dateModel)
    {
        DateNewYear nyear = dateModel.NewYear;
        int year_delta = 0;
        int split_month = 0;
        int split_day = 0;
        if (nyear == DateNewYear.NEWYEAR_MAR1)
        {
            split_month = 3;
            split_day = 1;
        }
        else if (nyear == DateNewYear.NEWYEAR_MAR25)
        {
            split_month = 3;
            split_day = 25;
        }
        else if (nyear == DateNewYear.NEWYEAR_SEP1)
        {
            split_month = 9;
            split_day = 1;
        }

        if (split_month != 0 && split_day != 0)
        {
            if (IsLargerThanOrEqual((dateModel.Month, dateModel.Day), (split_month, split_day)))
            {
                year_delta = -1;
                ArborDateModel newDate = new ArborDateModel
                {
                    Year = dateModel.Year + year_delta,
                    Month = dateModel.Month,
                    Day = dateModel.Day,
                    Calendar = dateModel.Calendar
                };
                CalculateSortValue(newDate);
                dateModel.SortValue = newDate.SortValue;
            }
        }

        return year_delta;
    }

    private bool IsLargerThanOrEqual((int, int) t1, (int, int) t2)
    {
        if (t1.Item1 > t2.Item1)
            return true;
        if (t1.Item1 == t2.Item1 && t1.Item2 >= t2.Item2)
            return true;
        return false;
    }
}
