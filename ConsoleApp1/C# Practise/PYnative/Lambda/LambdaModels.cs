namespace ConsoleApp1.C__Practise.PYnative.Lambda;

public sealed class LambdaProduct
{
    public string Name { get; init; } = "";
    public double Price { get; init; }
}

public sealed class LambdaUser
{
    public int Id { get; init; }
    public string Username { get; init; } = "";
    public string Email { get; init; } = "";
}

public sealed class LambdaEmployee
{
    public string FirstName { get; init; } = "";
    public string LastName { get; init; } = "";
    public int YearsOfExperience { get; init; }
}

public sealed class LambdaOrder
{
    public double Amount { get; init; }
    public bool IsPaid { get; init; }
}
