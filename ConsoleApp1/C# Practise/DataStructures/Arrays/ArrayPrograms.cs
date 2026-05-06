using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.CSharpPractise.DataStructures.Arrays
{
    internal class ArrayPrograms
    {
        public static void Main(string[] args)
        {
            int[] array = new int[5] { 1,2,3,4,5};
            //int i = 0;
            //while (i < 5)
            //{
            //    array[i] = int.Parse(Console.ReadLine());
            //    i++;

            //}

            //Console.WriteLine(string.Join(",", array));
           // ReverseArray(array);
            //Console.WriteLine(string.Join(",", array));
            TwoSumProblem(array, 3);

        }
        /*1. REVERSE AN ARRAY IN-PLACE
         2.Given an array containing $n$ distinct numbers in the range $[0, n]$, find the one that is missing.
         */
        public static void ReverseArray(int[] arr)
        {  //Inbuilt Function Array.Reverse(arr);
            int i = 0, n = arr.Length;
            while (i < n / 2)
            {
                int temp = arr[i];
                arr[i] = arr[n - i - 1];
                arr[n - i - 1] = temp;
                i++;
            }

        }
        public static void FindMissingNumber(int[] arr)
        {
            int n = arr.Length;
            int sum = n * (n + 1) / 2; // Sum of first n natural numbers
            int actualSum = 0;
            for (int i = 0; i < n; i++)
            {
                actualSum += arr[i];
            }
            int missingNumber = sum - actualSum;
            Console.WriteLine($"The missing number is: {missingNumber}");


        }

        public static void TwoSumProblem(int[] arr, int target)
        {
            HashSet<int> unique= new HashSet<int>(arr);
            foreach(var i in unique)
            {
                if (unique.Contains(target - i))
                { 
                    Console.WriteLine(  i + " " + (target - i));
                    break;
                }
            }

        }


    }
}
