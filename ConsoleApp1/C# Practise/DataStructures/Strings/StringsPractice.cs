using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace ConsoleApp1.CSharpPractise.DataStructures.Strings
{
    internal class StringsPractice
    {
        // Revision checklist: `PointsToRemember.md` (repository root, next to the solution folder).

        public static void Main(string[] args)
        {
            string str = Console.ReadLine();
            //ReverseString(str);
            // StringBuilderExample();
            //Console.WriteLine(str);
            // StringExample();
            // Console.WriteLine(IsPalindrome(str));
            //CountCharacterFrequency(str);
            StringEntryLevelPractice obj = new StringEntryLevelPractice();
            Console.WriteLine(obj.FirstNonRepeatingCharacterIndex(str));
            
            // --- StringEntryLevelPractice (entry-level string problems; uncomment one at a time) ---
            // Console.WriteLine(string.Join(", ", StringEntryLevelPractice.CharacterFrequency(str ?? "")));
            // Console.WriteLine(StringEntryLevelPractice.FirstNonRepeatingCharacterIndex(str ?? ""));
            // Console.WriteLine(StringEntryLevelPractice.AreAnagrams(str ?? "", "silent"));
            // Console.WriteLine(StringEntryLevelPractice.IsPalindrome(str ?? ""));
            // Console.WriteLine(StringEntryLevelPractice.ReverseWords(str ?? "hello world"));
            // var chars = (str ?? "").ToCharArray(); StringEntryLevelPractice.ReverseCharArrayInPlace(chars); Console.WriteLine(chars);
            // Console.WriteLine(StringEntryLevelPractice.CompressString(str ?? "aaabbc"));
            // Console.WriteLine(StringEntryLevelPractice.StrStr(str ?? "hello", "ll"));
            // Console.WriteLine(StringEntryLevelPractice.HasBalancedParentheses(str ?? "()[]{}"));
            // Console.WriteLine(StringEntryLevelPractice.RomanToInt(str ?? "MCMXCIV"));
            // Console.WriteLine(StringEntryLevelPractice.IntToRoman(1994));
            // Console.WriteLine(StringEntryLevelPractice.LongestCommonPrefix(new[] { "flower", "flow", "flight" }));
            ;
        }

        public static void FindFirstNonRepeatedCharacter(string str)
        {
            Dictionary<char,int> countDictonary=new Dictionary<char,int>();
            foreach (char c in str)
            {
            }
        }
        public static void StringExample()
        {
            int count = 3;
            string name = "Ann";

            // $ — interpolation (expressions inside { ... })
            string interpolated = $"Hello, {name}! Count={count}, double={count * 2}";
            Console.WriteLine(interpolated);

            // @ — verbatim string: backslashes are literal (paths, regex); newlines allowed if you actually break the line in source
            string path = @"C:\Users\data\file.txt";
            string withQuote = @"He said ""Hi"" to the file.";
            Console.WriteLine(path);
            Console.WriteLine(withQuote);

            // Ordinary string — escape sequences
            string escaped = "Line A\nLine B\tIndented\\Backslash\"Quoted\"";
            Console.WriteLine(escaped);

            // """ raw string literal (C# 11+) — good for multi-line, JSON/XML, fewer escapes
            string raw = """
                SELECT *
                FROM "Orders"
                WHERE Id > 10
                """;
            Console.WriteLine(raw);


            // string.Format — same placeholders as AppendFormat; useful when format comes from config/resources
            string formatted = string.Format(CultureInfo.InvariantCulture, "Pi ≈ {0:F4}", Math.PI);
            Console.WriteLine(formatted);

            string original = "  hello  ";
            string trimmed = original.Trim();
            Console.WriteLine($"same ref? {ReferenceEquals(original, trimmed)}"); // false

            string padded = "7".PadLeft(3, '0');
            Console.WriteLine(padded);

            bool same = string.Equals("abc", "ABC", StringComparison.OrdinalIgnoreCase);
            Console.WriteLine(same);
        }

        /*
         * Recollect (name the property or method):
         * 1. How do you get the length of a string?
         * 2. How do you check if a string starts with a given substring?
         * 3. How do you check if a string ends with a given substring?
         * 4. How do you find the index of a substring (first occurrence)?
         * 5. How do you replace one substring with another?
         * 6. How do you remove leading and trailing whitespace?
         * 7. How do you split a string into parts by a separator?
         * 8. How do you join an array (or IEnumerable) of strings with a separator?
         * 9. How do you take a portion of a string (by start index and length)?
         * 10. How do you test if a string is null, empty, or only whitespace?
         * 11. How do you convert a string to lowercase?
         * 12. How do you check if a string contains a substring?
         * 13. How do you test only null or empty (not spaces/tabs)?
         * 14. How do you find the last index of a substring?
         * 15. How do you convert a string to uppercase?
         * 16. How do you trim only the start or only the end?  
         * 17. How do you insert text at a given index, or remove a range of characters?
         * 18. How do you pad a string on the left or right to a minimum width?
         * 19. How do you convert a string to a char array?
         * 20. How do you concatenate several strings (static helper on string)?
         * 21. How do you format a composite string with placeholders (e.g. indices or names)?
         * 22. How do you compare two strings (ordinal, or ignoring case)?
         */

        public static void StringInBuiltMethods(string str)
        {
            Console.WriteLine(str.Length + "Length");
            Console.WriteLine(str.StartsWith("A"));
            Console.WriteLine(str.EndsWith("A"));
            Console.WriteLine(str.IndexOf("axe"));
            Console.WriteLine(str.LastIndexOf("axe"));
            Console.WriteLine(str.Replace("Hello","HI"));
            Console.WriteLine(str.Trim());
            Console.WriteLine(str.Split(','));
            Console.WriteLine(string.Join(",",new string[] {"H","I" }));
            Console.WriteLine(str.Substring(3,10));
            Console.WriteLine(string.IsNullOrWhiteSpace(str));
            Console.WriteLine(str.ToLower());
            Console.WriteLine(str.Contains("HI"));
            Console.WriteLine(string.IsNullOrEmpty(str));
            Console.WriteLine(str.TrimStart());
            Console.WriteLine(str.Insert(2,"Hello"));
            char[] chars = str.ToCharArray();
            string concated = string.Concat(str, "Hello");
            
            Console.WriteLine(string.Equals(str, concated, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


        }

        public static void ReverseString(string str)
        {
            char[] chars = str.ToCharArray();
            char temp;
            for (int i = 0; i < chars.Length / 2; i++)
            {    temp= chars[i]; 
                chars[i] = chars[chars.Length - i-1];
                chars[chars.Length - i-1] = temp;

            }
            str.Reverse();
            Console.WriteLine(string.Join(',',chars));


        }

        /*
         * StringBuilder — recollect (name the constructor overload, property, or method):
         * 1. How do you create an empty StringBuilder, optionally with initial capacity or starting text?
         * 2. How do you append text, numbers, or lines (including a line break)?
         * 3. How do you append formatted text (like String.Format) in one call?
         * 4. How do you insert text at a given index?
         * 5. How do you remove a range of characters (by start index and length)?
         * 6. How do you replace a substring inside the buffer (all occurrences)?
         * 7. How do you clear all content but keep the internal buffer for reuse?
         * 8. How do you read or set the character at a specific index?
         * 9. How do you get the current length vs. capacity vs. maximum capacity?
         * 10. How do you grow or reserve capacity before a large append loop?
         * 11. How do you get a normal string from the StringBuilder when you are done?
         */

        //the use of StringBuilder is recommended when you have to do a lot of modifications to a string, as it is more efficient than creating new string instances for each modification.
        public static void StringBuilderExample()
        {
            StringBuilder sb = new StringBuilder(); // new StringBuilder("seed"), (capacity), ("seed", capacity)

            sb.Append("Hello");
           
            sb.AppendLine(" world");
            sb.AppendFormat(" [{0:D2}-{1}]", 3, 2026); 

            Console.WriteLine("--- after Append / AppendLine / AppendFormat ---");
            Console.WriteLine(sb);

            sb.Insert(0, ">>> ");
            sb.Replace("world", "there");

            sb.Remove(3, 4);

            char c = sb[1];
            if (sb.Length > 1)
                sb[1] = char.ToUpperInvariant(c);

            _ = sb.Length;
            _ = sb.Capacity;
            _ = sb.MaxCapacity;

            sb.EnsureCapacity(256);

            Console.WriteLine("--- Length / Capacity (after EnsureCapacity) ---");
            Console.WriteLine($"Length={sb.Length}, Capacity={sb.Capacity}");

            string full = sb.ToString();
            string slice = sb.ToString(0, Math.Min(5, sb.Length));

            Console.WriteLine(full);
            Console.WriteLine("slice: " + slice);

            
            sb.Clear();
            sb.Append("reused");
            Console.WriteLine("after Clear + Append: " + sb.ToString());
        }

        #region
        //Palindrome check with and without inbuilt 
        public static bool IsPalindrome(string str)
        {
            string revstr="";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                revstr+=string.Concat(str[i]); 
            }

            return ((str) == revstr)? true : false;

        }
        #endregion
        #region
        public static void CountCharacterFrequency(string str)
        {
            //using dictonary
            //Dictionary<char, int> countDictonary = new Dictionary<char, int>();
            //foreach(char i in str)
            //{  if (countDictonary.ContainsKey(i))
            //    {
            //        countDictonary[i]++;
            //    }
            //    else {
            //        countDictonary[i]=1; 
            //    }
            //}
            //foreach (var pair in countDictonary)
            //{
            //    Console.WriteLine("Character"+pair.Key+" "+"Frequency"+ pair.Value);
            //} 

            //using array of 256 size for ASCII characters 
            int[] countArray = new int[256];
            foreach (char i in str)
            {
                countArray[i]++;
            }
            for(int i=0; i<countArray.Length; i++)
            {
                if (countArray[i] > 0)
                {
                    Console.WriteLine("Char " + (char)i + " Frequency " + countArray[i]);

                }
            }


        }
        #endregion
    }
}

