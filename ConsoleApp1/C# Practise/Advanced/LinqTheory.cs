using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.CSharpPractise.Advanced;

/*  
 * =============================================================================
 * LINQ (Language Integrated Query) — study notes
 * =============================================================================
 * QuickRecap:
 * - LINQ provides a clean way to query collections, databases, XML, etc.
 * - Works with IEnumerable<T> and IQueryable<T>
 * - Deferred Execution: Query executes only when iterated
 * - Common Operations:
 *   Filtering -> Where()
 *   Projection -> Select()
 *   Sorting -> OrderBy()
 *   Grouping -> GroupBy()
 *   Aggregation -> Sum(), Count()
 *  Note:  Method syntax vs query syntax
 * Also:
 * - System.Linq — extension methods; lambdas in predicates (e.g. Where(n => n % 2 == 0))
 * - Method syntax vs query syntax (from / where / select) — same pipeline
 * - Immediate: ToList, Count(), Sum(), First() run when called
 * - IQueryable<T> + EF Core: expression trees translated to SQL
 *
 * Deferred vs immediate:
 * - Deferred: IEnumerable<T> from Where — runs on foreach
 * - Immediate: .ToList(), .ToArray(), .Count(), .First() — run when called
 *
 * Performance:
 * - Do not enumerate the same deferred query twice without .ToList()
 * - Prefer .Any() over .Count() > 0 for existence checks
 * =============================================================================
 */

public static class LinqTheory
{
    public static void RunDemo() => RunAllDemos();

    public static void RunAllDemos()
    {
        Console.WriteLine("=== LINQ Theory ===\n");
        Filtering_Demo();
        Projection_Demo();
        Sorting_Demo();
        Grouping_Demo();
        Aggregation_Demo();
        Quantifier_Demo();
        Element_Demo();
        Partitioning_Demo();
        SetOperations_Demo();
        Join_Demo();
    }

    /*
     * =============================================================================
     * 1) FILTERING
     * =============================================================================
     * - Used to filter data based on conditions
     * - Main Method: Where()
     * - Shapes shown in Filtering_Demo:
     *     IEnumerable<T>  deferred (runs on foreach)
     *     .ToList() / .ToArray()  assign to new list or array (immediate)
     *     new List<T>(query)      copy deferred result into a list
     *     query syntax            from ... where ... select
     *     chained Where           multiple predicates
     *     Where with index        Where((item, index) => ...)
     * =============================================================================
     */
    public static void Filtering_Demo()
    {
        Console.WriteLine("\n=== 1) FILTERING ===");
        List<int> numbers = new() { 1, 2, 3, 4, 5, 6 };

        // --- 1) Method syntax → IEnumerable<T> (deferred; not a separate list yet) ---
        IEnumerable<int> evenNumbers =
            numbers.Where(n => n % 2 == 0);

        Console.WriteLine("1) IEnumerable<int> (deferred Where):");
        foreach (int n in evenNumbers)
            Console.WriteLine($"   {n}");

        // --- 2) Assign to List<T> — .ToList() materializes immediately ---
        List<int> evenList = numbers
            .Where(n => n % 2 == 0)
            .ToList();

        Console.WriteLine("2) List<int> via .ToList():");
        foreach (int n in evenList)
            Console.WriteLine($"   {n}");

        // --- 3) Assign to int[] — .ToArray() ---
        int[] evenArray = numbers
            .Where(n => n % 2 == 0)
            .ToArray();

        Console.WriteLine("3) int[] via .ToArray():");
        foreach (int n in evenArray)
            Console.WriteLine($"   {n}");

        // --- 4) Assign using List<T> constructor (enumerates the query once) ---
        List<int> evenViaCtor = new List<int>(
            numbers.Where(n => n % 2 == 0));

        Console.WriteLine("4) new List<int>(Where(...)):");
        Console.WriteLine($"   Count={evenViaCtor.Count}  [{string.Join(", ", evenViaCtor)}]");

        // --- 5) Query syntax (same as Where; compiles to similar IL) ---
        List<int> evenQuerySyntax =
            (from n in numbers
             where n % 2 == 0
             select n).ToList();

        Console.WriteLine("5) Query syntax (from / where / select) → ToList():");
        Console.WriteLine($"   [{string.Join(", ", evenQuerySyntax)}]");

        // --- 6) Chained Where (filter even AND greater than 2) ---
        List<int> evenAndGt2 = numbers
            .Where(n => n % 2 == 0)
            .Where(n => n > 2)
            .ToList();

        Console.WriteLine("6) Chained .Where().Where() → even and > 2:");
        Console.WriteLine($"   [{string.Join(", ", evenAndGt2)}]");

        // --- 7) Where with index (keep even numbers at index 0, 2, 4, …) ---
        List<int> evenIndexFilter = numbers
            .Where((n, index) => index % 2 == 0)
            .ToList();

        Console.WriteLine("7) Where((n, index) => index % 2 == 0) — elements at even indices:");
        Console.WriteLine($"   [{string.Join(", ", evenIndexFilter)}]");

        // --- 8) var + immediate check (Any vs Count anti-pattern note) ---
        var evensDeferred = numbers.Where(n => n % 2 == 0);
        bool hasAnyEven = evensDeferred.Any(); // prefer Any() over Count() > 0

        Console.WriteLine($"8) Any() on filtered query (has any even?): {hasAnyEven}");
    }

