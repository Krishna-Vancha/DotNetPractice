using System;
using System.Collections.Generic;

namespace ConsoleApp1.C__Practise.PYnative.Linq;

/// <summary>
/// PYnative C# LINQ Exercises — https://pynative.com/csharp-linq-exercises/
/// </summary>
public static class LinqExercises
{
    // Question 1: Given a list of integers, return only the even numbers.
    public static IReadOnlyList<int> FilterEvenNumbers(IEnumerable<int> numbers)
    {
        List<int> list = numbers.Where(x => x %2 ==0).ToList();
        return list;
    }

    // Question 2: Find all words that have more than 5 characters.
    public static IReadOnlyList<string> FindLongWords(IEnumerable<string> words)
    {
        return words.Where(x => x.Length > 5).ToList();
    }

    // Question 3: Sort names in descending alphabetical order.
    public static IReadOnlyList<string> SortNamesDescending(IEnumerable<string> names)
    {
        return names.OrderByDescending(x => x).ToList();
    }
    // Question 4: Select the top 3 highest unique values from an integer array.
    public static IReadOnlyList<int> TopThreeUniqueNumbers(IEnumerable<int> numbers)
    {
        return numbers.Distinct().OrderByDescending(x => x).Take(3).ToList();   //Imp Prog Rem UNIQUE TOP VALUES
    }

    // Question 5: From 100 products named "Product 1".."Product 100", skip 20 and take the next 10.
    public static IReadOnlyList<string> PaginateProducts(int skip, int take)
    { 
        return Enumerable.Range(1,100).Select(x=>$"Product {x}").Skip(20).Take(10).ToList();
    }

    // Question 6: Find fruits that start with 'A' (case-insensitive).
    public static IReadOnlyList<string> FruitsStartingWithA(IEnumerable<string> fruits)
    {
        return fruits.Where(x => x.StartsWith("A",StringComparison.OrdinalIgnoreCase)).ToList();  //Imp Prog Rem StringComparision.OrdinalIgnoreCase()
    }

    // Question 7: Find ages between 25 and 35 inclusive.
    public static IReadOnlyList<int> AgesInRange(IEnumerable<int> ages, int min, int max)
    {
        return ages.Where(x => (x >= 25 && x <= 35)).ToList();
    }

    // Question 8: Return squares of each integer in the list.
    public static IReadOnlyList<int> SquareNumbers(IEnumerable<int> numbers)
    {
        return numbers.Select(x => x * x).ToList();
    }

    // Question 9: Find first number divisible by 7, or default 0 if none.
    public static int FirstDivisibleBySeven(IEnumerable<int> numbers)
    {
        return numbers.FirstOrDefault(x => (x % 7 == 0));
    }

    // Question 10: Find last word ending with 'e', or null if none.
    public static string? LastWordEndingWithE(IEnumerable<string> words)
    {
        return words.LastOrDefault(x=>x.EndsWith("e",StringComparison.OrdinalIgnoreCase));   //Imp Prog Rem spelling StringComparision.OrdinalIgnoreCase()
    }

    // Question 11: Convert strings to uppercase.
    public static IReadOnlyList<string> ToUppercase(IEnumerable<string> words)
    { 
        return words.Select(x=>x.ToUpper()).ToList();        //Imp Prog Rem string conversion of upper and lower in linqs
    }

    // Question 12: Project user emails from a list of User objects.
    public static IReadOnlyList<string> ExtractEmails(IEnumerable<LinqUser> users)
    {
        return users.Select(x => x.Email).ToList();
    }

    // Question 13: Project products to name + tax (Price * 0.15).
    public static IReadOnlyList<LinqProductTax> CalculateProductTaxes(IEnumerable<LinqProduct> products)
    {
        return products.Select(x=>new LinqProductTax{ ProductName=x.Name, CalculatedTax= (x.Price * 0.15m)}).ToList();   //Imp Prog Rem How to get decimal output , how to return a intialized object
    }

    // Question 14: Flatten all employee names from departments using SelectMany.
    public static IReadOnlyList<string> FlattenDepartmentEmployees(IEnumerable<LinqDepartmentWithEmployees> departments)
    {
        return departments.SelectMany(x => x.EmployeeNames).ToList();     //Imp Prog Rem  what is SelectMany , what goes inside its function and what it returns
    }

    // Question 15: Extract unique characters from a sentence (no spaces), sorted alphabetically.
    public static IReadOnlyList<char> UniqueCharactersSorted(string sentence)
    {
        return sentence.Where(c=>c!=' ').Distinct().OrderBy(x=>x).ToList();
    }

    // Question 16: Project each item with its index: "Index: {i}, Value: {value}".
    public static IReadOnlyList<string> ProjectWithIndex(IEnumerable<string> items)
    {
        return items.Select((i, value) => $"Index: {value}, Value: {i}").ToList();
    }

    // Question 17: Zip first and last names into "First Last" full names.
    public static IReadOnlyList<string> ZipFullNames(IEnumerable<string> firstNames, IEnumerable<string> lastNames)
    { 
        return firstNames.Zip(lastNames, (first,last) =>$"{first} {last}").ToList(); //Imp Prog Rem what is ZIP
    }

    // Question 18: Extract unique email domains from email addresses.
    public static IReadOnlyList<string> UniqueEmailDomains(IEnumerable<string> emails)
    {
        return emails.Select(x=>x.Substring(x.IndexOf("@")+1)).Distinct().ToList();  //Imp Prog Rem Distinct() should be usedd sfter select or where
    }

