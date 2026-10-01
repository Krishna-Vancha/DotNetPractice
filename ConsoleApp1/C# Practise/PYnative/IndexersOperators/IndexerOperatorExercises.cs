using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.IndexersOperators;

/// <summary>PYnative C# Indexers and Operator Overloading Exercises — https://pynative.com/csharp-indexers-operator-overloading-exercises/</summary>
public static partial class IndexerOperatorExercises
{
    // Exercise 1: Look Up a Day of the Week by Name
    //
    // Practice Problem: Create a Week class that contains an array of the 7 days of the week. Implement a string-based indexer so that week["Monday"] returns 1, week["Tuesday"] returns 2, and so on. Return -1 if an invalid day name is passed.
    //
    // Purpose: Practice a string-keyed indexer so your class can be accessed with square brackets.
    //
    // Given Input: week["Monday"], week["Tuesday"], week["Funday"]
    //
    // Expected Output:
    // week["Monday"] = 1
    // week["Tuesday"] = 2
    // week["Funday"] = -1
    //
    // --- Your solution: Week class + RunExercise01() below ---

    public static void RunExercise01() =>
        throw new NotImplementedException();

    // Exercise 2: Build a Bounds-Checked Safe Array
    //
    // Practice Problem: Build a SafeArray class that wraps a standard integer array. Implement a standard integer indexer, but add bounds-checking. If the user tries to access an index out of bounds (e.g., array[100]), instead of crashing with an exception, return a default value of 0 on get, and do nothing (or resize) on set.
    //
    // Purpose: Practice get and set accessors that each do their own bounds checks.
    //
    // Given Input: A SafeArray of size 5, with array[2] = 42, then access and write attempts at index 100.
    //
    // Expected Output:
    // array[2] = 42
    // array[100] = 0
    // array[100] after out-of-bounds set = 0
    //
    // --- Your solution: SafeArray class + RunExercise02() below ---

    public static void RunExercise02() =>
        throw new NotImplementedException();

    // Exercise 3: Access Individual Bits with an Indexer
    //
    // Practice Problem: Create a BitCompact struct that wraps a single int value (32 bits). Implement an indexer public bool this[int bitIndex] that allows you to get or set individual bits (true for 1, false for 0) using bitwise operators.
    //
    // Purpose: Practice an indexer that reads and writes individual bits of a packed integer.
    //
    // Given Input: Starting from 0, set bit 0 and bit 3 to true.
    //
    // Expected Output:
    // bits[0] = True
    // bits[1] = False
    // bits[3] = True
    // Underlying Value = 9
    //
    // --- Your solution: BitCompact struct + RunExercise03() below ---

    public static void RunExercise03() =>
        throw new NotImplementedException();

    // Exercise 4: Build a Spreadsheet-Style Grid
    //
    // Practice Problem: Create a Grid class that represents a 2D table of strings. Implement a two-dimensional indexer public string this[int row, int col] to get or set values. Add an overload that allows indexing via a string Excel-style coordinate, like grid["A", 5].
    //
    // Purpose: Practice multiple indexer overloads on the same class.
    //
    // Given Input: grid[0, 0] = "Name", then grid["A", 1] = "Alice"
    //
    // Expected Output:
    // grid[0, 0] = Name
    // grid["A", 1] = Alice
    // grid[1, 0] via numeric indexer = Alice
    //
    // --- Your solution: Grid class + RunExercise04() below ---

    public static void RunExercise04() =>
        throw new NotImplementedException();

    // Exercise 5: Find an Employee by Multiple Keys
    //
    // Practice Problem: Create an EmployeeRegistry class containing a list of Employee objects (each having an ID, Name, and Email). Implement overloaded indexers so an employee can be retrieved by their int ID, their string Name, or their string Email.
    //
    // Purpose: Practice lookup indexers whose parameter type chooses the search.
    //
    // Given Input: Two employees, Alice (ID 1) and Bob (ID 2), looked up by ID, name, and email.
    //
    // Expected Output:
    // registry[1].Name = Alice
    // registry["Bob"].Email = bob@example.com
    // registry["alice@example.com"].Name = Alice
    //
    // --- Your solution: Employee + EmployeeRegistry classes + RunExercise05() below ---

