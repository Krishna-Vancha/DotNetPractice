using System;
using System.Collections.Generic;

namespace ConsoleApp1.C__Practise.PYnative.Dates;

/// <summary>
/// PYnative C# DateTime Exercises — https://pynative.com/csharp-datetime-exercises/
/// </summary>
public static partial class DateTimeExercises
{
    // Question 1: Describe moment with invariant "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd", and the weekday name. Do not call DateTime.Now.
    public static IReadOnlyList<string> DescribeDateTime(DateTime moment)
        => throw new NotImplementedException();

    // Question 2: Format date with invariant MM/dd/yyyy, "dddd, dd MMMM yyyy", and "yyyy-MM-dd HH:mm:ss".
    public static IReadOnlyList<string> FormatCustom(DateTime date)
        => throw new NotImplementedException();

    // Question 3: Return Year, Month, Day, Hour, Minute, Second, and Millisecond as labeled lines.
    public static IReadOnlyList<string> ExtractComponents(DateTime moment)
        => throw new NotImplementedException();

    // Question 4: Return the 1-based day number within the year.
    public static int GetDayOfYear(DateTime date)
        => throw new NotImplementedException();

    // Question 5: Parse dateText with DateTime.Parse and DateTime.TryParse (invariant) and return the three result lines.
    public static IReadOnlyList<string> ParseAndTryParse(string dateText)
        => throw new NotImplementedException();

    // Question 6: From today, return today, the next December 25 (roll to next year if needed), and the whole-day count.
    public static IReadOnlyList<string> DaysUntilChristmas(DateTime today)
        => throw new NotImplementedException();

    // Question 7: Return yesterday, today, and tomorrow as yyyy-MM-dd lines.
    public static IReadOnlyList<string> YesterdayAndTomorrow(DateTime today)
        => throw new NotImplementedException();

    // Question 8: Return the age in full years on today, subtracting one when the birthday has not occurred yet this year.
    public static int CalculateAge(DateTime birthDate, DateTime today)
        => throw new NotImplementedException();

    // Question 9: Return "{first} comes before {second}", "comes after", or "Both dates are identical." using yyyy-MM-dd.
    public static string CompareDates(DateTime firstDate, DateTime secondDate)
        => throw new NotImplementedException();

    // Question 10: Add the given number of business days, skipping Saturday and Sunday.
    public static DateTime AddBusinessDays(DateTime start, int days)
        => throw new NotImplementedException();

    // Question 11: Return whether date.Year is a leap year.
    public static bool IsLeapYear(DateTime date)
        => throw new NotImplementedException();

    // Question 12: Return the first and last calendar day of date's month.
    public static (DateTime FirstDay, DateTime LastDay) GetMonthBounds(DateTime date)
        => throw new NotImplementedException();

    // Question 13: Return the TimeSpan between start and end as total hours, minutes, and seconds.
    public static (double TotalHours, double TotalMinutes, double TotalSeconds) GetDuration(DateTime start, DateTime end)
        => throw new NotImplementedException();

    // Question 14: Return every Friday in the given month.
    public static IReadOnlyList<DateTime> FindFridays(int year, int month)
        => throw new NotImplementedException();

    // Question 15: Treat localTime as local, convert to UTC, then to Eastern Standard Time (America/New_York if that id is missing).
    public static (DateTime Utc, DateTime Eastern) ConvertLocalToUtcAndEastern(DateTime localTime)
        => throw new NotImplementedException();

    // Question 16: Return true when the two inclusive ranges overlap.
    public static bool DoDatesOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        => throw new NotImplementedException();

    // Question 17: Return midnight and 23:59:59.999 on the same calendar day as eventNotice.
    public static (DateTime StartOfDay, DateTime EndOfDay) GetDayBounds(DateTime eventNotice)
        => throw new NotImplementedException();

    // Question 18: Add daysUntilDue, then roll Saturday forward 2 days and Sunday forward 1 day.
    public static DateTime CalculateInvoiceDueDate(DateTime invoiceDate, int daysUntilDue)
        => throw new NotImplementedException();

    // Question 19: Return the next date strictly after start that falls on day.
    public static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        => throw new NotImplementedException();

    // Question 20: Return "Birthday = yyyy-MM-dd" and "Daily Alarm = HH:mm".
    public static IReadOnlyList<string> FormatBirthdayAndAlarm(DateOnly birthday, TimeOnly dailyAlarm)
        => throw new NotImplementedException();

    // Question 21: Time a loop that sums 0 through 9,999,999 and return elapsed milliseconds and ticks.
    public static (double ElapsedMilliseconds, long ElapsedTicks) MeasureSumLoop()
        => throw new NotImplementedException();

    // Question 22: Return the Nth occurrence of day in the given month (1 = first).
    public static DateTime GetNthWeekdayOfMonth(int year, int month, DayOfWeek day, int occurrence)
        => throw new NotImplementedException();

    // Question 23: Convert a UTC DateTime to Unix seconds (seconds since 1970-01-01).
    public static long ToUnixTimestamp(DateTime utcDate)
        => throw new NotImplementedException();

    // Question 23 continued: Convert Unix seconds back to a UTC DateTime.
    public static DateTime FromUnixTimestamp(long unixTimestamp)
        => throw new NotImplementedException();

    // Question 24: ParseExact "dd-yyyy-MM hh:mm tt" with CultureInfo.InvariantCulture.
    public static DateTime ParseExactCustom(string rawDate)
        => throw new NotImplementedException();

    // Question 25: Against Eastern time, return whether skippedHour is invalid and ambiguousHour is ambiguous.
    public static (bool IsInvalid, bool IsAmbiguous) DetectEasternDst(DateTime skippedHour, DateTime ambiguousHour)
        => throw new NotImplementedException();
}
