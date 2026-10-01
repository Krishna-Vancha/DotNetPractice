using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.RandomData;

public static class RandomDataExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 20; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative — Random Data Generation Exercises (20)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_RandomRanges(),
        2 => Test02_DeterministicSeeding(),
        3 => Test03_RandomCharMatrix(),
        4 => Test04_BiasedBool(),
        5 => Test05_FixedLengthPassword(),
        6 => Test06_SecureToken(),
        7 => Test07_PronounceableString(),
        8 => Test08_MaskIdentifier(),
        9 => Test09_RandomDate(),
        10 => Test10_GeoFence(),
        11 => Test11_RgbColor(),
        12 => Test12_RandomTimeSpan(),
        13 => Test13_SyntheticUsers(),
        14 => Test14_RandomIp(),
        15 => Test15_CreditCard(),
        16 => Test16_FisherYatesShuffle(),
        17 => Test17_SelectWithReplacement(),
        18 => Test18_SelectWithoutReplacement(),
        19 => Test19_WeightedSelection(),
        20 => Test20_WeightedSelectionDuplicate(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Random Data Generation exercises are numbered 1-20.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_RandomRanges() =>
        PynativeExerciseRunner.Run(1, "Random Ranges",
            "Generate 5 random integers between 50 and 150 inclusive and 5 random doubles between 10.0 and 50.0.",
            t => t.Add(("5 ints [50,150] and 5 doubles [10,50]", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    var sample = RandomDataExercises.GenerateRanges(new Random(42), 5, 50, 150, 10.0, 50.0);
                    return sample.Integers.Count == 5
                        && sample.Doubles.Count == 5
                        && sample.Integers.All(v => v >= 50 && v <= 150)
                        && sample.Doubles.All(v => v >= 10.0 && v <= 50.0);
                }, "5 ints in [50,150] and 5 doubles in [10,50]"))));

    public static PynativeExerciseRunner.SuiteResult Test02_DeterministicSeeding() =>
        PynativeExerciseRunner.Run(2, "Deterministic Randomness (Seeding)",
            "Initialize two Random instances with the same seed and verify their outputs are identical.",
            t => t.Add(("seed 42, 10 values in [1,100) -> True", () =>
                PynativeExerciseRunner.AssertEqual(true,
                    () => RandomDataExercises.SameSeedProducesSameSequence(42, 10, 1, 100)))));

    public static PynativeExerciseRunner.SuiteResult Test03_RandomCharMatrix() =>
        PynativeExerciseRunner.Run(3, "Random Char Matrix",
            "Generate a random 5x5 grid of uppercase characters from A to Z.",
            t => t.Add(("5x5 uppercase letters, same seed repeats", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    var grid = RandomDataExercises.GenerateUppercaseGrid(new Random(42), 5);
                    var again = RandomDataExercises.GenerateUppercaseGrid(new Random(42), 5);
                    return grid.Count == 5
                        && grid.All(row => row.Length == 5 && row.All(c => c >= 'A' && c <= 'Z'))
                        && grid.SequenceEqual(again);
                }, "5 rows of 5 letters A-Z, stable for seed 42"))));

    public static PynativeExerciseRunner.SuiteResult Test04_BiasedBool() =>
        PynativeExerciseRunner.Run(4, "Weighted Coin Toss / True-False Bias",
            "GetBiasedBool(0.75) should return true roughly 75% of the time.",
            t => t.Add(("0.75 over 10000 calls -> about 7500 trues", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    var rng = new Random(42);
                    int trues = 0;
                    const int total = 10000;
                    for (int i = 0; i < total; i++)
                    {
                        if (RandomDataExercises.GetBiasedBool(rng, 0.75))
                            trues++;
                    }

                    return trues >= 7000 && trues <= 8000;
                }, "true count should be near 75% of 10000"))));

    public static PynativeExerciseRunner.SuiteResult Test05_FixedLengthPassword() =>
        PynativeExerciseRunner.Run(5, "Random Fixed-Length Password",
            "Generate a 12-character password with at least 2 uppercase, 2 lowercase, 2 digits, and 2 special characters.",
            t => t.Add(("length 12 -> mixed categories, stable for seed 42", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    string password = RandomDataExercises.GeneratePassword(new Random(42), 12);
                    string again = RandomDataExercises.GeneratePassword(new Random(42), 12);
                    return password == again
                        && password.Length == 12
                        && password.Count(char.IsUpper) >= 2
                        && password.Count(char.IsLower) >= 2
                        && password.Count(char.IsDigit) >= 2
                        && password.Count(c => !char.IsLetterOrDigit(c)) >= 2;
                }, "length 12 with at least 2 of each required category"))));

    public static PynativeExerciseRunner.SuiteResult Test06_SecureToken() =>
        PynativeExerciseRunner.Run(6, "Cryptographically Secure Tokens",
            "Use RandomNumberGenerator to generate a secure 32-byte hex token.",
            t => t.Add(("32 bytes -> 64 hex chars, two calls differ", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    string token = RandomDataExercises.GenerateSecureHexToken(32);
                    string other = RandomDataExercises.GenerateSecureHexToken(32);
                    return token.Length == 64
                        && other.Length == 64
                        && token != other
                        && token.All(IsHexDigit)
                        && other.All(IsHexDigit);
                }, "64 hex characters from 32 random bytes"))));

    public static PynativeExerciseRunner.SuiteResult Test07_PronounceableString() =>
        PynativeExerciseRunner.Run(7, "Random Pronounceable String",
            "Generate a 6-letter string that alternates consonants and vowels.",
            t => t.Add(("length 6, even index consonant, odd index vowel", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    const string vowels = "aeiou";
                    const string consonants = "bcdfghjklmnpqrstvwxyz";
                    string word = RandomDataExercises.GeneratePronounceable(new Random(42), 6);
                    string again = RandomDataExercises.GeneratePronounceable(new Random(42), 6);
                    if (word.Length != 6 || word != again)
                        return false;

                    for (int i = 0; i < word.Length; i++)
                    {
                        string pool = i % 2 == 0 ? consonants : vowels;
                        if (pool.IndexOf(word[i]) < 0)
                            return false;
                    }

                    return true;
                }, "6 letters, consonant/vowel/consonant/vowel..."))));

    public static PynativeExerciseRunner.SuiteResult Test08_MaskIdentifier() =>
        PynativeExerciseRunner.Run(8, "Random String from a Custom Alphabet",
            "Given a mask like \"ABC-###-XY\", replace each # with a random digit 0-9.",
            t => t.Add(("ABC-###-XY -> ABC-ddd-XY", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    string id = RandomDataExercises.GenerateFromMask(new Random(42), "ABC-###-XY");
                    string again = RandomDataExercises.GenerateFromMask(new Random(42), "ABC-###-XY");
                    return id == again
                        && id.Length == 10
                        && id.StartsWith("ABC-")
                        && id.EndsWith("-XY")
                        && id.Substring(4, 3).All(char.IsDigit);
                }, "literal mask characters kept, # replaced by digits"))));

    public static PynativeExerciseRunner.SuiteResult Test09_RandomDate() =>
        PynativeExerciseRunner.Run(9, "Random Date in Range",
            "Generate a random DateTime between January 1, 2020 and December 31, 2025, including the time of day.",
            t => t.Add(("2020-01-01 through 2025-12-31, time not always midnight", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    var rng = new Random(42);
                    var start = new DateTime(2020, 1, 1);
                    var end = new DateTime(2025, 12, 31);
                    bool inRange = true;
                    bool anyTime = false;
                    for (int i = 0; i < 20; i++)
                    {
                        DateTime value = RandomDataExercises.RandomDateTime(rng, start, end);
                        if (value < start || value >= end.Date.AddDays(1))
                            inRange = false;
                        if (value.TimeOfDay != TimeSpan.Zero)
                            anyTime = true;
                    }

                    return inRange && anyTime;
                }, "dates stay inside the range and the time of day varies"))));

    public static PynativeExerciseRunner.SuiteResult Test10_GeoFence() =>
        PynativeExerciseRunner.Run(10, "Random Coordinate Geo-Fencing",
            "Given a center latitude and longitude, generate 10 coordinates within a 5-kilometer radius.",
            t => t.Add(("center 40.7128, -74.0060, radius 5 km, count 10", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    const double centerLat = 40.7128;
                    const double centerLng = -74.0060;
                    var points = RandomDataExercises.RandomCoordinatesWithinRadius(new Random(42), centerLat, centerLng, 5, 10);
                    var again = RandomDataExercises.RandomCoordinatesWithinRadius(new Random(42), centerLat, centerLng, 5, 10);
                    return points.Count == 10
                        && points.All(p => IsWithinKm(p.Latitude, p.Longitude, centerLat, centerLng, 5))
                        && points.SequenceEqual(again);
                }, "10 points inside about 5 km of the center"))));

    public static PynativeExerciseRunner.SuiteResult Test11_RgbColor() =>
        PynativeExerciseRunner.Run(11, "Random RGB Colors",
            "Generate a random RGB color and format it as a hex string such as #FF5733.",
            t => t.Add(("# plus 6 hex digits, stable for seed 42", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    string color = RandomDataExercises.RandomHexColor(new Random(42));
                    string again = RandomDataExercises.RandomHexColor(new Random(42));
                    return color == again
                        && color.Length == 7
                        && color[0] == '#'
                        && color.Skip(1).All(IsHexDigit);
                }, "#RRGGBB"))));

    public static PynativeExerciseRunner.SuiteResult Test12_RandomTimeSpan() =>
        PynativeExerciseRunner.Run(12, "Random TimeSpans",
            "Generate a random TimeSpan of at least 30 minutes and at most 8 hours.",
            t => t.Add(("30 to 480 whole minutes", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    TimeSpan duration = RandomDataExercises.RandomDuration(new Random(42), 30, 480);
                    TimeSpan again = RandomDataExercises.RandomDuration(new Random(42), 30, 480);
                    return duration == again
                        && duration.TotalMinutes >= 30
                        && duration.TotalMinutes <= 480
                        && duration.Seconds == 0
                        && duration.Milliseconds == 0;
                }, "whole minutes from 30 through 480"))));

    public static PynativeExerciseRunner.SuiteResult Test13_SyntheticUsers() =>
        PynativeExerciseRunner.Run(13, "Synthetic User Objects",
            "Generate 100 users with a Guid id, a username, an age from 18 to 65, and an IsActive flag.",
            t => t.Add(("count 100 -> unique ids, user#### names, ages 18-65", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    var users = RandomDataExercises.GenerateSyntheticUsers(new Random(42), 100);
                    return users.Count == 100
                        && users.All(u => u.Id != Guid.Empty)
                        && users.Select(u => u.Id).Distinct().Count() == 100
                        && users.All(u => u.Username.StartsWith("user") && u.Username.Length > 4 && u.Username.Skip(4).All(char.IsDigit))
                        && users.All(u => u.Age >= 18 && u.Age <= 65);
                }, "100 users with unique ids, user+digits names, and ages 18-65"))));

    public static PynativeExerciseRunner.SuiteResult Test14_RandomIp() =>
        PynativeExerciseRunner.Run(14, "Random IP Addresses",
            "Generate a valid IPv4 string with octets from 0 to 255, avoiding 0.0.0.0.",
            t => t.Add(("four octets 0-255, not 0.0.0.0", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    string ip = RandomDataExercises.RandomIpv4(new Random(42));
                    string again = RandomDataExercises.RandomIpv4(new Random(42));
                    string[] parts = ip.Split('.');
                    if (parts.Length != 4 || ip != again)
                        return false;

                    var octets = parts.Select(int.Parse).ToArray();
                    bool allInRange = octets.All(o => o >= 0 && o <= 255);
                    bool notAllZero = octets.Any(o => o != 0);
                    return allInRange && notAllZero;
                }, "dotted IPv4 that is not 0.0.0.0"))));

    public static PynativeExerciseRunner.SuiteResult Test15_CreditCard() =>
        PynativeExerciseRunner.Run(15, "Random Credit Card Generator",
            "Mock a random 16-digit card number that passes the Luhn check.",
            t => t.Add(("16 digits that pass Luhn, stable for seed 42", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    string card = RandomDataExercises.GenerateCreditCardNumber(new Random(42));
                    string again = RandomDataExercises.GenerateCreditCardNumber(new Random(42));
                    return card == again
                        && card.Length == 16
                        && card.All(char.IsDigit)
                        && PassesLuhn(card);
                }, "16 digits passing the Luhn check"))));

    public static PynativeExerciseRunner.SuiteResult Test16_FisherYatesShuffle() =>
        PynativeExerciseRunner.Run(16, "Array Shuffling (Fisher-Yates)",
            "Shuffle a list with Fisher-Yates so the result is a permutation of the original.",
            t => t.Add(("[1..10] -> same elements, stable for seed 42", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                    var shuffled = RandomDataExercises.Shuffle(new Random(42), source.ToArray());
                    var again = RandomDataExercises.Shuffle(new Random(42), source.ToArray());
                    return shuffled.Count == source.Length
                        && shuffled.SequenceEqual(again)
                        && shuffled.OrderBy(x => x).SequenceEqual(source);
                }, "permutation of 1..10"))));

    public static PynativeExerciseRunner.SuiteResult Test17_SelectWithReplacement() =>
        PynativeExerciseRunner.Run(17, "Random Selection with Replacement",
            "Pick 5 random cities from an array, allowing the same city more than once.",
            t => t.Add(("5 picks from Tokyo, Paris, Cairo, Lima, Oslo", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    string[] cities = { "Tokyo", "Paris", "Cairo", "Lima", "Oslo" };
                    var picks = RandomDataExercises.SelectWithReplacement(new Random(42), cities, 5);
                    var again = RandomDataExercises.SelectWithReplacement(new Random(42), cities, 5);
                    return picks.Count == 5
                        && picks.All(cities.Contains)
                        && picks.SequenceEqual(again);
                }, "5 cities, each one from the source list"))));

    public static PynativeExerciseRunner.SuiteResult Test18_SelectWithoutReplacement() =>
        PynativeExerciseRunner.Run(18, "Random Selection without Replacement",
            "Pick 3 unique items from Item1 through Item10.",
            t => t.Add(("3 distinct items from Item1..Item10", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                {
                    var items = Enumerable.Range(1, 10).Select(i => $"Item{i}").ToArray();
                    var picks = RandomDataExercises.SelectWithoutReplacement(new Random(42), items, 3);
                    var again = RandomDataExercises.SelectWithoutReplacement(new Random(42), items, 3);
                    return picks.Count == 3
                        && picks.Distinct().Count() == 3
                        && picks.All(items.Contains)
                        && picks.SequenceEqual(again);
                }, "3 unique items from the list of 10"))));

    public static PynativeExerciseRunner.SuiteResult Test19_WeightedSelection() =>
        PynativeExerciseRunner.Run(19, "Weighted Random Selection",
            "Select one item at random using weights, so heavier items are chosen more often.",
            t => t.Add(("weights 80, 15, 5 over 2000 draws -> Common dominates", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                    WeightedSampleLooksRight(
                        rng => RandomDataExercises.SelectWeightedItem(
                            rng,
                            new[] { "Common Item", "Rare Item", "Epic Item" },
                            new[] { 80, 15, 5 }),
                        42),
                    "Common Item should win most draws"))));

    public static PynativeExerciseRunner.SuiteResult Test20_WeightedSelectionDuplicate() =>
        PynativeExerciseRunner.Run(20, "Weighted Random Selection",
            "Select one item at random using weights, so heavier items are chosen more often.",
            t => t.Add(("weights 80, 15, 5 over 2000 draws -> Common dominates", () =>
                PynativeExerciseRunner.AssertTrue(() =>
                    WeightedSampleLooksRight(
                        rng => RandomDataExercises.SelectWeightedItemAgain(
                            rng,
                            new[] { "Common Item", "Rare Item", "Epic Item" },
                            new[] { 80, 15, 5 }),
                        99),
                    "Common Item should win most draws"))));

    private static bool WeightedSampleLooksRight(Func<Random, string> select, int seed)
    {
        var rng = new Random(seed);
        int common = 0, rare = 0, epic = 0, other = 0;
        for (int i = 0; i < 2000; i++)
        {
            string item = select(rng);
            if (item == "Common Item")
                common++;
            else if (item == "Rare Item")
                rare++;
            else if (item == "Epic Item")
                epic++;
            else
                other++;
        }

        return other == 0 && common > 1400 && rare > epic;
    }

    private static bool IsWithinKm(double lat, double lng, double centerLat, double centerLng, double radiusKm)
    {
        double dLatKm = (lat - centerLat) * 111.0;
        double dLngKm = (lng - centerLng) * 111.0 * Math.Cos(centerLat * Math.PI / 180.0);
        double distance = Math.Sqrt(dLatKm * dLatKm + dLngKm * dLngKm);
        return distance <= radiusKm + 0.05;
    }

    private static bool PassesLuhn(string digits)
    {
        int sum = 0;
        bool doubleDigit = false;
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            int digit = digits[i] - '0';
            if (doubleDigit)
            {
                digit *= 2;
                if (digit > 9)
                    digit -= 9;
            }

            sum += digit;
            doubleDigit = !doubleDigit;
        }

        return sum % 10 == 0;
    }

    private static bool IsHexDigit(char c) =>
        (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f');
}
