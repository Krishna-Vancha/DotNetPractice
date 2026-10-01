using System;

namespace ConsoleApp1.C__Practise.PYnative.Dictionary;

public sealed class DictionaryEmployee
{
    public string Name { get; init; } = "";
    public string Department { get; init; } = "";
}

public sealed class DictionaryPoint
{
    public DictionaryPoint(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }
}

public enum DictionaryGameState
{
    Idle,
    Playing,
    Paused,
    GameOver
}

public enum DictionaryGameTrigger
{
    Start,
    Pause,
    Resume,
    End
}

/// <summary>
/// Capacity is stored. Put and TryGet are the exercise (Least Recently Used cache).
/// </summary>
public sealed class DictionaryLruCache<TKey, TValue> where TKey : notnull
{
    public DictionaryLruCache(int capacity)
    {
        Capacity = capacity;
    }

    public int Capacity { get; }

    public void Put(TKey key, TValue value)
        => throw new NotImplementedException();

    public bool TryGet(TKey key, out TValue value)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Maps command names to execute/undo actions. Methods are the exercise.
/// </summary>
public sealed class DictionaryCommandEngine
{
    public void Register(string name, Action execute, Action undo)
        => throw new NotImplementedException();

    public void Execute(string name)
        => throw new NotImplementedException();

    public void Undo()
        => throw new NotImplementedException();
}

/// <summary>
/// Sparse grid keyed by (row, column). Methods are the exercise.
/// </summary>
public sealed class DictionarySparseMatrix
{
    public void Set(int row, int column, double value)
        => throw new NotImplementedException();

    public double Get(int row, int column)
        => throw new NotImplementedException();

    public double DotProductOfRows(int rowA, int rowB)
        => throw new NotImplementedException();
}

public interface DictionaryIGreeter
{
    string Greet();
}

public sealed class DictionaryEnglishGreeter : DictionaryIGreeter
{
    public string Greet() => "Hello!";
}

/// <summary>
/// Register and Resolve are the exercise.
/// </summary>
public sealed class DictionaryDiContainer
{
    public void Register<TService>(Func<TService> factory)
        => throw new NotImplementedException();

    public TService Resolve<TService>()
        => throw new NotImplementedException();
}
