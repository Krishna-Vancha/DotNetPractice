using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ConsoleApp1.C__Practise.Programming
{
    /// <summary>
    /// Test cases for TOPPrograms. Run individual exercises or entire sections from Practise.
    /// </summary>
    public static class TOPProgramTests
    {
        // ── Section runners ─────────────────────────────────────────────────

        public static void RunAll()
        {
            var results = new List<PracticeTestRunner.SuiteResult>();
            results.AddRange(RunSection1_Numbers());
            results.AddRange(RunSection2_Strings());
            results.AddRange(RunSection3_Arrays());
            results.AddRange(RunSection4_Linq());
            results.AddRange(RunSection13_Collections());
            PracticeTestRunner.PrintSummary("TOPPrograms — All automated tests", results);
        }

        public static void RunSection1() =>
            PracticeTestRunner.PrintSummary("Section 1 — Numbers", RunSection1_Numbers());

        public static void RunSection2() =>
            PracticeTestRunner.PrintSummary("Section 2 — Strings", RunSection2_Strings());

        public static void RunSection3() =>
            PracticeTestRunner.PrintSummary("Section 3 — Arrays", RunSection3_Arrays());

        public static void RunSection4() =>
            PracticeTestRunner.PrintSummary("Section 4 — LINQ", RunSection4_Linq());

        public static void RunSection13() =>
            PracticeTestRunner.PrintSummary("Section 13 — Collections", RunSection13_Collections());

        // ── 1. Numbers ──────────────────────────────────────────────────────

        public static List<PracticeTestRunner.SuiteResult> RunSection1_Numbers() => new()
        {
            TestConvertVeryLargeNumericString(),
            TestAddTwoLargeNumberStrings(),
            TestTryParseIntSafely(),
            TestReverseInteger(),
            TestIsIntegerPalindrome(),
            TestDivideWithoutMultiplyOrDivide(),
            TestIntegerPow(),
            TestDetectIntegerOverflowOnAdd(),
            TestDecimalToDoublePrecisionLoss(),
            TestCurrencyRounding(),
        };

        public static PracticeTestRunner.SuiteResult TestConvertVeryLargeNumericString() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.ConvertVeryLargeNumericString), t =>
            {
                t.Add(("small", () => PracticeTestRunner.AssertEqual(
                    BigInteger.Parse("123"), TOPPrograms.ConvertVeryLargeNumericString("123"))));
                t.Add(("large", () => PracticeTestRunner.AssertEqual(
                    BigInteger.Parse("999999999999999999999999999999"), TOPPrograms.ConvertVeryLargeNumericString("999999999999999999999999999999"))));
                t.Add(("zero", () => PracticeTestRunner.AssertEqual(
                    BigInteger.Zero, TOPPrograms.ConvertVeryLargeNumericString("0"))));
            });

        public static PracticeTestRunner.SuiteResult TestAddTwoLargeNumberStrings() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.AddTwoLargeNumberStrings), t =>
            {
                t.Add(("simple", () => PracticeTestRunner.AssertEqual("579", TOPPrograms.AddTwoLargeNumberStrings("123", "456"))));
                t.Add(("carry", () => PracticeTestRunner.AssertEqual("1000", TOPPrograms.AddTwoLargeNumberStrings("999", "1"))));
                t.Add(("large", () => PracticeTestRunner.AssertEqual("13579", TOPPrograms.AddTwoLargeNumberStrings("12345", "1234"))));
                t.Add(("different lengths", () => PracticeTestRunner.AssertEqual("111111111111111111111111111111", TOPPrograms.AddTwoLargeNumberStrings("999999999999999999999999999999", "111111111111111111111111111111"))));
            });

        public static PracticeTestRunner.SuiteResult TestTryParseIntSafely() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.TryParseIntSafely), t =>
            {
                t.Add(("valid", () =>
                {
                    var ok = TOPPrograms.TryParseIntSafely("42", out var n);
                    PracticeTestRunner.AssertTrue(ok);
                    PracticeTestRunner.AssertEqual(42, n);
                }));
                t.Add(("invalid text", () =>
                {
                    var ok = TOPPrograms.TryParseIntSafely("abc", out _);
                    PracticeTestRunner.AssertFalse(ok);
                }));
                t.Add(("empty", () =>
                {
                    var ok = TOPPrograms.TryParseIntSafely("", out _);
                    PracticeTestRunner.AssertFalse(ok);
                }));
                t.Add(("overflow string", () =>
                {
                    var ok = TOPPrograms.TryParseIntSafely("999999999999999999999", out _);
                    PracticeTestRunner.AssertFalse(ok);
                }));
            });

        public static PracticeTestRunner.SuiteResult TestReverseInteger() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.ReverseInteger), t =>
            {
                t.Add(("positive", () => PracticeTestRunner.AssertEqual(321, TOPPrograms.ReverseInteger(123))));
                t.Add(("negative", () => PracticeTestRunner.AssertEqual(-321, TOPPrograms.ReverseInteger(-123))));
                t.Add(("trailing zero", () => PracticeTestRunner.AssertEqual(21, TOPPrograms.ReverseInteger(120))));
                t.Add(("single digit", () => PracticeTestRunner.AssertEqual(5, TOPPrograms.ReverseInteger(5))));
                t.Add(("zero", () => PracticeTestRunner.AssertEqual(0, TOPPrograms.ReverseInteger(0))));
            });

        public static PracticeTestRunner.SuiteResult TestIsIntegerPalindrome() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.IsIntegerPalindrome), t =>
            {
                t.Add(("121", () => PracticeTestRunner.AssertTrue(TOPPrograms.IsIntegerPalindrome(121))));
                t.Add(("123", () => PracticeTestRunner.AssertFalse(TOPPrograms.IsIntegerPalindrome(123))));
                t.Add(("negative", () => PracticeTestRunner.AssertFalse(TOPPrograms.IsIntegerPalindrome(-121))));
                t.Add(("single digit", () => PracticeTestRunner.AssertTrue(TOPPrograms.IsIntegerPalindrome(7))));
                t.Add(("1001", () => PracticeTestRunner.AssertTrue(TOPPrograms.IsIntegerPalindrome(1001))));
            });

        public static PracticeTestRunner.SuiteResult TestDivideWithoutMultiplyOrDivide() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.DivideWithoutMultiplyOrDivide), t =>
            {
                t.Add(("10/3", () => PracticeTestRunner.AssertEqual(3, TOPPrograms.DivideWithoutMultiplyOrDivide(10, 3))));
                t.Add(("7/2", () => PracticeTestRunner.AssertEqual(3, TOPPrograms.DivideWithoutMultiplyOrDivide(7, 2))));
                t.Add(("exact", () => PracticeTestRunner.AssertEqual(5, TOPPrograms.DivideWithoutMultiplyOrDivide(15, 3))));
                t.Add(("zero dividend", () => PracticeTestRunner.AssertEqual(0, TOPPrograms.DivideWithoutMultiplyOrDivide(0, 5))));
            });

        public static PracticeTestRunner.SuiteResult TestIntegerPow() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.IntegerPow), t =>
            {
                t.Add(("2^10", () => PracticeTestRunner.AssertEqual(1024L, TOPPrograms.IntegerPow(2, 10))));
                t.Add(("5^0", () => PracticeTestRunner.AssertEqual(1L, TOPPrograms.IntegerPow(5, 0))));
                t.Add(("3^3", () => PracticeTestRunner.AssertEqual(27L, TOPPrograms.IntegerPow(3, 3))));
                t.Add(("10^6", () => PracticeTestRunner.AssertEqual(1_000_000L, TOPPrograms.IntegerPow(10, 6))));
            });

        public static PracticeTestRunner.SuiteResult TestDetectIntegerOverflowOnAdd() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.DetectIntegerOverflowOnAdd), t =>
            {
                t.Add(("normal", () => PracticeTestRunner.AssertFalse(TOPPrograms.DetectIntegerOverflowOnAdd(100, 200))));
                t.Add(("max boundary", () => PracticeTestRunner.AssertTrue(TOPPrograms.DetectIntegerOverflowOnAdd(int.MaxValue, 1))));
                t.Add(("min boundary", () => PracticeTestRunner.AssertTrue(TOPPrograms.DetectIntegerOverflowOnAdd(int.MinValue, -1))));
                t.Add(("zero", () => PracticeTestRunner.AssertFalse(TOPPrograms.DetectIntegerOverflowOnAdd(0, 0))));
            });

        public static PracticeTestRunner.SuiteResult TestDecimalToDoublePrecisionLoss() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.DecimalToDoublePrecisionLoss), t =>
            {
                t.Add(("0.1m loses precision", () => PracticeTestRunner.AssertTrue(TOPPrograms.DecimalToDoublePrecisionLoss(0.1m))));
                t.Add(("1m exact", () => PracticeTestRunner.AssertFalse(TOPPrograms.DecimalToDoublePrecisionLoss(1m))));
                t.Add(("large decimal", () => PracticeTestRunner.AssertTrue(TOPPrograms.DecimalToDoublePrecisionLoss(79228162514264337593543950335m))));
            });

        public static PracticeTestRunner.SuiteResult TestCurrencyRounding() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.CurrencyRounding), t =>
            {
                t.Add(("half up", () => PracticeTestRunner.AssertEqual(1.23m, TOPPrograms.CurrencyRounding(1.234m))));
                t.Add(("truncate down", () => PracticeTestRunner.AssertEqual(1.23m, TOPPrograms.CurrencyRounding(1.231m))));
                t.Add(("whole", () => PracticeTestRunner.AssertEqual(10.00m, TOPPrograms.CurrencyRounding(10m))));
                t.Add(("negative", () => PracticeTestRunner.AssertEqual(-1.23m, TOPPrograms.CurrencyRounding(-1.234m))));
            });

        // ── 2. Strings ──────────────────────────────────────────────────────

        public static List<PracticeTestRunner.SuiteResult> RunSection2_Strings() => new()
        {
            TestReverseStringManually(),
            TestIsStringPalindrome(),
            TestCountCharacterOccurrences(),
            TestFirstNonRepeatingCharacter(),
            TestAreAnagrams(),
            TestCustomStringTrim(),
            TestHasBalancedParentheses(),
            TestCompressString(),
            TestLongestCommonSubstringOrPrefix(),
            TestSplitOnMultipleDelimiters(),
        };

        public static PracticeTestRunner.SuiteResult TestReverseStringManually() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.ReverseStringManually), t =>
            {
                t.Add(("hello", () => PracticeTestRunner.AssertEqual("olleh", TOPPrograms.ReverseStringManually("hello"))));
                t.Add(("empty", () => PracticeTestRunner.AssertEqual("", TOPPrograms.ReverseStringManually(""))));
                t.Add(("single", () => PracticeTestRunner.AssertEqual("a", TOPPrograms.ReverseStringManually("a"))));
                t.Add(("palindrome", () => PracticeTestRunner.AssertEqual("aba", TOPPrograms.ReverseStringManually("aba"))));
            });

        public static PracticeTestRunner.SuiteResult TestIsStringPalindrome() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.IsStringPalindrome), t =>
            {
                t.Add(("racecar", () => PracticeTestRunner.AssertTrue(TOPPrograms.IsStringPalindrome("racecar"))));
                t.Add(("hello", () => PracticeTestRunner.AssertFalse(TOPPrograms.IsStringPalindrome("hello"))));
                t.Add(("empty", () => PracticeTestRunner.AssertTrue(TOPPrograms.IsStringPalindrome(""))));
                t.Add(("single", () => PracticeTestRunner.AssertTrue(TOPPrograms.IsStringPalindrome("x"))));
            });

        public static PracticeTestRunner.SuiteResult TestCountCharacterOccurrences() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.CountCharacterOccurrences), t =>
            {
                t.Add(("mississippi s", () => PracticeTestRunner.AssertEqual(4, TOPPrograms.CountCharacterOccurrences("mississippi", 's'))));
                t.Add(("none", () => PracticeTestRunner.AssertEqual(0, TOPPrograms.CountCharacterOccurrences("hello", 'z'))));
                t.Add(("all same", () => PracticeTestRunner.AssertEqual(5, TOPPrograms.CountCharacterOccurrences("aaaaa", 'a'))));
            });

        public static PracticeTestRunner.SuiteResult TestFirstNonRepeatingCharacter() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.FirstNonRepeatingCharacter), t =>
            {
                t.Add(("leetcode", () => PracticeTestRunner.AssertEqual('l', TOPPrograms.FirstNonRepeatingCharacter("leetcode"))));
                t.Add(("aabb", () => PracticeTestRunner.AssertEqual(null, TOPPrograms.FirstNonRepeatingCharacter("aabb"))));
                t.Add(("abcabc", () => PracticeTestRunner.AssertEqual(null, TOPPrograms.FirstNonRepeatingCharacter("abcabc"))));
                t.Add(("stress", () => PracticeTestRunner.AssertEqual('t', TOPPrograms.FirstNonRepeatingCharacter("stress"))));
            });

        public static PracticeTestRunner.SuiteResult TestAreAnagrams() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.AreAnagrams), t =>
            {
                t.Add(("listen silent", () => PracticeTestRunner.AssertTrue(TOPPrograms.AreAnagrams("listen", "silent"))));
                t.Add(("hello bello", () => PracticeTestRunner.AssertFalse(TOPPrograms.AreAnagrams("hello", "bello"))));
                t.Add(("empty", () => PracticeTestRunner.AssertTrue(TOPPrograms.AreAnagrams("", ""))));
                t.Add(("case sensitive", () => PracticeTestRunner.AssertFalse(TOPPrograms.AreAnagrams("Abc", "abc"))));
            });

        public static PracticeTestRunner.SuiteResult TestCustomStringTrim() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.CustomStringTrim), t =>
            {
                t.Add(("spaces", () => PracticeTestRunner.AssertEqual("hello", TOPPrograms.CustomStringTrim("  hello  "))));
                t.Add(("custom chars", () => PracticeTestRunner.AssertEqual("hello", TOPPrograms.CustomStringTrim("xxhelloxx", new[] { 'x' }))));
                t.Add(("already trimmed", () => PracticeTestRunner.AssertEqual("hi", TOPPrograms.CustomStringTrim("hi"))));
            });

        public static PracticeTestRunner.SuiteResult TestHasBalancedParentheses() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.HasBalancedParentheses), t =>
            {
                t.Add(("()[]{}", () => PracticeTestRunner.AssertTrue(TOPPrograms.HasBalancedParentheses("()[]{}"))));
                t.Add(("(]", () => PracticeTestRunner.AssertFalse(TOPPrograms.HasBalancedParentheses("(]"))));
                t.Add(("([)]", () => PracticeTestRunner.AssertFalse(TOPPrograms.HasBalancedParentheses("([)]"))));
                t.Add(("{[]}", () => PracticeTestRunner.AssertTrue(TOPPrograms.HasBalancedParentheses("{[]}"))));
                t.Add(("empty", () => PracticeTestRunner.AssertTrue(TOPPrograms.HasBalancedParentheses(""))));
            });

        public static PracticeTestRunner.SuiteResult TestCompressString() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.CompressString), t =>
            {
                t.Add(("aabcccccaaa", () => PracticeTestRunner.AssertEqual("a2b1c5a3", TOPPrograms.CompressString("aabcccccaaa"))));
                t.Add(("abc", () => PracticeTestRunner.AssertEqual("abc", TOPPrograms.CompressString("abc"))));
                t.Add(("aaaa", () => PracticeTestRunner.AssertEqual("a4", TOPPrograms.CompressString("aaaa"))));
            });

        public static PracticeTestRunner.SuiteResult TestLongestCommonSubstringOrPrefix() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.LongestCommonSubstringOrPrefix), t =>
            {
                t.Add(("prefix", () => PracticeTestRunner.AssertEqual("fl", TOPPrograms.LongestCommonSubstringOrPrefix(new[] { "flower", "flow", "flight" }))));
                t.Add(("single", () => PracticeTestRunner.AssertEqual("dog", TOPPrograms.LongestCommonSubstringOrPrefix(new[] { "dog" }))));
                t.Add(("none", () => PracticeTestRunner.AssertEqual("", TOPPrograms.LongestCommonSubstringOrPrefix(new[] { "abc", "def", "ghi" }))));
            });

        public static PracticeTestRunner.SuiteResult TestSplitOnMultipleDelimiters() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.SplitOnMultipleDelimiters), t =>
            {
                t.Add(("comma semicolon", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { "a", "b", "c" }, TOPPrograms.SplitOnMultipleDelimiters("a,b;c", new[] { ',', ';' }))));
                t.Add(("multiple delimiters", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { "hello", "world" }, TOPPrograms.SplitOnMultipleDelimiters("hello,,,world", new[] { ',' }))));
            });

        // ── 3. Arrays ───────────────────────────────────────────────────────

        public static List<PracticeTestRunner.SuiteResult> RunSection3_Arrays() => new()
        {
            TestFindDuplicatesInArray(),
            TestFindMissingNumber(),
            TestRotateArray(),
            TestSecondLargestWithoutSorting(),
            TestMergeSortedArrays(),
            TestArrayIntersection(),
            TestFlattenJaggedArray(),
            TestFindPairsThatSumToTarget(),
            TestMaxSubarraySumKadane(),
        };

        public static PracticeTestRunner.SuiteResult TestFindDuplicatesInArray() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.FindDuplicatesInArray), t =>
            {
                t.Add(("basic", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { 2, 3 }, TOPPrograms.FindDuplicatesInArray(new[] { 1, 2, 3, 2, 3, 4 }).OrderBy(x => x))));
                t.Add(("none", () => PracticeTestRunner.AssertSequenceEqual(
                    Array.Empty<int>(), TOPPrograms.FindDuplicatesInArray(new[] { 1, 2, 3 }))));
            });

        public static PracticeTestRunner.SuiteResult TestFindMissingNumber() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.FindMissingNumber), t =>
            {
                t.Add(("missing 2", () => PracticeTestRunner.AssertEqual(2, TOPPrograms.FindMissingNumber(new[] { 1, 3, 4, 5 }, 5))));
                t.Add(("missing 5", () => PracticeTestRunner.AssertEqual(5, TOPPrograms.FindMissingNumber(new[] { 1, 2, 3, 4 }, 5))));
                t.Add(("missing 1", () => PracticeTestRunner.AssertEqual(1, TOPPrograms.FindMissingNumber(new[] { 2, 3 }, 3))));
            });

        public static PracticeTestRunner.SuiteResult TestRotateArray() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.RotateArray), t =>
            {
                t.Add(("k=1", () =>
                {
                    var arr = new[] { 1, 2, 3, 4, 5 };
                    TOPPrograms.RotateArray(arr, 1);
                    PracticeTestRunner.AssertSequenceEqual(new[] { 5, 1, 2, 3, 4 }, arr);
                }));
                t.Add(("k=2", () =>
                {
                    var arr = new[] { 1, 2, 3, 4, 5 };
                    TOPPrograms.RotateArray(arr, 2);
                    PracticeTestRunner.AssertSequenceEqual(new[] { 4, 5, 1, 2, 3 }, arr);
                }));
                t.Add(("k > length", () =>
                {
                    var arr = new[] { 1, 2, 3 };
                    TOPPrograms.RotateArray(arr, 4);
                    PracticeTestRunner.AssertSequenceEqual(new[] { 3, 1, 2 }, arr);
                }));
            });

        public static PracticeTestRunner.SuiteResult TestSecondLargestWithoutSorting() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.SecondLargestWithoutSorting), t =>
            {
                t.Add(("basic", () => PracticeTestRunner.AssertEqual(8, TOPPrograms.SecondLargestWithoutSorting(new[] { 10, 5, 8, 20 }))));
                t.Add(("duplicates", () => PracticeTestRunner.AssertEqual(8, TOPPrograms.SecondLargestWithoutSorting(new[] { 10, 10, 8, 8 }))));
                t.Add(("two elements", () => PracticeTestRunner.AssertEqual(3, TOPPrograms.SecondLargestWithoutSorting(new[] { 5, 3 }))));
            });

        public static PracticeTestRunner.SuiteResult TestMergeSortedArrays() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.MergeSortedArrays), t =>
            {
                t.Add(("basic", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4, 5, 6 }, TOPPrograms.MergeSortedArrays(new[] { 1, 3, 5 }, new[] { 2, 4, 6 }))));
                t.Add(("one empty", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { 1, 2 }, TOPPrograms.MergeSortedArrays(new[] { 1, 2 }, Array.Empty<int>()))));
            });

        public static PracticeTestRunner.SuiteResult TestArrayIntersection() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.ArrayIntersection), t =>
            {
                t.Add(("basic", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { 2, 4 }, TOPPrograms.ArrayIntersection(new[] { 1, 2, 3, 4 }, new[] { 2, 4, 6 }).OrderBy(x => x))));
                t.Add(("no overlap", () => PracticeTestRunner.AssertSequenceEqual(
                    Array.Empty<int>(), TOPPrograms.ArrayIntersection(new[] { 1, 2 }, new[] { 3, 4 }))));
            });

        public static PracticeTestRunner.SuiteResult TestFlattenJaggedArray() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.FlattenJaggedArray), t =>
            {
                t.Add(("basic", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4, 5 }, TOPPrograms.FlattenJaggedArray(new[] { new[] { 1, 2 }, new[] { 3 }, new[] { 4, 5 } }))));
                t.Add(("empty inner", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { 1 }, TOPPrograms.FlattenJaggedArray(new[] { Array.Empty<int>(), new[] { 1 } }))));
            });

        public static PracticeTestRunner.SuiteResult TestFindPairsThatSumToTarget() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.FindPairsThatSumToTarget), t =>
            {
                t.Add(("basic", () =>
                {
                    var pairs = TOPPrograms.FindPairsThatSumToTarget(new[] { 1, 2, 3, 4, 5 }, 6);
                    PracticeTestRunner.AssertTrue(pairs.Any(p => (p.A == 1 && p.B == 5) || (p.A == 5 && p.B == 1)));
                    PracticeTestRunner.AssertTrue(pairs.Any(p => (p.A == 2 && p.B == 4) || (p.A == 4 && p.B == 2)));
                }));
                t.Add(("none", () => PracticeTestRunner.AssertEqual(0, TOPPrograms.FindPairsThatSumToTarget(new[] { 1, 2 }, 10).Count)));
            });

        public static PracticeTestRunner.SuiteResult TestMaxSubarraySumKadane() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.MaxSubarraySumKadane), t =>
            {
                t.Add(("classic", () => PracticeTestRunner.AssertEqual(6, TOPPrograms.MaxSubarraySumKadane(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }))));
                t.Add(("all negative", () => PracticeTestRunner.AssertEqual(-1, TOPPrograms.MaxSubarraySumKadane(new[] { -2, -3, -1 }))));
                t.Add(("single", () => PracticeTestRunner.AssertEqual(5, TOPPrograms.MaxSubarraySumKadane(new[] { 5 }))));
            });

        // ── 4. LINQ ─────────────────────────────────────────────────────────

        public static List<PracticeTestRunner.SuiteResult> RunSection4_Linq() => new()
        {
            TestGroupEmployeesByDepartmentAverageSalary(),
            TestAggregateRunningTotalAndReverseString(),
            TestFindDuplicateObjectsWithComparer(),
            TestGroupByToDictionary(),
            TestSelectManyFlatten(),
            TestPaginateEnumerable(),
            TestJoinAndGroupJoinDemo(),
        };

        public static PracticeTestRunner.SuiteResult TestGroupEmployeesByDepartmentAverageSalary() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.GroupEmployeesByDepartmentAverageSalary), t =>
            {
                t.Add(("averages", () =>
                {
                    var data = new[]
                    {
                        ("Alice", "IT", 100m), ("Bob", "IT", 200m), ("Carol", "HR", 150m)
                    };
                    var result = TOPPrograms.GroupEmployeesByDepartmentAverageSalary(data);
                    PracticeTestRunner.AssertEqual(150m, result["IT"]);
                    PracticeTestRunner.AssertEqual(150m, result["HR"]);
                }));
            });

        public static PracticeTestRunner.SuiteResult TestAggregateRunningTotalAndReverseString() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.AggregateRunningTotalAndReverseString), t =>
            {
                t.Add(("running total", () =>
                {
                    var items = new[] { (10, "ab"), (20, "cd") };
                    var result = TOPPrograms.AggregateRunningTotalAndReverseString(items);
                    PracticeTestRunner.AssertEqual(10, result[0].RunningTotal);
                    PracticeTestRunner.AssertEqual("ba", result[0].ReversedName);
                    PracticeTestRunner.AssertEqual(30, result[1].RunningTotal);
                    PracticeTestRunner.AssertEqual("dc", result[1].ReversedName);
                }));
            });

        public static PracticeTestRunner.SuiteResult TestFindDuplicateObjectsWithComparer() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.FindDuplicateObjectsWithComparer), t =>
            {
                t.Add(("duplicates", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { "a", "b" }, TOPPrograms.FindDuplicateObjectsWithComparer(new[] { "a", "b", "a", "c", "b", "d" }).OrderBy(x => x))));
            });

        public static PracticeTestRunner.SuiteResult TestGroupByToDictionary() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.GroupByToDictionary), t =>
            {
                t.Add(("first letter", () =>
                {
                    var result = TOPPrograms.GroupByToDictionary(new[] { "Amy", "Bob", "Anna" });
                    PracticeTestRunner.AssertSequenceEqual(new[] { "Amy", "Anna" }, result['A'].OrderBy(x => x));
                    PracticeTestRunner.AssertSequenceEqual(new[] { "Bob" }, result['B']);
                }));
            });

        public static PracticeTestRunner.SuiteResult TestSelectManyFlatten() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.SelectManyFlatten), t =>
            {
                t.Add(("flatten", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4 }, TOPPrograms.SelectManyFlatten(new[] { new[] { 1, 2 }, new[] { 3, 4 } }))));
            });

        public static PracticeTestRunner.SuiteResult TestPaginateEnumerable() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.PaginateEnumerable), t =>
            {
                t.Add(("page 0", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3 }, TOPPrograms.PaginateEnumerable(Enumerable.Range(1, 10), 3, 0))));
                t.Add(("page 1", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { 4, 5, 6 }, TOPPrograms.PaginateEnumerable(Enumerable.Range(1, 10), 3, 1))));
                t.Add(("partial last page", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { 10 }, TOPPrograms.PaginateEnumerable(Enumerable.Range(1, 10), 3, 3))));
            });

        public static PracticeTestRunner.SuiteResult TestJoinAndGroupJoinDemo() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.JoinAndGroupJoinDemo), t =>
            {
                t.Add(("inner join", () =>
                {
                    var people = new[] { (1, "Alice", 10), (2, "Bob", 20), (3, "Zoe", 99) };
                    var depts = new[] { (10, "IT"), (20, "HR") };
                    var result = TOPPrograms.JoinAndGroupJoinDemo(people, depts);
                    PracticeTestRunner.AssertTrue(result.Contains("Alice - IT"));
                    PracticeTestRunner.AssertTrue(result.Contains("Bob - HR"));
                    PracticeTestRunner.AssertFalse(result.Any(s => s.Contains("Zoe")));
                }));
            });

        // ── 13. Collections ─────────────────────────────────────────────────

        public static List<PracticeTestRunner.SuiteResult> RunSection13_Collections() => new()
        {
            TestDictionaryLookupMissingKey(),
            TestHashSetRemoveDuplicates(),
            TestCustomEqualityComparer(),
            TestBinarySearchRequiresSorted(),
            TestListContainsVsHashSetContains(),
            TestCustomEnumerableWithYield(),
            TestListCapacityVsCount(),
            TestImmutableCollections(),
            TestPriorityQueue(),
            TestArraySortMultiField(),
            TestLruCache(),
        };

        public static PracticeTestRunner.SuiteResult TestDictionaryLookupMissingKey() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.DictionaryLookupMissingKey), t =>
            {
                t.Add(("found", () =>
                {
                    var map = new Dictionary<int, string> { [1] = "one", [2] = "two" };
                    PracticeTestRunner.AssertEqual(3, TOPPrograms.DictionaryLookupMissingKey(map, 1)); // length of "one"
                }));
                t.Add(("missing", () =>
                {
                    var map = new Dictionary<int, string> { [1] = "one" };
                    PracticeTestRunner.AssertEqual(-1, TOPPrograms.DictionaryLookupMissingKey(map, 99));
                }));
            });

        public static PracticeTestRunner.SuiteResult TestHashSetRemoveDuplicates() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.HashSetRemoveDuplicates), t =>
            {
                t.Add(("dedupe", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { "a", "b", "c" }, TOPPrograms.HashSetRemoveDuplicates(new[] { "a", "b", "a", "c", "b" }).OrderBy(x => x))));
            });

        public static PracticeTestRunner.SuiteResult TestCustomEqualityComparer() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.CustomEqualityComparer), t =>
            {
                t.Add(("ignore case equal", () => PracticeTestRunner.AssertTrue(TOPPrograms.CustomEqualityComparer("Hello", "hello"))));
                t.Add(("different", () => PracticeTestRunner.AssertFalse(TOPPrograms.CustomEqualityComparer("Hello", "world"))));
            });

        public static PracticeTestRunner.SuiteResult TestBinarySearchRequiresSorted() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.BinarySearchRequiresSorted), t =>
            {
                t.Add(("found", () => PracticeTestRunner.AssertEqual(2, TOPPrograms.BinarySearchRequiresSorted(new[] { 1, 3, 5, 7, 9 }, 5))));
                t.Add(("not found", () => PracticeTestRunner.AssertEqual(-1, TOPPrograms.BinarySearchRequiresSorted(new[] { 1, 3, 5 }, 4))));
            });

        public static PracticeTestRunner.SuiteResult TestListContainsVsHashSetContains() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.ListContainsVsHashSetContains), t =>
            {
                t.Add(("both contain", () =>
                {
                    var (listOk, setOk) = TOPPrograms.ListContainsVsHashSetContains(
                        new List<int> { 1, 2, 3 }, new HashSet<int> { 1, 2, 3 }, 2);
                    PracticeTestRunner.AssertTrue(listOk);
                    PracticeTestRunner.AssertTrue(setOk);
                }));
                t.Add(("neither contain", () =>
                {
                    var (listOk, setOk) = TOPPrograms.ListContainsVsHashSetContains(
                        new List<int> { 1, 2, 3 }, new HashSet<int> { 1, 2, 3 }, 99);
                    PracticeTestRunner.AssertFalse(listOk);
                    PracticeTestRunner.AssertFalse(setOk);
                }));
            });

        public static PracticeTestRunner.SuiteResult TestCustomEnumerableWithYield() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.CustomEnumerableWithYield), t =>
            {
                t.Add(("range", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { 0, 1, 2, 3, 4 }, TOPPrograms.CustomEnumerableWithYield(0, 5))));
            });

        public static PracticeTestRunner.SuiteResult TestListCapacityVsCount() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.ListCapacityVsCount), t =>
            {
                t.Add(("defaults", () =>
                {
                    var (count, capacity) = TOPPrograms.ListCapacityVsCount(new List<int> { 1, 2, 3 });
                    PracticeTestRunner.AssertEqual(3, count);
                    PracticeTestRunner.AssertTrue(capacity >= 3);
                }));
            });

        public static PracticeTestRunner.SuiteResult TestImmutableCollections() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.ImmutableCollections), t =>
            {
                t.Add(("immutable list", () =>
                {
                    var original = new[] { 1, 2, 3 };
                    var immutable = TOPPrograms.ImmutableCollections(original);
                    PracticeTestRunner.AssertSequenceEqual(original, immutable);
                    PracticeTestRunner.AssertTrue(immutable is IReadOnlyList<int>);
                }));
            });

        public static PracticeTestRunner.SuiteResult TestPriorityQueue() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.PriorityQueue), t =>
            {
                t.Add(("min heap order", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4 }, TOPPrograms.PriorityQueue(new[] { 3, 1, 4, 2 }))));
            });

        public static PracticeTestRunner.SuiteResult TestArraySortMultiField() =>
            PracticeTestRunner.Run(nameof(TOPPrograms.ArraySortMultiField), t =>
            {
                t.Add(("age then name", () => PracticeTestRunner.AssertSequenceEqual(
                    new[] { "Amy:20", "Bob:20", "Cal:30" },
                    TOPPrograms.ArraySortMultiField(new[] { ("Bob", 20), ("Cal", 30), ("Amy", 20) }))));
            });

        public static PracticeTestRunner.SuiteResult TestLruCache() =>
            PracticeTestRunner.Run("LruCache", t =>
            {
                t.Add(("get put", () =>
                {
                    var cache = new TOPPrograms.LruCache(2);
                    cache.Put(1, 1);
                    cache.Put(2, 2);
                    PracticeTestRunner.AssertEqual(1, cache.Get(1));
                    cache.Put(3, 3);
                    PracticeTestRunner.AssertEqual(null, cache.Get(2));
                    PracticeTestRunner.AssertEqual(3, cache.Get(3));
                }));
                t.Add(("evict lru", () =>
                {
                    var cache = new TOPPrograms.LruCache(2);
                    cache.Put(1, 1);
                    cache.Put(2, 2);
                    cache.Get(1);
                    cache.Put(3, 3);
                    PracticeTestRunner.AssertEqual(null, cache.Get(2));
                    PracticeTestRunner.AssertEqual(1, cache.Get(1));
                }));
            });
    }
}
