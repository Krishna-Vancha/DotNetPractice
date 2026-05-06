using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.CSharpPractise.DataStructures.Arrays
{
    /* DataStructures — array cheat sheet in code + comments below.
       Run Main() to see 1D, rectangular/jagged, then System.Array helpers. */
    internal class DataStructures
    {
        public static void Main(string[] args)
        {
            showOneDimensionalArrays();
            showMultidimensionalArrays();
            ArrayInbuiltFunctions();
        }

        // Arrays: syntax, Range/Span, System.Array — see `PointsToRemember.md` in the repository root (section **Programming → Arrays**).

        public static void showOneDimensionalArrays()
        {
            // How do I allocate a fixed length — all elements default (0 for int)?
            int[] array = new int[10];
            Console.WriteLine("Defaults (first 4): " + string.Join(",", array[..4]));

            // How do I declare with explicit elements — classic form?
            int[] array1 = new int[] { 1, 2, 3, 4 };

            // How do I use shorthand when the type is on the left — compiler fills in "new int[]"?
            int[] array3 = { 1, 2, 3, 4 };

            // How do I use a collection expression (C# 12+)? One value vs many; empty array?
            int[] singleElement = [5];
            int[] array4 = [1, 2, 3, 4, 5];
            int[] empty = [];
            Console.WriteLine("Collection expr single: " + string.Join(",", singleElement) + " | many: " + string.Join(",", array4) + " | empty Length: " + empty.Length);

            // How do I let the compiler infer the element type from the initializer?
            var inferred = new[] { 1.0, 2.0, 3.0 };
            Console.WriteLine("new[] inferred as double[]: " + string.Join(",", inferred));

            // How do I set or read one slot?
            array[0] = 99;
            Console.WriteLine("After array[0]=99: " + array[0]);

            // Note: another int[] variable assigned from array1 would reference the same object — mutating one mutates both until you copy (Clone, Copy, span.ToArray, etc.).

            // How do I print all values compactly?
            Console.WriteLine("array1: " + string.Join(",", array1));

            // How do I loop by index?
            for (int i = 0; i < array1.Length; i++)
            {
                Console.WriteLine("index " + i + " => " + array1[i]);
            }

            // How do I loop without an index?
            foreach (var v in array3)
            {
                Console.WriteLine("foreach: " + v);
            }

            // How do I get a shared empty array without allocating each time?
            int[] sharedEmpty = Array.Empty<int>();
            Console.WriteLine("Array.Empty Length: " + sharedEmpty.Length);
        }
        public static void ArrayInbuiltFunctions()
        {
            // How do I create a 1D int array with known values at the start?
            int[] array1 = new int[] { 1, 2, 3, 4, 0 ,10, 11, 12 , 13};
            // How do I get the length (element count) of an array? When do I use LongLength instead of Length?
            Console.WriteLine("Length: " + array1.Length + ", LongLength: " + array1.LongLength);   // Length is int, LongLength is long (for very large arrays)
            // How do I know how many dimensions an array has? How do I get the length of a specific dimension (e.g. rows in 2D)?
            Console.WriteLine("Rank: " + array1.Rank + ", GetLength(0): " + array1.GetLength(0));

            // How do I sort an array in ascending order (in place)?
            Array.Sort(array1);
            // How can I run a method on every element without writing a for loop?
            Array.ForEach(array1, x => Console.Write(x + " "));
            Console.WriteLine();

            // How do I binary-search for a value — and what must be true about the array first? (If not found, result is negative; ~result = insertion index.)
            int foundAt = Array.BinarySearch(array1, 10);
            Console.WriteLine("BinarySearch(10): index " + foundAt + " (sorted array required)");

            // How do I reverse the order of elements in an array?
            int[] reversedDemo = [1, 2, 3, 4];
            Array.Reverse(reversedDemo);
            Console.WriteLine("Reverse [1,2,3,4]: " + string.Join(",", reversedDemo));

            // How do I set a contiguous range of elements to default (0 for int)?
            Array.Clear(array1, 0, 4);
            // How do I loop through every element in a simple way?
            foreach (var i in array1)
            { 
                Console.WriteLine(i);
            }
            // How do I declare an array with both a fixed capacity and initial contents?
            int [] array2 = new int[20] {1,2,3,4,5,6, 0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            // How do I find the first index where a value appears? The last index?
            Console.WriteLine("IndexOf(13): " + Array.IndexOf(array1, 13));
            Console.WriteLine("LastIndexOf(0): " + Array.LastIndexOf(array1, 0));

            // How do I get the first element matching a condition? Its index? Every match as a new array?
            int firstOver5 = Array.Find(array1, x => x > 5);
            int idxOver5 = Array.FindIndex(array1, x => x > 5);
            int[] allOver5 = Array.FindAll(array1, x => x > 5);
            Console.WriteLine("Find(>5): " + firstOver5 + ", FindIndex: " + idxOver5 + ", FindAll: " + string.Join(",", allOver5));
            // How do I check that every element satisfies a predicate?
            Console.WriteLine("TrueForAll(>=0): " + Array.TrueForAll(array1, x => x >= 0));

            // How do I copy a segment from one array into another at a chosen destination index (how many elements)?
            Array.Copy(array1, 0, array2, 6, array1.Length - 1);
            // How do I print or process every element of array2 after copying?
            Array.ForEach(array2, x => Console.Write(x + " "));
            Console.WriteLine();
            // How do I test whether at least one element matches a condition?
            Console.WriteLine("Exists(==10): " + Array.Exists(array1, x => x == 10));

            // How do I set many slots to the same value (optionally only a range)?
            Array.Fill(array2, -1, 0, 5);
            Console.WriteLine("Fill first 5 with -1 (start of array2): " + string.Join(",", array2[..10]));

            // How do I take a sub-range (slice) of a 1D array? How do I index from the end (last element)? (Range on T[] allocates a new array.)
            int[] subArray = array1[2..5];
            int lastElement = array1[^1];
            Console.WriteLine("Sub Array: " + string.Join(",", subArray));
            Console.WriteLine("Last Element: " + lastElement);


        }
        // Multidimensional: rectangular int[,] (one block, fixed rows/cols) vs jagged int[][] (array of row arrays).
        public static void showMultidimensionalArrays()
        {
            Console.WriteLine("--- Rectangular int[,] ---");
            // How do I declare a 2D matrix with initial values — one comma in the type, two indices [row, col]?
            int[,] array2D = new int[2, 2] { { 1, 2 }, { 2, 3 } };
            // How do I read rows vs cols count? (Prefer GetLength over Length for per-dimension sizes.)
            Console.WriteLine("Rank: " + array2D.Rank + ", rows GetLength(0): " + array2D.GetLength(0) + ", cols GetLength(1): " + array2D.GetLength(1));
            // How many total elements? (.Length on rectangular = product of dimensions.)
            Console.WriteLine("Total elements (.Length): " + array2D.Length);

            // How do I assign one cell?
            array2D[0, 1] = 99;
            Console.WriteLine("After [0,1]=99: " + array2D[0, 1]);

            // How do I visit every element with nested loops?
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    Console.WriteLine("[" + i + "," + j + "] = " + array2D[i, j]);
                }
            }

            // How do I iterate all values without indices? (Row-major order.)
            Console.Write("foreach int[,]: ");
            foreach (var v in array2D)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();

            // How do I allocate rectangular with defaults only — then fill?
            int[,] grid = new int[2, 3];
            grid[1, 2] = 7;
            Console.WriteLine("grid[1,2]=" + grid[1, 2] + " (rest default 0)");

            Console.WriteLine("--- Jagged int[][] ---");
            // How do I declare rows of different lengths — each row is its own 1D array? (Classic: new int[][] { new int[] { }, ... }; C# 12+: [[...],[...]].)
            int[][] jaggedExpr = [[2, 3, 6], [5, 7]];
            // Gotcha: new int[3][] allocates 3 row references (all null) until each jagged[i] = new int[...].

            // How many rows? How long is row i?
            Console.WriteLine("Rows (Length): " + jaggedExpr.Length + ", row0 Length: " + jaggedExpr[0].Length + ", row1 Length: " + jaggedExpr[1].Length);

            for (int i = 0; i < jaggedExpr.Length; i++)
            {
                for (int j = 0; j < jaggedExpr[i].Length; j++)
                {
                    Console.WriteLine("jagged[" + i + "][" + j + "] = " + jaggedExpr[i][j]);
                }
            }

            // Outer Rank is 1 (array of arrays); inner arrays are normal int[].
            Console.WriteLine("jaggedExpr.Rank: " + jaggedExpr.Rank + ", jaggedExpr[0].Rank: " + jaggedExpr[0].Rank);
        }
    }
}
