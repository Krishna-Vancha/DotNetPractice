using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ConsoleApp1.C__Practise.PYnative.Lambda;

// Source: https://pynative.com/csharp-lambda-expressions-exercises/
// The page title says 25 problems; the page lists 20 exercises. These stubs follow the page.
//
// Computation exercises are method stubs. Exercise 18 asks you to define a type: implement RunExercise18().

public static partial class LambdaExercises
{
    // Question 1: Lambda assigned to Func<int, int> that returns the square of its input.
    public static Func<int, int> CreateSquareFunc()
        => throw new NotImplementedException();

    // Question 2: Func<int, bool> lambda that returns true when the number is even.
    public static Func<int, bool> CreateIsEvenFunc()
        => throw new NotImplementedException();

    // Question 3: Func<string, int, bool> lambda that returns true when the string is longer than the integer.
    public static Func<string, int, bool> CreateIsLongerThanFunc()
        => throw new NotImplementedException();

    // Question 4: Action<string> lambda that prints the message prefixed with "[Log]: ".
    public static Action<string> CreateLogAction()
        => throw new NotImplementedException();

    // Question 5: Func<string, string, string> lambda that joins two strings with a space.
    public static Func<string, string, string> CreateFullNameFunc()
        => throw new NotImplementedException();

    // Question 6: Filter odd numbers from a list using Where() and a lambda.
    public static IReadOnlyList<int> FilterOddNumbers(IEnumerable<int> numbers)
        => throw new NotImplementedException();

    // Question 7: Convert every string to uppercase using Select() and a lambda.
    public static IReadOnlyList<string> ToUppercase(IEnumerable<string> words)
        => throw new NotImplementedException();

    // Question 8: First product whose Price is greater than minPrice, or null if none.
    public static LambdaProduct? FindFirstProductOver(IEnumerable<LambdaProduct> products, double minPrice)
        => throw new NotImplementedException();

    // Question 9: Sort strings by length ascending using OrderBy() and a lambda.
    public static IReadOnlyList<string> SortByLength(IEnumerable<string> words)
        => throw new NotImplementedException();

    // Question 10: Project each user's Email using Select() and a lambda.
    public static IReadOnlyList<string> ExtractEmails(IEnumerable<LambdaUser> users)
        => throw new NotImplementedException();

    // Question 11: True when any number is negative, using Any() and a lambda.
    public static bool HasNegativeNumber(IEnumerable<int> numbers)
        => throw new NotImplementedException();

    // Question 12: Count strings that start with 'A' using Count() and a lambda.
    public static int CountStartingWithA(IEnumerable<string> names)
        => throw new NotImplementedException();

    // Question 13: Project employees to "FullName - Senior: True/False" (senior when YearsOfExperience > 5).
    public static IReadOnlyList<string> SummarizeEmployees(IEnumerable<LambdaEmployee> employees)
        => throw new NotImplementedException();

    // Question 14: Group words by first letter. Return lines like "a: apple, avocado".
    public static IReadOnlyList<string> GroupByFirstLetter(IEnumerable<string> words)
        => throw new NotImplementedException();

    // Question 15: Sum Amount for orders where IsPaid is true (0 for unpaid), using Sum() and a lambda.
    public static double SumPaidRevenue(IEnumerable<LambdaOrder> orders)
        => throw new NotImplementedException();

    // Question 16: Statement lambda Func<int, int, int> that prints the larger number, then returns the absolute difference.
    public static Func<int, int, int> CreateCompareAndDiffFunc()
        => throw new NotImplementedException();

    // Question 17: Keep dictionary entries with stock count > 0. Return lines like "Keyboard: 12".
    public static IReadOnlyList<string> FilterInStock(IEnumerable<KeyValuePair<string, int>> stock)
        => throw new NotImplementedException();

    // Exercise 18: Inline Event Subscription
    //
    // Practice Problem: Given a custom class with a public event EventHandler ThresholdReached, use a lambda expression to subscribe to the event and print a message when it fires.
    //
    // Given Input: temperature = 105
    //
    // Expected Output:
    // Warning: Temperature threshold reached!
    //
    // --- Your solution: TemperatureSensor + RunExercise18() below ---

    public static void RunExercise18() =>
        throw new NotImplementedException();

    // Question 19: Return a Func<int, int> that multiplies by the captured factor parameter (later changes to the caller's variable do not apply).
    public static Func<int, int> CreateMultiplier(int factor)
        => throw new NotImplementedException();

    // Question 20: Expression<Func<int, bool>> for number => number > 5, kept as an expression tree.
    public static Expression<Func<int, bool>> CreateGreaterThanFiveExpression()
        => throw new NotImplementedException();
}
