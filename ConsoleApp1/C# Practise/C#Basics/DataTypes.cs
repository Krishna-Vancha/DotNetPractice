using System;
using System.Numerics;

namespace ConsoleApp1.C__Practise.C_Basics
{
    public class DataTypes
    {
        #region C# DATA TYPES — MIND MAP & OVERVIEW (DataTypes class)

        /*  C# DATA TYPES HIERARCHY (DataTypes.cs — practise regions in Main)
                        (Value = copy semantics | Reference = identity on heap)

                          ┌───────────────────────┐
                          │     C# Data Types     │
                          └───────────┬───────────┘
                                      │
                    ┌─────────────────┴─────────────────┐
                    ▼                                   ▼
        ┌───────────────────────┐           ┌───────────────────────┐
        │     VALUE TYPES       │           │   REFERENCE TYPES     │
        │  (stored by value)    │           │ (variable = ref)    │
        └───────────┬───────────┘           └───────────┬───────────┘
                    │                                   │
        ┌───────────┴───────────┐           ┌───────────┴───────────┐
        ▼                       ▼           ▼                       ▼
 ┌──────────────┐      ┌──────────────┐ ┌──────────────┐   ┌──────────────┐
 │  PREDEFINED  │      │ USER-DEFINED │ │  PREDEFINED  │   │ USER-DEFINED │
 │  (built-in)  │      │              │ │  (built-in)  │   │              │
 └──────┬───────┘      └──────┬───────┘ └──────┬───────┘   └──────┬───────┘
        │                     │                │                  │
        ▼                     ▼                ▼                  ▼

  ======================== VALUE — PREDEFINED ========================

  ┌─────────────────────────────────────────────────────────────────┐
  │ Signed integers (- to +)                                        │
  │   sbyte (8)  short (16)  int (32)  long (64)                    │
  ├─────────────────────────────────────────────────────────────────┤
  │ Unsigned integers (0 to +)                                      │
  │   byte (8)  ushort (16)  uint (32)  ulong (64)                  │
  ├─────────────────────────────────────────────────────────────────┤
  │ Floating point                                                  │
  │   float (32, f)  double (64, d)  decimal (128, m)               │
  ├─────────────────────────────────────────────────────────────────┤
  │ Other built-in value types                                      │
  │   char  bool  DateTime  BigInteger (System.Numerics)           │
  └─────────────────────────────────────────────────────────────────┘

  ======================== VALUE — USER-DEFINED =======================

  ┌────────────────────┐              ┌────────────────────┐
  │      struct        │              │        enum        │
  │  (SampleStruct)    │              │  (enumvariable)    │
  │  copy by value     │              │  underlying int    │
  └────────────────────┘              └────────────────────┘


  ====================== REFERENCE — PREDEFINED =======================

  ┌─────────────────────────────────────────────────────────────────┐
  │ string      immutable ref; ReadLine / Length                    │
  │ object      any ref or boxed value; boxing from value types     │
  │ dynamic     late binding (C# 4); runtime member resolution      │
  │ T[] Array   all arrays are reference types (heap object)        │
  │ Func/Action built-in delegate types (reference type instances)  │
  └─────────────────────────────────────────────────────────────────┘

  ====================== REFERENCE — USER-DEFINED =====================

  ┌────────────┐  ┌────────────┐  ┌────────────┐  ┌────────────────────┐
  │   class    │  │ interface  │  │record class│  │ delegate (custom)  │
  │SamplePerson│  │ISample     │  │SampleRecord│  │ SampleOperation   │
  │ default    │  │Greetable   │  │ value      │  │ method pointer    │
  │ null       │  │ + class    │  │ equality   │  │ type              │
  └────────────┘  └────────────┘  └────────────┘  └────────────────────┘
        NOTE: Record class is a reference type with value equality semantics (compares content, not reference),  init(cannot be modified after initialization), with

           * =============================================================================
           * C# DATA TYPES — REFERENCE (READ ME FIRST)
           * =============================================================================
           *
           * HOW TO USE
           * -----------------------------------------------------------------------------
           * Skim the mind map above, then open Main() regions in order:
           *   #region Value data types → Predefined / User-defined
           *   #region Reference data types → Predefined / User-defined
           * Uncomment one block at a time; practise TryParse / ReadLine / new as shown.
           * Type definitions live at the bottom of this class (struct, enum, class, etc.).
           *
           * TAKEAWAY — QUICK REVISION
           * -----------------------------------------------------------------------------
           * • Value type: assignment copies the whole value (struct copy can be expensive).
           * • Reference type: assignment copies the reference; two variables can share one object.
           * • default(T): value types → zeroed; reference types → null.
           * • string is a reference type but immutable (behaves like a safe text value).
           * • Boxing: value → object/interface; Unboxing: explicit cast to exact type.
           * • Prefer generics (List<T>) over ArrayList to avoid boxing in hot paths.
           *
           * SECTIONS INDEX (maps to Main regions)
           * -----------------------------------------------------------------------------
           * 1  Value — predefined: integers, floats, char, bool, DateTime, BigInteger
           * 2  Value — user-defined: struct, enum
           * 3  Reference — predefined: string, object, dynamic, array, Func<>
           * 4  Reference — user-defined: class, interface, record class, custom delegate
           *
           * =============================================================================
           */

