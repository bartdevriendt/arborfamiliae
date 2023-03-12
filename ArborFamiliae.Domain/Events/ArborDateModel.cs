using System;

namespace ArborFamiliae.Domain.Events;

#region Enums
public enum DateModifier
{
    MOD_NONE = 0,
    MOD_BEFORE = 1,
    MOD_AFTER = 2,
    MOD_ABOUT = 3,
    MOD_RANGE = 4,
    MOD_SPAN = 5,
    MOD_TEXTONLY = 6
}

public enum DateQuality
{
    QUAL_NONE = 0,
    QUAL_ESTIMATED = 1,
    QUAL_CALCULATED = 2
}

public enum DateCalendar
{
    CAL_GREGORIAN = 0,
    CAL_JULIAN = 1,
    CAL_HEBREW = 2,
    CAL_FRENCH = 3,
    CAL_PERSIAN = 4,
    CAL_ISLAMIC = 5,
    CAL_SWEDISH = 6
}

public enum DateNewYear
{
    NEWYEAR_JAN1 = 0,
    NEWYEAR_MAR1 = 1,
    NEWYEAR_MAR25 = 2,
    NEWYEAR_SEP1 = 3
}

#endregion

public class ArborDateModel
{
    public DateCalendar Calendar { get; set; }
    public DateModifier Modifier { get; set; }
    public DateQuality Quality { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public bool SlashDate1 { get; set; }
    public int Year2 { get; set; }
    public int Month2 { get; set; }
    public int Day2 { get; set; }
    public bool SlashDate2 { get; set; }

    public string? Text { get; set; }
    public int SortValue { get; set; }
    public DateNewYear NewYear { get; set; }

    public bool IsCompound => Modifier is DateModifier.MOD_SPAN or DateModifier.MOD_RANGE;
    public bool IsReguler => Modifier == DateModifier.MOD_NONE && Quality == DateQuality.QUAL_NONE;
    public bool IsYearValid => IsLowItemValid(Year);
    public bool IsMonthValid => IsLowItemValid(Month);
    public bool IsDayValid => IsLowItemValid(Day);

    private bool IsLowItemValid(int item)
    {
        if (Modifier == DateModifier.MOD_TEXTONLY)
            return false;
        return item != 0;
    }

    #region Constructors

    public ArborDateModel()
    {
        SetEmpty();
    }

    public ArborDateModel(ArborDateModel source)
    {
        Calendar = source.Calendar;
        Modifier = source.Modifier;
        Quality = source.Quality;
        Year = source.Year;
        Month = source.Month;
        Day = source.Day;
        SlashDate1 = source.SlashDate1;
        Year2 = source.Year2;
        Month2 = source.Month2;
        Day2 = source.Day2;
        SlashDate2 = source.SlashDate2;
        Text = source.Text;
        NewYear = source.NewYear;
        SortValue = source.SortValue;
    }

    public ArborDateModel((int Year, int Month, int Day, bool Slash) source)
    {
        SetEmpty();
        SetYearMonthDay((source.Year, source.Month, source.Day, source.Slash, 0, 0, 0, false));
    }

    public ArborDateModel(
        (
            int Year,
            int Month,
            int Day,
            bool Slash,
            int Year2,
            int Month2,
            int Day2,
            bool Slash2
        ) source
    )
    {
        SetEmpty();
        SetYearMonthDay(source);
    }

    #endregion



    #region Public methods

    public void SetYearMonthDay(
        (
            int Year,
            int Month,
            int Day,
            bool Slash,
            int Year2,
            int Month2,
            int Day2,
            bool Slash2
        ) source,
        bool removeStopDate = false
    )
    {
        SetYearMonthDayInternal(source.Year, source.Month, source.Day);
        if (removeStopDate && IsCompound)
        {
            SetYearMonthDayInternal(source.Year, source.Month, source.Day, false);
        }
    }

    #endregion

    #region Helper methods

    private void SetEmpty()
    {
        Year = 0;
        Month = 0;
        Day = 0;
        SlashDate1 = false;
        Year2 = 0;
        Month2 = 0;
        Day2 = 0;
        SlashDate2 = false;
        Calendar = DateCalendar.CAL_GREGORIAN;
        Modifier = DateModifier.MOD_NONE;
        Quality = DateQuality.QUAL_NONE;
        Text = "";
        SortValue = 0;
        NewYear = DateNewYear.NEWYEAR_JAN1;
    }

    private void SetYearMonthDayInternal(int year, int month, int day, bool isLower = true)
    {
        if (isLower)
        {
            Year = year;
            Month = month;
            Day = day;
        }
        else
        {
            Year2 = year;
            Month2 = month;
            Day2 = day;
        }
    }

    private (int, int, int) ZeroAdjust(int year, int month, int day)
    {
        year = year == 0 ? 1 : year;
        month = Math.Max(month, 1);
        day = Math.Max(day, 1);

        return (year, month, day);
    }

    #endregion


    public string ConvertToDisplay()
    {
        return $"{Year}-{Month}-{Day}";
    }
}
