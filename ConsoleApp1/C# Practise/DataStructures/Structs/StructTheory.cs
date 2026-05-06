using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.C__Practise.DataStructures.Structs
{

      struct Fruit
    {
        public string fruitColor { get; set; }
        public int fruitPrice { get; set; }
        public Fruit(string fc, int fp)
        {
            fruitColor= fc;
            fruitPrice = fp;
        }
        

    }
    public class StructTheory
    {
        // ----------------------------------------------------------------------------------------------------
        // Struct theory (same content as CSharpTopicsNotes.md – quick revision)
        // ----------------------------------------------------------------------------------------------------
        #region Struct theory – notes and syntax
        // --- 1. What a struct is
        // - A struct is a VALUE TYPE (unlike class = reference type).
        // - All structs implicitly derive from System.ValueType -> object. **No base class for a struct**; interfaces OK.
        // - Memory: often stack / inlined; NOT "always stack" (arrays, class fields, boxing can involve heap).
        // - Copy semantics: assign/pass by value copies the whole instance; large structs = expensive.
        // - default(T), new T(): fields get defaults. C# 10+ allows explicit public S() { } for new S() behavior;
        //   see language rules for default(S) vs field initializers.
        //
        // --- 2. Basic declaration and instance syntax
        // public struct Point
        // {
        //     public int X, Y;
        //     public Point(int x, int y) { X = x; Y = y; }  // assign all instance fields in every ctor
        // }
        // Point p1 = new Point(1, 2);
        // Point p2;        // struct local: fields default-initialized
        // Point p3 = default;
        // C# 10+: field initializers, parameterless instance ctor.
        //
        // --- 3. readonly struct
        // - Whole type: public readonly struct Point3D { ... } — instance members must not mutate the instance.
        // - Pairs with 'in' parameters; readonly instance members in non-readonly struct: readonly int Doubled() => ...
        //
        // --- 4. ref struct
        // - Stack-only; cannot be boxed/heap-escaped; Span<T>, ReadOnlySpan<>, high-perf buffers.
        // - public ref struct MyBuffer { ... } — async/yield and ref-struct rules in locals.
        //
        // --- 5. record struct (C# 10+)
        // - Value-based equality, synthesized ToString, Equals, GetHashCode, ==, with for records.
        // - public record struct PointR(int X, int Y);
        // - public readonly record struct Person(string Name, int Age);
        //
        // --- 6. Inheritance, interfaces, this
        // - No inheritance from class/struct (except ValueType chain). Can implement interfaces.
        // - this is value-typed; copying/mutation gotchas—prefer immutability or ref patterns.
        //
        // --- 7. static, constructors, finalizer
        // - static members like class. Every instance field must be assigned in all ctor paths.
        // - No ~S() finalizer; use IDisposable or scoping.
        //
        // --- 8. default, boxing, patterns
        // - default(S); boxing to object/interface allocates heap; unbox copies. Avoid hot-path boxing.
        // - o is MyStruct s — pattern/switch as usual.
        //
        // --- 9. unsafe, fixed, layout
        // - [StructLayout(LayoutKind.Sequential, Pack = 1)] for interop. unsafe, pointers, fixed byte buffer[...] need unsafe.
        // - sizeof / Marshal.SizeOf: interop and alignment (may differ with padding).
        //
        // --- 10. struct vs class (practical)
        // - struct: small (~16–32 bytes rule of thumb), many instances, often immutable, record struct DTOs.
        // - class: identity, inheritance, large/long-lived, null, virtual polymorphism.
        // - Big structs or interface boxing: class may be clearer; profile.
        #endregion

        public static void Main(string[] args)
        { 
            Fruit apple=new Fruit();
            apple.fruitColor = "Red";
            Console.WriteLine(apple.fruitColor);   //remember the fileds inside any class , struct declared without access modifier are private by default and cannot be accessed outside the class or struct.


        }
    }
}
