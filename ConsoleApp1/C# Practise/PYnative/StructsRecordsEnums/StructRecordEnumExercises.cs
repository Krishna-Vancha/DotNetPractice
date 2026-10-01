using System;

namespace ConsoleApp1.C__Practise.PYnative.StructsRecordsEnums;

// Source: https://pynative.com/csharp-structs-records-enums-exercises/ (25 exercises)
//
// How to practice:
// 1. Read the Exercise block: Practice Problem, Given Input, Expected Output.
// 2. Under "--- Your solution ---", define the enum, struct, or record the problem asks for.
// 3. Implement RunExerciseNN() so it runs the Given Input and prints the Expected Output.
// Tests call only RunExerciseNN() and compare captured console lines.

public static partial class StructRecordEnumExercises
{
    // Exercise 1: Weekday or Weekend Checker
    //
    // Practice Problem: Create an enum DaysOfWeek. Write a program that takes a day as input and prints whether it is a "Weekday" or "Weekend".
    //
    // Given Input: day = DaysOfWeek.Wednesday
    //
    // Expected Output:
    // Classifying Wednesday:
    // Result: Wednesday is a Weekday.
    // Classification completed successfully.
    //
    // --- Your solution: DaysOfWeek + RunExercise01() below ---

    public static void RunExercise01() =>
        throw new NotImplementedException();

    // Exercise 2: Next Traffic Light
    //
    // Practice Problem: Define a TrafficLight enum (Red, Yellow, Green). Write a method that takes the current light and returns the next light in the sequence.
    //
    // Given Input: currentLight = TrafficLight.Red
    //
    // Expected Output:
    // Current Light: Red
    // Next Light: Green
    // Traffic light simulation completed successfully.
    //
    // --- Your solution: TrafficLight + RunExercise02() below ---

    public static void RunExercise02() =>
        throw new NotImplementedException();

    // Exercise 3: Byte-Based Error Codes
    //
    // Practice Problem: Create an enum called ErrorCode where the underlying type is a byte instead of the default int, and assign it small values that fit within a byte's range.
    //
    // Given Input: code = ErrorCode.ServerError
    //
    // Expected Output:
    // Inspecting a byte-based enum:
    // Name: ServerError
    // Value: 20
    // Underlying Type Size: 1 byte(s)
    // Error code inspection completed successfully.
    //
    // --- Your solution: ErrorCode + RunExercise03() below ---

    public static void RunExercise03() =>
        throw new NotImplementedException();

    // Exercise 4: Combining Permission Flags
    //
    // Practice Problem: Create a UserPermissions enum using the [Flags] attribute. Write a program that combines permissions and checks if a user has Write access.
    //
    // Given Input: userPermissions = UserPermissions.Read | UserPermissions.Write
    //
    // Expected Output:
    // Combined Permissions: Read, Write
    // Result: User has Write access.
    // Permission check completed successfully.
    //
    // --- Your solution: UserPermissions + RunExercise04() below ---

    public static void RunExercise04() =>
        throw new NotImplementedException();

    // Exercise 5: Safely Parsing Enum Input
    //
    // Practice Problem: Write a program that takes a string input (e.g., "Premium") and safely parses it into a SubscriptionTier enum using Enum.TryParse.
    //
    // Given Input: tierInput = "Premium"
    //
    // Expected Output:
    // Parsing "Premium" into a SubscriptionTier:
    // Result: Successfully parsed as Premium.
    // Enum parsing completed successfully.
    //
    // --- Your solution: SubscriptionTier + RunExercise05() below ---

    public static void RunExercise05() =>
        throw new NotImplementedException();

    // Exercise 6: Listing All Enum Values
    //
    // Practice Problem: Write a method that dynamically prints all the names and underlying values of any given enum using Enum.GetValues.
    //
    // Given Input: enum Season { Spring, Summer, Autumn, Winter }
    //
    // Expected Output:
    // Listing all values of the Season enum:
    // Spring = 0
    // Summer = 1
    // Autumn = 2
    // Winter = 3
    // Enum listing completed successfully.
    //
    // --- Your solution: Season + RunExercise06() below ---

    public static void RunExercise06() =>
        throw new NotImplementedException();

