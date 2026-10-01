using System;
using System.Collections.Generic;

namespace ConsoleApp1.C__Practise.PYnative.Lists;

/// <summary>
/// PYnative C# List Exercises — https://pynative.com/csharp-list-exercises/
/// </summary>
public static class ListExercises
{
    // Question 1: Create a list of 5 fruit names and print each fruit on its own line.
    public static void PrintFruits(IEnumerable<string> fruits)
        => throw new NotImplementedException();

    // Question 2: Add values with Add, then Insert a value at the given index.
    public static IReadOnlyList<int> AddThenInsert(IEnumerable<int> valuesToAdd, int insertIndex, int valueToInsert)
        => throw new NotImplementedException();

    // Question 3: Remove a value, then remove whatever element is at the given index.
    public static IReadOnlyList<int> RemoveValueThenIndex(IEnumerable<int> numbers, int value, int index)
        => throw new NotImplementedException();

    // Question 4: For each query color, report whether it is in the list ("Blue is in the list.").
    public static IReadOnlyList<string> DescribeMembership(IEnumerable<string> colors, IEnumerable<string> queries)
        => throw new NotImplementedException();

    // Question 5: Return the element count of a list of doubles before and after Clear.
    public static (int Before, int After) CountBeforeAndAfterClear(IEnumerable<double> values)
        => throw new NotImplementedException();

    // Question 6: Return the index of a name, or -1 when it is missing.
    public static int IndexOfName(IEnumerable<string> names, string name)
        => throw new NotImplementedException();

    // Question 7: Sum and average a list of integers with a loop (no LINQ).
    public static (int Sum, double Average) SumAndAverage(IEnumerable<int> numbers)
        => throw new NotImplementedException();

    // Question 8: Find max and min in a list of integers using a for loop.
    public static (int Max, int Min) MinAndMax(IEnumerable<int> numbers)
        => throw new NotImplementedException();

    // Question 9: Copy a list of strings into an array with ToArray.
    public static string[] ToArrayCopy(IEnumerable<string> items)
        => throw new NotImplementedException();

    // Question 10: Reverse a list of characters in place with Reverse.
    public static IReadOnlyList<char> ReverseLetters(IEnumerable<char> letters)
        => throw new NotImplementedException();

    // Question 11: Build a new list containing only the even numbers.
    public static IReadOnlyList<int> FilterEvenNumbers(IEnumerable<int> numbers)
        => throw new NotImplementedException();

    // Question 12: Remove duplicate integers while keeping the first-seen order, without HashSet.
    public static IReadOnlyList<int> RemoveDuplicates(IEnumerable<int> numbers)
        => throw new NotImplementedException();

    // Question 13: Sort integers ascending, then descending.
    public static (IReadOnlyList<int> Ascending, IReadOnlyList<int> Descending) SortAscendingThenDescending(IEnumerable<int> numbers)
        => throw new NotImplementedException();

    // Question 14: Merge two string lists into one list with no duplicate strings.
    public static IReadOnlyList<string> MergeUnique(IEnumerable<string> listA, IEnumerable<string> listB)
        => throw new NotImplementedException();

    // Question 15: Use FindAll to keep words longer than the given length.
    public static IReadOnlyList<string> FindLongWords(IEnumerable<string> words, int minLengthExclusive)
        => throw new NotImplementedException();

    // Question 16: Insert a second list into the first at the given index with InsertRange.
    public static IReadOnlyList<int> InsertRangeAt(IEnumerable<int> primary, int index, IEnumerable<int> toInsert)
        => throw new NotImplementedException();

    // Question 17: Return book titles that contain the given substring (case-sensitive).
    public static IReadOnlyList<string> TitlesContaining(IEnumerable<string> titles, string substring)
        => throw new NotImplementedException();

    // Question 18: Multiply every odd integer by 2, leaving even numbers unchanged.
    public static IReadOnlyList<int> DoubleOddNumbers(IEnumerable<int> numbers)
        => throw new NotImplementedException();