    /*
     * =============================================================================
     * 2) PROJECTION — Select, SelectMany, anonymous types, query select
     * =============================================================================
     */
    public static void Projection_Demo()
    {
        Console.WriteLine("\n=== 2) PROJECTION ===");
        List<string> names = new() { "Bunty", "Singh", "Rahul" };

        // 1) IEnumerable<T> deferred
        IEnumerable<int> lengthsDeferred = names.Select(n => n.Length);
        Console.WriteLine("1) IEnumerable<int> (deferred Select):");
        Console.WriteLine($"   [{string.Join(", ", lengthsDeferred)}]");

        // 2) List<T> via ToList()
        List<int> lengthsList = names.Select(n => n.Length).ToList();
        Console.WriteLine($"2) List<int> via .ToList(): [{string.Join(", ", lengthsList)}]");

        // 3) int[] via ToArray()
        int[] lengthsArray = names.Select(n => n.Length).ToArray();
        Console.WriteLine($"3) int[] via .ToArray(): [{string.Join(", ", lengthsArray)}]");

        // 4) Anonymous type projection
        var upperAndLength = names
            .Select(n => new { Name = n.ToUpper(), Len = n.Length })
            .ToList();
        Console.WriteLine("4) Select → anonymous type:");
        foreach (var x in upperAndLength)
            Console.WriteLine($"   {x.Name} ({x.Len})");

        // 5) Query syntax (select projection)
        List<string> upperNames =
            (from n in names
             select n.ToUpper()).ToList();
        Console.WriteLine($"5) Query syntax select: [{string.Join(", ", upperNames)}]");

        // 6) SelectMany — flatten nested lists
        List<List<int>> batches = new() { new() { 1, 2 }, new() { 3, 4, 5 } };
        List<int> flat = batches.SelectMany(batch => batch).ToList();
        Console.WriteLine($"6) SelectMany (flatten): [{string.Join(", ", flat)}]");

        // 7) Select with index
        var indexed = names.Select((n, i) => $"{i}:{n}").ToList();
        Console.WriteLine($"7) Select((n, index) => ...): [{string.Join(", ", indexed)}]");
    }

    /*
     * =============================================================================
     * 3) SORTING — OrderBy, OrderByDescending, ThenBy, query orderby
     * =============================================================================
     */
    public static void Sorting_Demo()
    {
        Console.WriteLine("\n=== 3) SORTING ===");
        List<int> numbers = new() { 50, 10, 30, 20 };

        // 1) IEnumerable deferred
        IEnumerable<int> sortedDeferred = numbers.OrderBy(n => n);
        Console.WriteLine("1) IEnumerable (deferred OrderBy):");
        Console.WriteLine($"   [{string.Join(", ", sortedDeferred)}]");

        // 2) List via ToList()
        List<int> asc = numbers.OrderBy(n => n).ToList();
        Console.WriteLine($"2) OrderBy → ToList(): [{string.Join(", ", asc)}]");

        // 3) OrderByDescending
        List<int> desc = numbers.OrderByDescending(n => n).ToList();
        Console.WriteLine($"3) OrderByDescending: [{string.Join(", ", desc)}]");

        // 4) ThenBy (secondary key) — sort strings by length, then name
        List<string> words = new() { "pear", "fig", "apple", "kiwi" };
        List<string> byLenThenName = words
            .OrderBy(w => w.Length)
            .ThenBy(w => w)
            .ToList();
        Console.WriteLine($"4) OrderBy(len).ThenBy(name): [{string.Join(", ", byLenThenName)}]");

        // 5) Query syntax orderby
        List<int> querySorted =
            (from n in numbers
             orderby n descending
             select n).ToList();
        Console.WriteLine($"5) Query syntax orderby descending: [{string.Join(", ", querySorted)}]");

        // 6) new List from sorted query
        List<int> viaCtor = new List<int>(numbers.OrderBy(n => n));
        Console.WriteLine($"6) new List<int>(OrderBy(...)): [{string.Join(", ", viaCtor)}]");
    }

