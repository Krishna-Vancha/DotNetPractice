using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.CSharpPractise.DataStructures.Strings;

/// <summary>
/// Parameterless runners for <see cref="StringEntryLevelPractice"/> — each call exercises the target with fixed cases and prints PASS/FAIL.
/// </summary>
public static class StringEntryLevelPracticeRunners
{
    public static void RunCharacterFrequency()
    {
        Console.WriteLine("=== 1. CharacterFrequency ===");
        ExpectDict("empty string", "", new Dictionary<char, int>());
        ExpectDict("aabc", "aabc", new Dictionary<char, int> { ['a'] = 2, ['b'] = 1, ['c'] = 1 });
        ExpectDict("aba", "aba", new Dictionary<char, int> { ['a'] = 2, ['b'] = 1 });
    }

    public static void RunFirstNonRepeatingCharacterIndex()
    {
        Console.WriteLine("=== 2. FirstNonRepeatingCharacterIndex ===");
        var p = new StringEntryLevelPractice();
        ExpectInt("no unique (aabb)", s => p.FirstNonRepeatingCharacterIndex(s), "aabb", -1);
        ExpectInt("first is unique (sad)", s => p.FirstNonRepeatingCharacterIndex(s), "sad", 0);
        ExpectInt("leetcode", s => p.FirstNonRepeatingCharacterIndex(s), "leetcode", 0);
    }

    public static void RunAreAnagrams()
    {
        Console.WriteLine("=== 3. AreAnagrams ===");
        ExpectBool("anagram / nagaram", (a, b) => StringEntryLevelPractice.AreAnagrams(a, b), "anagram", "nagaram", true);
        ExpectBool("rat / car", (a, b) => StringEntryLevelPractice.AreAnagrams(a, b), "rat", "car", false);
        ExpectBool("empty / empty", (a, b) => StringEntryLevelPractice.AreAnagrams(a, b), "", "", true);
    }

    /// <summary>Tests: default = case-sensitive, only letters (no space/punctuation strip).</summary>
    public static void RunIsPalindrome()
    {
        Console.WriteLine("=== 4. IsPalindrome (simple: exact chars, case-sensitive) ===");
        ExpectBool("aba", s => StringEntryLevelPractice.IsPalindrome(s), "aba", true);
        ExpectBool("ab", s => StringEntryLevelPractice.IsPalindrome(s), "ab", false);
        ExpectBool("empty", s => StringEntryLevelPractice.IsPalindrome(s), "", true);
    }

    public static void RunReverseWords()
    {
        Console.WriteLine("=== 5. ReverseWords ===");
        ExpectString("hello world", s => StringEntryLevelPractice.ReverseWords(s), "hello world", "world hello");
        ExpectString("single", s => StringEntryLevelPractice.ReverseWords(s), "x", "x");
        ExpectString("a b c", s => StringEntryLevelPractice.ReverseWords(s), "a b c", "c b a");
    }

    public static void RunReverseCharArrayInPlace()
    {
        Console.WriteLine("=== 6. ReverseCharArrayInPlace ===");
        ExpectCharArray("hello", "hello".ToCharArray(), "olleh".ToCharArray());
        ExpectCharArray("a", "a".ToCharArray(), "a".ToCharArray());
        ExpectCharArray("ab", "ab".ToCharArray(), "ba".ToCharArray());
    }

    public static void RunCompressString()
    {
        Console.WriteLine("=== 7. CompressString (return original if not strictly shorter) ===");
        ExpectString("aabcccccaaa", s => StringEntryLevelPractice.CompressString(s), "aabcccccaaa", "a2b1c5a3");
        ExpectString("abc not shorter", s => StringEntryLevelPractice.CompressString(s), "abc", "abc");
        ExpectString("single a", s => StringEntryLevelPractice.CompressString(s), "a", "a");
    }

    public static void RunStrStr()
    {
        Console.WriteLine("=== 8. StrStr (first index of needle) ===");
        ExpectInt("hello, ll", (h, n) => StringEntryLevelPractice.StrStr(h, n), "hello", "ll", 2);
        ExpectInt("aaaa, bba", (h, n) => StringEntryLevelPractice.StrStr(h, n), "aaaa", "bba", -1);
        ExpectInt("mississippi, issi", (h, n) => StringEntryLevelPractice.StrStr(h, n), "mississippi", "issi", 4);
    }

    public static void RunHasBalancedParentheses()
    {
        Console.WriteLine("=== 9. HasBalancedParentheses ===");
        ExpectBool("()", s => StringEntryLevelPractice.HasBalancedParentheses(s), "()", true);
        ExpectBool("([)]", s => StringEntryLevelPractice.HasBalancedParentheses(s), "([)]", false);
        ExpectBool("([{}])", s => StringEntryLevelPractice.HasBalancedParentheses(s), "([{}])", true);
    }

    public static void RunRomanToInt()
    {
        Console.WriteLine("=== 10. RomanToInt ===");
        ExpectInt("III", s => StringEntryLevelPractice.RomanToInt(s), "III", 3);
        ExpectInt("IV", s => StringEntryLevelPractice.RomanToInt(s), "IV", 4);
        ExpectInt("MCMXCIV", s => StringEntryLevelPractice.RomanToInt(s), "MCMXCIV", 1994);
    }