    // Question 19: Split a list into a first half and a second half of the given length.
    public static (IReadOnlyList<int> FirstHalf, IReadOnlyList<int> SecondHalf) SplitInHalf(IEnumerable<int> numbers, int halfLength)
        => throw new NotImplementedException();

    // Question 20: Print each student's id and name as "Id: 1, Name: Alice".
    public static void PrintStudents(IEnumerable<ListStudent> students)
        => throw new NotImplementedException();

    // Question 21: Walk a linked list forward with Next and backward with Previous.
    public static (string Forward, string Backward) TraverseWorkflow(IEnumerable<string> steps)
        => throw new NotImplementedException();

    // Question 22: AddLast, AddFirst, AddLast, then RemoveFirst and RemoveLast.
    public static (IReadOnlyList<string> BeforeRemoval, IReadOnlyList<string> AfterRemoval) AddPriorityTasks(
        string firstLowPriority, string highPriority, string secondLowPriority)
        => throw new NotImplementedException();

    // Question 23: Find a linked-list node and insert a value immediately after it.
    public static IReadOnlyList<int> InsertAfter(IEnumerable<int> numbers, int existingValue, int valueToInsert)
        => throw new NotImplementedException();

    // Question 24: Find a song node and remove that node from the linked list.
    public static IReadOnlyList<string> RemoveSong(IEnumerable<string> songs, string songToRemove)
        => throw new NotImplementedException();

    // Question 25: Copy a LinkedList into a List by walking nodes, without LINQ.
    public static IReadOnlyList<int> ToStandardList(LinkedList<int> source)
        => throw new NotImplementedException();

    // Question 26: Electronics products priced above the minimum, sorted by price descending.
    public static IReadOnlyList<ListProduct> ExpensiveProducts(IEnumerable<ListProduct> products, string category, double minPrice)
        => throw new NotImplementedException();

    // Question 27: Group employees by department and return each department's average salary, in first-seen order.
    public static IReadOnlyList<(string Department, double AverageSalary)> AverageSalaryByDepartment(IEnumerable<ListEmployee> employees)
        => throw new NotImplementedException();

    // Question 28: Sort people by age ascending using a custom IComparer.
    public static IReadOnlyList<ListPerson> SortPeopleByAge(IEnumerable<ListPerson> people)
        => throw new NotImplementedException();

    // Question 29: Split a list into chunks of the given size; the last chunk may be shorter.
    public static IReadOnlyList<IReadOnlyList<int>> ChunkList(IEnumerable<int> source, int chunkSize)
        => throw new NotImplementedException();

    // Question 30: Flatten a list of integer lists into one list with SelectMany.
    public static IReadOnlyList<int> FlattenLists(IEnumerable<IEnumerable<int>> nested)
        => throw new NotImplementedException();

    // Question 31: BinarySearch a sorted list and return the index of the target.
    public static int BinarySearch(IReadOnlyList<int> sortedNumbers, int target)
        => throw new NotImplementedException();

    // Question 32: Convert students to a dictionary keyed by Id.
    public static IReadOnlyDictionary<int, ListStudent> StudentsById(IEnumerable<ListStudent> students)
        => throw new NotImplementedException();

    // Question 33: Whether any score equals the perfect score, and whether every score is above the pass mark.
    public static (bool AnyPerfect, bool AllPassed) CheckScores(IEnumerable<int> scores, int perfectScore, int passMarkExclusive)
        => throw new NotImplementedException();

    // Question 34: Rotate a list left by k positions.
    public static IReadOnlyList<T> RotateLeft<T>(IEnumerable<T> source, int positions)
        => throw new NotImplementedException();

    // Question 35: Count how often each word appears, in first-seen order.
    public static IReadOnlyList<(string Word, int Count)> WordFrequencies(IEnumerable<string> words)
        => throw new NotImplementedException();
}