    /*
     * =============================================================================
     * 4) GROUPING — GroupBy, query group by, ToDictionary
     * =============================================================================
     */
    public static void Grouping_Demo()
    {
        Console.WriteLine("\n=== 4) GROUPING ===");
        List<string> names = new() { "Bunty", "Bob", "Alice", "Ankit" };

        // 1) IEnumerable<IGrouping<...>> deferred
        IEnumerable<IGrouping<char, string>> groupsDeferred =
            names.GroupBy(n => n[0]);
        Console.WriteLine("1) IEnumerable<IGrouping> (deferred GroupBy):");
        foreach (var g in groupsDeferred)
            Console.WriteLine($"   Key '{g.Key}': [{string.Join(", ", g)}]");

        // 2) Materialize groups to List
        List<IGrouping<char, string>> groupsList = names.GroupBy(n => n[0]).ToList();
        Console.WriteLine($"2) .ToList() on GroupBy: {groupsList.Count} group(s)");

        // 3) Query syntax group by
        var queryGroups =
            (from n in names
             group n by n[0] into g
             select new { Letter = g.Key, Names = g.ToList() }).ToList();
        Console.WriteLine("3) Query syntax (group by / into):");
        foreach (var g in queryGroups)
            Console.WriteLine($"   {g.Letter} → [{string.Join(", ", g.Names)}]");

        // 4) GroupBy with element selector (project each member)
        var firstLetters = names
            .GroupBy(n => n[0], n => n[0])
            .ToList();
        Console.WriteLine($"4) GroupBy(key, element): {firstLetters.Count} group(s)");

        // 5) Count per group without nested loop
        Dictionary<char, int> countByLetter = names
            .GroupBy(n => n[0])
            .ToDictionary(g => g.Key, g => g.Count());
        Console.WriteLine($"5) ToDictionary(Key, Count): {string.Join(", ", countByLetter)}");
    }

    /*
     * =============================================================================
     * 5) AGGREGATION — Sum, Count, Average, Min, Max, Aggregate
     * =============================================================================
     */
    public static void Aggregation_Demo()
    {
        Console.WriteLine("\n=== 5) AGGREGATION ===");
        List<int> numbers = new() { 10, 20, 30 };

        // 1) Basic aggregates (immediate)
        Console.WriteLine("1) Sum / Count / Average / Min / Max:");
        Console.WriteLine($"   Sum={numbers.Sum()}  Count={numbers.Count()}  Avg={numbers.Average()}");
        Console.WriteLine($"   Min={numbers.Min()}  Max={numbers.Max()}");

        // 2) Sum with selector
        List<string> names = new() { "Ada", "Bob" };
        int totalChars = names.Sum(n => n.Length);
        Console.WriteLine($"2) Sum(selector) total name lengths: {totalChars}");

        // 3) Count with predicate
        int gt15 = numbers.Count(n => n > 15);
        Console.WriteLine($"3) Count(predicate) n > 15: {gt15}");

        // 4) Aggregate — custom fold (product)
        int product = numbers.Aggregate(1, (acc, n) => acc * n);
        Console.WriteLine($"4) Aggregate product: {product}");

        // 5) Aggregate — seed + func + result selector
        string joined = names.Aggregate(
            "Names:",
            (acc, n) => acc + " " + n,
            acc => acc.Trim());
        Console.WriteLine($"5) Aggregate string build: {joined}");

        // 6) LongCount (same as Count for in-memory; useful on IQueryable)
        long countLong = numbers.LongCount();
        Console.WriteLine($"6) LongCount(): {countLong}");
    }

