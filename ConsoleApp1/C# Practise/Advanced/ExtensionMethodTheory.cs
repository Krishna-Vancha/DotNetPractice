using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.CSharpPractise.Advanced;

/*
 * =============================================================================
 * Extension Methods in C# — study notes (interview-oriented)
 * =============================================================================
 *
 * Quick Review/Subtopics:
 * Extension methods?, static classes?, "this" keyword usage?,
 * LINQ usage?, chaining?, limitations?, best practices?,
 * extension vs inheritance?, extension vs helper methods?
 *
 * Extension methods allow you to **add new methods to existing types**
 * without modifying their source code or creating derived classes.
 *
 * =============================================================================
 *
 * 1) Core Concept: What are Extension Methods?
 * =============================================================================
 *
 * - Special static methods
 * - Defined in static classes
 * - First parameter uses "this" keyword
 *
 * Example:
 *      public static int Square(this int x)
 *
 * Usage:
 *      int result = 5.Square();
 *
 * Think:
 * - "Add methods to a class you don’t own"
 *
 * =============================================================================
 *
 * 2) Basic Syntax
 * =============================================================================
 *
 * Rules:
 * - Must be inside a static class
 * - Method must be static
 * - First parameter must use "this"
 *
 * Example:
 *      public static class MyExtensions
 *      {
 *          public static void Print(this string str)
 *          {
 *              Console.WriteLine(str);
 *          }
 *      }
 *
 * =============================================================================
 *
 * 3) How It Works Internally
 * =============================================================================
 *
 * Compiler converts:
 *
 *      str.Print();
 *
 * Into:
 *
 *      MyExtensions.Print(str);
 *
 * So:
 * - No real modification of original type
 * - Just syntactic sugar
 *
 * =============================================================================
 *
 * 4) Extension Methods with LINQ
 * =============================================================================
 *
 * LINQ is built using extension methods on IEnumerable<T>
 *
 * Examples:
 * - Where()
 * - Select()
 * - OrderBy()
 *
 * Example:
 *      numbers.Where(x => x > 5);
 *
 * Internally:
 *      Enumerable.Where(numbers, ...)
 *
 * =============================================================================
 *
 * 5) Method Chaining (Fluent Syntax)
 * =============================================================================
 *
 * Extension methods enable chaining:
 *
 *      numbers.Where(x => x > 5)
 *             .Select(x => x * 2)
 *             .ToList();
 *
 * Benefits:
 * - Readability
 * - Declarative style
 *
 * =============================================================================
 *
 * 6) Adding Extensions to Custom Types
 * =============================================================================
 *
 * You can extend:
 * - Classes
 * - Structs
 * - Interfaces
 *
 * Example:
 *      public static bool IsAdult(this Person p)
 *
 * =============================================================================
 *
 * 7) Limitations (VERY IMPORTANT)
 * =============================================================================
 *
 * - Cannot access private members
 * - Cannot override existing methods
 * - Instance methods take priority over extension methods
 * - Must import namespace to use
 *
 * =============================================================================
 *
 * 8) Extension Methods vs Inheritance
 * =============================================================================
 *
 * Extension Methods:
 * - No hierarchy change
 * - Works on sealed classes
 * - More flexible
 *
 * Inheritance:
 * - Requires base class control
 * - Tighter coupling
 *
 * =============================================================================
 *
 * 9) Extension Methods vs Helper Methods
 * =============================================================================
 *
 * Helper Method:
 *      StringHelper.Print(str);
 *
 * Extension Method:
 *      str.Print();
 *
 * Advantage:
 * - Cleaner syntax
 * - Better readability
 *
 * =============================================================================
 *
 * 10) Real-World Use Cases
 * =============================================================================
 *
 * - LINQ (most important)
 * - String utilities
 * - Validation helpers
 * - Mapping / transformation logic
 * - Fluent APIs
 *
 * =============================================================================
 *
 * 11) Performance Considerations
 * =============================================================================
 *
 * - No major overhead vs static methods
 * - Resolved at compile-time
 *
 * NOTE:
 * - No runtime penalty like reflection
 *
 * =============================================================================
 *
 * 12) Best Practices
 * =============================================================================
 *
 * - Keep extension methods small and focused
 * - Avoid overusing (can reduce readability)
 * - Use meaningful names
 * - Group logically in namespaces
 * - Prefer pure functions (no side effects)
 *
 * =============================================================================
 */

public static class ExtensionMethodTheory
{
    public static void RunAllDemos()
    {
        BasicExtensionDemo();
        ChainingDemo();
        CustomTypeExtensionDemo();
    }

    #region Basic Extension

    public static void BasicExtensionDemo()
    {
        string message = "Hello Extension Methods";

        message.Print(); // looks like instance method
    }

    #endregion

    #region Method Chaining

    public static void ChainingDemo()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };

        var result = numbers
            .Where(x => x > 2)
            .MultiplyBy(2)
            .ToList();

        Console.WriteLine(string.Join(", ", result));
    }

    #endregion

    #region Custom Type Extension

    public static void CustomTypeExtensionDemo()
    {
        var person = new Person { Age = 20 };

        Console.WriteLine(person.IsAdult());
    }

    #endregion
}

public static class MyExtensions
{
    public static void Print(this string str)
    {
        Console.WriteLine(str);
    }

    public static IEnumerable<int> MultiplyBy(this IEnumerable<int> source, int factor)
    {
        foreach (var item in source)
        {
            yield return item * factor;
        }
    }

    public static bool IsAdult(this Person person)
    {
        return person.Age >= 18;
    }
}

public class Person
{
    public int Age { get; set; }
}