    // Exercise 7: Checking Order Status Transitions
    //
    // Practice Problem: Create an OrderStatus enum (Pending, Shipped, Delivered, Cancelled). Write a method that validates if an order can transition from Delivered to Cancelled (it shouldn't!).
    //
    // Given Input: currentStatus = OrderStatus.Delivered, newStatus = OrderStatus.Cancelled
    //
    // Expected Output:
    // Checking transition from Delivered to Cancelled:
    // Result: This transition is not allowed.
    // Order status validation completed successfully.
    //
    // --- Your solution: OrderStatus + RunExercise07() below ---

    public static void RunExercise07() =>
        throw new NotImplementedException();

    // Exercise 8: Converting Length Units
    //
    // Practice Problem: Create an enum LengthUnit (Meter, Centimeter, Inch, Foot). Write a conversion function that converts a value from one unit to another based on the enum provided.
    //
    // Given Input: value = 5, fromUnit = LengthUnit.Meter, toUnit = LengthUnit.Foot
    //
    // Expected Output:
    // Converting 5 Meter to Foot:
    // Result: 16.40 Foot
    // Unit conversion completed successfully.
    //
    // --- Your solution: LengthUnit + RunExercise08() below ---

    public static void RunExercise08() =>
        throw new NotImplementedException();

    // Exercise 9: Calculating Distance Between Points
    //
    // Practice Problem: Create a Point2D struct with X and Y coordinates. Include a method to calculate the distance between two points.
    //
    // Given Input: pointA = new Point2D(0, 0), pointB = new Point2D(3, 4)
    //
    // Expected Output:
    // Calculating distance between (0, 0) and (3, 4):
    // Distance = 5
    // Distance calculation completed successfully.
    //
    // --- Your solution: Point2D + RunExercise09() below ---

    public static void RunExercise09() =>
        throw new NotImplementedException();

    // Exercise 10: Creating an Immutable Color Struct
    //
    // Practice Problem: Create a readonly struct called ColorRGB with fields for Red, Green, and Blue. Ensure they can only be set via the constructor.
    //
    // Given Input: color = new ColorRGB(255, 100, 50)
    //
    // Expected Output:
    // Creating an immutable RGB color:
    // Red = 255, Green = 100, Blue = 50
    // Color creation completed successfully.
    //
    // --- Your solution: ColorRGB + RunExercise10() below ---

    public static void RunExercise10() =>
        throw new NotImplementedException();

    // Exercise 11: Formatting a Money Value
    //
    // Practice Problem: Create a Money struct that holds an Amount (decimal) and a Currency (string). Override the ToString() method to display it nicely.
    //
    // Given Input: wallet = new Money(10.50m, "USD")
    //
    // Expected Output:
    // Formatting a wallet amount:
    // $10.50 USD
    // Money formatting completed successfully.
    //
    // --- Your solution: Money + RunExercise11() below ---

    public static void RunExercise11() =>
        throw new NotImplementedException();

    // Exercise 12: Rectangle Area Using Properties
    //
    // Practice Problem: Create a Rectangle struct. Give it Width and Height properties, and a read-only property for Area.
    //
    // Given Input: rectangle = new Rectangle { Width = 5, Height = 3 }
    //
    // Expected Output:
    // Calculating area for a 5 x 3 rectangle:
    // Area = 15
    // Rectangle area calculation completed successfully.
    //
    // --- Your solution: Rectangle + RunExercise12() below ---

    public static void RunExercise12() =>
        throw new NotImplementedException();

    // Exercise 13: Adding and Subtracting Vectors
    //
    // Practice Problem: Create a Vector2D struct. Overload the + and - operators so you can add or subtract two vectors directly.
    //
    // Given Input: vectorA = new Vector2D(2, 3), vectorB = new Vector2D(4, 1)
    //
    // Expected Output:
    // Vector A = (2, 3), Vector B = (4, 1)
    // Sum = (6, 4)
    // Difference = (-2, 2)
    // Vector operations completed successfully.
    //
    // --- Your solution: Vector2D + RunExercise13() below ---

    public static void RunExercise13() =>
        throw new NotImplementedException();

