using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.C__Practise.DataStructures.Tuples
{    
    public class TuplesTheory
    {
        public static void Main(string[] args)
        {
            // Basic Definition : Multiple values can be stored in a single variable using tuples. Tuples are **immutable**, meaning that once they are created, their values cannot be changed. Tuples can hold elements of **different data types**, and they can be used to return multiple values from a method.
            //it is a struct type, using System,  legacy tuple is a class type, using System.Tuple, but it is not recommended to use legacy tuple, because it is not as efficient as the new tuple.
            //Declaration
            (int, string) tuple = (1, "SriRama");
            (int a, char b) tuple2= (1, 'A');
            var tuple1 = (a: 1, b: 2);   //remember that var cannot be used inside a class, it can only be used inside a method or function. why?
            (int Id, string name) empty= default;  //it takes (0,null) 
            Console.WriteLine(tuple2.a);
            //Deconstructing
            var (c,d)= tuple2;
            Console.WriteLine(c);
                                       // remember how to discard while deconstructing


        }
    }
}
