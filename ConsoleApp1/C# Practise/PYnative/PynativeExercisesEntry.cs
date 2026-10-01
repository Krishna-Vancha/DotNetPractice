using ConsoleApp1.C__Practise.PYnative.Arrays;
using ConsoleApp1.C__Practise.PYnative.Beginners;
using ConsoleApp1.C__Practise.PYnative.Collections;
using ConsoleApp1.C__Practise.PYnative.Dates;
using ConsoleApp1.C__Practise.PYnative.DelegatesEvents;
using ConsoleApp1.C__Practise.PYnative.Dictionary;
using ConsoleApp1.C__Practise.PYnative.ExceptionHandling;
using ConsoleApp1.C__Practise.PYnative.ExtensionMethods;
using ConsoleApp1.C__Practise.PYnative.FileHandling;
using ConsoleApp1.C__Practise.PYnative.Generics;
using ConsoleApp1.C__Practise.PYnative.IndexersOperators;
using ConsoleApp1.C__Practise.PYnative.IteratorsYield;
using ConsoleApp1.C__Practise.PYnative.Lambda;
using ConsoleApp1.C__Practise.PYnative.Linq;
using ConsoleApp1.C__Practise.PYnative.Lists;
using ConsoleApp1.C__Practise.PYnative.Loops;
using ConsoleApp1.C__Practise.PYnative.OOP;
using ConsoleApp1.C__Practise.PYnative.PatternMatching;
using ConsoleApp1.C__Practise.PYnative.RandomData;
using ConsoleApp1.C__Practise.PYnative.RegularExpressions;
using ConsoleApp1.C__Practise.PYnative.Strings;
using ConsoleApp1.C__Practise.PYnative.StructsRecordsEnums;

namespace ConsoleApp1.C__Practise.PYnative;

/// <summary>
/// Entry point for PYnative C# exercises — https://pynative.com/csharp-exercises/
/// Switch topic in Practise.Main or pass CLI args: dotnet run -- arrays 5
/// </summary>
public static class PynativeExercisesEntry
{
    private sealed record TopicInfo(string DisplayName, int ExerciseCount, string Url, bool IsReady);

    private static readonly Dictionary<PynativeTopic, TopicInfo> Topics = new()
    {
        [PynativeTopic.Beginners] = new("Beginners", 58, "https://pynative.com/csharp-exercises-for-beginners/", true),
        [PynativeTopic.Loops] = new("Loops", 31, "https://pynative.com/csharp-loops-exercises/", true),
        [PynativeTopic.Arrays] = new("Arrays", 30, "https://pynative.com/csharp-array-exercises/", true),
        [PynativeTopic.Strings] = new("Strings", 30, "https://pynative.com/csharp-string-exercises/", true),
        [PynativeTopic.StructsRecordsEnums] = new("Structs/Records/Enums", 25, "https://pynative.com/csharp-structs-records-and-enums-exercises/", true),
        [PynativeTopic.Oop] = new("OOP", 39, "https://pynative.com/csharp-oop-exercises/", true),
        [PynativeTopic.Collections] = new("Collections", 30, "https://pynative.com/csharp-collections-exercises/", true),
        [PynativeTopic.Lists] = new("Lists", 35, "https://pynative.com/csharp-list-exercises/", true),
        [PynativeTopic.Dictionary] = new("Dictionary", 30, "https://pynative.com/csharp-dictionary-exercises/", true),
        [PynativeTopic.Generics] = new("Generics", 20, "https://pynative.com/csharp-generics-exercises/", true),
        [PynativeTopic.Linq] = new("LINQ", 40, "https://pynative.com/csharp-linq-exercises/", true),
        [PynativeTopic.Lambda] = new("Lambda", 20, "https://pynative.com/csharp-lambda-expressions-exercises/", true),
        [PynativeTopic.DelegatesEvents] = new("Delegates/Events", 21, "https://pynative.com/csharp-delegates-and-events-exercises/", true),
        [PynativeTopic.ExtensionMethods] = new("Extension Methods", 20, "https://pynative.com/csharp-extension-methods-exercises/", true),
        [PynativeTopic.ExceptionHandling] = new("Exception Handling", 17, "https://pynative.com/csharp-exception-handling-exercises/", true),
        [PynativeTopic.FileHandling] = new("File Handling", 30, "https://pynative.com/csharp-file-handling-exercises/", true),
        [PynativeTopic.DateTime] = new("DateTime", 25, "https://pynative.com/csharp-datetime-exercises/", true),
        [PynativeTopic.Regex] = new("Regex", 30, "https://pynative.com/csharp-regex-exercises/", true),
        [PynativeTopic.PatternMatching] = new("Pattern Matching", 19, "https://pynative.com/csharp-pattern-matching-exercises/", true),
        [PynativeTopic.IteratorsYield] = new("Iterators/Yield", 25, "https://pynative.com/csharp-iterators-yield-exercises/", true),
        [PynativeTopic.IndexersOperators] = new("Indexers/Operators", 15, "https://pynative.com/csharp-indexers-operator-overloading-exercises/", true),
        [PynativeTopic.RandomData] = new("Random Data", 20, "https://pynative.com/csharp-random-data-generation-exercises/", true),
    };

