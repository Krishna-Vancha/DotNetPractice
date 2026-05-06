using System;
using System.Runtime.InteropServices;

namespace ConsoleApp1.CSharpPractise.Advanced;

/*
 * =============================================================================
 * Span<T> and Memory<T> — study notes (High-Performance C#)
 * =============================================================================
 *
 * 1) What is Span<T>?
 * - A "ref struct" that provides a window into contiguous memory **No Memory Allocation Happens just points to memory**.
 * - Performance: Avoids heap allocations and data copying during "slicing."
 * - Limitation: Because it's a 'ref struct', it lives only on the STACK. 
 * It cannot be a field in a class, used in async methods, or boxed.
 *
 * 2) Span vs. ReadOnlySpan
 * - Span<T>: Allows modifying the underlying data.
 * - ReadOnlySpan<T>: Optimized for read-only data (like strings).
 *
 * 3) Slicing
 * - The most powerful feature. `.Slice(start, length)` creates a new view 
 * of the same memory instantly without allocating a new array.
 *
 * 4) stackalloc
 * - Allows allocating memory directly on the stack for ultra-fast, 
 * GC-free temporary buffers.
 * =============================================================================
 */

public static class SpanTheory
{
    public static void RunAllDemos()
    {
        BasicSlicing_Demo();
        StringPerformance_Demo();
        StackAlloc_Demo();
    }

    public static void BasicSlicing_Demo()
    {
        int[] numbers = { 10, 20, 30, 40, 50, 60 };

        // Create a Span pointing to the array
        Span<int> span = numbers;

        // SLICING: Get elements from index 2 to 4 (30, 40)
        // This DOES NOT copy the data. It just points to the original array.
        Span<int> slice = span.Slice(2, 2);

        slice[0] = 99; // Modifies the original 'numbers' array index 2

        Console.WriteLine(numbers[2]); // Output: 99
    }

    public static void StringPerformance_Demo()
    {
        string fullName = "Bunty Singh";

        // Traditional Substring creates a NEW string on the heap (Allocation!)
        // ReadOnlySpan creates a view of the existing string (No Allocation!)
        ReadOnlySpan<char> spanName = fullName.AsSpan();

        ReadOnlySpan<char> firstName = spanName.Slice(0, 5);

        Console.WriteLine(firstName.ToString());
    }

    public static void StackAlloc_Demo()
    {
        // Allocate 100 ints directly on the stack. 
        // No Garbage Collector involvement!
        Span<int> buffer = stackalloc int[100];

        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = i * 2;
        }

        // Memory is automatically reclaimed when the method returns.
    }
}