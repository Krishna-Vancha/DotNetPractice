using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.Strings;

/// <summary>
/// Test cases for PYnative String Exercises — https://pynative.com/csharp-string-exercises/
/// </summary>
public static class StringExerciseTests
{
    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_LengthWithoutProperty(),
        2 => Test02_Reverse(),
        3 => Test03_SeparateCharactersWithSpaces(),
        4 => Test04_CountVowelsAndConsonants(),
        5 => Test05_CountCharacterTypes(),
        6 => Test06_ToggleCase(),
        7 => Test07_CountWords(),
        8 => Test08_ContainsSubstring(),
        9 => Test09_TrimManual(),
        10 => Test10_AreEqualManual(),
        11 => Test11_ReverseWordOrder(),
        12 => Test12_CharacterFrequency(),
        13 => Test13_MostFrequentCharacter(),
        14 => Test14_ExtractSubstring(),
        15 => Test15_SortCharactersAlphabetically(),
        16 => Test16_RemoveDuplicateCharacters(),
        17 => Test17_ToTitleCase(),
        18 => Test18_IsPalindrome(),
        19 => Test19_AreAnagrams(),
        20 => Test20_PadLeftAndRight(),
        21 => Test21_GetAllSubstrings(),
        22 => Test22_LongestCommonPrefix(),
        23 => Test23_FirstNonRepeatedCharacter(),
        24 => Test24_ParseIntManual(),
        25 => Test25_RunLengthEncode(),
        26 => Test26_IsValidParentheses(),
        27 => Test27_UrlEncodeSpaces(),
        28 => Test28_IsRotation(),
        29 => Test29_CaesarCipher(),
        30 => Test30_LongestSubstringWithoutRepeating(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "String exercises are numbered 1–30.")
    };

    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 30; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative — String Exercises (30)", results);
    }

    public static PynativeExerciseRunner.SuiteResult Test01_LengthWithoutProperty() =>
        PynativeExerciseRunner.Run(1, "Length Calculator",
            "Find the length of a string without using the built-in .Length property.",
            t =>
            {
                t.Add(("input \"Programming\" -> expected 11", () =>
                    PynativeExerciseRunner.AssertEqual(11, () => StringExercises.LengthWithoutProperty("Programming"))));
                t.Add(("input \"hello\" -> expected 5", () =>
                    PynativeExerciseRunner.AssertEqual(5, () => StringExercises.LengthWithoutProperty("hello"))));
                t.Add(("input \"\" -> expected 0", () =>
                    PynativeExerciseRunner.AssertEqual(0, () => StringExercises.LengthWithoutProperty(""))));
            });

    public static PynativeExerciseRunner.SuiteResult Test02_Reverse() =>
        PynativeExerciseRunner.Run(2, "Reverse a String",
            "Accept a string and print it in reverse order.",
            t =>
            {
                t.Add(("input \"hello\" -> expected \"olleh\"", () =>
                    PynativeExerciseRunner.AssertEqual("olleh", () => StringExercises.Reverse("hello"))));
                t.Add(("input \"Code\" -> expected \"edoC\"", () =>
                    PynativeExerciseRunner.AssertEqual("edoC", () => StringExercises.Reverse("Code"))));
                t.Add(("input \"a\" -> expected \"a\"", () =>
                    PynativeExerciseRunner.AssertEqual("a", () => StringExercises.Reverse("a"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test03_SeparateCharactersWithSpaces() =>
        PynativeExerciseRunner.Run(3, "Character Separator",
            "Print individual characters separated by a space.",
            t =>
            {
                t.Add(("input \"Code\" -> expected \"C o d e\"", () =>
                    PynativeExerciseRunner.AssertEqual("C o d e", () => StringExercises.SeparateCharactersWithSpaces("Code"))));
                t.Add(("input \"ab\" -> expected \"a b\"", () =>
                    PynativeExerciseRunner.AssertEqual("a b", () => StringExercises.SeparateCharactersWithSpaces("ab"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test04_CountVowelsAndConsonants() =>
        PynativeExerciseRunner.Run(4, "Vowel & Consonant Counter",
            "Count vowels and consonants in a sentence (ignore non-letters).",
            t =>
            {
                t.Add(("input \"C# is a powerful programming language\" -> Vowels=12, Consonants=19", () =>
                {
                    var (v, c) = StringExercises.CountVowelsAndConsonants("C# is a powerful programming language");
                    PynativeExerciseRunner.PrintOutput($"Vowels={v}, Consonants={c}");
                    PynativeExerciseRunner.AssertEqualSilent(12, v);
                    PynativeExerciseRunner.AssertEqualSilent(19, c);
                }));
                t.Add(("input \"aeiou\" -> Vowels=5, Consonants=0", () =>
                {
                    var (v, c) = StringExercises.CountVowelsAndConsonants("aeiou");
                    PynativeExerciseRunner.PrintOutput($"Vowels={v}, Consonants={c}");
                    PynativeExerciseRunner.AssertEqualSilent(5, v);
                    PynativeExerciseRunner.AssertEqualSilent(0, c);
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test05_CountCharacterTypes() =>
        PynativeExerciseRunner.Run(5, "Alphabet, Digit, and Special Character Counter",
            "Count letters, digits, and special symbols.",
            t =>
            {
                t.Add(("input \"Hello123!@#\" -> Letters=5, Digits=3, Special=3", () =>
                {
                    var (letters, digits, special) = StringExercises.CountCharacterTypes("Hello123!@#");
                    PynativeExerciseRunner.PrintOutput($"Letters={letters}, Digits={digits}, Special={special}");
                    PynativeExerciseRunner.AssertEqualSilent(5, letters);
                    PynativeExerciseRunner.AssertEqualSilent(3, digits);
                    PynativeExerciseRunner.AssertEqualSilent(3, special);
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test06_ToggleCase() =>
        PynativeExerciseRunner.Run(6, "Case Converter",
            "Toggle case of each character (upper ↔ lower).",
            t =>
            {
                t.Add(("input \"Hello World\" -> expected \"hELLO wORLD\"", () =>
                    PynativeExerciseRunner.AssertEqual("hELLO wORLD", () => StringExercises.ToggleCase("Hello World"))));
                t.Add(("input \"abc\" -> expected \"ABC\"", () =>
                    PynativeExerciseRunner.AssertEqual("ABC", () => StringExercises.ToggleCase("abc"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test07_CountWords() =>
        PynativeExerciseRunner.Run(7, "Word Counter",
            "Count words separated by spaces.",
            t =>
            {
                t.Add(("input \"C# is a powerful programming language\" -> expected 6", () =>
                    PynativeExerciseRunner.AssertEqual(6, () => StringExercises.CountWords("C# is a powerful programming language"))));
                t.Add(("input \"one\" -> expected 1", () =>
                    PynativeExerciseRunner.AssertEqual(1, () => StringExercises.CountWords("one"))));
                t.Add(("input \"\" -> expected 0", () =>
                    PynativeExerciseRunner.AssertEqual(0, () => StringExercises.CountWords(""))));
            });

    public static PynativeExerciseRunner.SuiteResult Test08_ContainsSubstring() =>
        PynativeExerciseRunner.Run(8, "Sub-string Checker",
            "Check if substring exists without using .Contains().",
            t =>
            {
                t.Add(("text=\"programming\", sub=\"gram\" -> expected true", () =>
                    PynativeExerciseRunner.AssertTrue(() => StringExercises.ContainsSubstring("programming", "gram"))));
                t.Add(("text=\"programming\", sub=\"xyz\" -> expected false", () =>
                    PynativeExerciseRunner.AssertFalse(() => StringExercises.ContainsSubstring("programming", "xyz"))));
                t.Add(("text=\"abc\", sub=\"abc\" -> expected true", () =>
                    PynativeExerciseRunner.AssertTrue(() => StringExercises.ContainsSubstring("abc", "abc"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test09_TrimManual() =>
        PynativeExerciseRunner.Run(9, "String Trimmer",
            "Remove leading and trailing whitespace manually.",
            t =>
            {
                t.Add(("input \"   Hello World   \" -> expected \"Hello World\"", () =>
                    PynativeExerciseRunner.AssertEqual("Hello World", () => StringExercises.TrimManual("   Hello World   "))));
                t.Add(("input \"no trim\" -> expected \"no trim\"", () =>
                    PynativeExerciseRunner.AssertEqual("no trim", () => StringExercises.TrimManual("no trim"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test10_AreEqualManual() =>
        PynativeExerciseRunner.Run(10, "String Compactor (Manual Comparison)",
            "Compare two strings character by character without .Equals() or ==.",
            t =>
            {
                t.Add(("\"Hello\" vs \"Hello\" -> expected true", () =>
                    PynativeExerciseRunner.AssertTrue(() => StringExercises.AreEqualManual("Hello", "Hello"))));
                t.Add(("\"Hello\" vs \"hello\" -> expected false", () =>
                    PynativeExerciseRunner.AssertFalse(() => StringExercises.AreEqualManual("Hello", "hello"))));
                t.Add(("\"Hi\" vs \"Hi!\" -> expected false", () =>
                    PynativeExerciseRunner.AssertFalse(() => StringExercises.AreEqualManual("Hi", "Hi!"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test11_ReverseWordOrder() =>
        PynativeExerciseRunner.Run(11, "Sentence Reverser",
            "Reverse the order of words in a sentence.",
            t =>
            {
                t.Add(("input \"C# is fun\" -> expected \"fun is C#\"", () =>
                    PynativeExerciseRunner.AssertEqual("fun is C#", () => StringExercises.ReverseWordOrder("C# is fun"))));
                t.Add(("input \"one\" -> expected \"one\"", () =>
                    PynativeExerciseRunner.AssertEqual("one", () => StringExercises.ReverseWordOrder("one"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test12_CharacterFrequency() =>
        PynativeExerciseRunner.Run(12, "Character Frequency Counter",
            "Return frequency of each character (first appearance order).",
            t =>
            {
                t.Add(("input \"banana\" -> b=1, a=3, n=2", () =>
                {
                    var freq = StringExercises.CharacterFrequency("banana");
                    PynativeExerciseRunner.PrintOutput(freq);
                    PynativeExerciseRunner.AssertEqualSilent(1, freq['b']);
                    PynativeExerciseRunner.AssertEqualSilent(3, freq['a']);
                    PynativeExerciseRunner.AssertEqualSilent(2, freq['n']);
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test13_MostFrequentCharacter() =>
        PynativeExerciseRunner.Run(13, "Most Frequent Character",
            "Find the character that appears the most.",
            t =>
            {
                t.Add(("input \"success\" -> expected 's'", () =>
                    PynativeExerciseRunner.AssertEqual('s', () => StringExercises.MostFrequentCharacter("success"))));
                t.Add(("input \"aaaab\" -> expected 'a'", () =>
                    PynativeExerciseRunner.AssertEqual('a', () => StringExercises.MostFrequentCharacter("aaaab"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test14_ExtractSubstring() =>
        PynativeExerciseRunner.Run(14, "Manual Substring Extractor",
            "Extract substring without using .Substring().",
            t =>
            {
                t.Add(("text=\"programming\", start=3, length=4 -> expected \"gram\"", () =>
                    PynativeExerciseRunner.AssertEqual("gram", () => StringExercises.ExtractSubstring("programming", 3, 4))));
                t.Add(("text=\"hello\", start=0, length=2 -> expected \"he\"", () =>
                    PynativeExerciseRunner.AssertEqual("he", () => StringExercises.ExtractSubstring("hello", 0, 2))));
            });

    public static PynativeExerciseRunner.SuiteResult Test15_SortCharactersAlphabetically() =>
        PynativeExerciseRunner.Run(15, "Alphabetical Sorter",
            "Sort characters in ascending alphabetical order.",
            t =>
            {
                t.Add(("input \"dcba\" -> expected \"abcd\"", () =>
                    PynativeExerciseRunner.AssertEqual("abcd", () => StringExercises.SortCharactersAlphabetically("dcba"))));
                t.Add(("input \"hello\" -> expected \"ehllo\"", () =>
                    PynativeExerciseRunner.AssertEqual("ehllo", () => StringExercises.SortCharactersAlphabetically("hello"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test16_RemoveDuplicateCharacters() =>
        PynativeExerciseRunner.Run(16, "Duplicate Remover",
            "Remove duplicate characters, keep first occurrence.",
            t =>
            {
                t.Add(("input \"programming\" -> expected \"progamin\"", () =>
                    PynativeExerciseRunner.AssertEqual("progamin", () => StringExercises.RemoveDuplicateCharacters("programming"))));
                t.Add(("input \"aaa\" -> expected \"a\"", () =>
                    PynativeExerciseRunner.AssertEqual("a", () => StringExercises.RemoveDuplicateCharacters("aaa"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test17_ToTitleCase() =>
        PynativeExerciseRunner.Run(17, "Title Case Converter",
            "Capitalize the first letter of every word.",
            t =>
            {
                t.Add(("input \"the quick brown fox\" -> expected \"The Quick Brown Fox\"", () =>
                    PynativeExerciseRunner.AssertEqual("The Quick Brown Fox", () => StringExercises.ToTitleCase("the quick brown fox"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test18_IsPalindrome() =>
        PynativeExerciseRunner.Run(18, "Palindrome Checker",
            "Check palindrome ignoring case and spaces.",
            t =>
            {
                t.Add(("input \"A man a plan a canal Panama\" -> expected true", () =>
                    PynativeExerciseRunner.AssertTrue(() => StringExercises.IsPalindrome("A man a plan a canal Panama"))));
                t.Add(("input \"hello\" -> expected false", () =>
                    PynativeExerciseRunner.AssertFalse(() => StringExercises.IsPalindrome("hello"))));
                t.Add(("input \"Race car\" -> expected true", () =>
                    PynativeExerciseRunner.AssertTrue(() => StringExercises.IsPalindrome("Race car"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test19_AreAnagrams() =>
        PynativeExerciseRunner.Run(19, "Anagram Detector",
            "Check if two strings are anagrams.",
            t =>
            {
                t.Add(("\"listen\" and \"silent\" -> expected true", () =>
                    PynativeExerciseRunner.AssertTrue(() => StringExercises.AreAnagrams("listen", "silent"))));
                t.Add(("\"hello\" and \"world\" -> expected false", () =>
                    PynativeExerciseRunner.AssertFalse(() => StringExercises.AreAnagrams("hello", "world"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test20_PadLeftAndRight() =>
        PynativeExerciseRunner.Run(20, "String Padding Creator",
            "Left and right pad to target length with pad character.",
            t =>
            {
                t.Add(("text=\"42\", length=6, pad='0' -> left=\"000042\", right=\"420000\"", () =>
                {
                    var (left, right) = StringExercises.PadLeftAndRight("42", 6, '0');
                    PynativeExerciseRunner.PrintOutput((left, right));
                    PynativeExerciseRunner.AssertEqualSilent("000042", left);
                    PynativeExerciseRunner.AssertEqualSilent("420000", right);
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test21_GetAllSubstrings() =>
        PynativeExerciseRunner.Run(21, "Find All Substrings",
            "Generate all contiguous substrings.",
            t =>
            {
                t.Add(("input \"abc\" -> expected [a, ab, abc, b, bc, c]", () =>
                {
                    var expected = new[] { "a", "ab", "abc", "b", "bc", "c" };
                    PynativeExerciseRunner.AssertSequenceEqual(expected, () => StringExercises.GetAllSubstrings("abc"));
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test22_LongestCommonPrefix() =>
        PynativeExerciseRunner.Run(22, "Longest Common Prefix",
            "Find longest common prefix among strings.",
            t =>
            {
                t.Add(("words={flower, flow, flight} -> expected \"fl\"", () =>
                    PynativeExerciseRunner.AssertEqual("fl",
                        () => StringExercises.LongestCommonPrefix(new[] { "flower", "flow", "flight" }))));
                t.Add(("words={dog, cat} -> expected \"\"", () =>
                    PynativeExerciseRunner.AssertEqual("",
                        () => StringExercises.LongestCommonPrefix(new[] { "dog", "cat" }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test23_FirstNonRepeatedCharacter() =>
        PynativeExerciseRunner.Run(23, "First Non-Repeated Character",
            "Find the first character that does not repeat.",
            t =>
            {
                t.Add(("input \"swiss\" -> expected 'w'", () =>
                    PynativeExerciseRunner.AssertEqual('w', () => StringExercises.FirstNonRepeatedCharacter("swiss"))));
                t.Add(("input \"aabb\" -> expected null", () =>
                    PynativeExerciseRunner.AssertEqual(null, () => StringExercises.FirstNonRepeatedCharacter("aabb"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test24_ParseIntManual() =>
        PynativeExerciseRunner.Run(24, "String to Integer (Manual Parse)",
            "Convert numeric string to int without int.Parse() or Convert.ToInt32().",
            t =>
            {
                t.Add(("input \"-1234\" -> expected -1234", () =>
                    PynativeExerciseRunner.AssertEqual(-1234, () => StringExercises.ParseIntManual("-1234"))));
                t.Add(("input \"42\" -> expected 42", () =>
                    PynativeExerciseRunner.AssertEqual(42, () => StringExercises.ParseIntManual("42"))));
                t.Add(("input \"0\" -> expected 0", () =>
                    PynativeExerciseRunner.AssertEqual(0, () => StringExercises.ParseIntManual("0"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test25_RunLengthEncode() =>
        PynativeExerciseRunner.Run(25, "Run-Length Encoding (RLE)",
            "Compress repeated characters as char + count.",
            t =>
            {
                t.Add(("input \"aabbbcccc\" -> expected \"a2b3c4\"", () =>
                    PynativeExerciseRunner.AssertEqual("a2b3c4", () => StringExercises.RunLengthEncode("aabbbcccc"))));
                t.Add(("input \"abc\" -> expected \"a1b1c1\"", () =>
                    PynativeExerciseRunner.AssertEqual("a1b1c1", () => StringExercises.RunLengthEncode("abc"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test26_IsValidParentheses() =>
        PynativeExerciseRunner.Run(26, "Valid Parentheses",
            "Check if brackets (), {}, [] are balanced.",
            t =>
            {
                t.Add(("input \"{[()]}\" -> expected true", () =>
                    PynativeExerciseRunner.AssertTrue(() => StringExercises.IsValidParentheses("{[()]}"))));
                t.Add(("input \"([)]\" -> expected false", () =>
                    PynativeExerciseRunner.AssertFalse(() => StringExercises.IsValidParentheses("([)]"))));
                t.Add(("input \"()\" -> expected true", () =>
                    PynativeExerciseRunner.AssertTrue(() => StringExercises.IsValidParentheses("()"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test27_UrlEncodeSpaces() =>
        PynativeExerciseRunner.Run(27, "URL Encoder",
            "Replace spaces with %20 using StringBuilder.",
            t =>
            {
                t.Add(("input \"Hello World Wide Web\" -> expected \"Hello%20World%20Wide%20Web\"", () =>
                    PynativeExerciseRunner.AssertEqual("Hello%20World%20Wide%20Web",
                        () => StringExercises.UrlEncodeSpaces("Hello World Wide Web"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test28_IsRotation() =>
        PynativeExerciseRunner.Run(28, "String Rotation Checker",
            "Check if s2 is a rotation of s1.",
            t =>
            {
                t.Add(("s1=\"waterbottle\", s2=\"erbottlewat\" -> expected true", () =>
                    PynativeExerciseRunner.AssertTrue(() => StringExercises.IsRotation("waterbottle", "erbottlewat"))));
                t.Add(("s1=\"hello\", s2=\"lohel\" -> expected true", () =>
                    PynativeExerciseRunner.AssertTrue(() => StringExercises.IsRotation("hello", "lohel"))));
                t.Add(("s1=\"abc\", s2=\"acb\" -> expected false", () =>
                    PynativeExerciseRunner.AssertFalse(() => StringExercises.IsRotation("abc", "acb"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test29_CaesarCipher() =>
        PynativeExerciseRunner.Run(29, "Caesar Cipher",
            "Shift every letter by a fixed number of positions.",
            t =>
            {
                t.Add(("text=\"Hello World\", shift=3 -> expected \"Khoor Zruog\"", () =>
                    PynativeExerciseRunner.AssertEqual("Khoor Zruog", () => StringExercises.CaesarCipher("Hello World", 3))));
                t.Add(("text=\"abc\", shift=1 -> expected \"bcd\"", () =>
                    PynativeExerciseRunner.AssertEqual("bcd", () => StringExercises.CaesarCipher("abc", 1))));
            });

    public static PynativeExerciseRunner.SuiteResult Test30_LongestSubstringWithoutRepeating() =>
        PynativeExerciseRunner.Run(30, "Longest Substring Without Repeating Characters",
            "Find length of longest substring with no duplicate characters.",
            t =>
            {
                t.Add(("input \"abcabcbb\" -> expected 3", () =>
                    PynativeExerciseRunner.AssertEqual(3, () => StringExercises.LongestSubstringWithoutRepeating("abcabcbb"))));
                t.Add(("input \"bbbbb\" -> expected 1", () =>
                    PynativeExerciseRunner.AssertEqual(1, () => StringExercises.LongestSubstringWithoutRepeating("bbbbb"))));
                t.Add(("input \"pwwkew\" -> expected 3", () =>
                    PynativeExerciseRunner.AssertEqual(3, () => StringExercises.LongestSubstringWithoutRepeating("pwwkew"))));
            });
}
