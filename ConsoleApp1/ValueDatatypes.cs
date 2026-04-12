using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class ValueDatatypes
    {
        public static void Main()
        {
            // Value types in C# include:
            // - int
            // - double
            // - bool
            // - char
            // - struct (custom value types)
            // - enum (enumerations)
            int myInt = 42;
            double myDouble = 3.14;
            bool myBool = true;
            char myChar = 'A';
            Console.WriteLine($"Integer: {myInt}");
            Console.WriteLine($"Double: {myDouble}");
            Console.WriteLine($"Boolean: {myBool}");
            Console.WriteLine($"Character: {myChar}");
        }

    }
}
