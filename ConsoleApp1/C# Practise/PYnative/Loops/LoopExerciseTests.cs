using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.Loops;

public static class LoopExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 31; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative - Loops Exercises (31)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_PrintOneToTen(),
        2 => Test02_PrintCountdown(),
        3 => Test03_PrintEvenNumbers(),
        4 => Test04_PrintOddNumbers(),
        5 => Test05_PrintSumOfFirstN(),
        6 => Test06_PrintMultiplicationTable(),
        7 => Test07_PrintFactorial(),
        8 => Test08_PrintSumOfDigits(),
        9 => Test09_PrintDigitCount(),
        10 => Test10_PrintAverage(),
        11 => Test11_PrintPalindromeCheck(),
        12 => Test12_PrintDoubledValues(),
        13 => Test13_PlayGuessingGame(),
        14 => Test14_PrintArmstrongCheck(),
        15 => Test15_PrintAsciiTable(),
        16 => Test16_PrintRightTriangle(),
        17 => Test17_PrintPyramid(),
        18 => Test18_PrintNumberPattern(),
        19 => Test19_PrintFloydsTriangle(),
        20 => Test20_PrintPerfectNumbers(),
        21 => Test21_PrintFibonacci(),
        22 => Test22_PrintReversedString(),
        23 => Test23_PrintPrimeCheck(),
        24 => Test24_PrintPrimesInRange(),
        25 => Test25_PrintPower(),
        26 => Test26_PrintVowelAndConsonantCounts(),
        27 => Test27_PrintLcm(),
        28 => Test28_PrintGcd(),
        29 => Test29_PrintBinaryToDecimal(),
        30 => Test30_PrintDecimalToBinary(),
        31 => Test31_PrintDiagonalSum(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Loop exercises are numbered 1-31.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_PrintOneToTen() =>
        PynativeExerciseRunner.Run(1, "Print 1 to 10",
            "Print numbers from 1 to 10 using a for loop.",
            t => t.Add(("1 to 10", () =>
            {
                var expected = new List<string> { "Starting sequence from 1 to 10:" };
                expected.AddRange(Enumerable.Range(1, 10).Select(i => $"Current Value: {i}"));
                expected.Add("Number printing completed successfully.");
                PynativeExerciseRunner.AssertSequenceEqual(expected,
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintOneToTen()));
            })));

    public static PynativeExerciseRunner.SuiteResult Test02_PrintCountdown() =>
        PynativeExerciseRunner.Run(2, "Countdown",
            "Print numbers from 10 down to 1 using a while loop.",
            t => t.Add(("10 down to 1", () =>
            {
                var expected = new List<string> { "Starting countdown from 10 to 1:" };
                expected.AddRange(Enumerable.Range(0, 10).Select(i => $"Current Value: {10 - i}"));
                expected.Add("Countdown completed successfully.");
                PynativeExerciseRunner.AssertSequenceEqual(expected,
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintCountdown()));
            })));

    public static PynativeExerciseRunner.SuiteResult Test03_PrintEvenNumbers() =>
        PynativeExerciseRunner.Run(3, "Even Numbers",
            "Display all even numbers between 1 and 20.",
            t => t.Add(("1 to 20", () =>
            {
                var expected = new List<string> { "Finding even numbers between 1 and 20:" };
                expected.AddRange(Enumerable.Range(1, 10).Select(i => $"Even Number: {i * 2}"));
                expected.Add("Even number search completed successfully.");
                PynativeExerciseRunner.AssertSequenceEqual(expected,
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintEvenNumbers(1, 20)));
            })));

    public static PynativeExerciseRunner.SuiteResult Test04_PrintOddNumbers() =>
        PynativeExerciseRunner.Run(4, "Odd Numbers",
            "Display all odd numbers between 1 and 20.",
            t => t.Add(("1 to 20", () =>
            {
                var expected = new List<string> { "Finding odd numbers between 1 and 20:" };
                expected.AddRange(Enumerable.Range(0, 10).Select(i => $"Odd Number: {i * 2 + 1}"));
                expected.Add("Odd number search completed successfully.");
                PynativeExerciseRunner.AssertSequenceEqual(expected,
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintOddNumbers(1, 20)));
            })));

    public static PynativeExerciseRunner.SuiteResult Test05_PrintSumOfFirstN() =>
        PynativeExerciseRunner.Run(5, "Sum of First N Numbers",
            "Calculate the sum of all numbers from 1 to N.",
            t => t.Add(("n = 10 -> Sum = 55", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Calculating sum of first 10 numbers:",
                        "Sum = 55",
                        "Calculation completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintSumOfFirstN(10))))));

    public static PynativeExerciseRunner.SuiteResult Test06_PrintMultiplicationTable() =>
        PynativeExerciseRunner.Run(6, "Multiplication Table",
            "Print the multiplication table of a number up to 10.",
            t => t.Add(("num = 5", () =>
            {
                var expected = new List<string> { "Generating multiplication table for 5:" };
                expected.AddRange(Enumerable.Range(1, 10).Select(i => $"5 x {i} = {5 * i}"));
                expected.Add("Table generation completed successfully.");
                PynativeExerciseRunner.AssertSequenceEqual(expected,
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintMultiplicationTable(5)));
            })));

    public static PynativeExerciseRunner.SuiteResult Test07_PrintFactorial() =>
        PynativeExerciseRunner.Run(7, "Factorial Calculator",
            "Find the factorial of a number using a loop.",
            t => t.Add(("num = 5 -> Factorial = 120", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Calculating factorial of 5:",
                        "Factorial = 120",
                        "Calculation completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintFactorial(5))))));

    public static PynativeExerciseRunner.SuiteResult Test08_PrintSumOfDigits() =>
        PynativeExerciseRunner.Run(8, "Sum of Digits",
            "Calculate the sum of the digits of an integer.",
            t => t.Add(("123 -> 6", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Calculating sum of digits for 123:",
                        "Sum of digits = 6",
                        "Calculation completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintSumOfDigits(123))))));

    public static PynativeExerciseRunner.SuiteResult Test09_PrintDigitCount() =>
        PynativeExerciseRunner.Run(9, "Count Digits",
            "Count how many digits are in a given number.",
            t => t.Add(("45678 -> 5", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Counting digits in 45678:",
                        "Number of digits = 5",
                        "Counting completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintDigitCount(45678))))));

    public static PynativeExerciseRunner.SuiteResult Test10_PrintAverage() =>
        PynativeExerciseRunner.Run(10, "Average of Numbers",
            "Calculate and display the average of a set of 5 numbers.",
            t => t.Add(("{10, 20, 30, 40, 50} -> 30", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Calculating average of the given numbers:",
                        "Average = 30",
                        "Calculation completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() =>
                        LoopExercises.PrintAverage(new[] { 10, 20, 30, 40, 50 }))))));

    public static PynativeExerciseRunner.SuiteResult Test11_PrintPalindromeCheck() =>
        PynativeExerciseRunner.Run(11, "Palindrome Checker",
            "Check if a given string reads the same backward as forward.",
            t => t.Add(("radar", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Checking if \"radar\" is a palindrome:",
                        "Result: \"radar\" is a palindrome.",
                        "Palindrome check completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintPalindromeCheck("radar"))))));

    public static PynativeExerciseRunner.SuiteResult Test12_PrintDoubledValues() =>
        PynativeExerciseRunner.Run(12, "Array Traversal",
            "Print each element of a 5-integer array multiplied by 2.",
            t => t.Add(("{1, 2, 3, 4, 5}", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Traversing array and doubling each value:",
                        "1 x 2 = 2",
                        "2 x 2 = 4",
                        "3 x 2 = 6",
                        "4 x 2 = 8",
                        "5 x 2 = 10",
                        "Array traversal completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() =>
                        LoopExercises.PrintDoubledValues(new[] { 1, 2, 3, 4, 5 }))))));

    public static PynativeExerciseRunner.SuiteResult Test13_PlayGuessingGame() =>
        PynativeExerciseRunner.Run(13, "Number Guessing Game",
            "Compare guesses to a target between 1 and 100 and print too high, too low, or correct.",
            t => t.Add(("target 42, guesses 25, 60, 45, 40, 42", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Starting number guessing game. Target is between 1 and 100:",
                        "Guess: 25",
                        "Hint: Too Low",
                        "Guess: 60",
                        "Hint: Too High",
                        "Guess: 45",
                        "Hint: Too High",
                        "Guess: 40",
                        "Hint: Too Low",
                        "Guess: 42",
                        "Correct! You guessed the number.",
                        "Number guessing game completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() =>
                        LoopExercises.PlayGuessingGame(42, new[] { 25, 60, 45, 40, 42 }))))));

    public static PynativeExerciseRunner.SuiteResult Test14_PrintArmstrongCheck() =>
        PynativeExerciseRunner.Run(14, "Armstrong Number",
            "Check if a 3-digit number is an Armstrong number.",
            t => t.Add(("153", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Checking if 153 is an Armstrong number:",
                        "Result: 153 is an Armstrong number.",
                        "Armstrong number check completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintArmstrongCheck(153))))));

    public static PynativeExerciseRunner.SuiteResult Test15_PrintAsciiTable() =>
        PynativeExerciseRunner.Run(15, "ASCII Table",
            "Print uppercase letters A-Z alongside their ASCII values.",
            t => t.Add(("A to Z", () =>
            {
                var expected = new List<string> { "Printing uppercase letters with their ASCII values:" };
                for (char c = 'A'; c <= 'Z'; c++)
                    expected.Add($"{c} = {(int)c}");
                expected.Add("ASCII table printing completed successfully.");
                PynativeExerciseRunner.AssertSequenceEqual(expected,
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintAsciiTable()));
            })));

    public static PynativeExerciseRunner.SuiteResult Test16_PrintRightTriangle() =>
        PynativeExerciseRunner.Run(16, "Right-Angled Triangle Pattern",
            "Print a right-angled triangle pattern of asterisks.",
            t => t.Add(("rows = 5", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Printing right-angled triangle pattern:",
                        "*",
                        "**",
                        "***",
                        "****",
                        "*****",
                        "Pattern printing completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintRightTriangle(5))))));

    public static PynativeExerciseRunner.SuiteResult Test17_PrintPyramid() =>
        PynativeExerciseRunner.Run(17, "Pyramid Pattern",
            "Print a centered pyramid pattern of asterisks.",
            t => t.Add(("rows = 5", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Printing centered pyramid pattern:",
                        "    *",
                        "   ***",
                        "  *****",
                        " *******",
                        "*********",
                        "Pattern printing completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintPyramid(5))))));

    public static PynativeExerciseRunner.SuiteResult Test18_PrintNumberPattern() =>
        PynativeExerciseRunner.Run(18, "Number Pattern",
            "Print rows where each row lists the numbers from 1 up to the row number.",
            t => t.Add(("rows = 5", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Printing number pattern:",
                        "1",
                        "1 2",
                        "1 2 3",
                        "1 2 3 4",
                        "1 2 3 4 5",
                        "Pattern printing completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintNumberPattern(5))))));

    public static PynativeExerciseRunner.SuiteResult Test19_PrintFloydsTriangle() =>
        PynativeExerciseRunner.Run(19, "Floyd's Triangle",
            "Print Floyd's Triangle up to a given number of rows.",
            t => t.Add(("rows = 5", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Printing Floyd's Triangle:",
                        "1",
                        "2 3",
                        "4 5 6",
                        "7 8 9 10",
                        "11 12 13 14 15",
                        "Pattern printing completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintFloydsTriangle(5))))));

    public static PynativeExerciseRunner.SuiteResult Test20_PrintPerfectNumbers() =>
        PynativeExerciseRunner.Run(20, "Perfect Numbers",
            "Print every perfect number between 1 and 500.",
            t => t.Add(("1 to 500 -> 6, 28, 496", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Finding perfect numbers between 1 and 500:",
                        "Perfect Number: 6",
                        "Perfect Number: 28",
                        "Perfect Number: 496",
                        "Perfect number search completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintPerfectNumbers(1, 500))))));

    public static PynativeExerciseRunner.SuiteResult Test21_PrintFibonacci() =>
        PynativeExerciseRunner.Run(21, "Fibonacci Series",
            "Print the first N numbers of the Fibonacci sequence.",
            t => t.Add(("n = 10", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "0 1 1 2 3 5 8 13 21 34" },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintFibonacci(10))))));

    public static PynativeExerciseRunner.SuiteResult Test22_PrintReversedString() =>
        PynativeExerciseRunner.Run(22, "Reverse a String",
            "Print a string backward using a loop.",
            t => t.Add(("Hello -> olleH", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Reversing the string \"Hello\":",
                        "Reversed String: olleH",
                        "String reversal completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintReversedString("Hello"))))));

    public static PynativeExerciseRunner.SuiteResult Test23_PrintPrimeCheck() =>
        PynativeExerciseRunner.Run(23, "Prime Number Check",
            "Determine whether a given number is a prime number.",
            t => t.Add(("29", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Checking if 29 is a prime number:",
                        "Result: 29 is a prime number.",
                        "Prime number check completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintPrimeCheck(29))))));

    public static PynativeExerciseRunner.SuiteResult Test24_PrintPrimesInRange() =>
        PynativeExerciseRunner.Run(24, "Find Primes in a Range",
            "Print all prime numbers between 1 and 50.",
            t => t.Add(("1 to 50", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Finding prime numbers between 1 and 50:",
                        "Prime Number: 2",
                        "Prime Number: 3",
                        "Prime Number: 5",
                        "Prime Number: 7",
                        "Prime Number: 11",
                        "Prime Number: 13",
                        "Prime Number: 17",
                        "Prime Number: 19",
                        "Prime Number: 23",
                        "Prime Number: 29",
                        "Prime Number: 31",
                        "Prime Number: 37",
                        "Prime Number: 41",
                        "Prime Number: 43",
                        "Prime Number: 47",
                        "Prime number search completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintPrimesInRange(1, 50))))));

    public static PynativeExerciseRunner.SuiteResult Test25_PrintPower() =>
        PynativeExerciseRunner.Run(25, "Power Calculator",
            "Calculate a base raised to an exponent without using Math.Pow.",
            t => t.Add(("2^8 -> 256", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Calculating 2 raised to the power 8:",
                        "Result = 256",
                        "Power calculation completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintPower(2, 8))))));

    public static PynativeExerciseRunner.SuiteResult Test26_PrintVowelAndConsonantCounts() =>
        PynativeExerciseRunner.Run(26, "Count Vowels and Consonants",
            "Loop through a string and count how many vowels and consonants it has.",
            t => t.Add(("Programming -> 3 vowels, 8 consonants", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Counting vowels and consonants in \"Programming\":",
                        "Vowels = 3",
                        "Consonants = 8",
                        "Vowel and consonant count completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() =>
                        LoopExercises.PrintVowelAndConsonantCounts("Programming"))))));

    public static PynativeExerciseRunner.SuiteResult Test27_PrintLcm() =>
        PynativeExerciseRunner.Run(27, "LCM (Lowest Common Multiple)",
            "Find the LCM of two numbers using a loop.",
            t => t.Add(("4 and 6 -> 12", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Calculating LCM of 4 and 6:",
                        "LCM = 12",
                        "LCM calculation completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintLcm(4, 6))))));

    public static PynativeExerciseRunner.SuiteResult Test28_PrintGcd() =>
        PynativeExerciseRunner.Run(28, "GCD (Greatest Common Divisor)",
            "Find the GCD of two numbers using the Euclidean algorithm.",
            t => t.Add(("48 and 18 -> 6", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Calculating GCD of 48 and 18:",
                        "GCD = 6",
                        "GCD calculation completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintGcd(48, 18))))));

    public static PynativeExerciseRunner.SuiteResult Test29_PrintBinaryToDecimal() =>
        PynativeExerciseRunner.Run(29, "Binary to Decimal",
            "Convert a binary number into its decimal equivalent using a loop.",
            t => t.Add(("1011 -> 11", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Converting binary 1011 to decimal:",
                        "Decimal Value = 11",
                        "Binary to decimal conversion completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintBinaryToDecimal("1011"))))));

    public static PynativeExerciseRunner.SuiteResult Test30_PrintDecimalToBinary() =>
        PynativeExerciseRunner.Run(30, "Decimal to Binary",
            "Convert a decimal number into its binary representation using a loop.",
            t => t.Add(("26 -> 11010", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Converting decimal 26 to binary:",
                        "Binary Value = 11010",
                        "Decimal to binary conversion completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintDecimalToBinary(26))))));

    public static PynativeExerciseRunner.SuiteResult Test31_PrintDiagonalSum() =>
        PynativeExerciseRunner.Run(31, "Matrix Diagonal Sum",
            "Sum the main diagonal of a 3x3 matrix using nested loops.",
            t => t.Add(("{{1,2,3},{4,5,6},{7,8,9}} -> 15", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Calculating sum of main diagonal elements:",
                        "Diagonal Sum = 15",
                        "Matrix diagonal sum calculation completed successfully.",
                    },
                    () => PynativeConsole.CaptureLines(() => LoopExercises.PrintDiagonalSum(new int[,]
                    {
                        { 1, 2, 3 },
                        { 4, 5, 6 },
                        { 7, 8, 9 },
                    }))))));
}
