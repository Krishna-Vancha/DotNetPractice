using System;
using System.Collections.Generic;

namespace ConsoleApp1.C__Practise.PYnative.IndexersOperators;

public static class IndexerOperatorExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 15; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative — Indexers & Operator Overloading Exercises (15)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_LookUpDayOfWeek(),
        2 => Test02_SafeArray(),
        3 => Test03_BitCompact(),
        4 => Test04_SpreadsheetGrid(),
        5 => Test05_EmployeeRegistry(),
        6 => Test06_Vector2D(),
        7 => Test07_Fraction(),
        8 => Test08_Duration(),
        9 => Test09_Money(),
        10 => Test10_SmartString(),
        11 => Test11_MatrixMultiply(),
        12 => Test12_DistanceConversion(),
        13 => Test13_Polynomial(),
        14 => Test14_CriteriaLogic(),
        15 => Test15_Ledger(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Indexers & Operator Overloading exercises are numbered 1-15.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_LookUpDayOfWeek() =>
        PynativeExerciseRunner.Run(1, "Look Up a Day of the Week by Name",
            "Create a Week class with the 7 days and a string indexer so week[\"Monday\"] returns 1 and an invalid name returns -1.",
            t => t.Add(("week[\"Monday\"], week[\"Tuesday\"], week[\"Funday\"] -> 1, 2, -1", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "week[\"Monday\"] = 1",
                        "week[\"Tuesday\"] = 2",
                        "week[\"Funday\"] = -1"
                    },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise01)))));

    public static PynativeExerciseRunner.SuiteResult Test02_SafeArray() =>
        PynativeExerciseRunner.Run(2, "Build a Bounds-Checked Safe Array",
            "Build a SafeArray whose indexer returns 0 for an out-of-bounds get and ignores an out-of-bounds set.",
            t => t.Add(("size 5, array[2] = 42, then index 100 -> 42, 0, 0", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "array[2] = 42",
                        "array[100] = 0",
                        "array[100] after out-of-bounds set = 0"
                    },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise02)))));

    public static PynativeExerciseRunner.SuiteResult Test03_BitCompact() =>
        PynativeExerciseRunner.Run(3, "Access Individual Bits with an Indexer",
            "Create a BitCompact struct wrapping an int. Indexer this[int bitIndex] gets or sets individual bits.",
            t => t.Add(("start at 0, set bit 0 and bit 3 -> value 9", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "bits[0] = True",
                        "bits[1] = False",
                        "bits[3] = True",
                        "Underlying Value = 9"
                    },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise03)))));

    public static PynativeExerciseRunner.SuiteResult Test04_SpreadsheetGrid() =>
        PynativeExerciseRunner.Run(4, "Build a Spreadsheet-Style Grid",
            "Create a Grid with this[int row, int col] and an Excel-style overload this[string column, int row].",
            t => t.Add(("grid[0, 0] = Name, grid[\"A\", 1] = Alice", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "grid[0, 0] = Name",
                        "grid[\"A\", 1] = Alice",
                        "grid[1, 0] via numeric indexer = Alice"
                    },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise04)))));

    public static PynativeExerciseRunner.SuiteResult Test05_EmployeeRegistry() =>
        PynativeExerciseRunner.Run(5, "Find an Employee by Multiple Keys",
            "Create an EmployeeRegistry with indexers that look up an Employee by int ID, name, or email.",
            t => t.Add(("Alice ID 1, Bob ID 2 -> name, email, name", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "registry[1].Name = Alice",
                        "registry[\"Bob\"].Email = bob@example.com",
                        "registry[\"alice@example.com\"].Name = Alice"
                    },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise05)))));

    public static PynativeExerciseRunner.SuiteResult Test06_Vector2D() =>
        PynativeExerciseRunner.Run(6, "Overload Operators for 2D Vector Math",
            "Create a Vector2D struct and overload +, -, and * (scalar double) for vector math.",
            t => t.Add(("a = (2, 3), b = (4, 1) -> sum, difference, scaled", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "a + b = (6, 4)",
                        "a - b = (-2, 2)",
                        $"a * 2.5 = (5, {7.5})"
                    },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise06)))));

    public static PynativeExerciseRunner.SuiteResult Test07_Fraction() =>
        PynativeExerciseRunner.Run(7, "Build a Self-Reducing Fraction Calculator",
            "Create a Fraction class and overload +, -, *, and / so every result is reduced to simplest form.",
            t => t.Add(("1/2, 2/4, 1/3 -> reduced and four operations", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "2/4 reduced automatically = 1/2",
                        "1/2 + 1/3 = 5/6",
                        "1/2 - 1/3 = 1/6",
                        "1/2 * 1/3 = 1/6",
                        "1/2 / 1/3 = 3/2"
                    },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise07)))));

    public static PynativeExerciseRunner.SuiteResult Test08_Duration() =>
        PynativeExerciseRunner.Run(8, "Add and Subtract Time Durations",
            "Create a Duration class (hours and minutes) and overload + and - so extra minutes roll into hours.",
            t => t.Add(("1h 45m + 0h 30m -> 2h 15m", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "1h 45m + 0h 30m = 2h 15m" },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise08)))));

    public static PynativeExerciseRunner.SuiteResult Test09_Money() =>
        PynativeExerciseRunner.Run(9, "Compare Money Values Safely by Currency",
            "Create a Money struct and overload ==, !=, <, and >. Throw when the currencies differ.",
            t => t.Add(("10 USD, 20 USD, 10 EUR -> less, equal, currency error", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "10 USD < 20 USD = True",
                        "10 USD == 10 USD = True",
                        "Error: Cannot compare USD with EUR."
                    },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise09)))));

    public static PynativeExerciseRunner.SuiteResult Test10_SmartString() =>
        PynativeExerciseRunner.Run(10, "Overload the Multiplication Operator for Strings",
            "Create a SmartString class and overload * so new SmartString(\"Hi\") * 3 produces HiHiHi.",
            t => t.Add(("\"Hi\" * 3 -> HiHiHi", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Repeated = HiHiHi" },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise10)))));

    public static PynativeExerciseRunner.SuiteResult Test11_MatrixMultiply() =>
        PynativeExerciseRunner.Run(11, "Multiply Two Matrices with a 2D Indexer",
            "Create a Matrix class with a 2D indexer and overload * for mathematical matrix multiplication.",
            t => t.Add(("[[1, 2], [3, 4]] * [[5, 6], [7, 8]] -> [[19, 22], [43, 50]]", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Result of a * b:",
                        "19 22",
                        "43 50"
                    },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise11)))));

    public static PynativeExerciseRunner.SuiteResult Test12_DistanceConversion() =>
        PynativeExerciseRunner.Run(12, "Convert Between Double and a Custom Distance Type",
            "Create a Distance class with an implicit conversion from double and an explicit conversion to a string like \"1500m\".",
            t => t.Add(("1500.0 meters -> 1500m", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { $"Formatted = {1500.0}m" },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise12)))));

    public static PynativeExerciseRunner.SuiteResult Test13_Polynomial() =>
        PynativeExerciseRunner.Run(13, "Build a Polynomial with an Indexer for Coefficients",
            "Create a Polynomial class with an indexer for coefficients by power and overload + to add like terms.",
            t => t.Add(("3x^2 + 2x + 5 plus 1x^2 + 4 -> 4x^2 + 2x + 9", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "First = 3x^2 + 2x + 5",
                        "Second = 1x^2 + 4",
                        "Sum = 4x^2 + 2x + 9"
                    },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise13)))));

    public static PynativeExerciseRunner.SuiteResult Test14_CriteriaLogic() =>
        PynativeExerciseRunner.Run(14, "Overload & and | for Short-Circuit Boolean Logic",
            "Create a Criteria class and overload &, |, true, and false so && and || short-circuit.",
            t => t.Add(("isAdult true, hasLicense false, isBanned false, hasValidPayment true", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "isAdult & hasLicense = (IsAdult AND HasLicense) = False",
                        "isAdult | hasLicense = (IsAdult OR HasLicense) = True",
                        "Access denied (short-circuited: IsBanned was already false, so HasValidPayment's AND combination was never evaluated)."
                    },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise14)))));

    public static PynativeExerciseRunner.SuiteResult Test15_Ledger() =>
        PynativeExerciseRunner.Run(15, "Combine an Indexer and Operator Overloading in a Ledger",
            "Create a Ledger with a DateTime indexer and overload + so a Transaction can be added with +=.",
            t => t.Add(("+= Transaction(50.00) on DateTime.Today -> amount 50.00", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { $"Transaction on {DateTime.Today:yyyy-MM-dd} = {50.00m}" },
                    () => PynativeConsole.CaptureLines(IndexerOperatorExercises.RunExercise15)))));
}
