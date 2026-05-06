using System;
using System.Globalization;

namespace ConsoleApp1.C__Practise.OOPs_Concepts
{
    /*
     * =============================================================================
     * Type casting, type conversion, is, as — study notes (interview-oriented)
     * =============================================================================
     *
     * 1) Cast expression — (T)expr  , Implicit, Explicit, upcast, downcast, unboxing, checked/unchecked, enum.
     *    - "Cast" in interviews usually means the cast expression: apply an explicit or
     *      pre-defined conversion.
     *    - Implicit: compiler allows without (T) — e.g. int to long, Derived reference to
     *      Base (upcast).
     *    - Explicit: you write (T) — narrow numerics, (EnumType)int, (Derived)baseRef,
     *      unbox from object to a value type.
     *    - Upcast (reference): Animal a = new Cat();  — no cast; always safe.
     *    - Downcast: (Cat)a — can throw InvalidCastException at runtime if the object
     *      is not a Cat (or not assignable).
     *    - Unboxing: object o = 42; int n = (int)o;  — the boxed type must match exactly;
     *      else InvalidCastException. Boxing = value to object/interface (heap box).
     *    - checked / unchecked: in checked, overflowing integer ops can throw
     *      OverflowException; default is often unchecked (wrap). Use checked for
     *      financial/safety, or decimal when appropriate.
     *    - Enum: underlying integral type; (int)day or (Day)code. A numeric value that is
     *      not a "named" enum member still forms that enum value — use Enum.IsDefined
     *      or validate if that matters.
     *
     * 2) Type conversion (broader than (T) alone)
     *    - Parse / TryParse: string to primitive; TryParse for untrusted input; specify
     *      CultureInfo / InvariantCulture when format must be fixed (e.g. "3.5" in parsing).
     *    - Convert: helpers over many types, rounding/overflow per overload (read docs
     *      for the exact overload you use in an answer).
     *    - User-defined: public static implicit/explicit operator in your type; at least
     *      one of source or target is your type. implicit = no cast; explicit = (MyType)x.
     *    - Do not confuse: parsing a string, boxing, and (Down)cast are different mechanisms.
     *
     * 3) as operator — expr as T
     *    - For reference types: result is T or null; no InvalidCastException when the
     *      instance is not compatible.
     *    - For unboxing to nullable: o as int?  — valid. You cannot "as int" (non-nullable).
     *    - If (T) is wrong, cast throws; if as fails, you get null — so use (T) when
     *      failure is exceptional; as + null-check when failure is common.
     *    - (is T x) often clearest: one type check + variable in the true branch.
     *
     * 4) is operator — type test and patterns
     *    - o is int         — bool, no exception for "not int".
     *    - o is int n       — in true branch, n is assigned (declaration pattern).
     *    - o is not null, o is not string
     *    - switch / switch on object: first matching pattern wins; put derived types
     *      (e.g. Cat) before base (Animal) or the base case catches everything below.
     *    - is does not "fail" with false by throwing; evaluating some patterns can run
     *      user code that might throw, but a plain type test returns false.
     *
     * 5) OOP link (this file uses Animal / Cat)
     *    - Polymorphism: static type Animal, runtime type Cat. Downcast only when you
     *      need Cat-only API; prefer as / is to avoid try/catch on InvalidCastException.
     * =============================================================================
     */
    public static class TypeCastingOopTheory
    {
        public static void RunAllDemos()
        {
            TypeCasting_Section_Demos();
            TypeConversion_Section_Demos();
            AsOperator_Section_Demos();
            IsOperator_Section_Demos();
        }

        #region Type casting

        /*
         * Section: type casting (see namespace block for full notes)
         * Code: numeric wide/narrow, enum, Animal/Cat up+downcast, unboxing.
         */
        public static void TypeCasting_Section_Demos()
        {
            // --- Numeric: implicit widening, explicit narrowing ---
            int a = 100;
            long w = a;    // implicit int -> long
            byte b = (byte)w;  // explicit; may lose range

            checked
            {
                // int o = int.MaxValue; int p = o + 1; // would throw in checked
            }

            // --- enum ---
            const Day d = Day.Tue;
            int code = (int)d;
            Day back = (Day)code;

            // --- object reference: upcast (implicit) and downcast (explicit) ---
            Animal? cat = new Cat();
            Animal? animal = cat;  // upcast, implicit
            if (cat is not null)
            {
                _ = (Cat)animal!;  // downcast: throws if animal is not a Cat
            }

            // --- unboxing: boxed value type back to value ---
            int boxed = 42;
            object o = boxed;
            int n = (int)o;  // unbox: wrong value type in box => InvalidCastException
            _ = (a, w, b, d, code, back, n);
        }

        public enum Day { Mon = 1, Tue, Wed }

        public class Animal
        {
            public virtual void Speak() { }
        }

        public class Cat : Animal
        {
            public override void Speak() { }
        }

        #endregion

        #region Type conversion

        /*
         * Section: type conversion (Parse, Convert, custom Celsius operators)
         * See namespace block for: culture, when to use TryParse vs Parse.
         */
        public static void TypeConversion_Section_Demos()
        {
            // --- String to primitive (use culture when needed) ---
            const string s = "40";
            int i = int.Parse(s, CultureInfo.InvariantCulture);
            _ = int.TryParse("x", out _);

            // --- Convert: IConvertible-style helpers, handles many types ---
            const double f = 3.6;
            int c = Convert.ToInt32(f);

            // --- User-defined explicit/implicit (custom type) ---
            var t = (Celsius)(double)20.0;
            double celsiusAsDouble = t;  // implicit to double
            _ = (i, c, celsiusAsDouble);
        }

        public readonly struct Celsius(double v)
        {
            public double Value { get; } = v;
            public static explicit operator Celsius(double d) => new Celsius(d);
            public static implicit operator double(Celsius c) => c.Value;
        }

        #endregion

        #region The "as" operator

        /*
         * Section: as — reference or nullable; null on failure, no throw for bad ref type.
         */
        public static void AsOperator_Section_Demos()
        {
            object? text = "data";
            string? s1 = text as string;   // "data"
            object? num = 5;
            string? s2 = num as string;   // null (int is not string)
            // string s3 = (string)num!;  // would throw

            // Nullable unboxing pattern
            object? boxed = 7;
            int? ni = boxed as int?;
            if (ni is { } v)
                _ = v;

            // Reference hierarchy: 'as' for downcast
            Animal a = new Cat();
            var maybeCat = a as Cat;  // Cat instance, or null if 'a' were not Cat
            _ = (s1, s2, maybeCat);
        }

        #endregion

        #region The "is" operator

        /*
         * Section: is — bool test, declaration pattern, switch; order matters in switch.
         */
        public static void IsOperator_Section_Demos()
        {
            object? o1 = 10;
            if (o1 is int) { /* unboxed or boxed int */ }

            if (o1 is int n)
                _ = n + 1;

            if (o1 is not string) { }

            // Switch expression
            string s = DescribePattern(new Cat());
            _ = s;
        }

        public static string DescribePattern(object? o) => o switch
        {
            null => "null",
            int i => $"int {i}",
            Cat c => "cat: " + c.GetType().Name,
            Animal a => "animal: " + a.GetType().Name,
            _ => "other"
        };

        #endregion
    }
}
