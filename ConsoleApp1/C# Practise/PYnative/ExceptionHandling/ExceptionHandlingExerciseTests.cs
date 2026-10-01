using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.ExceptionHandling;

public static class ExceptionHandlingExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 17; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative - Exception Handling Exercises (17)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_DivideByZero(),
        2 => Test02_IndexOutOfRange(),
        3 => Test03_InvalidNumberFormat(),
        4 => Test04_NullReference(),
        5 => Test05_CatchAnyException(),
        6 => Test06_MultipleExceptionTypes(),
        7 => Test07_FinallyCleanup(),
        8 => Test08_ValidateAge(),
        9 => Test09_IntegerOverflow(),
        10 => Test10_MissingDictionaryKey(),
        11 => Test11_CustomException(),
        12 => Test12_WhenClause(),
        13 => Test13_InnerException(),
        14 => Test14_UsingStatement(),
        15 => Test15_InvalidCast(),
        16 => Test16_GlobalHandler(),
        17 => Test17_TryCatchVsTryParse(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Exception Handling exercises are numbered 1-17.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_DivideByZero() =>
        PynativeExerciseRunner.Run(1, "Handle a Divide by Zero Error",
            "Divide two integers and catch DivideByZeroException when the divisor is 0.",
            t => t.Add(("10 / 0 -> error", () =>
                PynativeExerciseRunner.AssertEqual(
                    "Error: Cannot divide by zero. Attempted to divide by zero.",
                    () => ExceptionHandlingExercises.Divide(10, 0)))));

    public static PynativeExerciseRunner.SuiteResult Test02_IndexOutOfRange() =>
        PynativeExerciseRunner.Run(2, "Handle an Out of Range Array Index",
            "Print a color by index and catch IndexOutOfRangeException for an index like 10.",
            t => t.Add(("index 10 -> error", () =>
                PynativeExerciseRunner.AssertEqual(
                    "Error: Index 10 is out of range. Index was outside the bounds of the array.",
                    () => ExceptionHandlingExercises.GetColor(
                        new[] { "Red", "Green", "Blue", "Yellow", "Purple" }, 10)))));

    public static PynativeExerciseRunner.SuiteResult Test03_InvalidNumberFormat() =>
        PynativeExerciseRunner.Run(3, "Handle an Invalid Number Format",
            "Parse an age with int.Parse and catch FormatException when the text is not a number.",
            t => t.Add(("\"twenty\" -> error", () =>
                PynativeExerciseRunner.AssertEqual(
                    "Error: \"twenty\" is not a valid number. The input string 'twenty' was not in a correct format.",
                    () => ExceptionHandlingExercises.ParseAge("twenty")))));

    public static PynativeExerciseRunner.SuiteResult Test04_NullReference() =>
        PynativeExerciseRunner.Run(4, "Handle a Null Reference Error",
            "Call ToUpper on a null string and catch NullReferenceException.",
            t => t.Add(("null -> error", () =>
                PynativeExerciseRunner.AssertEqual(
                    "Error: Cannot call a method on a null reference. Object reference not set to an instance of an object.",
                    () => ExceptionHandlingExercises.ToUpperName(null)))));

    public static PynativeExerciseRunner.SuiteResult Test05_CatchAnyException() =>
        PynativeExerciseRunner.Run(5, "Catch Any Exception with a Generic Handler",
            "Throw an exception chosen by number and log its runtime type and message from catch (Exception).",
            t => t.Add(("errorChoice 2 -> ArgumentException", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Caught Exception Type = ArgumentException",
                        "Message = Invalid argument provided."
                    },
                    () => ExceptionHandlingExercises.CatchAny(2)))));

    public static PynativeExerciseRunner.SuiteResult Test06_MultipleExceptionTypes() =>
        PynativeExerciseRunner.Run(6, "Handle Multiple Exception Types",
            "Open a file and parse its first line as an int, with catch blocks for FileNotFoundException, FormatException, and Exception.",
            t =>
            {
                t.Add(("missing data.txt -> file not found", () =>
                {
                    string path = Path.Combine(Path.GetTempPath(), "PynativeExceptionHandling", Guid.NewGuid().ToString("N"), "data.txt");
                    PynativeExerciseRunner.AssertEqual(
                        $"Error: File not found. Could not find file '{path}'.",
                        () => ExceptionHandlingExercises.ReadFirstLineAsInt(path));
                }));
                t.Add(("first line abc -> format error", () =>
                    WithTempDir(dir =>
                    {
                        string path = Path.Combine(dir, "data.txt");
                        File.WriteAllText(path, "abc");
                        PynativeExerciseRunner.AssertEqual(
                            "Error: File content is not a valid number. The input string 'abc' was not in a correct format.",
                            () => ExceptionHandlingExercises.ReadFirstLineAsInt(path));
                    })));
                t.Add(("first line 42 -> parsed", () =>
                    WithTempDir(dir =>
                    {
                        string path = Path.Combine(dir, "data.txt");
                        File.WriteAllText(path, "42");
                        PynativeExerciseRunner.AssertEqual(
                            "Parsed Value = 42",
                            () => ExceptionHandlingExercises.ReadFirstLineAsInt(path));
                    })));
            });

    public static PynativeExerciseRunner.SuiteResult Test07_FinallyCleanup() =>
        PynativeExerciseRunner.Run(7, "Guarantee Cleanup with Finally",
            "Write a file with StreamWriter and always close it from finally, even when writing succeeds.",
            t => t.Add(("output.txt -> written and closed", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "output.txt");
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "Data written successfully.", "Writer closed." },
                        () => ExceptionHandlingExercises.WriteWithFinally(path));
                    PynativeExerciseRunner.AssertEqualSilent(
                        "Writing data to the file.",
                        File.ReadAllText(path).TrimEnd('\r', '\n'));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test08_ValidateAge() =>
        PynativeExerciseRunner.Run(8, "Validate a Property with a Custom Exception",
            "Throw ArgumentOutOfRangeException from ExceptionPerson.Age when the age is outside 0 to 120.",
            t => t.Add(("age 150 -> error", () =>
                PynativeExerciseRunner.AssertEqual(
                    "Error: Age must be between 0 and 120. (Parameter 'value')",
                    () => ExceptionHandlingExercises.TryAssignAge(150)))));

    public static PynativeExerciseRunner.SuiteResult Test09_IntegerOverflow() =>
        PynativeExerciseRunner.Run(9, "Detect Integer Overflow",
            "Multiply inside a checked block and catch OverflowException.",
            t => t.Add(("int.MaxValue * 2 -> overflow", () =>
                PynativeExerciseRunner.AssertEqual(
                    "Error: Arithmetic operation overflowed. Arithmetic operation resulted in an overflow.",
                    () => ExceptionHandlingExercises.MultiplyChecked(int.MaxValue, 2)))));

    public static PynativeExerciseRunner.SuiteResult Test10_MissingDictionaryKey() =>
        PynativeExerciseRunner.Run(10, "Handle a Missing Dictionary Key",
            "Index a dictionary with a missing key and catch KeyNotFoundException, listing the available keys.",
            t => t.Add(("Webcam -> missing key", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Error: Key \"Webcam\" was not found. The given key 'Webcam' was not present in the dictionary.",
                        "Available Keys = Keyboard, Mouse, Monitor"
                    },
                    () => ExceptionHandlingExercises.LookupStock(new Dictionary<string, int>
                    {
                        ["Keyboard"] = 12,
                        ["Mouse"] = 30,
                        ["Monitor"] = 5
                    }, "Webcam")))));

    public static PynativeExerciseRunner.SuiteResult Test11_CustomException() =>
        PynativeExerciseRunner.Run(11, "Create a Custom Exception Type",
            "Throw ExceptionInsufficientFundsException when a withdrawal is larger than the balance.",
            t => t.Add(("balance 100 withdraw 250 -> error", () =>
                PynativeExerciseRunner.AssertEqual(
                    "Error: Cannot withdraw $250. Current balance is $100.",
                    () => ExceptionHandlingExercises.TryWithdraw(100m, 250m)))));

    public static PynativeExerciseRunner.SuiteResult Test12_WhenClause() =>
        PynativeExerciseRunner.Run(12, "Filter Exceptions with a When Clause",
            "Catch ExceptionHttpRequestFailedException with a when filter only when the error code is 404.",
            t =>
            {
                t.Add(("404 -> resource not found", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Error: Resource not found (404). The HTTP request failed.",
                        () => ExceptionHandlingExercises.HandleHttpFailure(404))));
                t.Add(("500 -> other code", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Error: Request failed with code 500. The HTTP request failed.",
                        () => ExceptionHandlingExercises.HandleHttpFailure(500))));
            });

    public static PynativeExerciseRunner.SuiteResult Test13_InnerException() =>
        PynativeExerciseRunner.Run(13, "Wrap and Preserve an Inner Exception",
            "Catch a simulated database failure and rethrow it as ApplicationException with the original as InnerException.",
            t => t.Add(("business layer -> outer and inner", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Outer Message = A business layer error occurred while accessing data.",
                        "Inner Message = Simulated database connection failure."
                    },
                    () => ExceptionHandlingExercises.CallBusinessLayer()))));

    public static PynativeExerciseRunner.SuiteResult Test14_UsingStatement() =>
        PynativeExerciseRunner.Run(14, "Refactor Cleanup Code with a Using Statement",
            "Write a log file with a using declaration so the writer is disposed without a manual finally block.",
            t => t.Add(("log.txt -> written and disposed", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "log.txt");
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "Log entry written successfully.", "Writer disposed automatically." },
                        () => ExceptionHandlingExercises.WriteWithUsing(path));
                    PynativeExerciseRunner.AssertEqualSilent(
                        "Application started.",
                        File.ReadAllText(path).TrimEnd('\r', '\n'));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test15_InvalidCast() =>
        PynativeExerciseRunner.Run(15, "Handle an Invalid Cast Safely",
            "Cast mixed list items to string and catch InvalidCastException so the loop continues.",
            t => t.Add(("Apple, 42, ExceptionProduct, Banana", () =>
            {
                string fullName = typeof(ExceptionProduct).FullName!;
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Valid String = Apple",
                        "Skipped Item: Cannot cast Int32 to string. Unable to cast object of type 'System.Int32' to type 'System.String'.",
                        $"Skipped Item: Cannot cast ExceptionProduct to string. Unable to cast object of type '{fullName}' to type 'System.String'.",
                        "Valid String = Banana"
                    },
                    () => ExceptionHandlingExercises.CastItemsToString(new object[]
                    {
                        "Apple",
                        42,
                        new ExceptionProduct { Name = "Chair" },
                        "Banana"
                    }));
            })));

    public static PynativeExerciseRunner.SuiteResult Test16_GlobalHandler() =>
        PynativeExerciseRunner.Run(16, "Catch Unhandled Exceptions Globally",
            "Log an exception that escapes local try-catch blocks, without terminating the process.",
            t => t.Add(("unhandled message -> two log lines", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Application starting.",
                        "Global Handler Caught: Something went wrong outside any try-catch block."
                    },
                    () => ExceptionHandlingExercises.DemonstrateGlobalHandler()))));

    public static PynativeExerciseRunner.SuiteResult Test17_TryCatchVsTryParse() =>
        PynativeExerciseRunner.Run(17, "Compare the Performance of Try-Catch vs TryParse",
            "Benchmark 10000 invalid parses with int.Parse in try-catch versus int.TryParse. Try-catch should be slower.",
            t => t.Add(("10000 x \"not-a-number\" -> try-catch slower", () =>
            {
                string[] inputs = Enumerable.Repeat("not-a-number", 10000).ToArray();
                var (tryCatchMs, tryParseMs) = ExceptionHandlingExercises.BenchmarkInvalidParse(inputs);
                PynativeExerciseRunner.PrintOutput($"try-catch={tryCatchMs} ms, TryParse={tryParseMs} ms");
                PynativeExerciseRunner.AssertTrue(
                    tryCatchMs > tryParseMs,
                    "Method A (try-catch) should take longer than Method B (TryParse).");
            })));

    private static void WithTempDir(Action<string> body)
    {
        string dir = Path.Combine(Path.GetTempPath(), "PynativeExceptionHandling", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(dir);
        try
        {
            body(dir);
        }
        finally
        {
            if (Directory.Exists(dir))
                Directory.Delete(dir, true);
        }
    }
}