    // Exercise 14: Converting Celsius to Fahrenheit
    //
    // Practice Problem: Create a Fahrenheit struct and a Celsius struct. Implement an explicit or implicit conversion operator to convert between the two.
    //
    // Given Input: celsius = new Celsius(25)
    //
    // Expected Output:
    // Converting 25°C to Fahrenheit:
    // Result: 77°F
    // Temperature conversion completed successfully.
    //
    // --- Your solution: Celsius, Fahrenheit + RunExercise14() below ---

    public static void RunExercise14() =>
        throw new NotImplementedException();

    // Exercise 15: Comparing Struct and Class Performance
    //
    // Practice Problem: Write a program that creates an array of 1,000,000 class objects versus 1,000,000 structs. Observe the instantiation time differences.
    //
    // Given Input: count = 1000000
    //
    // Expected Output (millisecond values vary by machine; keep these labels):
    // Creating 1000000 structs and 1000000 class objects:
    // Struct array creation time: <ms> ms
    // Class array creation time: <ms> ms
    // Benchmark completed successfully.
    //
    // --- Your solution: PointStruct, PointClass + RunExercise15() below ---

    public static void RunExercise15() =>
        throw new NotImplementedException();

    // Exercise 16: Why Ref Structs Can't Be Boxed
    //
    // Practice Problem: Create a ref struct called LargeBuffer. Try to box it or use it inside a regular class to see why the compiler prevents it.
    //
    // Given Input: buffer = new LargeBuffer(1024)
    //
    // Expected Output:
    // Creating a ref struct on the stack:
    // Buffer Size = 1024 bytes
    // First Byte = 255
    // Ref struct demonstration completed successfully.
    //
    // --- Your solution: LargeBuffer + RunExercise16() below ---

    public static void RunExercise16() =>
        throw new NotImplementedException();

    // Exercise 17: Creating a Product Record
    //
    // Practice Problem: Create a positional record Product that holds an Id, Name, and Price. Instantiate it using the concise positional syntax.
    //
    // Given Input: product = new Product(1, "Laptop", 999.99m)
    //
    // Expected Output:
    // Creating a product using positional record syntax:
    // Product { Id = 1, Name = Laptop, Price = 999.99 }
    // Product creation completed successfully.
    //
    // --- Your solution: Product + RunExercise17() below ---

    public static void RunExercise17() =>
        throw new NotImplementedException();

    // Exercise 18: Comparing Records with ==
    //
    // Practice Problem: Create two instances of a Book record with identical properties. Prove that book1 == book2 evaluates to true, unlike standard classes.
    //
    // Given Input: book1 = new Book("1984", "George Orwell"), book2 = new Book("1984", "George Orwell")
    //
    // Expected Output:
    // Comparing two record instances with identical values:
    // book1 == book2: True
    // Equality check completed successfully.
    //
    // --- Your solution: Book + RunExercise18() below ---

    public static void RunExercise18() =>
        throw new NotImplementedException();

    // Exercise 19: Copying a Record with 'with'
    //
    // Practice Problem: Create a UserAccount record with Username, Email, and IsActive. Use the with expression to create a copy of the user but with IsActive set to false.
    //
    // Given Input: originalUser = new UserAccount("jdoe", "jdoe@example.com", true)
    //
    // Expected Output:
    // Creating a modified copy using the 'with' expression:
    // Original: UserAccount { Username = jdoe, Email = jdoe@example.com, IsActive = True }
    // Copy: UserAccount { Username = jdoe, Email = jdoe@example.com, IsActive = False }
    // Non-destructive mutation completed successfully.
    //
    // --- Your solution: UserAccount + RunExercise19() below ---

    public static void RunExercise19() =>
        throw new NotImplementedException();

    // Exercise 20: Record Struct vs Record Class
    //
    // Practice Problem: Define a PointRecordStruct as a record struct and a PointRecordClass as a standard record. Modify one and observe how value vs reference semantics apply.
    //
    // Given Input: structOriginal = new PointRecordStruct { X = 1, Y = 1 }, classOriginal = new PointRecordClass { X = 1, Y = 1 }
    //
    // Expected Output:
    // Comparing record struct (value type) and record class (reference type):
    // Struct Original: PointRecordStruct { X = 1, Y = 1 }
    // Struct Copy: PointRecordStruct { X = 100, Y = 1 }
    // Class Original: PointRecordClass { X = 100, Y = 1 }
    // Class Reference: PointRecordClass { X = 100, Y = 1 }
    // Comparison completed successfully.
    //
    // --- Your solution: PointRecordStruct, PointRecordClass + RunExercise20() below ---

