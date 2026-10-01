using System;
using System.Collections.Generic;

namespace ConsoleApp1.C__Practise.PYnative.Generics;

public static class GenericExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 20; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative — Generics Exercises (20)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_GenericBox(),
        2 => Test02_SwapArrayElements(),
        3 => Test03_GenericPair(),
        4 => Test04_PrintCollection(),
        5 => Test05_ReverseArray(),
        6 => Test06_MaxFinder(),
        7 => Test07_EntityRepository(),
        8 => Test08_FactoryPattern(),
        9 => Test09_GenericStack(),
        10 => Test10_IdBasedSearch(),
        11 => Test11_NullableStructWrapper(),
        12 => Test12_DoubleConstraintRepository(),
        13 => Test13_GenericValidator(),
        14 => Test14_GenericCache(),
        15 => Test15_TypeConverter(),
        16 => Test16_CovariantLogger(),
        17 => Test17_ContravariantConsumer(),
        18 => Test18_GenericEventBroker(),
        19 => Test19_CustomLinqFilter(),
        20 => Test20_GenericSpecEvaluation(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Generics exercises are numbered 1–20.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_GenericBox() =>
        PynativeExerciseRunner.Run(1, "Generic Box",
            "Store a value in GenBox<T>, update it, and retrieve the result.",
            t =>
            {
                t.Add(("Update(100) -> Retrieve = 100", () =>
                    PynativeExerciseRunner.AssertEqual(100, () =>
                    {
                        var intBox = new GenBox<int>(42);
                        intBox.Update(100);
                        return intBox.Retrieve();
                    })));
            });

    public static PynativeExerciseRunner.SuiteResult Test02_SwapArrayElements() =>
        PynativeExerciseRunner.Run(2, "Swap Array Elements",
            "Swap elements at indices 1 and 3 in an int array.",
            t =>
            {
                t.Add(("[1,2,3,4,5] swap 1,3 -> [1,4,3,2,5]", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(new[] { 1, 4, 3, 2, 5 }, () =>
                    {
                        int[] numbers = { 1, 2, 3, 4, 5 };
                        GenericMethods.Swap(numbers, 1, 3);
                        return numbers;
                    })));
            });

    public static PynativeExerciseRunner.SuiteResult Test03_GenericPair() =>
        PynativeExerciseRunner.Run(3, "Generic Pair",
            "Hold a key and value of different types and format them.",
            t =>
            {
                t.Add(("Age, 25 -> Key = Age, Value = 25", () =>
                    PynativeExerciseRunner.AssertEqual("Key = Age, Value = 25",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            var pair = new GenPair<string, int>("Age", 25);
                            Console.WriteLine($"Key = {pair.Key}, Value = {pair.Value}");
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test04_PrintCollection() =>
        PynativeExerciseRunner.Run(4, "Print Collection",
            "Print each fruit on its own line.",
            t =>
            {
                t.Add(("Apple, Banana, Cherry -> 3 lines", () =>
                    PynativeExerciseRunner.AssertEqual("Apple\nBanana\nCherry",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                            GenericMethods.PrintList(new List<string> { "Apple", "Banana", "Cherry" })))));
            });

    public static PynativeExerciseRunner.SuiteResult Test05_ReverseArray() =>
        PynativeExerciseRunner.Run(5, "Reverse Array",
            "Reverse an int array in place.",
            t =>
            {
                t.Add(("[1,2,3,4,5] -> [5,4,3,2,1]", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(new[] { 5, 4, 3, 2, 1 }, () =>
                    {
                        int[] numbers = { 1, 2, 3, 4, 5 };
                        GenericMethods.Reverse(numbers);
                        return numbers;
                    })));
            });

    public static PynativeExerciseRunner.SuiteResult Test06_MaxFinder() =>
        PynativeExerciseRunner.Run(6, "Max Finder (Comparable Constraint)",
            "Return the larger of two IComparable values.",
            t =>
            {
                t.Add(("FindMax(10,20) and FindMax(apple,banana)", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Max = 20\nMax = banana",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            Console.WriteLine("Max = " + GenericMethods.FindMax(10, 20));
                            Console.WriteLine("Max = " + GenericMethods.FindMax("apple", "banana"));
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test07_EntityRepository() =>
        PynativeExerciseRunner.Run(7, "Entity Repository (Class Constraint)",
            "Add string entities and print each stored item.",
            t =>
            {
                t.Add(("Add Item1, Item2 -> two lines", () =>
                    PynativeExerciseRunner.AssertEqual("Item1\nItem2",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            var repo = new GenRepository<string>();
                            repo.Add("Item1");
                            repo.Add("Item2");
                            foreach (string item in repo.GetAll())
                                Console.WriteLine(item);
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test08_FactoryPattern() =>
        PynativeExerciseRunner.Run(8, "Factory Pattern (New() Constraint)",
            "Create a new instance via GenEntityFactory<T>.",
            t =>
            {
                t.Add(("GenFactoryProduct -> creation message", () =>
                    PynativeExerciseRunner.AssertEqual("New instance created: GenFactoryProduct",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            var factory = new GenEntityFactory<GenFactoryProduct>();
                            var product = factory.CreateInstance();
                            Console.WriteLine("New instance created: " + product.GetType().Name);
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test09_GenericStack() =>
        PynativeExerciseRunner.Run(9, "Generic Stack",
            "Push 10, 20, 30 then peek, pop, and peek again.",
            t =>
            {
                t.Add(("push 10,20,30 -> peek/pop messages", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Peek = 30\nPop = 30\nPeek after pop = 20",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            var stack = new GenCustomStack<int>();
                            stack.Push(10);
                            stack.Push(20);
                            stack.Push(30);
                            Console.WriteLine("Peek = " + stack.Peek());
                            Console.WriteLine("Pop = " + stack.Pop());
                            Console.WriteLine("Peek after pop = " + stack.Peek());
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test10_IdBasedSearch() =>
        PynativeExerciseRunner.Run(10, "ID-Based Search",
            "Find employee with Id 2 using FindById.",
            t =>
            {
                t.Add(("employees id 2 -> Bob", () =>
                    PynativeExerciseRunner.AssertEqual("Found: Id = 2, Name = Bob",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            var employees = new List<GenIdentifiableEmployee>
                            {
                                new() { Id = 1, Name = "Alice" },
                                new() { Id = 2, Name = "Bob" },
                                new() { Id = 3, Name = "Carol" }
                            };
                            var found = GenericMethods.FindById(employees, 2);
                            Console.WriteLine($"Found: Id = {found!.Id}, Name = {found.Name}");
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test11_NullableStructWrapper() =>
        PynativeExerciseRunner.Run(11, "Nullable Struct Wrapper",
            "GenOptional with a value and default empty optional.",
            t =>
            {
                t.Add(("Optional(5) and default", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "HasValue = True, Value = 5\nHasValue = False",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            GenOptional<int> some = new GenOptional<int>(5);
                            GenOptional<int> none = default;
                            Console.WriteLine("HasValue = " + some.HasValue + ", Value = " + some.Value);
                            Console.WriteLine("HasValue = " + none.HasValue);
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test12_DoubleConstraintRepository() =>
        PynativeExerciseRunner.Run(12, "Double Constraint Repository",
            "CreateAndAdd runs Execute and stores the procedure.",
            t =>
            {
                t.Add(("CreateAndAdd -> execute line + count 1", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Executing stored procedure logic.\nTotal procedures stored: 1",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            var repo = new GenProcedureRepository<GenUserProcedure>();
                            repo.CreateAndAdd();
                            Console.WriteLine("Total procedures stored: " + repo.GetAll().Count);
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test13_GenericValidator() =>
        PynativeExerciseRunner.Run(13, "Generic Validator",
            "Validate integers with n > 0 rule.",
            t =>
            {
                t.Add(("10 and -5", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Is 10 valid? True\nIs -5 valid? False",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            var positiveValidator = new GenValidator<int>(n => n > 0);
                            Console.WriteLine("Is 10 valid? " + positiveValidator.Validate(10));
                            Console.WriteLine("Is -5 valid? " + positiveValidator.Validate(-5));
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test14_GenericCache() =>
        PynativeExerciseRunner.Run(14, "Generic Cache",
            "Set greeting Hello; lookup hit and miss.",
            t =>
            {
                t.Add(("greeting Hello + missing key", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Found: Hello\nNot found or expired.",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            var cache = new GenCache<string, string>();
                            cache.Set("greeting", "Hello", TimeSpan.FromSeconds(5));
                            if (cache.TryGet("greeting", out string result))
                                Console.WriteLine("Found: " + result);
                            else
                                Console.WriteLine("Not found or expired.");
                            if (cache.TryGet("unknown", out string missing))
                                Console.WriteLine("Found: " + missing);
                            else
                                Console.WriteLine("Not found or expired.");
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test15_TypeConverter() =>
        PynativeExerciseRunner.Run(15, "Type Converter",
            "Convert string to int; invalid input returns default.",
            t =>
            {
                t.Add(("123->123, abc->0", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Converted = 123\nConverted = 0",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            int good = GenericMethods.ConvertType<string, int>("123");
                            int bad = GenericMethods.ConvertType<string, int>("abc");
                            Console.WriteLine("Converted = " + good);
                            Console.WriteLine("Converted = " + bad);
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test16_CovariantLogger() =>
        PynativeExerciseRunner.Run(16, "Covariant Logger (Out Keyword)",
            "Assign IGenCovLogger<GenCovDog> to IGenCovLogger<GenCovAnimal>.",
            t =>
            {
                t.Add(("dog logger -> Woof!", () =>
                    PynativeExerciseRunner.AssertEqual("Logged animal says: Woof!",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            IGenCovLogger<GenCovDog> dogLogger = new GenCovDogLogger();
                            IGenCovLogger<GenCovAnimal> animalLogger = dogLogger;
                            GenCovAnimal animal = animalLogger.GetLastLogged();
                            Console.WriteLine("Logged animal says: " + animal.Speak());
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test17_ContravariantConsumer() =>
        PynativeExerciseRunner.Run(17, "Contravariant Consumer (In Keyword)",
            "Assign IGenConConsumer<GenConAnimal> to IGenConConsumer<GenConDog>.",
            t =>
            {
                t.Add(("Consume Rex", () =>
                    PynativeExerciseRunner.AssertEqual("Consumed animal: Rex",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            IGenConConsumer<GenConAnimal> animalConsumer = new GenConAnimalConsumer();
                            IGenConConsumer<GenConDog> dogConsumer = animalConsumer;
                            var dog = new GenConDog { Name = "Rex" };
                            dogConsumer.Consume(dog);
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test18_GenericEventBroker() =>
        PynativeExerciseRunner.Run(18, "Generic Event Broker",
            "Two subscribers receive one published message.",
            t =>
            {
                t.Add(("Publish maintenance message", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Subscriber A received: Server is going down for maintenance.\n" +
                        "Subscriber B received: Server is going down for maintenance.",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            var chatEvent = new GenMessageEvent<string>();
                            chatEvent.OnMessage += message =>
                                Console.WriteLine("Subscriber A received: " + message);
                            chatEvent.OnMessage += message =>
                                Console.WriteLine("Subscriber B received: " + message);
                            chatEvent.Publish("Server is going down for maintenance.");
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test19_CustomLinqFilter() =>
        PynativeExerciseRunner.Run(19, "Custom LINQ Filter",
            "Filter extension returns even numbers only.",
            t =>
            {
                t.Add(("evens 2,4,6", () =>
                    PynativeExerciseRunner.AssertEqual("2\n4\n6",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
                            IEnumerable<int> evens = numbers.Filter(n => n % 2 == 0);
                            foreach (int n in evens)
                                Console.WriteLine(n);
                        }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test20_GenericSpecEvaluation() =>
        PynativeExerciseRunner.Run(20, "Generic Spec Evaluation",
            "AndSpecification combines min age 18 and max age 65.",
            t =>
            {
                t.Add(("Age 30 True, Age 15 False", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Age 30 satisfies: True\nAge 15 satisfies: False",
                        () => GenericConsoleHelper.CaptureConsole(() =>
                        {
                            IGenSpecification<int> adultSpec = new GenAndSpecification<int>(
                                new GenMinAgeSpecification(18),
                                new GenMaxAgeSpecification(65));
                            Console.WriteLine("Age 30 satisfies: " + adultSpec.IsSatisfiedBy(30));
                            Console.WriteLine("Age 15 satisfies: " + adultSpec.IsSatisfiedBy(15));
                        }))));
            });
}
