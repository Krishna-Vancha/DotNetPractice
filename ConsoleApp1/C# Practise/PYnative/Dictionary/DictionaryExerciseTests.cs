using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.Dictionary;

public static class DictionaryExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 30; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative — Dictionary Exercises (30)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_CountWords(),
        2 => Test02_LookupPhone(),
        3 => Test03_TryAddEmployee(),
        4 => Test04_RemoveBelowPrice(),
        5 => Test05_UpdateGrade(),
        6 => Test06_FormatPopulations(),
        7 => Test07_CountBeforeAndAfterClear(),
        8 => Test08_CheckStock(),
        9 => Test09_ExtractKeysAndValues(),
        10 => Test10_CreateCaseInsensitiveUsers(),
        11 => Test11_Invert(),
        12 => Test12_FilterAbove(),
        13 => Test13_HighestAndLowest(),
        14 => Test14_AverageValue(),
        15 => Test15_GroupByLength(),
        16 => Test16_MergeInventories(),
        17 => Test17_ApplyTax(),
        18 => Test18_SortByValueDescending(),
        19 => Test19_GroupByDepartment(),
        20 => Test20_ToJson(),
        21 => Test21_AverageCourseGrade(),
        22 => Test22_ContainsEquivalentPoint(),
        23 => Test23_BuildParallelCache(),
        24 => Test24_CreateLruCache(),
        25 => Test25_MutualFriends(),
        26 => Test26_Fire(),
        27 => Test27_TopFrequent(),
        28 => Test28_CreateCommandEngine(),
        29 => Test29_CreateSparseMatrix(),
        30 => Test30_CreateContainer(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Dictionary exercises are numbered 1–30.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_CountWords() =>
        PynativeExerciseRunner.Run(1, "Word Counter",
            "Count the frequency of each word in a string using a dictionary.",
            t => t.Add(("the quick brown fox the lazy dog the fox", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "the=3", "quick=1", "brown=1", "fox=2", "lazy=1", "dog=1" },
                    () => DictionaryExercises.CountWords("the quick brown fox the lazy dog the fox")
                        .Select(pair => $"{pair.Key}={pair.Value}")))));

    public static PynativeExerciseRunner.SuiteResult Test02_LookupPhone() =>
        PynativeExerciseRunner.Run(2, "Phonebook Lookup",
            "Add names and phone numbers, then search for a name.",
            t =>
            {
                var phonebook = new Dictionary<string, string>
                {
                    ["Alice"] = "555-1234",
                    ["Bob"] = "555-5678",
                };
                t.Add(("Bob -> Bob's number is 555-5678", () =>
                    PynativeExerciseRunner.AssertEqual("Bob's number is 555-5678",
                        () => DictionaryExercises.LookupPhone(phonebook, "Bob"))));
                t.Add(("Zoe -> not found", () =>
                    PynativeExerciseRunner.AssertEqual("Zoe was not found in the phonebook.",
                        () => DictionaryExercises.LookupPhone(phonebook, "Zoe"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test03_TryAddEmployee() =>
        PynativeExerciseRunner.Run(3, "Unique ID Manager",
            "Add employee ids, and warn instead of throwing when an id already exists.",
            t => t.Add(("1001 Alice, 1002 Bob, duplicate 1001", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Added employee 1001: Alice",
                        "Added employee 1002: Bob",
                        "Warning: Employee ID 1001 already exists.",
                    },
                    () => PynativeConsole.CaptureLines(() =>
                    {
                        var employees = new Dictionary<int, string>();
                        DictionaryExercises.TryAddEmployee(employees, 1001, "Alice");
                        DictionaryExercises.TryAddEmployee(employees, 1002, "Bob");
                        DictionaryExercises.TryAddEmployee(employees, 1001, "Charlie");
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test04_RemoveBelowPrice() =>
        PynativeExerciseRunner.Run(4, "Remove by Value",
            "Remove every product that costs less than $5.00.",
            t => t.Add(("Gum, Soda, Sandwich, Chips, Coffee", () =>
            {
                var remaining = DictionaryExercises.RemoveBelowPrice(new Dictionary<string, double>
                {
                    ["Gum"] = 1.50,
                    ["Soda"] = 2.00,
                    ["Sandwich"] = 6.50,
                    ["Chips"] = 3.25,
                    ["Coffee"] = 5.00,
                }, 5.00);
                PynativeExerciseRunner.PrintOutput(string.Join(", ", remaining.Select(pair => $"{pair.Key}:{pair.Value}")));
                PynativeExerciseRunner.AssertEqualSilent(6.5, remaining["Sandwich"]);
                PynativeExerciseRunner.AssertEqualSilent(5.0, remaining["Coffee"]);
                PynativeExerciseRunner.AssertEqualSilent(2, remaining.Count);
            })));

    public static PynativeExerciseRunner.SuiteResult Test05_UpdateGrade() =>
        PynativeExerciseRunner.Run(5, "Update Grades",
            "Update a student's grade, or add them if they do not exist.",
            t =>
            {
                var grades = new Dictionary<string, string>
                {
                    ["Alice"] = "B",
                    ["Bob"] = "C",
                };
                t.Add(("Alice B -> A", () =>
                    PynativeExerciseRunner.AssertEqual("Updated Alice's grade to A.",
                        () => DictionaryExercises.UpdateGrade(grades, "Alice", "A"))));
                t.Add(("add Charlie with B", () =>
                    PynativeExerciseRunner.AssertEqual("Added Charlie with grade B.",
                        () => DictionaryExercises.UpdateGrade(grades, "Charlie", "B"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test06_FormatPopulations() =>
        PynativeExerciseRunner.Run(6, "Dictionary Iteration",
            "Print each city as \"City: [Name], Population: [Count]\".",
            t => t.Add(("Tokyo, Delhi, Shanghai", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "City: Tokyo, Population: 37400000",
                        "City: Delhi, Population: 30300000",
                        "City: Shanghai, Population: 27058000",
                    },
                    () => DictionaryExercises.FormatPopulations(new Dictionary<string, int>
                    {
                        ["Tokyo"] = 37400000,
                        ["Delhi"] = 30300000,
                        ["Shanghai"] = 27058000,
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test07_CountBeforeAndAfterClear() =>
        PynativeExerciseRunner.Run(7, "Clear and Count",
            "Print the count, clear the dictionary, and verify the count is 0.",
            t => t.Add(("3 settings -> before 3, after 0", () =>
            {
                var (before, after) = DictionaryExercises.CountBeforeAndAfterClear(new Dictionary<string, string>
                {
                    ["Theme"] = "Dark",
                    ["Timeout"] = "30",
                    ["Language"] = "en-US",
                });
                PynativeExerciseRunner.PrintOutput($"before={before}, after={after}");
                PynativeExerciseRunner.AssertEqualSilent(3, before);
                PynativeExerciseRunner.AssertEqualSilent(0, after);
            })));

    public static PynativeExerciseRunner.SuiteResult Test08_CheckStock() =>
        PynativeExerciseRunner.Run(8, "Inventory Check",
            "Check whether an item is in stock and whether its quantity is greater than 10.",
            t =>
            {
                var inventory = new Dictionary<string, int>
                {
                    ["Widget"] = 25,
                    ["Gadget"] = 4,
                };
                t.Add(("Widget -> sufficient 25", () =>
                    PynativeExerciseRunner.AssertEqual("Widget is in stock with sufficient quantity (25).",
                        () => DictionaryExercises.CheckStock(inventory, "Widget", 10))));
                t.Add(("Gadget -> low 4", () =>
                    PynativeExerciseRunner.AssertEqual("Gadget is in stock but low (4).",
                        () => DictionaryExercises.CheckStock(inventory, "Gadget", 10))));
                t.Add(("Gizmo -> missing", () =>
                    PynativeExerciseRunner.AssertEqual("Gizmo is not in the inventory.",
                        () => DictionaryExercises.CheckStock(inventory, "Gizmo", 10))));
            });

    public static PynativeExerciseRunner.SuiteResult Test09_ExtractKeysAndValues() =>
        PynativeExerciseRunner.Run(9, "Keys and Values Lists",
            "Copy keys into a list and values into a list without a foreach loop.",
            t => t.Add(("Alice 90, Bob 85, Charlie 78", () =>
            {
                var (keys, values) = DictionaryExercises.ExtractKeysAndValues(new Dictionary<string, int>
                {
                    ["Alice"] = 90,
                    ["Bob"] = 85,
                    ["Charlie"] = 78,
                });
                PynativeExerciseRunner.PrintOutput($"keys={string.Join(", ", keys)}; values={string.Join(", ", values)}");
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "Alice", "Bob", "Charlie" }, keys);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 90, 85, 78 }, values);
            })));

    public static PynativeExerciseRunner.SuiteResult Test10_CreateCaseInsensitiveUsers() =>
        PynativeExerciseRunner.Run(10, "Case-Insensitive Search",
            "Looking up john_doe, John_Doe, and JOHN_DOE returns the same user data.",
            t => t.Add(("john_doe -> John Doe - Admin", () =>
            {
                var users = DictionaryExercises.CreateCaseInsensitiveUsers("john_doe", "John Doe - Admin");
                PynativeExerciseRunner.PrintOutput($"{users["john_doe"]} | {users["John_Doe"]} | {users["JOHN_DOE"]}");
                PynativeExerciseRunner.AssertEqualSilent("John Doe - Admin", users["john_doe"]);
                PynativeExerciseRunner.AssertEqualSilent("John Doe - Admin", users["John_Doe"]);
                PynativeExerciseRunner.AssertEqualSilent("John Doe - Admin", users["JOHN_DOE"]);
            })));

    public static PynativeExerciseRunner.SuiteResult Test11_Invert() =>
        PynativeExerciseRunner.Run(11, "Invert a Dictionary",
            "Swap English words and their Spanish translations.",
            t => t.Add(("hello/hola, goodbye/adios, please/por favor", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "hola=hello", "adios=goodbye", "por favor=please" },
                    () => DictionaryExercises.Invert(new Dictionary<string, string>
                    {
                        ["hello"] = "hola",
                        ["goodbye"] = "adios",
                        ["please"] = "por favor",
                    }).Select(pair => $"{pair.Key}={pair.Value}")))));

    public static PynativeExerciseRunner.SuiteResult Test12_FilterAbove() =>
        PynativeExerciseRunner.Run(12, "Filter by Criteria",
            "Keep only cars that can go over 150 mph.",
            t => t.Add(("five cars, min 150", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Corvette=184", "Veyron=254", "Model 3=162" },
                    () => DictionaryExercises.FilterAbove(new Dictionary<string, int>
                    {
                        ["Civic"] = 124,
                        ["Corvette"] = 184,
                        ["Veyron"] = 254,
                        ["Model 3"] = 162,
                        ["Camry"] = 135,
                    }, 150).Select(pair => $"{pair.Key}={pair.Value}")))));

    public static PynativeExerciseRunner.SuiteResult Test13_HighestAndLowest() =>
        PynativeExerciseRunner.Run(13, "Highest and Lowest",
            "Find the stock with the highest price and the stock with the lowest price.",
            t => t.Add(("AAPL, GOOG, AMZN, TSLA", () =>
            {
                var (highKey, highValue, lowKey, lowValue) = DictionaryExercises.HighestAndLowest(new Dictionary<string, double>
                {
                    ["AAPL"] = 190.50,
                    ["GOOG"] = 140.25,
                    ["AMZN"] = 178.90,
                    ["TSLA"] = 250.75,
                });
                PynativeExerciseRunner.PrintOutput($"high={highKey} {highValue}, low={lowKey} {lowValue}");
                PynativeExerciseRunner.AssertEqualSilent("TSLA", highKey);
                PynativeExerciseRunner.AssertEqualSilent(250.75, highValue);
                PynativeExerciseRunner.AssertEqualSilent("GOOG", lowKey);
                PynativeExerciseRunner.AssertEqualSilent(140.25, lowValue);
            })));

    public static PynativeExerciseRunner.SuiteResult Test14_AverageValue() =>
        PynativeExerciseRunner.Run(14, "Average Value Calculator",
            "Calculate the average monthly expenditure.",
            t => t.Add(("Jan..Apr -> 1137.875", () =>
                PynativeExerciseRunner.AssertEqual(1137.875, () =>
                    Math.Round(DictionaryExercises.AverageValue(new Dictionary<string, double>
                    {
                        ["Jan"] = 1200.00,
                        ["Feb"] = 950.50,
                        ["Mar"] = 1100.75,
                        ["Apr"] = 1300.25,
                    }), 3)))));

    public static PynativeExerciseRunner.SuiteResult Test15_GroupByLength() =>
        PynativeExerciseRunner.Run(15, "Group by Length",
            "Group words into a dictionary keyed by word length.",
            t => t.Add(("cat, dog, fish, ant, lion, owl", () =>
            {
                var grouped = DictionaryExercises.GroupByLength(new[] { "cat", "dog", "fish", "ant", "lion", "owl" });
                PynativeExerciseRunner.PrintOutput(string.Join(" | ", grouped.Select(pair => $"{pair.Key}:{string.Join(",", pair.Value)}")));
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "cat", "dog", "ant", "owl" }, grouped[3]);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "fish", "lion" }, grouped[4]);
            })));

    public static PynativeExerciseRunner.SuiteResult Test16_MergeInventories() =>
        PynativeExerciseRunner.Run(16, "Dictionary Merging",
            "Merge two store inventories, summing quantities for shared items.",
            t => t.Add(("store A + store B", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Apples=10", "Bananas=12", "Oranges=10", "Grapes=12" },
                    () => DictionaryExercises.MergeInventories(
                        new Dictionary<string, int> { ["Apples"] = 10, ["Bananas"] = 5, ["Oranges"] = 8 },
                        new Dictionary<string, int> { ["Bananas"] = 7, ["Oranges"] = 2, ["Grapes"] = 12 })
                        .Select(pair => $"{pair.Key}={pair.Value}")))));

    public static PynativeExerciseRunner.SuiteResult Test17_ApplyTax() =>
        PynativeExerciseRunner.Run(17, "Transform Values",
            "Create a new dictionary where every price includes 10% sales tax.",
            t => t.Add(("Book, Pen, Notebook at 10%", () =>
            {
                var taxed = DictionaryExercises.ApplyTax(new Dictionary<string, double>
                {
                    ["Book"] = 15.00,
                    ["Pen"] = 2.50,
                    ["Notebook"] = 4.75,
                }, 0.10);
                PynativeExerciseRunner.PrintOutput(string.Join(", ", taxed.Select(pair => $"{pair.Key}:{pair.Value}")));
                PynativeExerciseRunner.AssertEqualSilent(16.5, Math.Round(taxed["Book"], 3));
                PynativeExerciseRunner.AssertEqualSilent(2.75, Math.Round(taxed["Pen"], 3));
                PynativeExerciseRunner.AssertEqualSilent(5.225, Math.Round(taxed["Notebook"], 3));
            })));

    public static PynativeExerciseRunner.SuiteResult Test18_SortByValueDescending() =>
        PynativeExerciseRunner.Run(18, "Sort by Value",
            "Sort game review scores from highest to lowest.",
            t => t.Add(("Game A 85, B 92, C 78, D 95", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Game D=95", "Game B=92", "Game A=85", "Game C=78" },
                    () => DictionaryExercises.SortByValueDescending(new Dictionary<string, int>
                    {
                        ["Game A"] = 85,
                        ["Game B"] = 92,
                        ["Game C"] = 78,
                        ["Game D"] = 95,
                    }).Select(pair => $"{pair.Key}={pair.Value}")))));

    public static PynativeExerciseRunner.SuiteResult Test19_GroupByDepartment() =>
        PynativeExerciseRunner.Run(19, "Lookup Conversion",
            "Group employees into a dictionary keyed by department.",
            t => t.Add(("5 employees", () =>
            {
                var grouped = DictionaryExercises.GroupByDepartment(new[]
                {
                    new DictionaryEmployee { Name = "Alice", Department = "Engineering" },
                    new DictionaryEmployee { Name = "Bob", Department = "Sales" },
                    new DictionaryEmployee { Name = "Charlie", Department = "Engineering" },
                    new DictionaryEmployee { Name = "Diana", Department = "Marketing" },
                    new DictionaryEmployee { Name = "Eve", Department = "Sales" },
                });
                PynativeExerciseRunner.PrintOutput(string.Join(" | ", grouped.Select(pair =>
                    $"{pair.Key}:{string.Join(",", pair.Value.Select(employee => employee.Name))}")));
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "Alice", "Charlie" }, grouped["Engineering"].Select(employee => employee.Name));
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "Bob", "Eve" }, grouped["Sales"].Select(employee => employee.Name));
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "Diana" }, grouped["Marketing"].Select(employee => employee.Name));
            })));

    public static PynativeExerciseRunner.SuiteResult Test20_ToJson() =>
        PynativeExerciseRunner.Run(20, "Dictionary to JSON",
            "Convert a string dictionary into a JSON object without an external library.",
            t => t.Add(("name Alice, city Paris", () =>
                PynativeExerciseRunner.AssertEqual("{\"name\":\"Alice\",\"city\":\"Paris\"}",
                    () => DictionaryExercises.ToJson(new Dictionary<string, string>
                    {
                        ["name"] = "Alice",
                        ["city"] = "Paris",
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test21_AverageCourseGrade() =>
        PynativeExerciseRunner.Run(21, "Nested Dictionaries (Multi-Key)",
            "Average the grades for course CS101 in the ComputerScience department.",
            t => t.Add(("CS101 grades 85, 90, 78, 92 -> 86.25", () =>
            {
                var university = new Dictionary<string, Dictionary<string, List<int>>>
                {
                    ["ComputerScience"] = new Dictionary<string, List<int>>
                    {
                        ["CS101"] = new List<int> { 85, 90, 78, 92 },
                        ["CS201"] = new List<int> { 70, 88 },
                    },
                    ["Mathematics"] = new Dictionary<string, List<int>>
                    {
                        ["MATH101"] = new List<int> { 95, 100, 89 },
                    },
                };
                PynativeExerciseRunner.AssertEqual(86.25, () =>
                    Math.Round(DictionaryExercises.AverageCourseGrade(university, "ComputerScience", "CS101"), 2));
            })));

    public static PynativeExerciseRunner.SuiteResult Test22_ContainsEquivalentPoint() =>
        PynativeExerciseRunner.Run(22, "Custom Equality Comparer",
            "A dictionary of Point keys treats the same coordinates as the same key.",
            t =>
            {
                t.Add(("new Point(1, 2) -> true", () =>
                    PynativeExerciseRunner.AssertTrue(() =>
                        DictionaryExercises.ContainsEquivalentPoint(
                            new DictionaryPoint(1, 2), "Origin marker", new DictionaryPoint(1, 2)))));
                t.Add(("new Point(3, 4) -> false", () =>
                    PynativeExerciseRunner.AssertFalse(() =>
                        DictionaryExercises.ContainsEquivalentPoint(
                            new DictionaryPoint(1, 2), "Origin marker", new DictionaryPoint(3, 4)))));
            });

    public static PynativeExerciseRunner.SuiteResult Test23_BuildParallelCache() =>
        PynativeExerciseRunner.Run(23, "Thread-Safe Dictionary Cache",
            "Five parallel GetOrAdd calls store Value-0 through Value-4.",
            t => t.Add(("keys 0..4, key 3 is Value-3", () =>
            {
                var cache = DictionaryExercises.BuildParallelCache(5);
                PynativeExerciseRunner.PrintOutput($"count={cache.Count}, key3={cache[3]}");
                PynativeExerciseRunner.AssertEqualSilent(5, cache.Count);
                PynativeExerciseRunner.AssertEqualSilent("Value-3", cache[3]);
            })));

    public static PynativeExerciseRunner.SuiteResult Test24_CreateLruCache() =>
        PynativeExerciseRunner.Run(24, "LRU (Least Recently Used) Cache",
            "Capacity 2. Put a, put b, access a, then put c. a and c remain; b is evicted.",
            t => t.Add(("contains a true, b false, c true", () =>
            {
                var cache = DictionaryExercises.CreateLruCache<string, int>(2);
                cache.Put("a", 1);
                cache.Put("b", 2);
                cache.TryGet("a", out _);
                cache.Put("c", 3);
                bool hasA = cache.TryGet("a", out _);
                bool hasB = cache.TryGet("b", out _);
                bool hasC = cache.TryGet("c", out _);
                PynativeExerciseRunner.PrintOutput($"a={hasA}, b={hasB}, c={hasC}");
                PynativeExerciseRunner.AssertEqualSilent(true, hasA);
                PynativeExerciseRunner.AssertEqualSilent(false, hasB);
                PynativeExerciseRunner.AssertEqualSilent(true, hasC);
            })));

    public static PynativeExerciseRunner.SuiteResult Test25_MutualFriends() =>
        PynativeExerciseRunner.Run(25, "Graph Representation (Adjacency List)",
            "Find mutual friends of Alice and Bob.",
            t => t.Add(("mutual friend Charlie", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Charlie" },
                    () => DictionaryExercises.MutualFriends(new Dictionary<string, HashSet<string>>
                    {
                        ["Alice"] = new HashSet<string> { "Bob", "Charlie", "Diana" },
                        ["Bob"] = new HashSet<string> { "Alice", "Charlie", "Eve" },
                        ["Charlie"] = new HashSet<string> { "Alice", "Bob" },
                    }, "Alice", "Bob")))));

    public static PynativeExerciseRunner.SuiteResult Test26_Fire() =>
        PynativeExerciseRunner.Run(26, "State Machine",
            "From Idle, fire Start, Pause, Resume, then End.",
            t => t.Add(("Playing, Paused, Playing, GameOver", () =>
            {
                var state = DictionaryGameState.Idle;
                var seen = new List<string>();
                state = DictionaryExercises.Fire(state, DictionaryGameTrigger.Start);
                seen.Add(state.ToString());
                state = DictionaryExercises.Fire(state, DictionaryGameTrigger.Pause);
                seen.Add(state.ToString());
                state = DictionaryExercises.Fire(state, DictionaryGameTrigger.Resume);
                seen.Add(state.ToString());
                state = DictionaryExercises.Fire(state, DictionaryGameTrigger.End);
                seen.Add(state.ToString());
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Playing", "Paused", "Playing", "GameOver" }, seen);
            })));

    public static PynativeExerciseRunner.SuiteResult Test27_TopFrequent() =>
        PynativeExerciseRunner.Run(27, "Frequency Tracker with Priority",
            "Return the top 2 most frequent items.",
            t => t.Add(("top 2 -> apple, banana", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "apple", "banana" },
                    () => DictionaryExercises.TopFrequent(
                        new[] { "apple", "banana", "apple", "cherry", "apple", "banana", "date" }, 2)))));

    public static PynativeExerciseRunner.SuiteResult Test28_CreateCommandEngine() =>
        PynativeExerciseRunner.Run(28, "Undo/Redo System Command History",
            "Run increment and addTen, then undo once. Counter goes 11, then 1.",
            t => t.Add(("after commands 11, after undo 1", () =>
            {
                int counter = 0;
                var engine = DictionaryExercises.CreateCommandEngine();
                engine.Register("increment", () => counter++, () => counter--);
                engine.Register("addTen", () => counter += 10, () => counter -= 10);
                engine.Execute("increment");
                engine.Execute("addTen");
                PynativeExerciseRunner.PrintOutput($"after commands={counter}");
                PynativeExerciseRunner.AssertEqualSilent(11, counter);
                engine.Undo();
                PynativeExerciseRunner.PrintOutput($"after undo={counter}");
                PynativeExerciseRunner.AssertEqualSilent(1, counter);
            })));

    public static PynativeExerciseRunner.SuiteResult Test29_CreateSparseMatrix() =>
        PynativeExerciseRunner.Run(29, "Sparse Matrix Representation",
            "Dot product of row 0 (2.0 at col 5, 3.0 at col 9998) and row 1 (4.0 and 1.5).",
            t => t.Add(("dot product -> 12.5", () =>
            {
                var matrix = DictionaryExercises.CreateSparseMatrix();
                matrix.Set(0, 5, 2.0);
                matrix.Set(0, 9998, 3.0);
                matrix.Set(1, 5, 4.0);
                matrix.Set(1, 9998, 1.5);
                PynativeExerciseRunner.AssertEqual(12.5, () => matrix.DotProductOfRows(0, 1));
            })));

    public static PynativeExerciseRunner.SuiteResult Test30_CreateContainer() =>
        PynativeExerciseRunner.Run(30, "Dependency Injection Container",
            "Register EnglishGreeter as IGreeter, resolve it, and call Greet.",
            t => t.Add(("resolved greeting -> Hello!", () =>
            {
                var container = DictionaryExercises.CreateContainer();
                container.Register<DictionaryIGreeter>(() => new DictionaryEnglishGreeter());
                DictionaryIGreeter greeter = container.Resolve<DictionaryIGreeter>();
                PynativeExerciseRunner.AssertEqualSilent("Hello!", greeter.Greet());
            })));
}