    // Question 19: Flatten a jagged 2D int array into 1D sequence.
    public static IReadOnlyList<int> FlattenJaggedArray(IEnumerable<int[]> matrix)
    {
        return matrix.SelectMany(x => x).ToList(); //Imp Prog Rem how to traverse in 2d matrix in linq
    }

    // Question 20: Extract file extensions from file paths (include the dot).
    public static IReadOnlyList<string> ExtractFileExtensions(IEnumerable<string> filePaths)
    {
        return filePaths.Select(x => x.Substring(x.IndexOf("."))).ToList();
    }

    // Question 21: Sum of squares of all odd numbers in a list.
    public static int SumOfSquaresOfOddNumbers(IEnumerable<int> numbers)
    {
        return numbers.Where(x => x % 2 == 1).Sum(x => x * x);
            }

    // Question 22: Average price of books published after the given year.
    public static decimal AverageBookPriceAfterYear(IEnumerable<LinqBook> books, int year)
    {
        return books.Where(x => x.Year > year).Average(x => (x.Price));    
            }

    // Question 23: Find minimum and maximum product prices.
    public static (decimal MinPrice, decimal MaxPrice) MinMaxProductPrice(IEnumerable<LinqProduct> products)
        => (products.Min(x => x.Price), products.Max(x => x.Price));

    // Question 24: Count sentences containing the word "LINQ".
    public static int CountSentencesContainingLinq(IEnumerable<string> sentences)
        => sentences.Count(x => x.Contains("LINQ"));

    // Question 25: Join words with ", " using Aggregate (no trailing comma).
    public static string JoinWordsWithAggregate(IEnumerable<string> words)
        => words.Aggregate((current, next) => current + ", " + next);  //Imp Prog Rem Aggregate folds left to right; the separator is only inserted between items, so there is no trailing comma

    // Question 26: Calculate factorial of n using Enumerable.Range and Aggregate.
    public static long Factorial(int n)
        => Enumerable.Range(1, n).Aggregate((current, next) => current*next);  //Imp Prog Rem seeded Aggregate: the seed (1L) is the starting value and also fixes the result type as long

    // Question 27: Sum salaries for employees in the given department.
    public static decimal SumDepartmentSalaries(IEnumerable<LinqSalaryEmployee> employees, string department)
        => employees.Where(x => x.Department == department).Sum(x => x.Salary);

    // Question 28: Count vowels (a,e,i,o,u) in text using LINQ.
    public static int CountVowels(string text)
        => text.Count(x => "aeiouAEIOU".Contains(x));

    // Question 29: Product of all non-zero numbers using Aggregate.
    public static long ProductOfNonZeroNumbers(IEnumerable<int> numbers)
        => numbers.Where(n => n != 0).Aggregate((x, y) => x * y);

    // Question 30: Find longest word using MaxBy on Length.
    public static string LongestWord(IEnumerable<string> words)
        => words.MaxBy(x => x.Length);

    // Question 31: Group people by age; return age -> list of names.
    public static IReadOnlyDictionary<int, IReadOnlyList<string>> GroupPeopleByAge(IEnumerable<LinqPerson> people)
    => throw new NotImplementedException();
    //    => people.GroupBy(x=>x.Key).ToDictionary(g=>g.Key,g=>)

    // Question 32: Group words by length; return length -> count of words.
    public static IReadOnlyDictionary<int, int> CountWordsByLength(IEnumerable<string> words)
        => words.GroupBy(x => x.Length).ToDictionary(x => x.Key, x => x.Count());

    // Question 33: Inner join students and courses on StudentId.
    public static IReadOnlyList<LinqStudentCourseRow> JoinStudentsAndCourses(
        IEnumerable<LinqStudent> students, IEnumerable<LinqCourse> courses)
         => throw new NotImplementedException();

    // Question 34: Left outer join employees to departments (unmatched -> "No Department").
    public static IReadOnlyList<LinqEmployeeDepartmentRow> LeftJoinEmployeesDepartments(
        IEnumerable<LinqEmployeeWithDept> employees, IEnumerable<LinqDepartment> departments)
        => throw new NotImplementedException();

    // Question 35: Numbers present in both lists (Intersect).
    public static IReadOnlyList<int> CommonNumbers(IEnumerable<int> listA, IEnumerable<int> listB)
        => throw new NotImplementedException();

    // Question 36: Items in inventoryA missing from inventoryB (Except).
    public static IReadOnlyList<string> MissingProducts(IEnumerable<string> inventoryA, IEnumerable<string> inventoryB)
        => throw new NotImplementedException();

    // Question 37: Union of two name lists without duplicates.
    public static IReadOnlyList<string> UnionNames(IEnumerable<string> listA, IEnumerable<string> listB)
        => throw new NotImplementedException();

    // Question 38: Most frequently occurring integer in an array.
    public static int MostFrequentNumber(IEnumerable<int> numbers)
        => throw new NotImplementedException();

    // Question 39: Highest-paid employee in each department (MaxBy per group).
    public static IReadOnlyList<LinqEmployeeRecord> HighestPaidPerDepartment(IEnumerable<LinqEmployeeRecord> employees)
        => throw new NotImplementedException();

    // Question 40: Split integers into chunks of the given size using Chunk().
    public static IReadOnlyList<int[]> ChunkNumbers(IEnumerable<int> numbers, int chunkSize)
        => throw new NotImplementedException();
}
