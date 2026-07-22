using ConsoleApp1.C__Practise.Misc;
using ConsoleApp1.C__Practise.OOPs_Concepts;
using ConsoleApp1.C__Practise.Programming;
using ConsoleApp1.CSharpPractise.Advanced;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.Quic;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace ConsoleApp1.C__Practise.Entry
{
    /*
     * AI PRACTISE-CLASS RULE:
     * This is the only class where I practise code that should run from RootProgram.
     * When I ask for practice methods for any future Theory class:
     * - Add the practice methods in this Practise class only.
     * - Use the same section/demo method names from the Theory class as-is.
     * - Call every added practice method from Main().
     * - Keep method bodies empty so I can write the syntax myself.
     * - Do not reveal implementation logic, sample syntax, or completed answers here.
     * - Question comments and section headings must NOT reveal API/method names
     *   (e.g. do not write Enqueue, Push, TryAdd, AddRange, UnionWith, FindLast in the question).
     *   Describe intent in plain English so the user must recall the syntax themselves
     *   (e.g. "add at the back of the FIFO line", "merge only when the key is missing").
     *   Section headings use behaviour names (Add at back), not member names (Enqueue).
     */


    public class Practise
    {

        public static void Main(string[] args)
        {
            TOPPrograms.ReverseInteger();

        }
        public static bool IsValidNumber(string str)
        {
            bool isvalid = true;
            if(!string.IsNullOrEmpty(str))
            {
                foreach (char c in str)
                {
                    if (!char.IsDigit(c))
                    {
                        isvalid = false;
                    }
                }
            }
            return isvalid;
        }
        public static string AddNumbers(string a, string b)
        {
            StringBuilder c=new StringBuilder();
            int i = a.Length - 1;
            int j=b.Length - 1;
            int carry = 0;
            while (i >= 0 || j >= 0 || carry>0)
            {
                int digit1 =i>= 0 ? a[i] - '0' : 0;
                int digit2 =j >= 0 ? b[j] - '0' : 0;
                
                int sum = digit1 + digit2 + carry;
                carry= sum/10;
                c.Append(sum%10);
                i--;
                j--;

            }

            char[] array = c.ToString().ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        // Practice aligned with LinqTheory.Filtering_Demo() — question comments only; write your syntax below each question.
        public static void PracticeFiltering_Demo()
        {
            // ----- 1) FILTERING (LinqTheory §1) -----

                  // 1) Create a list of integers named numbers with values 1 through 6.
                  List<int> numbers= new List<int>() {1,2,3,4,5,6 };

            // 2) Build a deferred sequence of only even values (do not copy to a new list yet); loop and print each value.
            IEnumerable<int> evennumbers = numbers.Where(n => n % 2 == 0);
            foreach(var n in evennumbers)
            {
                Console.Write(n+" ");
            }
            // 3) Materialize even values into a list of integers and print them joined.


            List<int> evenlist = numbers.Where(n => n % 2 == 0).ToList();
            foreach(var n in evenlist)
            {
                Console.Write(n + " ");
            }
            int[] arraylist= numbers.Where(n => n % 2 == 0).ToArray();
            foreach(var n in arraylist)
            {
                Console.Write(n + " ");
            }

            // 5) Copy the deferred even sequence into a new list using the list constructor that accepts a sequence.

            List<int> evenlist1 = new List<int>(evennumbers.Where(n => n % 2 == 0));
            foreach (var n in evenlist1)
            {
                Console.Write(n + " ");
            }


            // 6) Use query-syntax (from / where / select) to get evens and materialize to a list; print joined.
            List<int> evenQuerySyntax =
          (from n in numbers
           where n % 2 == 0
           select n).ToList();

            Console.WriteLine("5) Query syntax (from / where / select) → ToList():");
            Console.WriteLine($"   [{string.Join(", ", evenQuerySyntax)}]");

            // 7) Chain two filters: even values and then only those greater than 2; materialize and print joined.

            List<int> evenlist2 = numbers.Where(n => n % 2 == 0).Where(n=>n>2).ToList();
            foreach (var n in evenlist2)
            {
                Console.Write(n + " ");
            }


            // 8) Keep elements whose position index is even (0, 2, 4, …); materialize and print joined.

            List<int> evenindexlist = numbers.Where((n,element) => element % 2 == 0).ToList();
            foreach (var n in evenindexlist)
            {
                Console.Write(n + " ");
            }


            // 9) On the filtered even query, check whether any item exists (use an existence check, not a full count).
            var evenquery = numbers.Where(n => n % 2 == 0);
            Console.WriteLine(evenquery.Any());
        }
        


        // Practice aligned with LinqTheory.Projection_Demo() — question comments only; write your syntax below each question.
        public static void PracticeProjection_Demo()
        {
            // ----- 2) PROJECTION (LinqTheory §2) -----

                  // 1) Create a list of strings named names with "Bunty", "Singh", "Rahul".
                  List<string> names=new List<string>() { "Bunty", "Singh", "Rahul" };

            // 2) Build a deferred sequence of each name's character length; print joined.
            IEnumerable<int> namescharlength = names.Select(n => n.Length);
            Console.WriteLine(string.Join("", namescharlength));

            // 3) Materialize lengths to a list and print joined.
            List<int> listlengths = names.Select(n => n.Length).ToList();
            Console.WriteLine(string.Join("", listlengths));

            // 4) Materialize lengths to an array and print joined.

            int[] lengtharray = names.Select(n => n.Length).ToArray();
            Console.WriteLine(string.Join("", lengtharray));

            // 5) Project each name to an anonymous pair: uppercase name and length; loop and print each pair.
            var pair = names.Select(n => new { Name= n.ToUpper(),Length=n.Length }).ToList();
            foreach (var n in pair)
            {
                Console.WriteLine(n.Name + "" + n.Length);
            }

            // 6) Use query-syntax to uppercase every name and materialize to a list; print joined.

            List<string> upperNames =
            (from n in names
             select n.ToUpper()).ToList();
            Console.WriteLine($"5) Query syntax select: [{string.Join(", ", upperNames)}]");

            // 7) Flatten nested lists {{1,2}, {3,4,5}} into one list of integers; print joined.

            List<List<int>> batches = new List<List<int>> { new List<int> { 1, 2, 3 }, new List<int> { 4, 5, 6 } };
            List<int>  flat=batches.SelectMany(n=>n).ToList();
            Console.WriteLine(string.Join("",flat));



            // 8) Project each name with its zero-based index as "index:name"; materialize and print joined.
            var indexbased = names.Select((n, i) => $"{n}:{i}").ToList();
            Console.WriteLine(string.Join("", indexbased));

        }


        // Practice aligned with LinqTheory.Sorting_Demo() — question comments only; write your syntax below each question.
        public static void PracticeSorting_Demo()
        {
            // ----- 3) SORTING (LinqTheory §3) -----

            // 1) Create a list of integers named numbers with 50, 10, 30, 20.

            List<int> numbers = new List<int>() { 50, 10, 30, 20 };
                  // 2) Build a deferred ascending sort; print joined (original list stays unchanged).
                  IEnumerable<int> sortedDeferred=numbers.OrderBy(n=>n);

                 Console.WriteLine($"{string.Join(",", sortedDeferred)}");
                  // 3) Materialize ascending sort to a list and print joined.
                  List<int> sortedlist= numbers.OrderBy(n => n).ToList();
            Console.WriteLine($"{string.Join(",", sortedlist)}");
            // 4) Materialize descending sort to a list and print joined.
            List<int> reversesortedlist = numbers.OrderByDescending(n => n).ToList();
            Console.WriteLine($"{string.Join(",", reversesortedlist)}");

            // 5) Sort words by length then by name for {"pear", "fig", "apple", "kiwi"}; print joined.
            List<string> words=new List<string> { "pear", "fig", "apple", "kiwi" };
            IEnumerable<string> sortedwords=words.OrderBy(n=>n.Length).ThenBy(n=>n);
            Console.WriteLine($"{string.Join(",", sortedwords)}");

            // 6) Use query-syntax orderby descending on numbers; materialize and print joined.
            List<int> querySorted =
         (from n in numbers
          orderby n descending
          select n).ToList();
            Console.WriteLine($"5) Query syntax orderby descending: [{string.Join(", ", querySorted)}]");

            // 7) Copy ascending-sorted numbers into a new list via constructor; print joined.
            List<int> newlist = new List<int>(numbers.OrderBy(n=>n));

        }


        // Practice aligned with LinqTheory.Grouping_Demo() — question comments only; write your syntax below each question.
        public static void PracticeGrouping_Demo()
        {
            // ----- 4) GROUPING (LinqTheory §4) -----

                  // 1) Create a list of strings named names with "Bunty", "Bob", "Alice", "Ankit".

                  List<string>  names=new List<string>() { "Bunty", "Bob", "Alice", "Ankit" , "Rohith"};

            // 2) Group by first character (deferred); foreach group print key and members joined.

            IEnumerable<IGrouping<char, string>> groupdata = names.GroupBy(n => n[0]);

            foreach (var g in groupdata)
            {
                Console.WriteLine(g.Key + ""+ string.Join(" ", g));
            }


            // 3) Materialize groups to a list and print how many groups exist.
            List<IGrouping<char, string>> listGroups = names.GroupBy(n => n[0]).ToList();

            Console.WriteLine(listGroups.Count);


            // 4) Use query-syntax group by first letter into a named group; project letter + member list; print each group.

            var queryGroups =
    (from n in names
     group n by n[0] into g
     select new { Letter = g.Key, Names = g.ToList() }).ToList();
            Console.WriteLine("3) Query syntax (group by / into):");
            foreach (var g in queryGroups)
                Console.WriteLine($"   {g.Letter} → [{string.Join(", ", g.Names)}]");

            // 5) Group by first letter but project each member as its first character only; print group count.
            var singlechargroups = names
            .GroupBy(n => n[0], n => n[0])
            .ToList();
            Console.WriteLine(singlechargroups.Count);

            // 6) Build a map from first letter to member count (one entry per group); print key=value pairs joined.
            Dictionary<char, int> map = names.GroupBy(n => n[0]).ToDictionary(g => g.Key, g => g.Count());

            Console.WriteLine(string.Join(",", map));
        }


        // Practice aligned with LinqTheory.Aggregation_Demo() — question comments only; write your syntax below each question.
        public static void PracticeAggregation_Demo()
        {
            // ----- 5) AGGREGATION (LinqTheory §5) -----

                  // 1) On list {10, 20, 30}, print total, count, average, minimum, and maximum.

            List<int> list=new List<int>() { 10, 20, 30 };
            Console.WriteLine(list.Sum());
            Console.WriteLine(list.Count());
            Console.WriteLine(list.Average());
            Console.WriteLine(list.Min());
            Console.WriteLine(list.Max());
            // Console.WriteLine();

            // 2) On names {"Ada", "Bob"}, print the sum of all name lengths.

            List<string> names = new List<string>() { "Ada", "Bob" };
            Console.WriteLine(names.Sum(n=>n.Length));


            // 3) On numbers {10, 20, 30}, print how many values are greater than 15.
            Console.WriteLine(list.Count(n=>n>15));


            // 4) Fold numbers {10, 20, 30} with seed 1 to compute the product of all values.
            int product = list.Aggregate(1, (acc, n) => acc * n);
            Console.WriteLine($"4) Aggregate product: {product}");

            // 5) Fold names {"Ada", "Bob"} into one string starting with "Names:" and space-separated names; trim result.
            string joined = names.Aggregate(
           "Names:",
           (acc, n) => acc + " " + n,
           acc => acc.Trim());
            Console.WriteLine($"5) Aggregate string build: {joined}");

            // 6) Print the long-form count of numbers {10, 20, 30}.
            long countLong = list.LongCount();
            Console.WriteLine($"6) LongCount(): {countLong}");
        }


        // Practice aligned with LinqTheory.Quantifier_Demo() — question comments only; write your syntax below each question.
        public static void PracticeQuantifier_Demo()
        {
            // ----- 6) QUANTIFIERS (LinqTheory §6) -----

                  // 1) On evens {2, 4, 6, 8}, print whether any exist, whether all are even, and whether 6 is present.

                  // 2) On mixed {1, 2, 3, 4}, print whether any value is greater than 5.

                  // 3) On mixed {1, 2, 3, 4}, print whether every value is positive.

                  // 4) On an empty integer list, print whether it has no items (prefer existence check over count).

                  // 5) On mixed {1, 2, 3, 4}, print whether any are even and whether all are even.

                  // 6) On deferred evens from mixed, print whether the sequence contains 2.
        }


        // Practice aligned with LinqTheory.Element_Demo() — question comments only; write your syntax below each question.
        public static void PracticeElement_Demo()
        {
            // ----- 7) ELEMENT (LinqTheory §7) -----

                  // 1) On {10, 20, 30}, print the first and last element.

                  // 2) Print the first value greater than 15 and the last even value.

                  // 3) On empty list print default first; on numbers print default when nothing exceeds 100.

                  // 4) On single-element list {99}, print the one-and-only element (throws if not exactly one).

                  // 5) On single-element list {5}, print single-or-default.

                  // 6) Print element at index 1; print default for index 99.

                  // 7) When no value exceeds 1000, materialize a default sentinel (-1) as the only element.
        }


        // Practice aligned with LinqTheory.Partitioning_Demo() — question comments only; write your syntax below each question.
        public static void PracticePartitioning_Demo()
        {
            // ----- 8) PARTITIONING (LinqTheory §8) -----

                  // 1) On {1..6}, take first 3 deferred and skip first 3 deferred; print each joined.

                  // 2) Materialize first three and remainder-after-three to lists; print each joined.

                  // 3) Take while value < 4; skip while value < 4; print each joined.

                  // 4) Page size 2, page index 1 (second page): skip then take; print joined.

                  // 5) Copy first two elements into a new list via constructor; print joined.
        }


        // Practice aligned with LinqTheory.SetOperations_Demo() — question comments only; write your syntax below each question.
        public static void PracticeSetOperations_Demo()
        {
            // ----- 9) SET OPERATIONS (LinqTheory §9) -----

                  // 1) On {1, 2, 3, 3}, print distinct deferred and distinct list joined.

                  // 2) Union of {1, 2, 3, 3} with {3, 4, 5}; print joined.

                  // 3) Intersection of those two lists; print joined.

                  // 4) Elements in first list not in second; print joined.

                  // 5) Concatenate both lists (duplicates allowed); print joined.

                  // 6) On words, keep first occurrence per initial letter; print joined.
        }


        // Practice aligned with LinqTheory.Join_Demo() — question comments only; write your syntax below each question.
        public static void PracticeJoin_Demo()
        {
            // ----- 10) JOIN (LinqTheory §10) -----

                  // 1) Inner join students (Id, Name, DepartmentId) with departments (Id, Department);
                  //    students: (1,Bunty,1), (2,Rahul,2), (3,Zoe,99); depts: (1,IT), (2,HR);
                  //    materialize "Name - Department" strings and print each line.

                  // 2) Same join using query-syntax; project name and department; print each pair.

                  // 3) Group join: each student with list of matching departments; print name and dept names joined.

                  // 4) Left join: include students with no department as "(none)"; print name and department.
        }






        // Practice aligned with GenericCollections.ShowDictionary() — question comments only; write your syntax below each question.
        public static void PracticeDictionary()
        {
            // ----- 1) Initialization -----

                  // 1) Create a map from integer keys to string values named idToName with entries 2→"Hari" and 5→"Krishna".

                  // 2) Add key 3 with value "Sri Rama".

                  // 3) Assign key 1 the value "FirstUser" using key-based assignment.

                  // 4) Try adding key 2 again with value "DuplicateKey"; when it fails, catch the error and print the exception message.

                  // 5) Replace the value for key 2 with "HariUpdated" using key-based assignment.

            // ----- 2) Merge another map -----

                  // 6) Create another map with 4→"Anu" and 6→"Ravi", loop its pairs, and merge into idToName only when the key is not already present.

                  // 7) Attempt to add key 4 with value "ShouldNotReplace" without changing the existing value for key 4.

            // ----- 3) Size / internal storage -----

                  // 8) Print the number of entries, reserve internal space for at least 64, then trim unused internal space.

            // ----- 4) Accessing by key -----

                  // 9) Print the value for key 3 using direct key access.

                  // 10) Safely read key 6; print the value if found, otherwise print a missing placeholder.

                  // 11) Read key 999 or print default text "<none>" when the key is absent.

                  // 12) Loop all key-value pairs and print each key and value.

            // ----- 5) Searching -----

                  // 13) Print whether key 5 exists and whether any value equals "HariUpdated".

                  // 14) Find and print the first key whose value starts with 'S', or a null/missing marker if none.

            // ----- 6) Remove -----

                  // 15) Remove key 1.

                  // 16) Remove key 5 and print the removed value when removal succeeds.

                  // 17) Add keys 99 and 100 with value "Temp", then remove both entries.

            // ----- 7) Ordering -----

                  // 18) Print all keys in enumeration order as a comma-separated list.

            // ----- 8) Conversion and utility -----

                  // 19) Copy all keys into an int array and all values into a string array sized to the current entry count.

                  // 20) Check whether every value is non-null and print the result.

            // ----- 8.a) Do NOT modify while iterating -----

                  // 21) Inside a foreach over the map, assign a new key while iterating; catch the invalid-operation error and print its message.

            // ----- 9) Other helpers -----

                  // 22) Build a list of uppercase values and print them joined.

                  // 23) Collect the first three keys in enumeration order into a list and print them.

                  // 24) Copy all pairs into a key-value array, print the array length, then empty the map and print the entry count.
        }


        // Practice aligned with GenericCollections.ShowList() — question comments only; write your syntax below each question.
        public static void PracticeList()
        {
            /*
             * REMEMBER POINTS (from your mistakes):
             * 1. Use ?. (null-conditional) when a node/reference may be null — e.g. names.First?.Value, names.Last?.Value (empty LinkedList → First/Last is null).
             * 2. BinarySearch only works on ascending sorted order — Sort first, search, then Reverse if needed; never search after Reverse().
             * 3. AddRange = append at end; InsertRange(0, …) = insert at front — read whether the question says append or insert at index.
             * 4. Mutate the correct collection — e.g. names.InsertRange(…), not list.InsertRange(…) when the question targets names.
             * 5. StartsWith: use the letter in the question ('S' vs 'H'); add StringComparison.OrdinalIgnoreCase when case may vary.
             * 6. RemoveAll removes every match; Remove removes only the first occurrence.
             * 7. Count = elements inside; Capacity = internal storage — print both when asked; call TrimExcess() after EnsureCapacity().
             * 8. Finish every step the question lists — print joined output, foreach-print values, Clear then print count.
             *
             * CORRECTIONS (mistakes found in this run):
             *
             * Q4  — Used InsertRange(0, list) instead of AddRange(list). Q4 asks to *append*; InsertRange(0, ...) inserts at the front.
             * Q5  — InsertRange was called on `list`, not `names`. Should be: names.InsertRange(2, new[] { "X", "Y" }).
             * Q6  — Printed Count only; question also asks for internal storage size (Capacity).
             * Q7  — Missing TrimExcess() after EnsureCapacity(50). Print capacity again after reserve and after trim.
             * Q12 — Predicate uses StartsWith("s") (lowercase). Use StartsWith("S") or StringComparison.OrdinalIgnoreCase — names use uppercase S.
             * Q13 — Same lowercase "s" mistake as Q12.
             * Q14 — Question asks for starts with 'H'; code uses StartsWith("s"). Should be StartsWith("H").
             * Q17 — Used Remove("Temp") twice instead of RemoveAll(s => s == "Temp") to remove *every* matching entry in one call.
             * Q19 — BinarySearch requires ascending sorted order. After Sort() + Reverse() the list is descending, so BinarySearch("Hari") is unreliable. Sort, search, then Reverse — or search before reversing.
             * Q24 — Built newlist with ConvertAll but never printed the joined uppercase values.
             * Q26 — Copied to array and printed length, but never called Clear() or printed the element count after clearing.
             *
             * Style (minor): spaces around = and after commas; Q23 try/catch is correct (InvalidOperationException outside foreach).
             * Correct: Q1–Q3, Q8–Q11, Q15–Q16, Q18, Q20–Q22, Q23, Q25.
             */

            // ----- 1) Initialization -----

                  // 1) Create a list of strings named names with initial elements "Krishna" and "Hari".

            List<string> names = new List<string>() { "Krishna", "Hari"};


            Console.WriteLine(" 1------------------- " + string.Join(",", names)); 

            // ----- 2) Add / Insert -----

                  // 2) Append a single element "Sri Rama" to the end of the list.

            names.Add("Sri Rama"); // Correct — Add always appends at the end.



                  // 3) Insert "FirstUser" at index 0.

            names.Insert(0, "FirstUser"); // Correct — Insert(0, ...) shifts existing items to higher indices.

            Console.WriteLine(" 2------------------- " + string.Join(",", names)); // OK

            // ----- 3) Append collection / insert collection at index -----

                  // 4) Create another list containing "Anu" and "Ravi", then append all of its elements to names.

            List<string> list=new List<string>() { "Anu","Ravi" }; // Style: spaces around = and after commas → list = new List<string>() { "Anu", "Ravi" };
            names.AddRange(list);             // Logic: Q4 asks to *append* — use names.AddRange(list); InsertRange(0, ...) inserts at the front and shifts everything.

                  // 5) Insert the elements "X" and "Y" at index 2 from a string array or collection.

            names.InsertRange(2, new[] { "X", "Y" }); // Logic: insert into names at index 2, not list → names.InsertRange(2, new[] { "X", "Y" }); Style: new[] { "X", "Y" } avoids repeating string[]

            Console.WriteLine(" 3------------------- " + string.Join(",", names));

            // ----- 4) Size / internal storage -----

                  // 6) Print the number of elements and the current internal storage size.
            Console.WriteLine(names.Count);

                  // 7) Reserve internal space for at least 50 elements, print the storage size after reserving, then shrink unused internal space.
            names.EnsureCapacity(50);

            //names.TrimExcess();

            Console.WriteLine(names.Capacity);

            // ----- 5) Accessing elements -----

                  // 8) Print the element at index 0.

            Console.WriteLine(names[0]);

                  // 9) Loop by index from 0 through the last position and print each index and its value.

             for (int i = 0; i < names.Count; i++)
                Console.WriteLine($"[{i}] = {names[i]}");

            // ----- 6) Searching / Finding -----

                  // 10) Print whether "Hari" is present in the list.

            Console.WriteLine(names.Contains("Hari"));

                  // 11) Print the first index of "Sri Rama" and the last index of "Sri Rama".

            Console.WriteLine(names.IndexOf("Sri Rama"));
            Console.WriteLine(names.LastIndexOf("Sri Rama"));

                  // 12) Print the first element whose value starts with 'S', and the last such element.

            Console.WriteLine(names.Find(s => s.StartsWith("s", StringComparison.OrdinalIgnoreCase)));
            Console.WriteLine(names.FindLast(s => s.StartsWith("s")));

                  // 13) Print the first index and last index of any element starting with 'S'.

            Console.WriteLine(names.FindIndex(s => s.StartsWith("s")));
            Console.WriteLine(names.FindLastIndex(s => s.StartsWith("s")));

                  // 14) Print whether any element starts with 'H'.

            Console.WriteLine(names.Exists(s => s.StartsWith("H")));

            // ----- 7) Remove -----

                  // 15) Remove the first occurrence of "FirstUser".

            names.Remove("FirstUser");

                  // 16) If the list has more than two elements, remove the element at index 2.

            if (names.Count > 2)
            {
                names.RemoveAt(2);
            }

                  // 17) Add two entries with value "Temp", then remove every entry equal to "Temp" in one operation.

            names.Add("Temp");
            names.Add("Temp");
            
            names.RemoveAll(s=>s.StartsWith("Temp"));

            // ----- 8) Ordering / reversing / binary lookup -----

                  // 18) Sort the list in ascending order, then reverse the order.

            names.Sort();

            names.Reverse();

                  // 19) On the ascending-sorted list, locate "Hari" using a binary lookup and print the returned index.

            Console.WriteLine("Binary Search For Hari" + names.BinarySearch("Hari"));

            // ----- 9) Conversion and utility -----

                  // 20) Copy all elements into a string array.

            string[] stringarray=new string[names.Count];   //names.ToArray();
            names.CopyTo(stringarray);

                  // 21) Run an action on each element that prints the element.

            names.ForEach(s=>Console.WriteLine(s));

                  // 22) Print whether every element is non-null.

            Console.WriteLine("True For All" + names.TrueForAll(s => s != null));

            // ----- 9.a) Do NOT modify while iterating -----

                  // 23) Inside a foreach over the list, try adding a new element while iterating; catch the invalid-operation error and print its message.

            try
            {
                foreach (var i in names)
                {
                    names.Add("Try Catch");
                }
                

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            // ----- 10) Other helpers -----

                  // 24) Build a new list of uppercase versions of every element and print them joined.

            List<string> newlist = names.ConvertAll(n => n.ToUpper());

                  // 25) Take a sub-range of the first three elements (or fewer if the list is shorter) and print them joined.

            List<string> slice = names.GetRange(0, Math.Min(3,names.Count));

            Console.WriteLine(string.Join(",", slice));

                  // 26) Copy all elements into a string array sized to the current element count, print the array length, then clear the list and print the element count.
            string[] namesarray= new string[names.Count];
            names.CopyTo(namesarray, 0);

            Console.WriteLine(namesarray.Length);
            names.Clear();
            Console.WriteLine(names.Count);

        }


        // Practice aligned with GenericCollections.ShowLinkedList() — question comments only; write your syntax below each question.
        public static void PracticeLinkedList()
        {
            /*
             * REMEMBER POINTS (from your mistakes):
             * 1. Use ?. (null-conditional) when a node/reference may be null — e.g. names.First?.Value, names.Last?.Value (empty LinkedList → First/Last is null).
             * 2. BinarySearch only works on ascending sorted order — Sort first, search, then Reverse if needed; never search after Reverse().
             * 3. LinkedList has no indexer — use First/Last and walk with .Next (forward) or .Previous (backward); first N nodes = .Next from head, not .Previous.
             * 4. Start each node walk fresh from names.First or names.Last; use 0-based index when printing [0], [1], …
             * 5. No bulk append on LinkedList — loop a sequence and AddLast each item.
             * 6. Remove(node) is O(1) when you already hold the node; Remove(value) scans the list O(n).
             * 7. Do not modify during foreach — catch InvalidOperationException outside the loop.
             *
             *
             * CORRECTIONS (mistakes found in this run):
             *
             * Q4  — Works, but question asks to append each item from a *sequence*; use foreach over new[] { "Anu", "Ravi" } and AddLast in the loop.
             * Q8  — Reused `node` from Q5 instead of starting a fresh walk from names.First. Index starts at 1; C# lists use 0-based index ([0], [1], …). Missing space in output ("Index 0 Value …").
             * Q11 — Logic is fine (backward walk ≈ FindLast for 'S'). After a match, walknode is not null — your "no S found" message only runs when the loop exhausts; OK. Optional: use FindLast("Sri Rama")-style or print "<null>" when nothing matches inside the loop.
             * Q15 — Same as PracticeList Q19: BinarySearch needs ascending order. After Sort() + Reverse() the list is descending, so BinarySearch("Hari") is unreliable. Search before Reverse, or Sort and search without reversing.
             * Q16 — Cleared, re-added, and copied to array, but never foreach-printed each value (question requires it).
             * Q17 — Logic correct; minor: add break after nonnull = false, and print clearer label e.g. "All non-null? true/false".
             * Q20 — Used collectnode.Previous — walks *backward* from head. First three nodes = walk forward with .Next: names.First, then .Next, then .Next (or loop with si < Math.Min(3, names.Count)).
             *
             * Style (minor): spaces around = and after commas; Q5 AddAfter(node, "X") spacing.
             * Correct: Q1–Q3, Q5–Q6, Q9–Q10, Q12–Q14, Q18–Q19, Q21.
             */

            // ----- 1) Initialization -----

                  // 1) Create a doubly-linked chain of strings named names from an array containing "Krishna" and "Hari".
                  LinkedList<string> names=new LinkedList<string>(new[] { "Krishna", "Hari" });

            // ----- 2) Add at head and tail -----

            // 2) Append "Sri Rama" to the tail of the chain.
            names.AddLast("Sri Rama");

            // 3) Insert "FirstUser" at the head of the chain.
            names.AddFirst("FirstUser");

            // ----- 3) Bulk append / relative insert -----

            // 4) Append each item from a sequence "Anu", "Ravi" to the tail (this type has no bulk-append API).

            names.AddLast("Anu");
            names.AddLast("Ravi");


            // 5) After the first node, insert "X", then after that new node insert "Y" using relative node references.

            var node = names.First;
            if (node != null)
            {
                names.AddAfter(node,"X");
                names.AddAfter(node.Next!, "Y");
            }

            // ----- 4) Size -----

            // 6) Print the number of nodes (this type has no internal array capacity).

            Console.WriteLine(names.Count);

            // ----- 5) Accessing elements -----

            // 7) Print the first and last node values.
            Console.WriteLine(names.First.Value +" "+ names.Last.Value);
            // 8) Walk forward from the first node and print each index and value.
            int i = 1;
            while (node!=null)
            {
                Console.WriteLine("Index " + i + "Value" + node.Value);
                node = node.Next;
                i++;
            }

            // ----- 6) Searching -----

            // 9) Print whether "Hari" is present.
            Console.WriteLine(names.Contains("Hari"));

            // 10) Locate and print the value for "Sri Rama", or a missing marker if not found.
            var nodesrirama = names.Find("Sri Rama");

            Console.WriteLine(nodesrirama!=null? nodesrirama.Value:"<Missing>");

            // 11) Walk backward from the last node and print the first value starting with 'S'.

            var walknode = names.Last;
            while (walknode != null)
            {
                if (walknode.Value.StartsWith("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(walknode.Value);
                    break;
                }
                walknode = walknode.Previous;
               

            }
            if (walknode == null)
            {
                Console.WriteLine("No item is starting with \"S\" ");
            }



            // ----- 7) Remove -----

            // 12) Remove the first node whose value equals "FirstUser".

                    names.Remove("FirstUser");

            // 13) Locate the node holding "X" and remove that specific node in O(1) time.

            var xnode = names.Find("X");
            if (xnode != null)
            {
                names.Remove(xnode);
            }

            // 14) Add two "Temp" entries at the tail, then remove every node equal to "Temp".

            names.AddLast("Temp");
            names.AddLast("Temp");
            while (names.Find("Temp") is { } t)
            {
                names.Remove(t);
            }

            // ----- 8) Sorting (via list copy) -----

            // 15) Copy values into a list, sort ascending, reverse, then locate "Hari" on the sorted copy with a binary lookup and print the index.

            List<string> list = new List<string>(names);
            list.Sort();
            list.Reverse();
            Console.WriteLine(list.BinarySearch("Hari"));

            // ----- 9) Conversion and utility -----

            // 16) Clear the chain, re-add "Krishna", "Hari", "Sri Rama", copy values to a string array, and foreach-print each value.

            names.Clear();
            names.AddLast("Krishna");
            names.AddLast("Hari");
            names.AddLast("Sri Rama");

            string[] array=new string[names.Count];
            names.CopyTo(array,0);


            // 17) Check whether every value is non-null and print the result.
            bool nonnull = true;
            foreach (var p in names)
            {
                if (p == null)
                { nonnull=false; break; }
            }
            Console.WriteLine(" Values null is " + nonnull);
            // ----- 9.a) Do NOT modify while iterating -----

            // 18) Inside a foreach, append a new node while iterating; catch the invalid-operation error and print its message.
            try
            {
                foreach (var loopnode in names)
                {
                    names.AddLast("Exception");
                }
            }
            catch(InvalidOperationException e){
                Console.WriteLine(e.Message);
            }

            // ----- 10) Other helpers -----

            // 19) Build a list of uppercase values and print them joined.
            List<string> list1=new List<string>();
            foreach (var n in names)
            {
                list1.Add(n.ToUpper());
            }
            Console.WriteLine(string.Join(",", list1));
            // 20) Collect the first three node values into a list and print them joined.

            var collectnode = names.First;
            int collect = 3;
            List<string> first3list=new List<string>();
            while (collect > 0 && collectnode!=null)
            {
                first3list.Add(collectnode.Value);
                collect--;
                collectnode = collectnode.Next;
            }
            Console.WriteLine(string.Join(",",first3list));

            // 21) Copy all values to a string array, print the array length, then clear the chain and print the node count.
            string[] llarray = new string[names.Count];
            names.CopyTo(llarray,0);
            Console.WriteLine(llarray.Length);
            names.Clear();
            Console.WriteLine(names.Count);
        }


        // Practice aligned with GenericCollections.ShowSortedList() — question comments only; write your syntax below each question.
        public static void PracticeSortedList()
        {
            // ----- 1) Initialization -----

                  // 1) Create a sorted key-to-name map named idToName with keys 2→"Hari" and 5→"Krishna".

            // ----- 2) Add / indexer -----

                  // 2) Add key 3 with value "Sri Rama".

                  // 3) Assign key 1 the value "FirstUser" using key-based assignment.

                  // 4) Try adding key 2 again with value "DuplicateKey"; when it fails, catch the error and print the exception message.

                  // 5) Replace the value for key 2 with "HariUpdated" using key-based assignment.

            // ----- 3) Merge another map -----

                  // 6) Loop pairs from another map {4→"Anu", 6→"Ravi"} and merge into idToName only when the key is not already present.

            // ----- 4) Size / internal storage -----

                  // 7) Print the number of entries, the internal array capacity, bump capacity to at least 16, then trim excess storage.

            // ----- 5) Accessing by key and sorted index -----

                  // 8) Print the value for key 3.

                  // 9) Print the key and value at sorted index 0.

                  // 10) Loop by sorted index from 0 through the last position and print each index, key, and value.

            // ----- 6) Searching -----

                  // 11) Print whether key 5 exists and whether any value equals "HariUpdated".

                  // 12) Print the sorted index of key 4 and the sorted index of value "Anu".

                  // 13) Safely read key 6; print the value if found, otherwise print a missing placeholder.

                  // 14) Find and print the first sorted index whose value starts with 'S', or -1 if none.

            // ----- 7) Remove -----

                  // 15) Remove key 1.

                  // 16) If more than two entries remain, remove the entry at sorted index 2.

                  // 17) Add keys 99 and 100 with value "Temp", then remove both entries.

            // ----- 8) Ordering -----

                  // 18) Print all keys in sorted order as a comma-separated list (no separate sort API exists).

            // ----- 9) Conversion and utility -----

                  // 19) Copy all keys and all values into separate arrays sized to the current entry count.

                  // 20) Loop all pairs and print each key and value.

                  // 21) Check whether every value is non-null and print the result.

            // ----- 9.a) Do NOT modify while iterating -----

                  // 22) Inside a foreach, assign a new key while iterating; catch the invalid-operation error and print its message.

            // ----- 10) Other helpers -----

                  // 23) Build a list of uppercase values and print them joined.

                  // 24) Collect the first three keys in sorted order into a list and print them.

                  // 25) Copy all pairs into a key-value array, print the array length, then clear the map and print the entry count.
        }


        // Practice aligned with GenericCollections.ShowQueue() — question comments only; write your syntax below each question.
        public static void PracticeQueue()
        {
            /*
             * REMEMBER POINTS (from your mistakes):
             * 1. Queue has no indexer — front access only: look without removing, remove from front; add at back only.
             * 2. Looking at the front on an empty line throws — use the safe try-pattern when the line may be empty.
             * 3. foreach walks arrival order and does not remove — do not add at the back inside foreach (InvalidOperationException).
             * 4. No bulk-add API — loop each sequence and add one item at a time.
             * 5. To filter items (e.g. drop "Temp"): snapshot Count, dequeue that many times, re-add non-matches at the back.
             * 6. When asked for storage size after reserve and after shrink — print Capacity after EnsureCapacity and again after TrimExcess.
             * 7. Finish every step — print [index] = value, print joined uppercase, inspect front before emptying the line.
             *
             * CORRECTIONS (mistakes found in this run):
             *
             * Q4  — Printed Count and Capacity before reserve/shrink only; question also wants storage size after reserving and after shrinking.
             *       → names.EnsureCapacity(64);
             *       → Console.WriteLine(names.Capacity);   // after reserve
             *       → names.TrimExcess();
             *       → Console.WriteLine(names.Capacity);   // after shrink
             * Q5  — Peek() throws on an empty line; TryPeek ternary is good but empty case is never actually tested (queue still has items here).
             *       → Console.WriteLine(names.TryPeek(out var peeked) ? peeked : "<empty>");   // safe when line has items
             *       → var emptyLine = new Queue<string>();
             *       → Console.WriteLine(emptyLine.TryPeek(out var none) ? none : "<empty>");    // proves empty case
             * Q6  — Index and value are printed but format is unclear (index+""+e); prefer $"[{index}] = {e}" for readable output.
             *       → Console.WriteLine($"[{index}] = {e}");
             * Q8  — Logic OK; optional: print a placeholder when no value starts with 'S'.
             *       → string? firstS = null;
             *       → foreach (var e in names) { if (e.StartsWith("S")) { firstS = e; break; } }
             *       → Console.WriteLine(firstS ?? "<none>");
             * Q14 — Logic correct; minor: clearer label e.g. "All non-null? " + nonnull (code sits under 9.a heading — keep Q14 block together).
             *       → Console.WriteLine("All non-null? " + nonnull);
             * Q18 — Copy, length, clear, and count are done; missing inspect the front element when Count > 0 before emptying the line.
             *       → if (names.Count > 0)
             *       →     Console.WriteLine(names.TryPeek(out var front) ? front : "<empty>");
             *       → names.Clear();
             *       → Console.WriteLine(names.Count);
             *
             * Style (minor): spaces around = and after commas; section comment on same line as Q1 init.
             * Correct: Q1–Q3, Q7, Q9–Q13, Q15–Q17.
             */

            // ----- 1) Initialization -----

            // 1) Create a first-in-first-out line of strings named names starting with "Krishna" and "Hari".

            Queue<string> names = new Queue<string>(new[] { "Krishna", "Hari" });  //can use  Queue<string> names =["Krishna", "Hari"]
                                                                                   // ----- 2) Add at back (FIFO) -----


            // 2) Add "Sri Rama" and "FirstUser" at the back of the line.

            names.Enqueue("Sri Rama");
            names.Enqueue("FirstUser");

            // ----- 3) Bulk add at back -----



            // 3) Add each item from sequences "Anu", "Ravi" and "X", "Y" one at a time (this type has no bulk-add API).


            foreach (var i in new []{ "Anu", "Ravi" })
            {
                names.Enqueue(i);
            }

            foreach (var i in new[] {"X", "Y"})
            {
                names.Enqueue(i);
            }


            // ----- 4) Size / internal storage -----

            // 4) Print the number of elements and internal buffer size, reserve space for at least 64, then shrink unused storage.

            Console.WriteLine(names.Count);
            Console.WriteLine(names.Capacity);
            names.EnsureCapacity(64);
            Console.WriteLine(names.Capacity);
            names.TrimExcess();
            Console.WriteLine(names.Capacity);

            // ----- 5) Accessing (front only — no indexer) -----

            // 5) Look at the front element without removing it; also handle the case when the line is empty.

            Console.WriteLine(names.TryPeek(out var peeked) ? peeked : "<empty>");
            var emptyLine = new Queue<string>();
            Console.WriteLine(emptyLine.TryPeek(out var none) ? none : "<empty>");

            // 6) Walk the line with foreach (arrival order, does not remove) and print each index and value.
            int index = 0;
            foreach (var e in names)
            {
                Console.WriteLine($"[{index}] = {e}");
                index++;
            }

            // ----- 6) Searching -----

            // 7) Print whether "Hari" is present.
            Console.WriteLine(names.Contains("Hari"));

            // 8) Scan in arrival order and print the first value starting with 'S'.

            string? firstS = null;
            foreach (var e in names)
            {
                if (e.StartsWith("S", StringComparison.OrdinalIgnoreCase))
                {
                    firstS = e;
                    break;
                }
            }
            Console.WriteLine(firstS ?? "<none>");

            // ----- 7) Remove from front -----

            // 9) Remove and return one front element, then safely remove another when the line may be empty.

            Console.WriteLine(names.Dequeue());
            Console.WriteLine(names.TryDequeue(out var element)?element:"Empty Queue");

            // 10) Add two "Temp" entries at the back, then rotate the line to drop every "Temp" while preserving order of other items.

            names.Enqueue("Temp");
            names.Enqueue("Temp");
            int count=names.Count;
            for (int i = 0; i < count; i++)
            { 
                string s=names.Dequeue();
                if (s!="Temp")
                { names.Enqueue(s); 
                }
            }
            

            // ----- 8) Ordering -----

            // 11) Print a comma-separated snapshot of all remaining elements in arrival order.

            Console.WriteLine(string.Join(",",names));

            // ----- 9) Conversion and utility -----

            // 12) Copy all elements to an array and print the array length.
            string[] stringarray = names.ToArray();
            Console.WriteLine(stringarray.Length);


            // 13) Copy to a string buffer and loop-print each element.
            string[] strings = new string[names.Count];
            names.CopyTo(strings, 0);
            foreach (var i in strings)
            {
                Console.WriteLine(i);
            }

            // 14) Check whether every element is non-null and print the result.

            bool nonnull = true;
            foreach (var i in names)
            {
                if (i == null)
                {
                    nonnull = false;
                    break;
                }
            }
            Console.WriteLine("All non-null? " + nonnull);

            // ----- 9.a) Do NOT modify while iterating -----

            // 15) Inside a foreach, add a new item at the back while iterating; catch the invalid-operation error and print its message.

            try
            {

                foreach (var i in names)
                {
                    names.Enqueue("dummy");

                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            // ----- 10) Other helpers -----

            // 16) Snapshot the line to an array, build uppercase copies, and print them joined.

            string[] array = names.ToArray();
            var list=new List<string>();
            foreach (var i in array)
            {
                list.Add(i.ToUpper());
            }
            Console.WriteLine(string.Join(",", list));

            // 17) Take the first three items from the snapshot and print them joined.

            var slice = new List<string>();
            for (int i = 0; i < Math.Min(3, array.Length); i++)
            {
                slice.Add(array[i]);
            }
            Console.WriteLine(string.Join(",",slice));

            // 18) Copy to a string array, print the length, inspect the front if any remain, then empty the line and print the element count.)
            string[] finalline = new string[names.Count];
            names.CopyTo(finalline, 0);
            Console.WriteLine(finalline.Length);
            if (names.Count > 0)
                Console.WriteLine(names.TryPeek(out var front) ? front : "<empty>");
            names.Clear();
            Console.WriteLine(names.Count);
        }


        // Practice aligned with GenericCollections.ShowStack() — question comments only; write your syntax below each question.
        public static void PracticeStack()
        {
            // ----- 1) Initialization -----

                  // 1) Create a last-in-first-out pile of strings named names from "Krishna" and "Hari" (first item is bottom, last is top).

            //Stack<string> names= new Stack<string>() { "Krishna", "Hari"};

            // ----- 2) Add at top (LIFO) -----

                  // 2) Place "Sri Rama" and "FirstUser" on top of the pile.

            // ----- 3) Bulk add at top -----

                  // 3) Place each item from sequences "Anu", "Ravi" and "X", "Y" on top one at a time (last placed ends on top).

            // ----- 4) Size / internal storage -----

                  // 4) Print the number of elements and internal buffer size, reserve space for at least 64, then shrink unused storage.

            // ----- 5) Accessing (top only — no indexer) -----

                  // 5) Look at the top element without removing it; also handle the case when the pile is empty.

                  // 6) Walk with foreach (top-down order) and print each index and value.

            // ----- 6) Searching -----

                  // 7) Print whether "Hari" is present.

                  // 8) Scan top-down and print the first value starting with 'S'.

            // ----- 7) Remove from top -----

                  // 9) Remove and return one top element, then safely remove another when the pile may be empty.

                  // 10) Place two "Temp" entries on top, then filter out every "Temp" using a scratch pile (two-pass LIFO).

            // ----- 8) Ordering -----

                  // 11) Print a comma-separated snapshot where index 0 is the top element.

            // ----- 9) Conversion and utility -----

                  // 12) Copy all elements to an array and print the array length.

                  // 13) Copy to a string buffer and loop-print each element.

                  // 14) Check whether every element is non-null and print the result.

            // ----- 9.a) Do NOT modify while iterating -----

                  // 15) Inside a foreach, place a new item on top while iterating; catch the invalid-operation error and print its message.

            // ----- 10) Other helpers -----

                  // 16) Snapshot to an array, build uppercase copies (top-first order), and print them joined.

                  // 17) Take the top three items from the snapshot and print them joined.

                  // 18) Copy to a string array, print the length, inspect the top if any remain, then empty the pile and print the element count.
        }


        // Practice aligned with GenericCollections.ShowPriorityQueue() — question comments only; write your syntax below each question.
        public static void PracticePriorityQueue()
        {
            // ----- 1) Initialization -----

                  // 1) Create a min-priority task scheduler (string task, int priority) named tasks; add "Krishna" at priority 2 and "Hari" at priority 5.

            // ----- 2) Add with priority -----

                  // 2) Add "Sri Rama" at priority 3 and "FirstUser" at priority 1.

            // ----- 3) Bulk add with priority -----

                  // 3) Add ("Anu", 4) and ("Ravi", 6) in one bulk operation, then add ("X", 7) and ("Y", 8) individually.

            // ----- 4) Size / internal storage -----

                  // 4) Print the number of entries, reserve internal space for at least 64, then shrink unused storage.

            // ----- 5) Inspect best item (lowest priority number) -----

                  // 5) Safely inspect the highest-precedence task and its priority number, then inspect again without removing.

                  // 6) Loop the internal heap view (not true removal order) and print each task and priority.

            // ----- 6) Searching -----

                  // 7) Scan the internal heap view and print whether "Hari" is present.

                  // 8) Scan the internal heap view and print the first task starting with 'S'.

            // ----- 7) Remove by priority / filter -----

                  // 9) Safely remove and return one highest-precedence entry, then remove another.

                  // 10) Add two ("Temp", 99) entries, snapshot all pairs, empty the scheduler, and rebuild without "Temp".

                  // 11) Add "Zeta" at priority 50 and immediately return the best task after the add (add-then-take-best pattern).

            // ----- 8) Custom ordering -----

                  // 12) Create a max-priority scheduler (higher int wins), add "low" at 1 and "high" at 100, and inspect the winner.

            // ----- 9) Drain order -----

                  // 13) Remove all entries in true priority order and print them joined with " -> ".

                  // 14) Refill with three entries, check whether every task name is non-null, and print the result.

            // ----- 9.a) Do NOT modify while iterating -----

                  // 15) Inside a loop over the internal heap view, add a new task while iterating; catch the invalid-operation error and print its message.

            // ----- 10) Other helpers -----

                  // 16) Snapshot all pairs without destroying the scheduler, build uppercase task names, and print them joined.

                  // 17) Take the first three pairs from the snapshot and print them.

                  // 18) Empty the scheduler and print the entry count.
        }


        // Practice aligned with GenericCollections.ShowSortedDictionary() — question comments only; write your syntax below each question.
        public static void PracticeSortedDictionary()
        {
            // ----- 1) Initialization -----

                  // 1) Create a sorted key-to-name map named idToName with keys 2→"Hari" and 5→"Krishna".

            // ----- 2) Add / indexer -----

                  // 2) Add key 3 with value "Sri Rama".

                  // 3) Assign key 1 the value "FirstUser" using key-based assignment.

                  // 4) Try adding key 2 again with value "DuplicateKey"; when it fails, catch the error and print the exception message.

                  // 5) Replace the value for key 2 with "HariUpdated" using key-based assignment.

            // ----- 3) Merge another map -----

                  // 6) Loop pairs from another map {4→"Anu", 6→"Ravi"} and merge only when the key is not already present.

                  // 7) Attempt to add key 4 with value "ShouldNotReplace" without changing the existing value for key 4.

            // ----- 4) Size -----

                  // 8) Print the number of entries (this tree-based type has no capacity API).

            // ----- 5) Accessing by key -----

                  // 9) Print the value for key 3 using direct key access.

                  // 10) Safely read key 6; print the value if found, otherwise print a missing placeholder.

                  // 11) Read key 999 or print default text "<none>" when the key is absent.

                  // 12) Loop all pairs in sorted key order and print each key and value.

            // ----- 6) Searching -----

                  // 13) Print whether key 5 exists and whether any value equals "HariUpdated".

                  // 14) Walk in sorted key order and print the smallest key whose value starts with 'S', or a missing marker.

            // ----- 7) Remove -----

                  // 15) Remove key 1.

                  // 16) Remove key 5 and print the removed value when removal succeeds.

                  // 17) Add keys 99 and 100 with value "Temp", then remove both entries.

            // ----- 8) Ordering -----

                  // 18) Print all keys in ascending sorted order as a comma-separated list.

            // ----- 9) Conversion and utility -----

                  // 19) Copy all keys and all values into separate arrays sized to the current entry count.

                  // 20) Check whether every value is non-null and print the result.

            // ----- 9.a) Do NOT modify while iterating -----

                  // 21) Inside a foreach, assign a new key while iterating; catch the invalid-operation error and print its message.

            // ----- 10) Other helpers -----

                  // 22) Build a list of uppercase values in sorted key order and print them joined.

                  // 23) Collect the three smallest keys into a list and print them.

                  // 24) Copy all pairs into a key-value array, print the array length, then clear and print the entry count.

                  // 25) Create a separate map with descending key order, add keys 1 and 3, and print its keys.
        }


        // Practice aligned with GenericCollections.ShowHashSet() — question comments only; write your syntax below each question.
        public static void PracticeHashSet()
        {
            // ----- 1) Initialization -----

                  // 1) Create a unique string collection named names with "Krishna" and "Hari".
                  HashSet<string> names = new HashSet<string>(){ "Krishna", "Hari" };


            // ----- 2) Add -----

            // 2) Insert "Sri Rama" and print whether it was newly added; insert "Krishna" again and print whether it was accepted.
            Console.WriteLine(names.Add("Sri Rama"));
            Console.WriteLine(names.Add("Krishna"));

            // ----- 3) Bulk merge -----



            // 3) Merge in all items from another collection {"Anu", "Ravi"} and from sequence {"X", "Y"} using an in-place combine-all operation.
            HashSet<string> Col = new HashSet<string>() { "Anu", "Ravi" };
            names.UnionWith(Col);
            names.UnionWith(new[] { "X", "Y" });

            // ----- 4) Size / internal storage -----

            // 4) Print the number of distinct elements, reserve internal space for at least 64, then shrink unused storage.
            Console.WriteLine(names.Count);
            names.EnsureCapacity(64);
            names.TrimExcess();
            // Console.WriteLine();

            // ----- 5) Membership -----

            // 5) Print whether "Hari" is present.
            Console.WriteLine(names.Contains("Hari"));

            // 6) Scan enumeration and print the first value starting with 'S'.
            foreach (var i in names)
            { if (i.StartsWith('s'))
                {
                    Console.WriteLine(i);
                    break;
                }
            }

            // 7) Retrieve the stored instance that matches "Hari" under equality rules and print it.
           Console.WriteLine(names.TryGetValue("Hari",out var instance));


            // 8) Create an ignore-case collection with "Hari" and "Krishna", then retrieve the stored instance matching "HARI".
            HashSet<string> Ordinalcase = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Krishna", "Hari" };
            Console.WriteLine(Ordinalcase.TryGetValue("Hari", out var ordinalinstance));
            // ----- 6) Remove -----

            // 9) Remove "X", insert "Temp" and "Temp2", then remove every value starting with "Temp".

            names.Remove("X");
            names.Add("Temp");
            names.Add("Temp2");
            names.RemoveWhere(x => x.StartsWith("Temp"));

            // ----- 7) Set algebra -----

            // 10) Given A={1,2,3,4,5} and B={4,5,6,7,8}, copy A and combine with all of B; print the result.

                HashSet<int> A=new HashSet<int>() { 1, 2, 3, 4, 5 };
                HashSet<int> B = new HashSet<int>() { 4, 5, 6, 7, 8 };
            var union = new HashSet<int>(A);
            union.UnionWith(B);
            Console.WriteLine(string.Join(",",union));

            // 11) Copy A and keep only elements also in B; print the result.

            var intersect=new HashSet<int>(A);
            union.IntersectWith(B);
            Console.WriteLine(string.Join(",", intersect));

            // 12) Copy A and remove every element that appears in B; print the result.

            var except = new HashSet<int>(A);
            union.ExceptWith(B);
            Console.WriteLine(string.Join(",", except));
            // 13) Copy A and keep elements that appear in exactly one of A or B; print the result.
            var symmetricexcept = new HashSet<int>(A);
            union.SymmetricExceptWith(B);
            Console.WriteLine(string.Join(",", symmetricexcept));
            // ----- 8) Set comparisons -----





            // 14) Print whether {4,5} is contained in B, whether A shares any element with B, and whether {1,2,3} holds the same elements as {3,2,1}.
            Console.WriteLine("Is Subset of " + new HashSet<int>() { 4,5}.IsSubsetOf(B));
            Console.WriteLine("Overlaps"+ A.Overlaps(B));
            Console.WriteLine("setequals"+ new HashSet<int> { 1, 2, 3 }.SetEquals(new HashSet<int> { 3, 2, 1 }));

            // ----- 9) Conversion and utility -----

            // 15) Copy all elements to a string array and loop-print each element.
            var buf = new string[names.Count];
            names.CopyTo(buf, 0);

            // 16) Check whether every element is non-null and print the result.

            // ----- 9.a) Do NOT modify while iterating -----

            // 17) Inside a foreach, insert a new item while iterating; catch the invalid-operation error and print its message.

            // ----- 10) Other helpers -----

            // 18) Snapshot to a list, build uppercase copies, and print them joined.

            // 19) Print the first three items from the snapshot (order is unspecified).

            // 20) Empty the collection and print the element count.
        }


        // Practice aligned with GenericCollections.ShowSortedSet() — question comments only; write your syntax below each question.
        public static void PracticeSortedSet()
        {
            // ----- 1) Initialization -----

                  // 1) Create a sorted unique string collection named names with "Krishna" and "Hari".


            // ----- 2) Add -----

                  // 2) Insert "Sri Rama" and print whether it was newly added; insert "Krishna" again and print whether it was accepted.

            // ----- 3) Bulk merge -----

                  // 3) Merge in items from another sorted collection {"Anu", "Ravi"} and from sequence {"X", "Y"} using an in-place combine-all operation.

            // ----- 4) Size -----

                  // 4) Print the number of elements (this tree-based type has no capacity API).

            // ----- 5) Membership / extremes -----

                  // 5) Print whether "Hari" is present.

                  // 6) Scan in sorted order and print the first value starting with 'S'.

                  // 7) Print the smallest and largest element in the collection.

            // ----- 6) Remove / range view -----

                  // 8) Remove "X", insert "Temp" and "TempZ", then remove every value starting with "Temp".

                  // 9) Create a live sub-range view between "Anu" and "Sri Rama" (inclusive) and print its elements joined.

            // ----- 7) Set algebra -----

                  // 10) Given sorted A={1,2,3,4,5} and B={4,5,6,7,8}, copy A and combine with all of B; print sorted result.

                  // 11) Copy A and keep only elements also in B; print the result.

                  // 12) Copy A and remove every element that appears in B; print the result.

                  // 13) Copy A and keep elements that appear in exactly one of A or B; print the result.

            // ----- 8) Set comparisons -----

                  // 14) Print whether {4,5} is contained in B, whether A shares any element with B, and whether {1,2,3} holds the same elements as {3,2,1}.

                  // 15) Create a descending-order collection, insert 1, 3, 5, and print elements in loop order.

            // ----- 9) Conversion and utility -----

                  // 16) Copy all elements to a string array in sorted order and loop-print each element.

                  // 17) Check whether every element is non-null and print the result.

            // ----- 9.a) Do NOT modify while iterating -----

                  // 18) Inside a foreach, insert a new item while iterating; catch the invalid-operation error and print its message.

            // ----- 10) Other helpers -----

                  // 19) Collect the three lexicographically smallest elements into a list and print them joined.

                  // 20) Empty the collection and print the element count.
        }


        public static void ShowCollectionOperations()
        {
            //1.Initialization
            List<string> list = new List<string>() { "Krishna", "Hari"};
            //new List<string>(other collection/array, capacity);  new() { "Krishna", "Hari" }; othercollection.Where(condition).ToList();
            //new List<int>(nums).ConvertAll(n => n.ToString());

             // 2.adding
                list.Add("Hanuman");
            list.Insert(3, "Sita");   //at index
            List<string> newcol = new List<string> { "Sri Krishna", "Sri Hanuman"};

                //appending collection
                list.AddRange(newcol);
            list.InsertRange(2,newcol);

            Console.WriteLine(list.Count);//count gives count of elements
            Console.WriteLine(list.Capacity); //capacity gives size
            //list.EnsureCapacity(new size);
            //list.TrimExcess();


            Console.WriteLine(list.Contains("Hari"));
            Console.WriteLine(list.IndexOf("Hari"));
            Console.WriteLine(list.LastIndexOf("Hari"));
            Console.WriteLine(list.Exists(n=>n.StartsWith("H")));

            list.RemoveRange(0,0);
            //..Remove()   just removes element
            //RemoveAt()  just removes the element at index
            //RemoveAll(x=>x%2==0)



        }





    }
    
   


}