    /*
     * =============================================================================
     * 6) QUANTIFIERS — Any, All, Contains
     * =============================================================================
     */
    public static void Quantifier_Demo()
    {
        Console.WriteLine("\n=== 6) QUANTIFIERS ===");
        List<int> numbers = new() { 2, 4, 6, 8 };
        List<int> mixed = new() { 1, 2, 3, 4 };

        // 1) Any / All / Contains on sequence
        Console.WriteLine("1) Any / All / Contains:");
        Console.WriteLine($"   Any(): {numbers.Any()}  All even: {numbers.All(n => n % 2 == 0)}  Contains(6): {numbers.Contains(6)}");

        // 2) Any with predicate
        bool anyGt5 = mixed.Any(n => n > 5);
        Console.WriteLine($"2) Any(n => n > 5) on [1,2,3,4]: {anyGt5}");

        // 3) All with predicate
        bool allPositive = mixed.All(n => n > 0);
        Console.WriteLine($"3) All(n => n > 0): {allPositive}");

        // 4) !Any() — preferred over Count() == 0
        List<int> empty = new();
        bool isEmpty = !empty.Any();
        Console.WriteLine($"4) !empty.Any() (is empty?): {isEmpty}");

        // 5) Assign results to variables (readable pipeline)
        bool hasEven = mixed.Any(n => n % 2 == 0);
        bool allEven = mixed.All(n => n % 2 == 0);
        Console.WriteLine($"5) mixed — hasEven={hasEven}, allEven={allEven}");

        // 6) Contains on deferred query (materializes when checked)
        var evens = mixed.Where(n => n % 2 == 0);
        bool containsTwo = evens.Contains(2);
        Console.WriteLine($"6) Where(...).Contains(2): {containsTwo}");
    }

    /*
     * =============================================================================
     * 7) ELEMENT — First, Last, Single, ElementAt, OrDefault variants
     * =============================================================================
     */
    public static void Element_Demo()
    {
        Console.WriteLine("\n=== 7) ELEMENT ===");
        List<int> numbers = new() { 10, 20, 30 };

        // 1) First / Last (throws if empty)
        Console.WriteLine($"1) First={numbers.First()}  Last={numbers.Last()}");

        // 2) First(predicate) / Last(predicate)
        int firstGt15 = numbers.First(n => n > 15);
        int lastEven = numbers.Last(n => n % 2 == 0);
        Console.WriteLine($"2) First(n>15)={firstGt15}  Last(even)={lastEven}");

        // 3) FirstOrDefault — safe when missing
        List<int> empty = new();
        int missing = empty.FirstOrDefault();
        int missingPred = numbers.FirstOrDefault(n => n > 100);
        Console.WriteLine($"3) FirstOrDefault: empty→{missing}, none>100→{missingPred}");

        // 4) Single — exactly one element (throws otherwise)
        int only = new List<int> { 99 }.Single();
        Console.WriteLine($"4) Single() on [99]: {only}");

        // 5) SingleOrDefault
        int singleOrDef = new List<int> { 5 }.SingleOrDefault();
        Console.WriteLine($"5) SingleOrDefault on [5]: {singleOrDef}");

        // 6) ElementAt / ElementAtOrDefault (0-based index)
        int at1 = numbers.ElementAt(1);
        int at99 = numbers.ElementAtOrDefault(99);
        Console.WriteLine($"6) ElementAt(1)={at1}  ElementAtOrDefault(99)={at99}");

        // 7) DefaultIfEmpty — empty sequence → one default element
        IEnumerable<int> noHits = numbers.Where(n => n > 1000);
        List<int> withDefault = noHits.DefaultIfEmpty(-1).ToList();
        Console.WriteLine($"7) Where(no match).DefaultIfEmpty(-1): [{string.Join(", ", withDefault)}]");
    }

    /*
     * =============================================================================
     * 8) PARTITIONING — Take, Skip, TakeWhile, SkipWhile, paging
     * =============================================================================
     */
    public static void Partitioning_Demo()
    {
        Console.WriteLine("\n=== 8) PARTITIONING ===");
        List<int> numbers = new() { 1, 2, 3, 4, 5, 6 };

        // 1) Take / Skip deferred
        IEnumerable<int> takeDef = numbers.Take(3);
        IEnumerable<int> skipDef = numbers.Skip(3);
        Console.WriteLine($"1) Take(3) deferred: [{string.Join(", ", takeDef)}]");
        Console.WriteLine($"   Skip(3) deferred: [{string.Join(", ", skipDef)}]");

        // 2) ToList assignments
        List<int> firstThree = numbers.Take(3).ToList();
        List<int> afterThree = numbers.Skip(3).ToList();
        Console.WriteLine($"2) Take→List: [{string.Join(", ", firstThree)}]  Skip→List: [{string.Join(", ", afterThree)}]");

        // 3) TakeWhile / SkipWhile (stop when condition fails)
        List<int> takeWhileLt4 = numbers.TakeWhile(n => n < 4).ToList();
        List<int> skipWhileLt4 = numbers.SkipWhile(n => n < 4).ToList();
        Console.WriteLine($"3) TakeWhile(<4): [{string.Join(", ", takeWhileLt4)}]");
        Console.WriteLine($"   SkipWhile(<4): [{string.Join(", ", skipWhileLt4)}]");

        // 4) Paging: page size 2, page index 1 (second page)
        int pageSize = 2, pageIndex = 1;
        List<int> page = numbers.Skip(pageSize * pageIndex).Take(pageSize).ToList();
        Console.WriteLine($"4) Page size={pageSize} index={pageIndex}: [{string.Join(", ", page)}]");

        // 5) new List from Take
        List<int> viaCtor = new List<int>(numbers.Take(2));
        Console.WriteLine($"5) new List<int>(Take(2)): [{string.Join(", ", viaCtor)}]");
    }

