using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.CSharpPractise.Advanced;

/*
 * =============================================================================
 * IEnumerable in C# — study notes (interview-oriented)
 * =============================================================================
 *
 * Quick Review/Subtopics:
 * IEnumerable?, IEnumerator?, yield return?, deferred execution?, foreach internals?,
 * LINQ integration? (data is not stored inless converted to , like .TOLIST()), IEnumerable vs ICollection vs IList ?, lazy evaluation?,
 * multiple enumeration pitfalls?, covariance?, performance considerations?.
 * DeferredExecutionDemo - when Linq is built , it is not executed until used to itearate.
 * 
 * 
 *
 * In C#, IEnumerable<T> is the **base abstraction for iteration**. It enables
 * foreach loops, LINQ queries, and lazy execution via yield return.
 *
 * =============================================================================
 *
 * 1) Core Concept: What is IEnumerable?
 * =============================================================================
 *
 * - Defined in System.Collections / System.Collections.Generic
 * - Represents a sequence that can be enumerated (iterated)
 * - Exposes one method:
 *
 *      IEnumerator<T> GetEnumerator();
 *
 * - Allows "foreach" usage
 *
 * Example:
 *      foreach (var item in collection) { }
 *
 * Internally:
 *      Uses IEnumerator → MoveNext() + Current
 *
 * =============================================================================
 *
 * 2) IEnumerable vs IEnumerator
 * =============================================================================
 *
 * IEnumerable:
 * - "Collection that can be iterated"
 * - Factory for enumerators
 *
 * IEnumerator:
 * - "Actual iterator"
 * - Maintains state during iteration
 *
 * IEnumerator members:
 * - bool MoveNext()
 * - T Current
 * - void Reset() (rarely used)
 *
 * Think:
 * - IEnumerable = menu (source of items)
 * - IEnumerator = waiter (delivers items one-by-one)
 *
 * =============================================================================
 *
 * 3) Foreach Internal Compilation (Important Interview Point)
 * =============================================================================
 *
 * foreach is NOT magic. It compiles to:
 *
 * var enumerator = collection.GetEnumerator();
 * while (enumerator.MoveNext())
 * {
 *     var item = enumerator.Current;
 * }
 *
 * IDisposable support:
 * - If enumerator implements IDisposable → wrapped in try/finally
 *
 * =============================================================================
 *
 * 4) Yield Return (Lazy Iteration)
 * =============================================================================
 *
 * - Used to create IEnumerable without storing full collection in memory
 * - Enables deferred execution
 *
 * Keywords:
 * - yield return: returns one element at a time
 * - yield break: stops iteration
 *
 * Execution model:
 * - Compiler generates a state machine
 *
 * Example:
 *      return numbers.Where(x => x > 10);
 * (not executed immediately)
 * yield → streaming Netflix 🎬 (loads as you watch)
   array/list/any sequence data → downloaded movie 📥 (everything ready upfront)
 *
 * =============================================================================
 *
 * 5) Deferred Execution (VERY IMPORTANT)
 * =============================================================================
 *
 * LINQ queries and yield return are NOT executed immediately.
 *
 * Execution happens when:
 * - foreach loop starts
 * - .ToList(), .ToArray() is called
 *
 * Example:
 *      var query = list.Where(x => x > 10); // not executed
 *      query.ToList(); // executed here
 *
 * Risk:
 * - Underlying data may change before execution
 *
 * =============================================================================
 *
 * 6) IEnumerable vs ICollection vs IList
 * =============================================================================
 *
 * IEnumerable:
 * - Read-only iteration
 * - No count, no indexing
 *
 * ICollection:
 * - Has Count
 * - Add/Remove supported
 *
 * IList:
 * - Indexed access (list[i])
 * - Full mutable collection
 *
 * Performance rule:
 * - Prefer IEnumerable for abstraction
 * - Use IList when indexing is required
 *
 * =============================================================================
 *
 * 7) Multiple Enumeration Problem
 * =============================================================================
 *
 * Issue:
 * - IEnumerable may re-execute logic every time it is iterated
 *
 * Example:
 *      var query = GetExpensiveData(); // deferred
 *      query.ToList();
 *      query.ToList(); // recomputed again
 *
 * Fix:
 * - Cache using .ToList() or .ToArray()
 *
 * =============================================================================
 *
 * 8) LINQ & IEnumerable
 * =============================================================================
 *
 * LINQ operates on IEnumerable<T>
 *
 * Operators:
 * - Where → filtering
 * - Select → projection
 * - OrderBy → sorting
 * - GroupBy → grouping
 *
 * Execution types:
 * - Deferred: Where, Select, OrderBy
 * - Immediate: ToList, Count, First
 *
 * =============================================================================
 *
 * 9) yield return vs List<T>
 * =============================================================================
 *
 * yield return:
 * - Lazy
 * - Memory efficient
 * - Slower per iteration
 *
 * List<T>:
 * - Eager
 * - Faster iteration
 * - Higher memory usage
 *
 * =============================================================================
 *
 * 10) Covariance in IEnumerable
 * =============================================================================
 *
 * IEnumerable<T> is covariant:
 *
 * Example:
 *      IEnumerable<string> → IEnumerable<object> (valid)
 *
 * Why:
 * - Read-only nature ensures type safety
 *
 * Not valid for:
 * - IList<T> (invariant due to write operations)
 *
 * =============================================================================
 *
 * 11) Best Practices
 * =============================================================================
 *
 * - Prefer IEnumerable for method parameters (flexibility)
 * - Avoid multiple enumeration (cache when needed)
 * - Use yield return for streaming large datasets
 * - Materialize only when necessary (.ToList())
 * - Be aware of deferred execution side effects
 *
 * =============================================================================
 */

public static class IEnumerableTheory
{
    public static void RunAllDemos()
    {
        YieldReturnDemo();
        DeferredExecutionDemo();
        MultipleEnumerationDemo();
    }

    #region Yield Return

    public static void YieldReturnDemo()
    {
        foreach (var number in GetNumbers())
        {
            Console.WriteLine(number);
        }
    }

    private static IEnumerable<int> GetNumbers()
    {
        yield return 1;
        yield return 2;
        yield return 3;

        yield break; // stops iteration early if needed
    }

    #endregion

    #region Deferred Execution

    public static void DeferredExecutionDemo()
    {
        var data = new List<int> { 1, 2, 3, 4, 5 };

        var query = data.Where(x =>
        {
            Console.WriteLine($"Evaluating {x}");
            return x > 2;
        });

        Console.WriteLine("Query defined (NOT executed yet)");

        foreach (var item in query)
        {
            Console.WriteLine($"Result: {item}");
        }
    }

    #endregion

    #region Multiple Enumeration Problem

    public static void MultipleEnumerationDemo()
    {
        var data = Enumerable.Range(1, 3).Select(x =>
        {
            Console.WriteLine($"Generating {x}");
            return x;
        });

        Console.WriteLine("First iteration:");
        var list1 = data.ToList(); // executes once

        Console.WriteLine("Second iteration:");
        var list2 = data.ToList(); // executes AGAIN (recomputed)
    }

    #endregion
}