using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.C__Practise.Entry
{
    internal class Remember
    {
        //How to add """ in between string while printing

        /* LinkedList:
             * 1. Use?. (null-conditional) when a node / reference may be null — e.g.names.First?.Value, names.Last?.Value(empty LinkedList → First/Last is null).
             * 2. BinarySearch only works on ascending sorted order — Sort first, search, then Reverse if needed; never search after Reverse().
             * 3. LinkedList has no indexer — use First/Last and walk with.Next(forward) or.Previous(backward); first N nodes = .Next from head
             * 4.Start each node walk fresh from names.First or names.Last; use 0-based index when printing[0], [1], …
             * 5. No bulk append on LinkedList — loop a sequence and AddLast each item.
             * 6. Remove(node) is O(1) when you already hold the node; Remove(value) scans the list O(n).
             * 7. Do not modify during foreach — catch InvalidOperationException outside the loop.  

        1.what collections has bulk adding of elements why not other 
        2.Which order does foreach prints
         
         
         
         
         
         
         # 100 C# / .NET Interview Coding Questions (Mid-Level)

## How to use this list
Interviewers rarely just want "the happy path" — they want to see if you *think* about what breaks the happy path. For every question below, don't just write code that works for the obvious input. Before you code, ask yourself:

- What if the input is **empty**, **null**, or **whitespace**?
- What if it's **too big** for the type I'd normally reach for?
- What if it's **negative**, **zero**, or has a **leading sign/zero**?
- What if it has **duplicates**, is already **sorted**, or is a **single element**?
- What happens on **repeated calls**, **concurrent calls**, or with **culture/locale** differences?

The string-to-number question you mentioned is a perfect example: the "general case" instinct is `int.Parse` or `long.Parse`, but a 40+ digit numeric string overflows both — that's when you need `System.Numerics.BigInteger`, or if only add/compare is needed, an array/string-digit-based approach. I've flagged similar traps throughout with a **⚠ Edge case:** line.

---

## 1. Numbers, Parsing & Overflow (10)
1. Convert a numeric string like `"4554545444654564564542452424545432133147987"` into a number and print it.
   ⚠ Edge case: exceeds `long.MaxValue` → use `BigInteger.Parse`, or implement manual digit-array addition if BigInteger is "not allowed."
2. Add two very large numbers represented as strings (no BigInteger allowed) — implement manual carry logic.
3. Parse a string into an `int` safely without throwing on bad input.
   ⚠ Edge case: use `int.TryParse`, and think about what happens with `" 42 "`, `"+42"`, `"42.0"`, `""`.
4. Reverse an integer (e.g., 123 → 321).
   ⚠ Edge case: negative numbers (`-123`), numbers ending in 0 (`120`), and overflow after reversing (`int.MaxValue`).
5. Check if an integer is a palindrome without converting it to a string.
6. Divide two integers without using `/` or `*`.
   ⚠ Edge case: division by zero, negative operands, overflow (`int.MinValue / -1`).
7. Implement `Math.Pow` manually for integer exponents.
   ⚠ Edge case: negative exponent, exponent = 0, base = 0.
8. Detect integer overflow before it happens when adding two `int`s.
9. Convert a `decimal` to `double` and explain/demonstrate the precision loss with a concrete example.
10. Write a currency rounding function (banker's rounding vs. away-from-zero) and show where `Math.Round` defaults surprise people.

## 2. Strings (10)
11. Reverse a string without using `Array.Reverse` or LINQ.
    ⚠ Edge case: empty string, single character, string with surrogate pairs (emoji).
12. Check if a string is a palindrome, ignoring case, spaces, and punctuation.
13. Count occurrences of each character in a string.
14. Find the first non-repeating character in a string.
    ⚠ Edge case: all characters repeat, empty string.
15. Check if two strings are anagrams of each other.
    ⚠ Edge case: different casing, whitespace, Unicode characters.
16. Implement your own `string.Trim()`.
17. Write a method to check if a string has balanced parentheses/brackets.
    ⚠ Edge case: empty string, only closing brackets, mismatched types `"(]"`.
18. Compress a string using counts of repeated characters (e.g., `"aabcccccaaa"` → `"a2b1c5a3"`).
    ⚠ Edge case: compressed string longer than original — should you return original?
19. Find the longest common substring/prefix between two strings.
20. Split a string on multiple delimiters without using `Split(params char[])` naively — handle consecutive delimiters and leading/trailing delimiters.
    ⚠ Edge case: `StringSplitOptions.RemoveEmptyEntries` vs default behavior.

## 3. Arrays & Collections (10)
21. Find duplicate elements in an array.
22. Find the missing number in an array of 1 to N.
    ⚠ Edge case: multiple missing numbers, empty array.
23. Rotate an array by K positions (left and right).
    ⚠ Edge case: K larger than array length, K negative, empty array.
24. Find the second largest number in an array without sorting.
    ⚠ Edge case: all elements equal, array with only one element.
25. Merge two sorted arrays into one sorted array.
26. Find the intersection of two arrays.
    ⚠ Edge case: duplicates within one array — should output have duplicates?
27. Flatten a nested/jagged array (`int[][]`) into a single list.
28. Find all pairs in an array that sum to a target value.
    ⚠ Edge case: same element used twice, duplicate pairs, negative numbers.
29. Implement your own generic `Stack<T>` and `Queue<T>` using an array (not `List<T>`).
    ⚠ Edge case: pop/dequeue on empty collection — throw or return default?
30. Find the maximum sum of a contiguous subarray (Kadane's algorithm).
    ⚠ Edge case: all negative numbers, single element array.

## 4. LINQ (10)
31. Given a `List<Employee>`, group employees by department and get the average salary per department.
32. Use `Aggregate()` to compute a running total, and separately to reverse a string.
33. Find duplicate objects in a list using a custom equality comparer.
34. Use `GroupBy` with a custom key selector and element selector to produce a `Dictionary<string, List<string>>`.
35. Difference between `.First()`, `.FirstOrDefault()`, `.Single()`, `.SingleOrDefault()` — write code that shows each throwing (or not) on an empty/multi-item list.
36. Use `SelectMany` to flatten a `List<List<int>>`.
37. Write a LINQ query using deferred execution and show how the result changes if the source collection is modified before enumeration.
    ⚠ Edge case: multiple enumeration side effects (e.g., a query with `.Select(x => { count++; return x; })` enumerated twice).
38. Implement pagination (skip/take) over a large `IEnumerable<T>` efficiently.
39. Use `Join` and `GroupJoin` to replicate a SQL INNER JOIN and LEFT JOIN between two in-memory collections.
40. Explain and demonstrate the difference between `IEnumerable<T>` and `IQueryable<T>` with a scenario where using the wrong one causes all data to be pulled into memory.

## 5. OOP & C# Language Fundamentals (10)
41. Demonstrate the difference between method overriding (`virtual`/`override`) and method hiding (`new`).
    ⚠ Edge case: calling the hidden/overridden method through a base-class reference — show the surprising output.
42. Implement an abstract class vs. an interface for the same scenario and explain when you'd choose each.
43. Demonstrate boxing and unboxing, and show a case where unboxing throws (`InvalidCastException`).
44. Explain and demonstrate `struct` vs `class` value/reference semantics with a mutation example.
    ⚠ Edge case: mutating a struct inside a `foreach` loop, or a struct stored in a `List<T>`.
45. Implement `IComparable<T>` and `IEquatable<T>` on a custom class correctly, including overriding `GetHashCode()`.
    ⚠ Edge case: what breaks if you override `Equals` but not `GetHashCode`?
46. Demonstrate the difference between `const` and `readonly` (including `static readonly`).
47. Write an extension method and explain why it can't access private members of the type it extends.
48. Demonstrate deep copy vs. shallow copy of an object with a nested reference-type property.
49. Explain and show sealed classes/methods — why would you seal a class?
50. Implement operator overloading (`+`, `==`) for a custom `Money` or `Vector2D` class.
    ⚠ Edge case: overloading `==` without overriding `Equals`/`GetHashCode` — show the inconsistency.

## 6. Exception Handling (8)
51. Write a method with nested `try/catch/finally` and predict the execution order, including when an exception is thrown inside `finally`.
52. Create a custom exception class with proper constructors (including serialization constructor).
53. Demonstrate the difference between `throw;` and `throw ex;` inside a catch block (stack trace preservation).
54. Show what happens when an exception is thrown inside a `using` block — does `Dispose()` still get called?
55. Write code demonstrating exception filters (`catch (Exception ex) when (condition)`).
56. Demonstrate catching multiple exception types and ordering catch blocks correctly (most specific first).
    ⚠ Edge case: unreachable catch block if ordered wrong — does it even compile?
57. Show how an exception thrown in an `async void` method behaves differently than one thrown in `async Task`.
58. Implement retry logic with exponential backoff around a method that may throw transient exceptions.

## 7. Delegates, Events & Functional C# (7)
59. Write a custom delegate, then rewrite the same logic using `Func<>`/`Action<>`.
60. Implement a simple event publisher/subscriber (`event EventHandler`) and show a memory leak caused by not unsubscribing.
61. Demonstrate multicast delegates — what happens when one delegate in the invocation list throws?
62. Explain closures — write a loop that captures a loop variable and show the classic C# 4 vs C# 5+ behavior difference (`for` loop variable capture).
    ⚠ Edge case: this is a famous "gotcha" question — know the pre/post C# 5 behavior change.
63. Implement a simple `IObservable<T>`/`IObserver<T>` pair.
64. Write a lambda that captures a disposable resource — what's the risk?
65. Implement memoization of a function using a `Dictionary` and a `Func<T,TResult>` wrapper.

## 8. Async / Await & Threading (10)
66. Explain and demonstrate the difference between `Task.Run` and directly calling an `async` method.
67. Show a deadlock caused by calling `.Result` or `.Wait()` on an async method from a UI/ASP.NET synchronization context, and how `ConfigureAwait(false)` avoids it.
68. Implement parallel processing of a list of items with `Task.WhenAll`, and handle multiple exceptions using `AggregateException`.
    ⚠ Edge case: one task fails — do the others still complete? How do you observe all exceptions, not just the first?
69. Demonstrate a race condition with two threads incrementing a shared counter, then fix it with `lock`/`Interlocked`.
70. Explain the difference between `Task` and `Thread` — when would you use each?
71. Implement a producer-consumer pattern using `BlockingCollection<T>` or `Channel<T>`.
72. Show what happens when you `await` inside a loop vs. collecting tasks and `await`ing them together — measure/explain the performance difference.
73. Implement a timeout wrapper around an async call using `CancellationTokenSource`.
    ⚠ Edge case: cancellation requested after the task already completed — does it still throw?
74. Demonstrate `async` method returning `void` vs `Task` — why is `async void` discouraged outside event handlers?
75. Write code showing how exceptions are wrapped/unwrapped differently between synchronous code, `Task`, and `async`/`await`.

## 9. Memory, GC & Performance (6)
76. Explain and demonstrate the `IDisposable` pattern correctly (including the `Dispose(bool disposing)` overload for classes with a finalizer).
77. Show a memory leak caused by a static event handler holding a reference to a short-lived object.
78. Demonstrate the difference between `StringBuilder` and string concatenation in a loop — measure and explain why.
    ⚠ Edge case: small number of concatenations vs. thousands — is `StringBuilder` always better?
79. Explain value type vs. reference type allocation (stack vs. heap) with a code example, including where a struct might still end up on the heap (boxing, closures).
80. Demonstrate `Span<T>` or `Memory<T>` usage to avoid an unnecessary array allocation.
81. Explain the generational GC model and show code that would end up in Gen 2 unnecessarily (e.g., large object heap threshold).

## 10. Design Patterns & Architecture (6)
82. Implement the Singleton pattern in a thread-safe way (and explain why the naive version isn't thread-safe).
83. Implement the Repository pattern over Entity Framework and explain what it buys you (and what it can hide).
84. Implement the Factory pattern for creating different payment processor objects.
85. Implement the Strategy pattern to swap sorting/discount algorithms at runtime.
86. Demonstrate Dependency Injection manually (constructor injection) before showing how ASP.NET Core's built-in container does it.
87. Explain SOLID principles with one short code example per principle showing a violation and the fix.

## 11. Entity Framework Core & SQL (8)
88. Write a LINQ-to-EF query and explain why it might generate an inefficient SQL query (e.g., N+1 problem) — then fix it with `.Include()`.
89. Demonstrate the difference between eager loading, lazy loading, and explicit loading.
90. Write code demonstrating optimistic concurrency handling with a `[Timestamp]`/`RowVersion` column.
91. Explain and demonstrate `AsNoTracking()` — when should you use it, and what breaks if you try to update an entity queried this way?
92. Write a raw SQL query via EF Core (`FromSqlRaw`/`FromSqlInterpolated`) and explain SQL injection risk and how interpolation protects against it.
93. Demonstrate a migration that adds a non-nullable column to a table that already has data — what problem occurs and how do you solve it?
94. Write a query showing the difference between `IN` clause behavior and `EXISTS`/`JOIN` performance implications.
95. Demonstrate handling `NULL` values correctly in both C# (`?.`, `??`) and the generated SQL (`IS NULL` vs `= NULL`).

## 12. Reflection, Attributes & Misc (5)
96. Use reflection to list all public properties of an object and print their values generically.
97. Create and read a custom attribute at runtime using reflection.
98. Implement a simple generic method with constraints (`where T : class, new()`) and explain why each constraint is needed.
99. Demonstrate `is`/`as` pattern matching vs. explicit casting, including what happens with an invalid cast in each case.
100. Given a `Person { get; set; }` and `List<Person>`, implement deep equality comparison, and separately demonstrate why using it as a `Dictionary` key without overriding `GetHashCode` breaks lookups.

## 13. Collections Deep Dive — Dictionary, HashSet & More (20)
101. Implement a `Dictionary<TKey,TValue>` lookup and show what happens (exception vs. no exception) with `[]`, `TryGetValue`, and `ContainsKey` when the key is missing.
102. Iterate over a `Dictionary` and modify it in the same loop — show the `InvalidOperationException` this throws, and the correct way to do it (materialize keys first, or build a new collection).
103. Use a `HashSet<T>` to remove duplicates from a list of custom objects.
    ⚠ Edge case: works fine for `int`/`string`, but silently "fails" (keeps duplicates) for custom reference types unless you override `Equals`/`GetHashCode` or supply an `IEqualityComparer<T>`.
104. Implement a custom `IEqualityComparer<T>` and use it with both `HashSet<T>` and `Dictionary<TKey,TValue>` (e.g., case-insensitive string keys).
105. Explain why `Dictionary<TKey,TValue>` enumeration order is not guaranteed, and demonstrate a real case where insertion order appears preserved but you shouldn't rely on it.
106. Use a `SortedDictionary<TKey,TValue>` vs `SortedList<TKey,TValue>` — explain the underlying data structure difference and when each is faster (frequent inserts vs. frequent lookups by index).
107. Implement a LRU cache using `Dictionary` + `LinkedList<T>`.
108. Demonstrate why `Dictionary<TKey,TValue>` is not thread-safe by showing a corrupted state under concurrent writes, then fix it with `ConcurrentDictionary<TKey,TValue>`.
    ⚠ Edge case: `ConcurrentDictionary.GetOrAdd` calling the factory delegate more than once under contention — know this "gotcha."
109. Use `List<T>.BinarySearch` and explain why it gives wrong/undefined results if the list isn't sorted first.
110. Demonstrate the performance difference between `List<T>.Contains` (O(n)) and `HashSet<T>.Contains` (O(1) average) on a large collection.
111. Show what happens when you use a mutable object (or a `struct`) as a `Dictionary` key and then mutate it after insertion — why do lookups start failing?
112. Implement your own generic `IEnumerable<T>` / `IEnumerator<T>` using `yield return`, and explain what `yield` actually compiles to under the hood (state machine).
113. Demonstrate the difference between `List<T>`, `IList<T>`, `ICollection<T>`, and `IEnumerable<T>` — write a method signature choice exercise: which interface should a parameter/return type use and why.
114. Explain `List<T>` capacity vs. count, and show how repeated `Add()` calls without pre-sizing cause hidden reallocation/copy costs — fix it using the constructor's capacity parameter.
115. Convert a `List<T>` to a `ReadOnlyCollection<T>` (or expose `IReadOnlyList<T>`) and demonstrate that the underlying list can still be mutated through the original reference — "read-only" isn't "immutable."
116. Use `System.Collections.Immutable` (`ImmutableList<T>`, `ImmutableDictionary<TKey,TValue>`) and explain the performance trade-off vs. mutable collections.
117. Implement a priority queue manually (pre-.NET 6) and then rewrite it using the built-in `PriorityQueue<TElement,TPriority>`.
118. Demonstrate `Queue<T>`/`Stack<T>` "peek on empty" behavior — what exception, and how do you check safely (`TryPeek`/`TryDequeue`/`TryPop`)?
119. Use `Array.Sort` with a custom `IComparer<T>` or `Comparison<T>` delegate to sort a list of objects by multiple fields (e.g., last name, then first name).
    ⚠ Edge case: unstable sort — two objects that compare equal on the sort key may end up in a different relative order than they started; show when this matters.
120. Compare `ValueTuple` (`(int, string)`) vs. `KeyValuePair<TKey,TValue>` vs. a custom class for returning multiple values from a method — trade-offs in readability, mutability, and use as dictionary entries.

---

## Suggested practice order
Given your background (LINQ, SQL Server, EF, and Reflection already fairly solid), I'd bias your practice time toward sections **1, 6, 8, and 9** — numeric/overflow edge cases, exception handling nuances, async/await gotchas, and memory/performance — since those are the categories mid-level interviews most often use to separate "writes working code" from "understands what the runtime is actually doing."
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         
         */
    }
}