    /*
     * =============================================================================
     * 9) SET OPERATIONS — Distinct, Union, Intersect, Except, Concat
     * =============================================================================
     */
    public static void SetOperations_Demo()
    {
        Console.WriteLine("\n=== 9) SET OPERATIONS ===");
        List<int> list1 = new() { 1, 2, 3, 3 };
        List<int> list2 = new() { 3, 4, 5 };

        // 1) Distinct — IEnumerable vs List
        IEnumerable<int> distinctDef = list1.Distinct();
        List<int> distinctList = list1.Distinct().ToList();
        Console.WriteLine($"1) Distinct: deferred [{string.Join(", ", distinctDef)}]");
        Console.WriteLine($"   Distinct→List: [{string.Join(", ", distinctList)}]");

        // 2) Union (unique from both)
        List<int> union = list1.Union(list2).ToList();
        Console.WriteLine($"2) Union: [{string.Join(", ", union)}]");

        // 3) Intersect (common)
        List<int> intersect = list1.Intersect(list2).ToList();
        Console.WriteLine($"3) Intersect: [{string.Join(", ", intersect)}]");

        // 4) Except (in first, not in second)
        List<int> except = list1.Except(list2).ToList();
        Console.WriteLine($"4) Except: [{string.Join(", ", except)}]");

        // 5) Concat (keeps duplicates; Union removes dupes)
        List<int> concat = list1.Concat(list2).ToList();
        Console.WriteLine($"5) Concat (with dupes): [{string.Join(", ", concat)}]");

        // 6) DistinctBy (.NET 6+) — first occurrence per key
        List<string> words = new() { "apple", "apricot", "banana", "berry" };
        List<string> distinctByFirstChar = words.DistinctBy(w => w[0]).ToList();
        Console.WriteLine($"6) DistinctBy(first char): [{string.Join(", ", distinctByFirstChar)}]");
    }

    /*
     * =============================================================================
     * 10) JOIN — Join, GroupJoin, query join, left join pattern
     * =============================================================================
     */
    public static void Join_Demo()
    {
        Console.WriteLine("\n=== 10) JOIN ===");
        var students = new[]
        {
            new { Id = 1, Name = "Bunty", DepartmentId = 1 },
            new { Id = 2, Name = "Rahul", DepartmentId = 2 },
            new { Id = 3, Name = "Zoe", DepartmentId = 99 }
        };
        var departments = new[]
        {
            new { Id = 1, Department = "IT" },
            new { Id = 2, Department = "HR" }
        };

        // 1) Join — inner join (method syntax) → List
        List<string> innerJoin = students
            .Join(
                departments,
                s => s.DepartmentId,
                d => d.Id,
                (s, d) => $"{s.Name} - {d.Department}")
            .ToList();
        Console.WriteLine("1) Join (inner) → ToList():");
        innerJoin.ForEach(Console.WriteLine);

        // 2) Query syntax join
        var queryJoin =
            (from s in students
             join d in departments on s.DepartmentId equals d.Id
             select new { s.Name, d.Department }).ToList();
        Console.WriteLine("2) Query syntax join:");
        foreach (var row in queryJoin)
            Console.WriteLine($"   {row.Name} - {row.Department}");

        // 3) GroupJoin — left side + collection of matches per student
        var groupJoin = students
            .GroupJoin(
                departments,
                s => s.DepartmentId,
                d => d.Id,
                (s, depts) => new { s.Name, Depts = depts.ToList() })
            .ToList();
        Console.WriteLine("3) GroupJoin (student + matching dept list):");
        foreach (var row in groupJoin)
            Console.WriteLine($"   {row.Name}: [{string.Join(", ", row.Depts.Select(d => d.Department))}]");

        // 4) Left join — DefaultIfEmpty (students with no department)
        var leftJoin =
            (from s in students
             join d in departments on s.DepartmentId equals d.Id into deptGroup
             from d in deptGroup.DefaultIfEmpty()
             select new { s.Name, Department = d?.Department ?? "(none)" }).ToList();
        Console.WriteLine("4) Left join (group join + DefaultIfEmpty):");
        foreach (var row in leftJoin)
            Console.WriteLine($"   {row.Name} → {row.Department}");
    }
}
