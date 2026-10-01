using System;
using System.Collections.Generic;

namespace ConsoleApp1.C__Practise.Programming
{
    /// <summary>
    /// Lightweight test runner for TOPPrograms practice exercises.
    /// Call from Practise to verify your implementation against all test cases.
    /// </summary>
    public static class PracticeTestRunner
    {
        public sealed class SuiteResult
        {
            public int Passed { get; init; }
            public int Failed { get; init; }
            public int Skipped { get; init; }
            public int Total => Passed + Failed + Skipped;
        }

        public static SuiteResult Run(string exerciseName, Action<List<(string Name, Action Body)>> registerTests)
        {
            var tests = new List<(string Name, Action Body)>();
            registerTests(tests);

            int passed = 0, failed = 0, skipped = 0;

            Console.WriteLine($"\n=== {exerciseName} ({tests.Count} tests) ===");

            foreach (var (name, body) in tests)
            {
                try
                {
                    body();
                    Console.WriteLine($"  PASS  {name}");
                    passed++;
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"  SKIP  {name} — not implemented yet");
                    skipped++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  FAIL  {name} — {ex.Message}");
                    failed++;
                }
            }

            Console.WriteLine($"  → {passed} passed, {failed} failed, {skipped} skipped");
            return new SuiteResult { Passed = passed, Failed = failed, Skipped = skipped };
        }

        public static void AssertEqual<T>(T expected, T actual, string? detail = null)
        {
            if (!EqualityComparer<T>.Default.Equals(expected, actual))
            {
                var msg = detail ?? $"expected [{expected}], got [{actual}]";
                throw new InvalidOperationException(msg);
            }
        }

        public static void AssertTrue(bool condition, string? message = null)
        {
            if (!condition)
                throw new InvalidOperationException(message ?? "expected true");
        }

        public static void AssertFalse(bool condition, string? message = null)
        {
            if (condition)
                throw new InvalidOperationException(message ?? "expected false");
        }

        public static void AssertSequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual, string? detail = null)
        {
            var exp = new List<T>(expected);
            var act = new List<T>(actual);
            if (exp.Count != act.Count)
                throw new InvalidOperationException(detail ?? $"count mismatch: expected {exp.Count}, got {act.Count}");

            for (int i = 0; i < exp.Count; i++)
            {
                if (!EqualityComparer<T>.Default.Equals(exp[i], act[i]))
                    throw new InvalidOperationException(detail ?? $"at index {i}: expected [{exp[i]}], got [{act[i]}]");
            }
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

            Console.WriteLine($"\n========== {label} ==========");
            Console.WriteLine($"Total: {passed + failed + skipped} | Passed: {passed} | Failed: {failed} | Skipped: {skipped}");
            if (failed == 0 && skipped == 0)
                Console.WriteLine("All tests passed!");
            else if (failed == 0)
                Console.WriteLine("No failures — implement remaining exercises to clear skips.");
            Console.WriteLine("================================\n");
        }
    }
}
