using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative;

/// <summary>
/// Test runner for PYnative exercises — prints the question, each test input, expected vs your output, and pass/fail result.
/// </summary>
public static class PynativeExerciseRunner
{
    private sealed class ExerciseSkippedException : Exception;

    public sealed class SuiteResult
    {
        public int Passed { get; init; }
        public int Failed { get; init; }
        public int Skipped { get; init; }
        public int Total => Passed + Failed + Skipped;
    }

    public static SuiteResult Run(
        int exerciseNumber,
        string title,
        string question,
        Action<List<(string Input, Action Body)>> registerTests)
    {
        var tests = new List<(string Input, Action Body)>();
        registerTests(tests);

        Console.WriteLine();
        Console.WriteLine(new string('=', 72));
        Console.WriteLine($"Exercise {exerciseNumber}: {title}");
        Console.WriteLine(new string('-', 72));
        Console.WriteLine($"Question: {question}");
        Console.WriteLine(new string('-', 72));

        int passed = 0, failed = 0, skipped = 0;

        for (int i = 0; i < tests.Count; i++)
        {
            var (input, body) = tests[i];
            Console.WriteLine($"Test {i + 1}: {input}");

            try
            {
                body();
                Console.WriteLine("  Result: PASS");
                passed++;
            }
            catch (ExerciseSkippedException)
            {
                Console.WriteLine("  Result: SKIP — implement the method above, then run again");
                skipped++;
            }
            catch (NotImplementedException)
            {
                PrintExpectedHint(input);
                Console.WriteLine("  Your output: (not implemented yet)");
                Console.WriteLine("  Result: SKIP — implement the method above, then run again");
                skipped++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  Result: FAIL — {ex.Message}");
                failed++;
            }
        }

        Console.WriteLine(new string('-', 72));
        Console.WriteLine($"Summary: {passed} passed, {failed} failed, {skipped} skipped (of {tests.Count})");
        return new SuiteResult { Passed = passed, Failed = failed, Skipped = skipped };
    }

    public static void PrintSummary(string label, IReadOnlyList<SuiteResult> results)
    {
        int passed = 0, failed = 0, skipped = 0;
        foreach (var r in results)
        {
            passed += r.Passed;
            failed += r.Failed;
            skipped += r.Skipped;
        }

        Console.WriteLine();
        Console.WriteLine(new string('=', 72));
        Console.WriteLine(label);
        Console.WriteLine($"Total tests: {passed + failed + skipped} | Passed: {passed} | Failed: {failed} | Skipped: {skipped}");
        if (failed == 0 && skipped == 0)
            Console.WriteLine("All tests passed!");
        Console.WriteLine(new string('=', 72));
    }

    /// <summary>Print your method's return value (and optional expected) before asserting.</summary>
    public static void PrintOutput(object? actual, object? expected = null)
    {
        if (expected is not null)
            Console.WriteLine($"  Expected:    {FormatValue(expected)}");
        Console.WriteLine($"  Your output: {FormatValue(actual)}");
    }

    public static void AssertEqual<T>(T expected, T actual)
    {
        PrintComparison(expected, actual);
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new InvalidOperationException($"expected [{FormatValue(expected)}], got [{FormatValue(actual)}]");
    }

    public static void AssertEqual<T>(T expected, Func<T> getActual)
    {
        T actual;
        try
        {
            actual = getActual();
        }
        catch (NotImplementedException)
        {
            PrintComparison(expected, "(not implemented yet)");
            throw new ExerciseSkippedException();
        }

        PrintComparison(expected, actual);
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new InvalidOperationException($"expected [{FormatValue(expected)}], got [{FormatValue(actual)}]");
    }

    public static void AssertTrue(bool actual, string? message = null)
    {
        PrintComparison(true, actual);
        if (!actual)
            throw new InvalidOperationException(message ?? "expected true");
    }

    public static void AssertTrue(Func<bool> getActual, string? message = null)
    {
        bool actual;
        try
        {
            actual = getActual();
        }
        catch (NotImplementedException)
        {
            PrintComparison(true, "(not implemented yet)");
            throw new ExerciseSkippedException();
        }

        PrintComparison(true, actual);
        if (!actual)
            throw new InvalidOperationException(message ?? "expected true");
    }

    public static void AssertFalse(bool actual, string? message = null)
    {
        PrintComparison(false, actual);
        if (actual)
            throw new InvalidOperationException(message ?? "expected false");
    }

    public static void AssertFalse(Func<bool> getActual, string? message = null)
    {
        bool actual;
        try
        {
            actual = getActual();
        }
        catch (NotImplementedException)
        {
            PrintComparison(false, "(not implemented yet)");
            throw new ExerciseSkippedException();
        }

        PrintComparison(false, actual);
        if (actual)
            throw new InvalidOperationException(message ?? "expected false");
    }

