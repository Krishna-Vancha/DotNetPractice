using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ConsoleApp1.C__Practise.PYnative.Lambda;

public static class LambdaExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 20; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative - Lambda Expressions Exercises (20)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_SquareANumber(),
        2 => Test02_CheckForEvenNumber(),
        3 => Test03_StringLengthChecker(),
        4 => Test04_PrintMessageWithLogPrefix(),
        5 => Test05_ConcatenateTwoStrings(),
        6 => Test06_FilterOddNumbers(),
        7 => Test07_TransformStringsToUppercase(),
        8 => Test08_FindFirstProductOver100(),
        9 => Test09_SortStringsByLength(),
        10 => Test10_ExtractEmails(),
        11 => Test11_CheckAnyCondition(),
        12 => Test12_CountSpecificElements(),
        13 => Test13_CustomObjectTransformation(),
        14 => Test14_GroupByFirstLetter(),
        15 => Test15_ConditionalAggregation(),
        16 => Test16_InlineMultiStatementLambda(),
        17 => Test17_DictionaryFiltering(),
        18 => Test18_InlineEventSubscription(),
        19 => Test19_ClosureAndCapturedVariables(),
        20 => Test20_InspectExpressionTree(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Lambda exercises are numbered 1-20.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_SquareANumber() =>
        PynativeExerciseRunner.Run(1, "Square a Number",
            "Write a lambda expression assigned to a Func<int, int> that takes an integer and returns its square.",
            t => t.Add(("number = 6 -> Square = 36", () =>
                PynativeExerciseRunner.AssertEqual(36,
                    () => LambdaExercises.CreateSquareFunc()(6)))));

    public static PynativeExerciseRunner.SuiteResult Test02_CheckForEvenNumber() =>
        PynativeExerciseRunner.Run(2, "Check for Even Number",
            "Create a Func<int, bool> lambda that returns true if a given number is even, and false if it is odd.",
            t => t.Add(("number = 15 -> Is Even = False", () =>
                PynativeExerciseRunner.AssertFalse(
                    () => LambdaExercises.CreateIsEvenFunc()(15)))));

    public static PynativeExerciseRunner.SuiteResult Test03_StringLengthChecker() =>
        PynativeExerciseRunner.Run(3, "String Length Checker",
            "Write a lambda that takes a string and an integer, returning true if the string length is greater than the integer.",
            t => t.Add(("word = \"Programming\", minLength = 5 -> True", () =>
                PynativeExerciseRunner.AssertTrue(
                    () => LambdaExercises.CreateIsLongerThanFunc()("Programming", 5)))));

    public static PynativeExerciseRunner.SuiteResult Test04_PrintMessageWithLogPrefix() =>
        PynativeExerciseRunner.Run(4, "Print Message with Log Prefix",
            "Create an Action<string> lambda that prepends \"[Log]: \" to a string and prints it to the console.",
            t => t.Add(("message = \"Application started successfully.\" -> [Log]: ...", () =>
            {
                Action<string> log = LambdaExercises.CreateLogAction();
                string[] lines = PynativeConsole.CaptureLines(() => log("Application started successfully."));
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "[Log]: Application started successfully." },
                    lines);
            })));

    public static PynativeExerciseRunner.SuiteResult Test05_ConcatenateTwoStrings() =>
        PynativeExerciseRunner.Run(5, "Concatenate Two Strings",
            "Write a lambda assigned to Func<string, string, string> that joins two strings with a space in between.",
            t => t.Add(("firstName = \"John\", lastName = \"Smith\" -> John Smith", () =>
                PynativeExerciseRunner.AssertEqual("John Smith",
                    () => LambdaExercises.CreateFullNameFunc()("John", "Smith")))));

    public static PynativeExerciseRunner.SuiteResult Test06_FilterOddNumbers() =>
        PynativeExerciseRunner.Run(6, "Filter Odd Numbers from a List",
            "Given a List<int>, use Where() with a lambda expression to filter out all odd numbers.",
            t => t.Add(("1..10 -> 1, 3, 5, 7, 9", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 3, 5, 7, 9 },
                    () => LambdaExercises.FilterOddNumbers(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })))));

    public static PynativeExerciseRunner.SuiteResult Test07_TransformStringsToUppercase() =>
        PynativeExerciseRunner.Run(7, "Transform Strings to Uppercase",
            "Given a List<string>, use Select() with a lambda to convert all strings in the list to uppercase.",
            t => t.Add(("apple, banana, cherry -> APPLE, BANANA, CHERRY", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "APPLE", "BANANA", "CHERRY" },
                    () => LambdaExercises.ToUppercase(new[] { "apple", "banana", "cherry" })))));

    public static PynativeExerciseRunner.SuiteResult Test08_FindFirstProductOver100() =>
        PynativeExerciseRunner.Run(8, "Find First Product Over $100",
            "Given a list of Product objects (Name and Price), use FirstOrDefault() with a lambda to find the first product that costs more than $100.",
            t => t.Add(("prices 45.50, 199.99, 25.00, 899.00 -> Monitor 199.99", () =>
            {
                LambdaProduct? product = LambdaExercises.FindFirstProductOver(new[]
                {
                    new LambdaProduct { Name = "Keyboard", Price = 45.50 },
                    new LambdaProduct { Name = "Monitor", Price = 199.99 },
                    new LambdaProduct { Name = "Mouse", Price = 25.00 },
                    new LambdaProduct { Name = "Laptop", Price = 899.00 }
                }, 100);
                PynativeExerciseRunner.PrintOutput(product is null ? "null" : $"{product.Name} = {product.Price}");
                PynativeExerciseRunner.AssertEqualSilent("Monitor", product!.Name);
                PynativeExerciseRunner.AssertEqualSilent(199.99, product.Price);
            })));

    public static PynativeExerciseRunner.SuiteResult Test09_SortStringsByLength() =>
        PynativeExerciseRunner.Run(9, "Sort Strings by Length",
            "Given a list of strings, use OrderBy() with a lambda to sort the list by the length of the strings.",
            t => t.Add(("kiwi, banana, fig, watermelon, pear -> fig, kiwi, pear, banana, watermelon", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "fig", "kiwi", "pear", "banana", "watermelon" },
                    () => LambdaExercises.SortByLength(new[] { "kiwi", "banana", "fig", "watermelon", "pear" })))));

    public static PynativeExerciseRunner.SuiteResult Test10_ExtractEmails() =>
        PynativeExerciseRunner.Run(10, "Extract Emails from a User List",
            "Given a list of users (Id, Username, Email), use Select() to extract a list of just the Email strings.",
            t => t.Add(("alice, bob, carol -> three emails", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "alice@example.com", "bob@example.com", "carol@example.com" },
                    () => LambdaExercises.ExtractEmails(new[]
                    {
                        new LambdaUser { Id = 1, Username = "alice", Email = "alice@example.com" },
                        new LambdaUser { Id = 2, Username = "bob", Email = "bob@example.com" },
                        new LambdaUser { Id = 3, Username = "carol", Email = "carol@example.com" }
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test11_CheckAnyCondition() =>
        PynativeExerciseRunner.Run(11, "Check Any Condition",
            "Given a list of integers, use Any() with a lambda to check if the list contains any negative numbers.",
            t => t.Add(("4, 8, -3, 15, 22, -7 -> Has Negative Number = True", () =>
                PynativeExerciseRunner.AssertTrue(
                    () => LambdaExercises.HasNegativeNumber(new[] { 4, 8, -3, 15, 22, -7 })))));

    public static PynativeExerciseRunner.SuiteResult Test12_CountSpecificElements() =>
        PynativeExerciseRunner.Run(12, "Count Specific Elements",
            "Given a list of strings, use Count() with a lambda to count how many strings start with the letter 'A'.",
            t => t.Add(("Alice, Bob, Amanda, Charlie, Andrew -> 3", () =>
                PynativeExerciseRunner.AssertEqual(3,
                    () => LambdaExercises.CountStartingWithA(new[] { "Alice", "Bob", "Amanda", "Charlie", "Andrew" })))));

    public static PynativeExerciseRunner.SuiteResult Test13_CustomObjectTransformation() =>
        PynativeExerciseRunner.Run(13, "Custom Object Transformation",
            "Project employees into FullName and IsSenior (true if YearsOfExperience > 5).",
            t => t.Add(("experience 3, 8, 6 -> Sara False, Tom True, Nina True", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Sara Khan - Senior: False",
                        "Tom Reed - Senior: True",
                        "Nina Patel - Senior: True"
                    },
                    () => LambdaExercises.SummarizeEmployees(new[]
                    {
                        new LambdaEmployee { FirstName = "Sara", LastName = "Khan", YearsOfExperience = 3 },
                        new LambdaEmployee { FirstName = "Tom", LastName = "Reed", YearsOfExperience = 8 },
                        new LambdaEmployee { FirstName = "Nina", LastName = "Patel", YearsOfExperience = 6 }
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test14_GroupByFirstLetter() =>
        PynativeExerciseRunner.Run(14, "Group by First Letter",
            "Given a list of words, use GroupBy() with a lambda to group the words by their first letter, then print the groups.",
            t => t.Add(("apple, avocado, banana, blueberry, cherry", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "a: apple, avocado",
                        "b: banana, blueberry",
                        "c: cherry"
                    },
                    () => LambdaExercises.GroupByFirstLetter(new[] { "apple", "avocado", "banana", "blueberry", "cherry" })))));

    public static PynativeExerciseRunner.SuiteResult Test15_ConditionalAggregation() =>
        PynativeExerciseRunner.Run(15, "Conditional Aggregation",
            "Given orders with Amount and IsPaid, use Sum() with a lambda to total revenue from paid orders only.",
            t => t.Add(("paid 120.50 and 200.00 -> Total Paid Revenue = 320.5", () =>
                PynativeExerciseRunner.AssertEqual(320.5,
                    () => Math.Round(LambdaExercises.SumPaidRevenue(new[]
                    {
                        new LambdaOrder { Amount = 120.50, IsPaid = true },
                        new LambdaOrder { Amount = 75.00, IsPaid = false },
                        new LambdaOrder { Amount = 200.00, IsPaid = true },
                        new LambdaOrder { Amount = 40.25, IsPaid = false }
                    }), 1)))));

    public static PynativeExerciseRunner.SuiteResult Test16_InlineMultiStatementLambda() =>
        PynativeExerciseRunner.Run(16, "Inline Multi-statement Lambda",
            "Write a Func<int, int, int> statement lambda that logs the larger number, then returns the absolute difference.",
            t => t.Add(("first = 18, second = 42 -> larger 42, difference 24", () =>
            {
                Func<int, int, int> compare = LambdaExercises.CreateCompareAndDiffFunc();
                int difference = 0;
                string[] lines = PynativeConsole.CaptureLines(() => difference = compare(18, 42));
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "Larger Number = 42" }, lines);
                PynativeExerciseRunner.AssertEqualSilent(24, difference);
            })));

    public static PynativeExerciseRunner.SuiteResult Test17_DictionaryFiltering() =>
        PynativeExerciseRunner.Run(17, "Dictionary Filtering",
            "Given a Dictionary<string, int> of stock counts, use Where() and a lambda to filter out items with count == 0.",
            t => t.Add(("Keyboard 12, Mouse 0, Monitor 5, Webcam 0 -> Keyboard and Monitor", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Keyboard: 12", "Monitor: 5" },
                    () => LambdaExercises.FilterInStock(new Dictionary<string, int>
                    {
                        ["Keyboard"] = 12,
                        ["Mouse"] = 0,
                        ["Monitor"] = 5,
                        ["Webcam"] = 0
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test18_InlineEventSubscription() =>
        PynativeExerciseRunner.Run(18, "Inline Event Subscription",
            "Subscribe a lambda to a ThresholdReached event and print a message when temperature 105 fires it.",
            t => t.Add(("temperature = 105 -> Warning: Temperature threshold reached!", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Warning: Temperature threshold reached!" },
                    () => PynativeConsole.CaptureLines(LambdaExercises.RunExercise18)))));

    public static PynativeExerciseRunner.SuiteResult Test19_ClosureAndCapturedVariables() =>
        PynativeExerciseRunner.Run(19, "Closure and Captured Variables",
            "Return a Func<int, int> that multiplies by a captured factor. Reassigning the caller's factor must not change the lambda.",
            t => t.Add(("factor = 3, then 10; 5 * captured factor stays 15", () =>
            {
                int factor = 3;
                Func<int, int> multiply = LambdaExercises.CreateMultiplier(factor);
                PynativeExerciseRunner.AssertEqualSilent(15, multiply(5));
                factor = 10;
                PynativeExerciseRunner.AssertEqualSilent(15, multiply(5));
            })));

    public static PynativeExerciseRunner.SuiteResult Test20_InspectExpressionTree() =>
        PynativeExerciseRunner.Run(20, "Inspect an Expression Tree",
            "Assign number => number > 5 to Expression<Func<int, bool>> and inspect the body node types.",
            t => t.Add(("number => number > 5 -> GreaterThan, Parameter, Constant", () =>
            {
                Expression<Func<int, bool>> expr = LambdaExercises.CreateGreaterThanFiveExpression();
                PynativeExerciseRunner.PrintOutput(expr);
                PynativeExerciseRunner.AssertEqualSilent("number => (number > 5)", expr.ToString());
                var body = (BinaryExpression)expr.Body;
                PynativeExerciseRunner.AssertEqualSilent(ExpressionType.GreaterThan, body.NodeType);
                PynativeExerciseRunner.AssertEqualSilent(ExpressionType.Parameter, body.Left.NodeType);
                PynativeExerciseRunner.AssertEqualSilent(ExpressionType.Constant, body.Right.NodeType);
            })));
}
