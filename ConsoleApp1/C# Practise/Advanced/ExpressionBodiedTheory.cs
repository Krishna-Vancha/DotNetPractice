using System;

namespace ConsoleApp1.CSharpPractise.Advanced;

/*
 * =============================================================================
 * Expression-Bodied Members — Study Notes (Clean Syntax)
 * =============================================================================
 *
 * Definition: Introduced in C# 6 and expanded in later versions, expression-bodied
 * members provide a highly condensed, readable syntax for member definitions.
 * They replace traditional multi-line blocks `{ ... }` containing a single expression
 * with the "fat arrow" operator (`=>`).
 *
 * 1) Core Mechanics:
 * - Syntax: `member_signature => expression;`
 * - It can be used *only* when the body consists of a single statement or expression.
 * - For value-returning members (like methods or getters), the `return` keyword
 *   is implicit and MUST NOT be written.
 *
 * 2) Supported Member Categories:
 * - Methods (Value-returning or void)
 * - Read-Only Properties
 * - Property Accessors (Explicit get/set blocks)
 * - Constructors & Destructors
 * - Indexers
 *
 * 3) Architectural Benefit: Clean Code Architecture
 * - Drastically minimizes boilerplate noise in small utility classes, data models,
 *   DTOs, and domain entities without introducing runtime performance penalties.
 * =============================================================================
 */

public static class ExpressionBodiedTheory
{
    public static void RunDemo()
    {
        Console.WriteLine("=== ExpressionBodiedTheory ===");

        UserProfile user = new UserProfile("Bunty", "Singh");

        Console.WriteLine($"Full Name: {user.FullName}");
        Console.WriteLine($"Display Greeting: {user.GetGreeting()}");

        user.Age = 26;
        Console.WriteLine($"Assigned Age: {user.Age}");

        user.LogToConsole();

        new MemberVsLambdaDemo().RunPipeline();
    }
}

#region Expression-Bodied Member Targets

public class UserProfile
{
    private string _firstName;
    private string _lastName;
    private int _age;

    // 1. EXPRESSION-BODIED CONSTRUCTOR
    public UserProfile(string firstName, string lastName) =>
        (_firstName, _lastName) = (firstName, lastName);

    // 2. EXPRESSION-BODIED READ-ONLY PROPERTY
    public string FullName => $"{_firstName} {_lastName}";

    // 3. EXPRESSION-BODIED PROPERTY ACCESSORS (GET / SET)
    public int Age
    {
        get => _age;
        set => _age = value > 0 ? value : throw new ArgumentException("Age must be positive.");
    }

    // 4. EXPRESSION-BODIED METHOD (VALUE-RETURNING)
    public string GetGreeting() => $"Hello, my name is {FullName}!";

    // 5. EXPRESSION-BODIED METHOD (VOID)
    public void LogToConsole() => Console.WriteLine($"Log Triggered for: {FullName}");
}

#endregion

/*
 * =============================================================================
 * Expression-Bodied Members vs. Lambda Expressions — Study Notes
 * =============================================================================
 *
 * 1) Expression-Bodied Members (A Compile-Time Syntax Feature):
 * - Purpose: A shorthand way to write class members (methods, properties, constructors)
 *   that contain only a single statement.
 * - Nature: It is a permanent member of the class. It has a fixed name and is
 *   compiled exactly like a traditional method or property block.
 * - Left side of => : The name and signature of a class member.
 *
 * 2) Lambda Expressions (An Inline Anonymous Function Block):
 * - Purpose: An anonymous (nameless) function block passed around as executable data.
 * - Nature: It is treated as an object instance of a delegate type (like Func<>, Action<>)
 *   or an Expression Tree. It can capture local variables (closures).
 * - Left side of => : The input parameters of the anonymous function.
 *
 * 3) Core Mental Model:
 * - Expression-Bodied Members = *How you define a permanent class member concisely.*
 * - Lambda Expressions = *An inline block of code passed on-the-fly to a method or delegate.*
 * =============================================================================
 */

public class MemberVsLambdaDemo
{
    public double Pi => 3.14159;

    public int MultiplyByTwo(int number) => number * 2;

    public void RunPipeline()
    {
        Console.WriteLine($"[Expression-Bodied Member] Call: {MultiplyByTwo(10)}");

        Func<int, int> lambdaProcessor = (x) => x * 2;
        int lambdaResult = lambdaProcessor(10);
        Console.WriteLine($"[Lambda Expression] Execution: {lambdaResult}");

        ExecuteCallback(5, (val) => Console.WriteLine($"Callback caught: {val * 10}"));
    }

    private void ExecuteCallback(int input, Action<int> callbackBlock) =>
        callbackBlock(input);
}
