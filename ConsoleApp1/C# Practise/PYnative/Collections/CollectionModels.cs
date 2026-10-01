using System;
using System.Collections.ObjectModel;

namespace ConsoleApp1.C__Practise.PYnative.Collections;

public sealed class CollectionInventoryProduct
{
    public CollectionInventoryProduct(int id, string name, int quantity)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

    public override string ToString() => $"{Name} (Id={Id}, Qty={Quantity})";
}

public sealed class CollectionEmployee
{
    public CollectionEmployee(string name, decimal salary, string email)
    {
        Name = name;
        Salary = salary;
        Email = email;
    }

    public string Name { get; }
    public decimal Salary { get; }
    public string Email { get; }
}

public sealed class CollectionPricedProduct
{
    public CollectionPricedProduct(string name, string category, decimal price)
    {
        Name = name;
        Category = category;
        Price = price;
    }

    public string Name { get; }
    public string Category { get; }
    public decimal Price { get; }
}

public sealed class CollectionStudent
{
    public CollectionStudent(string firstName, string lastName, int grade)
    {
        FirstName = firstName;
        LastName = lastName;
        Grade = grade;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public int Grade { get; }

    public override string ToString() => $"{FirstName} {LastName} (Grade: {Grade})";
}

/// <summary>
/// Start with MaxUsers=100 and Theme=Dark. Settings is a read-only view; AddSetting changes the private list.
/// </summary>
public sealed class CollectionSystemConfig
{
    public ReadOnlyCollection<string> Settings
        => throw new NotImplementedException();

    public void AddSetting(string setting)
        => throw new NotImplementedException();
}
