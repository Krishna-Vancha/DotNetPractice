using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1.C__Practise.PYnative.FileHandling;

public static class FileHandlingExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 25; i++)
            results.Add(RunExercise(i));
        results.Add(RunExercise(29));
        results.Add(RunExercise(30));
        PynativeExerciseRunner.PrintSummary("PYnative - File Handling Exercises (27)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_CreateBlankFile(),
        2 => Test02_WriteTextToFile(),
        3 => Test03_ReadEntireFile(),
        4 => Test04_AppendText(),
        5 => Test05_DeleteFile(),
        6 => Test06_ReadLineByLine(),
        7 => Test07_CopyFile(),
        8 => Test08_MoveFile(),
        9 => Test09_CountLines(),
        10 => Test10_WriteArrayOfStrings(),
        11 => Test11_FindSpecificWord(),
        12 => Test12_CsvParser(),
        13 => Test13_CountCharactersAndWords(),
        14 => Test14_DirectoryFileLister(),
        15 => Test15_FilterLines(),
        16 => Test16_BinaryWriterReader(),
        17 => Test17_UppercaseConverter(),
        18 => Test18_FindLargestFile(),
        19 => Test19_FileProperties(),
        20 => Test20_RemoveEmptyLines(),
        21 => Test21_CreateSubdirectories(),
        22 => Test22_ReverseFileContent(),
        23 => Test23_SearchFilesByExtension(),
        24 => Test24_ExceptionSafeReader(),
        25 => Test25_MergeTwoFiles(),
        29 => Test29_SecureSerialization(),
        30 => Test30_MemoryMappedFile(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "File Handling exercises are numbered 1-25 and 29-30.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_CreateBlankFile() =>
        PynativeExerciseRunner.Run(1, "Create a Blank File",
            "Check whether a file exists and, if not, create a blank text file.",
            t =>
            {
                t.Add(("missing notes.txt -> created", () =>
                    WithTempDir(dir =>
                    {
                        string path = Path.Combine(dir, "notes.txt");
                        PynativeExerciseRunner.AssertEqual(
                            "File created: " + path,
                            () => FileHandlingExercises.CreateBlankFile(path));
                        PynativeExerciseRunner.AssertTrue(File.Exists(path));
                        PynativeExerciseRunner.AssertEqualSilent(0L, new FileInfo(path).Length);
                    })));
                t.Add(("existing notes.txt -> already exists", () =>
                    WithTempDir(dir =>
                    {
                        string path = Path.Combine(dir, "notes.txt");
                        File.WriteAllText(path, "keep me");
                        PynativeExerciseRunner.AssertEqual(
                            "File already exists: " + path,
                            () => FileHandlingExercises.CreateBlankFile(path));
                        PynativeExerciseRunner.AssertEqualSilent("keep me", File.ReadAllText(path));
                    })));
            });

    public static PynativeExerciseRunner.SuiteResult Test02_WriteTextToFile() =>
        PynativeExerciseRunner.Run(2, "Write Text to File",
            "Write a name and age into user.txt.",
            t => t.Add(("Alex, 28 -> Saved to user.txt", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "user.txt");
                    PynativeExerciseRunner.AssertEqual(
                        "Saved to user.txt",
                        () => FileHandlingExercises.WriteUserInfo(path, "Alex", 28));
                    PynativeExerciseRunner.AssertEqualSilent(
                        "Name: Alex, Age: 28",
                        File.ReadAllText(path).TrimEnd('\r', '\n'));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test03_ReadEntireFile() =>
        PynativeExerciseRunner.Run(3, "Read Entire File",
            "Read and return the entire content of a text file using File.ReadAllText.",
            t => t.Add(("notes.txt -> Hello from the file!", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "notes.txt");
                    File.WriteAllText(path, "Hello from the file!");
                    PynativeExerciseRunner.AssertEqual(
                        "Hello from the file!",
                        () => FileHandlingExercises.ReadEntireFile(path));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test04_AppendText() =>
        PynativeExerciseRunner.Run(4, "Append Text",
            "Append a timestamped log line to an existing file. Format the timestamp as yyyy-MM-dd HH:mm:ss.",
            t => t.Add(("log.txt + 2026-07-13 10:42:07", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "log.txt");
                    File.WriteAllText(path, "previous entry" + Environment.NewLine);
                    var timestamp = new DateTime(2026, 7, 13, 10, 42, 7);
                    PynativeExerciseRunner.AssertEqual(
                        "Log entry appended",
                        () => FileHandlingExercises.AppendTimestampedLog(path, timestamp));
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "previous entry", "Log entry at 2026-07-13 10:42:07" },
                        File.ReadAllLines(path));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test05_DeleteFile() =>
        PynativeExerciseRunner.Run(5, "Delete a File",
            "Delete a file when it exists, and report when it does not.",
            t =>
            {
                t.Add(("temp.txt exists -> deleted", () =>
                    WithTempDir(dir =>
                    {
                        string path = Path.Combine(dir, "temp.txt");
                        File.WriteAllText(path, "temporary");
                        PynativeExerciseRunner.AssertEqual(
                            "File deleted: " + path,
                            () => FileHandlingExercises.DeleteFileIfExists(path));
                        PynativeExerciseRunner.AssertFalse(File.Exists(path));
                    })));
                t.Add(("temp.txt missing -> not found", () =>
                    WithTempDir(dir =>
                    {
                        string path = Path.Combine(dir, "temp.txt");
                        PynativeExerciseRunner.AssertEqual(
                            "File not found: " + path,
                            () => FileHandlingExercises.DeleteFileIfExists(path));
                    })));
            });

    public static PynativeExerciseRunner.SuiteResult Test06_ReadLineByLine() =>
        PynativeExerciseRunner.Run(6, "Read File Line-by-Line",
            "Read a text file line by line and prefix each line with its line number.",
            t => t.Add(("poem.txt -> numbered lines", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "poem.txt");
                    File.WriteAllLines(path, new[] { "Roses are red", "Violets are blue", "Sugar is sweet" });
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "1: Roses are red", "2: Violets are blue", "3: Sugar is sweet" },
                        () => FileHandlingExercises.ReadNumberedLines(path));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test07_CopyFile() =>
        PynativeExerciseRunner.Run(7, "Copy a File",
            "Copy a file to a destination path, overwriting the destination when it already exists.",
            t => t.Add(("report.txt -> backup/report.txt", () =>
                WithTempDir(dir =>
                {
                    string source = Path.Combine(dir, "report.txt");
                    string backup = Path.Combine(dir, "backup");
                    Directory.CreateDirectory(backup);
                    string destination = Path.Combine(backup, "report.txt");
                    File.WriteAllText(source, "quarterly report");
                    File.WriteAllText(destination, "old");
                    PynativeExerciseRunner.AssertEqual(
                        "File copied to " + destination,
                        () => FileHandlingExercises.CopyFile(source, destination));
                    PynativeExerciseRunner.AssertEqualSilent("quarterly report", File.ReadAllText(destination));
                    PynativeExerciseRunner.AssertTrue(File.Exists(source));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test08_MoveFile() =>
        PynativeExerciseRunner.Run(8, "Move/Rename a File",
            "Move a file to a new path.",
            t => t.Add(("draft.txt -> archive/draft_final.txt", () =>
                WithTempDir(dir =>
                {
                    string source = Path.Combine(dir, "draft.txt");
                    string archive = Path.Combine(dir, "archive");
                    Directory.CreateDirectory(archive);
                    string destination = Path.Combine(archive, "draft_final.txt");
                    File.WriteAllText(source, "draft body");
                    PynativeExerciseRunner.AssertEqual(
                        "File moved to " + destination,
                        () => FileHandlingExercises.MoveFile(source, destination));
                    PynativeExerciseRunner.AssertFalse(File.Exists(source));
                    PynativeExerciseRunner.AssertEqualSilent("draft body", File.ReadAllText(destination));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test09_CountLines() =>
        PynativeExerciseRunner.Run(9, "Count Lines in a File",
            "Return the total number of lines in a text file.",
            t => t.Add(("poem.txt -> 3", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "poem.txt");
                    File.WriteAllLines(path, new[] { "Roses are red", "Violets are blue", "Sugar is sweet" });
                    PynativeExerciseRunner.AssertEqual(3, () => FileHandlingExercises.CountLines(path));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test10_WriteArrayOfStrings() =>
        PynativeExerciseRunner.Run(10, "Write Array of Strings",
            "Write each shopping-list item as its own line.",
            t => t.Add(("Milk, Eggs, Bread -> shopping_list.txt", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "shopping_list.txt");
                    PynativeExerciseRunner.AssertEqual(
                        "Shopping list saved",
                        () => FileHandlingExercises.SaveShoppingList(path, new[] { "Milk", "Eggs", "Bread" }));
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "Milk", "Eggs", "Bread" },
                        File.ReadAllLines(path));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test11_FindSpecificWord() =>
        PynativeExerciseRunner.Run(11, "Find Specific Word",
            "Report the 1-based line numbers where a word occurs. The sample story has fox on lines 1 and 3.",
            t => t.Add(("story.txt word fox -> lines 1 and 3", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "story.txt");
                    File.WriteAllLines(path, new[] { "The fox ran", "Dogs play", "A fox sleeps", "Birds sing" });
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "Found on line 1", "Found on line 3" },
                        () => FileHandlingExercises.FindWordLines(path, "fox"));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test12_CsvParser() =>
        PynativeExerciseRunner.Run(12, "CSV Data Parser",
            "Parse employee name,salary rows and pad each name to 12 characters.",
            t => t.Add(("employees.csv -> padded rows", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "employees.csv");
                    File.WriteAllLines(path, new[] { "Alice,55000", "Bob,62000", "Charlie,48000" });
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "Alice".PadRight(12) + "55000", "Bob".PadRight(12) + "62000", "Charlie".PadRight(12) + "48000" },
                        () => FileHandlingExercises.FormatEmployeeCsv(path));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test13_CountCharactersAndWords() =>
        PynativeExerciseRunner.Run(13, "Count Characters and Words",
            "Count characters excluding spaces, and count words, in a text file.",
            t => t.Add(("The quick brown fox -> 16 chars, 4 words", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "sample.txt");
                    File.WriteAllText(path, "The quick brown fox");
                    var (characters, words) = FileHandlingExercises.CountCharactersAndWords(path);
                    PynativeExerciseRunner.PrintOutput(
                        $"Characters (excluding spaces): {characters}\nWords: {words}");
                    PynativeExerciseRunner.AssertEqualSilent(16, characters);
                    PynativeExerciseRunner.AssertEqualSilent(4, words);
                }))));

    public static PynativeExerciseRunner.SuiteResult Test14_DirectoryFileLister() =>
        PynativeExerciseRunner.Run(14, "Directory File Lister",
            "List each file name with its size in KB (bytes / 1024, invariant ToString).",
            t => t.Add(("report.txt 2048 bytes, notes.txt 512 bytes", () =>
                WithTempDir(dir =>
                {
                    File.WriteAllBytes(Path.Combine(dir, "report.txt"), new byte[2048]);
                    File.WriteAllBytes(Path.Combine(dir, "notes.txt"), new byte[512]);
                    string[] lines = FileHandlingExercises.ListFileSizesKb(dir)
                        .OrderBy(line => line, StringComparer.Ordinal)
                        .ToArray();
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "notes.txt - 0.5 KB", "report.txt - 2 KB" },
                        lines);
                }))));

    public static PynativeExerciseRunner.SuiteResult Test15_FilterLines() =>
        PynativeExerciseRunner.Run(15, "Filter Lines",
            "Copy lines containing Error into errors.log.",
            t => t.Add(("app.log -> two error lines", () =>
                WithTempDir(dir =>
                {
                    string source = Path.Combine(dir, "app.log");
                    string destination = Path.Combine(dir, "errors.log");
                    File.WriteAllLines(source, new[]
                    {
                        "Application started",
                        "Error: disk full",
                        "Cache refreshed",
                        "Error: timeout"
                    });
                    PynativeExerciseRunner.AssertEqual(
                        "Filtered lines saved to errors.log",
                        () => FileHandlingExercises.FilterErrorLines(source, destination));
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "Error: disk full", "Error: timeout" },
                        File.ReadAllLines(destination));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test16_BinaryWriterReader() =>
        PynativeExerciseRunner.Run(16, "Binary Writer/Reader",
            "Write an int, a double, and a string with BinaryWriter and read them back in the same order.",
            t => t.Add(("30, 19.99, Widget", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "data.bin");
                    var (age, price, name) = FileHandlingExercises.RoundTripBinary(path, 30, 19.99, "Widget");
                    PynativeExerciseRunner.PrintOutput($"{age}\n{price}\n{name}");
                    PynativeExerciseRunner.AssertEqualSilent(30, age);
                    PynativeExerciseRunner.AssertEqualSilent(19.99, Math.Round(price, 2));
                    PynativeExerciseRunner.AssertEqualSilent("Widget", name);
                }))));

    public static PynativeExerciseRunner.SuiteResult Test17_UppercaseConverter() =>
        PynativeExerciseRunner.Run(17, "Uppercase Converter",
            "Read a text file, uppercase it, and save the result to a new file.",
            t => t.Add(("Hello World -> HELLO WORLD", () =>
                WithTempDir(dir =>
                {
                    string source = Path.Combine(dir, "original.txt");
                    string destination = Path.Combine(dir, "uppercase.txt");
                    File.WriteAllText(source, "Hello World");
                    PynativeExerciseRunner.AssertEqual(
                        "Converted file saved",
                        () => FileHandlingExercises.ConvertToUppercase(source, destination));
                    PynativeExerciseRunner.AssertEqualSilent(
                        "HELLO WORLD",
                        File.ReadAllText(destination).TrimEnd('\r', '\n'));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test18_FindLargestFile() =>
        PynativeExerciseRunner.Run(18, "Find the Largest File",
            "Return the name and byte length of the largest file in a directory.",
            t => t.Add(("presentation.pptx 10240 bytes", () =>
                WithTempDir(dir =>
                {
                    File.WriteAllBytes(Path.Combine(dir, "report.txt"), new byte[2048]);
                    File.WriteAllBytes(Path.Combine(dir, "notes.txt"), new byte[512]);
                    File.WriteAllBytes(Path.Combine(dir, "presentation.pptx"), new byte[10240]);
                    PynativeExerciseRunner.AssertEqual(
                        "Largest file: presentation.pptx (10240 bytes)",
                        () => FileHandlingExercises.FindLargestFile(dir));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test19_FileProperties() =>
        PynativeExerciseRunner.Run(19, "File Properties Viewer",
            "Return creation time, last access time, and attributes. Format times as invariant yyyy-MM-dd HH:mm:ss.",
            t => t.Add(("report.txt Archive timestamps", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "report.txt");
                    var created = new DateTime(2026, 1, 5, 9, 15, 0);
                    var accessed = new DateTime(2026, 7, 13, 8, 0, 0);
                    File.WriteAllText(path, "report");
                    File.SetAttributes(path, FileAttributes.Archive);
                    File.SetCreationTime(path, created);
                    File.SetLastAccessTime(path, accessed);
                    var info = new FileInfo(path);
                    string createdText = info.CreationTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    string accessedText = info.LastAccessTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    string attributes = info.Attributes.ToString();
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[]
                        {
                            "Created: " + createdText,
                            "Last Accessed: " + accessedText,
                            "Attributes: " + attributes
                        },
                        () => FileHandlingExercises.DescribeFileProperties(path));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test20_RemoveEmptyLines() =>
        PynativeExerciseRunner.Run(20, "Remove Empty Lines",
            "Remove empty and whitespace-only lines and save the cleaned text back to the same file.",
            t => t.Add(("messy.txt -> Hello, World", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "messy.txt");
                    File.WriteAllLines(path, new[] { "Hello", "", "   ", "World" });
                    PynativeExerciseRunner.AssertEqual(
                        "Empty lines removed",
                        () => FileHandlingExercises.RemoveEmptyLines(path));
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "Hello", "World" },
                        File.ReadAllLines(path));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test21_CreateSubdirectories() =>
        PynativeExerciseRunner.Run(21, "Create Subdirectories",
            "Create a nested folder path when it does not already exist.",
            t => t.Add(("MyApp/Logs/Archive", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "MyApp", "Logs", "Archive");
                    PynativeExerciseRunner.AssertEqual(
                        "Directory structure ready: " + path,
                        () => FileHandlingExercises.EnsureDirectoryTree(path));
                    PynativeExerciseRunner.AssertTrue(Directory.Exists(path));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test22_ReverseFileContent() =>
        PynativeExerciseRunner.Run(22, "Reverse File Content",
            "Reverse the order of lines and save them to a new file.",
            t => t.Add(("First, Second, Third -> reversed", () =>
                WithTempDir(dir =>
                {
                    string source = Path.Combine(dir, "original.txt");
                    string destination = Path.Combine(dir, "reversed.txt");
                    File.WriteAllLines(source, new[] { "First", "Second", "Third" });
                    PynativeExerciseRunner.AssertEqual(
                        "Reversed content saved to reversed.txt",
                        () => FileHandlingExercises.ReverseFileLines(source, destination));
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "Third", "Second", "First" },
                        File.ReadAllLines(destination));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test23_SearchFilesByExtension() =>
        PynativeExerciseRunner.Run(23, "Search Files by Extension",
            "List file names in a directory that match a search pattern such as *.pdf.",
            t => t.Add(("*.pdf -> invoice.pdf, report.pdf", () =>
                WithTempDir(dir =>
                {
                    File.WriteAllText(Path.Combine(dir, "report.pdf"), "report");
                    File.WriteAllText(Path.Combine(dir, "invoice.pdf"), "invoice");
                    File.WriteAllText(Path.Combine(dir, "notes.txt"), "notes");
                    string[] names = FileHandlingExercises.FindFilesByExtension(dir, "*.pdf")
                        .OrderBy(name => name, StringComparer.Ordinal)
                        .ToArray();
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "invoice.pdf", "report.pdf" },
                        names);
                }))));

    public static PynativeExerciseRunner.SuiteResult Test24_ExceptionSafeReader() =>
        PynativeExerciseRunner.Run(24, "Exception Safe Reader",
            "Catch FileNotFoundException while reading, and always report that the read attempt finished.",
            t => t.Add(("missing.txt -> not found, then finished", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "missing.txt");
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "File not found: " + path, "Read attempt finished" },
                        () => FileHandlingExercises.ReadFileSafely(path));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test25_MergeTwoFiles() =>
        PynativeExerciseRunner.Run(25, "Merge Two Files",
            "Merge two files by alternating lines into a third file.",
            t => t.Add(("A1 A2 + B1 B2 -> interleaved", () =>
                WithTempDir(dir =>
                {
                    string fileA = Path.Combine(dir, "fileA.txt");
                    string fileB = Path.Combine(dir, "fileB.txt");
                    string merged = Path.Combine(dir, "merged.txt");
                    File.WriteAllLines(fileA, new[] { "A1", "A2" });
                    File.WriteAllLines(fileB, new[] { "B1", "B2" });
                    PynativeExerciseRunner.AssertEqual(
                        "Merged content saved to merged.txt",
                        () => FileHandlingExercises.MergeFilesAlternating(fileA, fileB, merged));
                    PynativeExerciseRunner.AssertSequenceEqual(
                        new[] { "A1", "B1", "A2", "B2" },
                        File.ReadAllLines(merged));
                }))));

    public static PynativeExerciseRunner.SuiteResult Test29_SecureSerialization() =>
        PynativeExerciseRunner.Run(29, "Secure Object Serialization Engine",
            "Serialize a FileCompany to JSON, AES-encrypt it to disk, then decrypt and load it back.",
            t => t.Add(("Acme Corp, Alice and Bob", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "company.dat");
                    var company = new FileCompany
                    {
                        Name = "Acme Corp",
                        Employees = new List<FileEmployee>
                        {
                            new FileEmployee { Name = "Alice" },
                            new FileEmployee { Name = "Bob" }
                        }
                    };
                    PynativeExerciseRunner.AssertEqual(
                        "Company: Acme Corp, Employees: 2",
                        () => FileHandlingExercises.SaveAndLoadEncryptedCompany(path, company));
                    string raw = Encoding.UTF8.GetString(File.ReadAllBytes(path));
                    PynativeExerciseRunner.AssertFalse(
                        raw.Contains("Acme Corp"),
                        "encrypted file should not contain the company name in plaintext");
                }))));

    public static PynativeExerciseRunner.SuiteResult Test30_MemoryMappedFile() =>
        PynativeExerciseRunner.Run(30, "Memory-Mapped File Processor",
            "Count occurrences of a byte pattern using a memory-mapped file. The site's 42 was only an illustration.",
            t => t.Add(("three ERROR tokens -> 3", () =>
                WithTempDir(dir =>
                {
                    string path = Path.Combine(dir, "huge_log.txt");
                    File.WriteAllText(path, "ERROR\nfine\nERROR ERROR\n");
                    PynativeExerciseRunner.AssertEqual(
                        3L,
                        () => FileHandlingExercises.CountMappedPattern(path, "ERROR"));
                }))));

    private static void WithTempDir(Action<string> body)
    {
        string dir = Path.Combine(Path.GetTempPath(), "PynativeFileHandling", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(dir);
        try
        {
            body(dir);
        }
        finally
        {
            if (Directory.Exists(dir))
            {
                foreach (string file in Directory.EnumerateFiles(dir, "*", SearchOption.AllDirectories))
                    File.SetAttributes(file, FileAttributes.Normal);

                Directory.Delete(dir, true);
            }
        }
    }
}
