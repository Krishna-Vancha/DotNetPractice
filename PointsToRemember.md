1. does //  // remember where this sheet comes from -------- from your `// remember` / `// Remember` / `// rem` / `#region remember` in source; two parts: Conceptual and Programming; wording is yours
2. does I open the right self-quiz first? //  // remember the opening checklist -------- quick recollection: what did I mark "remember" before drilling details
3. ―
4. does I know the verbatim string section? //  // remember String literals & comparison (topic) -------- In a verbatim `@"..."` string, how is one literal `"` written? After `Trim`/`Replace`/`Substring`, does the original variable change or a new instance? Comparing keys: which `StringComparison` default, when culture?
5. ―
6. does I know the string API self-quiz? //  // remember String APIs (StringInBuiltMethods) -------- `Replace`: one or every by default? `Split` return type, how to rejoin? `IsNullOrEmpty` vs `IsNullOrWhiteSpace`? `TrimStart`/`TrimEnd` which side, what does `Trim`? Besides `+` and interpolation, which static builds one string from pieces?
7. ―
8. does I know `StringBuilder`? //  // remember StringBuilder topic -------- `AppendFormat` mirrors which string API? `Replace` on builder: one or all, which overload limits? read/write `sb[i]`? type of slot? call before long append to reduce buffer growth? slice to string without `Substring` on full `ToString()`?
9. ―
10. does // s.Reverse(); //remember the string reverse does not reverse the string -------- `s` is unchanged; `Enumerable.Reverse` yields `IEnumerable<char>`, not a `string`—materialize: `new string(s.Reverse().ToArray())` or `string.Concat(s.Reverse())` with `using System.Linq;` (or two-pointer compare without building a second string)
11. ―
12. does I know `countArray[i]` with a `char`? //  // remember Character frequency (ASCII array) -------- `countArray[i]` with index from a `char` is valid; print back with `(char)i` for display
13. ―
14. does a verbatim `@"` string use `\"` for a quote? //  // Remember: inside @"..." a double quote is written as "" — not \". -------- use `""` in the source for one `"` in a verbatim literal
15. does `Trim` / `Replace` / `Substring` change the original? //  // Remember: Trim, Replace, Substring, etc. return a NEW string — they do not modify `original`. -------- assign the result: the variable gets a new instance, the old `string` is not edited in place
16. does keys vs display text use the same `StringComparison`? //  // Remember: OrdinalIgnoreCase is usually right for identifiers/keys; CurrentCulture matters for user-facing sort rules. -------- match the rule to the use case: keys vs user-visible text
17. does `AppendFormat` exist on `StringBuilder`? //  // Remember: AppendFormat was missing from your first pass — same role as string.Format, writes into the builder. -------- `AppendFormat` = `string.Format`-style placeholders, writes into the builder buffer
18. does `StringBuilder.Replace` replace one or all? //  // Remember: Replace swaps every occurrence in the buffer (use the startIndex+count overload to limit). -------- all matches unless you use the indexed overload
19. does `StringBuilder` allow only read `sb[i]`? //  // Remember: easy to only read sb[i] — you can assign sb[i] too. -------- each slot is `char`; you can get and set
20. does `StringBuilder` grow every append? //  // Remember: you hadn't used EnsureCapacity — optional; call before a long append loop to reduce buffer growth. -------- call `EnsureCapacity` (or set capacity) before a long loop of appends
21. does a slice of `StringBuilder` need full `ToString` then `Substring`? //  // Remember: ToString(start, length) overload is easy to miss vs building a Substring on the full ToString(). -------- `sb.ToString(index, count)` to avoid `ToString()`+`Substring` on the full text
22. ―
23. Programming: does this print after replace? //Console.WriteLine(str.Replace("Hello","HI"));  //Remeber -------- `Replace` returns a new `string` with every occurrence of the first arg replaced; print shows that new text
24. does `str.Split` in `WriteLine`? //  // remember -------- `Split` returns `string[]`; `WriteLine` prints the array representation unless you `Join` first
25. does I join with a separator? // `Console.WriteLine(string.Join(",",new string[] {"H","I" }));`   // remember convert array, List of chars or strings to string -------- `string.Join(sep, parts)` to build one `string` from many pieces
26. does I check null/whitespace? //  // remember -------- `string.IsNullOrEmpty` / `string.IsNullOrWhiteSpace` before use
27. does I trim from one side? //  // remember -------- `TrimStart` / `TrimEnd` / `Trim` on both sides
28. does I concatenate? // `string concated = string.Concat(str, "Hello");`  // remember -------- `string.Concat` or `+` or `$""` / `StringBuilder` for many appends
29. does I get a `char[]` from a `string`? // `//how to create a chars[] from a string    //rem` -------- e.g. `s.ToCharArray()` (or span when you can avoid a heap array)
30. does the key exist? // if (charCount.ContainsKey(i))                                          // remeber how to check if a key exists in a dictionary in C#?  -------- `ContainsKey` / `TryGetValue`
31. does I get the index of a char? //                 return s.IndexOf(kvp.Key);     //remember how to get the index of a character in a string in C#?  -------- `s.IndexOf(ch)`; `-1` if not found
32. does I get a key *by* value? //         }                                           //remember how to get key in dictonary using value -------- no direct lookup by value—`foreach`/`LINQ` or a second map
33. does I display a code unit as a `char`? //  // remember: cast index to char for display — (char)i -------- use `(char)i` when the index is a character code
34. ―
35. does I know 1D arrays? //  // `Points to remember about arrays` -------- single-dimensional: `T[]` / `new T[size]` / `new T[] { a,b }` / `T[] x = [ a,b ];` (collection expression)
36. does I index 2D rectangular? //  // remember -------- `T[,]`; `new T[rows, cols]`; `arr[i, j]`; `GetLength(0)` rows, `GetLength(1)` cols
37. does I use jagged `T[][]`? //  // remember -------- jagged: `T[][]`, `new T[][] { new T[] { }, new T[] { } }`; `arr[i][j]`; row `Length`, row *i* width `arr[i].Length`
38. does I confuse rectangular vs jagged? //  // remember -------- `[,]` one “rectangle” block; `[][]` an array of row arrays (rows can be ragged or null)
39. does I slice 2D like 1D range? //  // remember -------- `int[,]` has no 1D-style `arr[a..b]`; use `i,j` or copy to a 1D buffer
40. does I mix `Length` and `GetLength`? //  // remember -------- 1D `.Length` = count; `T[,] .Length` = all dims product; per dimension always `GetLength(dim)`
41. does index 0 = first? //  // remember -------- zero-based; bad index → `IndexOutOfRangeException`
42. does `T[]` resize? //  // remember -------- size fixed at creation; “resize” = new array + copy, or `Array.Resize(ref arr, newSize)`
43. does assignment copy array data? //  // remember -------- reference: two vars can reference one array; use copy/`Clone` for a new buffer
44. does `string[]` fit `object[]`? //  // remember -------- covariance: assignable, but a wrong store throws `ArrayTypeMismatchException`
45. does `Clone()` copy elements deeply? //  // remember -------- shallow: new array, same element references for reference types
46. does `arr[start..end]` and `^1`? //  // remember -------- `end` exclusive; `^1` last; slice of `T[]` allocates a new array (not a view)
47. does `params` work? //  // remember -------- last parameter `params T[]` bundles call-site values into an array
48. does I know `System.Array`? //  // remember -------- `Sort`, `BinarySearch` (sorted, else `~` index), `IndexOf`/`LastIndexOf`, `Reverse`, `Clear`, `Copy`, `Fill`, `Find*`, `ForEach`, `Empty<T>()` …
49. does I use `Span`? //  // remember -------- `arr.AsSpan()` / `AsSpan(start, length)`; or `stackalloc` span (unmanaged buffer)
50. ―
51. Add new lines below; each in one line: `does // code  // remember your exact comment  --------  solution` (no empty lines, no ` ``` ` fences)
