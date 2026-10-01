using System;
using System.Text;
using System.Collections.Generic;

namespace ConsoleApp1.C__Practise.PYnative.Strings;

/// <summary>
/// PYnative C# String Exercises — https://pynative.com/csharp-string-exercises/
/// Implement each method body. Run tests from StringExerciseTests or PynativeExercisesEntry.
/// </summary>
public static class StringExercises
{
    // Question 1: Write a program to find the length of a string without using the built-in .Length property.
    public static int LengthWithoutProperty(string text)
    {
        int i = 0;
        foreach (char c in text)
        {
            i++;
        }
        return i;  // Prog Ideas - can also use while(true) with **try catch**, can also convert to TocharArray
    }

    // Question 2: Accept a string and print it in reverse order.
    public static string Reverse(string text)
    { 
        StringBuilder sb = new StringBuilder(text);
        char[] array = text.ToCharArray();
        Array.Reverse(array);
        return new string(array);  //Imp Prog Rem- array reverse inbuilt func, 
    }

    // Question 3: Take a string and return its individual characters separated by a space (e.g. "Code" → "C o d e").
    public static string SeparateCharactersWithSpaces(string text)
    {
        StringBuilder sb=new StringBuilder();
        foreach(char c in text)
        {
            sb.Append(c);
            sb.Append(" ");
        }
        
        return sb.ToString().TrimEnd();  //Imp Prog Rem - Inbuilt func to remove spaces at the end, start and both of a string

    }

    // Question 4: Count the total number of vowels and consonants in a given sentence (ignore non-letters).
    public static (int Vowels, int Consonants) CountVowelsAndConsonants(string sentence)
    {
        int v = 0,cc = 0;
        foreach (char c in sentence)
        {
            if (c == 'a' || c == 'A' ||
     c == 'e' || c == 'E' ||
     c == 'i' || c == 'I' ||
     c == 'o' || c == 'O' ||
     c == 'u' || c == 'U')
            {
                v++;
            }
            else if (c == ' ' || char.IsDigit(c))
            {

            }
            else if(char.IsLetter(c)){
                cc++;
            }
        }
        return (v,cc);     //Imp Prog Rem is character is a lettr or digit
    } 

    // Question 5: Analyze a string and return counts of alphabetic letters, numeric digits, and special symbols.
    public static (int Letters, int Digits, int Special) CountCharacterTypes(string text)
        => throw new NotImplementedException();   //Imp Prog Rem  asci values of characters

    // Question 6: Toggle the case of each character (uppercase becomes lowercase and vice versa).
    public static string ToggleCase(string text)
    {
        StringBuilder SB = new StringBuilder();
        foreach (char c in text)
        {
            if (c >= 65 && c <= 90)
            {
                SB.Append((char)(c + 32));
            }
            else if (c >= 97 && c <= 122)
            {
                SB.Append((char)(c - 32));
            }
            else
            {
                SB.Append((char)(c));
            }
        }
        return SB.ToString();   //Imp Prog Rem  number to char conversion
    }

    // Question 7: Count the total number of words in a string, assuming words are separated by spaces.
    public static int CountWords(string text)
    {

        if (text.Length == 0)
        {
            return 0;
        }
        string[] words = text.Split(" ");
        return words.Length;
    }

    // Question 8: Check whether a specific substring exists inside a given string without using .Contains().
    public static bool ContainsSubstring(string text, string sub)
        => throw new NotImplementedException();

    // Question 9: Remove all leading and trailing whitespace characters manually using loops.
    public static string TrimManual(string text)
        => throw new NotImplementedException();

    // Question 10: Compare two strings character by character without using .Equals() or == on the strings themselves.
    public static bool AreEqualManual(string text1, string text2)
        => throw new NotImplementedException();

    // Question 11: Reverse the order of words in a given sentence.
    public static string ReverseWordOrder(string sentence)
    {
        StringBuilder sb = new StringBuilder();
        string[] word = sentence.Split(' ');
        Array.Reverse(word);
        return string.Join(" ",word);   ////Imp Prog Rem Array of words to string conversion 


    }

