using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.Lists;

public static class ListExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 35; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative — List Exercises (35)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_PrintFruits(),
        2 => Test02_AddThenInsert(),
        3 => Test03_RemoveValueThenIndex(),
        4 => Test04_DescribeMembership(),
        5 => Test05_CountBeforeAndAfterClear(),
        6 => Test06_IndexOfName(),
        7 => Test07_SumAndAverage(),
        8 => Test08_MinAndMax(),
        9 => Test09_ToArrayCopy(),
        10 => Test10_ReverseLetters(),
        11 => Test11_FilterEvenNumbers(),
        12 => Test12_RemoveDuplicates(),
        13 => Test13_SortAscendingThenDescending(),
        14 => Test14_MergeUnique(),
        15 => Test15_FindLongWords(),
        16 => Test16_InsertRangeAt(),
        17 => Test17_TitlesContaining(),
        18 => Test18_DoubleOddNumbers(),
        19 => Test19_SplitInHalf(),
        20 => Test20_PrintStudents(),
        21 => Test21_TraverseWorkflow(),
        22 => Test22_AddPriorityTasks(),
        23 => Test23_InsertAfter(),
        24 => Test24_RemoveSong(),
        25 => Test25_ToStandardList(),
        26 => Test26_ExpensiveProducts(),
        27 => Test27_AverageSalaryByDepartment(),
        28 => Test28_SortPeopleByAge(),
        29 => Test29_ChunkList(),
        30 => Test30_FlattenLists(),
        31 => Test31_BinarySearch(),
        32 => Test32_StudentsById(),
        33 => Test33_CheckScores(),
        34 => Test34_RotateLeft(),
        35 => Test35_WordFrequencies(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "List exercises are numbered 1–35.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_PrintFruits() =>
        PynativeExerciseRunner.Run(1, "Initialize and Print",
            "Create a list of 5 fruit names and print each fruit on a new line.",
            t => t.Add(("5 fruits", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Apple", "Banana", "Cherry", "Date", "Elderberry" },
                    () => PynativeConsole.CaptureLines(() => ListExercises.PrintFruits(
                        new[] { "Apple", "Banana", "Cherry", "Date", "Elderberry" }))))));

    public static PynativeExerciseRunner.SuiteResult Test02_AddThenInsert() =>
        PynativeExerciseRunner.Run(2, "Add & Insert",
            "Add 10, 20, and 30, then insert 15 at index 1.",
            t => t.Add(("insert 15 at index 1 -> 10, 15, 20, 30", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 10, 15, 20, 30 },
                    () => ListExercises.AddThenInsert(new[] { 10, 20, 30 }, 1, 15)))));

    public static PynativeExerciseRunner.SuiteResult Test03_RemoveValueThenIndex() =>
        PynativeExerciseRunner.Run(3, "Remove Elements",
            "From 1..10, remove the value 5, then remove the element at index 0.",
            t => t.Add(("remove 5 then index 0", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 2, 3, 4, 6, 7, 8, 9, 10 },
                    () => ListExercises.RemoveValueThenIndex(Enumerable.Range(1, 10), 5, 0)))));

    public static PynativeExerciseRunner.SuiteResult Test04_DescribeMembership() =>
        PynativeExerciseRunner.Run(4, "Check Existence",
            "Check whether each color exists in Red, Green, Blue, Yellow.",
            t => t.Add(("Blue and Purple", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Blue is in the list.", "Purple is not in the list." },
                    () => ListExercises.DescribeMembership(
                        new[] { "Red", "Green", "Blue", "Yellow" },
                        new[] { "Blue", "Purple" })))));

    public static PynativeExerciseRunner.SuiteResult Test05_CountBeforeAndAfterClear() =>
        PynativeExerciseRunner.Run(5, "Count and Clear",
            "Print the count, clear the list, and verify the count is 0.",
            t => t.Add(("4 doubles -> before 4, after 0", () =>
            {
                var (before, after) = ListExercises.CountBeforeAndAfterClear(new[] { 1.1, 2.2, 3.3, 4.4 });
                PynativeExerciseRunner.PrintOutput($"before={before}, after={after}");
                PynativeExerciseRunner.AssertEqualSilent(4, before);
                PynativeExerciseRunner.AssertEqualSilent(0, after);
            })));

    public static PynativeExerciseRunner.SuiteResult Test06_IndexOfName() =>
        PynativeExerciseRunner.Run(6, "Find Index",
            "Find the index of a name with IndexOf, or -1 if it is missing.",
            t =>
            {
                var names = new[] { "Alice", "Bob", "Charlie", "Diana" };
                t.Add(("Charlie -> 2", () =>
                    PynativeExerciseRunner.AssertEqual(2, () => ListExercises.IndexOfName(names, "Charlie"))));
                t.Add(("Zoe -> -1", () =>
                    PynativeExerciseRunner.AssertEqual(-1, () => ListExercises.IndexOfName(names, "Zoe"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test07_SumAndAverage() =>
        PynativeExerciseRunner.Run(7, "Sum and Average",
            "Calculate the sum and average of integers with a loop, not LINQ.",
            t => t.Add(("4, 8, 15, 16, 23, 42 -> sum 108, average 18", () =>
            {
                var (sum, average) = ListExercises.SumAndAverage(new[] { 4, 8, 15, 16, 23, 42 });
                PynativeExerciseRunner.PrintOutput($"sum={sum}, average={average}");
                PynativeExerciseRunner.AssertEqualSilent(108, sum);
                PynativeExerciseRunner.AssertEqualSilent(18d, average);
            })));

    public static PynativeExerciseRunner.SuiteResult Test08_MinAndMax() =>
        PynativeExerciseRunner.Run(8, "Min and Max",
            "Find the maximum and minimum values with a for loop.",
            t => t.Add(("34, 12, 89, 5, 67, 23 -> max 89, min 5", () =>
            {
                var (max, min) = ListExercises.MinAndMax(new[] { 34, 12, 89, 5, 67, 23 });
                PynativeExerciseRunner.PrintOutput($"max={max}, min={min}");
                PynativeExerciseRunner.AssertEqualSilent(89, max);
                PynativeExerciseRunner.AssertEqualSilent(5, min);
            })));

    public static PynativeExerciseRunner.SuiteResult Test09_ToArrayCopy() =>
        PynativeExerciseRunner.Run(9, "List to Array",
            "Convert a list of strings to an array with ToArray and print the elements.",
            t => t.Add(("Apple, Banana, Cherry", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Apple", "Banana", "Cherry" },
                    () => ListExercises.ToArrayCopy(new[] { "Apple", "Banana", "Cherry" })))));

    public static PynativeExerciseRunner.SuiteResult Test10_ReverseLetters() =>
        PynativeExerciseRunner.Run(10, "Reverse a List",
            "Reverse characters A to E with Reverse.",
            t => t.Add(("A..E -> E, D, C, B, A", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 'E', 'D', 'C', 'B', 'A' },
                    () => ListExercises.ReverseLetters(new[] { 'A', 'B', 'C', 'D', 'E' })))));

    public static PynativeExerciseRunner.SuiteResult Test11_FilterEvenNumbers() =>
        PynativeExerciseRunner.Run(11, "Filter Even Numbers",
            "Create a new list containing only the even numbers.",
            t => t.Add(("sample ints -> 12, 8, 4, 22", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 12, 8, 4, 22 },
                    () => ListExercises.FilterEvenNumbers(new[] { 12, 7, 8, 3, 4, 15, 22, 9 })))));

    public static PynativeExerciseRunner.SuiteResult Test12_RemoveDuplicates() =>
        PynativeExerciseRunner.Run(12, "Remove Duplicates",
            "Remove duplicate integers without HashSet, keeping first-seen order.",
            t => t.Add(("with repeats -> 1, 2, 3, 4, 5", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4, 5 },
                    () => ListExercises.RemoveDuplicates(new[] { 1, 2, 2, 3, 4, 4, 4, 5, 1 })))));

    public static PynativeExerciseRunner.SuiteResult Test13_SortAscendingThenDescending() =>
        PynativeExerciseRunner.Run(13, "Sort Lists",
            "Sort integers ascending, then sort the same values descending.",
            t => t.Add(("42, 17, 8, 99, 23, 4", () =>
            {
                var (ascending, descending) = ListExercises.SortAscendingThenDescending(new[] { 42, 17, 8, 99, 23, 4 });
                PynativeExerciseRunner.PrintOutput(
                    $"asc=[{string.Join(", ", ascending)}], desc=[{string.Join(", ", descending)}]");
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 4, 8, 17, 23, 42, 99 }, ascending);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 99, 42, 23, 17, 8, 4 }, descending);
            })));

    public static PynativeExerciseRunner.SuiteResult Test14_MergeUnique() =>
        PynativeExerciseRunner.Run(14, "Merge Two Lists",
            "Combine two string lists so no duplicate strings are added.",
            t => t.Add(("fruits from both lists", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Apple", "Banana", "Cherry", "Date", "Fig" },
                    () => ListExercises.MergeUnique(
                        new[] { "Apple", "Banana", "Cherry" },
                        new[] { "Banana", "Date", "Cherry", "Fig" })))));

    public static PynativeExerciseRunner.SuiteResult Test15_FindLongWords() =>
        PynativeExerciseRunner.Run(15, "Find All Matches",
            "Use FindAll to extract words longer than 5 characters.",
            t => t.Add(("words -> elephant, giraffe, butterfly", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "elephant", "giraffe", "butterfly" },
                    () => ListExercises.FindLongWords(
                        new[] { "cat", "elephant", "dog", "giraffe", "ant", "butterfly" }, 5)))));

    public static PynativeExerciseRunner.SuiteResult Test16_InsertRangeAt() =>
        PynativeExerciseRunner.Run(16, "Insert Range",
            "Insert 3, 4, 5 into 1, 2, 6, 7 so the list becomes sequential.",
            t => t.Add(("insert at index 2", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4, 5, 6, 7 },
                    () => ListExercises.InsertRangeAt(new[] { 1, 2, 6, 7 }, 2, new[] { 3, 4, 5 })))));

    public static PynativeExerciseRunner.SuiteResult Test17_TitlesContaining() =>
        PynativeExerciseRunner.Run(17, "Check for Substring",
            "Filter book titles that contain the word \"The\".",
            t => t.Add(("5 titles", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "The Great Gatsby", "The Catcher in the Rye", "The Hobbit" },
                    () => ListExercises.TitlesContaining(
                        new[] { "The Great Gatsby", "Moby Dick", "The Catcher in the Rye", "1984", "The Hobbit" },
                        "The")))));

    public static PynativeExerciseRunner.SuiteResult Test18_DoubleOddNumbers() =>
        PynativeExerciseRunner.Run(18, "Update Elements",
            "Multiply every odd number by 2.",
            t => t.Add(("1..6 -> 2, 2, 6, 4, 10, 6", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 2, 2, 6, 4, 10, 6 },
                    () => ListExercises.DoubleOddNumbers(new[] { 1, 2, 3, 4, 5, 6 })))));

    public static PynativeExerciseRunner.SuiteResult Test19_SplitInHalf() =>
        PynativeExerciseRunner.Run(19, "Split a List",
            "Split 10 numbers into the first 5 and the last 5.",
            t => t.Add(("1..10", () =>
            {
                var (first, second) = ListExercises.SplitInHalf(Enumerable.Range(1, 10), 5);
                PynativeExerciseRunner.PrintOutput(
                    $"first=[{string.Join(", ", first)}], second=[{string.Join(", ", second)}]");
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 1, 2, 3, 4, 5 }, first);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 6, 7, 8, 9, 10 }, second);
            })));

    public static PynativeExerciseRunner.SuiteResult Test20_PrintStudents() =>
        PynativeExerciseRunner.Run(20, "List of Custom Objects",
            "Create a Student list with Id and Name and print each student's details.",
            t => t.Add(("Alice, Bob, Charlie", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Id: 1, Name: Alice", "Id: 2, Name: Bob", "Id: 3, Name: Charlie" },
                    () => PynativeConsole.CaptureLines(() => ListExercises.PrintStudents(new[]
                    {
                        new ListStudent { Id = 1, Name = "Alice" },
                        new ListStudent { Id = 2, Name = "Bob" },
                        new ListStudent { Id = 3, Name = "Charlie" },
                    }))))));

    public static PynativeExerciseRunner.SuiteResult Test21_TraverseWorkflow() =>
        PynativeExerciseRunner.Run(21, "Forward and Backward Traversal",
            "Print a linked list of workflow steps forward with Next and backward with Previous.",
            t => t.Add(("Design, Develop, Test, Deploy", () =>
            {
                var (forward, backward) = ListExercises.TraverseWorkflow(
                    new[] { "Design", "Develop", "Test", "Deploy" });
                PynativeExerciseRunner.PrintOutput($"forward={forward}, backward={backward}");
                PynativeExerciseRunner.AssertEqualSilent("Design -> Develop -> Test -> Deploy", forward);
                PynativeExerciseRunner.AssertEqualSilent("Deploy -> Test -> Develop -> Design", backward);
            })));

    public static PynativeExerciseRunner.SuiteResult Test22_AddPriorityTasks() =>
        PynativeExerciseRunner.Run(22, "First and Last Manipulation",
            "AddLast and AddFirst tasks, then RemoveFirst and RemoveLast.",
            t => t.Add(("report, critical bug, docs", () =>
            {
                var (before, after) = ListExercises.AddPriorityTasks("Write report", "Fix critical bug", "Update docs");
                PynativeExerciseRunner.PrintOutput(
                    $"before=[{string.Join(", ", before)}], after=[{string.Join(", ", after)}]");
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Fix critical bug", "Write report", "Update docs" }, before);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "Write report" }, after);
            })));

    public static PynativeExerciseRunner.SuiteResult Test23_InsertAfter() =>
        PynativeExerciseRunner.Run(23, "Mid-List Insertion",
            "Find the node containing 2 and AddAfter the missing 3.",
            t => t.Add(("1, 2, 4 insert 3 after 2", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4 },
                    () => ListExercises.InsertAfter(new[] { 1, 2, 4 }, 2, 3)))));

    public static PynativeExerciseRunner.SuiteResult Test24_RemoveSong() =>
        PynativeExerciseRunner.Run(24, "Targeted Node Removal",
            "Find the Hotel California node and remove that node.",
            t => t.Add(("4 songs", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Bohemian Rhapsody", "Stairway to Heaven", "Imagine" },
                    () => ListExercises.RemoveSong(
                        new[] { "Bohemian Rhapsody", "Stairway to Heaven", "Hotel California", "Imagine" },
                        "Hotel California")))));

    public static PynativeExerciseRunner.SuiteResult Test25_ToStandardList() =>
        PynativeExerciseRunner.Run(25, "Convert to Standard List",
            "Copy a LinkedList into a List by walking nodes, without LINQ.",
            t => t.Add(("10, 20, 30, 40", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 10, 20, 30, 40 },
                    () => ListExercises.ToStandardList(new LinkedList<int>(new[] { 10, 20, 30, 40 }))))));

    public static PynativeExerciseRunner.SuiteResult Test26_ExpensiveProducts() =>
        PynativeExerciseRunner.Run(26, "LINQ Filtering & Sorting",
            "Electronics priced above 500, sorted by price descending.",
            t => t.Add(("5 products", () =>
            {
                var matches = ListExercises.ExpensiveProducts(new[]
                {
                    new ListProduct { Name = "Laptop", Price = 1200, Category = "Electronics" },
                    new ListProduct { Name = "Headphones", Price = 150, Category = "Electronics" },
                    new ListProduct { Name = "Smartphone", Price = 800, Category = "Electronics" },
                    new ListProduct { Name = "Desk", Price = 300, Category = "Furniture" },
                    new ListProduct { Name = "Monitor", Price = 600, Category = "Electronics" },
                }, "Electronics", 500);
                PynativeExerciseRunner.PrintOutput(string.Join(", ", matches.Select(p => $"{p.Name}:{p.Price}")));
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "Laptop", "Smartphone", "Monitor" }, matches.Select(p => p.Name));
                PynativeExerciseRunner.AssertEqualSilent(1200d, matches[0].Price);
                PynativeExerciseRunner.AssertEqualSilent(800d, matches[1].Price);
                PynativeExerciseRunner.AssertEqualSilent(600d, matches[2].Price);
            })));

    public static PynativeExerciseRunner.SuiteResult Test27_AverageSalaryByDepartment() =>
        PynativeExerciseRunner.Run(27, "Group By",
            "Group employees by department and print each department's average salary.",
            t => t.Add(("5 employees", () =>
            {
                var groups = ListExercises.AverageSalaryByDepartment(new[]
                {
                    new ListEmployee { Name = "Alice", Department = "Engineering", Salary = 95000 },
                    new ListEmployee { Name = "Bob", Department = "Sales", Salary = 65000 },
                    new ListEmployee { Name = "Charlie", Department = "Engineering", Salary = 105000 },
                    new ListEmployee { Name = "Diana", Department = "Sales", Salary = 70000 },
                    new ListEmployee { Name = "Eve", Department = "Marketing", Salary = 60000 },
                });
                PynativeExerciseRunner.PrintOutput(string.Join(", ", groups.Select(g => $"{g.Department}:{g.AverageSalary}")));
                PynativeExerciseRunner.AssertEqualSilent(3, groups.Count);
                PynativeExerciseRunner.AssertEqualSilent("Engineering", groups[0].Department);
                PynativeExerciseRunner.AssertEqualSilent(100000d, groups[0].AverageSalary);
                PynativeExerciseRunner.AssertEqualSilent("Sales", groups[1].Department);
                PynativeExerciseRunner.AssertEqualSilent(67500d, groups[1].AverageSalary);
                PynativeExerciseRunner.AssertEqualSilent("Marketing", groups[2].Department);
                PynativeExerciseRunner.AssertEqualSilent(60000d, groups[2].AverageSalary);
            })));

    public static PynativeExerciseRunner.SuiteResult Test28_SortPeopleByAge() =>
        PynativeExerciseRunner.Run(28, "Custom Object Sorting",
            "Sort people by Age using a custom IComparer.",
            t => t.Add(("ages 30, 22, 45, 28", () =>
            {
                var sorted = ListExercises.SortPeopleByAge(new[]
                {
                    new ListPerson { Name = "Alice", Age = 30 },
                    new ListPerson { Name = "Bob", Age = 22 },
                    new ListPerson { Name = "Charlie", Age = 45 },
                    new ListPerson { Name = "Diana", Age = 28 },
                });
                PynativeExerciseRunner.PrintOutput(string.Join(", ", sorted.Select(p => $"{p.Name}:{p.Age}")));
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Bob", "Diana", "Alice", "Charlie" }, sorted.Select(p => p.Name));
            })));

    public static PynativeExerciseRunner.SuiteResult Test29_ChunkList() =>
        PynativeExerciseRunner.Run(29, "Chunking a List",
            "Break a list into smaller lists of size 3.",
            t => t.Add(("1..10 chunk 3", () =>
            {
                var chunks = ListExercises.ChunkList(Enumerable.Range(1, 10), 3);
                PynativeExerciseRunner.PrintOutput(string.Join(" | ", chunks.Select(c => $"[{string.Join(",", c)}]")));
                PynativeExerciseRunner.AssertEqualSilent(4, chunks.Count);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 1, 2, 3 }, chunks[0]);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 4, 5, 6 }, chunks[1]);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 7, 8, 9 }, chunks[2]);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 10 }, chunks[3]);
            })));

    public static PynativeExerciseRunner.SuiteResult Test30_FlattenLists() =>
        PynativeExerciseRunner.Run(30, "Flattening Lists",
            "Flatten a list of integer lists with SelectMany.",
            t => t.Add(("three inner lists", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                    () => ListExercises.FlattenLists(new[]
                    {
                        new[] { 1, 2, 3 },
                        new[] { 4, 5 },
                        new[] { 6, 7, 8, 9 },
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test31_BinarySearch() =>
        PynativeExerciseRunner.Run(31, "Binary Search",
            "BinarySearch a sorted list of 1000 even numbers for the value 742.",
            t => t.Add(("0, 2, .. 1998 search 742 -> 371", () =>
            {
                var numbers = new List<int>();
                for (int i = 0; i < 1000; i++)
                    numbers.Add(i * 2);
                PynativeExerciseRunner.AssertEqual(371, () => ListExercises.BinarySearch(numbers, 742));
            })));

    public static PynativeExerciseRunner.SuiteResult Test32_StudentsById() =>
        PynativeExerciseRunner.Run(32, "Dictionary Conversion",
            "Convert a student list into a dictionary keyed by Id.",
            t => t.Add(("lookup id 2 -> Bob", () =>
            {
                var byId = ListExercises.StudentsById(new[]
                {
                    new ListStudent { Id = 1, Name = "Alice" },
                    new ListStudent { Id = 2, Name = "Bob" },
                    new ListStudent { Id = 3, Name = "Charlie" },
                });
                PynativeExerciseRunner.PrintOutput(byId[2].Name);
                PynativeExerciseRunner.AssertEqualSilent("Bob", byId[2].Name);
            })));

    public static PynativeExerciseRunner.SuiteResult Test33_CheckScores() =>
        PynativeExerciseRunner.Run(33, "Check Conditions (All/Any)",
            "Check if any student scored 100 and if all students scored above 50.",
            t => t.Add(("85, 100, 62, 78, 45, 90", () =>
            {
                var (anyPerfect, allPassed) = ListExercises.CheckScores(
                    new[] { 85, 100, 62, 78, 45, 90 }, 100, 50);
                PynativeExerciseRunner.PrintOutput($"anyPerfect={anyPerfect}, allPassed={allPassed}");
                PynativeExerciseRunner.AssertEqualSilent(true, anyPerfect);
                PynativeExerciseRunner.AssertEqualSilent(false, allPassed);
            })));

    public static PynativeExerciseRunner.SuiteResult Test34_RotateLeft() =>
        PynativeExerciseRunner.Run(34, "Rotate Elements",
            "Rotate a list left by k positions. {1, 2, 3, 4} by 1 becomes {2, 3, 4, 1}.",
            t => t.Add(("rotate 1, 2, 3, 4 left by 1", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 2, 3, 4, 1 },
                    () => ListExercises.RotateLeft(new[] { 1, 2, 3, 4 }, 1)))));

    public static PynativeExerciseRunner.SuiteResult Test35_WordFrequencies() =>
        PynativeExerciseRunner.Run(35, "Frequency Count",
            "Count each word and return the word with its count.",
            t => t.Add(("apple, banana, apple, cherry, apple, banana", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "apple: 3", "banana: 2", "cherry: 1" },
                    () => ListExercises.WordFrequencies(
                        new[] { "apple", "banana", "apple", "cherry", "apple", "banana" })
                        .Select(entry => $"{entry.Word}: {entry.Count}")))));
}
