using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.PatternMatching;

public static class PatternMatchingExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 19; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative - Pattern Matching Exercises (19)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_StatusConverter(),
        2 => Test02_BooleanSimplifier(),
        3 => Test03_DayClassifier(),
        4 => Test04_SafeDowncasting(),
        5 => Test05_UniversalSummer(),
        6 => Test06_CollectionDetector(),
        7 => Test07_EcommerceDiscount(),
        8 => Test08_NestedAddress(),
        9 => Test09_UiElementState(),
        10 => Test10_QuadrantFinder(),
        11 => Test11_LoginValidator(),
        12 => Test12_TrafficLight(),
        13 => Test13_AgeCategorizer(),
        14 => Test14_ValidTemperature(),
        15 => Test15_NullAndEmptyFilter(),
        16 => Test16_ArrayStartChecker(),
        17 => Test17_CsvParserHelper(),
        18 => Test18_SliceAndDice(),
        19 => Test19_MatrixFirstRow(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Pattern matching exercises are numbered 1-19.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_StatusConverter() =>
        PynativeExerciseRunner.Run(1, "The Status Converter",
            "Map an HTTP status code to a friendly message with a switch expression.",
            t =>
            {
                t.Add(("404 -> Not Found", () =>
                    PynativeExerciseRunner.AssertEqual("Not Found", () => PatternMatchingExercises.GetStatusMessage(404))));
                t.Add(("200 -> OK", () =>
                    PynativeExerciseRunner.AssertEqual("OK", () => PatternMatchingExercises.GetStatusMessage(200))));
                t.Add(("500 -> Internal Server Error", () =>
                    PynativeExerciseRunner.AssertEqual("Internal Server Error", () => PatternMatchingExercises.GetStatusMessage(500))));
                t.Add(("201 -> Unknown Status Code", () =>
                    PynativeExerciseRunner.AssertEqual("Unknown Status Code", () => PatternMatchingExercises.GetStatusMessage(201))));
            });

    public static PynativeExerciseRunner.SuiteResult Test02_BooleanSimplifier() =>
        PynativeExerciseRunner.Run(2, "Boolean Simplifier",
            "Return Yes for true, No for false, and Maybe for null.",
            t =>
            {
                t.Add(("null -> Maybe", () =>
                    PynativeExerciseRunner.AssertEqual("Maybe", () => PatternMatchingExercises.SimplifyNullableBool(null))));
                t.Add(("true -> Yes", () =>
                    PynativeExerciseRunner.AssertEqual("Yes", () => PatternMatchingExercises.SimplifyNullableBool(true))));
                t.Add(("false -> No", () =>
                    PynativeExerciseRunner.AssertEqual("No", () => PatternMatchingExercises.SimplifyNullableBool(false))));
            });

    public static PynativeExerciseRunner.SuiteResult Test03_DayClassifier() =>
        PynativeExerciseRunner.Run(3, "Day Classifier",
            "Return Weekend for Saturday and Sunday, otherwise Weekday.",
            t =>
            {
                t.Add(("Saturday -> Weekend", () =>
                    PynativeExerciseRunner.AssertEqual("Weekend", () => PatternMatchingExercises.ClassifyDay(DayOfWeek.Saturday))));
                t.Add(("Sunday -> Weekend", () =>
                    PynativeExerciseRunner.AssertEqual("Weekend", () => PatternMatchingExercises.ClassifyDay(DayOfWeek.Sunday))));
                t.Add(("Wednesday -> Weekday", () =>
                    PynativeExerciseRunner.AssertEqual("Weekday", () => PatternMatchingExercises.ClassifyDay(DayOfWeek.Wednesday))));
            });

    public static PynativeExerciseRunner.SuiteResult Test04_SafeDowncasting() =>
        PynativeExerciseRunner.Run(4, "Safe Downcasting",
            "Describe a PatternCircle with its radius, a PatternRectangle, or an unknown shape.",
            t =>
            {
                t.Add(("Circle(5) -> It's a circle with radius 5", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "It's a circle with radius 5",
                        () => PatternMatchingExercises.DescribeShape(new PatternCircle(5)))));
                t.Add(("Rectangle -> It's a rectangle", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "It's a rectangle",
                        () => PatternMatchingExercises.DescribeShape(new PatternRectangle(2, 3)))));
                t.Add(("string -> Unknown shape", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Unknown shape",
                        () => PatternMatchingExercises.DescribeShape("nope"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test05_UniversalSummer() =>
        PynativeExerciseRunner.Run(5, "Universal Summer",
            "Return an int as-is, parse a numeric string, otherwise return 0.",
            t =>
            {
                t.Add(("42 -> 42", () =>
                    PynativeExerciseRunner.AssertEqual(42, () => PatternMatchingExercises.ToInt(42))));
                t.Add(("\"100\" -> 100", () =>
                    PynativeExerciseRunner.AssertEqual(100, () => PatternMatchingExercises.ToInt("100"))));
                t.Add(("\"abc\" -> 0", () =>
                    PynativeExerciseRunner.AssertEqual(0, () => PatternMatchingExercises.ToInt("abc"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test06_CollectionDetector() =>
        PynativeExerciseRunner.Run(6, "Collection Detector",
            "Identify List<int>, int[], or any other collection type.",
            t =>
            {
                t.Add(("List<int> -> List<int>", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "List<int>",
                        () => PatternMatchingExercises.DescribeCollection(new List<int> { 1, 2, 3 }))));
                t.Add(("int[] -> int array", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "int array",
                        () => PatternMatchingExercises.DescribeCollection(new[] { 1, 2, 3 }))));
                t.Add(("Dictionary -> Other collection type", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Other collection type",
                        () => PatternMatchingExercises.DescribeCollection(new Dictionary<string, int>()))));
            });

    public static PynativeExerciseRunner.SuiteResult Test07_EcommerceDiscount() =>
        PynativeExerciseRunner.Run(7, "E-Commerce Discount",
            "Premium over $100 is 20%, other premium is 10%, everyone else is 0%.",
            t =>
            {
                t.Add(("premium 150 -> Discount = 20%", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Discount = 20%",
                        () => PatternMatchingExercises.GetDiscount(new PatternOrder { TotalPrice = 150, IsPremiumCustomer = true }))));
                t.Add(("premium 80 -> Discount = 10%", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Discount = 10%",
                        () => PatternMatchingExercises.GetDiscount(new PatternOrder { TotalPrice = 80, IsPremiumCustomer = true }))));
                t.Add(("standard 200 -> Discount = 0%", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Discount = 0%",
                        () => PatternMatchingExercises.GetDiscount(new PatternOrder { TotalPrice = 200, IsPremiumCustomer = false }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test08_NestedAddress() =>
        PynativeExerciseRunner.Run(8, "Nested Address Lookup",
            "Report whether Profile.Address.Country is Canada.",
            t =>
            {
                t.Add(("Canada -> User is from Canada", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "User is from Canada",
                        () => PatternMatchingExercises.CheckCountry(UserFrom("Canada")))));
                t.Add(("USA -> User is not from Canada", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "User is not from Canada",
                        () => PatternMatchingExercises.CheckCountry(UserFrom("USA")))));
            });

    public static PynativeExerciseRunner.SuiteResult Test09_UiElementState() =>
        PynativeExerciseRunner.Run(9, "UI Element State",
            "Disabled wins, then hovered (Highlighted), then pressed (Clicked), else Normal.",
            t =>
            {
                t.Add(("enabled, pressed -> Clicked", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Clicked",
                        () => PatternMatchingExercises.GetButtonState(new PatternButton
                        {
                            IsEnabled = true,
                            IsHovered = false,
                            IsPressed = true
                        }))));
                t.Add(("disabled and pressed -> Disabled", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Disabled",
                        () => PatternMatchingExercises.GetButtonState(new PatternButton
                        {
                            IsEnabled = false,
                            IsHovered = true,
                            IsPressed = true
                        }))));
                t.Add(("enabled and hovered -> Highlighted", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Highlighted",
                        () => PatternMatchingExercises.GetButtonState(new PatternButton
                        {
                            IsEnabled = true,
                            IsHovered = true,
                            IsPressed = true
                        }))));
                t.Add(("enabled, idle -> Normal", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Normal",
                        () => PatternMatchingExercises.GetButtonState(new PatternButton
                        {
                            IsEnabled = true,
                            IsHovered = false,
                            IsPressed = false
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test10_QuadrantFinder() =>
        PynativeExerciseRunner.Run(10, "Quadrant Finder",
            "Return Quadrant 1-4 for a PatternPoint, or On an axis when X or Y is 0.",
            t =>
            {
                t.Add(("(3, 4) -> Quadrant 1", () =>
                    PynativeExerciseRunner.AssertEqual("Quadrant 1", () => PatternMatchingExercises.GetQuadrant(new PatternPoint(3, 4)))));
                t.Add(("(-2, 5) -> Quadrant 2", () =>
                    PynativeExerciseRunner.AssertEqual("Quadrant 2", () => PatternMatchingExercises.GetQuadrant(new PatternPoint(-2, 5)))));
                t.Add(("(-2, -5) -> Quadrant 3", () =>
                    PynativeExerciseRunner.AssertEqual("Quadrant 3", () => PatternMatchingExercises.GetQuadrant(new PatternPoint(-2, -5)))));
                t.Add(("(2, -5) -> Quadrant 4", () =>
                    PynativeExerciseRunner.AssertEqual("Quadrant 4", () => PatternMatchingExercises.GetQuadrant(new PatternPoint(2, -5)))));
                t.Add(("(0, 5) -> On an axis", () =>
                    PynativeExerciseRunner.AssertEqual("On an axis", () => PatternMatchingExercises.GetQuadrant(new PatternPoint(0, 5)))));
            });

    public static PynativeExerciseRunner.SuiteResult Test11_LoginValidator() =>
        PynativeExerciseRunner.Run(11, "Login Validator",
            "Return true only for the admin account (\"admin\", \"P@ssw0rd\").",
            t =>
            {
                t.Add(("admin / P@ssw0rd -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => PatternMatchingExercises.ValidateLogin(("admin", "P@ssw0rd")))));
                t.Add(("admin / wrongpass -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => PatternMatchingExercises.ValidateLogin(("admin", "wrongpass")))));
            });

    public static PynativeExerciseRunner.SuiteResult Test12_TrafficLight() =>
        PynativeExerciseRunner.Run(12, "Traffic Light Simulator",
            "Red stays Red while a pedestrian waits, otherwise turns Green. Yellow always becomes Red.",
            t =>
            {
                t.Add(("Red, waiting -> Red", () =>
                    PynativeExerciseRunner.AssertEqual(
                        PatternLightState.Red,
                        () => PatternMatchingExercises.GetNextLightState((PatternLightState.Red, true)))));
                t.Add(("Red, clear -> Green", () =>
                    PynativeExerciseRunner.AssertEqual(
                        PatternLightState.Green,
                        () => PatternMatchingExercises.GetNextLightState((PatternLightState.Red, false)))));
                t.Add(("Green, waiting -> Yellow", () =>
                    PynativeExerciseRunner.AssertEqual(
                        PatternLightState.Yellow,
                        () => PatternMatchingExercises.GetNextLightState((PatternLightState.Green, true)))));
                t.Add(("Green, clear -> Green", () =>
                    PynativeExerciseRunner.AssertEqual(
                        PatternLightState.Green,
                        () => PatternMatchingExercises.GetNextLightState((PatternLightState.Green, false)))));
                t.Add(("Yellow, waiting -> Red", () =>
                    PynativeExerciseRunner.AssertEqual(
                        PatternLightState.Red,
                        () => PatternMatchingExercises.GetNextLightState((PatternLightState.Yellow, true)))));
            });

    public static PynativeExerciseRunner.SuiteResult Test13_AgeCategorizer() =>
        PynativeExerciseRunner.Run(13, "Age Categorizer",
            "Child under 13, Teenager 13-19, Adult 20-64, Senior 65 or older.",
            t =>
            {
                t.Add(("45 -> Adult", () =>
                    PynativeExerciseRunner.AssertEqual("Adult", () => PatternMatchingExercises.CategorizeAge(45))));
                t.Add(("10 -> Child", () =>
                    PynativeExerciseRunner.AssertEqual("Child", () => PatternMatchingExercises.CategorizeAge(10))));
                t.Add(("13 -> Teenager", () =>
                    PynativeExerciseRunner.AssertEqual("Teenager", () => PatternMatchingExercises.CategorizeAge(13))));
                t.Add(("65 -> Senior", () =>
                    PynativeExerciseRunner.AssertEqual("Senior", () => PatternMatchingExercises.CategorizeAge(65))));
            });

    public static PynativeExerciseRunner.SuiteResult Test14_ValidTemperature() =>
        PynativeExerciseRunner.Run(14, "Valid Temperature Check",
            "True when temperature is greater than 0.0 and less than or equal to 100.0.",
            t =>
            {
                t.Add(("37.5 -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => PatternMatchingExercises.IsValidTemperature(37.5))));
                t.Add(("0.0 -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => PatternMatchingExercises.IsValidTemperature(0.0))));
                t.Add(("100.0 -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => PatternMatchingExercises.IsValidTemperature(100.0))));
                t.Add(("100.1 -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => PatternMatchingExercises.IsValidTemperature(100.1))));
            });

    public static PynativeExerciseRunner.SuiteResult Test15_NullAndEmptyFilter() =>
        PynativeExerciseRunner.Run(15, "Null and Empty Filter",
            "True when the value is not null and is not an empty string.",
            t =>
            {
                t.Add(("Hello -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => PatternMatchingExercises.IsNotNullOrEmpty("Hello"))));
                t.Add(("empty string -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => PatternMatchingExercises.IsNotNullOrEmpty(""))));
                t.Add(("null -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => PatternMatchingExercises.IsNotNullOrEmpty(null))));
            });

    public static PynativeExerciseRunner.SuiteResult Test16_ArrayStartChecker() =>
        PynativeExerciseRunner.Run(16, "Array Start Checker",
            "True when the array starts with 1, 2, 3, no matter what follows.",
            t =>
            {
                t.Add(("[1, 2, 3, 4, 5] -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => PatternMatchingExercises.StartsWithOneTwoThree(new[] { 1, 2, 3, 4, 5 }))));
                t.Add(("[1, 2, 3] -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => PatternMatchingExercises.StartsWithOneTwoThree(new[] { 1, 2, 3 }))));
                t.Add(("[9, 2, 3, 4] -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => PatternMatchingExercises.StartsWithOneTwoThree(new[] { 9, 2, 3, 4 }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test17_CsvParserHelper() =>
        PynativeExerciseRunner.Run(17, "CSV Parser Helper",
            "True for a 3-element row whose first cell is ID and last cell is Active.",
            t =>
            {
                t.Add(("[ID, 42, Active] -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() =>
                        PatternMatchingExercises.IsActiveIdRow(new[] { "ID", "42", "Active" }))));
                t.Add(("[ID, 42, Inactive] -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() =>
                        PatternMatchingExercises.IsActiveIdRow(new[] { "ID", "42", "Inactive" }))));
                t.Add(("[ID, Active] -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() =>
                        PatternMatchingExercises.IsActiveIdRow(new[] { "ID", "Active" }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test18_SliceAndDice() =>
        PynativeExerciseRunner.Run(18, "Slice & Dice",
            "True when the array starts with 0, ends with 9, and has at least those two elements.",
            t =>
            {
                t.Add(("[0, 4, 7, 9] -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => PatternMatchingExercises.StartsWithZeroEndsWithNine(new[] { 0, 4, 7, 9 }))));
                t.Add(("[0, 9] -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => PatternMatchingExercises.StartsWithZeroEndsWithNine(new[] { 0, 9 }))));
                t.Add(("[1, 4, 7, 9] -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => PatternMatchingExercises.StartsWithZeroEndsWithNine(new[] { 1, 4, 7, 9 }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test19_MatrixFirstRow() =>
        PynativeExerciseRunner.Run(19, "Matrix Game Matrix",
            "Report a winning line when the first row is X, X, X.",
            t =>
            {
                t.Add(("first row XXX -> First row is a winning line", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "First row is a winning line",
                        () => PatternMatchingExercises.CheckFirstRow(new[]
                        {
                            new[] { 'X', 'X', 'X' },
                            new[] { 'O', 'X', 'O' },
                            new[] { 'O', 'O', 'X' }
                        }))));
                t.Add(("first row XOX -> First row is not a winning line", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "First row is not a winning line",
                        () => PatternMatchingExercises.CheckFirstRow(new[]
                        {
                            new[] { 'X', 'O', 'X' },
                            new[] { 'O', 'X', 'O' },
                            new[] { 'O', 'O', 'X' }
                        }))));
            });

    private static PatternUser UserFrom(string country) =>
        new()
        {
            Profile = new PatternProfile
            {
                Address = new PatternAddress { Country = country }
            }
        };
}
