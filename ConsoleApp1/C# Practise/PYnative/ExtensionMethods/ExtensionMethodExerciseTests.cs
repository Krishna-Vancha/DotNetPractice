using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.ExtensionMethods;

public static class ExtensionMethodExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 20; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative - Extension Methods Exercises (20)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_ToPascalCase(),
        2 => Test02_IsEvenOrOdd(),
        3 => Test03_WordCount(),
        4 => Test04_ToPercentage(),
        5 => Test05_IsWeekend(),
        6 => Test06_Truncate(),
        7 => Test07_IsEmpty(),
        8 => Test08_Shuffle(),
        9 => Test09_RemoveDuplicates(),
        10 => Test10_TakeRandom(),
        11 => Test11_Age(),
        12 => Test12_IsValidEmail(),
        13 => Test13_JoinStrings(),
        14 => Test14_JsonRoundTrip(),
        15 => Test15_In(),
        16 => Test16_GetOrAdd(),
        17 => Test17_InnermostException(),
        18 => Test18_Page(),
        19 => Test19_GetDescription(),
        20 => Test20_Pipe(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Extension method exercises are numbered 1-20.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_ToPascalCase() =>
        PynativeExerciseRunner.Run(1, "Convert a String to PascalCase",
            "Write an extension method for string that converts a space-separated or snake_case string into PascalCase.",
            t => t.Add(("text = \"hello_world\" -> HelloWorld", () =>
                PynativeExerciseRunner.AssertEqual("HelloWorld",
                    () => "hello_world".ToPascalCase()))));

    public static PynativeExerciseRunner.SuiteResult Test02_IsEvenOrOdd() =>
        PynativeExerciseRunner.Run(2, "Check if a Number Is Even or Odd",
            "Create two extension methods for int that return whether the number is even or odd.",
            t => t.Add(("number = 4 -> Is Even = True, Is Odd = False", () =>
            {
                PynativeExerciseRunner.AssertTrue(() => 4.IsEven());
                PynativeExerciseRunner.AssertFalse(() => 4.IsOdd());
            })));

    public static PynativeExerciseRunner.SuiteResult Test03_WordCount() =>
        PynativeExerciseRunner.Run(3, "Count Words in a Sentence",
            "Extend string to count the number of words in a sentence, ignoring extra spaces.",
            t => t.Add(("sentence = \" Coding is fun \" -> Word Count = 3", () =>
                PynativeExerciseRunner.AssertEqual(3,
                    () => " Coding is fun ".WordCount()))));

    public static PynativeExerciseRunner.SuiteResult Test04_ToPercentage() =>
        PynativeExerciseRunner.Run(4, "Format a Decimal as a Percentage",
            "Create a method for double that formats a decimal fraction as a percentage string with a specified number of decimal places.",
            t => t.Add(("fraction = 0.856, decimalPlaces = 1 -> 85.6%", () =>
                PynativeExerciseRunner.AssertEqual("85.6%",
                    () => 0.856.ToPercentage(1)))));

    public static PynativeExerciseRunner.SuiteResult Test05_IsWeekend() =>
        PynativeExerciseRunner.Run(5, "Check if a Date Falls on a Weekend",
            "Extend DateTime to check if a given date falls on a Saturday or Sunday.",
            t => t.Add(("January 1, 2000 (Saturday) -> Is Weekend = True", () =>
                PynativeExerciseRunner.AssertTrue(
                    () => new DateTime(2000, 1, 1).IsWeekend()))));

    public static PynativeExerciseRunner.SuiteResult Test06_Truncate() =>
        PynativeExerciseRunner.Run(6, "Truncate a Long String",
            "Write a method for string that cuts off text at a maximum length and appends \"...\" if it exceeds that length.",
            t => t.Add(("text = \"Long text here\", maxLength = 7 -> Long te...", () =>
                PynativeExerciseRunner.AssertEqual("Long te...",
                    () => "Long text here".Truncate(7)))));

    public static PynativeExerciseRunner.SuiteResult Test07_IsEmpty() =>
        PynativeExerciseRunner.Run(7, "Check if a Collection Is Empty",
            "Write a method to check if an enumerable is empty, as a readable alternative to !collection.Any().",
            t => t.Add(("empty List<int> -> Is Empty = True", () =>
                PynativeExerciseRunner.AssertTrue(
                    () => new List<int>().IsEmpty()))));

    public static PynativeExerciseRunner.SuiteResult Test08_Shuffle() =>
        PynativeExerciseRunner.Run(8, "Shuffle a Collection Randomly",
            "Randomly shuffle any IEnumerable<T> into a new sequence. The sample order 4, 1, 5, 2, 3 is only an example.",
            t => t.Add(("numbers = 1, 2, 3, 4, 5 -> same items, original unchanged", () =>
            {
                var original = new List<int> { 1, 2, 3, 4, 5 };
                List<int> shuffled = original.Shuffle().ToList();
                PynativeExerciseRunner.PrintOutput(string.Join(", ", shuffled));
                PynativeExerciseRunner.AssertEqualSilent(5, shuffled.Count);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 1, 2, 3, 4, 5 }, original);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 1, 2, 3, 4, 5 }, shuffled.OrderBy(n => n));
            })));

    public static PynativeExerciseRunner.SuiteResult Test09_RemoveDuplicates() =>
        PynativeExerciseRunner.Run(9, "Remove Duplicate Items from a List",
            "Extend IList<T> to remove duplicate elements from the collection in place.",
            t => t.Add(("1, 2, 2, 3, 4, 4, 5 -> 1, 2, 3, 4, 5", () =>
            {
                var numbers = new List<int> { 1, 2, 2, 3, 4, 4, 5 };
                numbers.RemoveDuplicates();
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 1, 2, 3, 4, 5 }, numbers);
            })));

    public static PynativeExerciseRunner.SuiteResult Test10_TakeRandom() =>
        PynativeExerciseRunner.Run(10, "Take Random Elements from a Collection",
            "Return a specified number of random elements. The sample Cherry, Apple, Elderberry is only an example.",
            t => t.Add(("5 fruits, count = 3 -> 3 items from the source", () =>
            {
                string[] items = { "Apple", "Banana", "Cherry", "Date", "Elderberry" };
                List<string> picked = items.TakeRandom(3).ToList();
                PynativeExerciseRunner.PrintOutput(string.Join(", ", picked));
                PynativeExerciseRunner.AssertEqualSilent(3, picked.Count);
                PynativeExerciseRunner.AssertEqualSilent(3, picked.Distinct().Count());
                PynativeExerciseRunner.AssertTrue(() => picked.All(items.Contains));
            })));

    public static PynativeExerciseRunner.SuiteResult Test11_Age() =>
        PynativeExerciseRunner.Run(11, "Calculate Age from a Birthdate",
            "Extend DateTime to calculate a person's age in years as of today. The published sample showed Age = 25.",
            t => t.Add(("birthDate = July 20, 2000 -> age as of today", () =>
                PynativeExerciseRunner.AssertEqual(ExpectedAge(new DateTime(2000, 7, 20)),
                    () => new DateTime(2000, 7, 20).Age()))));

    public static PynativeExerciseRunner.SuiteResult Test12_IsValidEmail() =>
        PynativeExerciseRunner.Run(12, "Validate an Email Address",
            "Create a method that uses Regex to validate whether a string is a properly formatted email address.",
            t => t.Add(("email = \"test@test.com\" -> Is Valid Email = True", () =>
                PynativeExerciseRunner.AssertTrue(
                    () => "test@test.com".IsValidEmail()))));

    public static PynativeExerciseRunner.SuiteResult Test13_JoinStrings() =>
        PynativeExerciseRunner.Run(13, "Join a Collection of Strings",
            "Extend IEnumerable<string> to join elements into a single string with a custom separator.",
            t => t.Add(("letters A, B separator \", \" -> A, B", () =>
                PynativeExerciseRunner.AssertEqual("A, B",
                    () => new[] { "A", "B" }.JoinStrings(", ")))));

    public static PynativeExerciseRunner.SuiteResult Test14_JsonRoundTrip() =>
        PynativeExerciseRunner.Run(14, "Serialize and Deserialize an Object to JSON",
            "Serialize any object to JSON and deserialize a JSON string back into an object using System.Text.Json.",
            t => t.Add(("Person Alice, 30 -> {\"Name\":\"Alice\",\"Age\":30}", () =>
            {
                var person = new ExtensionPerson { Name = "Alice", Age = 30 };
                string json = person.ToJson();
                PynativeExerciseRunner.PrintOutput(json);
                PynativeExerciseRunner.AssertEqualSilent("{\"Name\":\"Alice\",\"Age\":30}", json);
                ExtensionPerson restored = json.FromJson<ExtensionPerson>();
                PynativeExerciseRunner.AssertEqualSilent("Alice", restored.Name);
                PynativeExerciseRunner.AssertEqualSilent(30, restored.Age);
            })));

    public static PynativeExerciseRunner.SuiteResult Test15_In() =>
        PynativeExerciseRunner.Run(15, "Check if a Value Is in a List of Values",
            "Write a generic In<T> extension that checks if an item exists within a params list of values.",
            t => t.Add(("Pending in Active, Pending -> Is In List = True", () =>
                PynativeExerciseRunner.AssertTrue(
                    () => ExtensionStatus.Pending.In(ExtensionStatus.Active, ExtensionStatus.Pending)))));

    public static PynativeExerciseRunner.SuiteResult Test16_GetOrAdd() =>
        PynativeExerciseRunner.Run(16, "Get or Add a Value in a Dictionary",
            "If a key is missing, evaluate a factory, add the result to the dictionary, and return it.",
            t => t.Add(("empty dictionary, key \"count\", factory 42", () =>
            {
                var counts = new Dictionary<string, int>();
                int result = counts.GetOrAdd("count", () => 42);
                PynativeExerciseRunner.PrintOutput($"Result = {result}");
                PynativeExerciseRunner.AssertEqualSilent(42, result);
                PynativeExerciseRunner.AssertTrue(() => counts.ContainsKey("count"));
                PynativeExerciseRunner.AssertEqualSilent(42, counts["count"]);
            })));

    public static PynativeExerciseRunner.SuiteResult Test17_InnermostException() =>
        PynativeExerciseRunner.Run(17, "Find the Root Cause of an Exception",
            "Recursively walk an Exception's InnerException chain and return the root cause.",
            t => t.Add(("three wrapped exceptions -> Innermost Message = Root cause failure", () =>
            {
                var root = new InvalidOperationException("Root cause failure");
                var middle = new InvalidOperationException("Middle failure", root);
                var outer = new InvalidOperationException("Outer failure", middle);
                PynativeExerciseRunner.AssertEqual("Root cause failure",
                    () => outer.GetInnermostException().Message);
            })));

    public static PynativeExerciseRunner.SuiteResult Test18_Page() =>
        PynativeExerciseRunner.Run(18, "Paginate a Queryable Collection",
            "Page an IQueryable<T> with pageNumber and pageSize using Skip and Take.",
            t => t.Add(("numbers 1..20, page 2, size 5 -> 6, 7, 8, 9, 10", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 6, 7, 8, 9, 10 },
                    () => Enumerable.Range(1, 20).AsQueryable().Page(2, 5)))));

    public static PynativeExerciseRunner.SuiteResult Test19_GetDescription() =>
        PynativeExerciseRunner.Run(19, "Read a Description Attribute from an Enum",
            "Read the string from a [Description] attribute on an enum member.",
            t => t.Add(("ExtensionOrderStatus.Shipped -> Order Shipped", () =>
                PynativeExerciseRunner.AssertEqual("Order Shipped",
                    () => ExtensionOrderStatus.Shipped.GetDescription()))));

    public static PynativeExerciseRunner.SuiteResult Test20_Pipe() =>
        PynativeExerciseRunner.Run(20, "Chain Function Calls with Pipe",
            "Create a Pipe extension that passes the object into a function so calls can be chained.",
            t => t.Add(("5.Pipe(x => x * 2).Pipe(x => x.ToString()) -> 10", () =>
                PynativeExerciseRunner.AssertEqual("10",
                    () => 5.Pipe(x => x * 2).Pipe(x => x.ToString())))));

    private static int ExpectedAge(DateTime birthDate)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age))
            age--;
        return age;
    }
}
