using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.C__Practise.C_Basics
{
    public class Strings
    {
        public static void Main(string[] args)
        {
            string s= "  Hello World  ";
            Console.WriteLine(s.Length);
            Console.WriteLine("Trimming"+s.Trim());
            Console.WriteLine("To upper and To lower" + s.ToLower() + s.ToUpper());
            Console.WriteLine("Substring" + s.Substring(2,9));
            Console.WriteLine("Index of"+ s.IndexOf("World"));
            Console.WriteLine("Contains"+ s.Contains("World"));
            Console.WriteLine("Replace"+ s.Replace("Hello","Holla"));
            Console.WriteLine("Split " + s.Split(' '));
            Console.WriteLine("Split join"+ string.Join(",", s.Split(' ')));
            Console.WriteLine("Starts with Ends With "+ s.StartsWith("Holla") + s.EndsWith("World"));
            Console.WriteLine("string null or empty or white space" + string.IsNullOrEmpty(s)+ string.IsNullOrWhiteSpace(s));
          Console.WriteLine(s.Equals("holla world", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Add extra space at the beggining"+ s.PadLeft(20));
            Console.WriteLine("To Char Array"+ s.ToCharArray());
            Console.WriteLine();


            StringBuilder sb=new StringBuilder();
            sb.Append("Holla");
            sb.Insert(3," Hello ");
            Console.WriteLine(sb);
            Console.WriteLine(sb.Length  + sb.Capacity);
            Console.WriteLine(sb.ToString());
        }
    }
}
