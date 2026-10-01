namespace ConsoleApp1.C__Practise.PYnative;

/// <summary>
/// Collected reminders from the PYnative exercises.
///
/// Marker convention used in the exercise files:
///   //Imp Prog Rem  -> Important PROGRAMMING point to remember (syntax / inbuilt method / how-to).
///   //Imp Con Rem   -> Important CONCEPT to remember (how something works / why / when to use).
///
/// Section 1 lists each //Imp Prog Rem comment exactly, without the "Imp Prog Rem" prefix.
/// Section 2 lists the concept questions: override abstract properties, implement abstract constructor, IComparable, IDisposable.
/// </summary>
internal static class Remember
{
    /* =====================================================================================
     * SECTION 1: IMPORTANT PROGRAMMING POINTS TO REMEMBER
     * Wording is the comment text exactly, without the leading "Imp Prog Rem".
     * =====================================================================================
     *
     * ---- Strings (StringExercises.cs) ----
     *  1. array reverse inbuilt func,
     *        char[] arr = text.ToCharArray(); Array.Reverse(arr); return new string(arr);
     *  2. Inbuilt func to remove spaces at the end, start and both of a string
     *        .TrimEnd() end, .TrimStart() start, .Trim() both.
     *  3. is character is a lettr or digit
     *        char.IsLetter(c), char.IsDigit(c).
     *  4. asci values of characters
     *        'A'..'Z' = 65..90, 'a'..'z' = 97..122, '0'..'9' = 48..57. Upper and lower differ by 32.
     *  5. number to char conversion
     *        (char)(c + 32) or (char)(c - 32). (int)c gives the code.
     *  6. Array of words to string conversion
     *        string.Join(" ", words);
     *  7. hopw to get value in a dictionary
     *        if (dict.TryGetValue(key, out int value)) dict[key] = value + 1; else dict.Add(key, 1);
     *  8. Linq to get highest value in a dictionary
     *        dict.OrderByDescending(x => x.Value).First().Key;
     *
     * ---- LINQ (LinqExercises.cs) ----
     *  9. UNIQUE TOP VALUES
     *        numbers.Distinct().OrderByDescending(x => x).Take(3).ToList();
     * 10. StringComparision.OrdinalIgnoreCase()
     *        x.StartsWith("A", StringComparison.OrdinalIgnoreCase)
     * 11. spelling StringComparision.OrdinalIgnoreCase()
     *        Correct spelling is StringComparison.OrdinalIgnoreCase (Comparison, not Comparision).
     *        x.EndsWith("e", StringComparison.OrdinalIgnoreCase)
     * 12. string conversion of upper and lower in linqs
     *        words.Select(x => x.ToUpper()).ToList();
     *        words.Select(x => x.ToLower()).ToList();
     * 13. How to get decimal output , how to return a intialized object
     *        products.Select(x => new LinqProductTax { ProductName = x.Name, CalculatedTax = x.Price * 0.15m }).ToList();
     * 14. what is SelectMany , what goes inside its function and what it returns
     *        departments.SelectMany(x => x.EmployeeNames).ToList();
     *        The lambda returns a sequence per item. SelectMany flattens those sequences into one sequence.
     * 15. what is ZIP
     *        firstNames.Zip(lastNames, (first, last) => $"{first} {last}").ToList();
     * 16. Distinct() should be usedd sfter select or where
     *        emails.Select(x => x.Substring(x.IndexOf("@") + 1)).Distinct().ToList();
     * 17. how to traverse in 2d matrix in linq
     *        matrix.SelectMany(x => x).ToList();
     *
     * =====================================================================================
     * SECTION 2: IMPORTANT CONCEPTS TO REMEMBER
     * =====================================================================================
     *
     *  1. how to override abstract properties
     *        public abstract class Shape { public abstract double Area { get; } public abstract string Name { get; set; } }
     *        public class Circle : Shape
     *        {
     *            public double Radius { get; }
     *            public override double Area => Math.PI * Radius * Radius;     // get-only: expression body is enough
     *            public override string Name { get; set; } = "Circle";          // must implement the same accessors (get + set)
     *        }
     *        -> Use 'override' (not 'new'); accessors must match the abstract declaration; a derived class that doesn't
     *           override every abstract member must itself be abstract.
     * 12. implement abstract constructor
     *        Constructors can't be abstract/virtual/override. An abstract class CAN have a constructor (make it protected,
     *        since the class can't be instantiated with 'new'). Derived classes pass values up with : base(...).
     *        public abstract class Employee
     *        {
     *            public string Name { get; }
     *            protected Employee(string name) { Name = name; }                // runs first when a derived object is created
     *        }
     *        public class Manager : Employee { public Manager(string name) : base(name) { } }
     *        -> If the abstract class has no parameterless constructor, every derived constructor MUST call : base(...).
     *        -> Order: base constructor runs before the derived constructor body.
     * 13. IComparable
     *        public class Product : IComparable<Product>
     *        {
     *            public decimal Price { get; set; }
     *            public int CompareTo(Product? other)
     *            {
     *                if (other is null) return 1;                                // non-null sorts after null
     *                return Price.CompareTo(other.Price);                         // < 0 this first, 0 equal, > 0 other first
     *            }
     *        }
     *        -> Enables list.Sort(), Array.Sort(), OrderBy(x => x), SortedSet/SortedList without passing a comparer.
     *        -> Descending: other.Price.CompareTo(Price). Multi-field: compare first field, if 0 compare the next.
     *        -> IComparable<T> = the ONE default order inside the class; IComparer<T> = extra/external orders passed in.
     *        -> Without it, list.Sort() on custom objects throws InvalidOperationException ("Failed to compare two elements").
     * 14. Implementation of IDisposable (using, dispose)
     *        public class FileLogger : IDisposable
     *        {
     *            private StreamWriter? _writer = new StreamWriter("log.txt");
     *            private bool _disposed;
     *
     *            public void Dispose()
     *            {
     *                if (_disposed) return;          // Dispose must be safe to call more than once
     *                _writer?.Dispose();             // release the unmanaged / owned resource
     *                _writer = null;
     *                _disposed = true;
     *            }
     *        }
     *        using (var logger = new FileLogger())   // Dispose() runs when the block ends, even if an exception is thrown
     *        {
     *            // use logger
     *        }                                       // compiler calls logger.Dispose() here
     *        using var logger2 = new FileLogger();   // C# 8: Dispose() runs at the end of the enclosing method/block
     *        -> 'using' only works on types that implement IDisposable (or are ref structs with a Dispose method).
     *        -> Call Dispose yourself when you don't use 'using': logger.Dispose();
     */
}
