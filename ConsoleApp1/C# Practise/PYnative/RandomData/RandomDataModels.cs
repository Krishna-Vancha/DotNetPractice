using System;

namespace ConsoleApp1.C__Practise.PYnative.RandomData;

public sealed class RandomUser
{
    public Guid Id { get; init; }
    public string Username { get; init; } = "";
    public int Age { get; init; }
    public bool IsActive { get; init; }
}
