# C# / .NET — coding practice questions (problem-style)

**~115** small programming tasks (like coding rounds / LeetCode-style), grouped by topic. Within each topic, problems are split into **Entry level** and **Advanced**. Implement in C#; use whatever structures you prefer unless noted.

---

## Strings & characters

### Entry level

1. Count frequency of each character in a string (print or return `Dictionary<char, int>`).
2. Find the first non-repeating character in a string (return index or char).
3. Check if two strings are anagrams of each other.
4. Check if a string is a palindrome (ignore spaces / punctuation optionally).
5. Reverse words in a sentence (`"hello world"` → `"world hello"`).
6. Reverse a string in place using a `char[]`.
7. Compress a string: `"aaabbc"` → `"a3b2c1"` (or return original if not shorter).
9. Implement `strStr`: find first index of needle in haystack (or -1).
11. Check balanced parentheses `()` `[]` `{}` in a string.
13. Roman numeral ↔ integer conversion.
14. Longest common prefix among an array of strings.

### Advanced

8. Check if one string is a rotation of another (e.g. `"erbottlewat"` from `"waterbottle"`).
10. Longest substring without repeating characters.
12. Convert string to integer (atoi-style) with sign and overflow rules.
15. Group anagrams: given words, group those that are anagrams.
16. Minimum window substring: smallest window of `s` containing all chars of `t`.
17. Valid palindrome after deleting at most one character.
18. Encode/decode string list with a delimiter scheme (design a simple protocol).
19. Count and say (look-and-say sequence) nth term.
20. Multiply two large numbers represented as strings.

---

## Arrays & vectors

### Entry level

21. Two sum: return indices where values add to target (assume one solution).
22. Two sum II: sorted array, use two pointers.
23. Best time to buy and sell stock (single transaction).
24. Best time to buy and sell stock II (unlimited transactions).
27. Rotate array to the right by `k` steps.
28. Merge two sorted arrays into the first (enough extra space at end).
29. Remove duplicates from sorted array in place; return new length.
30. Move all zeros to the end while preserving order of non-zeros.
31. Find missing number in `0..n` with one missing.
33. Third maximum distinct number in an array.
39. Pascal’s row or triangle up to `n`.

### Advanced

25. Maximum subarray sum (Kadane).
26. Product of array except self (without division).
32. Find all duplicates in an array (values in `1..n`).
34. Maximum product of three numbers in an array.
35. Container with most water (two pointers).
36. Trapping rain water given heights.
37. Spiral order traversal of a matrix.
38. Set matrix zeroes: if cell is 0, zero its whole row and column.
40. Next permutation of an array of integers.

---

## Hash maps, sets & frequency

### Entry level

44. Intersection of two arrays (unique elements).
45. Union of two arrays.
46. Top K frequent elements in an array.
47. Sort characters by frequency (string output).
48. Subdomain visit counts (combine `"900 discuss.leetcode.com"` style).

### Advanced

41. Longest consecutive sequence in an unsorted array (O(n) expected).
42. Subarray sum equals `k` (count subarrays).
43. Four sum II: count tuples across four arrays summing to zero.
49. Logger rate limiter: print message at most every 10 seconds per unique message.
50. Design a simple LRU cache (get/put with capacity).

---

## Linked lists (use a simple `Node` class)

### Entry level

51. Reverse a singly linked list.
53. Merge two sorted linked lists.
55. Middle of the linked list.
57. Add two numbers represented as reversed digit lists.

### Advanced

52. Detect cycle in a linked list (Floyd).
54. Remove nth node from end of list.
56. Intersection of two linked lists.

---

## Stacks & queues

### Entry level

61. Implement queue using two stacks.
62. Implement min-stack (push/pop/top/getMin in O(1)).
64. Simplify Unix-style path (`"/a/./b/../../c"`).

### Advanced

58. Valid stack sequences (push/pop of `1..n`).
59. Daily temperatures: days until warmer temperature for each day.
60. Largest rectangle in histogram.
63. Decode string: `"3[a2[c]]"` → `"accaccacc"`.

---

## Binary search & sorted logic

### Entry level

65. Binary search: classic index of target or -1.
68. Square root of integer (floor).

### Advanced

66. Search in rotated sorted array (no duplicates).
67. Find first and last position of target in sorted array.
69. Peak element in array (binary search variant).
70. Split array largest sum (binary search on answer).

---

## Recursion & backtracking (light)

### Entry level

71. Generate all subsets of a distinct integer array.
72. Generate permutations of distinct integers.

### Advanced

73. Generate valid n pairs of parentheses strings.
74. Word search on a 2D grid (DFS + backtrack).
75. Combination sum: pick numbers summing to target (reuse allowed or not — pick one variant).
76. N-Queens count or print solutions.

---

## Trees (build simple `TreeNode` if needed)

### Entry level

77. Maximum depth of binary tree.
78. Same tree: two binary trees identical?
79. Invert binary tree.
81. Level-order traversal (BFS) of binary tree.

### Advanced

80. Lowest common ancestor of two nodes in BST.
82. Validate BST.
83. Diameter of binary tree (longest path between any two nodes).
84. Serialize and deserialize binary tree.

---

## Dynamic programming (intro / medium)

### Entry level

85. Climbing stairs (1 or 2 steps at a time).
86. House robber (linear street, no two adjacent).
90. Unique paths in a grid with obstacles.

### Advanced

87. Coin change: minimum coins to make amount (or count ways).
88. Longest increasing subsequence length.
89. Edit distance between two strings.
91. Decode ways: `"12"` can be `AB` or `L` (digit mapping).

---

## Bits & math

### Entry level

92. Number of 1 bits (Hamming weight).
93. Power of two check.
94. Single number: every element appears twice except one.

### Advanced

95. Sum of two integers without `+` / `-` operators (bit tricks).
96. Reverse bits of a 32-bit integer.

---

## Design & simulation (short specs)

### Entry level

100. Iterator for nested list of integers (flatten).
101. Peeking iterator: wrap `IEnumerator` with `Peek()`.

### Advanced

97. Design `MinStack` (variant: one stack only if you want extra constraint).
98. Design hit counter: count hits in last 5 minutes (timestamp stream).
99. Design a tic-tac-toe winner checker after each move (`n×n`).

---

## Sorting & two pointers (extra)

### Entry level

102. Sort colors (Dutch national flag): 0,1,2 in place.

### Advanced

103. Merge intervals: merge overlapping `[start,end]` intervals.
104. Insert interval into sorted non-overlapping intervals.
105. 3Sum: all unique triplets that sum to zero.

---

## Graphs (basics)

### Entry level

106. Number of islands in a grid of `'1'` / `'0'`.

### Advanced

107. Course schedule: can you finish all courses (cycle detection / topo sort).
108. Clone graph (node with neighbors list).

---

## Strings / arrays (more)

### Entry level

112. Jump game: can reach last index?
114. Search a 2D matrix: each row sorted, first element of row > last of previous row.

### Advanced

109. Longest palindromic substring in a string.
110. Word break: can string be segmented by dictionary words?
111. Minimum path sum in a grid (only right/down).
113. Rotate image: 90° clockwise in place (`n×n` matrix).
115. Candy distribution (greedy) or similar fairness problem.

---

*Tip: For each problem, practice: edge cases (empty, null, single element), time/space complexity, and a clean C# signature (`ReadOnlySpan<char>` for hot string paths if you want extra practice).*
