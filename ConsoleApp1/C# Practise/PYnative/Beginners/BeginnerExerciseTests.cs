using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.Beginners;

public static class BeginnerExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 58; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative - Beginners Exercises (58)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_GreetUser(),
        2 => Test02_SumTwoNumbers(),
        3 => Test03_BasicArithmetic(),
        4 => Test04_CelsiusToFahrenheit(),
        5 => Test05_AverageOfThree(),
        6 => Test06_Remainder(),
        7 => Test07_ConvertDays(),
        8 => Test08_EvenOrOdd(),
        9 => Test09_SwapNumbers(),
        10 => Test10_SimpleInterest(),
        11 => Test11_MaximumOfThree(),
        12 => Test12_IsLeapYear(),
        13 => Test13_ToUppercase(),
        14 => Test14_CountCharacters(),
        15 => Test15_PrintCountToTen(),
        16 => Test16_PrintCountdown(),
        17 => Test17_PrintMultiplicationTable(),
        18 => Test18_SumFromOneTo(),
        19 => Test19_Factorial(),
        20 => Test20_PrintEvenNumbersTo50(),
        21 => Test21_PrintArray(),
        22 => Test22_FindMinMax(),
        23 => Test23_PrintReversed(),
        24 => Test24_SumArray(),
        25 => Test25_FindIndex(),
        26 => Test26_CountAddedItems(),
        27 => Test27_RemoveDuplicates(),
        28 => Test28_ReverseString(),
        29 => Test29_IsPrime(),
        30 => Test30_CreateCar(),
        31 => Test31_Drive(),
        32 => Test32_CreateBook(),
        33 => Test33_BankBalanceAfter(),
        34 => Test34_DogSound(),
        35 => Test35_DistanceFromOrigin(),
        36 => Test36_CreateColor(),
        37 => Test37_ProductsAreEqual(),
        38 => Test38_UpdateGrade(),
        39 => Test39_RunGroceryList(),
        40 => Test40_LookupPhone(),
        41 => Test41_RegisterStudentIds(),
        42 => Test42_ProcessEditorActions(),
        43 => Test43_ServeCustomers(),
        44 => Test44_PrintSortedInventory(),
        45 => Test45_PrintPrices(),
        46 => Test46_ContainsThenClear(),
        47 => Test47_FilterEvenNumbers(),
        48 => Test48_TopScoresAbove(),
        49 => Test49_ToUppercaseCities(),
        50 => Test50_PriceStatistics(),
        51 => Test51_FirstNameStartingWith(),
        52 => Test52_FormatCurrentTime(),
        53 => Test53_AgeInDaysMessage(),
        54 => Test54_FutureDateMessage(),
        55 => Test55_DaysInMonthMessage(),
        56 => Test56_SaveDiaryEntry(),
        57 => Test57_AppendLogEntry(),
        58 => Test58_ReadDiary(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Beginner exercises are numbered 1-58.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_GreetUser() =>
        PynativeExerciseRunner.Run(1, "User Greeting",
            "Accept a user's name and print a personalized greeting.",
            t => t.Add(("Alice -> Hello, Alice! Welcome.", () =>
                PynativeExerciseRunner.AssertEqual("Hello, Alice! Welcome.",
                    () => BeginnerExercises.GreetUser("Alice")))));

    public static PynativeExerciseRunner.SuiteResult Test02_SumTwoNumbers() =>
        PynativeExerciseRunner.Run(2, "Sum of Two Numbers",
            "Add two integers and print the sum.",
            t => t.Add(("15 + 27 -> 42", () =>
                PynativeExerciseRunner.AssertEqual(42,
                    () => BeginnerExercises.SumTwoNumbers(15, 27)))));

    public static PynativeExerciseRunner.SuiteResult Test03_BasicArithmetic() =>
        PynativeExerciseRunner.Run(3, "Basic Calculator",
            "Display the sum, difference, product, and quotient of two numbers.",
            t => t.Add(("20 and 4 -> 24, 16, 80, 5", () =>
            {
                var (sum, difference, product, quotient) = BeginnerExercises.BasicArithmetic(20, 4);
                PynativeExerciseRunner.PrintOutput($"Sum={sum}, Difference={difference}, Product={product}, Quotient={quotient}");
                PynativeExerciseRunner.AssertEqualSilent(24, sum);
                PynativeExerciseRunner.AssertEqualSilent(16, difference);
                PynativeExerciseRunner.AssertEqualSilent(80, product);
                PynativeExerciseRunner.AssertEqualSilent(5, quotient);
            })));

    public static PynativeExerciseRunner.SuiteResult Test04_CelsiusToFahrenheit() =>
        PynativeExerciseRunner.Run(4, "Temperature Converter",
            "Convert a temperature from Celsius to Fahrenheit.",
            t => t.Add(("25 C -> 77 F", () =>
                PynativeExerciseRunner.AssertEqual(77d,
                    () => Math.Round(BeginnerExercises.CelsiusToFahrenheit(25), 2)))));

    public static PynativeExerciseRunner.SuiteResult Test05_AverageOfThree() =>
        PynativeExerciseRunner.Run(5, "Average Calculator",
            "Print the average of three decimal numbers.",
            t => t.Add(("10.5, 20.3, 15.2 -> 15.33", () =>
                PynativeExerciseRunner.AssertEqual(15.33,
                    () => Math.Round(BeginnerExercises.AverageOfThree(10.5, 20.3, 15.2), 2)))));

    public static PynativeExerciseRunner.SuiteResult Test06_Remainder() =>
        PynativeExerciseRunner.Run(6, "Remainder Finder",
            "Display the remainder of dividing two integers.",
            t => t.Add(("17 % 5 -> 2", () =>
                PynativeExerciseRunner.AssertEqual(2,
                    () => BeginnerExercises.Remainder(17, 5)))));

    public static PynativeExerciseRunner.SuiteResult Test07_ConvertDays() =>
        PynativeExerciseRunner.Run(7, "Days to Years/Weeks",
            "Convert a number of days into years, weeks, and remaining days.",
            t => t.Add(("400 days -> 1 year, 5 weeks, 0 days", () =>
            {
                var (years, weeks, remainingDays) = BeginnerExercises.ConvertDays(400);
                PynativeExerciseRunner.PrintOutput($"Years={years}, Weeks={weeks}, Remaining Days={remainingDays}");
                PynativeExerciseRunner.AssertEqualSilent(1, years);
                PynativeExerciseRunner.AssertEqualSilent(5, weeks);
                PynativeExerciseRunner.AssertEqualSilent(0, remainingDays);
            })));

    public static PynativeExerciseRunner.SuiteResult Test08_EvenOrOdd() =>
        PynativeExerciseRunner.Run(8, "Even or Odd",
            "Check if a given integer is even or odd.",
            t =>
            {
                t.Add(("7 -> 7 is Odd", () =>
                    PynativeExerciseRunner.AssertEqual("7 is Odd",
                        () => BeginnerExercises.EvenOrOdd(7))));
                t.Add(("8 -> 8 is Even", () =>
                    PynativeExerciseRunner.AssertEqual("8 is Even",
                        () => BeginnerExercises.EvenOrOdd(8))));
            });

    public static PynativeExerciseRunner.SuiteResult Test09_SwapNumbers() =>
        PynativeExerciseRunner.Run(9, "Swap Two Numbers",
            "Swap two integers using a temporary variable.",
            t => t.Add(("5, 10 -> 10, 5", () =>
            {
                var (first, second) = BeginnerExercises.SwapNumbers(5, 10);
                PynativeExerciseRunner.PrintOutput($"first={first}, second={second}");
                PynativeExerciseRunner.AssertEqualSilent(10, first);
                PynativeExerciseRunner.AssertEqualSilent(5, second);
            })));

    public static PynativeExerciseRunner.SuiteResult Test10_SimpleInterest() =>
        PynativeExerciseRunner.Run(10, "Simple Interest Calculator",
            "Calculate simple interest from principal, rate, and time.",
            t => t.Add(("1000 at 5% for 2 years -> 100", () =>
                PynativeExerciseRunner.AssertEqual(100d,
                    () => Math.Round(BeginnerExercises.SimpleInterest(1000, 5, 2), 2)))));

    public static PynativeExerciseRunner.SuiteResult Test11_MaximumOfThree() =>
        PynativeExerciseRunner.Run(11, "Find the Maximum",
            "Determine which of three numbers is the largest.",
            t => t.Add(("12, 45, 30 -> 45", () =>
                PynativeExerciseRunner.AssertEqual(45,
                    () => BeginnerExercises.MaximumOfThree(12, 45, 30)))));

    public static PynativeExerciseRunner.SuiteResult Test12_IsLeapYear() =>
        PynativeExerciseRunner.Run(12, "Leap Year Checker",
            "Check whether a year is a leap year.",
            t =>
            {
                t.Add(("2024 -> leap year", () =>
                    PynativeExerciseRunner.AssertTrue(() => BeginnerExercises.IsLeapYear(2024))));
                t.Add(("2023 -> not a leap year", () =>
                    PynativeExerciseRunner.AssertFalse(() => BeginnerExercises.IsLeapYear(2023))));
            });

    public static PynativeExerciseRunner.SuiteResult Test13_ToUppercase() =>
        PynativeExerciseRunner.Run(13, "Uppercase Converter",
            "Convert a lowercase string to uppercase.",
            t => t.Add(("hello world -> HELLO WORLD", () =>
                PynativeExerciseRunner.AssertEqual("HELLO WORLD",
                    () => BeginnerExercises.ToUppercase("hello world")))));

    public static PynativeExerciseRunner.SuiteResult Test14_CountCharacters() =>
        PynativeExerciseRunner.Run(14, "Count Characters",
            "Count how many characters a string contains.",
            t => t.Add(("Programming -> 11", () =>
                PynativeExerciseRunner.AssertEqual(11,
                    () => BeginnerExercises.CountCharacters("Programming")))));

    public static PynativeExerciseRunner.SuiteResult Test15_PrintCountToTen() =>
        PynativeExerciseRunner.Run(15, "Count to Ten",
            "Print numbers from 1 to 10 using a for loop.",
            t => t.Add(("1 to 10", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    Enumerable.Range(1, 10).Select(i => i.ToString()),
                    () => PynativeConsole.CaptureLines(() => BeginnerExercises.PrintCountToTen())))));

    public static PynativeExerciseRunner.SuiteResult Test16_PrintCountdown() =>
        PynativeExerciseRunner.Run(16, "Countdown",
            "Print numbers from 10 down to 1 using a while loop.",
            t => t.Add(("10 down to 1", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    Enumerable.Range(0, 10).Select(i => (10 - i).ToString()),
                    () => PynativeConsole.CaptureLines(() => BeginnerExercises.PrintCountdown())))));

    public static PynativeExerciseRunner.SuiteResult Test17_PrintMultiplicationTable() =>
        PynativeExerciseRunner.Run(17, "Multiplication Table",
            "Display the multiplication table up to 10 for a given number.",
            t => t.Add(("number = 5", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    Enumerable.Range(1, 10).Select(i => $"5 x {i} = {5 * i}"),
                    () => PynativeConsole.CaptureLines(() => BeginnerExercises.PrintMultiplicationTable(5))))));

    public static PynativeExerciseRunner.SuiteResult Test18_SumFromOneTo() =>
        PynativeExerciseRunner.Run(18, "Sum of N Numbers",
            "Calculate the sum of all integers from 1 to N.",
            t => t.Add(("n = 10 -> 55", () =>
                PynativeExerciseRunner.AssertEqual(55,
                    () => BeginnerExercises.SumFromOneTo(10)))));

    public static PynativeExerciseRunner.SuiteResult Test19_Factorial() =>
        PynativeExerciseRunner.Run(19, "Factorial Calculator",
            "Compute the factorial of a positive integer.",
            t => t.Add(("5! -> 120", () =>
                PynativeExerciseRunner.AssertEqual(120L,
                    () => BeginnerExercises.Factorial(5)))));

    public static PynativeExerciseRunner.SuiteResult Test20_PrintEvenNumbersTo50() =>
        PynativeExerciseRunner.Run(20, "Even Numbers Only",
            "Print all even numbers between 1 and 50.",
            t => t.Add(("2, 4, ... 50", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    Enumerable.Range(1, 25).Select(i => (i * 2).ToString()),
                    () => PynativeConsole.CaptureLines(() => BeginnerExercises.PrintEvenNumbersTo50())))));

    public static PynativeExerciseRunner.SuiteResult Test21_PrintArray() =>
        PynativeExerciseRunner.Run(21, "Array Initialization",
            "Print each element of a 5-integer array.",
            t => t.Add(("[10, 20, 30, 40, 50]", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "10", "20", "30", "40", "50" },
                    () => PynativeConsole.CaptureLines(() =>
                        BeginnerExercises.PrintArray(new[] { 10, 20, 30, 40, 50 }))))));

    public static PynativeExerciseRunner.SuiteResult Test22_FindMinMax() =>
        PynativeExerciseRunner.Run(22, "Find Min/Max in Array",
            "Find the smallest and largest values in an array.",
            t => t.Add(("[12, 45, 3, 67, 21] -> min 3, max 67", () =>
            {
                var (minimum, maximum) = BeginnerExercises.FindMinMax(new[] { 12, 45, 3, 67, 21 });
                PynativeExerciseRunner.PrintOutput($"Minimum={minimum}, Maximum={maximum}");
                PynativeExerciseRunner.AssertEqualSilent(3, minimum);
                PynativeExerciseRunner.AssertEqualSilent(67, maximum);
            })));

    public static PynativeExerciseRunner.SuiteResult Test23_PrintReversed() =>
        PynativeExerciseRunner.Run(23, "Array Reverser",
            "Print an array of strings in reverse order.",
            t => t.Add(("Apple..Elderberry reversed", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Elderberry", "Date", "Cherry", "Banana", "Apple" },
                    () => PynativeConsole.CaptureLines(() => BeginnerExercises.PrintReversed(
                        new[] { "Apple", "Banana", "Cherry", "Date", "Elderberry" }))))));

    public static PynativeExerciseRunner.SuiteResult Test24_SumArray() =>
        PynativeExerciseRunner.Run(24, "Sum of Array Elements",
            "Sum all the elements inside a double array.",
            t => t.Add(("[10.5, 20.3, 5.2, 8.0] -> 44", () =>
                PynativeExerciseRunner.AssertEqual(44d,
                    () => Math.Round(BeginnerExercises.SumArray(new[] { 10.5, 20.3, 5.2, 8.0 }), 2)))));

    public static PynativeExerciseRunner.SuiteResult Test25_FindIndex() =>
        PynativeExerciseRunner.Run(25, "Search an Element",
            "Return the index of a number inside a predefined array.",
            t =>
            {
                t.Add(("16 -> index 3", () =>
                    PynativeExerciseRunner.AssertEqual(3,
                        () => BeginnerExercises.FindIndex(new[] { 4, 8, 15, 16, 23, 42 }, 16))));
                t.Add(("42 -> index 5", () =>
                    PynativeExerciseRunner.AssertEqual(5,
                        () => BeginnerExercises.FindIndex(new[] { 4, 8, 15, 16, 23, 42 }, 42))));
            });

    public static PynativeExerciseRunner.SuiteResult Test26_CountAddedItems() =>
        PynativeExerciseRunner.Run(26, "Dynamic Integer List",
            "Add numbers to a list and return how many items it contains.",
            t => t.Add(("10, 20, 30, 40, 50 -> 5", () =>
                PynativeExerciseRunner.AssertEqual(5,
                    () => BeginnerExercises.CountAddedItems(new[] { 10, 20, 30, 40, 50 })))));

    public static PynativeExerciseRunner.SuiteResult Test27_RemoveDuplicates() =>
        PynativeExerciseRunner.Run(27, "Remove Duplicates",
            "Filter a list so only unique numbers remain.",
            t => t.Add(("[1, 2, 2, 3, 4, 4, 5] -> 1, 2, 3, 4, 5", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4, 5 },
                    () => BeginnerExercises.RemoveDuplicates(new[] { 1, 2, 2, 3, 4, 4, 5 })))));

    public static PynativeExerciseRunner.SuiteResult Test28_ReverseString() =>
        PynativeExerciseRunner.Run(28, "String Reverser",
            "Return a string completely reversed.",
            t => t.Add(("Hello -> olleH", () =>
                PynativeExerciseRunner.AssertEqual("olleH",
                    () => BeginnerExercises.ReverseString("Hello")))));

    public static PynativeExerciseRunner.SuiteResult Test29_IsPrime() =>
        PynativeExerciseRunner.Run(29, "Is Prime Function",
            "Return true if a number is prime and false otherwise.",
            t =>
            {
                t.Add(("17 -> true", () =>
                    PynativeExerciseRunner.AssertTrue(() => BeginnerExercises.IsPrime(17))));
                t.Add(("4 -> false", () =>
                    PynativeExerciseRunner.AssertFalse(() => BeginnerExercises.IsPrime(4))));
            });

    public static PynativeExerciseRunner.SuiteResult Test30_CreateCar() =>
        PynativeExerciseRunner.Run(30, "Create a Car Class",
            "Create a car with Make, Model, and Year and expose those details.",
            t => t.Add(("Toyota Corolla 2022", () =>
            {
                BeginnerCar car = BeginnerExercises.CreateCar("Toyota", "Corolla", 2022);
                PynativeExerciseRunner.PrintOutput($"{car.Make}, {car.Model}, {car.Year}");
                PynativeExerciseRunner.AssertEqualSilent("Toyota", car.Make);
                PynativeExerciseRunner.AssertEqualSilent("Corolla", car.Model);
                PynativeExerciseRunner.AssertEqualSilent(2022, car.Year);
            })));

    public static PynativeExerciseRunner.SuiteResult Test31_Drive() =>
        PynativeExerciseRunner.Run(31, "Class Methods",
            "Return a drive message for a car make and model.",
            t => t.Add(("Toyota Corolla -> The Toyota Corolla is driving!", () =>
                PynativeExerciseRunner.AssertEqual("The Toyota Corolla is driving!",
                    () => BeginnerExercises.Drive("Toyota", "Corolla")))));

    public static PynativeExerciseRunner.SuiteResult Test32_CreateBook() =>
        PynativeExerciseRunner.Run(32, "Constructors",
            "Create a book by setting Title and Author in the constructor.",
            t => t.Add(("1984, George Orwell", () =>
            {
                BeginnerBook book = BeginnerExercises.CreateBook("1984", "George Orwell");
                PynativeExerciseRunner.PrintOutput($"Title: {book.Title}, Author: {book.Author}");
                PynativeExerciseRunner.AssertEqualSilent("1984", book.Title);
                PynativeExerciseRunner.AssertEqualSilent("George Orwell", book.Author);
            })));

    public static PynativeExerciseRunner.SuiteResult Test33_BankBalanceAfter() =>
        PynativeExerciseRunner.Run(33, "Bank Account Encapsulation",
            "Deposit and withdraw through a bank account and return the balance.",
            t => t.Add(("deposit 500, withdraw 200 -> 300", () =>
                PynativeExerciseRunner.AssertEqual(300m,
                    () => BeginnerExercises.BankBalanceAfter(500, 200)))));

    public static PynativeExerciseRunner.SuiteResult Test34_DogSound() =>
        PynativeExerciseRunner.Run(34, "Basic Inheritance",
            "Return Bark! from a Dog that overrides Animal.MakeSound.",
            t => t.Add(("Dog -> Bark!", () =>
                PynativeExerciseRunner.AssertEqual("Bark!",
                    () => BeginnerExercises.DogSound()))));

    public static PynativeExerciseRunner.SuiteResult Test35_DistanceFromOrigin() =>
        PynativeExerciseRunner.Run(35, "The Point Struct",
            "Calculate the distance of a point from the origin.",
            t => t.Add(("X = 3, Y = 4 -> 5", () =>
                PynativeExerciseRunner.AssertEqual(5d,
                    () => Math.Round(BeginnerExercises.DistanceFromOrigin(3, 4), 2)))));

    public static PynativeExerciseRunner.SuiteResult Test36_CreateColor() =>
        PynativeExerciseRunner.Run(36, "Immutable Color Struct",
            "Create an immutable color from red, green, and blue values.",
            t => t.Add(("255, 0, 0", () =>
            {
                BeginnerColor color = BeginnerExercises.CreateColor(255, 0, 0);
                PynativeExerciseRunner.PrintOutput($"R: {color.R}, G: {color.G}, B: {color.B}");
                PynativeExerciseRunner.AssertEqualSilent(255, color.R);
                PynativeExerciseRunner.AssertEqualSilent(0, color.G);
                PynativeExerciseRunner.AssertEqualSilent(0, color.B);
            })));

    public static PynativeExerciseRunner.SuiteResult Test37_ProductsAreEqual() =>
        PynativeExerciseRunner.Run(37, "Product Record",
            "Show that two identical product records compare equal by value.",
            t =>
            {
                t.Add(("Book 15.99 == Book 15.99 -> true", () =>
                    PynativeExerciseRunner.AssertTrue(() => BeginnerExercises.ProductsAreEqual(
                        new BeginnerProduct("Book", 15.99m),
                        new BeginnerProduct("Book", 15.99m)))));
                t.Add(("Book 15.99 == Book 9.99 -> false", () =>
                    PynativeExerciseRunner.AssertFalse(() => BeginnerExercises.ProductsAreEqual(
                        new BeginnerProduct("Book", 15.99m),
                        new BeginnerProduct("Book", 9.99m)))));
            });

    public static PynativeExerciseRunner.SuiteResult Test38_UpdateGrade() =>
        PynativeExerciseRunner.Run(38, "Updating Records (with Expression)",
            "Copy a student record and update the grade.",
            t => t.Add(("Alice grade B -> A", () =>
            {
                var original = new BeginnerStudent("Alice", "B");
                BeginnerStudent updated = BeginnerExercises.UpdateGrade(original, "A");
                PynativeExerciseRunner.PrintOutput($"Name: {updated.Name}, Grade: {updated.Grade}");
                PynativeExerciseRunner.AssertEqualSilent("B", original.Grade);
                PynativeExerciseRunner.AssertEqualSilent("Alice", updated.Name);
                PynativeExerciseRunner.AssertEqualSilent("A", updated.Grade);
            })));

    public static PynativeExerciseRunner.SuiteResult Test39_RunGroceryList() =>
        PynativeExerciseRunner.Run(39, "Dynamic Grocery List (List)",
            "Add, remove, and view items in a grocery list.",
            t => t.Add(("add Milk, add Bread, remove Milk, view", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Grocery List:", "- Bread" },
                    () => PynativeConsole.CaptureLines(() => BeginnerExercises.RunGroceryList(new (int Choice, string Item)[]
                    {
                        (1, "Milk"),
                        (1, "Bread"),
                        (2, "Milk"),
                        (3, ""),
                        (4, ""),
                    }))))));

    public static PynativeExerciseRunner.SuiteResult Test40_LookupPhone() =>
        PynativeExerciseRunner.Run(40, "Contact Directory (Dictionary<TKey, TValue>)",
            "Look up a phone number by name in a dictionary.",
            t => t.Add(("Alice -> 555-1234", () =>
                PynativeExerciseRunner.AssertEqual("Alice's number: 555-1234",
                    () => BeginnerExercises.LookupPhone(new Dictionary<string, string>
                    {
                        ["Alice"] = "555-1234",
                        ["Bob"] = "555-5678",
                    }, "Alice")))));

    public static PynativeExerciseRunner.SuiteResult Test41_RegisterStudentIds() =>
        PynativeExerciseRunner.Run(41, "Unique Registration (HashSet)",
            "Register student ids and reject duplicates.",
            t => t.Add(("[101, 102, 101, 103]", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "101 registered successfully.",
                        "102 registered successfully.",
                        "101 is already registered.",
                        "103 registered successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() =>
                        BeginnerExercises.RegisterStudentIds(new[] { 101, 102, 101, 103 }))))));

    public static PynativeExerciseRunner.SuiteResult Test42_ProcessEditorActions() =>
        PynativeExerciseRunner.Run(42, "Undo Mechanism (Stack)",
            "Push typed words and pop the last word when the action is undo.",
            t => t.Add(("Hello, World, undo", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Typed: Hello",
                        "Typed: World",
                        "Undo: removed \"World\"",
                        "Remaining words:",
                        "Hello",
                    },
                    () => PynativeConsole.CaptureLines(() =>
                        BeginnerExercises.ProcessEditorActions(new[] { "Hello", "World", "undo" }))))));

    public static PynativeExerciseRunner.SuiteResult Test43_ServeCustomers() =>
        PynativeExerciseRunner.Run(43, "Customer Service Line (Queue)",
            "Enqueue customers, then dequeue them one by one.",
            t => t.Add(("Alice, Bob, Charlie", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Serving: Alice", "Serving: Bob", "Serving: Charlie" },
                    () => PynativeConsole.CaptureLines(() =>
                        BeginnerExercises.ServeCustomers(new[] { "Alice", "Bob", "Charlie" }))))));

    public static PynativeExerciseRunner.SuiteResult Test44_PrintSortedInventory() =>
        PynativeExerciseRunner.Run(44, "Sorted Inventory (SortedList<TKey, TValue>)",
            "Display products sorted by item code.",
            t => t.Add(("B002, A001, C003 sorted by code", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "A001: Widget", "B002: Gadget", "C003: Gizmo" },
                    () => PynativeConsole.CaptureLines(() => BeginnerExercises.PrintSortedInventory(new (string Code, string Name)[]
                    {
                        ("B002", "Gadget"),
                        ("A001", "Widget"),
                        ("C003", "Gizmo"),
                    }))))));

    public static PynativeExerciseRunner.SuiteResult Test45_PrintPrices() =>
        PynativeExerciseRunner.Run(45, "Key-Value Iteration",
            "Print each product as Product: {name} costs ${price}.",
            t => t.Add(("Laptop, Mouse, Keyboard", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Product: Laptop costs $999.99",
                        "Product: Mouse costs $25.5",
                        "Product: Keyboard costs $45",
                    },
                    () => PynativeConsole.CaptureLines(() => BeginnerExercises.PrintPrices(new Dictionary<string, double>
                    {
                        ["Laptop"] = 999.99,
                        ["Mouse"] = 25.50,
                        ["Keyboard"] = 45.00,
                    }))))));

    public static PynativeExerciseRunner.SuiteResult Test46_ContainsThenClear() =>
        PynativeExerciseRunner.Run(46, "Collection Clearing & Checking",
            "Check whether a list contains an item, then clear the list.",
            t => t.Add(("contains Notebook, then count 0", () =>
            {
                var (contains, countAfterClear) = BeginnerExercises.ContainsThenClear(
                    new[] { "Pen", "Notebook", "Eraser" }, "Notebook");
                PynativeExerciseRunner.PrintOutput($"Contains={contains}, Count={countAfterClear}");
                PynativeExerciseRunner.AssertEqualSilent(true, contains);
                PynativeExerciseRunner.AssertEqualSilent(0, countAfterClear);
            })));

    public static PynativeExerciseRunner.SuiteResult Test47_FilterEvenNumbers() =>
        PynativeExerciseRunner.Run(47, "Filtering Even Numbers",
            "Filter a list of integers from 1 to 20 down to the even numbers.",
            t => t.Add(("1 to 20 -> evens", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    Enumerable.Range(1, 10).Select(i => i * 2),
                    () => BeginnerExercises.FilterEvenNumbers(Enumerable.Range(1, 20))))));

    public static PynativeExerciseRunner.SuiteResult Test48_TopScoresAbove() =>
        PynativeExerciseRunner.Run(48, "Top Scorers",
            "Keep scores greater than 80 and sort them descending.",
            t => t.Add(("[75, 88, 92, 60, 85] -> 92, 88, 85", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 92, 88, 85 },
                    () => BeginnerExercises.TopScoresAbove(new[] { 75, 88, 92, 60, 85 }, 80)))));

    public static PynativeExerciseRunner.SuiteResult Test49_ToUppercaseCities() =>
        PynativeExerciseRunner.Run(49, "String Transformation (.Select())",
            "Transform city names into uppercase.",
            t => t.Add(("london, paris, tokyo", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "LONDON", "PARIS", "TOKYO" },
                    () => BeginnerExercises.ToUppercaseCities(new[] { "london", "paris", "tokyo" })))));

    public static PynativeExerciseRunner.SuiteResult Test50_PriceStatistics() =>
        PynativeExerciseRunner.Run(50, "Aggregation (Min, Max, Average)",
            "Return the sum, average, minimum, and maximum of item prices.",
            t => t.Add(("[19.99, 5.49, 42.00, 12.75]", () =>
            {
                var (sum, average, min, max) = BeginnerExercises.PriceStatistics(
                    new[] { 19.99m, 5.49m, 42.00m, 12.75m });
                PynativeExerciseRunner.PrintOutput($"Sum={sum}, Average={average}, Min={min}, Max={max}");
                PynativeExerciseRunner.AssertEqualSilent(80.23m, sum);
                PynativeExerciseRunner.AssertEqualSilent(20.0575m, average);
                PynativeExerciseRunner.AssertEqualSilent(5.49m, min);
                PynativeExerciseRunner.AssertEqualSilent(42m, max);
            })));

    public static PynativeExerciseRunner.SuiteResult Test51_FirstNameStartingWith() =>
        PynativeExerciseRunner.Run(51, "Find the First Match",
            "Find the first name that starts with a letter, or report that none exists.",
            t =>
            {
                t.Add(("J -> James", () =>
                    PynativeExerciseRunner.AssertEqual("First match: James",
                        () => BeginnerExercises.FirstNameStartingWith(
                            new[] { "Michael", "Sarah", "James", "Laura" }, 'J'))));
                t.Add(("no J -> not found", () =>
                    PynativeExerciseRunner.AssertEqual("No name starting with 'J' was found.",
                        () => BeginnerExercises.FirstNameStartingWith(
                            new[] { "Michael", "Sarah", "Laura" }, 'J'))));
            });

    public static PynativeExerciseRunner.SuiteResult Test52_FormatCurrentTime() =>
        PynativeExerciseRunner.Run(52, "Digital Clock/Current Time",
            "Format a date and time as MM/dd/yyyy HH:mm:ss.",
            t => t.Add(("2026-07-11 14:32:10", () =>
                PynativeExerciseRunner.AssertEqual("07/11/2026 14:32:10",
                    () => BeginnerExercises.FormatCurrentTime(new DateTime(2026, 7, 11, 14, 32, 10))))));

    public static PynativeExerciseRunner.SuiteResult Test53_AgeInDaysMessage() =>
        PynativeExerciseRunner.Run(53, "Age Calculator",
            "Return how many whole days separate a birth date from a given day.",
            t => t.Add(("1995-06-15 as of 2026-07-11 -> 11349 days", () =>
                PynativeExerciseRunner.AssertEqual("You are 11349 days old.",
                    () => BeginnerExercises.AgeInDaysMessage("1995-06-15", new DateTime(2026, 7, 11))))));

    public static PynativeExerciseRunner.SuiteResult Test54_FutureDateMessage() =>
        PynativeExerciseRunner.Run(54, "Adding/Subtracting Time",
            "Describe the date 45 days after a given day, including the weekday.",
            t => t.Add(("2026-07-11 plus 45 days -> Tuesday 08/25/2026", () =>
                PynativeExerciseRunner.AssertEqual(
                    "45 days from today is 08/25/2026, which falls on a Tuesday.",
                    () => BeginnerExercises.FutureDateMessage(new DateTime(2026, 7, 11), 45)))));

    public static PynativeExerciseRunner.SuiteResult Test55_DaysInMonthMessage() =>
        PynativeExerciseRunner.Run(55, "Days in a Month",
            "Report how many days are in a given month and year.",
            t => t.Add(("February 2024 -> 29 days", () =>
                PynativeExerciseRunner.AssertEqual("February 2024 has 29 days.",
                    () => BeginnerExercises.DaysInMonthMessage(2024, 2)))));

    public static PynativeExerciseRunner.SuiteResult Test56_SaveDiaryEntry() =>
        PynativeExerciseRunner.Run(56, "Diary Entry (Write Text)",
            "Write a sentence to a file and confirm that the diary entry was saved.",
            t => t.Add(("Today was a great day!", () =>
            {
                string path = Path.Combine(Path.GetTempPath(), "pynative-beginner-diary-" + Guid.NewGuid().ToString("N") + ".txt");
                try
                {
                    string[] lines = PynativeConsole.CaptureLines(() =>
                        BeginnerExercises.SaveDiaryEntry(path, "Today was a great day!"));
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "Your diary entry has been saved." }, lines);
                    PynativeExerciseRunner.AssertEqualSilent("Today was a great day!", File.ReadAllText(path));
                }
                finally
                {
                    if (File.Exists(path))
                        File.Delete(path);
                }
            })));

    public static PynativeExerciseRunner.SuiteResult Test57_AppendLogEntry() =>
        PynativeExerciseRunner.Run(57, "Log Append",
            "Append a timestamped log line to a file and print that line.",
            t => t.Add(("2026-07-11 14:32:10", () =>
            {
                string path = Path.Combine(Path.GetTempPath(), "pynative-beginner-log-" + Guid.NewGuid().ToString("N") + ".txt");
                try
                {
                    string[] lines = PynativeConsole.CaptureLines(() =>
                        BeginnerExercises.AppendLogEntry(path, new DateTime(2026, 7, 11, 14, 32, 10)));
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "Log entry added at 07/11/2026 14:32:10" }, lines);
                    PynativeExerciseRunner.AssertTrue(
                        File.ReadAllText(path).Contains("Log entry added at 07/11/2026 14:32:10"));
                }
                finally
                {
                    if (File.Exists(path))
                        File.Delete(path);
                }
            })));

    public static PynativeExerciseRunner.SuiteResult Test58_ReadDiary() =>
        PynativeExerciseRunner.Run(58, "Diary Reader (Read Text)",
            "Read diary.txt when it exists, and say so when it does not.",
            t =>
            {
                t.Add(("file contains Today was a great day!", () =>
                {
                    string path = Path.Combine(Path.GetTempPath(), "pynative-beginner-read-" + Guid.NewGuid().ToString("N") + ".txt");
                    File.WriteAllText(path, "Today was a great day!");
                    try
                    {
                        string[] lines = PynativeConsole.CaptureLines(() => BeginnerExercises.ReadDiary(path));
                        PynativeExerciseRunner.AssertSequenceEqual(
                            new[] { "Diary Entry: Today was a great day!" }, lines);
                    }
                    finally
                    {
                        if (File.Exists(path))
                            File.Delete(path);
                    }
                }));
                t.Add(("missing file", () =>
                {
                    string path = Path.Combine(Path.GetTempPath(), "pynative-beginner-missing-" + Guid.NewGuid().ToString("N") + ".txt");
                    string[] lines = PynativeConsole.CaptureLines(() => BeginnerExercises.ReadDiary(path));
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "No diary entry was found. Write one first." }, lines);
                }));
            });
}
