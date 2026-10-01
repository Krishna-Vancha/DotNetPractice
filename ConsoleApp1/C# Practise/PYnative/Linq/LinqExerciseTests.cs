using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.Linq;

public static class LinqExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 40; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative â€” LINQ Exercises (40)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_FilterEvenNumbers(),
        2 => Test02_FindLongWords(),
        3 => Test03_SortNamesDescending(),
        4 => Test04_TopThreeUniqueNumbers(),
        5 => Test05_PaginateProducts(),
        6 => Test06_FruitsStartingWithA(),
        7 => Test07_AgesInRange(),
        8 => Test08_SquareNumbers(),
        9 => Test09_FirstDivisibleBySeven(),
        10 => Test10_LastWordEndingWithE(),
        11 => Test11_ToUppercase(),
        12 => Test12_ExtractEmails(),
        13 => Test13_CalculateProductTaxes(),
        14 => Test14_FlattenDepartmentEmployees(),
        15 => Test15_UniqueCharactersSorted(),
        16 => Test16_ProjectWithIndex(),
        17 => Test17_ZipFullNames(),
        18 => Test18_UniqueEmailDomains(),
        19 => Test19_FlattenJaggedArray(),
        20 => Test20_ExtractFileExtensions(),
        21 => Test21_SumOfSquaresOfOddNumbers(),
        22 => Test22_AverageBookPriceAfterYear(),
        23 => Test23_MinMaxProductPrice(),
        24 => Test24_CountSentencesContainingLinq(),
        25 => Test25_JoinWordsWithAggregate(),
        26 => Test26_Factorial(),
        27 => Test27_SumDepartmentSalaries(),
        28 => Test28_CountVowels(),
        29 => Test29_ProductOfNonZeroNumbers(),
        30 => Test30_LongestWord(),
        31 => Test31_GroupPeopleByAge(),
        32 => Test32_CountWordsByLength(),
        33 => Test33_JoinStudentsAndCourses(),
        34 => Test34_LeftJoinEmployeesDepartments(),
        35 => Test35_CommonNumbers(),
        36 => Test36_MissingProducts(),
        37 => Test37_UnionNames(),
        38 => Test38_MostFrequentNumber(),
        39 => Test39_HighestPaidPerDepartment(),
        40 => Test40_ChunkNumbers(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "LINQ exercises are numbered 1â€“40.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_FilterEvenNumbers() =>
        PynativeExerciseRunner.Run(1, "Filtering Even Numbers",
            "Return only even numbers using Where().",
            t => t.Add(("1..10 -> evens", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 2, 4, 6, 8, 10 },
                    () => LinqExercises.FilterEvenNumbers(Enumerable.Range(1, 10))))));

    public static PynativeExerciseRunner.SuiteResult Test02_FindLongWords() =>
        PynativeExerciseRunner.Run(2, "Finding Long Words",
            "Find words with more than 5 characters.",
            t => t.Add(("sample words", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "elephant", "butterfly", "giraffe" },
                    () => LinqExercises.FindLongWords(new[] { "cat", "elephant", "dog", "butterfly", "ox", "giraffe" })))));

    public static PynativeExerciseRunner.SuiteResult Test03_SortNamesDescending() =>
        PynativeExerciseRunner.Run(3, "Sorting Names in Reverse",
            "Sort names descending alphabetically.",
            t => t.Add(("5 names", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Eve", "Dave", "Charlie", "Bob", "Alice" },
                    () => LinqExercises.SortNamesDescending(new[] { "Charlie", "Alice", "Bob", "Eve", "Dave" })))));

    public static PynativeExerciseRunner.SuiteResult Test04_TopThreeUniqueNumbers() =>
        PynativeExerciseRunner.Run(4, "Top 3 Unique Numbers",
            "Top 3 highest unique values.",
            t => t.Add(("sample array", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 90, 80, 50 },
                    () => LinqExercises.TopThreeUniqueNumbers(new[] { 50, 20, 50, 80, 80, 10, 30, 90 })))));

    public static PynativeExerciseRunner.SuiteResult Test05_PaginateProducts() =>
        PynativeExerciseRunner.Run(5, "Paginating a Product List",
            "Skip 20, take 10 from Product 1..100.",
            t => t.Add(("skip 20 take 10", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    Enumerable.Range(21, 10).Select(i => $"Product {i}"),
                    () => LinqExercises.PaginateProducts(20, 10)))));

    public static PynativeExerciseRunner.SuiteResult Test06_FruitsStartingWithA() =>
        PynativeExerciseRunner.Run(6, "Fruits Starting with A",
            "Fruits starting with A (case-insensitive).",
            t => t.Add(("fruit array", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "apple", "Avocado", "apricot" },
                    () => LinqExercises.FruitsStartingWithA(new[] { "apple", "Banana", "Avocado", "cherry", "apricot", "Mango" })))));

    public static PynativeExerciseRunner.SuiteResult Test07_AgesInRange() =>
        PynativeExerciseRunner.Run(7, "Filtering Ages in a Range",
            "Ages between 25 and 35 inclusive.",
            t => t.Add(("employee ages", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 25, 30, 35, 28, 33 },
                    () => LinqExercises.AgesInRange(new[] { 22, 25, 30, 35, 40, 28, 19, 33 }, 25, 35)))));

    public static PynativeExerciseRunner.SuiteResult Test08_SquareNumbers() =>
        PynativeExerciseRunner.Run(8, "Squaring a List of Numbers",
            "Return squares using Select().",
            t => t.Add(("1..5", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 4, 9, 16, 25 },
                    () => LinqExercises.SquareNumbers(new[] { 1, 2, 3, 4, 5 })))));

    public static PynativeExerciseRunner.SuiteResult Test09_FirstDivisibleBySeven() =>
        PynativeExerciseRunner.Run(9, "Finding the First Match",
            "First number divisible by 7, else 0.",
            t => t.Add(("no divisible by 7 -> 0", () =>
                PynativeExerciseRunner.AssertEqual(0,
                    () => LinqExercises.FirstDivisibleBySeven(new[] { 10, 15, 22, 33, 41, 50 })))));

    public static PynativeExerciseRunner.SuiteResult Test10_LastWordEndingWithE() =>
        PynativeExerciseRunner.Run(10, "Finding the Last Match",
            "Last word ending with 'e'.",
            t => t.Add(("word list", () =>
                PynativeExerciseRunner.AssertEqual("orange",
                    () => LinqExercises.LastWordEndingWithE(new[] { "apple", "banana", "grape", "cherry", "orange", "kiwi" })))));

    public static PynativeExerciseRunner.SuiteResult Test11_ToUppercase() =>
        PynativeExerciseRunner.Run(11, "Converting Strings to Uppercase",
            "Transform to uppercase.",
            t => t.Add(("fruits", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "APPLE", "BANANA", "CHERRY" },
                    () => LinqExercises.ToUppercase(new[] { "apple", "banana", "cherry" })))));

    public static PynativeExerciseRunner.SuiteResult Test12_ExtractEmails() =>
        PynativeExerciseRunner.Run(12, "Projecting Object Properties",
            "Extract Email from User objects.",
            t => t.Add(("3 users", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "alice@example.com", "bob@example.com", "charlie@example.com" },
                    () => LinqExercises.ExtractEmails(new[]
                    {
                        new LinqUser { Id = 1, Name = "Alice", Email = "alice@example.com" },
                        new LinqUser { Id = 2, Name = "Bob", Email = "bob@example.com" },
                        new LinqUser { Id = 3, Name = "Charlie", Email = "charlie@example.com" },
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test13_CalculateProductTaxes() =>
        PynativeExerciseRunner.Run(13, "Creating Anonymous Types",
            "Project product name and tax (15%).",
            t =>
            {
                t.Add(("3 products", () =>
                {
                    var taxes = LinqExercises.CalculateProductTaxes(new[]
                    {
                        new LinqProduct { Name = "Laptop", Price = 1000m },
                        new LinqProduct { Name = "Mouse", Price = 20m },
                        new LinqProduct { Name = "Keyboard", Price = 50m },
                    });
                    PynativeExerciseRunner.PrintOutput(
                        string.Join(", ", taxes.Select(t => $"{t.ProductName}:{t.CalculatedTax}")));
                    PynativeExerciseRunner.AssertEqualSilent(150m, taxes[0].CalculatedTax);
                    PynativeExerciseRunner.AssertEqualSilent(3m, taxes[1].CalculatedTax);
                    PynativeExerciseRunner.AssertEqualSilent(7.5m, taxes[2].CalculatedTax);
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test14_FlattenDepartmentEmployees() =>
        PynativeExerciseRunner.Run(14, "Flattening Nested Lists",
            "Flatten employee names with SelectMany.",
            t => t.Add(("3 departments", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Alice", "Bob", "Charlie", "Dave", "Eve" },
                    () => LinqExercises.FlattenDepartmentEmployees(new[]
                    {
                        new LinqDepartmentWithEmployees { Name = "Eng", EmployeeNames = new[] { "Alice", "Bob" } },
                        new LinqDepartmentWithEmployees { Name = "Sales", EmployeeNames = new[] { "Charlie" } },
                        new LinqDepartmentWithEmployees { Name = "Mkt", EmployeeNames = new[] { "Dave", "Eve" } },
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test15_UniqueCharactersSorted() =>
        PynativeExerciseRunner.Run(15, "Finding Unique Characters",
            "Unique non-space chars sorted.",
            t => t.Add(("the quick brown fox", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 'b', 'c', 'e', 'f', 'h', 'i', 'k', 'n', 'o', 'q', 'r', 't', 'u', 'w', 'x' },
                    () => LinqExercises.UniqueCharactersSorted("the quick brown fox")))));

    public static PynativeExerciseRunner.SuiteResult Test16_ProjectWithIndex() =>
        PynativeExerciseRunner.Run(16, "Projecting with Index",
            "Format index and value strings.",
            t => t.Add(("RGB colors", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Index: 0, Value: Red", "Index: 1, Value: Green", "Index: 2, Value: Blue" },
                    () => LinqExercises.ProjectWithIndex(new[] { "Red", "Green", "Blue" })))));

    public static PynativeExerciseRunner.SuiteResult Test17_ZipFullNames() =>
        PynativeExerciseRunner.Run(17, "Zipping Two Arrays Together",
            "Combine first/last names with Zip.",
            t => t.Add(("3 names each", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "John Doe", "Jane Smith", "Jim Brown" },
                    () => LinqExercises.ZipFullNames(
                        new[] { "John", "Jane", "Jim" },
                        new[] { "Doe", "Smith", "Brown" })))));

    public static PynativeExerciseRunner.SuiteResult Test18_UniqueEmailDomains() =>
        PynativeExerciseRunner.Run(18, "Extracting Unique Email Domains",
            "Unique domains from emails.",
            t => t.Add(("5 emails", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "gmail.com", "yahoo.com", "outlook.com" },
                    () => LinqExercises.UniqueEmailDomains(new[]
                    {
                        "alice@gmail.com", "bob@yahoo.com", "charlie@gmail.com",
                        "dave@outlook.com", "eve@yahoo.com"
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test19_FlattenJaggedArray() =>
        PynativeExerciseRunner.Run(19, "Flattening a 2D Array",
            "Flatten jagged int[][] array.",
            t => t.Add(("jagged matrix", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                    () => LinqExercises.FlattenJaggedArray(new[]
                    {
                        new[] { 1, 2, 3 }, new[] { 4, 5 }, new[] { 6, 7, 8, 9 }
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test20_ExtractFileExtensions() =>
        PynativeExerciseRunner.Run(20, "Extracting File Extensions",
            "Extract extensions including dot.",
            t => t.Add(("5 paths", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { ".txt", ".png", ".zip", ".txt", ".jpeg" },
                    () => LinqExercises.ExtractFileExtensions(new[]
                    {
                        "document.txt", "image.png", "archive.zip", "notes.txt", "photo.jpeg"
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test21_SumOfSquaresOfOddNumbers() =>
        PynativeExerciseRunner.Run(21, "Summing Squares of Odd Numbers",
            "Sum of squares of odd numbers.",
            t => t.Add(("1..10", () =>
                PynativeExerciseRunner.AssertEqual(165,
                    () => LinqExercises.SumOfSquaresOfOddNumbers(Enumerable.Range(1, 10))))));

    public static PynativeExerciseRunner.SuiteResult Test22_AverageBookPriceAfterYear() =>
        PynativeExerciseRunner.Run(22, "Averaging Prices with a Condition",
            "Average price of books after 2010.",
            t => t.Add(("5 books", () =>
                PynativeExerciseRunner.AssertEqual(42.33m,
                    () => Math.Round(LinqExercises.AverageBookPriceAfterYear(new[]
                    {
                        new LinqBook { Title = "Clean Code", Year = 2008, Price = 35m },
                        new LinqBook { Title = "Pragmatic", Year = 2019, Price = 40m },
                        new LinqBook { Title = "C# in Depth", Year = 2019, Price = 45m },
                        new LinqBook { Title = "Design Patterns", Year = 1994, Price = 50m },
                        new LinqBook { Title = "Refactoring", Year = 2018, Price = 42m },
                    }, 2010), 2)))));

    public static PynativeExerciseRunner.SuiteResult Test23_MinMaxProductPrice() =>
        PynativeExerciseRunner.Run(23, "Finding Min and Max Price",
            "Min and max product prices.",
            t => t.Add(("4 products", () =>
            {
                var (min, max) = LinqExercises.MinMaxProductPrice(new[]
                {
                    new LinqProduct { Name = "Laptop", Price = 999m },
                    new LinqProduct { Name = "Mouse", Price = 15m },
                    new LinqProduct { Name = "Monitor", Price = 250m },
                    new LinqProduct { Name = "Keyboard", Price = 45m },
                });
                PynativeExerciseRunner.PrintOutput($"Min={min}, Max={max}");
                PynativeExerciseRunner.AssertEqualSilent(15m, min);
                PynativeExerciseRunner.AssertEqualSilent(999m, max);
            })));

    public static PynativeExerciseRunner.SuiteResult Test24_CountSentencesContainingLinq() =>
        PynativeExerciseRunner.Run(24, "Counting Matching Elements",
            "Count sentences containing LINQ.",
            t => t.Add(("5 sentences", () =>
                PynativeExerciseRunner.AssertEqual(3,
                    () => LinqExercises.CountSentencesContainingLinq(new[]
                    {
                        "I love LINQ", "This has nothing", "LINQ is powerful",
                        "Another sentence", "LINQ makes life easier"
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test25_JoinWordsWithAggregate() =>
        PynativeExerciseRunner.Run(25, "Joining Words with Aggregate",
            "Comma-separated words via Aggregate.",
            t => t.Add(("4 words", () =>
                PynativeExerciseRunner.AssertEqual("apple, banana, cherry, date",
                    () => LinqExercises.JoinWordsWithAggregate(new[] { "apple", "banana", "cherry", "date" })))));

    public static PynativeExerciseRunner.SuiteResult Test26_Factorial() =>
        PynativeExerciseRunner.Run(26, "Calculating Factorial with LINQ",
            "Factorial using Range + Aggregate.",
            t => t.Add(("n=5 -> 120", () =>
                PynativeExerciseRunner.AssertEqual(120L, () => LinqExercises.Factorial(5)))));

    public static PynativeExerciseRunner.SuiteResult Test27_SumDepartmentSalaries() =>
        PynativeExerciseRunner.Run(27, "Summing Department Salaries",
            "Total Engineering department salary.",
            t => t.Add(("5 employees", () =>
                PynativeExerciseRunner.AssertEqual(25500m,
                    () => LinqExercises.SumDepartmentSalaries(new[]
                    {
                        new LinqSalaryEmployee { Name = "Alice", Department = "Engineering", Salary = 8500m },
                        new LinqSalaryEmployee { Name = "Bob", Department = "Sales", Salary = 6000m },
                        new LinqSalaryEmployee { Name = "Charlie", Department = "Engineering", Salary = 9200m },
                        new LinqSalaryEmployee { Name = "Dave", Department = "Marketing", Salary = 5500m },
                        new LinqSalaryEmployee { Name = "Eve", Department = "Engineering", Salary = 7800m },
                    }, "Engineering")))));

    public static PynativeExerciseRunner.SuiteResult Test28_CountVowels() =>
        PynativeExerciseRunner.Run(28, "Counting Vowels with LINQ",
            "Count vowels in text.",
            t => t.Add(("sample sentence", () =>
                PynativeExerciseRunner.AssertEqual(10,
                    () => LinqExercises.CountVowels("Programming in LINQ is enjoyable")))));

    public static PynativeExerciseRunner.SuiteResult Test29_ProductOfNonZeroNumbers() =>
        PynativeExerciseRunner.Run(29, "Multiplying Numbers with Aggregate",
            "Product of non-zero numbers.",
            t => t.Add(("with zeros", () =>
                PynativeExerciseRunner.AssertEqual(120L,
                    () => LinqExercises.ProductOfNonZeroNumbers(new[] { 2, 0, 3, 4, 0, 5 })))));

    public static PynativeExerciseRunner.SuiteResult Test30_LongestWord() =>
        PynativeExerciseRunner.Run(30, "Finding the Longest Word",
            "Longest word using MaxBy.",
            t => t.Add(("animal words", () =>
                PynativeExerciseRunner.AssertEqual("hippopotamus",
                    () => LinqExercises.LongestWord(new[] { "cat", "elephant", "dog", "hippopotamus", "ox" })))));

    public static PynativeExerciseRunner.SuiteResult Test31_GroupPeopleByAge() =>
        PynativeExerciseRunner.Run(31, "Grouping People by Age",
            "Group names by age.",
            t => t.Add(("5 people", () =>
            {
                var grouped = LinqExercises.GroupPeopleByAge(new[]
                {
                    new LinqPerson { Name = "Alice", Age = 30 },
                    new LinqPerson { Name = "Bob", Age = 25 },
                    new LinqPerson { Name = "Charlie", Age = 30 },
                    new LinqPerson { Name = "Dave", Age = 25 },
                    new LinqPerson { Name = "Eve", Age = 35 },
                });
                PynativeExerciseRunner.PrintOutput(
                    string.Join(" | ", grouped.Select(g => $"{g.Key}:[{string.Join(",", g.Value)}]")));
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "Alice", "Charlie" }, grouped[30]);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "Bob", "Dave" }, grouped[25]);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "Eve" }, grouped[35]);
            })));

    public static PynativeExerciseRunner.SuiteResult Test32_CountWordsByLength() =>
        PynativeExerciseRunner.Run(32, "Counting Words by Length",
            "Count words per length.",
            t => t.Add(("8 words", () =>
            {
                var counts = LinqExercises.CountWordsByLength(
                    new[] { "cat", "dog", "fish", "bird", "ant", "lion", "owl", "bee" });
                PynativeExerciseRunner.PrintOutput(counts);
                PynativeExerciseRunner.AssertEqualSilent(5, counts[3]);
                PynativeExerciseRunner.AssertEqualSilent(3, counts[4]);
            })));

    public static PynativeExerciseRunner.SuiteResult Test33_JoinStudentsAndCourses() =>
        PynativeExerciseRunner.Run(33, "Joining Students and Courses",
            "Inner join on StudentId.",
            t => t.Add(("students + courses", () =>
            {
                var rows = LinqExercises.JoinStudentsAndCourses(
                    new[]
                    {
                        new LinqStudent { StudentId = 1, Name = "Alice" },
                        new LinqStudent { StudentId = 2, Name = "Bob" },
                        new LinqStudent { StudentId = 3, Name = "Charlie" },
                    },
                    new[]
                    {
                        new LinqCourse { StudentId = 1, CourseName = "Math" },
                        new LinqCourse { StudentId = 1, CourseName = "Science" },
                        new LinqCourse { StudentId = 2, CourseName = "History" },
                        new LinqCourse { StudentId = 4, CourseName = "Art" },
                    });
                PynativeExerciseRunner.PrintOutput(
                    string.Join(", ", rows.Select(r => $"{r.StudentName}:{r.CourseName}")));
                PynativeExerciseRunner.AssertEqualSilent(3, rows.Count);
                PynativeExerciseRunner.AssertTrue(() => rows.Any(r => r.StudentName == "Alice" && r.CourseName == "Math"));
                PynativeExerciseRunner.AssertTrue(() => rows.Any(r => r.StudentName == "Bob" && r.CourseName == "History"));
            })));

    public static PynativeExerciseRunner.SuiteResult Test34_LeftJoinEmployeesDepartments() =>
        PynativeExerciseRunner.Run(34, "Left Joining Employees and Departments",
            "Left outer join; unmatched -> No Department.",
            t => t.Add(("3 employees", () =>
            {
                var rows = LinqExercises.LeftJoinEmployeesDepartments(
                    new[]
                    {
                        new LinqEmployeeWithDept { Id = 1, Name = "Alice", DepartmentId = 10 },
                        new LinqEmployeeWithDept { Id = 2, Name = "Bob", DepartmentId = 20 },
                        new LinqEmployeeWithDept { Id = 3, Name = "Charlie", DepartmentId = 0 },
                    },
                    new[]
                    {
                        new LinqDepartment { Id = 10, DepartmentName = "Engineering" },
                        new LinqDepartment { Id = 20, DepartmentName = "Sales" },
                    });
                PynativeExerciseRunner.PrintOutput(
                    string.Join(", ", rows.Select(r => $"{r.EmployeeName}:{r.DepartmentName}")));
                PynativeExerciseRunner.AssertTrue(
                    () => rows.Any(r => r.EmployeeName == "Charlie" && r.DepartmentName == "No Department"));
            })));

    public static PynativeExerciseRunner.SuiteResult Test35_CommonNumbers() =>
        PynativeExerciseRunner.Run(35, "Finding Common Numbers",
            "Intersect two lists.",
            t => t.Add(("listA & listB", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 4, 5, 6 },
                    () => LinqExercises.CommonNumbers(
                        new[] { 1, 2, 3, 4, 5, 6 },
                        new[] { 4, 5, 6, 7, 8, 9 })))));

    public static PynativeExerciseRunner.SuiteResult Test36_MissingProducts() =>
        PynativeExerciseRunner.Run(36, "Finding Missing Products",
            "Except: in A but not B.",
            t => t.Add(("inventories", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Apple", "Cherry", "Elderberry" },
                    () => LinqExercises.MissingProducts(
                        new[] { "Apple", "Banana", "Cherry", "Date", "Elderberry" },
                        new[] { "Banana", "Date", "Fig" })))));

    public static PynativeExerciseRunner.SuiteResult Test37_UnionNames() =>
        PynativeExerciseRunner.Run(37, "Combining Lists Without Duplicates",
            "Union two name lists.",
            t => t.Add(("two lists", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Alice", "Bob", "Charlie", "Dave", "Eve" },
                    () => LinqExercises.UnionNames(
                        new[] { "Alice", "Bob", "Charlie" },
                        new[] { "Bob", "Dave", "Alice", "Eve" })))));

    public static PynativeExerciseRunner.SuiteResult Test38_MostFrequentNumber() =>
        PynativeExerciseRunner.Run(38, "Finding the Most Frequent Number",
            "Most frequent integer via GroupBy.",
            t => t.Add(("array with 3 repeated", () =>
                PynativeExerciseRunner.AssertEqual(3,
                    () => LinqExercises.MostFrequentNumber(new[] { 1, 3, 2, 3, 4, 3, 2, 5, 3 })))));

    public static PynativeExerciseRunner.SuiteResult Test39_HighestPaidPerDepartment() =>
        PynativeExerciseRunner.Run(39, "Highest Paid Employee per Department",
            "MaxBy salary within each department group.",
            t => t.Add(("5 employees", () =>
            {
                var top = LinqExercises.HighestPaidPerDepartment(new[]
                {
                    new LinqEmployeeRecord { Name = "Alice", Department = "Engineering", Salary = 8500m },
                    new LinqEmployeeRecord { Name = "Bob", Department = "Sales", Salary = 6000m },
                    new LinqEmployeeRecord { Name = "Charlie", Department = "Engineering", Salary = 9200m },
                    new LinqEmployeeRecord { Name = "Dave", Department = "Sales", Salary = 7200m },
                    new LinqEmployeeRecord { Name = "Eve", Department = "Marketing", Salary = 5500m },
                });
                PynativeExerciseRunner.PrintOutput(
                    string.Join(", ", top.Select(e => $"{e.Department}:{e.Name}")));
                PynativeExerciseRunner.AssertTrue(() => top.Any(e => e.Department == "Engineering" && e.Name == "Charlie"));
                PynativeExerciseRunner.AssertTrue(() => top.Any(e => e.Department == "Sales" && e.Name == "Dave"));
                PynativeExerciseRunner.AssertTrue(() => top.Any(e => e.Department == "Marketing" && e.Name == "Eve"));
            })));

    public static PynativeExerciseRunner.SuiteResult Test40_ChunkNumbers() =>
        PynativeExerciseRunner.Run(40, "Splitting a List into Chunks",
            "Chunk list into groups of 5.",
            t => t.Add(("1..12 chunk 5", () =>
            {
                var chunks = LinqExercises.ChunkNumbers(Enumerable.Range(1, 12), 5);
                PynativeExerciseRunner.PrintOutput(
                    string.Join(" | ", chunks.Select(c => $"[{string.Join(",", c)}]")));
                PynativeExerciseRunner.AssertEqualSilent(3, chunks.Count);
                PynativeExerciseRunner.AssertSequenceEqual(Enumerable.Range(1, 5), chunks[0]);
                PynativeExerciseRunner.AssertSequenceEqual(Enumerable.Range(6, 5), chunks[1]);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { 11, 12 }, chunks[2]);
            })));
}