    /// <summary>Run one exercise (1-based) or all exercises when exerciseNumber is 0.</summary>
    public static void Run(PynativeTopic topic, int exerciseNumber = 0)
    {
        var info = Topics[topic];
        Console.WriteLine($"PYnative topic: {info.DisplayName} ({info.ExerciseCount} exercises)");
        Console.WriteLine($"Source: {info.Url}");

        if (!info.IsReady)
        {
            Console.WriteLine();
            Console.WriteLine("This topic is not wired up yet in the project.");
            Console.WriteLine("Run PrintTopicCatalog() to see all topics.");
            return;
        }

        if (exerciseNumber == 0)
        {
            RunAll(topic);
            return;
        }

        if (exerciseNumber < 1 || exerciseNumber > info.ExerciseCount)
            throw new ArgumentOutOfRangeException(nameof(exerciseNumber), exerciseNumber,
                $"{info.DisplayName} exercises are numbered 1–{info.ExerciseCount}.");

        RunExercise(topic, exerciseNumber);
    }

    public static void RunFromArgs(string[] args)
    {
        if (args.Length == 0)
        {
            PrintUsage();
            return;
        }

        var command = args[0].Trim().ToLowerInvariant();
        if (command is "catalog" or "list" or "topics" or "help")
        {
            if (command == "help")
                PrintUsage();
            else
                PrintTopicCatalog();
            return;
        }

        var topic = ParseTopic(command);
        int exercise = 0;
        if (args.Length > 1 && !int.TryParse(args[1], out exercise))
            throw new ArgumentException($"Invalid exercise number: {args[1]}");

        Run(topic, exercise);
    }

    public static void PrintTopicCatalog()
    {
        Console.WriteLine("PYnative C# Exercises — https://pynative.com/csharp-exercises/");
        Console.WriteLine(new string('-', 72));
        foreach (var (topic, info) in Topics)
        {
            var status = info.IsReady ? "READY" : "soon";
            Console.WriteLine($"  {info.DisplayName,-22} ({info.ExerciseCount,2})  [{status,-4}]  {TopicAlias(topic)}");
        }
        Console.WriteLine(new string('-', 72));
        Console.WriteLine("Usage: dotnet run -- <topic> [exerciseNumber]");
        Console.WriteLine("Examples:");
        Console.WriteLine("  dotnet run -- strings 13");
        Console.WriteLine("  dotnet run -- arrays 5");
        Console.WriteLine("  dotnet run -- strings     (all string exercises)");
        Console.WriteLine("  dotnet run -- catalog");
    }

    public static void PrintUsage()
    {
        Console.WriteLine("PYnative practice runner");
        Console.WriteLine("  dotnet run -- <topic> [exerciseNumber]");
        Console.WriteLine("  dotnet run -- catalog");
        Console.WriteLine();
        PrintTopicCatalog();
    }

    // ── Backward-compatible shortcuts ─────────────────────────────────────

