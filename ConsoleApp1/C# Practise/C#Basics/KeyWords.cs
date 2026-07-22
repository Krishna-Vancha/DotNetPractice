using System;
using System.Runtime.InteropServices;

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
 * 9) init
 *    - Used on property or indexer setters to make them assignable only during object
 *      initialization, in a constructor, or in a `with` expression for records.
 *    - Good for immutable DTO-style objects: callers can set values at creation time,
 *      but cannot modify them later.
 *
 * 10) sealed
 *    - On a class: no other class may inherit from it (inheritance chain stops here).
 *      Example: public sealed class AppSettings { }
 *    - On a method with override: public sealed override void M() { } — derived
 *      classes cannot override M again (final override in the hierarchy).
 *    - Not the same as static: sealed blocks subclassing; static means type-level,
 *      no instance.
 *    - Common pairs: virtual → override → sealed override; or sealed class when
 *      the type must not be extended (security, design-by-contract).
 *
 * 11) Span<T> (related feature, not a keyword)
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
 * 12) Windows Forms (WinForms)
 *    - Windows Forms (commonly known as WinForms) is a free and open-source graphical
 *      user interface (GUI) class library included as part of the .NET framework.
 *    - Introduced by Microsoft as the original drag-and-drop framework to build rich,
 *      native desktop applications for the Windows operating system.
 *
 * 13) extern
 *    - Modifier keyword: declares a method implemented externally — outside your C#
 *      source code (no method body in C#).
 *    - Tells the compiler: trust this signature; the implementation is provided at
 *      runtime (often a native Windows DLL via P/Invoke).
 *    - Common pattern: [DllImport("native.dll", SetLastError = true)]
 *      public static extern bool SomeNativeApi();
 *    - See SecurityUtilities in #region extern below (advapi32.dll / RevertToSelf).
 *
 * 14) dynamic
 *    - Keyword introduced in C# 4.0: tells the compiler to bypass compile-time type checking.
 *    - Method calls, properties, and operations on a dynamic variable are resolved entirely
 *      at runtime (via the DLR), not when you build the application.
 *    - Trade-off: flexibility for COM, JSON, and late-bound APIs vs no IntelliSense/errors
 *      for typos until runtime (RuntimeBinderException).
 *    - Not the same as var: var is statically typed at compile time; dynamic defers typing.
 *    - Not the same as object: object requires casts; dynamic allows direct member access
 *      when the runtime type supports it.
 *
 * =============================================================================
 */

    internal class KeyWords
    {
        public static void RunSealedDemo()
        {
            var child = new SealedOverrideChild();
            BaseForSealed b = child;
            b.Display(); // "Child" — override still runs at runtime

            // SealedClass cannot be subclassed — compile error if you try:
            // class Bad : SealedClass { }
        }

        #region sealed — class and override

        public class BaseForSealed
        {
            public virtual void Display() => Console.WriteLine("Base");
        }

        public class SealedOverrideChild : BaseForSealed
        {
            public sealed override void Display() => Console.WriteLine("Child");
        }

        // class FurtherChild : SealedOverrideChild
        // {
        //     public override void Display() { } // CS0509: cannot override sealed member
        // }

        public sealed class SealedClass
        {
            public int Id { get; init; }
        }

        #endregion

        #region extern — DllImport / native WinAPI

        /// <summary>
        /// Example: <c>extern</c> + <see cref="DllImportAttribute"/> — implementation lives in a native DLL.
        /// Do not call <see cref="RevertToSelf"/> unless you understand Windows security context (impersonation).
        /// </summary>
        internal static class SecurityUtilities
        {
            // extern: no C# body — advapi32.dll provides RevertToSelf at runtime (Windows only).
            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern bool RevertToSelf();
        }

        #endregion

        #region dynamic — late binding (C# 4.0)

        public static void RunDynamicDemo()
        {
            dynamic value = "Hello";
            Console.WriteLine(value.Length); // resolved at runtime

            value = 42;
            Console.WriteLine(value + 1); // runtime type is int
        }

        #endregion
    }
}
