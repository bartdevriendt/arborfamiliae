using ArborFamiliae.Domain.Events;
using ArborFamiliae.Shared.Interfaces;
using ArborFamiliae.Shared.Services;

namespace ArborFamiliae.Services.Common;

public class DateParserService : IDateParserService
{
    public ArborDateModel? ParseDate(string text)
    {
        ArborDateModel result = new ArborDateModel();

        text = text.Trim();
        result.Text = text;

        var qual = DateQuality.QUAL_NONE;
        var cal = DateCalendar.CAL_GREGORIAN;
        var newyear = DateNewYear.NEWYEAR_JAN1;
        var bc = false;

        // (text, cal, newyear) = MatchCalendarNewYear(text, cal, newyear);
        // (text, newyear) = MatchNewYear(text, newyear);
        // (text, cal) = MatchCalendar(text, cal);
        // (text, qual) = MatchQuality(text, qual);

        // for now only year or year/month/date so do it simple way

        result.Calendar = cal;
        result.NewYear = newyear;

        if (text.Contains("-"))
        {
            string[] parts = text.Split('-');

            if (parts.Length == 3)
            {
                try
                {
                    int year = Convert.ToInt32(parts[0]);
                    int month = Convert.ToInt32(parts[1]);
                    int day = Convert.ToInt32(parts[2]);
                    result.Quality = DateQuality.QUAL_NONE;
                    result.SetYearMonthDay((year, month, day, false, 0, 0, 0, false));
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        else
        {
            if (!String.IsNullOrEmpty(text))
            {
                int year = Convert.ToInt32(text);
                qual = DateQuality.QUAL_ESTIMATED;
                result.Year = year;
            }
            else
            {
                Console.WriteLine("Unknown date: {text}");
            }
        }

        return result;
    }

    // private (string text, DateQuality qual) MatchQuality(string text, DateQuality qual) { }
    //
    // private (string text, DateCalendar cal) MatchCalendar(string text, DateCalendar cal) { }
    //
    // private (string, DateCalendar, DateNewYear) MatchCalendarNewYear(
    //     string text,
    //     DateCalendar calendar,
    //     DateNewYear newYear
    // ) { }
    //
    // private (string, DateNewYear) MatchNewYear(string text, DateNewYear newYear) { }
}