    public static void RunExercise05() =>
        throw new NotImplementedException();

    // Exercise 6: Overload Operators for 2D Vector Math
    //
    // Practice Problem: Create a Vector2D struct with X and Y properties. Overload the + and - operators to allow vector addition and subtraction. Also, overload the * operator to allow a vector to be multiplied by a scalar double value.
    //
    // Purpose: Practice the static operator overload syntax for +, -, and *.
    //
    // Given Input: a = (2, 3), b = (4, 1)
    //
    // Expected Output:
    // a + b = (6, 4)
    // a - b = (-2, 2)
    // a * 2.5 = (5, 7.5)
    //
    // --- Your solution: Vector2D struct + RunExercise06() below ---

    public static void RunExercise06() =>
        throw new NotImplementedException();

    // Exercise 7: Build a Self-Reducing Fraction Calculator
    //
    // Practice Problem: Create a Fraction class with Numerator and Denominator properties. Overload +, -, *, and / to perform precise fractional arithmetic. Ensure the resulting fraction is automatically reduced to its simplest form (e.g., 2/4 becomes 1/2).
    //
    // Purpose: Practice the four arithmetic operators plus reduction in the constructor.
    //
    // Given Input: half = 1/2, twoFourths = 2/4, third = 1/3
    //
    // Expected Output:
    // 2/4 reduced automatically = 1/2
    // 1/2 + 1/3 = 5/6
    // 1/2 - 1/3 = 1/6
    // 1/2 * 1/3 = 1/6
    // 1/2 / 1/3 = 3/2
    //
    // --- Your solution: Fraction class + RunExercise07() below ---

    public static void RunExercise07() =>
        throw new NotImplementedException();

    // Exercise 8: Add and Subtract Time Durations
    //
    // Practice Problem: Create a Duration class representing hours and minutes. Overload the + and - operators to add or subtract durations. Ensure that if minutes exceed 59, they roll over correctly into hours (e.g., 1h 45m + 0h 30m = 2h 15m).
    //
    // Purpose: Practice normalizing hours and minutes inside the constructor.
    //
    // Given Input: first = 1h 45m, second = 0h 30m
    //
    // Expected Output:
    // 1h 45m + 0h 30m = 2h 15m
    //
    // --- Your solution: Duration class + RunExercise08() below ---

    public static void RunExercise08() =>
        throw new NotImplementedException();

    // Exercise 9: Compare Money Values Safely by Currency
    //
    // Practice Problem: Create a Money struct with Amount (decimal) and Currency (string, e.g., "USD"). Overload the ==, !=, <, and > operators. The comparison operators should throw an exception if the two Money objects being compared have different currencies.
    //
    // Purpose: Practice comparison operators that reject mismatched currencies.
    //
    // Given Input: tenDollars = 10 USD, twentyDollars = 20 USD, tenEuros = 10 EUR
    //
    // Expected Output:
    // 10 USD < 20 USD = True
    // 10 USD == 10 USD = True
    // Error: Cannot compare USD with EUR.
    //
    // --- Your solution: Money struct + RunExercise09() below ---

    public static void RunExercise09() =>
        throw new NotImplementedException();

    // Exercise 10: Overload the Multiplication Operator for Strings
    //
    // Practice Problem: Create a SmartString wrapper class. Overload the * operator between a SmartString and an int so that new SmartString("Hi") * 3 results in a new SmartString containing "HiHiHi".
    //
    // Purpose: Practice giving * a non-numeric meaning (repeat the text).
    //
    // Given Input: greeting = new SmartString("Hi"), count = 3
    //
    // Expected Output:
    // Repeated = HiHiHi
    //
    // --- Your solution: SmartString class + RunExercise10() below ---

    public static void RunExercise10() =>
        throw new NotImplementedException();