    public static void RunExercise20() =>
        throw new NotImplementedException();

    // Exercise 21: Inheriting from a Record
    //
    // Practice Problem: Create a base record Vehicle (Make, Model) and a derived record ElectricCar that adds BatteryCapacity. Ensure value equality still works accurately.
    //
    // Given Input: car1 = new ElectricCar("Tesla", "Model 3", 75), car2 = new ElectricCar("Tesla", "Model 3", 75)
    //
    // Expected Output:
    // Comparing two derived record instances:
    // Car 1: ElectricCar { Make = Tesla, Model = Model 3, BatteryCapacity = 75 }
    // Car 2: ElectricCar { Make = Tesla, Model = Model 3, BatteryCapacity = 75 }
    // car1 == car2: True
    // Record inheritance check completed successfully.
    //
    // --- Your solution: Vehicle, ElectricCar + RunExercise21() below ---

    public static void RunExercise21() =>
        throw new NotImplementedException();

    // Exercise 22: Deconstructing a Record
    //
    // Practice Problem: Create a Student record with Name, Grade, and Major. Write code that deconstructs an instance of the student into individual variables in a single line.
    //
    // Given Input: student = new Student("Alice", "A", "Computer Science")
    //
    // Expected Output:
    // Deconstructing Student { Name = Alice, Grade = A, Major = Computer Science }:
    // Name = Alice
    // Grade = A
    // Major = Computer Science
    // Deconstruction completed successfully.
    //
    // --- Your solution: Student + RunExercise22() below ---

    public static void RunExercise22() =>
        throw new NotImplementedException();

    // Exercise 23: Making a Record Mutable
    //
    // Practice Problem: Create a record that uses standard properties with { get; set; } instead of init. Demonstrate how it breaks traditional record immutability.
    //
    // Given Input: user = new MutableUser { Name = "Alex", Age = 30 }
    //
    // Expected Output:
    // Before mutation: MutableUser { Name = Alex, Age = 30 }
    // After mutation: MutableUser { Name = Alex, Age = 31 }
    // Mutable record demonstration completed successfully.
    //
    // --- Your solution: MutableUser + RunExercise23() below ---

    public static void RunExercise23() =>
        throw new NotImplementedException();

    // Exercise 24: Validating Data in a Record
    //
    // Practice Problem: Create a SmartHomeDevice record. Customize the positional constructor to throw an ArgumentException if the DeviceName is null or empty.
    //
    // Given Input: A valid device new SmartHomeDevice("Living Room Light", "Light"), and an invalid attempt new SmartHomeDevice("", "Thermostat")
    //
    // Expected Output:
    // Creating a valid smart home device:
    // SmartHomeDevice { DeviceName = Living Room Light, DeviceType = Light }
    // Attempting to create a device with an empty name:
    // Caught Exception: Device name cannot be null or empty. (Parameter 'deviceName')
    // Validation demonstration completed successfully.
    //
    // --- Your solution: SmartHomeDevice + RunExercise24() below ---

    public static void RunExercise24() =>
        throw new NotImplementedException();

    // Exercise 25: Nested Records and Equality
    //
    // Practice Problem: Create a WeatherReport record that contains nested data, such as a Temperature struct inside it. Test if the value equality checks all the way down into the nested struct.
    //
    // Given Input: report1 = new WeatherReport("Seattle", new Temperature { Celsius = 15.5 }), report2 = new WeatherReport("Seattle", new Temperature { Celsius = 15.5 })
    //
    // Expected Output:
    // Comparing two weather reports with nested temperature data:
    // Report 1: WeatherReport { City = Seattle, CurrentTemperature = 15.5°C }
    // Report 2: WeatherReport { City = Seattle, CurrentTemperature = 15.5°C }
    // report1 == report2: True
    // Nested equality check completed successfully.
    //
    // --- Your solution: Temperature, WeatherReport + RunExercise25() below ---

    public static void RunExercise25() =>
        throw new NotImplementedException();
}
