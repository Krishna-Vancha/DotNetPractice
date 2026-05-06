using System;

namespace ConsoleApp1.C__Practise.C_Basics
{
/*
 * =============================================================================
 * C# keywords & related operators — study notes
 * =============================================================================
 *
 * 1) const
 *    - Value fixed at compile time; must be initialized where declared.
 *    - Implicitly static (no instance const fields).
 *    - Allowed types: primitives, enum, string, null for reference types where applicable,
 *      and other const-dependent constants — not arbitrary runtime objects.
 *
 * 2) readonly
 *    - For fields: can be assigned in declaration or in constructors (instance or
 *      static depending on field); value fixed after construction completes.
 *    - Broader type surface than const — reference types, structs, etc.
 *
 * 3) const vs readonly (quick compare)
 *    - const → compile-time literal semantics; readonly → init-then-fixed at runtime.
 *
 * 4) yield (yield return / yield break)
 *    - Used in iterator methods returning IEnumerable / IEnumerator / async streams.
 *    - Compiler builds a state machine — lazy evaluation (values produced on demand).
 *
 * 5) typeof
 *    - Type t = typeof(string); — obtains System.Type at compile time for a type known
 *      in source (metadata token).
 *
 * 6) nameof
 *    - nameof(myVar) / nameof(MyType.Member) — string name at compile time; safe for
 *      refactors (ArgumentException, logging, INotifyPropertyChanged).
 *
 * 7) sizeof
 *    - sizeof(int) — size in bytes for unmanaged value types (unsafe context rules
 *      apply for some types in older language versions).
 *
 * 8) default
 *    - default / default(T) — type’s default value (0, false, null for refs, etc.);
 *      default inference with target typing in modern C#.
 *
 * 9) Span<T> (related feature, not a keyword)
 *    - QuickRecap: ref struct that does not create new memory; it points to existing
 *      contiguous memory.
 *    - Span<T>: mutable view over contiguous memory; ReadOnlySpan<T>: read-only view
 *      useful for strings and read-only data.
 *    - .Slice(start, length) creates another view of the same memory without allocation
 *      or copying.
 *    - Index access [] reads or writes through the view; modifying Span<T> can modify
 *      the original array/memory.
 *    - Because Span<T> is a ref struct, it is stack-only and cannot be boxed, stored in
 *      class fields, or used across async/yield boundaries.
 *
 * =============================================================================
 */

    internal class KeyWords
    {
    }
}
