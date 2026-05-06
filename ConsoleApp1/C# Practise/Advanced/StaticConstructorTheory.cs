using System;

namespace ConsoleApp1.CSharpPractise.Advanced;

/*
 * =============================================================================
 * Static Constructor in C# — study notes (interview-oriented)
 * =============================================================================
 *
 * Quick Review/Subtopics:
 * static constructor?, initialization timing?, CLR behavior?,
 * static fields initialization?, thread safety?, order of execution?,
 * static vs instance constructor?, beforefieldinit?, limitations?
 *
 * Static constructor is used to **initialize static data or perform
 * one-time setup for a class**.
 *
 * =============================================================================
 *
 * 1) Core Concept: What is a Static Constructor?
 * =============================================================================
 *
 * - Special constructor for initializing static members
 * - Declared using "static" keyword
 * - No access modifier allowed
 * - No parameters
 *
 * Example:
 *      static MyClass()
 *      {
 *          // initialization logic
 *      }
 *
 * Think:
 * - "Runs once per type (not per object)"
 *
 * =============================================================================
 *
 * 2) When Does It Execute? (VERY IMPORTANT)
 * =============================================================================
 *
 * - Executed automatically by CLR
 * - Runs BEFORE:
 *      - First object creation OR
 *      - First static member access
 *
 * Example:
 *      MyClass.DoSomething(); // triggers static constructor
 *
 * Key rule:
 * - Runs ONLY ONCE per AppDomain
 *
 * =============================================================================
 *
 * 3) Static vs Instance Constructor
 * =============================================================================
 *
 * Static Constructor:
 * - Runs once
 * - No parameters
 * - Initializes static fields
 *
 * Instance Constructor:
 * - Runs every time object is created
 * - Can take parameters
 * - Initializes instance fields
 *
 * =============================================================================
 *
 * 4) Order of Execution
 * =============================================================================
 *
 * Execution order:
 *
 * 1. Static field initializers
 * 2. Static constructor
 * 3. Instance field initializers
 * 4. Instance constructor
 *
 * =============================================================================
 *
 * 5) Example Flow
 * =============================================================================
 *
 * Access static member →
 * Static fields initialized →
 * Static constructor runs →
 * Method executes
 *
 * =============================================================================
 *
 * 6) Thread Safety (IMPORTANT)
 * =============================================================================
 *
 * - Guaranteed by CLR
 * - Executed in a thread-safe manner
 * - Only one thread runs it
 *
 * No need for:
 * - locks
 * - double-checking
 *
 * =============================================================================
 *
 * 7) Restrictions / Limitations
 * =============================================================================
 *
 * - Cannot have parameters
 * - Cannot have access modifiers
 * - Cannot be called explicitly
 * - Only one static constructor per class
 *
 * =============================================================================
 *
 * 8) beforefieldinit (Advanced Concept)
 * =============================================================================
 *
 * - If NO static constructor:
 *      CLR may initialize type anytime before first access
 *
 * - If static constructor EXISTS:
 *      CLR guarantees "precise" initialization timing
 *
 * Interview Insight:
 * - Static constructor removes beforefieldinit optimization
 *
 * =============================================================================
 *
 * 9) Common Use Cases
 * =============================================================================
 *
 * - Initialize static fields
 * - Load configuration
 * - Initialize cache
 * - Setup logging
 * - Precompute values
 *
 * =============================================================================
 *
 * 10) Performance Considerations
 * =============================================================================
 *
 * - Small overhead on first access only
 * - Avoid heavy operations
 *
 * Why?
 * - Blocks type usage until complete
 *
 * =============================================================================
 *
 * 11) Static Class + Static Constructor
 * =============================================================================
 *
 * - Static classes can also have static constructors
 *
 * Example:
 *      static class Config
 *      {
 *          static Config() { }
 *      }
 *
 * =============================================================================
 *
 * 12) Best Practices
 * =============================================================================
 *
 * - Keep static constructor lightweight
 * - Avoid exceptions (can break type usage)
 * - Use for essential initialization only
 * - Prefer lazy initialization if expensive
 *
 * =============================================================================
 */

public class StaticConstructorTheory
{
    public static void RunAllDemos()
    {
        Demo.Run();
    }
}

public class Demo
{
    static int staticValue;

    // Static constructor
    static Demo()
    {
        Console.WriteLine("Static Constructor Called");
        staticValue = 100;
    }

    // Instance constructor
    public Demo()
    {
        Console.WriteLine("Instance Constructor Called");
    }

    public static void Run()
    {
        Console.WriteLine("Main started");

        // Triggers static constructor
        Console.WriteLine($"Static Value: {staticValue}");

        // Instance creation
        var obj1 = new Demo();
        var obj2 = new Demo();
    }
}