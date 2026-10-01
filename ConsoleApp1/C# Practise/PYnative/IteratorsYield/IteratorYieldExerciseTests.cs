using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.IteratorsYield;

public static class IteratorYieldExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 25; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative - Iterators and Yield Exercises (25)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_GetEvens(),
        2 => Test02_Countdown(),
        3 => Test03_FilterVowels(),
        4 => Test04_InfiniteNumbers(),
        5 => Test05_PowersOfTwo(),
        6 => Test06_TakeEveryNth(),
        7 => Test07_StopWord(),
        8 => Test08_MyWhere(),
        9 => Test09_MySelect(),
        10 => Test10_Fibonacci(),
        11 => Test11_RunningTotal(),
        12 => Test12_Chunk(),
        13 => Test13_LogsBetweenSignals(),
        14 => Test14_Flatten(),
        15 => Test15_ToPairs(),
        16 => Test16_DeferredExecution(),
        17 => Test17_FinallyOnEarlyExit(),
        18 => Test18_CustomEnumerator(),
        19 => Test19_ReadLines(),
        20 => Test20_Interleave(),
        21 => Test21_PaginatedFetch(),
        22 => Test22_PeekableIterator(),
        23 => Test23_LoopForever(),
        24 => Test24_IteratorPipeline(),
        25 => Test25_FetchDataAsync(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Iterators and yield exercises are numbered 1-25.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_GetEvens() =>
        PynativeExerciseRunner.Run(1, "Generate Even Numbers with Yield Return",
            "Yield even numbers from 0 up to max, inclusive.",
            t =>
            {
                t.Add(("max 10 -> 0, 2, 4, 6, 8, 10", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { 0, 2, 4, 6, 8, 10 },
                        () => IteratorYieldExercises.GetEvens(10))));
                t.Add(("max 4 -> 0, 2, 4", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { 0, 2, 4 },
                        () => IteratorYieldExercises.GetEvens(4))));
            });

    public static PynativeExerciseRunner.SuiteResult Test02_Countdown() =>
        PynativeExerciseRunner.Run(2, "Count Down with an Early Exit",
            "Count down from start to 1. A negative start yields nothing.",
            t =>
            {
                t.Add(("start 5 -> 5, 4, 3, 2, 1", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { 5, 4, 3, 2, 1 },
                        () => IteratorYieldExercises.Countdown(5))));
                t.Add(("start -1 -> empty", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(
                        Array.Empty<int>(),
                        () => IteratorYieldExercises.Countdown(-1))));
            });

    public static PynativeExerciseRunner.SuiteResult Test03_FilterVowels() =>
        PynativeExerciseRunner.Run(3, "Filter Vowels from a String",
            "Yield only vowels, upper or lower case, in the order they appear.",
            t =>
            {
                t.Add(("Programming -> o, a, i", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { 'o', 'a', 'i' },
                        () => IteratorYieldExercises.FilterVowels("Programming"))));
                t.Add(("AEIOU -> A, E, I, O, U", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { 'A', 'E', 'I', 'O', 'U' },
                        () => IteratorYieldExercises.FilterVowels("AEIOU"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test04_InfiniteNumbers() =>
        PynativeExerciseRunner.Run(4, "Generate an Infinite Sequence Lazily",
            "Yield 1, 2, 3, ... forever. The test takes the first 5 values.",
            t => t.Add(("first 5 -> 1, 2, 3, 4, 5", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4, 5 },
                    () => IteratorYieldExercises.InfiniteNumbers().Take(5)))));

    public static PynativeExerciseRunner.SuiteResult Test05_PowersOfTwo() =>
        PynativeExerciseRunner.Run(5, "Generate Powers of Two",
            "Yield 2^0 through 2^exponentLimit.",
            t => t.Add(("exponentLimit 5 -> 1, 2, 4, 8, 16, 32", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new long[] { 1, 2, 4, 8, 16, 32 },
                    () => IteratorYieldExercises.GetPowersOfTwo(5)))));

    public static PynativeExerciseRunner.SuiteResult Test06_TakeEveryNth() =>
        PynativeExerciseRunner.Run(6, "Take Every Nth Element from an Array",
            "Yield every n-th element, starting at index 0.",
            t => t.Add(("n = 3 -> 10, 40, 70", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 10, 40, 70 },
                    () => IteratorYieldExercises.TakeEveryNth(
                        new[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 }, 3)))));

    public static PynativeExerciseRunner.SuiteResult Test07_StopWord() =>
        PynativeExerciseRunner.Run(7, "Stop an Iterator at a Specific Word",
            "Yield words until the stop word, which is not included.",
            t => t.Add(("stop at END -> Apple, Banana", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Apple", "Banana" },
                    () => IteratorYieldExercises.ReadUntilStopWord(
                        new[] { "Apple", "Banana", "END", "Cherry", "Date" }, "END")))));

    public static PynativeExerciseRunner.SuiteResult Test08_MyWhere() =>
        PynativeExerciseRunner.Run(8, "Reimplement LINQ's Where Method",
            "Yield source items for which the predicate returns true.",
            t => t.Add(("evens of 1..8 -> 2, 4, 6, 8", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 2, 4, 6, 8 },
                    () => new[] { 1, 2, 3, 4, 5, 6, 7, 8 }.MyWhere(n => n % 2 == 0)))));

    public static PynativeExerciseRunner.SuiteResult Test09_MySelect() =>
        PynativeExerciseRunner.Run(9, "Reimplement LINQ's Select Method",
            "Yield selector(item) for each source item.",
            t => t.Add(("squares of 1..4 -> 1, 4, 9, 16", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 4, 9, 16 },
                    () => new[] { 1, 2, 3, 4 }.MySelect(n => n * n)))));

    public static PynativeExerciseRunner.SuiteResult Test10_Fibonacci() =>
        PynativeExerciseRunner.Run(10, "Generate the Fibonacci Sequence",
            "Yield the first count Fibonacci numbers, starting 0, 1, 1, 2.",
            t => t.Add(("count 8 -> 0, 1, 1, 2, 3, 5, 8, 13", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 0, 1, 1, 2, 3, 5, 8, 13 },
                    () => IteratorYieldExercises.GetFibonacci(8)))));

    public static PynativeExerciseRunner.SuiteResult Test11_RunningTotal() =>
        PynativeExerciseRunner.Run(11, "Calculate a Running Total (Prefix Sum)",
            "Yield the cumulative sum after each number.",
            t => t.Add(("[1, 2, 3] -> 1, 3, 6", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 3, 6 },
                    () => IteratorYieldExercises.RunningTotal(new[] { 1, 2, 3 })))));

    public static PynativeExerciseRunner.SuiteResult Test12_Chunk() =>
        PynativeExerciseRunner.Run(12, "Split a Collection into Chunks",
            "Yield groups of the given size, including a shorter final group.",
            t => t.Add(("[1..7] size 3 -> [1,2,3] [4,5,6] [7]", () =>
            {
                var chunks = IteratorYieldExercises.Chunk(new[] { 1, 2, 3, 4, 5, 6, 7 }, 3).ToList();
                PynativeExerciseRunner.PrintOutput(string.Join(" | ", chunks.Select(c => string.Join(",", c))));
                PynativeExerciseRunner.AssertEqualSilent(3, chunks.Count);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 1, 2, 3 }, chunks[0]);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 4, 5, 6 }, chunks[1]);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 7 }, chunks[2]);
            })));

    public static PynativeExerciseRunner.SuiteResult Test13_LogsBetweenSignals() =>
        PynativeExerciseRunner.Run(13, "Track State Between Two Signal Markers",
            "Yield logs strictly between START and STOP.",
            t => t.Add(("between START and STOP -> Login, Purchase", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Login", "Purchase" },
                    () => IteratorYieldExercises.GetLogsBetweenSignals(
                        new[] { "Init", "START", "Login", "Purchase", "STOP", "Logout" })))));

    public static PynativeExerciseRunner.SuiteResult Test14_Flatten() =>
        PynativeExerciseRunner.Run(14, "Flatten a Nested Collection",
            "Yield one flat sequence from a sequence of sequences.",
            t => t.Add(("three inner lists -> 1..9", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                    () => IteratorYieldExercises.Flatten<int>(new[]
                    {
                        new[] { 1, 2, 3 },
                        new[] { 4, 5 },
                        new[] { 6, 7, 8, 9 }
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test15_ToPairs() =>
        PynativeExerciseRunner.Run(15, "Generate Adjacent Pairs from a Sequence",
            "Yield overlapping adjacent pairs from the sequence.",
            t => t.Add(("[1, 2, 3, 4] -> (1,2), (2,3), (3,4)", () =>
            {
                var pairs = IteratorYieldExercises.ToPairs(new[] { 1, 2, 3, 4 }).ToList();
                PynativeExerciseRunner.PrintOutput(string.Join(", ", pairs.Select(p => $"({p.First}, {p.Second})")));
                PynativeExerciseRunner.AssertEqualSilent(3, pairs.Count);
                PynativeExerciseRunner.AssertEqualSilent((1, 2), pairs[0]);
                PynativeExerciseRunner.AssertEqualSilent((2, 3), pairs[1]);
                PynativeExerciseRunner.AssertEqualSilent((3, 4), pairs[2]);
            })));

    public static PynativeExerciseRunner.SuiteResult Test16_DeferredExecution() =>
        PynativeExerciseRunner.Run(16, "Visualize Deferred Execution",
            "The iterator body must not run until foreach starts pulling values.",
            t => t.Add(("trace for 1, 2, 3", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Calling GetNumbersWithLogging()...",
                        "Method call returned, but no logging has happened yet.",
                        "Now starting to iterate:",
                        "Iterator method started executing.",
                        "About to yield 1",
                        "Received 1",
                        "About to yield 2",
                        "Received 2",
                        "About to yield 3",
                        "Received 3"
                    },
                    () => PynativeConsole.CaptureLines(() => IteratorYieldExercises.DemonstrateDeferredExecution())))));

    public static PynativeExerciseRunner.SuiteResult Test17_FinallyOnEarlyExit() =>
        PynativeExerciseRunner.Run(17, "Observe Finally Block Behavior on Early Exit",
            "Breaking out of foreach at 3 still runs the iterator finally block.",
            t => t.Add(("break at 3 of 1..5", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Received 1",
                        "Received 2",
                        "Received 3",
                        "Breaking out of the loop early.",
                        "Finally block executed: cleanup ran."
                    },
                    () => PynativeConsole.CaptureLines(() => IteratorYieldExercises.DemonstrateFinallyOnEarlyExit())))));

    public static PynativeExerciseRunner.SuiteResult Test18_CustomEnumerator() =>
        PynativeExerciseRunner.Run(18, "Build a Zero-Allocation Custom Enumerator",
            "foreach a NumberRange(1, 5) struct via a struct enumerator, without IEnumerable.",
            t => t.Add(("1..5 -> Number = 1 .. Number = 5", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Number = 1",
                        "Number = 2",
                        "Number = 3",
                        "Number = 4",
                        "Number = 5"
                    },
                    () => PynativeConsole.CaptureLines(() => IteratorYieldExercises.DemonstrateCustomEnumerator())))));

    public static PynativeExerciseRunner.SuiteResult Test19_ReadLines() =>
        PynativeExerciseRunner.Run(19, "Read a Large File Line by Line",
            "Yield each line from a StreamReader. The test reads a small temp file, including a STOP line.",
            t =>
            {
                t.Add(("alpha, beta, STOP, gamma", () =>
                    AssertFileLines(
                        new[] { "alpha", "beta", "STOP", "gamma" },
                        new[] { "alpha", "beta", "STOP", "gamma" })));
                t.Add(("empty file -> empty", () =>
                    AssertFileLines(Array.Empty<string>(), Array.Empty<string>())));
            });

    public static PynativeExerciseRunner.SuiteResult Test20_Interleave() =>
        PynativeExerciseRunner.Run(20, "Interleave Two Sequences",
            "Alternate items from two sequences until both are exhausted.",
            t => t.Add(("{1,3,5} with {2,4,6,8,10}", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4, 5, 6, 8, 10 },
                    () => IteratorYieldExercises.Interleave(
                        new[] { 1, 3, 5 },
                        new[] { 2, 4, 6, 8, 10 })))));

    public static PynativeExerciseRunner.SuiteResult Test21_PaginatedFetch() =>
        PynativeExerciseRunner.Run(21, "Simulate a Paginated API Fetcher",
            "Page size 100 and 3 pages, but only 5 items are consumed, so only page 1 is fetched.",
            t => t.Add(("consume 5 -> fetch page 1 only", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Fetching page 1 from the API...",
                        "Consumed item 1",
                        "Consumed item 2",
                        "Consumed item 3",
                        "Consumed item 4",
                        "Consumed item 5"
                    },
                    () => PynativeConsole.CaptureLines(() => IteratorYieldExercises.DemonstratePaginatedFetch())))));

    public static PynativeExerciseRunner.SuiteResult Test22_PeekableIterator() =>
        PynativeExerciseRunner.Run(22, "Build a Peekable Iterator",
            "Peek at the next value of {10, 20, 30} without advancing the cursor.",
            t => t.Add(("peek 20, then current stays 20", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Current = 10",
                        "Peeked = 20",
                        "Current = 20",
                        "Current = 30"
                    },
                    () => PynativeConsole.CaptureLines(() => IteratorYieldExercises.DemonstratePeekableIterator())))));

    public static PynativeExerciseRunner.SuiteResult Test23_LoopForever() =>
        PynativeExerciseRunner.Run(23, "Loop Through a Collection Forever",
            "Cycle through the source forever. The test takes the first 8 values.",
            t => t.Add(("Red, Green, Blue take 8", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Red", "Green", "Blue", "Red", "Green", "Blue", "Red", "Green" },
                    () => IteratorYieldExercises.LoopForever(new[] { "Red", "Green", "Blue" }).Take(8)))));

    public static PynativeExerciseRunner.SuiteResult Test24_IteratorPipeline() =>
        PynativeExerciseRunner.Run(24, "Chain Multiple Iterators into a Pipeline",
            "Filter positive integers, double them, and format Result: N. Rejected items skip later stages.",
            t => t.Add(("12, abc, 45, -3, 78", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "[ReadInput] Read: 12",
                        "[FilterInvalid] Passed: 12",
                        "[TransformData] 12 -> 24",
                        "[CleanOutput] Formatted: Result: 24",
                        "Final: Result: 24",
                        "---",
                        "[ReadInput] Read: abc",
                        "[FilterInvalid] Rejected: abc",
                        "[ReadInput] Read: 45",
                        "[FilterInvalid] Passed: 45",
                        "[TransformData] 45 -> 90",
                        "[CleanOutput] Formatted: Result: 90",
                        "Final: Result: 90",
                        "---",
                        "[ReadInput] Read: -3",
                        "[FilterInvalid] Rejected: -3",
                        "[ReadInput] Read: 78",
                        "[FilterInvalid] Passed: 78",
                        "[TransformData] 78 -> 156",
                        "[CleanOutput] Formatted: Result: 156",
                        "Final: Result: 156",
                        "---"
                    },
                    () => PynativeConsole.CaptureLines(() => IteratorYieldExercises.DemonstrateIteratorPipeline())))));

    public static PynativeExerciseRunner.SuiteResult Test25_FetchDataAsync() =>
        PynativeExerciseRunner.Run(25, "Stream Data Asynchronously with IAsyncEnumerable",
            "Yield Record A, Record B, and Record C. Wall-clock timestamps are not checked.",
            t => t.Add(("Record A, Record B, Record C", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Record A", "Record B", "Record C" },
                    () => IteratorYieldExercises.FetchDataAsync().ToBlockingEnumerable()))));

    private static void AssertFileLines(string[] fileLines, string[] expected)
    {
        string path = Path.Combine(Path.GetTempPath(), "pynative-iter-readlines-" + Guid.NewGuid().ToString("N") + ".txt");
        File.WriteAllLines(path, fileLines);
        try
        {
            PynativeExerciseRunner.AssertSequenceEqual(expected, () => IteratorYieldExercises.ReadLines(path));
        }
        finally
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