    public static void RunIntToRoman()
    {
        Console.WriteLine("=== 11. IntToRoman ===");
        ExpectString("3", n => StringEntryLevelPractice.IntToRoman(n), 3, "III");
        ExpectString("4", n => StringEntryLevelPractice.IntToRoman(n), 4, "IV");
        ExpectString("1994", n => StringEntryLevelPractice.IntToRoman(n), 1994, "MCMXCIV");
    }

    public static void RunLongestCommonPrefix()
    {
        Console.WriteLine("=== 12. LongestCommonPrefix ===");
        ExpectLcp("flower, flow, flight", new[] { "flower", "flow", "flight" }, "fl");
        ExpectLcp("no common", new[] { "dog", "racecar", "car" }, "");
        ExpectLcp("single", new[] { "alone" }, "alone");
    }

    /// <summary>Run every exercise in order; stops printing each section’s failures in detail.</summary>
    public static void RunAll()
    {
        RunCharacterFrequency();
        RunFirstNonRepeatingCharacterIndex();
        RunAreAnagrams();
        RunIsPalindrome();
        RunReverseWords();
        RunReverseCharArrayInPlace();
        RunCompressString();
        RunStrStr();
        RunHasBalancedParentheses();
        RunRomanToInt();
        RunIntToRoman();
        RunLongestCommonPrefix();
    }

    // --- validation helpers ---

    private static void ExpectDict(string label, string input, IReadOnlyDictionary<char, int> expected)
    {
        try
        {
            var actual = StringEntryLevelPractice.CharacterFrequency(input);
            bool ok = DictEqual(actual, expected);
            Console.WriteLine(ok ? $"  PASS  [{label}]" : $"  FAIL  [{label}]  expected: {FormatDict(expected)}  got: {FormatDict(actual)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  FAIL  [{label}]  exception: {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ExpectInt(string label, Func<string, int> fn, string s, int expected)
    {
        try
        {
            int actual = fn(s);
            bool ok = actual == expected;
            Console.WriteLine(ok ? $"  PASS  [{label}]" : $"  FAIL  [{label}]  expected: {expected}  got: {actual}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  FAIL  [{label}]  exception: {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ExpectInt(string label, Func<string, string, int> fn, string a, string b, int expected)
    {
        try
        {
            int actual = fn(a, b);
            bool ok = actual == expected;
            Console.WriteLine(ok ? $"  PASS  [{label}]" : $"  FAIL  [{label}]  expected: {expected}  got: {actual}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  FAIL  [{label}]  exception: {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ExpectString(string label, Func<string, string> fn, string input, string expected)
    {
        try
        {
            var actual = fn(input);
            bool ok = string.Equals(expected, actual, StringComparison.Ordinal);
            Console.WriteLine(ok ? $"  PASS  [{label}]" : $"  FAIL  [{label}]  expected: \"{expected}\"  got: \"{actual}\"");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  FAIL  [{label}]  exception: {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ExpectString(string label, Func<int, string> fn, int input, string expected)
    {
        try
        {
            var actual = fn(input);
            bool ok = string.Equals(expected, actual, StringComparison.Ordinal);
            Console.WriteLine(ok ? $"  PASS  [{label}]" : $"  FAIL  [{label}]  expected: \"{expected}\"  got: \"{actual}\"");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  FAIL  [{label}]  exception: {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ExpectBool(string label, Func<string, bool> fn, string s, bool expected)
    {
        try
        {
            bool actual = fn(s);
            bool ok = actual == expected;
            Console.WriteLine(ok ? $"  PASS  [{label}]" : $"  FAIL  [{label}]  expected: {expected}  got: {actual}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  FAIL  [{label}]  exception: {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ExpectBool(string label, Func<string, string, bool> fn, string a, string b, bool expected)
    {
        try
        {
            bool actual = fn(a, b);
            bool ok = actual == expected;
            Console.WriteLine(ok ? $"  PASS  [{label}]" : $"  FAIL  [{label}]  expected: {expected}  got: {actual}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  FAIL  [{label}]  exception: {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ExpectCharArray(string label, char[] work, char[] expectedAfter)
    {
        try
        {
            StringEntryLevelPractice.ReverseCharArrayInPlace(work);
            bool ok = work.Length == expectedAfter.Length && work.AsSpan().SequenceEqual(expectedAfter);
            if (ok)
                Console.WriteLine($"  PASS  [{label}]");
            else
                Console.WriteLine($"  FAIL  [{label}]  expected chars: {new string(expectedAfter)}  got: {new string(work)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  FAIL  [{label}]  exception: {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ExpectLcp(string label, string[] strs, string expected)
    {
        try
        {
            var actual = StringEntryLevelPractice.LongestCommonPrefix(strs);
            bool ok = string.Equals(expected, actual, StringComparison.Ordinal);
            Console.WriteLine(ok ? $"  PASS  [{label}]" : $"  FAIL  [{label}]  expected: \"{expected}\"  got: \"{actual}\"");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  FAIL  [{label}]  exception: {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static bool DictEqual(Dictionary<char, int>? a, IReadOnlyDictionary<char, int> b)
    {
        if (a is null) return false;
        if (a.Count != b.Count) return false;
        foreach (var kv in a)
        {
            if (!b.TryGetValue(kv.Key, out int v) || v != kv.Value)
                return false;
        }
        return true;
    }

    private static string FormatDict(IReadOnlyDictionary<char, int> d) =>
        "{" + string.Join(", ", d.OrderBy(x => x.Key).Select(x => $"'{x.Key}':{x.Value}")) + "}";
}
