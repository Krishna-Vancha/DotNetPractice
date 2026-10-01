using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.ExtensionMethods;

// Source: https://pynative.com/csharp-extension-methods-exercises/ (20 exercises)
// Extension methods live on this static class. Call them as extensions or as static methods.

public static class ExtensionMethodExercises
{
    // Question 1: Convert a space-separated or snake_case string into PascalCase.
    public static string ToPascalCase(this string input)
        => throw new NotImplementedException();

    // Question 2: True when the int is even.
    public static bool IsEven(this int number)
        => throw new NotImplementedException();

    // Question 2: True when the int is odd.
    public static bool IsOdd(this int number)
        => throw new NotImplementedException();

    // Question 3: Count words in a sentence, ignoring extra spaces.
    public static int WordCount(this string sentence)
        => throw new NotImplementedException();

    // Question 4: Format a fraction as a percentage string with the given number of decimal places.
    public static string ToPercentage(this double value, int decimalPlaces)
        => throw new NotImplementedException();

    // Question 5: True when the date falls on Saturday or Sunday.
    public static bool IsWeekend(this DateTime date)
        => throw new NotImplementedException();

    // Question 6: Cut text at maxLength and append "..." when it is longer.
    public static string Truncate(this string text, int maxLength)
        => throw new NotImplementedException();

    // Question 7: True when the sequence contains no elements.
    public static bool IsEmpty<T>(this IEnumerable<T> source)
        => throw new NotImplementedException();

    // Question 8: Return a new sequence with the elements in random order. Sample order varies.
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        => throw new NotImplementedException();

    // Question 9: Remove duplicate elements from the list in place.
    public static void RemoveDuplicates<T>(this IList<T> list)
        => throw new NotImplementedException();

    // Question 10: Return count random elements. Which items are chosen varies between runs.
    public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count)
        => throw new NotImplementedException();

    // Question 11: Age in whole years as of DateTime.Today, accounting for a birthday not yet reached this year.
    public static int Age(this DateTime birthDate)
        => throw new NotImplementedException();

    // Question 12: True when the string is a properly formatted email address.
    public static bool IsValidEmail(this string email)
        => throw new NotImplementedException();

    // Question 13: Join strings with a custom separator.
    public static string JoinStrings(this IEnumerable<string> source, string separator)
        => throw new NotImplementedException();

    // Question 14: Serialize any object to a JSON string.
    public static string ToJson<T>(this T obj)
        => throw new NotImplementedException();

    // Question 14: Deserialize a JSON string back into T.
    public static T FromJson<T>(this string json)
        => throw new NotImplementedException();

    // Question 15: True when item is one of the supplied values.
    public static bool In<T>(this T item, params T[] values)
        => throw new NotImplementedException();

    // Question 16: Return the existing value, or add and return the factory result when the key is missing.
    public static V GetOrAdd<K, V>(this IDictionary<K, V> dictionary, K key, Func<V> factory)
        where K : notnull
        => throw new NotImplementedException();

    // Question 17: Walk InnerException until the root cause exception.
    public static Exception GetInnermostException(this Exception exception)
        => throw new NotImplementedException();

    // Question 18: Page an IQueryable with 1-based pageNumber and pageSize (Skip/Take).
    public static IQueryable<T> Page<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        => throw new NotImplementedException();

    // Question 19: Read the [Description] attribute on an enum member, or the member name if it has none.
    // The test passes ExtensionOrderStatus.Shipped, whose description is "Order Shipped".
    public static string GetDescription(this Enum value)
        => throw new NotImplementedException();

    // Question 20: Pass the value into function and return the result, so calls can be chained.
    public static TResult Pipe<T, TResult>(this T input, Func<T, TResult> function)
        => throw new NotImplementedException();
}