    public static void RunStrings() => Run(PynativeTopic.Strings, 0);
    public static void RunStringExercise(int number) => Run(PynativeTopic.Strings, number);
    public static void RunArrays() => Run(PynativeTopic.Arrays, 0);
    public static void RunArrayExercise(int number) => Run(PynativeTopic.Arrays, number);
    public static void RunLinq() => Run(PynativeTopic.Linq, 0);
    public static void RunLinqExercise(int number) => Run(PynativeTopic.Linq, number);
    public static void RunOop() => Run(PynativeTopic.Oop, 0);
    public static void RunOopExercise(int number) => Run(PynativeTopic.Oop, number);
    public static void RunGenerics() => Run(PynativeTopic.Generics, 0);
    public static void RunGenericExercise(int number) => Run(PynativeTopic.Generics, number);

    private static void RunAll(PynativeTopic topic)
    {
        switch (topic)
        {
            case PynativeTopic.Beginners: BeginnerExerciseTests.RunAll(); break;
            case PynativeTopic.Loops: LoopExerciseTests.RunAll(); break;
            case PynativeTopic.Arrays: ArrayExerciseTests.RunAll(); break;
            case PynativeTopic.Strings: StringExerciseTests.RunAll(); break;
            case PynativeTopic.StructsRecordsEnums: StructRecordEnumExerciseTests.RunAll(); break;
            case PynativeTopic.Oop: OopExerciseTests.RunAll(); break;
            case PynativeTopic.Collections: CollectionExerciseTests.RunAll(); break;
            case PynativeTopic.Lists: ListExerciseTests.RunAll(); break;
            case PynativeTopic.Dictionary: DictionaryExerciseTests.RunAll(); break;
            case PynativeTopic.Generics: GenericExerciseTests.RunAll(); break;
            case PynativeTopic.Linq: LinqExerciseTests.RunAll(); break;
            case PynativeTopic.Lambda: LambdaExerciseTests.RunAll(); break;
            case PynativeTopic.DelegatesEvents: DelegateEventExerciseTests.RunAll(); break;
            case PynativeTopic.ExtensionMethods: ExtensionMethodExerciseTests.RunAll(); break;
            case PynativeTopic.ExceptionHandling: ExceptionHandlingExerciseTests.RunAll(); break;
            case PynativeTopic.FileHandling: FileHandlingExerciseTests.RunAll(); break;
            case PynativeTopic.DateTime: DateTimeExerciseTests.RunAll(); break;
            case PynativeTopic.Regex: RegexExerciseTests.RunAll(); break;
            case PynativeTopic.PatternMatching: PatternMatchingExerciseTests.RunAll(); break;
            case PynativeTopic.IteratorsYield: IteratorYieldExerciseTests.RunAll(); break;
            case PynativeTopic.IndexersOperators: IndexerOperatorExerciseTests.RunAll(); break;
            case PynativeTopic.RandomData: RandomDataExerciseTests.RunAll(); break;
            default: throw new InvalidOperationException($"Topic {topic} is not ready.");
        }
    }

