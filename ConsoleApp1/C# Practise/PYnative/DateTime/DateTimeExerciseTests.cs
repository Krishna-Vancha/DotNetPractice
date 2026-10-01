using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp1.C__Practise.PYnative.Dates;

public static class DateTimeExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 25; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative - DateTime Exercises (25)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_DisplayCurrentDateTime(),
        2 => Test02_FormatCustomString(),
        3 => Test03_ExtractComponents(),
        4 => Test04_DayOfYear(),
        5 => Test05_ParseString(),
        6 => Test06_DaysUntilChristmas(),
        7 => Test07_YesterdayAndTomorrow(),
        8 => Test08_CalculateAge(),
        9 => Test09_CompareDates(),
        10 => Test10_AddBusinessDays(),
        11 => Test11_LeapYear(),
        12 => Test12_MonthBounds(),
        13 => Test13_TimeDifference(),
        14 => Test14_FridaysInMonth(),
        15 => Test15_TimeZoneConversion(),
        16 => Test16_DateRangeOverlap(),
        17 => Test17_StartAndEndOfDay(),
        18 => Test18_InvoiceDueDate(),
        19 => Test19_NextWeekday(),
        20 => Test20_DateOnlyTimeOnly(),
        21 => Test21_Stopwatch(),
        22 => Test22_NthWeekday(),
        23 => Test23_UnixTimestamp(),
        24 => Test24_ParseExact(),
        25 => Test25_DaylightSavingTime(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "DateTime exercises are numbered 1-25.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_DisplayCurrentDateTime() =>
        PynativeExerciseRunner.Run(1, "Display the Current Date and Time",
            "Display a moment's date and time, the date only, and the day of the week. The moment is passed in.",
            t => t.Add(("2026-07-13 10:42:07", () =>
            {
                var moment = new DateTime(2026, 7, 13, 10, 42, 7);
                string stamp = moment.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                string day = moment.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Current Date and Time = " + stamp,
                        "Current Date Only = " + day,
                        "Current Day of Week = " + moment.DayOfWeek
                    },
                    () => DateTimeExercises.DescribeDateTime(moment));
            })));

    public static PynativeExerciseRunner.SuiteResult Test02_FormatCustomString() =>
        PynativeExerciseRunner.Run(2, "Format a Date as a Custom String",
            "Format a date as MM/dd/yyyy, full weekday and month, and yyyy-MM-dd HH:mm:ss using invariant culture.",
            t => t.Add(("October 25, 2026", () =>
            {
                var date = new DateTime(2026, 10, 25);
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "MM/dd/yyyy = " + date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        "Full Format = " + date.ToString("dddd, dd MMMM yyyy", CultureInfo.InvariantCulture),
                        "ISO 8601 = " + date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                    },
                    () => DateTimeExercises.FormatCustom(date));
            })));

    public static PynativeExerciseRunner.SuiteResult Test03_ExtractComponents() =>
        PynativeExerciseRunner.Run(3, "Extract Individual Date and Time Components",
            "Print Year, Month, Day, Hour, Minute, Second, and Millisecond from a DateTime.",
            t => t.Add(("2026-03-15 14:30:45.250", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Year = 2026",
                        "Month = 3",
                        "Day = 15",
                        "Hour = 14",
                        "Minute = 30",
                        "Second = 45",
                        "Millisecond = 250"
                    },
                    () => DateTimeExercises.ExtractComponents(new DateTime(2026, 3, 15, 14, 30, 45, 250))))));

    public static PynativeExerciseRunner.SuiteResult Test04_DayOfYear() =>
        PynativeExerciseRunner.Run(4, "Find the Day Number Within a Year",
            "Return which day of the year a date is. January 1 is 1.",
            t => t.Add(("2026-12-31 -> 365", () =>
                PynativeExerciseRunner.AssertEqual(
                    365,
                    () => DateTimeExercises.GetDayOfYear(new DateTime(2026, 12, 31))))));

    public static PynativeExerciseRunner.SuiteResult Test05_ParseString() =>
        PynativeExerciseRunner.Run(5, "Parse a String into a DateTime",
            "Parse 2026-12-25 with DateTime.Parse and DateTime.TryParse using invariant culture.",
            t => t.Add(("2026-12-25", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Parsed with Parse() = 2026-12-25",
                        "TryParse Succeeded = True",
                        "Parsed with TryParse() = 2026-12-25"
                    },
                    () => DateTimeExercises.ParseAndTryParse("2026-12-25")))));

    public static PynativeExerciseRunner.SuiteResult Test06_DaysUntilChristmas() =>
        PynativeExerciseRunner.Run(6, "Count the Days Until Christmas",
            "Count whole days from today until the next December 25, rolling to next year when needed.",
            t => t.Add(("2026-07-13 -> 165 days", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Today = 2026-07-13",
                        "Next Christmas = 2026-12-25",
                        "Days Until Christmas = 165"
                    },
                    () => DateTimeExercises.DaysUntilChristmas(new DateTime(2026, 7, 13))))));

    public static PynativeExerciseRunner.SuiteResult Test07_YesterdayAndTomorrow() =>
        PynativeExerciseRunner.Run(7, "Calculate Yesterday and Tomorrow",
            "Calculate the dates one day before and one day after today.",
            t => t.Add(("2026-07-13", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Yesterday = 2026-07-12",
                        "Today = 2026-07-13",
                        "Tomorrow = 2026-07-14"
                    },
                    () => DateTimeExercises.YesterdayAndTomorrow(new DateTime(2026, 7, 13))))));

    public static PynativeExerciseRunner.SuiteResult Test08_CalculateAge() =>
        PynativeExerciseRunner.Run(8, "Calculate a Person's Age",
            "Return the age in full years on a given today, accounting for whether the birthday has occurred.",
            t => t.Add(("born 1998-09-05 on 2026-07-13 -> 27", () =>
                PynativeExerciseRunner.AssertEqual(
                    27,
                    () => DateTimeExercises.CalculateAge(new DateTime(1998, 9, 5), new DateTime(2026, 7, 13))))));

    public static PynativeExerciseRunner.SuiteResult Test09_CompareDates() =>
        PynativeExerciseRunner.Run(9, "Compare Two Dates",
            "Report which date comes first, or that the two dates are identical.",
            t =>
            {
                t.Add(("2026-05-10 before 2026-08-22", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "2026-05-10 comes before 2026-08-22",
                        () => DateTimeExercises.CompareDates(new DateTime(2026, 5, 10), new DateTime(2026, 8, 22)))));
                t.Add(("2026-08-22 after 2026-05-10", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "2026-08-22 comes after 2026-05-10",
                        () => DateTimeExercises.CompareDates(new DateTime(2026, 8, 22), new DateTime(2026, 5, 10)))));
                t.Add(("same day -> identical", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Both dates are identical.",
                        () => DateTimeExercises.CompareDates(new DateTime(2026, 5, 10), new DateTime(2026, 5, 10)))));
            });

    public static PynativeExerciseRunner.SuiteResult Test10_AddBusinessDays() =>
        PynativeExerciseRunner.Run(10, "Add Business Days to a Date",
            "Add business days to a start date, skipping Saturdays and Sundays.",
            t => t.Add(("Friday 2026-07-10 plus 5 -> 2026-07-17", () =>
                PynativeExerciseRunner.AssertEqual(
                    new DateTime(2026, 7, 17),
                    () => DateTimeExercises.AddBusinessDays(new DateTime(2026, 7, 10), 5)))));

    public static PynativeExerciseRunner.SuiteResult Test11_LeapYear() =>
        PynativeExerciseRunner.Run(11, "Check if a Year Is a Leap Year",
            "Check whether the year of a DateTime is a leap year.",
            t =>
            {
                t.Add(("2028-06-01 -> true", () =>
                    PynativeExerciseRunner.AssertTrue(
                        () => DateTimeExercises.IsLeapYear(new DateTime(2028, 6, 1)))));
                t.Add(("2026-06-01 -> false", () =>
                    PynativeExerciseRunner.AssertFalse(
                        () => DateTimeExercises.IsLeapYear(new DateTime(2026, 6, 1)))));
            });

    public static PynativeExerciseRunner.SuiteResult Test12_MonthBounds() =>
        PynativeExerciseRunner.Run(12, "Find the First and Last Day of a Month",
            "Return the first day and the last day of the month containing the given date.",
            t => t.Add(("2026-02-17 -> Feb 1 and Feb 28", () =>
                PynativeExerciseRunner.AssertEqual(
                    (new DateTime(2026, 2, 1), new DateTime(2026, 2, 28)),
                    () => DateTimeExercises.GetMonthBounds(new DateTime(2026, 2, 17))))));

    public static PynativeExerciseRunner.SuiteResult Test13_TimeDifference() =>
        PynativeExerciseRunner.Run(13, "Calculate the Time Difference Between Two Dates",
            "Return the duration from start to end as total hours, minutes, and seconds.",
            t => t.Add(("2026-07-10 09:00 to 2026-07-12 17:30 -> 56.5 hours", () =>
                PynativeExerciseRunner.AssertEqual(
                    (56.5, 3390d, 203400d),
                    () =>
                    {
                        var duration = DateTimeExercises.GetDuration(
                            new DateTime(2026, 7, 10, 9, 0, 0),
                            new DateTime(2026, 7, 12, 17, 30, 0));
                        return (
                            Math.Round(duration.TotalHours, 2),
                            Math.Round(duration.TotalMinutes, 2),
                            Math.Round(duration.TotalSeconds, 2));
                    }))));

    public static PynativeExerciseRunner.SuiteResult Test14_FridaysInMonth() =>
        PynativeExerciseRunner.Run(14, "Find All Fridays in a Month",
            "Return every Friday in the given month and year.",
            t => t.Add(("July 2026", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        new DateTime(2026, 7, 3),
                        new DateTime(2026, 7, 10),
                        new DateTime(2026, 7, 17),
                        new DateTime(2026, 7, 24),
                        new DateTime(2026, 7, 31)
                    },
                    () => DateTimeExercises.FindFridays(2026, 7)))));

    public static PynativeExerciseRunner.SuiteResult Test15_TimeZoneConversion() =>
        PynativeExerciseRunner.Run(15, "Convert Between Local Time, UTC, and a Time Zone",
            "Convert a local DateTime to UTC and then to Eastern time. UTC depends on this machine's time zone.",
            t => t.Add(("2026-07-13 15:00 local", () =>
            {
                var local = new DateTime(2026, 7, 13, 15, 0, 0, DateTimeKind.Local);
                var actual = DateTimeExercises.ConvertLocalToUtcAndEastern(local);
                DateTime utc = local.ToUniversalTime();
                TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime eastern = TimeZoneInfo.ConvertTimeFromUtc(utc, zone);
                PynativeExerciseRunner.PrintOutput(
                    $"UTC={actual.Utc.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}, Eastern={actual.Eastern.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}");
                PynativeExerciseRunner.AssertEqualSilent(utc, actual.Utc);
                PynativeExerciseRunner.AssertEqualSilent(eastern, actual.Eastern);
            })));

    public static PynativeExerciseRunner.SuiteResult Test16_DateRangeOverlap() =>
        PynativeExerciseRunner.Run(16, "Check if Two Date Ranges Overlap",
            "Return true when two inclusive date ranges intersect.",
            t =>
            {
                t.Add(("Jul 1-15 overlaps Jul 10-20", () =>
                    PynativeExerciseRunner.AssertTrue(() => DateTimeExercises.DoDatesOverlap(
                        new DateTime(2026, 7, 1),
                        new DateTime(2026, 7, 15),
                        new DateTime(2026, 7, 10),
                        new DateTime(2026, 7, 20)))));
                t.Add(("Jul 1-15 does not overlap Jul 16-20", () =>
                    PynativeExerciseRunner.AssertFalse(() => DateTimeExercises.DoDatesOverlap(
                        new DateTime(2026, 7, 1),
                        new DateTime(2026, 7, 15),
                        new DateTime(2026, 7, 16),
                        new DateTime(2026, 7, 20)))));
            });

    public static PynativeExerciseRunner.SuiteResult Test17_StartAndEndOfDay() =>
        PynativeExerciseRunner.Run(17, "Find the Start and End of a Day",
            "Return 00:00:00.000 and 23:59:59.999 for the calendar day of the given timestamp.",
            t => t.Add(("2026-04-12 14:30:00", () =>
                PynativeExerciseRunner.AssertEqual(
                    (new DateTime(2026, 4, 12, 0, 0, 0, 0), new DateTime(2026, 4, 12, 23, 59, 59, 999)),
                    () => DateTimeExercises.GetDayBounds(new DateTime(2026, 4, 12, 14, 30, 0))))));

    public static PynativeExerciseRunner.SuiteResult Test18_InvoiceDueDate() =>
        PynativeExerciseRunner.Run(18, "Calculate an Invoice Due Date",
            "Add 30 days, then roll a weekend due date forward to Monday.",
            t => t.Add(("2026-07-16 plus 30 -> 2026-08-17", () =>
                PynativeExerciseRunner.AssertEqual(
                    new DateTime(2026, 8, 17),
                    () => DateTimeExercises.CalculateInvoiceDueDate(new DateTime(2026, 7, 16), 30)))));

    public static PynativeExerciseRunner.SuiteResult Test19_NextWeekday() =>
        PynativeExerciseRunner.Run(19, "Find the Next Occurrence of a Weekday",
            "Return the next date strictly after start that falls on the requested weekday.",
            t => t.Add(("Monday 2026-07-13 -> next Tuesday 2026-07-14", () =>
                PynativeExerciseRunner.AssertEqual(
                    new DateTime(2026, 7, 14),
                    () => DateTimeExercises.GetNextWeekday(new DateTime(2026, 7, 13), DayOfWeek.Tuesday)))));

    public static PynativeExerciseRunner.SuiteResult Test20_DateOnlyTimeOnly() =>
        PynativeExerciseRunner.Run(20, "Use DateOnly and TimeOnly Instead of DateTime",
            "Format a DateOnly birthday and a TimeOnly daily alarm.",
            t => t.Add(("1998-09-05 and 07:30", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Birthday = 1998-09-05", "Daily Alarm = 07:30" },
                    () => DateTimeExercises.FormatBirthdayAndAlarm(new DateOnly(1998, 9, 5), new TimeOnly(7, 30))))));

    public static PynativeExerciseRunner.SuiteResult Test21_Stopwatch() =>
        PynativeExerciseRunner.Run(21, "Measure Execution Time with a Stopwatch",
            "Measure a loop that sums 0 through 9,999,999. Elapsed ticks must be positive; milliseconds vary by machine.",
            t => t.Add(("sum loop -> elapsed ticks > 0", () =>
            {
                var (milliseconds, ticks) = DateTimeExercises.MeasureSumLoop();
                PynativeExerciseRunner.PrintOutput($"Elapsed Time = {milliseconds:F2} ms, Elapsed Ticks = {ticks}");
                PynativeExerciseRunner.AssertTrue(ticks > 0 && milliseconds >= 0 && milliseconds < 120000);
            })));

    public static PynativeExerciseRunner.SuiteResult Test22_NthWeekday() =>
        PynativeExerciseRunner.Run(22, "Find the Nth Weekday of a Month",
            "Return the Nth occurrence of a weekday in a month, such as the 2nd Tuesday of October 2026.",
            t => t.Add(("2nd Tuesday of October 2026 -> 2026-10-13", () =>
                PynativeExerciseRunner.AssertEqual(
                    new DateTime(2026, 10, 13),
                    () => DateTimeExercises.GetNthWeekdayOfMonth(2026, 10, DayOfWeek.Tuesday, 2)))));

    public static PynativeExerciseRunner.SuiteResult Test23_UnixTimestamp() =>
        PynativeExerciseRunner.Run(23, "Convert Between DateTime and a Unix Timestamp",
            "Convert a UTC DateTime to Unix seconds and convert those seconds back to UTC.",
            t =>
            {
                var original = new DateTime(2026, 7, 13, 0, 0, 0, DateTimeKind.Utc);
                t.Add(("2026-07-13 00:00:00 UTC -> 1783900800", () =>
                    PynativeExerciseRunner.AssertEqual(1783900800L, () => DateTimeExercises.ToUnixTimestamp(original))));
                t.Add(("1783900800 -> 2026-07-13 00:00:00 UTC", () =>
                    PynativeExerciseRunner.AssertEqual(original, () => DateTimeExercises.FromUnixTimestamp(1783900800L))));
            });

    public static PynativeExerciseRunner.SuiteResult Test24_ParseExact() =>
        PynativeExerciseRunner.Run(24, "Parse a Non-Standard Date Format Exactly",
            "ParseExact the text 25-2026-10 08:30 PM with format dd-yyyy-MM hh:mm tt and invariant culture.",
            t => t.Add(("25-2026-10 08:30 PM -> 2026-10-25 20:30:00", () =>
                PynativeExerciseRunner.AssertEqual(
                    new DateTime(2026, 10, 25, 20, 30, 0),
                    () => DateTimeExercises.ParseExactCustom("25-2026-10 08:30 PM")))));

    public static PynativeExerciseRunner.SuiteResult Test25_DaylightSavingTime() =>
        PynativeExerciseRunner.Run(25, "Detect Daylight Saving Time Gaps and Overlaps",
            "Using Eastern time, detect a skipped spring-forward hour and an ambiguous fall-back hour.",
            t => t.Add(("2026-03-08 02:30 invalid, 2026-11-01 01:30 ambiguous", () =>
                PynativeExerciseRunner.AssertEqual(
                    (true, true),
                    () => DateTimeExercises.DetectEasternDst(
                        new DateTime(2026, 3, 8, 2, 30, 0),
                        new DateTime(2026, 11, 1, 1, 30, 0))))));
}
