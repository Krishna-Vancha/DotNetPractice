using System;
using System.Collections.Generic;

namespace ConsoleApp1.C__Practise.PYnative.Arrays;

public static class ArrayExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 30; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative — Array Exercises (30)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_FormatElementsOnSeparateLines(),
        2 => Test02_FormatArrayLabel(),
        3 => Test03_ReverseOrder(),
        4 => Test04_SumAndAverage(),
        5 => Test05_CopyArray(),
        6 => Test06_FindMinMax(),
        7 => Test07_LinearSearch(),
        8 => Test08_CountOccurrences(),
        9 => Test09_SeparateEvenAndOdd(),
        10 => Test10_FindSecondLargest(),
        11 => Test11_RemoveDuplicates(),
        12 => Test12_MergeAndSort(),
        13 => Test13_LeftRotateByOne(),
        14 => Test14_RotateRight(),
        15 => Test15_InsertAt(),
        16 => Test16_DeleteAt(),
        17 => Test17_ElementFrequencies(),
        18 => Test18_FindMode(),
        19 => Test19_FindMissingNumber(),
        20 => Test20_IsSubset(),
        21 => Test21_FormatMatrixGrid(),
        22 => Test22_AddMatrices(),
        23 => Test23_MultiplyMatrices(),
        24 => Test24_DiagonalSum(),
        25 => Test25_Transpose(),
        26 => Test26_BubbleSort(),
        27 => Test27_BinarySearch(),
        28 => Test28_TwoSum(),
        29 => Test29_MaxSubarraySum(),
        30 => Test30_JaggedArrayTotal(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Array exercises are numbered 1–30.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_FormatElementsOnSeparateLines() =>
        PynativeExerciseRunner.Run(1, "Declare and Print",
            "Return each array element on its own line.",
            t =>
            {
                t.Add(("[10,20,30,40,50] -> 5 lines", () =>
                    PynativeExerciseRunner.AssertEqual("10\n20\n30\n40\n50",
                        () => ArrayExercises.FormatElementsOnSeparateLines(new[] { 10, 20, 30, 40, 50 }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test02_FormatArrayLabel() =>
        PynativeExerciseRunner.Run(2, "User Input Array",
            "Return comma-separated array label string.",
            t =>
            {
                t.Add(("[5,10,15] -> \"Array: 5, 10, 15\"", () =>
                    PynativeExerciseRunner.AssertEqual("Array: 5, 10, 15",
                        () => ArrayExercises.FormatArrayLabel(new[] { 5, 10, 15 }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test03_ReverseOrder() =>
        PynativeExerciseRunner.Run(3, "Reverse Print",
            "Return elements in reverse order.",
            t =>
            {
                t.Add(("[1,2,3,4] -> [4,3,2,1]", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(new[] { 4, 3, 2, 1 },
                        () => ArrayExercises.ReverseOrder(new[] { 1, 2, 3, 4 }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test04_SumAndAverage() =>
        PynativeExerciseRunner.Run(4, "Sum & Average",
            "Calculate sum and average of a double array.",
            t =>
            {
                t.Add(("[10.5,20.3,5.2,8.0] -> Sum=44, Avg=11", () =>
                {
                    var (sum, avg) = ArrayExercises.SumAndAverage(new[] { 10.5, 20.3, 5.2, 8.0 });
                    PynativeExerciseRunner.PrintOutput($"Sum={sum}, Average={avg}");
                    PynativeExerciseRunner.AssertEqualSilent(44.0, sum);
                    PynativeExerciseRunner.AssertEqualSilent(11.0, avg);
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test05_CopyArray() =>
        PynativeExerciseRunner.Run(5, "Array Copy",
            "Copy one int array into a new array manually.",
            t =>
            {
                t.Add(("[1,2,3,4,5] -> same values", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(new[] { 1, 2, 3, 4, 5 },
                        () => ArrayExercises.CopyArray(new[] { 1, 2, 3, 4, 5 }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test06_FindMinMax() =>
        PynativeExerciseRunner.Run(6, "Find Maximum & Minimum",
            "Find max and min without LINQ.",
            t =>
            {
                t.Add(("[23,7,45,12,89,34] -> Max=89, Min=7", () =>
                {
                    var (max, min) = ArrayExercises.FindMinMax(new[] { 23, 7, 45, 12, 89, 34 });
                    PynativeExerciseRunner.PrintOutput($"Maximum={max}, Minimum={min}");
                    PynativeExerciseRunner.AssertEqualSilent(89, max);
                    PynativeExerciseRunner.AssertEqualSilent(7, min);
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test07_LinearSearch() =>
        PynativeExerciseRunner.Run(7, "Linear Search",
            "Return index of target or -1.",
            t =>
            {
                t.Add(("target 23 in [4,8,15,16,23,42] -> index 4", () =>
                    PynativeExerciseRunner.AssertEqual(4,
                        () => ArrayExercises.LinearSearch(new[] { 4, 8, 15, 16, 23, 42 }, 23))));
                t.Add(("target 99 -> -1", () =>
                    PynativeExerciseRunner.AssertEqual(-1,
                        () => ArrayExercises.LinearSearch(new[] { 4, 8, 15, 16, 23, 42 }, 99))));
            });

    public static PynativeExerciseRunner.SuiteResult Test08_CountOccurrences() =>
        PynativeExerciseRunner.Run(8, "Count Occurrences",
            "Count how many times target appears.",
            t =>
            {
                t.Add(("target 2 in [2,5,2,8,2,9,5] -> 3", () =>
                    PynativeExerciseRunner.AssertEqual(3,
                        () => ArrayExercises.CountOccurrences(new[] { 2, 5, 2, 8, 2, 9, 5 }, 2))));
            });

    public static PynativeExerciseRunner.SuiteResult Test09_SeparateEvenAndOdd() =>
        PynativeExerciseRunner.Run(9, "Even and Odd Separation",
            "Split into even and odd arrays.",
            t =>
            {
                t.Add(("[12,7,18,3,9,24,5]", () =>
                {
                    var (evens, odds) = ArrayExercises.SeparateEvenAndOdd(new[] { 12, 7, 18, 3, 9, 24, 5 });
                    PynativeExerciseRunner.PrintOutput($"Evens=[{string.Join(",", evens)}], Odds=[{string.Join(",", odds)}]");
                    PynativeExerciseRunner.AssertSequenceEqual(new[] { 12, 18, 24 }, evens);
                    PynativeExerciseRunner.AssertSequenceEqual(new[] { 7, 3, 9, 5 }, odds);
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test10_FindSecondLargest() =>
        PynativeExerciseRunner.Run(10, "Find Second Largest",
            "Find second largest without sorting.",
            t =>
            {
                t.Add(("[12,45,2,41,31,10,8,6,4] -> 41", () =>
                    PynativeExerciseRunner.AssertEqual(41,
                        () => ArrayExercises.FindSecondLargest(new[] { 12, 45, 2, 41, 31, 10, 8, 6, 4 }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test11_RemoveDuplicates() =>
        PynativeExerciseRunner.Run(11, "Remove Duplicates",
            "Return unique elements in first-appearance order.",
            t =>
            {
                t.Add(("[1,2,2,3,4,4,5,1] -> [1,2,3,4,5]", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(new[] { 1, 2, 3, 4, 5 },
                        () => ArrayExercises.RemoveDuplicates(new[] { 1, 2, 2, 3, 4, 4, 5, 1 }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test12_MergeAndSort() =>
        PynativeExerciseRunner.Run(12, "Merge and Sort",
            "Merge two arrays and sort ascending.",
            t =>
            {
                t.Add(("[5,3,8] + [9,1,4,2] -> [1,2,3,4,5,8,9]", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(new[] { 1, 2, 3, 4, 5, 8, 9 },
                        () => ArrayExercises.MergeAndSort(new[] { 5, 3, 8 }, new[] { 9, 1, 4, 2 }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test13_LeftRotateByOne() =>
        PynativeExerciseRunner.Run(13, "Left Rotate",
            "Rotate left by one position.",
            t =>
            {
                t.Add(("[1,2,3,4,5] -> [2,3,4,5,1]", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(new[] { 2, 3, 4, 5, 1 },
                        () => ArrayExercises.LeftRotateByOne(new[] { 1, 2, 3, 4, 5 }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test14_RotateRight() =>
        PynativeExerciseRunner.Run(14, "Rotate by N Positions",
            "Rotate right by k steps.",
            t =>
            {
                t.Add(("[1,2,3,4,5], k=2 -> [4,5,1,2,3]", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(new[] { 4, 5, 1, 2, 3 },
                        () => ArrayExercises.RotateRight(new[] { 1, 2, 3, 4, 5 }, 2))));
            });

    public static PynativeExerciseRunner.SuiteResult Test15_InsertAt() =>
        PynativeExerciseRunner.Run(15, "Insert an Element",
            "Insert value at index, shift right.",
            t =>
            {
                t.Add(("insert 25 at index 2 in [10,20,30,40]", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(new[] { 10, 20, 25, 30, 40 },
                        () => ArrayExercises.InsertAt(new[] { 10, 20, 30, 40 }, 2, 25))));
            });

    public static PynativeExerciseRunner.SuiteResult Test16_DeleteAt() =>
        PynativeExerciseRunner.Run(16, "Delete an Element",
            "Delete element at index.",
            t =>
            {
                t.Add(("delete index 2 from [10,20,30,40,50]", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(new[] { 10, 20, 40, 50 },
                        () => ArrayExercises.DeleteAt(new[] { 10, 20, 30, 40, 50 }, 2))));
            });

    public static PynativeExerciseRunner.SuiteResult Test17_ElementFrequencies() =>
        PynativeExerciseRunner.Run(17, "Frequency Count",
            "Return frequency of each distinct element.",
            t =>
            {
                t.Add(("[5,3,5,2,3,5,8]", () =>
                {
                    var freq = ArrayExercises.ElementFrequencies(new[] { 5, 3, 5, 2, 3, 5, 8 });
                    PynativeExerciseRunner.PrintOutput(freq);
                    PynativeExerciseRunner.AssertEqualSilent(3, freq[5]);
                    PynativeExerciseRunner.AssertEqualSilent(2, freq[3]);
                    PynativeExerciseRunner.AssertEqualSilent(1, freq[2]);
                    PynativeExerciseRunner.AssertEqualSilent(1, freq[8]);
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test18_FindMode() =>
        PynativeExerciseRunner.Run(18, "Find the Mode",
            "Find most frequent element and its count.",
            t =>
            {
                t.Add(("[4,8,4,2,8,4,9] -> mode 4, count 3", () =>
                {
                    var (mode, count) = ArrayExercises.FindMode(new[] { 4, 8, 4, 2, 8, 4, 9 });
                    PynativeExerciseRunner.PrintOutput($"Mode={mode}, Count={count}");
                    PynativeExerciseRunner.AssertEqualSilent(4, mode);
                    PynativeExerciseRunner.AssertEqualSilent(3, count);
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test19_FindMissingNumber() =>
        PynativeExerciseRunner.Run(19, "Missing Number",
            "Find missing integer from 1..n.",
            t =>
            {
                t.Add(("n=6, [1,2,4,5,6] -> 3", () =>
                    PynativeExerciseRunner.AssertEqual(3, () => ArrayExercises.FindMissingNumber(6, new[] { 1, 2, 4, 5, 6 }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test20_IsSubset() =>
        PynativeExerciseRunner.Run(20, "Check Subarray",
            "Check if subsetArray is a subset of mainArray.",
            t =>
            {
                t.Add(("[2,4,6] subset of [1,2,3,4,5,6] -> true", () =>
                    PynativeExerciseRunner.AssertTrue(
                        () => ArrayExercises.IsSubset(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 2, 4, 6 }))));
                t.Add(("[2,7] not subset -> false", () =>
                    PynativeExerciseRunner.AssertFalse(
                        () => ArrayExercises.IsSubset(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 2, 7 }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test21_FormatMatrixGrid() =>
        PynativeExerciseRunner.Run(21, "Matrix Grid Print",
            "Format 3x3 matrix as aligned grid.",
            t =>
            {
                t.Add(("3x3 identity-style matrix", () =>
                {
                    int[,] m = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
                    var result = ArrayExercises.FormatMatrixGrid(m);
                    PynativeExerciseRunner.PrintOutput(result);
                    PynativeExerciseRunner.AssertTrue(result.Contains("1") && result.Contains("9"),
                        "grid should contain matrix values");
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test22_AddMatrices() =>
        PynativeExerciseRunner.Run(22, "Matrix Addition",
            "Add two 2x2 matrices element-wise.",
            t =>
            {
                t.Add(("[[1,2],[3,4]] + [[5,6],[7,8]]", () =>
                {
                    int[,] a = { { 1, 2 }, { 3, 4 } };
                    int[,] b = { { 5, 6 }, { 7, 8 } };
                    int[,] expected = { { 6, 8 }, { 10, 12 } };
                    PynativeExerciseRunner.AssertMatrixEqual(expected, () => ArrayExercises.AddMatrices(a, b));
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test23_MultiplyMatrices() =>
        PynativeExerciseRunner.Run(23, "Matrix Multiplication",
            "Multiply two compatible matrices.",
            t =>
            {
                t.Add(("2x2 * 2x2", () =>
                {
                    int[,] a = { { 1, 2 }, { 3, 4 } };
                    int[,] b = { { 5, 6 }, { 7, 8 } };
                    int[,] expected = { { 19, 22 }, { 43, 50 } };
                    PynativeExerciseRunner.AssertMatrixEqual(expected, () => ArrayExercises.MultiplyMatrices(a, b));
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test24_DiagonalSum() =>
        PynativeExerciseRunner.Run(24, "Diagonal Sum",
            "Sum main diagonal of square matrix.",
            t =>
            {
                t.Add(("[[1,2,3],[4,5,6],[7,8,9]] -> 15", () =>
                    PynativeExerciseRunner.AssertEqual(15,
                        () => ArrayExercises.DiagonalSum(new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test25_Transpose() =>
        PynativeExerciseRunner.Run(25, "Transpose a Matrix",
            "Return transpose of matrix.",
            t =>
            {
                t.Add(("2x3 matrix", () =>
                {
                    int[,] m = { { 1, 2, 3 }, { 4, 5, 6 } };
                    int[,] expected = { { 1, 4 }, { 2, 5 }, { 3, 6 } };
                    PynativeExerciseRunner.AssertMatrixEqual(expected, () => ArrayExercises.Transpose(m));
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test26_BubbleSort() =>
        PynativeExerciseRunner.Run(26, "Bubble Sort Implementation",
            "Sort array using bubble sort.",
            t =>
            {
                t.Add(("[5,1,4,2,8] -> sorted", () =>
                    PynativeExerciseRunner.AssertSequenceEqual(new[] { 1, 2, 4, 5, 8 },
                        () => ArrayExercises.BubbleSort(new[] { 5, 1, 4, 2, 8 }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test27_BinarySearch() =>
        PynativeExerciseRunner.Run(27, "Binary Search",
            "Search sorted array, return index or -1.",
            t =>
            {
                t.Add(("target 23 in sorted array -> index 4", () =>
                    PynativeExerciseRunner.AssertEqual(4,
                        () => ArrayExercises.BinarySearch(new[] { 4, 8, 15, 16, 23, 42 }, 23))));
            });

    public static PynativeExerciseRunner.SuiteResult Test28_TwoSum() =>
        PynativeExerciseRunner.Run(28, "Two Sum Problem",
            "Return indices of two numbers that sum to target.",
            t =>
            {
                t.Add(("nums=[2,7,11,15], target=9 -> (0,1)", () =>
                {
                    var (i, j) = ArrayExercises.TwoSum(new[] { 2, 7, 11, 15 }, 9);
                    PynativeExerciseRunner.PrintOutput($"({i}, {j})");
                    PynativeExerciseRunner.AssertEqualSilent(0, i);
                    PynativeExerciseRunner.AssertEqualSilent(1, j);
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test29_MaxSubarraySum() =>
        PynativeExerciseRunner.Run(29, "Max Subarray Sum (Kadane's Algorithm)",
            "Maximum sum of contiguous subarray.",
            t =>
            {
                t.Add(("[-2,1,-3,4,-1,2,1,-5,4] -> 6", () =>
                    PynativeExerciseRunner.AssertEqual(6,
                        () => ArrayExercises.MaxSubarraySum(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }))));
            });

    public static PynativeExerciseRunner.SuiteResult Test30_JaggedArrayTotal() =>
        PynativeExerciseRunner.Run(30, "Jagged Array Total",
            "Sum all elements in a jagged int array.",
            t =>
            {
                t.Add(("[[1,2],[3,4,5],[6]] -> 21", () =>
                    PynativeExerciseRunner.AssertEqual(21,
                        () => ArrayExercises.JaggedArrayTotal(new[] { new[] { 1, 2 }, new[] { 3, 4, 5 }, new[] { 6 } }))));
            });
}
