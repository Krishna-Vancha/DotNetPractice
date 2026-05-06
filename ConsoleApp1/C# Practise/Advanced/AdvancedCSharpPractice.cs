namespace ConsoleApp1.CSharpPractise.Advanced;

/// <summary>
/// Exercise stubs for advanced C#: spans, ref/unsafe-safe patterns, records, async streams, generics, modern syntax.
/// Implement each method; call from <see cref="RootProgram"/> or a small test harness.
/// </summary>
public static class AdvancedCSharpPractice
{
    /// <summary>1. Sum <paramref name="values"/> using <see cref="ReadOnlySpan{T}"/> (no LINQ, no per-call allocation from the array).</summary>
    public static int SumReadOnlySpan(ReadOnlySpan<int> values) => throw new NotImplementedException();

    /// <summary>2. Copy bytes from <paramref name="source"/> into the start of <paramref name="destination"/>; return how many bytes were written.</summary>
    public static int CopyToSpan(ReadOnlySpan<byte> source, Span<byte> destination) => throw new NotImplementedException();

    /// <summary>3. Return the middle segment of a string as <see cref="ReadOnlySpan{T}"/> without allocating a new string (use <see cref="string.AsSpan()"/> / range).</summary>
    public static ReadOnlySpan<char> MiddleAsSpan(string? text, int start, int length) => throw new NotImplementedException();

    /// <summary>4. <c>out</c> + pattern: try to parse <paramref name="s"/> as a positive <see langword="int"/>; on success return <see langword="true"/>; on failure <paramref name="value"/> is <c>0</c>.</summary>
    public static bool TryParsePositiveInt(string? s, out int value) => throw new NotImplementedException();

    /// <summary>5. Use switch expression with property/relational patterns to map a <see cref="DayOfWeek"/> to a short string (e.g. "weekend" vs "weekday").</summary>
    public static string DescribeDay(DayOfWeek day) => throw new NotImplementedException();

    /// <summary>6. Immutable <see langword="record"/>: return a new instance with <c>with { ... }</c> and a new name, based on an existing <paramref name="person"/>.</summary>
    public static NamedPerson WithRenamed(NamedPerson person, string newName) => throw new NotImplementedException();

    /// <summary>7. <see cref="IAsyncEnumerable{T}"/>: async iterator yielding squares <c>0, 1, 4, ... (count-1)^2</c> (use <see langword="await"/> <see cref="Task.Yield"/> or similar between items if you want real async behaviour).</summary>
    public static IAsyncEnumerable<int> SquaresAsync(int count) => throw new NotImplementedException();

    /// <summary>8. Generic: build an array of <c>T</c> using a factory <paramref name="factory"/>, for <c>T</c> with a default ctor.</summary>
    public static T[] CreateMany<T>(int count, Func<T> factory) where T : new() => throw new NotImplementedException();

    /// <summary>9. Pooling: rent a buffer from <c>ArrayPool&lt;T&gt;.Shared</c>, fill with <paramref name="fillByte"/>, return length; buffer must be returned in a <see langword="finally"/> (implement pattern).</summary>
    public static int PooledBufferSample(byte fillByte) => throw new NotImplementedException();

    /// <summary>10. Primary-constructor style type is defined below - implement a method on <see cref="Point"/> that returns squared distance to origin (instance method stub pattern).</summary>
    public static double PointDistanceToOrigin(in Point p) => throw new NotImplementedException();
}

// Types used by the exercises (extend as you practise).
public record NamedPerson(string Name, int YearBorn);

public readonly struct Point(double x, double y)
{
    public double X { get; } = x;
    public double Y { get; } = y;
}