        #endregion C# DATA TYPES — MIND MAP & OVERVIEW

        public static void Main(string[] args)
        {
            #region Value data types

            #region Predefined value types (built-in)

            ////Signed integers (- to +)  sbyte, short, int, long
            Console.WriteLine("Enter sbyte that ranges from -128 to 127, 8 bits , -2^7 to 2^7 - 1");
            sbyte sbytevariable;
            sbyte.TryParse(Console.ReadLine(), out sbytevariable);
            Console.WriteLine("Enter short that ranges from -32,768 to 32,767, 16 bits , -2^15 to 2^15 - 1");
            short shortvariable;
            short.TryParse(Console.ReadLine(), out shortvariable);
            Console.WriteLine("Enter Integer which is from -2.1B to 2.1B , 32 bits, -2^31 to 2^31-1");
            int intvariable;
            int.TryParse(Console.ReadLine(), out intvariable);
            Console.WriteLine("Enter Long which ranges from -2^63 to 2^63-1");
            long longvariable;
            long.TryParse(Console.ReadLine(), out longvariable);

            //Unsigned integers (0 to +)
            Console.WriteLine("Enter Byte which is positive 8 bits range numbers 0 to 255");
            byte bytevariable;
            byte.TryParse(Console.ReadLine(), out bytevariable);
            Console.WriteLine("Enter Unsigned Short which ranges from 0 to 65,535, 16 bits, 0 to 2^16-1");
            ushort ushortvariable;
            ushort.TryParse(Console.ReadLine(), out ushortvariable);
            Console.WriteLine("Enter Unsigned Integer which ranges from 0 to 4.2B, 32 bits, 0 to 2^32-1");
            uint uintvariable;
            uint.TryParse(Console.ReadLine(), out uintvariable);
            Console.WriteLine("Enter Unsigned Long which ranges from 0 to 18.4B, 64 bits, 0 to 2^64-1");
            ulong ulongvariable;
            ulong.TryParse(Console.ReadLine(), out ulongvariable);

            //Floating point (f = 32 bits, d = 64 bits, m = decimal 128 bits)
            Console.WriteLine("Enter Float which ranges from -3.4E38 to 3.4E38, 32 bits");
            float floatvariable;
            float.TryParse(Console.ReadLine(), out floatvariable);
            Console.WriteLine("Enter Double which ranges from -1.7E308 to 1.7E308, 64 bits");
            double doublevariable;
            double.TryParse(Console.ReadLine(), out doublevariable);
            Console.WriteLine("Enter Decimal which ranges from -7.9E28 to 7.9E28, 128 bits");
            decimal decimalvariable;
            decimal.TryParse(Console.ReadLine(), out decimalvariable);

            //Other predefined value types
            Console.WriteLine("Enter Char which is a single Unicode character, 16 bits, U+0000 to U+FFFF");
            char charvariable;
            char.TryParse(Console.ReadLine(), out charvariable);
            Console.WriteLine("Enter bool (true/false):");
            bool boolvariable;
            bool.TryParse(Console.ReadLine(), out boolvariable);
            Console.WriteLine("Enter Date yyyy-mm-dd:");
            DateTime dateTimeVariable;
            DateTime.TryParse(Console.ReadLine(), out dateTimeVariable);
            Console.WriteLine(dateTimeVariable);

            Console.WriteLine("Enter BigInteger (arbitrary-size integer):");
            string input = Console.ReadLine();
            BigInteger bigIntegerVariable = BigInteger.Parse(input!);
            // BigInteger.TryParse(Console.ReadLine(), out bigIntegerVariable);
            Console.WriteLine(bigIntegerVariable);

            #endregion Predefined value types (built-in)

            #region User-defined value types

            ////Struct — custom value type (copied by value)
            //Console.WriteLine("Struct is a value type. Enter struct Id (int):");
            //int structId;
            //int.TryParse(Console.ReadLine(), out structId);
            //Console.WriteLine("Enter struct Label:");
            //string structLabel = Console.ReadLine() ?? "";
            //SampleStruct structVariable = new SampleStruct(structId, structLabel);
            //Console.WriteLine($"Struct Id: {structVariable.Id}, Label: {structVariable.Label}");

            ////Enum — named integral constants (underlying type, default int)
            //Console.WriteLine("Enum is a value type. Stored as integer; cast to int for numeric value.");
            //enumvariable enumVariable = enumvariable.a;
            //Console.WriteLine(enumVariable);           // prints member name
            //Console.WriteLine((int)enumVariable);      // prints underlying integer

            #endregion User-defined value types

            #endregion Value data types

            #region Reference data types

            #region Predefined reference types (built-in)

            ////string — reference type (immutable); variable holds a reference to heap data
            //Console.WriteLine("Enter string (reference type, immutable):");
            //string stringVariable = Console.ReadLine() ?? "";
            //Console.WriteLine($"String length: {stringVariable.Length}");

            ////object — reference type; can hold any reference or boxed value type
            //Console.WriteLine("Enter an int to assign to object (boxing for value types):");
            //int objectSource;
            //int.TryParse(Console.ReadLine(), out objectSource);
            //object objectVariable = objectSource;
            //Console.WriteLine($"object holds: {objectVariable}");

            ////dynamic — compile-time bypass; resolved at runtime (reference-like usage)
            //dynamic dynamicVariable = "Hello";
            //Console.WriteLine($"dynamic length: {dynamicVariable.Length}");
            //dynamicVariable = 42;
            //Console.WriteLine($"dynamic value: {dynamicVariable}");

            ////Array — all arrays are reference types (object on heap, variable holds reference)
            //Console.WriteLine("Enter array length (int):");
            //int arrayLength;
            //int.TryParse(Console.ReadLine(), out arrayLength);
            //int[] intArrayVariable = new int[arrayLength];
            //Console.WriteLine($"Array length: {intArrayVariable.Length}");

            ////Delegate (built-in delegate types) — reference type; points to one or more methods
            //Func<int, int> funcVariable = x => x * x;
            //Console.WriteLine($"Func result: {funcVariable(5)}");

            #endregion Predefined reference types (built-in)

            #region User-defined reference types

            ////class — custom reference type (variable holds reference; default is null)
            //Console.WriteLine("Class is a reference type. Enter person name:");
            //string personName = Console.ReadLine() ?? "";
            //SamplePerson personVariable = new SamplePerson(personName);
            //Console.WriteLine($"Person: {personVariable.Name}");

            ////interface — reference type for variables; implemented by a class on the heap
            //ISampleGreetable greetableVariable = new SampleGreeter("World");
            //greetableVariable.Greet();

            ////record class — reference type by default (value equality semantics)
            //SampleRecord recordVariable = new SampleRecord("Ada", 36);
            //Console.WriteLine(recordVariable);

            ////Custom delegate type — reference type declared by the user
            //SampleOperation customDelegateVariable = (a, b) => a + b;
            //Console.WriteLine($"Custom delegate: {customDelegateVariable(10, 20)}");

            #endregion User-defined reference types

            #endregion Reference data types
        }

        #region User-defined value types (definitions)

        enum enumvariable
        {
            a = 1, b = 2, c = 3
        }

        public struct SampleStruct
        {
            public int Id;
            public string Label;

            public SampleStruct(int id, string label)
            {
                Id = id;
                Label = label;
            }
        }

        #endregion User-defined value types (definitions)

        #region User-defined reference types (definitions)

        public class SamplePerson
        {
            public string Name { get; set; }

            public SamplePerson(string name) => Name = name;
        }

        public interface ISampleGreetable
        {
            void Greet();
        }

        public class SampleGreeter : ISampleGreetable
        {
            private readonly string _target;

            public SampleGreeter(string target) => _target = target;

            public void Greet() => Console.WriteLine($"Hello, {_target}!");
        }

        public record class SampleRecord(string Name, int Age);

        public delegate int SampleOperation(int a, int b);

        #endregion User-defined reference types (definitions)
    }
}
