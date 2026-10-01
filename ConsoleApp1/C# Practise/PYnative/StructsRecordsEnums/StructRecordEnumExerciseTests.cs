using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.C__Practise.PYnative.StructsRecordsEnums;

public static class StructRecordEnumExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 25; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative - Structs, Records & Enums Exercises (25)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_WeekdayOrWeekend(),
        2 => Test02_NextTrafficLight(),
        3 => Test03_ByteErrorCodes(),
        4 => Test04_PermissionFlags(),
        5 => Test05_ParseEnum(),
        6 => Test06_ListEnumValues(),
        7 => Test07_OrderStatusTransition(),
        8 => Test08_ConvertLengthUnits(),
        9 => Test09_PointDistance(),
        10 => Test10_ImmutableColor(),
        11 => Test11_MoneyFormat(),
        12 => Test12_RectangleArea(),
        13 => Test13_VectorOperators(),
        14 => Test14_CelsiusToFahrenheit(),
        15 => Test15_StructClassPerformance(),
        16 => Test16_RefStruct(),
        17 => Test17_ProductRecord(),
        18 => Test18_RecordEquality(),
        19 => Test19_RecordWithExpression(),
        20 => Test20_RecordStructVsClass(),
        21 => Test21_RecordInheritance(),
        22 => Test22_DeconstructRecord(),
        23 => Test23_MutableRecord(),
        24 => Test24_RecordValidation(),
        25 => Test25_NestedRecordEquality(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Struct/record/enum exercises are numbered 1-25.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_WeekdayOrWeekend() =>
        PynativeExerciseRunner.Run(1, "Weekday or Weekend Checker",
            "Create an enum DaysOfWeek. Write a program that takes a day as input and prints whether it is a Weekday or Weekend.",
            t => t.Add(("day = DaysOfWeek.Wednesday -> Weekday", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Classifying Wednesday:",
                        "Result: Wednesday is a Weekday.",
                        "Classification completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise01)))));

    public static PynativeExerciseRunner.SuiteResult Test02_NextTrafficLight() =>
        PynativeExerciseRunner.Run(2, "Next Traffic Light",
            "Define a TrafficLight enum (Red, Yellow, Green). Write a method that takes the current light and returns the next light in the sequence.",
            t => t.Add(("currentLight = TrafficLight.Red -> Green", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Current Light: Red",
                        "Next Light: Green",
                        "Traffic light simulation completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise02)))));

    public static PynativeExerciseRunner.SuiteResult Test03_ByteErrorCodes() =>
        PynativeExerciseRunner.Run(3, "Byte-Based Error Codes",
            "Create an enum called ErrorCode where the underlying type is a byte instead of the default int.",
            t => t.Add(("code = ErrorCode.ServerError -> value 20, size 1", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Inspecting a byte-based enum:",
                        "Name: ServerError",
                        "Value: 20",
                        "Underlying Type Size: 1 byte(s)",
                        "Error code inspection completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise03)))));

    public static PynativeExerciseRunner.SuiteResult Test04_PermissionFlags() =>
        PynativeExerciseRunner.Run(4, "Combining Permission Flags",
            "Create a UserPermissions enum using the [Flags] attribute. Combine permissions and check Write access.",
            t => t.Add(("Read | Write -> has Write", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Combined Permissions: Read, Write",
                        "Result: User has Write access.",
                        "Permission check completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise04)))));

    public static PynativeExerciseRunner.SuiteResult Test05_ParseEnum() =>
        PynativeExerciseRunner.Run(5, "Safely Parsing Enum Input",
            "Take a string input (e.g., \"Premium\") and safely parse it into a SubscriptionTier enum using Enum.TryParse.",
            t => t.Add(("tierInput = \"Premium\" -> Premium", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Parsing \"Premium\" into a SubscriptionTier:",
                        "Result: Successfully parsed as Premium.",
                        "Enum parsing completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise05)))));

    public static PynativeExerciseRunner.SuiteResult Test06_ListEnumValues() =>
        PynativeExerciseRunner.Run(6, "Listing All Enum Values",
            "Dynamically print all the names and underlying values of any given enum using Enum.GetValues.",
            t => t.Add(("Season: Spring, Summer, Autumn, Winter", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Listing all values of the Season enum:",
                        "Spring = 0",
                        "Summer = 1",
                        "Autumn = 2",
                        "Winter = 3",
                        "Enum listing completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise06)))));

    public static PynativeExerciseRunner.SuiteResult Test07_OrderStatusTransition() =>
        PynativeExerciseRunner.Run(7, "Checking Order Status Transitions",
            "Create an OrderStatus enum. Validate that an order cannot transition from Delivered to Cancelled.",
            t => t.Add(("Delivered -> Cancelled is not allowed", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Checking transition from Delivered to Cancelled:",
                        "Result: This transition is not allowed.",
                        "Order status validation completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise07)))));

    public static PynativeExerciseRunner.SuiteResult Test08_ConvertLengthUnits() =>
        PynativeExerciseRunner.Run(8, "Converting Length Units",
            "Create a LengthUnit enum. Convert a value from one unit to another based on the enum provided.",
            t => t.Add(("5 Meter -> Foot = 16.40", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Converting 5 Meter to Foot:",
                        "Result: 16.40 Foot",
                        "Unit conversion completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise08)))));

    public static PynativeExerciseRunner.SuiteResult Test09_PointDistance() =>
        PynativeExerciseRunner.Run(9, "Calculating Distance Between Points",
            "Create a Point2D struct with X and Y coordinates. Include a method to calculate the distance between two points.",
            t => t.Add(("(0, 0) to (3, 4) -> 5", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Calculating distance between (0, 0) and (3, 4):",
                        "Distance = 5",
                        "Distance calculation completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise09)))));

    public static PynativeExerciseRunner.SuiteResult Test10_ImmutableColor() =>
        PynativeExerciseRunner.Run(10, "Creating an Immutable Color Struct",
            "Create a readonly struct ColorRGB with Red, Green, and Blue fields set only via the constructor.",
            t => t.Add(("ColorRGB(255, 100, 50)", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Creating an immutable RGB color:",
                        "Red = 255, Green = 100, Blue = 50",
                        "Color creation completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise10)))));

    public static PynativeExerciseRunner.SuiteResult Test11_MoneyFormat() =>
        PynativeExerciseRunner.Run(11, "Formatting a Money Value",
            "Create a Money struct that holds an Amount (decimal) and a Currency (string). Override ToString().",
            t => t.Add(("Money(10.50m, \"USD\") -> $10.50 USD", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Formatting a wallet amount:",
                        "$10.50 USD",
                        "Money formatting completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise11)))));

    public static PynativeExerciseRunner.SuiteResult Test12_RectangleArea() =>
        PynativeExerciseRunner.Run(12, "Rectangle Area Using Properties",
            "Create a Rectangle struct with Width and Height properties, and a read-only Area property.",
            t => t.Add(("Width = 5, Height = 3 -> Area 15", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Calculating area for a 5 x 3 rectangle:",
                        "Area = 15",
                        "Rectangle area calculation completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise12)))));

    public static PynativeExerciseRunner.SuiteResult Test13_VectorOperators() =>
        PynativeExerciseRunner.Run(13, "Adding and Subtracting Vectors",
            "Create a Vector2D struct. Overload the + and - operators so you can add or subtract two vectors.",
            t => t.Add(("(2, 3) +/- (4, 1) -> (6, 4) and (-2, 2)", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Vector A = (2, 3), Vector B = (4, 1)",
                        "Sum = (6, 4)",
                        "Difference = (-2, 2)",
                        "Vector operations completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise13)))));

    public static PynativeExerciseRunner.SuiteResult Test14_CelsiusToFahrenheit() =>
        PynativeExerciseRunner.Run(14, "Converting Celsius to Fahrenheit",
            "Create Fahrenheit and Celsius structs. Implement a conversion operator between the two.",
            t => t.Add(("Celsius(25) -> 77 F", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Converting 25\u00B0C to Fahrenheit:",
                        "Result: 77\u00B0F",
                        "Temperature conversion completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise14)))));

    public static PynativeExerciseRunner.SuiteResult Test15_StructClassPerformance() =>
        PynativeExerciseRunner.Run(15, "Comparing Struct and Class Performance",
            "Create an array of 1,000,000 class objects versus 1,000,000 structs and print the instantiation times.",
            t => t.Add(("count = 1000000 -> timing labels (ms values vary)", () =>
            {
                string[] lines = PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise15);
                PynativeExerciseRunner.PrintOutput(string.Join(" | ", lines));
                PynativeExerciseRunner.AssertEqualSilent(
                    "Creating 1000000 structs and 1000000 class objects:",
                    lines[0]);
                PynativeExerciseRunner.AssertTrue(
                    () => lines.Any(l => l.StartsWith("Struct array creation time:") && l.EndsWith(" ms")));
                PynativeExerciseRunner.AssertTrue(
                    () => lines.Any(l => l.StartsWith("Class array creation time:") && l.EndsWith(" ms")));
                PynativeExerciseRunner.AssertEqualSilent("Benchmark completed successfully.", lines[^1]);
            })));

    public static PynativeExerciseRunner.SuiteResult Test16_RefStruct() =>
        PynativeExerciseRunner.Run(16, "Why Ref Structs Can't Be Boxed",
            "Create a ref struct called LargeBuffer. Demonstrate it living on the stack (it cannot be boxed).",
            t => t.Add(("LargeBuffer(1024) -> size 1024, first byte 255", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Creating a ref struct on the stack:",
                        "Buffer Size = 1024 bytes",
                        "First Byte = 255",
                        "Ref struct demonstration completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise16)))));

    public static PynativeExerciseRunner.SuiteResult Test17_ProductRecord() =>
        PynativeExerciseRunner.Run(17, "Creating a Product Record",
            "Create a positional record Product that holds an Id, Name, and Price.",
            t => t.Add(("Product(1, \"Laptop\", 999.99m)", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Creating a product using positional record syntax:",
                        "Product { Id = 1, Name = Laptop, Price = 999.99 }",
                        "Product creation completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise17)))));

    public static PynativeExerciseRunner.SuiteResult Test18_RecordEquality() =>
        PynativeExerciseRunner.Run(18, "Comparing Records with ==",
            "Create two Book records with identical properties. Prove that book1 == book2 evaluates to true.",
            t => t.Add(("two Book(\"1984\", \"George Orwell\") -> True", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Comparing two record instances with identical values:",
                        "book1 == book2: True",
                        "Equality check completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise18)))));

    public static PynativeExerciseRunner.SuiteResult Test19_RecordWithExpression() =>
        PynativeExerciseRunner.Run(19, "Copying a Record with 'with'",
            "Create a UserAccount record. Use with to copy the user with IsActive set to false.",
            t => t.Add(("jdoe active -> copy inactive", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Creating a modified copy using the 'with' expression:",
                        "Original: UserAccount { Username = jdoe, Email = jdoe@example.com, IsActive = True }",
                        "Copy: UserAccount { Username = jdoe, Email = jdoe@example.com, IsActive = False }",
                        "Non-destructive mutation completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise19)))));

    public static PynativeExerciseRunner.SuiteResult Test20_RecordStructVsClass() =>
        PynativeExerciseRunner.Run(20, "Record Struct vs Record Class",
            "Define PointRecordStruct as a record struct and PointRecordClass as a record. Compare value vs reference semantics.",
            t => t.Add(("copy struct X=100 leaves original at 1; class reference sees 100", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Comparing record struct (value type) and record class (reference type):",
                        "Struct Original: PointRecordStruct { X = 1, Y = 1 }",
                        "Struct Copy: PointRecordStruct { X = 100, Y = 1 }",
                        "Class Original: PointRecordClass { X = 100, Y = 1 }",
                        "Class Reference: PointRecordClass { X = 100, Y = 1 }",
                        "Comparison completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise20)))));

    public static PynativeExerciseRunner.SuiteResult Test21_RecordInheritance() =>
        PynativeExerciseRunner.Run(21, "Inheriting from a Record",
            "Create a base record Vehicle (Make, Model) and a derived record ElectricCar that adds BatteryCapacity.",
            t => t.Add(("two ElectricCar(\"Tesla\", \"Model 3\", 75) -> equal", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Comparing two derived record instances:",
                        "Car 1: ElectricCar { Make = Tesla, Model = Model 3, BatteryCapacity = 75 }",
                        "Car 2: ElectricCar { Make = Tesla, Model = Model 3, BatteryCapacity = 75 }",
                        "car1 == car2: True",
                        "Record inheritance check completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise21)))));

    public static PynativeExerciseRunner.SuiteResult Test22_DeconstructRecord() =>
        PynativeExerciseRunner.Run(22, "Deconstructing a Record",
            "Create a Student record with Name, Grade, and Major. Deconstruct an instance into individual variables.",
            t => t.Add(("Student(\"Alice\", \"A\", \"Computer Science\")", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Deconstructing Student { Name = Alice, Grade = A, Major = Computer Science }:",
                        "Name = Alice",
                        "Grade = A",
                        "Major = Computer Science",
                        "Deconstruction completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise22)))));

    public static PynativeExerciseRunner.SuiteResult Test23_MutableRecord() =>
        PynativeExerciseRunner.Run(23, "Making a Record Mutable",
            "Create a record that uses { get; set; } properties. Demonstrate that it is mutable.",
            t => t.Add(("MutableUser Alex age 30 -> age 31", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Before mutation: MutableUser { Name = Alex, Age = 30 }",
                        "After mutation: MutableUser { Name = Alex, Age = 31 }",
                        "Mutable record demonstration completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise23)))));

    public static PynativeExerciseRunner.SuiteResult Test24_RecordValidation() =>
        PynativeExerciseRunner.Run(24, "Validating Data in a Record",
            "Create a SmartHomeDevice record. Throw ArgumentException if DeviceName is null or empty.",
            t => t.Add(("valid Living Room Light, then empty name throws", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Creating a valid smart home device:",
                        "SmartHomeDevice { DeviceName = Living Room Light, DeviceType = Light }",
                        "Attempting to create a device with an empty name:",
                        "Caught Exception: Device name cannot be null or empty. (Parameter 'deviceName')",
                        "Validation demonstration completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise24)))));

    public static PynativeExerciseRunner.SuiteResult Test25_NestedRecordEquality() =>
        PynativeExerciseRunner.Run(25, "Nested Records and Equality",
            "Create a WeatherReport record containing a Temperature struct. Value equality should include the nested struct.",
            t => t.Add(("two Seattle reports at 15.5 C -> equal", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Comparing two weather reports with nested temperature data:",
                        "Report 1: WeatherReport { City = Seattle, CurrentTemperature = 15.5\u00B0C }",
                        "Report 2: WeatherReport { City = Seattle, CurrentTemperature = 15.5\u00B0C }",
                        "report1 == report2: True",
                        "Nested equality check completed successfully."
                    },
                    () => PynativeConsole.CaptureLines(StructRecordEnumExercises.RunExercise25)))));
}
