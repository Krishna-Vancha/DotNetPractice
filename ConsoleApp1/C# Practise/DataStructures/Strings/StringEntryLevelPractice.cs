using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1.CSharpPractise.DataStructures.Strings;

/// <summary>
/// Empty stubs for <b>Strings &amp; characters → Entry level</b> (questions 1,2,3,4,5,6,7,9,11,13,14).
/// Implement each method; use parameterless runners in <see cref="StringEntryLevelPracticeRunners"/> to validate.
/// </summary>
public class StringEntryLevelPractice
{
    /// <summary>1. Count frequency of each character (return map).</summary>
    public static Dictionary<char, int> CharacterFrequency(string s)
    {
        throw new NotImplementedException();
    }

    /// <summary>2. First non-repeating character — return index, or -1 if none.</summary>
    public  int FirstNonRepeatingCharacterIndex(string s)
    {
        //throw new NotImplementedException();
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        foreach (var i in s)
        {
            if (charCount.ContainsKey(i))
            {

                charCount[i]++;
            }
            else
            {
                charCount[i] = 1;

            }
            
        }
        foreach (var kvp in charCount)
        {
            if (kvp.Value == 1)
            {
                return s.IndexOf(kvp.Key);
            }
        }


        return -1;

    }

    /// <summary>3. Two strings are anagrams of each other.</summary> an anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
    public static bool AreAnagrams(string a, string b)
    {
        char[] achars = a.ToCharArray();
        char[] bchars = b.ToCharArray();
        Array.Sort(achars);
        Array.Sort(bchars);

        //for (int i = 0; i < achars.Length-1; i++)
        //{ for (int j = 0; j < achars.Length-1-i; j++)
        //    {
        //        if (achars[j] > achars[j + 1])
        //        {
        //            (achars[j], achars[j + 1]) = (achars[j + 1], achars[j]);
        //        }

        //    }
        //}
        //for (int i = 0; i < bchars.Length - 1; i++)
        //{
        //    for (int j = 0; j < bchars.Length - 1-i; j++)
        //    {
        //        if (bchars[j] > bchars[j + 1])
        //        {
        //            (bchars[j], bchars[j + 1]) = (bchars[j + 1], bchars[j]);
        //        }

        //    }
        //}

        return new string(achars).Equals(new string(bchars));   //remember how to check if two arrrays are equal

       
                                                    //remember inbuilt method to sort a string 
    }


    /// <summary>4. Palindrome — optionally ignore spaces / punctuation (pick one behaviour and document it).</summary>
    public static bool IsPalindrome(string s)
    {
        string orgstr = s;
                                                                     // s.Reverse(); //remember the string reverse does not reverse the string
        return orgstr.Equals(new string(s.Reverse().ToArray()));    //why not conerted to char array
    }

    /// <summary>5. Reverse words: "hello world" → "world hello".</summary>
    public static string ReverseWords(string s)
    {
        throw new NotImplementedException();
    }

    /// <summary>6. Reverse chars in place (same array).</summary>
    public static void ReverseCharArrayInPlace(char[] chars)
    {
        throw new NotImplementedException();
    }

    /// <summary>7. Run-length style compress; return original if compressed is not shorter.</summary>
    public static string CompressString(string s)
    {
        throw new NotImplementedException();
    }

    /// <summary>9. First index of needle in haystack, or -1 (classic strStr).</summary>
    public static int StrStr(string haystack, string needle)
    {
        throw new NotImplementedException();
    }

    /// <summary>11. Balanced (), [], {}.</summary>
    public static bool HasBalancedParentheses(string s)
    {
        throw new NotImplementedException();
    }

    /// <summary>13a. Roman numeral string → integer.</summary>
    public static int RomanToInt(string roman)
    {
        throw new NotImplementedException();
    }

    /// <summary>13b. Integer → Roman numeral string.</summary>
    public static string IntToRoman(int value)
    {
        throw new NotImplementedException();
    }

    /// <summary>14. Longest common prefix across all strings (empty array → define return).</summary>
    public static string LongestCommonPrefix(string[] strs)
    {
        throw new NotImplementedException();
    }
}
