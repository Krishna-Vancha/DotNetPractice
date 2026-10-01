using System;

namespace ConsoleApp1.C__Practise.PYnative.Beginners;

public sealed class BeginnerCar
{
    public string Make { get; init; } = "";
    public string Model { get; init; } = "";
    public int Year { get; init; }
}

public sealed class BeginnerBook
{
    public BeginnerBook(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public string Title { get; }
    public string Author { get; }
}

public sealed class BeginnerBankAccount
{
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount) => throw new NotImplementedException();

    public void Withdraw(decimal amount) => throw new NotImplementedException();
}

public class BeginnerAnimal
{
    public virtual string MakeSound() => throw new NotImplementedException();
}

public sealed class BeginnerDog : BeginnerAnimal
{
    public override string MakeSound() => throw new NotImplementedException();
}

public readonly struct BeginnerPoint
{
    public BeginnerPoint(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }
}

public readonly struct BeginnerColor
{
    public BeginnerColor(int red, int green, int blue)
    {
        R = red;
        G = green;
        B = blue;
    }

    public int R { get; }
    public int G { get; }
    public int B { get; }
}

public sealed record BeginnerProduct(string Name, decimal Price);

public sealed record BeginnerStudent(string Name, string Grade);
