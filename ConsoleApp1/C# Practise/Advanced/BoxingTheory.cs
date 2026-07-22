using System;

namespace ConsoleApp1.CSharpPractise.Advanced;

/*
 * =============================================================================
 * Data Boxing & Unboxing — Study Notes (Memory Management Mechanics)
 * =============================================================================
 *
 * 1) Boxing Mechanics (Value Type -> Reference Type):
 *    - Allocation: A brand new object wrapper is allocated on the managed HEAP.
 *    - Copying: The raw value living on the STACK is copied into that new heap object.
 *    - Conversion: It happens implicitly; no special casting syntax is required.
 *
 * 2) Unboxing Mechanics (Reference Type -> Value Type):
 *    - Verification: The CLR checks the heap object to ensure it matches the target type.
 *    - Copying: The value is copied from the heap back into a stack variable frame.
 *    - Conversion: Requires an EXPLICIT cast. If the type doesn't match perfectly,
 *      it throws an `InvalidCastException`.
 *
 * 3) The Serious Performance Hit:
 *    - Boxing forces a heap allocation, which pressures the Garbage Collector (GC).
 *    - Doing thousands of boxing operations in loops causes significant CPU overhead.
 *    - Solution: Always use modern **Generics** (`List<T>` instead of `ArrayList`)
 *      to ensure compile-time type safety and completely bypass boxing loops.
 * =============================================================================
 */

public static class BoxingTheory
{
    public static void RunDemo()
    {
        Console.WriteLine("=== 1. Core Boxing and Unboxing Pipeline ===");

        int stackValue = 150;

        // BOXING: Implicit conversion. 'object' forces a heap allocation wrapper.
        object boxedObject = stackValue;

        // UNBOXING: Requires an explicit cast to get the raw value back to the stack.
        int unboxedValue = (int)boxedObject;

        Console.WriteLine($"Original Stack Value: {stackValue}");
        Console.WriteLine($"Boxed Representation: {boxedObject}");
        Console.WriteLine($"Unboxed Stack Return: {unboxedValue}\n");


        Console.WriteLine("=== 2. Type Verification Failure ===");

        double preciseAmount = 99.99;
        object boxedAmount = preciseAmount;

        try
        {
            // UNBOXING ERROR: cannot unbox to a different type than was boxed.
            int failedUnbox = (int)boxedAmount;
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine($"Unboxing Blocked: Crucial type mismatch! Error: {ex.Message}\n");
        }


        Console.WriteLine("=== 3. Performance Warning: Invisible Boxing ===");

        int age = 26;
        Console.WriteLine("User Age: " + age); // 'age' is boxed when passed as object

        Console.WriteLine($"User Age: {age.ToString()}");
    }
}
