using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.Collections;

public static class CollectionExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 30; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative — Collections Exercises (30)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_TopThreeScores(),
        2 => Test02_RemoveDuplicateNames(),
        3 => Test03_Shuffle(),
        4 => Test04_Inventory(),
        5 => Test05_Interleave(),
        6 => Test06_CountWords(),
        7 => Test07_TrackSession(),
        8 => Test08_AddCity(),
        9 => Test09_FlipDepartments(),
        10 => Test10_CheckoutTotal(),
        11 => Test11_ProcessPrintQueue(),
        12 => Test12_AdmitTickets(),
        13 => Test13_BreadthFirstSearch(),
        14 => Test14_IsBalanced(),
        15 => Test15_UndoLastWord(),
        16 => Test16_ToBinary(),
        17 => Test17_UniqueVisitors(),
        18 => Test18_MutualFriends(),
        19 => Test19_AddUniqueTags(),
        20 => Test20_FindMissingNumber(),
        21 => Test21_ExclusiveInterests(),
        22 => Test22_DescendingLeaderboard(),
        23 => Test23_ProcessByPriority(),
        24 => Test24_AlphabetizeContacts(),
        25 => Test25_ConcurrentLogCount(),
        26 => Test26_CreateSystemConfig(),
        27 => Test27_EmailsBelowSalary(),
        28 => Test28_AveragePriceByCategory(),
        29 => Test29_Paginate(),
        30 => Test30_SortByGradeThenLastName(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Collections exercises are numbered 1–30.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_TopThreeScores() =>
        PynativeExerciseRunner.Run(1, "Finding the Top 3 Scores",
            "Find and display the top 3 highest scores.",
            t => t.Add(("88, 95, 70, 100, 65, 90, 78 -> 100, 95, 90", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 100, 95, 90 },
                    () => CollectionExercises.TopThreeScores(new[] { 88, 95, 70, 100, 65, 90, 78 })))));

    public static PynativeExerciseRunner.SuiteResult Test02_RemoveDuplicateNames() =>
        PynativeExerciseRunner.Run(2, "Removing Duplicate Names",
            "Remove duplicate names in place without creating a second result list.",
            t => t.Add(("Alice, Bob, Alice, Charlie, Bob, Dave", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Alice", "Bob", "Charlie", "Dave" },
                    () => CollectionExercises.RemoveDuplicateNames(
                        new List<string> { "Alice", "Bob", "Alice", "Charlie", "Bob", "Dave" })))));

    public static PynativeExerciseRunner.SuiteResult Test03_Shuffle() =>
        PynativeExerciseRunner.Run(3, "Shuffling a Playlist",
            "Fisher-Yates shuffle. The order is random, so the test checks that the result is a permutation.",
            t => t.Add(("Song A through Song E", () =>
            {
                string[] original = { "Song A", "Song B", "Song C", "Song D", "Song E" };
                var shuffled = CollectionExercises.Shuffle(original);
                PynativeExerciseRunner.PrintOutput(string.Join(", ", shuffled));
                PynativeExerciseRunner.AssertSequenceEqual(original.OrderBy(song => song), shuffled.OrderBy(song => song));
            })));

    public static PynativeExerciseRunner.SuiteResult Test04_Inventory() =>
        PynativeExerciseRunner.Run(4, "Managing a Product Inventory",
            "Add products, set the Mouse quantity to 0, then remove out-of-stock items.",
            t => t.Add(("Keyboard 10, Mouse 5, Monitor 2", () =>
            {
                var inventory = new List<CollectionInventoryProduct>
                {
                    new CollectionInventoryProduct(1, "Keyboard", 10),
                    new CollectionInventoryProduct(2, "Mouse", 5),
                    new CollectionInventoryProduct(3, "Monitor", 2),
                };
                CollectionExercises.UpdateQuantity(inventory, 2, 0);
                PynativeExerciseRunner.PrintOutput(string.Join(", ", inventory));
                PynativeExerciseRunner.AssertEqualSilent(0, inventory[1].Quantity);
                CollectionExercises.RemoveOutOfStock(inventory);
                PynativeExerciseRunner.PrintOutput(string.Join(", ", inventory));
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "Keyboard", "Monitor" }, inventory.Select(product => product.Name));
            })));

    public static PynativeExerciseRunner.SuiteResult Test05_Interleave() =>
        PynativeExerciseRunner.Run(5, "Merging Two Lists",
            "Merge two equal-length lists by alternating elements.",
            t => t.Add(("1,3,5,7 with 2,4,6,8", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4, 5, 6, 7, 8 },
                    () => CollectionExercises.Interleave(new[] { 1, 3, 5, 7 }, new[] { 2, 4, 6, 8 })))));

    public static PynativeExerciseRunner.SuiteResult Test06_CountWords() =>
        PynativeExerciseRunner.Run(6, "Counting Word Frequency",
            "Count how many times each word appears in a paragraph.",
            t => t.Add(("the quick brown fox jumps over the lazy dog the fox runs", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "the=3", "quick=1", "brown=1", "fox=2", "jumps=1", "over=1", "lazy=1", "dog=1", "runs=1" },
                    () => CollectionExercises.CountWords("the quick brown fox jumps over the lazy dog the fox runs")
                        .Select(pair => $"{pair.Key}={pair.Value}")))));

    public static PynativeExerciseRunner.SuiteResult Test07_TrackSession() =>
        PynativeExerciseRunner.Run(7, "Tracking User Sessions",
            "Log in jdoe under a fixed session id, look the user up, then log out.",
            t => t.Add(("login 1, found jdoe, logout 0", () =>
            {
                var (afterLogin, username, afterLogout) = CollectionExercises.TrackSession(
                    Guid.Parse("11111111-1111-1111-1111-111111111111"), "jdoe");
                PynativeExerciseRunner.PrintOutput($"login={afterLogin}, user={username}, logout={afterLogout}");
                PynativeExerciseRunner.AssertEqualSilent(1, afterLogin);
                PynativeExerciseRunner.AssertEqualSilent("jdoe", username);
                PynativeExerciseRunner.AssertEqualSilent(0, afterLogout);
            })));

    public static PynativeExerciseRunner.SuiteResult Test08_AddCity() =>
        PynativeExerciseRunner.Run(8, "Grouping Cities by Country",
            "Add New York, Los Angeles, and Chicago to USA, and Tokyo to Japan.",
            t => t.Add(("USA three cities, Japan one", () =>
            {
                var cities = new Dictionary<string, List<string>>();
                CollectionExercises.AddCity(cities, "USA", "New York");
                CollectionExercises.AddCity(cities, "USA", "Los Angeles");
                CollectionExercises.AddCity(cities, "Japan", "Tokyo");
                CollectionExercises.AddCity(cities, "USA", "Chicago");
                PynativeExerciseRunner.PrintOutput(string.Join(" | ", cities.Select(pair => $"{pair.Key}: {string.Join(", ", pair.Value)}")));
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "New York", "Los Angeles", "Chicago" }, cities["USA"]);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "Tokyo" }, cities["Japan"]);
            })));

    public static PynativeExerciseRunner.SuiteResult Test09_FlipDepartments() =>
        PynativeExerciseRunner.Run(9, "Flipping a Dictionary",
            "Flip employee id -> department into department -> employee ids.",
            t => t.Add(("E1..E5", () =>
            {
                var flipped = CollectionExercises.FlipDepartments(new Dictionary<string, string>
                {
                    ["E1"] = "Engineering",
                    ["E2"] = "Sales",
                    ["E3"] = "Engineering",
                    ["E4"] = "Marketing",
                    ["E5"] = "Sales",
                });
                PynativeExerciseRunner.PrintOutput(string.Join(" | ", flipped.Select(pair => $"{pair.Key}: {string.Join(", ", pair.Value)}")));
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "E1", "E3" }, flipped["Engineering"]);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "E2", "E5" }, flipped["Sales"]);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "E4" }, flipped["Marketing"]);
            })));

    public static PynativeExerciseRunner.SuiteResult Test10_CheckoutTotal() =>
        PynativeExerciseRunner.Run(10, "Calculating a Shopping Cart Total",
            "Look up Apple 0.50, Bread 2.50, and Milk 1.75 for the scanned items. Total is $7.75.",
            t => t.Add(("Apple, Bread, Apple, Milk, Bread -> 7.75", () =>
                PynativeExerciseRunner.AssertEqual(7.75, () =>
                    Math.Round(CollectionExercises.CheckoutTotal(
                        new Dictionary<string, double> { ["Apple"] = 0.50, ["Bread"] = 2.50, ["Milk"] = 1.75 },
                        new[] { "Apple", "Bread", "Apple", "Milk", "Bread" }), 2)))));

    public static PynativeExerciseRunner.SuiteResult Test11_ProcessPrintQueue() =>
        PynativeExerciseRunner.Run(11, "Simulating a Printer Queue",
            "Print Report.docx, Invoice.pdf, and Photo.png in arrival order.",
            t => t.Add(("FIFO print order", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Report.docx", "Invoice.pdf", "Photo.png" },
                    () => CollectionExercises.ProcessPrintQueue(new[] { "Report.docx", "Invoice.pdf", "Photo.png" })))));

    public static PynativeExerciseRunner.SuiteResult Test12_AdmitTickets() =>
        PynativeExerciseRunner.Run(12, "Limiting a Support Ticket Queue",
            "Capacity 3. Ticket1 through Ticket3 are accepted. Ticket4 is rejected.",
            t => t.Add(("final size 3", () =>
            {
                var (decisions, finalCount) = CollectionExercises.AdmitTickets(3, new[] { "Ticket1", "Ticket2", "Ticket3", "Ticket4" });
                PynativeExerciseRunner.PrintOutput(string.Join(" | ", decisions) + $" count={finalCount}");
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Ticket1: Accepted", "Ticket2: Accepted", "Ticket3: Accepted", "Ticket4: Rejected (queue is full)" },
                    decisions);
                PynativeExerciseRunner.AssertEqualSilent(3, finalCount);
            })));

    public static PynativeExerciseRunner.SuiteResult Test13_BreadthFirstSearch() =>
        PynativeExerciseRunner.Run(13, "Breadth-First Search with a Queue",
            "Visit a tree rooted at 1, where 1 -> {2, 3}, 2 -> {4, 5}, 3 -> {6}.",
            t => t.Add(("visit order 1, 2, 3, 4, 5, 6", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 1, 2, 3, 4, 5, 6 },
                    () => CollectionExercises.BreadthFirstSearch(new Dictionary<int, List<int>>
                    {
                        [1] = new List<int> { 2, 3 },
                        [2] = new List<int> { 4, 5 },
                        [3] = new List<int> { 6 },
                        [4] = new List<int>(),
                        [5] = new List<int>(),
                        [6] = new List<int>(),
                    }, 1)))));

    public static PynativeExerciseRunner.SuiteResult Test14_IsBalanced() =>
        PynativeExerciseRunner.Run(14, "Checking Balanced Parentheses",
            "Decide whether parentheses, braces, and brackets are properly balanced.",
            t =>
            {
                t.Add(("([]{}) -> true", () =>
                    PynativeExerciseRunner.AssertTrue(() => CollectionExercises.IsBalanced("([]{})"))));
                t.Add(("([)] -> false", () =>
                    PynativeExerciseRunner.AssertFalse(() => CollectionExercises.IsBalanced("([)]"))));
            });

    public static PynativeExerciseRunner.SuiteResult Test15_UndoLastWord() =>
        PynativeExerciseRunner.Run(15, "Building an Undo Stack",
            "Type Hello, World, and Foo, then undo once.",
            t => t.Add(("removed Foo, buffer Hello World", () =>
            {
                var (removed, buffer) = CollectionExercises.UndoLastWord(new[] { "Hello", "World", "Foo" });
                PynativeExerciseRunner.PrintOutput($"removed={removed}, buffer={string.Join(" ", buffer)}");
                PynativeExerciseRunner.AssertEqualSilent("Foo", removed);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "Hello", "World" }, buffer);
            })));

    public static PynativeExerciseRunner.SuiteResult Test16_ToBinary() =>
        PynativeExerciseRunner.Run(16, "Converting Decimal to Binary with a Stack",
            "Convert 26 to binary using a stack.",
            t => t.Add(("26 -> 11010", () =>
                PynativeExerciseRunner.AssertEqual("11010", () => CollectionExercises.ToBinary(26)))));

    public static PynativeExerciseRunner.SuiteResult Test17_UniqueVisitors() =>
        PynativeExerciseRunner.Run(17, "Logging Unique IP Addresses",
            "Six visits from three unique IP addresses.",
            t => t.Add(("6 visits, 3 unique", () =>
            {
                var (total, unique) = CollectionExercises.UniqueVisitors(new[]
                {
                    "192.168.1.1", "192.168.1.2", "192.168.1.1", "10.0.0.5", "192.168.1.2", "10.0.0.5",
                });
                PynativeExerciseRunner.PrintOutput($"total={total}, unique={string.Join(", ", unique)}");
                PynativeExerciseRunner.AssertEqualSilent(6, total);
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "192.168.1.1", "192.168.1.2", "10.0.0.5" }, unique);
            })));

    public static PynativeExerciseRunner.SuiteResult Test18_MutualFriends() =>
        PynativeExerciseRunner.Run(18, "Finding Mutual Friends",
            "Intersection of Alice/Bob/Charlie/Dave and Bob/Dave/Eve/Frank.",
            t => t.Add(("Bob, Dave", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Bob", "Dave" },
                    () => CollectionExercises.MutualFriends(
                        new[] { "Alice", "Bob", "Charlie", "Dave" },
                        new[] { "Bob", "Dave", "Eve", "Frank" })))));

    public static PynativeExerciseRunner.SuiteResult Test19_AddUniqueTags() =>
        PynativeExerciseRunner.Run(19, "Keeping Tags Unique",
            "Add tags with a case-insensitive set. Later case variants are duplicates.",
            t => t.Add(("CSharp, dotnet, csharp, DotNet, Programming", () =>
            {
                var (log, tags) = CollectionExercises.AddUniqueTags(
                    new[] { "CSharp", "dotnet", "csharp", "DotNet", "Programming" });
                PynativeExerciseRunner.PrintOutput(string.Join(" | ", log));
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Added: CSharp", "Added: dotnet", "Skipped duplicate: csharp", "Skipped duplicate: DotNet", "Added: Programming" },
                    log);
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "CSharp", "dotnet", "Programming" }, tags);
            })));

    public static PynativeExerciseRunner.SuiteResult Test20_FindMissingNumber() =>
        PynativeExerciseRunner.Run(20, "Finding a Missing Number",
            "Numbers from 1 to 6 with 3 missing.",
            t => t.Add(("1, 2, 4, 5, 6 -> 3", () =>
                PynativeExerciseRunner.AssertEqual(3, () => CollectionExercises.FindMissingNumber(6, new[] { 1, 2, 4, 5, 6 })))));

    public static PynativeExerciseRunner.SuiteResult Test21_ExclusiveInterests() =>
        PynativeExerciseRunner.Run(21, "Finding Exclusive Interests",
            "Interests that belong to exactly one of the two students, sorted alphabetically.",
            t => t.Add(("Cooking, Music, Painting, Reading", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Cooking", "Music", "Painting", "Reading" },
                    () => CollectionExercises.ExclusiveInterests(
                        new[] { "Reading", "Gaming", "Hiking", "Cooking" },
                        new[] { "Gaming", "Painting", "Hiking", "Music" })))));

    public static PynativeExerciseRunner.SuiteResult Test22_DescendingLeaderboard() =>
        PynativeExerciseRunner.Run(22, "Building a Sorted Leaderboard",
            "Keep scores sorted from highest to lowest as they are added: 85, 92, 77, 100, 68.",
            t => t.Add(("100, 92, 85, 77, 68", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { 100, 92, 85, 77, 68 },
                    () => CollectionExercises.DescendingLeaderboard(new[] { 85, 92, 77, 100, 68 })))));

    public static PynativeExerciseRunner.SuiteResult Test23_ProcessByPriority() =>
        PynativeExerciseRunner.Run(23, "Processing Tasks by Priority",
            "Process tasks by priority (0 is critical), not by arrival order.",
            t => t.Add(("Server outage, Refactor code, Review PR, Update docs", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Server outage", "Refactor code", "Review PR", "Update docs" },
                    () => CollectionExercises.ProcessByPriority(new[]
                    {
                        ("Update docs", 3),
                        ("Server outage", 0),
                        ("Review PR", 2),
                        ("Refactor code", 1),
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test24_AlphabetizeContacts() =>
        PynativeExerciseRunner.Run(24, "Keeping Contacts Alphabetized",
            "Charlie, Alice, then Bob are stored and listed alphabetically by name.",
            t => t.Add(("Alice, Bob, Charlie", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Alice: 555-0001", "Bob: 555-0002", "Charlie: 555-0003" },
                    () => CollectionExercises.AlphabetizeContacts(new[]
                    {
                        new KeyValuePair<string, string>("Charlie", "555-0003"),
                        new KeyValuePair<string, string>("Alice", "555-0001"),
                        new KeyValuePair<string, string>("Bob", "555-0002"),
                    })))));

    public static PynativeExerciseRunner.SuiteResult Test25_ConcurrentLogCount() =>
        PynativeExerciseRunner.Run(25, "Logging Safely from Multiple Threads",
            "3 threads each write 5 log lines. The queue count is 15.",
            t => t.Add(("3 x 5 -> 15", () =>
                PynativeExerciseRunner.AssertEqual(15, () => CollectionExercises.ConcurrentLogCount(3, 5)))));

    public static PynativeExerciseRunner.SuiteResult Test26_CreateSystemConfig() =>
        PynativeExerciseRunner.Run(26, "Exposing a Read-Only List",
            "Initial settings are MaxUsers=100 and Theme=Dark. AddSetting(\"Timeout=30\") shows up in the read-only view.",
            t => t.Add(("before 2 settings, after Timeout=30", () =>
            {
                var config = CollectionExercises.CreateSystemConfig();
                PynativeExerciseRunner.AssertSequenceEqual(new[] { "MaxUsers=100", "Theme=Dark" }, config.Settings);
                config.AddSetting("Timeout=30");
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "MaxUsers=100", "Theme=Dark", "Timeout=30" }, config.Settings);
            })));

    public static PynativeExerciseRunner.SuiteResult Test27_EmailsBelowSalary() =>
        PynativeExerciseRunner.Run(27, "Filtering and Selecting with LINQ",
            "Emails of employees earning under $50,000.",
            t => t.Add(("Bob and Dave", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "bob@company.com", "dave@company.com" },
                    () => CollectionExercises.EmailsBelowSalary(new[]
                    {
                        new CollectionEmployee("Alice", 85000, "alice@company.com"),
                        new CollectionEmployee("Bob", 42000, "bob@company.com"),
                        new CollectionEmployee("Charlie", 55000, "charlie@company.com"),
                        new CollectionEmployee("Dave", 38000, "dave@company.com"),
                    }, 50000)))));

    public static PynativeExerciseRunner.SuiteResult Test28_AveragePriceByCategory() =>
        PynativeExerciseRunner.Run(28, "Grouping and Averaging with LINQ",
            "Average price per category. Electronics is $408.00 and Furniture is $120.00.",
            t => t.Add(("5 products", () =>
            {
                var averages = CollectionExercises.AveragePriceByCategory(new[]
                {
                    new CollectionPricedProduct("Laptop", "Electronics", 999),
                    new CollectionPricedProduct("Mouse", "Electronics", 25),
                    new CollectionPricedProduct("Desk", "Furniture", 150),
                    new CollectionPricedProduct("Chair", "Furniture", 90),
                    new CollectionPricedProduct("Monitor", "Electronics", 200),
                });
                PynativeExerciseRunner.PrintOutput(string.Join(", ", averages.Select(row => $"{row.Category}:{row.AveragePrice}")));
                PynativeExerciseRunner.AssertEqualSilent("Electronics", averages[0].Category);
                PynativeExerciseRunner.AssertEqualSilent(408m, Math.Round(averages[0].AveragePrice, 2));
                PynativeExerciseRunner.AssertEqualSilent("Furniture", averages[1].Category);
                PynativeExerciseRunner.AssertEqualSilent(120m, Math.Round(averages[1].AveragePrice, 2));
            })));

    public static PynativeExerciseRunner.SuiteResult Test29_Paginate() =>
        PynativeExerciseRunner.Run(29, "Paginating a List with LINQ",
            "Page 2 of 50 items with a page size of 10 is items 11 through 20.",
            t => t.Add(("page 2 size 10 -> 11..20", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    Enumerable.Range(11, 10),
                    () => CollectionExercises.Paginate(Enumerable.Range(1, 50), 10, 2)))));

    public static PynativeExerciseRunner.SuiteResult Test30_SortByGradeThenLastName() =>
        PynativeExerciseRunner.Run(30, "Sorting by Multiple Fields",
            "Sort by grade descending, then by last name ascending.",
            t => t.Add(("Dave Brown, Bob Jones, Charlie Adams, Alice Smith, Eve Clark", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Dave Brown (Grade: 95)",
                        "Bob Jones (Grade: 95)",
                        "Charlie Adams (Grade: 90)",
                        "Alice Smith (Grade: 90)",
                        "Eve Clark (Grade: 85)",
                    },
                    () => CollectionExercises.SortByGradeThenLastName(new[]
                    {
                        new CollectionStudent("Alice", "Smith", 90),
                        new CollectionStudent("Bob", "Jones", 95),
                        new CollectionStudent("Charlie", "Adams", 90),
                        new CollectionStudent("Dave", "Brown", 95),
                        new CollectionStudent("Eve", "Clark", 85),
                    }).Select(student => student.ToString())))));
}
