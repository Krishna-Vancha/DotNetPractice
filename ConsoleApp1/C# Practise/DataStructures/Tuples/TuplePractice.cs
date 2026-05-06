namespace ConsoleApp1.CSharpPractise.DataStructures.Tuples;

/// <summary>
/// Value-tuple exercises: return types, deconstruction, named elements, nullable tuples.
/// Implement each method (replace the <c>throw new NotImplementedException()</c> bodies).
/// </summary>
public static class TuplePractice
{
    /// <summary>1. Sum of all values and how many there were. Empty input → (0, 0).</summary>
    public static (int sum, int count) SumAndCount(IEnumerable<int> numbers) => throw new NotImplementedException();

    /// <summary>2. Return <c>"Last, First"</c> from a name pair.</summary>
    public static string FormatLastFirst((string First, string Last) name) => throw new NotImplementedException();

    /// <summary>3. If <paramref name="s"/> parses to a positive integer, return <c>(true, value)</c>; else <c>(false, 0)</c>.</summary>
    public static (bool ok, int value) TryParsePositiveInt(string? s) => throw new NotImplementedException();

    /// <summary>4. Smallest and largest in <paramref name="values"/>; throw if empty.</summary>
    public static (int min, int max) MinMax(int[] values) => throw new NotImplementedException();

    /// <summary>5. Division: if <paramref name="b"/> is 0, return <see langword="null"/>; else <c>(quotient, remainder)</c>.</summary>
    public static (int quotient, int remainder)? DivWithRemainder(int a, int b) => throw new NotImplementedException();

    /// <summary>6. Swap the two parts of a pair (practise returning a new tuple).</summary>
    public static (TSecond, TFirst) Swap<TFirst, TSecond>((TFirst first, TSecond second) pair) => throw new NotImplementedException();

    /// <summary>7. Build a named tuple for a point: <c>(X, Y)</c> from two doubles.</summary>
    public static (double X, double Y) MakePoint(double x, double y) => throw new NotImplementedException();

    /// <summary>8. Return <see langword="true"/> if both tuples have the same values (use tuple equality).</summary>
    public static bool TuplesEqual((int, string) a, (int, string) b) => throw new NotImplementedException();
}