    // Exercise 11: Multiply Two Matrices with a 2D Indexer
    //
    // Practice Problem: Create a Matrix class (a mathematical grid of numbers). Implement a 2D indexer to access elements at matrix[row, col]. Then, overload the * operator to implement true mathematical matrix multiplication between two Matrix objects.
    //
    // Purpose: Practice a 2D indexer together with matrix multiplication.
    //
    // Given Input: a = [[1, 2], [3, 4]], b = [[5, 6], [7, 8]]
    //
    // Expected Output:
    // Result of a * b:
    // 19 22
    // 43 50
    //
    // --- Your solution: Matrix class + RunExercise11() below ---

    public static void RunExercise11() =>
        throw new NotImplementedException();

    // Exercise 12: Convert Between Double and a Custom Distance Type
    //
    // Practice Problem: Create a Distance class that stores values in meters. Implement an implicit conversion operator from double to Distance (assuming the double is in meters). Then, implement an explicit conversion operator from Distance to string that formats the output nicely (e.g., "1500m").
    //
    // Purpose: Practice implicit versus explicit conversion operators.
    //
    // Given Input: double meters = 1500.0
    //
    // Expected Output:
    // Formatted = 1500m
    //
    // --- Your solution: Distance class + RunExercise12() below ---

    public static void RunExercise12() =>
        throw new NotImplementedException();

    // Exercise 13: Build a Polynomial with an Indexer for Coefficients
    //
    // Practice Problem: Create a Polynomial class that represents an algebraic polynomial (like 3x^2 + 2x + 5). Use an indexer where the index represents the power of x (so poly[2] = 3 sets the coefficient of x^2). Overload the + operator to add two polynomials together by summing their like-termed coefficients.
    //
    // Purpose: Practice an indexer whose index is a power, plus polynomial addition.
    //
    // Given Input: first = 3x^2 + 2x + 5, second = 1x^2 + 4
    //
    // Expected Output:
    // First = 3x^2 + 2x + 5
    // Second = 1x^2 + 4
    // Sum = 4x^2 + 2x + 9
    //
    // --- Your solution: Polynomial class + RunExercise13() below ---

    public static void RunExercise13() =>
        throw new NotImplementedException();

    // Exercise 14: Overload & and | for Short-Circuit Boolean Logic
    //
    // Practice Problem: Create a Criteria class that holds a set of evaluation rules. Overload the conditional logical operators & and | (and consequently true and false operators, which C# requires for short-circuiting evaluation) so that users can combine multiple Criteria objects together seamlessly using && and ||.
    //
    // Purpose: Practice &, |, true, and false so && and || short-circuit on a custom type.
    //
    // Given Input: isAdult = true, hasLicense = false, isBanned = false, hasValidPayment = true
    //
    // Expected Output:
    // isAdult & hasLicense = (IsAdult AND HasLicense) = False
    // isAdult | hasLicense = (IsAdult OR HasLicense) = True
    // Access denied (short-circuited: IsBanned was already false, so HasValidPayment's AND combination was never evaluated).
    //
    // --- Your solution: Criteria class + RunExercise14() below ---

    public static void RunExercise14() =>
        throw new NotImplementedException();

    // Exercise 15: Combine an Indexer and Operator Overloading in a Ledger
    //
    // Practice Problem: Create a Ledger class that tracks financial transactions. Indexer: allow users to look up a transaction by date, ledger[DateTime.Today]. Operator overloading: overload the + operator to easily add a new Transaction object directly to the Ledger (e.g., myLedger += new Transaction(50.00);).
    //
    // Purpose: Practice an indexer and + on the same class so += adds a transaction.
    //
    // Given Input: myLedger += new Transaction(50.00m), added with today's date
    //
    // Expected Output: Transaction on 2026-07-13 = 50.00
    //
    // Note: the site records the transaction against DateTime.Today, so the printed date is the day the program runs. 2026-07-13 is only the sample from the article.
    //
    // --- Your solution: Transaction + Ledger classes + RunExercise15() below ---

    public static void RunExercise15() =>
        throw new NotImplementedException();
}
