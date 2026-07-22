using System;
using System.Collections.Generic;

namespace ConsoleApp1.CSharpPractise.Advanced;

/*
 * =============================================================================
 * Records in C# — interview notes (read with the code below)
 * =============================================================================
 *  QuickReview/Subtopics: value equality, init-only properties, with expressions,
 *  positional records, nominal records, deconstruction, inheritance, record struct.
 *
 * 1) What is a record?
 *    - A reference type by default, declared with the record / record class keyword.
 *    - Designed for immutable data models where equality is based on values, not identity.
 *    - Compiler generates useful members: Equals, GetHashCode, ==, !=, ToString, and
 *      with-support through a copy-style method.
 *    - Example record class:
 *        public record class Customer(string Name, string Email);
 *
 * 2) Record class vs class
 *    - class equality normally means reference identity unless you override it.
 *    - record equality means same runtime record type and same stored values.
 *    - ToString prints a readable shape like Person { FirstName = Ada, LastName = Lovelace }.
 *
 * 3) Positional records
 *    - Syntax: public record Person(string FirstName, string LastName);
 *    - Primary constructor parameters become public init-only properties by default.
 *    - Supports deconstruction: var (first, last) = person;
 *
 * 4) Nominal records
 *    - Syntax: public record Product { public string Name { get; init; } = ""; }
 *    - Useful when you want a normal property body instead of a positional shape.
 *    - record class is explicit syntax for reference-type records:
 *        public sealed record class Product { ... }
 *
 * 5) init-only properties
 *    - init lets callers assign a property during object initialization, but not after.
 *    - Good for immutable DTO-style objects: new Product { Name = "Book" }.
 *
 * 6) with expressions
 *    - with creates a copy with selected changed values.
 *    - Original instance stays unchanged: var updated = old with { Name = "New" };
 *
 * 7) Record inheritance
 *    - record classes can inherit from other record classes.
 *    - Equality includes the record runtime type, so Person(...) and Employee(...)
 *      with the same base values are not equal.
 *
 * 8) record struct
 *    - Value type version of records, introduced for small value-like data.
 *    - record struct is mutable by default; readonly record struct is immutable-friendly.
 *    - Example mutable record struct:
 *        public record struct Point2D(double X, double Y);
 *    - Example immutable record struct:
 *        public readonly record struct Money(decimal Amount, string Currency);
 *    - record struct also gets value equality, ToString, deconstruction for positional
 *      records, and with expressions.
 *
 * 9) Practical use
 *    - Prefer records for request/response DTOs, config snapshots, events/messages,
 *      immutable state, and value-based tests.
 *    - Prefer classes when identity, lifecycle, mutation, or rich behavior is the main idea.
 * =============================================================================
 */

// Interview Quick revision Notes for Records

/// <summary>Runnable samples + notes in the file header for record interviews.</summary>
public static class RecordsTheory
{
    public static void RunAllDemos()
    {
        PositionalRecord_Section();
        ValueEquality_Section();
        WithExpression_Section();
        NominalRecordAndInit_Section();
        Inheritance_Section();
        RecordStruct_Section();
    }

    #region Positional records and deconstruction

    /*
     * Section: concise immutable data shape with generated properties and Deconstruct.
     */
    public static void PositionalRecord_Section()
    {
        Person person = new("Ada", "Lovelace");

        string first = person.FirstName;
        string last = person.LastName;
        var (deconstructedFirst, deconstructedLast) = person;

        _ = first;
        _ = last;
        _ = deconstructedFirst;
        _ = deconstructedLast;
    }

    public record Person(string FirstName, string LastName);

    #endregion

    #region Value equality

    /*
     * Section: records compare by values; normal classes compare by reference by default.
     */
    public static void ValueEquality_Section()
    {
        Person p1 = new("Ada", "Lovelace");
        Person p2 = new("Ada", "Lovelace");

        bool sameValues = p1 == p2; // true
        bool equalsResult = p1.Equals(p2); // true

        HashSet<Person> people = new() { p1, p2 }; // one item because values are equal
        int uniqueCount = people.Count;

        _ = sameValues;
        _ = equalsResult;
        _ = uniqueCount;
    }

    #endregion

    #region with expressions

    /*
     * Section: make a non-mutating copy with selected property changes.
     */
    public static void WithExpression_Section()
    {
        Person original = new("Ada", "Lovelace");
        Person renamed = original with { LastName = "Byron" };

        bool originalStayedSame = original.LastName == "Lovelace";
        bool changedCopy = renamed.LastName == "Byron";

        _ = originalStayedSame;
        _ = changedCopy;
    }

    #endregion

    #region Nominal records and init-only properties

    /*
     * Section: object-initializer style record with validation-friendly property shape.
     */
    public static void NominalRecordAndInit_Section()
    {
        Product book = new()
        {
            Id = 1,
            Name = "C# Notes",
            Price = 25.00m
        };

        Product discounted = book with { Price = 20.00m };
        Customer customer = new("Ada", "ada@example.com");
        string customerText = customer.ToString(); // generated readable ToString

        _ = book;
        _ = discounted;
        _ = customerText;
    }

    public sealed record class Product
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;  //this is a field initializer, it is used to initialize the field with a default value.
        public decimal Price { get; init; }  //init is used to initialize the field with a value. it is a readonly property.
    }

    public record class Customer(string Name, string Email);

    #endregion

    #region Record inheritance

    /*
     * Section: record classes can inherit, but equality still respects runtime type.
     */
    public static void Inheritance_Section()
    {
        Person basePerson = new("Grace", "Hopper");
        Employee employee = new("Grace", "Hopper", "Compiler Team");

        bool differentRuntimeRecordTypes = basePerson != employee; // true
        string team = employee.Team;

        _ = differentRuntimeRecordTypes;
        _ = team;
    }

    public sealed record Employee(string FirstName, string LastName, string Team)
        : Person(FirstName, LastName);

    #endregion

    #region Record structs

    /*
     * Section: value-type records for small data; readonly keeps the value immutable.
     */
    public static void RecordStruct_Section()
    {
        Money price = new(10m, "USD");
        Money samePrice = new(10m, "USD");
        Money euroPrice = price with { Currency = "EUR" };
        MutablePoint point = new(1, 2);
        point.X = 10; // record struct is mutable by default

        bool sameValue = price == samePrice; // true
        string currency = euroPrice.Currency;
        var (amount, moneyCurrency) = price; // positional record struct deconstruction

        _ = sameValue;
        _ = currency;
        _ = point;
        _ = amount;
        _ = moneyCurrency;
    }

    public readonly record struct Money(decimal Amount, string Currency);

    public record struct MutablePoint(double X, double Y);

    #endregion
}
