namespace ConsoleApp1.C__Practise.PYnative.Lists;

public sealed class ListStudent
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
}

public sealed class ListProduct
{
    public string Name { get; init; } = "";
    public double Price { get; init; }
    public string Category { get; init; } = "";
}

public sealed class ListEmployee
{
    public string Name { get; init; } = "";
    public string Department { get; init; } = "";
    public double Salary { get; init; }
}

public sealed class ListPerson
{
    public string Name { get; init; } = "";
    public int Age { get; init; }
}