    // Question 12: Find and return the frequency of each character present in a string (each char once, in order of first appearance).
    public static IReadOnlyDictionary<char, int> CharacterFrequency(string text)
    { 
        Dictionary<char,int> dict=new Dictionary<char, int>();
        foreach(char ch in text)
        {
            if (dict.TryGetValue(ch, out int value))
            {
                dict[ch] = value + 1;
            }
            else {
                dict.Add(ch,1);
            }
        }
        return dict;    ////Imp Prog Rem  hopw to get value in a dictionary 
    }
        

    // Question 13: Identify the character that appears the maximum number of times in a given string.
    public static char MostFrequentCharacter(string text)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach (char ch in text)
        {
            if (dict.TryGetValue(ch, out int value))
            {
                dict[ch] = value + 1;
            }
            else
            {
                dict.Add(ch, 1);
            }
        }
        return dict.OrderByDescending(x=>x.Value).First().Key;      ////Imp Prog Rem  Linq to get highest value in a dictionary 
    }

    // Question 14: Extract a substring from a given starting position up to a specified length without using .Substring().
    public static string ExtractSubstring(string text, int startIndex, int length)
        => throw new NotImplementedException();

    // Question 15: Read a string and sort its characters in ascending alphabetical order.
    public static string SortCharactersAlphabetically(string text)
    {
        char[] array = text.ToCharArray();
        Array.Sort(array);
        return new string(array);
    }

    // Question 16: Remove all duplicate characters from a string, keeping only their first occurrences.
    public static string RemoveDuplicateCharacters(string text)
        => throw new NotImplementedException();

    // Question 17: Convert a given lowercase sentence so that the first letter of every word is capitalized.
    public static string ToTitleCase(string sentence)
        => throw new NotImplementedException();

    // Question 18: Determine if a string is a palindrome, ignoring case and spaces.
    public static bool IsPalindrome(string text)
        => throw new NotImplementedException();

    // Question 19: Check if two provided strings are anagrams of each other.
    public static bool AreAnagrams(string text1, string text2)
        => throw new NotImplementedException();

    // Question 20: Implement manual left and right padding for a string to reach a target length using a specific pad character.
    public static (string LeftPadded, string RightPadded) PadLeftAndRight(string text, int targetLength, char padChar)
        => throw new NotImplementedException();

    // Question 21: Generate and return all possible contiguous substrings of a given string.
    public static IReadOnlyList<string> GetAllSubstrings(string text)
        => throw new NotImplementedException();

    // Question 22: Given an array of strings, find the longest common prefix string among them.
    public static string LongestCommonPrefix(string[] words)
        => throw new NotImplementedException();

    // Question 23: Scan a string from left to right and find the very first character that does not repeat.
    public static char? FirstNonRepeatedCharacter(string text)
        => throw new NotImplementedException();

    // Question 24: Convert a numerical string into an actual int without using int.Parse() or Convert.ToInt32().
    public static int ParseIntManual(string text)
        => throw new NotImplementedException();

    // Question 25: Implement run-length encoding — store runs of repeated characters as character + count (e.g. "aabbbcccc" → "a2b3c4").
    public static string RunLengthEncode(string text)
        => throw new NotImplementedException();

    // Question 26: Check if a string containing only '(', ')', '{', '}', '[' and ']' is structurally valid.
    public static bool IsValidParentheses(string text)
        => throw new NotImplementedException();

    // Question 27: Replace all spaces in a string with "%20" efficiently using StringBuilder.
    public static string UrlEncodeSpaces(string text)
        => throw new NotImplementedException();

    // Question 28: Given two strings s1 and s2, check if s2 is a rotated version of s1.
    public static bool IsRotation(string s1, string s2)
        => throw new NotImplementedException();

    // Question 29: Create a Caesar cipher that shifts every letter in a string by a fixed number of positions down the alphabet.
    public static string CaesarCipher(string text, int shift)
        => throw new NotImplementedException();

    // Question 30: Find the length of the longest substring that contains no duplicate characters.
    public static int LongestSubstringWithoutRepeating(string text)
        => throw new NotImplementedException();
}