    public static void AssertSequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual)
    {
        var act = new List<T>(actual);
        PrintComparison(expected, act);
        CompareSequences(expected, act);
    }

    public static void AssertSequenceEqual<T>(IEnumerable<T> expected, Func<IEnumerable<T>> getActual)
    {
        List<T> act;
        try
        {
            act = new List<T>(getActual());
        }
        catch (NotImplementedException)
        {
            PrintComparison(expected, "(not implemented yet)");
            throw new ExerciseSkippedException();
        }

        PrintComparison(expected, act);
        CompareSequences(expected, act);
    }

    public static void AssertMatrixEqual(int[,] expected, int[,] actual)
    {
        PrintComparison(MatrixToDisplay(expected), MatrixToDisplay(actual));
        if (expected.GetLength(0) != actual.GetLength(0) || expected.GetLength(1) != actual.GetLength(1))
            throw new InvalidOperationException(
                $"matrix size mismatch: expected {expected.GetLength(0)}x{expected.GetLength(1)}, got {actual.GetLength(0)}x{actual.GetLength(1)}");

        for (int r = 0; r < expected.GetLength(0); r++)
        for (int c = 0; c < expected.GetLength(1); c++)
        {
            if (expected[r, c] != actual[r, c])
                throw new InvalidOperationException($"at [{r},{c}]: expected {expected[r, c]}, got {actual[r, c]}");
        }
    }

    public static void AssertMatrixEqual(int[,] expected, Func<int[,]> getActual)
    {
        int[,] actual;
        try
        {
            actual = getActual();
        }
        catch (NotImplementedException)
        {
            PrintComparison(MatrixToDisplay(expected), "(not implemented yet)");
            throw new ExerciseSkippedException();
        }

        AssertMatrixEqual(expected, actual);
    }

    /// <summary>Assert and print expected vs actual (use after PrintOutput for composite results).</summary>
    public static void AssertEqualSilent<T>(T expected, T actual)
    {
        PrintComparison(expected, actual);
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new InvalidOperationException($"expected [{FormatValue(expected)}], got [{FormatValue(actual)}]");
    }

    private static void PrintComparison(object? expected, object? actual)
    {
        Console.WriteLine($"  Expected:    {FormatValue(expected)}");
        Console.WriteLine($"  Your output: {FormatValue(actual)}");
    }

    private static void PrintExpectedHint(string input)
    {
        var hint = ExtractExpectedHint(input);
        if (hint is not null)
            Console.WriteLine($"  Expected:    {hint}");
    }

    private static string? ExtractExpectedHint(string input)
    {
        var match = System.Text.RegularExpressions.Regex.Match(input, @"->\s*(.+)$");
        return match.Success ? match.Groups[1].Value.Trim() : null;
    }

    private static void CompareSequences<T>(IEnumerable<T> expected, List<T> actual)
    {
        var exp = new List<T>(expected);
        if (exp.Count != actual.Count)
            throw new InvalidOperationException($"count mismatch: expected {exp.Count}, got {actual.Count}");

        for (int i = 0; i < exp.Count; i++)
        {
            if (!EqualityComparer<T>.Default.Equals(exp[i], actual[i]))
                throw new InvalidOperationException($"at index {i}: expected [{FormatValue(exp[i])}], got [{FormatValue(actual[i])}]");
        }
    }

    private static string MatrixToDisplay(int[,] matrix)
    {
        var rows = new List<string>();
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            var cells = new List<string>();
            for (int c = 0; c < matrix.GetLength(1); c++)
                cells.Add(matrix[r, c].ToString());
            rows.Add($"[{string.Join(", ", cells)}]");
        }
        return string.Join(" | ", rows);
    }

    private static string FormatValue(object? value)
    {
        if (value is null)
            return "null";

        return value switch
        {
            string s => $"\"{s}\"",
            char c => $"'{c}'",
            bool b => b ? "true" : "false",
            IEnumerable<string> strings => $"[{string.Join(", ", strings.Select(s => $"\"{s}\""))}]",
            IEnumerable<char> chars => $"[{string.Join(", ", chars.Select(c => $"'{c}'"))}]",
            IEnumerable<int> ints => $"[{string.Join(", ", ints)}]",
            IReadOnlyDictionary<char, int> freq =>
                $"{{{string.Join(", ", freq.Select(kv => $"'{kv.Key}'={kv.Value}"))}}}",
            ValueTuple<string, string> (string a, string b) => $"(left=\"{a}\", right=\"{b}\")",
            _ => value.ToString() ?? "null"
        };
    }
}
