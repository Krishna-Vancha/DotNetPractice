using System;

namespace ConsoleApp1.C__Practise.PYnative.ExceptionHandling;

public sealed class ExceptionProduct
{
    public string Name { get; set; } = "";
}

/// <summary>
/// Skeleton for Exercise 8. Reject ages outside 0..120 in the setter with ArgumentOutOfRangeException.
/// </summary>
public sealed class ExceptionPerson
{
    public int Age { get; set; }
}

public class ExceptionInsufficientFundsException : Exception
{
    public ExceptionInsufficientFundsException(string message) : base(message)
    {
    }
}

public class ExceptionHttpRequestFailedException : Exception
{
    public int ErrorCode { get; }

    public ExceptionHttpRequestFailedException(string message, int errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }
}