    private static void RunExercise(PynativeTopic topic, int number)
    {
        switch (topic)
        {
            case PynativeTopic.Beginners: BeginnerExerciseTests.RunExercise(number); break;
            case PynativeTopic.Loops: LoopExerciseTests.RunExercise(number); break;
            case PynativeTopic.Arrays: ArrayExerciseTests.RunExercise(number); break;
            case PynativeTopic.Strings: StringExerciseTests.RunExercise(number); break;
            case PynativeTopic.StructsRecordsEnums: StructRecordEnumExerciseTests.RunExercise(number); break;
            case PynativeTopic.Oop: OopExerciseTests.RunExercise(number); break;
            case PynativeTopic.Collections: CollectionExerciseTests.RunExercise(number); break;
            case PynativeTopic.Lists: ListExerciseTests.RunExercise(number); break;
            case PynativeTopic.Dictionary: DictionaryExerciseTests.RunExercise(number); break;
            case PynativeTopic.Generics: GenericExerciseTests.RunExercise(number); break;
            case PynativeTopic.Linq: LinqExerciseTests.RunExercise(number); break;
            case PynativeTopic.Lambda: LambdaExerciseTests.RunExercise(number); break;
            case PynativeTopic.DelegatesEvents: DelegateEventExerciseTests.RunExercise(number); break;
            case PynativeTopic.ExtensionMethods: ExtensionMethodExerciseTests.RunExercise(number); break;
            case PynativeTopic.ExceptionHandling: ExceptionHandlingExerciseTests.RunExercise(number); break;
            case PynativeTopic.FileHandling: FileHandlingExerciseTests.RunExercise(number); break;
            case PynativeTopic.DateTime: DateTimeExerciseTests.RunExercise(number); break;
            case PynativeTopic.Regex: RegexExerciseTests.RunExercise(number); break;
            case PynativeTopic.PatternMatching: PatternMatchingExerciseTests.RunExercise(number); break;
            case PynativeTopic.IteratorsYield: IteratorYieldExerciseTests.RunExercise(number); break;
            case PynativeTopic.IndexersOperators: IndexerOperatorExerciseTests.RunExercise(number); break;
            case PynativeTopic.RandomData: RandomDataExerciseTests.RunExercise(number); break;
            default: throw new InvalidOperationException($"Topic {topic} is not ready.");
        }
    }

    private static string TopicAlias(PynativeTopic topic) => topic switch
    {
        PynativeTopic.Beginners => "beginners",
        PynativeTopic.Loops => "loops",
        PynativeTopic.Arrays => "arrays",
        PynativeTopic.Strings => "strings",
        PynativeTopic.StructsRecordsEnums => "structs",
        PynativeTopic.Oop => "oop",
        PynativeTopic.Collections => "collections",
        PynativeTopic.Lists => "lists",
        PynativeTopic.Dictionary => "dictionary",
        PynativeTopic.Generics => "generics",
        PynativeTopic.Linq => "linq",
        PynativeTopic.Lambda => "lambda",
        PynativeTopic.DelegatesEvents => "delegates",
        PynativeTopic.ExtensionMethods => "extensions",
        PynativeTopic.ExceptionHandling => "exceptions",
        PynativeTopic.FileHandling => "files",
        PynativeTopic.DateTime => "datetime",
        PynativeTopic.Regex => "regex",
        PynativeTopic.PatternMatching => "patterns",
        PynativeTopic.IteratorsYield => "iterators",
        PynativeTopic.IndexersOperators => "indexers",
        PynativeTopic.RandomData => "random",
        _ => topic.ToString().ToLowerInvariant()
    };

    private static PynativeTopic ParseTopic(string token) => token switch
    {
        "beginners" or "beginner" or "b" => PynativeTopic.Beginners,
        "loops" or "loop" or "l" => PynativeTopic.Loops,
        "arrays" or "array" or "a" => PynativeTopic.Arrays,
        "strings" or "string" or "s" => PynativeTopic.Strings,
        "structs" or "records" or "enums" => PynativeTopic.StructsRecordsEnums,
        "oop" => PynativeTopic.Oop,
        "collections" or "collection" => PynativeTopic.Collections,
        "lists" or "list" => PynativeTopic.Lists,
        "dictionary" or "dict" => PynativeTopic.Dictionary,
        "generics" or "generic" => PynativeTopic.Generics,
        "linq" => PynativeTopic.Linq,
        "lambda" or "lambdas" => PynativeTopic.Lambda,
        "delegates" or "events" or "delegate" => PynativeTopic.DelegatesEvents,
        "extensions" or "extension" => PynativeTopic.ExtensionMethods,
        "exceptions" or "exception" => PynativeTopic.ExceptionHandling,
        "files" or "file" => PynativeTopic.FileHandling,
        "datetime" or "date" => PynativeTopic.DateTime,
        "regex" => PynativeTopic.Regex,
        "patterns" or "pattern" => PynativeTopic.PatternMatching,
        "iterators" or "yield" => PynativeTopic.IteratorsYield,
        "indexers" or "operators" => PynativeTopic.IndexersOperators,
        "random" => PynativeTopic.RandomData,
        _ => throw new ArgumentException($"Unknown topic '{token}'. Run: dotnet run -- catalog")
    };
}
