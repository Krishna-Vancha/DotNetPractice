using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.RegularExpressions;

public static class RegexExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 30; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative - Regex Exercises (30)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_ExactlyFiveDigits(),
        2 => Test02_AlphabeticWords(),
        3 => Test03_StartsAndEndsWithLetters(),
        4 => Test04_ValidWholeNumbers(),
        5 => Test05_WhitespaceCleaner(),
        6 => Test06_HexColorCodes(),
        7 => Test07_WordsStartingWithVowel(),
        8 => Test08_IsolatedDollarAmounts(),
        9 => Test09_VariableNames(),
        10 => Test10_StripPunctuation(),
        11 => Test11_BasicEmail(),
        12 => Test12_UsDateGroups(),
        13 => Test13_ExtractHref(),
        14 => Test14_PhoneNumbers(),
        15 => Test15_ExtractDomain(),
        16 => Test16_DuplicateWords(),
        17 => Test17_NumericValues(),
        18 => Test18_LogSeverity(),
        19 => Test19_PasswordStrength(),
        20 => Test20_QuotedText(),
        21 => Test21_PriceLookbehind(),
        22 => Test22_StripHtmlTags(),
        23 => Test23_ConfigKeyValue(),
        24 => Test24_IPv4(),
        25 => Test25_NegativeLookahead(),
        26 => Test26_MacAddress(),
        27 => Test27_NonBacktracking(),
        28 => Test28_SplitCamelCase(),
        29 => Test29_CSharpComments(),
        30 => Test30_MaskCreditCard(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Regex exercises are numbered 1-30.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_ExactlyFiveDigits() =>
        PynativeExerciseRunner.Run(1, "Exactly 5 Digits",
            "Match a string that consists entirely of exactly 5 numeric digits.",
            t =>
            {
                t.Add(("12345 -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsExactlyFiveDigits("12345"))));
                t.Add(("1234 -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => RegexExercises.IsExactlyFiveDigits("1234"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test02_AlphabeticWords() =>
        PynativeExerciseRunner.Run(2, "Alphabetic Words",
            "Find words that contain only letters, with no numbers or symbols mixed in.",
            t =>
            {
                t.Add(("Hello, user123! -> Hello", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "Hello" },
                        () => RegexExercises.FindAlphabeticWords("Hello, user123!"))));
                t.Add(("Hello World 2024! -> Hello, World", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "Hello", "World" },
                        () => RegexExercises.FindAlphabeticWords("Hello World 2024!"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test03_StartsAndEndsWithLetters() =>
        PynativeExerciseRunner.Run(3, "Starts and Ends with Specified Letters",
            "Match a 5-letter word that starts with a and ends with e.",
            t =>
            {
                t.Add(("apple -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.StartsWithAEndsWithE("apple"))));
                t.Add(("awake -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.StartsWithAEndsWithE("awake"))));
                t.Add(("table -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => RegexExercises.StartsWithAEndsWithE("table"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test04_ValidWholeNumbers() =>
        PynativeExerciseRunner.Run(4, "Valid Whole Numbers",
            "Accept a positive whole number: digits only, no sign and no decimal point.",
            t =>
            {
                t.Add(("4820 -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsPositiveWholeNumber("4820"))));
                t.Add(("48.20 -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => RegexExercises.IsPositiveWholeNumber("48.20"))));
                t.Add(("-4820 -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => RegexExercises.IsPositiveWholeNumber("-4820"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test05_WhitespaceCleaner() =>
        PynativeExerciseRunner.Run(5, "Whitespace Cleaner",
            "Replace each run of two or more spaces with a single space.",
            t =>
            {
                t.Add(("Hello   World -> Hello World", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Hello World",
                        () => RegexExercises.CollapseExtraSpaces("Hello   World"))));
                t.Add(("Hello World -> Hello World", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Hello World",
                        () => RegexExercises.CollapseExtraSpaces("Hello World"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test06_HexColorCodes() =>
        PynativeExerciseRunner.Run(6, "Hexadecimal Color Codes",
            "Match a 6-digit hex color that starts with #.",
            t =>
            {
                t.Add(("#FF5733 -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsHexColorCode("#FF5733"))));
                t.Add(("#00A3FF -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsHexColorCode("#00A3FF"))));
                t.Add(("#GG1234 -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => RegexExercises.IsHexColorCode("#GG1234"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test07_WordsStartingWithVowel() =>
        PynativeExerciseRunner.Run(7, "Extracting Words Starting with a Vowel",
            "Find words that begin with a vowel, matching either case.",
            t => t.Add(("An elephant ate an Apple", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "An", "elephant", "ate", "an", "Apple" },
                    () => RegexExercises.FindWordsStartingWithVowel("An elephant ate an Apple")))));

    public static PynativeExerciseRunner.SuiteResult Test08_IsolatedDollarAmounts() =>
        PynativeExerciseRunner.Run(8, "Finding Isolated Symbols",
            "Find each $ sign that is followed immediately by one or more digits.",
            t => t.Add(("The total is $100, plus a $5 fee", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "$100", "$5" },
                    () => RegexExercises.FindDollarAmounts("The total is $100, plus a $5 fee")))));

    public static PynativeExerciseRunner.SuiteResult Test09_VariableNames() =>
        PynativeExerciseRunner.Run(9, "Simple Variable Names",
            "Match an identifier that starts with a letter or underscore, then word characters.",
            t =>
            {
                t.Add(("_userId -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsValidVariableName("_userId"))));
                t.Add(("data2 -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsValidVariableName("data2"))));
                t.Add(("2data -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => RegexExercises.IsValidVariableName("2data"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test10_StripPunctuation() =>
        PynativeExerciseRunner.Run(10, "Stripping Punctuation",
            "Remove '.', ',', '!', and '?' from the text.",
            t => t.Add(("Stop, look! Are you ready? -> Stop look Are you ready", () =>
                PynativeExerciseRunner.AssertEqual(
                    "Stop look Are you ready",
                    () => RegexExercises.StripPunctuation("Stop, look! Are you ready?")))));

    public static PynativeExerciseRunner.SuiteResult Test11_BasicEmail() =>
        PynativeExerciseRunner.Run(11, "Basic Email Validation",
            "Accept a basic email with an @, a domain, and a 2-4 letter TLD.",
            t =>
            {
                t.Add(("test.user@domain.com -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsBasicEmail("test.user@domain.com"))));
                t.Add(("not-an-email -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => RegexExercises.IsBasicEmail("not-an-email"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test12_UsDateGroups() =>
        PynativeExerciseRunner.Run(12, "Date Format Converter (MM/DD/YYYY)",
            "Capture month, day, and year from a US date MM/DD/YYYY.",
            t => t.Add(("12/25/2026 -> Month 12, Day 25, Year 2026", () =>
            {
                var parsed = RegexExercises.ParseUsDate("12/25/2026");
                PynativeExerciseRunner.PrintOutput($"Month: {parsed.Month}, Day: {parsed.Day}, Year: {parsed.Year}");
                PynativeExerciseRunner.AssertEqualSilent("12", parsed.Month);
                PynativeExerciseRunner.AssertEqualSilent("25", parsed.Day);
                PynativeExerciseRunner.AssertEqualSilent("2026", parsed.Year);
            })));

    public static PynativeExerciseRunner.SuiteResult Test13_ExtractHref() =>
        PynativeExerciseRunner.Run(13, "Extraction of href Attributes",
            "Extract the URL from an HTML anchor href attribute.",
            t => t.Add(("<a href=\"https://example.com\"> -> https://example.com", () =>
                PynativeExerciseRunner.AssertEqual(
                    "https://example.com",
                    () => RegexExercises.ExtractHref("<a href=\"https://example.com\">Visit</a>")))));

    public static PynativeExerciseRunner.SuiteResult Test14_PhoneNumbers() =>
        PynativeExerciseRunner.Run(14, "North American Phone Numbers",
            "Match 555-867-5309 or (555) 867-5309, and reject dotted numbers.",
            t =>
            {
                t.Add(("555-867-5309 -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsNorthAmericanPhone("555-867-5309"))));
                t.Add(("(555) 867-5309 -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsNorthAmericanPhone("(555) 867-5309"))));
                t.Add(("555.867.5309 -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => RegexExercises.IsNorthAmericanPhone("555.867.5309"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test15_ExtractDomain() =>
        PynativeExerciseRunner.Run(15, "Extracting Domain Names",
            "From an https URL, return only the domain label before the TLD.",
            t => t.Add(("https://github.com/features -> github", () =>
                PynativeExerciseRunner.AssertEqual(
                    "github",
                    () => RegexExercises.ExtractDomainLabel("https://github.com/features")))));

    public static PynativeExerciseRunner.SuiteResult Test16_DuplicateWords() =>
        PynativeExerciseRunner.Run(16, "Duplicate Word Finder",
            "Find the same word typed twice in a row.",
            t =>
            {
                t.Add(("This is the the end. -> the the", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "the the",
                        () => RegexExercises.FindDuplicateWords("This is the the end."))));
                t.Add(("Go go now -> Go go", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Go go",
                        () => RegexExercises.FindDuplicateWords("Go go now"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test17_NumericValues() =>
        PynativeExerciseRunner.Run(17, "Numeric Values with Optional Decimals",
            "Match integers or decimals, with an optional leading minus.",
            t =>
            {
                t.Add(("-45.67 -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsNumericValue("-45.67"))));
                t.Add(("100 -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsNumericValue("100"))));
                t.Add(("3.14 -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsNumericValue("3.14"))));
                t.Add(("-8 -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsNumericValue("-8"))));
                t.Add(("12.3.4 -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => RegexExercises.IsNumericValue("12.3.4"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test18_LogSeverity() =>
        PynativeExerciseRunner.Run(18, "Extracting Log Severity Levels",
            "Extract a leading bracketed uppercase tag such as [ERROR].",
            t =>
            {
                t.Add(("[ERROR] Connection failed. -> [ERROR]", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "[ERROR]",
                        () => RegexExercises.ExtractLogSeverity("[ERROR] Connection failed."))));
                t.Add(("[WARNING] Disk low -> [WARNING]", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "[WARNING]",
                        () => RegexExercises.ExtractLogSeverity("[WARNING] Disk low"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test19_PasswordStrength() =>
        PynativeExerciseRunner.Run(19, "Password Strength Requirement",
            "Accept 8 to 16 characters that include at least one digit.",
            t =>
            {
                t.Add(("P@ssword123 -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsAcceptablePassword("P@ssword123"))));
                t.Add(("password -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => RegexExercises.IsAcceptablePassword("password"))));
                t.Add(("short1 -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => RegexExercises.IsAcceptablePassword("short1"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test20_QuotedText() =>
        PynativeExerciseRunner.Run(20, "Matching Content Inside Quotes",
            "Extract the text inside double quotes, without the quotes.",
            t => t.Add(("He said \"Secret Message\". -> Secret Message", () =>
                PynativeExerciseRunner.AssertEqual(
                    "Secret Message",
                    () => RegexExercises.ExtractQuotedText("He said \"Secret Message\".")))));

    public static PynativeExerciseRunner.SuiteResult Test21_PriceLookbehind() =>
        PynativeExerciseRunner.Run(21, "Extracting Prices Preceded by Currency Text",
            "Capture a decimal price only when it is preceded by 'Price: '.",
            t => t.Add(("Total Price: 49.99 -> 49.99", () =>
                PynativeExerciseRunner.AssertEqual(
                    "49.99",
                    () => RegexExercises.ExtractPriceAfterLabel("Total Price: 49.99")))));

    public static PynativeExerciseRunner.SuiteResult Test22_StripHtmlTags() =>
        PynativeExerciseRunner.Run(22, "Stripping HTML Tags Safely",
            "Remove HTML tags and leave the plain text.",
            t => t.Add(("<p>Hello</p> -> Hello", () =>
                PynativeExerciseRunner.AssertEqual(
                    "Hello",
                    () => RegexExercises.StripHtmlTags("<p>Hello</p>")))));

    public static PynativeExerciseRunner.SuiteResult Test23_ConfigKeyValue() =>
        PynativeExerciseRunner.Run(23, "Parsing Key-Value Configurations",
            "Split a key=value line into dictionary entries named key and value.",
            t => t.Add(("Timeout=30 -> key Timeout, value 30", () =>
            {
                var parsed = RegexExercises.ParseConfigKeyValue("Timeout=30");
                PynativeExerciseRunner.PrintOutput($"Key: {parsed["key"]}, Value: {parsed["value"]}");
                PynativeExerciseRunner.AssertEqualSilent("Timeout", parsed["key"]);
                PynativeExerciseRunner.AssertEqualSilent("30", parsed["value"]);
            })));

    public static PynativeExerciseRunner.SuiteResult Test24_IPv4() =>
        PynativeExerciseRunner.Run(24, "Validating IPv4 Addresses",
            "Accept an IPv4 address only when every octet is from 0 to 255.",
            t =>
            {
                t.Add(("192.168.1.254 -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsValidIPv4("192.168.1.254"))));
                t.Add(("192.168.1.256 -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => RegexExercises.IsValidIPv4("192.168.1.256"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test25_NegativeLookahead() =>
        PynativeExerciseRunner.Run(25, "Negative Lookahead Filtering",
            "Match words that start with pro unless they end with ing.",
            t =>
            {
                t.Add(("product -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.MatchesProButNotIng("product"))));
                t.Add(("programming -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => RegexExercises.MatchesProButNotIng("programming"))));
                t.Add(("profile -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.MatchesProButNotIng("profile"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test26_MacAddress() =>
        PynativeExerciseRunner.Run(26, "Extracting MAC Addresses",
            "Match a 6-byte hex MAC address separated by colons or hyphens.",
            t =>
            {
                t.Add(("00:1A:2B:3C:4D:5E -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsMacAddress("00:1A:2B:3C:4D:5E"))));
                t.Add(("00-1A-2B-3C-4D-5E -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.IsMacAddress("00-1A-2B-3C-4D-5E"))));
                t.Add(("00:1A:2B:3C:4D -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() => RegexExercises.IsMacAddress("00:1A:2B:3C:4D"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test27_NonBacktracking() =>
        PynativeExerciseRunner.Run(27, "Non-Backtracking Verification",
            "Match ^(a+)+$ with RegexOptions.NonBacktracking. Timing is not checked.",
            t =>
            {
                t.Add(("30 a's + ! -> False", () =>
                    PynativeExerciseRunner.AssertFalse(() =>
                        RegexExercises.MatchesWithNonBacktracking(new string('a', 30) + "!"))));
                t.Add(("aaa -> True", () =>
                    PynativeExerciseRunner.AssertTrue(() => RegexExercises.MatchesWithNonBacktracking("aaa"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test28_SplitCamelCase() =>
        PynativeExerciseRunner.Run(28, "Splitting CamelCase Words",
            "Split camelCase on each lowercase-to-uppercase boundary.",
            t => t.Add(("camelCaseExample -> camel, Case, Example", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "camel", "Case", "Example" },
                    () => RegexExercises.SplitCamelCase("camelCaseExample")))));

    public static PynativeExerciseRunner.SuiteResult Test29_CSharpComments() =>
        PynativeExerciseRunner.Run(29, "Parsing C# Comments",
            "Extract both // line comments and /* block comments */.",
            t => t.Add(("line comment plus block comment", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "// set x", "/* TODO: fix */" },
                    () => RegexExercises.ExtractCSharpComments("int x = 5; // set x\n/* TODO: fix */")))));

    public static PynativeExerciseRunner.SuiteResult Test30_MaskCreditCard() =>
        PynativeExerciseRunner.Run(30, "Credit Card Number Masking",
            "Mask the first 12 digits and keep the last 4 and its separator.",
            t =>
            {
                t.Add(("4111-2222-3333-4444 -> XXXX-XXXX-XXXX-4444", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "XXXX-XXXX-XXXX-4444",
                        () => RegexExercises.MaskCreditCard("4111-2222-3333-4444"))));
                t.Add(("4111 2222 3333 4444 -> XXXX-XXXX-XXXX 4444", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "XXXX-XXXX-XXXX 4444",
                        () => RegexExercises.MaskCreditCard("4111 2222 3333 4444"))));
            });
}
