using System;
using System.Collections.Generic;

namespace ConsoleApp1.C__Practise.PYnative.OOP;

/// <summary>
/// Test cases for PYnative C# OOP Exercises — https://pynative.com/csharp-oop-exercises/
/// Titles and questions are copied exactly from the site's "Practice Problem" text.
/// </summary>
public static class OopExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 39; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative — OOP Exercises (39)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_DigitalWatch(),
        2 => Test02_BookConstructors(),
        3 => Test03_AccountReadOnlyField(),
        4 => Test04_ConfigurationSingleton(),
        5 => Test05_ThermostatHistory(),
        6 => Test06_ProductDiscount(),
        7 => Test07_MathWizard(),
        8 => Test08_ResourceWrapperFinalizer(),
        9 => Test09_UserProfilePasswordMask(),
        10 => Test10_ImmutableRectangle(),
        11 => Test11_RentalCarOdometer(),
        12 => Test12_ClothingTemperatureValidation(),
        13 => Test13_CircleArea(),
        14 => Test14_FlightAssignSeat(),
        15 => Test15_HeroHealthSideEffects(),
        16 => Test16_SavingsAccountBonus(),
        17 => Test17_VehicleStartEngine(),
        18 => Test18_StrictAuthSealed(),
        19 => Test19_EmployeeCalculatePay(),
        20 => Test20_StudentBaseConstructor(),
        21 => Test21_KnightSealedMove(),
        22 => Test22_AnimalMakeSound(),
        23 => Test23_ShadowDisplay(),
        24 => Test24_MicrowavePowerOn(),
        25 => Test25_CanvasRenderAll(),
        26 => Test26_SqlDatabaseConnection(),
        27 => Test27_ShapePerimeter(),
        28 => Test28_LatteBrew(),
        29 => Test29_PdfParser(),
        30 => Test30_PayPalProcessPayment(),
        31 => Test31_GoblinDragonExecuteTurn(),
        32 => Test32_AllInOnePrinter(),
        33 => Test33_DriverExplicitTurns(),
        34 => Test34_ConsoleLogger(),
        35 => Test35_PluginHost(),
        36 => Test36_WeaponSortByDamage(),
        37 => Test37_DatabaseSessionDispose(),
        38 => Test38_FlyingBoatFlySwim(),
        39 => Test39_UserExplicitAdminReset(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "OOP exercises are numbered 1–39.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_DigitalWatch() =>
        PynativeExerciseRunner.Run(1, "The Digital Watch (Class Fields & Methods)",
            "Create a DigitalWatch class with fields for hours and minutes. Implement a method to add time and print the current time.",
            t =>
            {
                t.Add(("Given Input: Starting time 10:45, add 30 minutes -> Expected Output: 11:15", () =>
                    PynativeExerciseRunner.AssertEqual("11:15",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise01))));
            });

    public static PynativeExerciseRunner.SuiteResult Test02_BookConstructors() =>
        PynativeExerciseRunner.Run(2, "Library Book Tracker (Multiple Constructors)",
            "Build a Book class. Use multiple constructors: a default constructor, one taking just the title and author, and one taking title, author, and ISBN.",
            t =>
            {
                t.Add(("Given Input: book1 (no arguments), book2 = (\"1984\", \"George Orwell\"), book3 = (\"Dune\", \"Frank Herbert\", \"978-0441172719\") -> Expected Output: 3 Title/Author/ISBN lines", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Title: Unknown Title, Author: Unknown Author, ISBN: N/A\n" +
                        "Title: 1984, Author: George Orwell, ISBN: N/A\n" +
                        "Title: Dune, Author: Frank Herbert, ISBN: 978-0441172719",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise02))));
            });

    public static PynativeExerciseRunner.SuiteResult Test03_AccountReadOnlyField() =>
        PynativeExerciseRunner.Run(3, "Bank Account Snapshot (Read-Only Fields)",
            "Create an Account class where the account number can only be set via the constructor and is read-only afterward (using readonly fields).",
            t =>
            {
                t.Add(("Given Input: accountNumber = \"ACC-10293\" -> Expected Output: Account Number: ACC-10293", () =>
                    PynativeExerciseRunner.AssertEqual("Account Number: ACC-10293",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise03))));
            });

    public static PynativeExerciseRunner.SuiteResult Test04_ConfigurationSingleton() =>
        PynativeExerciseRunner.Run(4, "The Singleton Configuration (Singleton Pattern)",
            "Create a ConfigurationManager class that uses a private constructor and a static method to ensure only one instance ever exists.",
            t =>
            {
                t.Add(("Given Input: None -> Expected Output: Same instance: True", () =>
                    PynativeExerciseRunner.AssertTrue(() => OopExercises.RunExercise04())));
            });

    public static PynativeExerciseRunner.SuiteResult Test05_ThermostatHistory() =>
        PynativeExerciseRunner.Run(5, "Smart Home Thermostat (Private Fields & Public Methods)",
            "Implement a Thermostat class where the internal temperature history array is private, but public methods allow adding new readings.",
            t =>
            {
                t.Add(("Given Input: Readings 68.5, 70.2, 69.0 -> Expected Output: Temperature History: 68.5, 70.2, 69", () =>
                    PynativeExerciseRunner.AssertEqual("Temperature History: 68.5, 70.2, 69",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise05))));
            });

    public static PynativeExerciseRunner.SuiteResult Test06_ProductDiscount() =>
        PynativeExerciseRunner.Run(6, "E-Commerce Product (Internal Access Modifier)",
            "Create a Product class utilizing internal modifiers to ensure the product's discount logic is only accessible within its own project assembly.",
            t =>
            {
                t.Add(("Given Input: Name = \"Wireless Mouse\", Price = 25.00 -> Expected Output: Discounted Price for Wireless Mouse: 22.5", () =>
                    PynativeExerciseRunner.AssertEqual("Discounted Price for Wireless Mouse: 22.5",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise06))));
            });

    public static PynativeExerciseRunner.SuiteResult Test07_MathWizard() =>
        PynativeExerciseRunner.Run(7, "Static Math Utility (Static Class & Methods)",
            "Design a MathWizard class that is marked static, containing static methods for calculating factorials and absolute differences, without instantiation.",
            t =>
            {
                t.Add(("Given Input: Factorial(5), AbsoluteDifference(10, 3) -> Expected Output: Factorial of 5 = 120 / Absolute Difference = 7", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Factorial of 5 = 120\nAbsolute Difference = 7",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise07))));
            });

    public static PynativeExerciseRunner.SuiteResult Test08_ResourceWrapperFinalizer() =>
        PynativeExerciseRunner.Run(8, "Destructor Cleanup (Finalizers)",
            "Create a ResourceWrapper class that simulates opening a file. Implement a finalizer/destructor (~ResourceWrapper()) that prints a message when the garbage collector claims the object.",
            t =>
            {
                t.Add(("Given Input: None -> Expected Output: File opened. / File handle cleaned up by garbage collector.", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "File opened.\nFile handle cleaned up by garbage collector.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise08))));
            });

    public static PynativeExerciseRunner.SuiteResult Test09_UserProfilePasswordMask() =>
        PynativeExerciseRunner.Run(9, "Secure User Profile (Custom Property Get/Set)",
            "Create a UserProfile class where the Password property can be set, but reading it always returns \"********\".",
            t =>
            {
                t.Add(("Given Input: Password = \"MySecret123\" -> Expected Output: ********", () =>
                    PynativeExerciseRunner.AssertEqual("********", () => OopExercises.RunExercise09())));
            });

    public static PynativeExerciseRunner.SuiteResult Test10_ImmutableRectangle() =>
        PynativeExerciseRunner.Run(10, "The Immutable Rectangle (Init-Only Properties)",
            "Design a Rectangle class using init accessors for Width and Height, ensuring they can only be set during object initialization and never changed again.",
            t =>
            {
                t.Add(("Given Input: Width = 10, Height = 5 -> Expected Output: Width: 10, Height: 5", () =>
                    PynativeExerciseRunner.AssertEqual("Width: 10, Height: 5",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise10))));
            });

    public static PynativeExerciseRunner.SuiteResult Test11_RentalCarOdometer() =>
        PynativeExerciseRunner.Run(11, "Auto-Property Rental Car (Auto-Properties vs Backing Fields)",
            "Create a RentalCar class using auto-properties for Make and Model, but use a backing field for Odometer to ensure it can never be rolled backward.",
            t =>
            {
                t.Add(("Given Input: Set Odometer to 5000, then attempt to set it to 3000 -> Expected Output: Odometer: 5000", () =>
                    PynativeExerciseRunner.AssertEqual("Odometer: 5000",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise11))));
            });

    public static PynativeExerciseRunner.SuiteResult Test12_ClothingTemperatureValidation() =>
        PynativeExerciseRunner.Run(12, "Smart Wardrobe Temperature (Validated Property Setter)",
            "Create a Clothing class with a TargetTemperature property. Throw an ArgumentException in the set accessor if the value falls outside 15°C to 30°C.",
            t =>
            {
                t.Add(("Given Input: Attempt to set TargetTemperature to 40, then set it to 22 -> Expected Output: Error: Temperature must be between 15 and 30 degrees Celsius. / Target Temperature: 22", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Error: Temperature must be between 15 and 30 degrees Celsius.\nTarget Temperature: 22",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise12))));
            });

    public static PynativeExerciseRunner.SuiteResult Test13_CircleArea() =>
        PynativeExerciseRunner.Run(13, "Calculated Circle (Read-Only Computed Property)",
            "Design a Circle class with a read-only calculated property Area that dynamically computes π r² whenever called.",
            t =>
            {
                t.Add(("Given Input: Radius = 5 -> Expected Output: Area = 78.54", () =>
                    PynativeExerciseRunner.AssertEqual("Area = 78.54",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise13))));
            });

    public static PynativeExerciseRunner.SuiteResult Test14_FlightAssignSeat() =>
        PynativeExerciseRunner.Run(14, "Flight Reservation (Private Set with Controlled Method)",
            "Implement a Flight class where the SeatNumber has a public get but a private set, modifiable only by the internal AssignSeat() method.",
            t =>
            {
                t.Add(("Given Input: AssignSeat(\"14A\") -> Expected Output: Seat Number: 14A", () =>
                    PynativeExerciseRunner.AssertEqual("Seat Number: 14A",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise14))));
            });

    public static PynativeExerciseRunner.SuiteResult Test15_HeroHealthSideEffects() =>
        PynativeExerciseRunner.Run(15, "Game Character Health (Property Triggering Side Effects)",
            "Create a Hero class where setting Health automatically triggers a boolean property IsAlive to flip to false if health hits 0.",
            t =>
            {
                t.Add(("Given Input: Set Health to 50, then set it to 0 -> Expected Output: Is Alive: True / Is Alive: False", () =>
                    PynativeExerciseRunner.AssertEqual("Is Alive: True\nIs Alive: False",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise15))));
            });

    public static PynativeExerciseRunner.SuiteResult Test16_SavingsAccountBonus() =>
        PynativeExerciseRunner.Run(16, "Bank Yield Calculator (Custom Set Logic with Bonus)",
            "Create a SavingsAccount with a Balance property. Use custom get/set blocks to automatically calculate and apply a 2% bonus if the deposit exceeds $10,000.",
            t =>
            {
                t.Add(("Given Input: Balance = 15000 -> Expected Output: Balance = 15300", () =>
                    PynativeExerciseRunner.AssertEqual("Balance = 15300",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise16))));
            });

    public static PynativeExerciseRunner.SuiteResult Test17_VehicleStartEngine() =>
        PynativeExerciseRunner.Run(17, "Vehicle Hierarchy (Inheritance & Method Overriding)",
            "Create a base class Vehicle and derived classes Car and Motorcycle. Override a StartEngine() method to print unique startup sounds.",
            t =>
            {
                t.Add(("Given Input: None -> Expected Output: Vroom! The car engine roars to life. / Vroooom! The motorcycle engine revs up.", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Vroom! The car engine roars to life.\nVroooom! The motorcycle engine revs up.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise17))));
            });

    public static PynativeExerciseRunner.SuiteResult Test18_StrictAuthSealed() =>
        PynativeExerciseRunner.Run(18, "The Sealed Security System (Sealed Classes)",
            "Design a SecurityCore base class. Create a StrictAuth derived class and mark it as sealed so no other class can inherit and potentially alter its authentication logic.",
            t =>
            {
                t.Add(("Given Input: None -> Expected Output: Running strict authentication checks.", () =>
                    PynativeExerciseRunner.AssertEqual("Running strict authentication checks.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise18))));
            });

    public static PynativeExerciseRunner.SuiteResult Test19_EmployeeCalculatePay() =>
        PynativeExerciseRunner.Run(19, "Employee Payroll System (Virtual & Override Across Multiple Subclasses)",
            "Write a base Employee class with a CalculatePay() method. Create HourlyEmployee and SalariedEmployee subclasses that override the calculation using virtual and override.",
            t =>
            {
                t.Add(("Given Input: Hourly employee: rate $20, hours 80. Salaried employee: monthly salary $4000. -> Expected Output: Hourly Employee Pay = 1600 / Salaried Employee Pay = 4000", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Hourly Employee Pay = 1600\nSalaried Employee Pay = 4000",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise19))));
            });

    public static PynativeExerciseRunner.SuiteResult Test20_StudentBaseConstructor() =>
        PynativeExerciseRunner.Run(20, "Base Constructor Chaining (The base Keyword)",
            "Create a Person base class requiring a name in its constructor. Create a Student derived class that passes the name to the base constructor using the base keyword.",
            t =>
            {
                t.Add(("Given Input: name = \"Emma\", school = \"Springfield High\" -> Expected Output: Name: Emma, School: Springfield High", () =>
                    PynativeExerciseRunner.AssertEqual("Name: Emma, School: Springfield High",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise20))));
            });

    public static PynativeExerciseRunner.SuiteResult Test21_KnightSealedMove() =>
        PynativeExerciseRunner.Run(21, "The Sealed Method (Sealed Overrides)",
            "In an RPGCharacter hierarchy, create a virtual Move() method. Have a Knight class override Move(), but mark the overridden method as sealed to stop subclasses of Knight (like Paladin) from changing it again.",
            t =>
            {
                t.Add(("Given Input: None -> Expected Output: The knight marches forward in heavy armor.", () =>
                    PynativeExerciseRunner.AssertEqual("The knight marches forward in heavy armor.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise21))));
            });

    public static PynativeExerciseRunner.SuiteResult Test22_AnimalMakeSound() =>
        PynativeExerciseRunner.Run(22, "Zoo Soundboard (Runtime Polymorphism)",
            "Create an array of Animal objects containing Lion, Sparrow, and Frog instances. Loop through the array and call a virtual MakeSound() method to demonstrate runtime polymorphism.",
            t =>
            {
                t.Add(("Given Input: animals = [Lion, Sparrow, Frog] -> Expected Output: Roar! / Tweet! / Ribbit!", () =>
                    PynativeExerciseRunner.AssertEqual("Roar!\nTweet!\nRibbit!",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise22))));
            });

    public static PynativeExerciseRunner.SuiteResult Test23_ShadowDisplay() =>
        PynativeExerciseRunner.Run(23, "Shadowing vs Overriding (The new Keyword)",
            "Create a base class with a method Display(). Create a derived class that uses the new keyword to shadow it. Write a test script showing the behavior difference when cast as the base type versus the derived type.",
            t =>
            {
                t.Add(("Given Input: None -> Expected Output: Display from DerivedClass / Display from BaseClass", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Display from DerivedClass\nDisplay from BaseClass",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise23))));
            });

    public static PynativeExerciseRunner.SuiteResult Test24_MicrowavePowerOn() =>
        PynativeExerciseRunner.Run(24, "Multi-level Appliance (Multi-level Inheritance & base Calls)",
            "Build an inheritance chain: Device -> KitchenAppliance -> Microwave. Override a PowerOn() method at each level, ensuring the lower levels call base.PowerOn() first.",
            t =>
            {
                t.Add(("Given Input: None -> Expected Output: Device powering on. / Kitchen appliance initializing. / Microwave ready to heat.", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Device powering on.\nKitchen appliance initializing.\nMicrowave ready to heat.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise24))));
            });

    public static PynativeExerciseRunner.SuiteResult Test25_CanvasRenderAll() =>
        PynativeExerciseRunner.Run(25, "Dynamic UI Rendering (Polymorphic Collections)",
            "Create a UIElement class with a virtual Draw() method. Create Button, TextBox, and Checkbox overrides. Implement a Canvas class that holds a list of UIElements and renders them all simultaneously.",
            t =>
            {
                t.Add(("Given Input: elements = [Button, TextBox, Checkbox] -> Expected Output: Drawing a button. / Drawing a text box. / Drawing a checkbox.", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Drawing a button.\nDrawing a text box.\nDrawing a checkbox.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise25))));
            });

    public static PynativeExerciseRunner.SuiteResult Test26_SqlDatabaseConnection() =>
        PynativeExerciseRunner.Run(26, "Database Connector (Abstract Classes & Methods)",
            "Create an abstract DatabaseConnection class with abstract methods OpenConnection() and CloseConnection(). Implement concrete SqlConnection and MongoDbConnection classes.",
            t =>
            {
                t.Add(("Given Input: None -> Expected Output: Opening SQL Server connection. / Closing SQL Server connection.", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Opening SQL Server connection.\nClosing SQL Server connection.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise26))));
            });

    public static PynativeExerciseRunner.SuiteResult Test27_ShapePerimeter() =>
        PynativeExerciseRunner.Run(27, "Abstract Shape Factory (Abstract Methods with Different Data)",
            "Design an abstract Shape class with an abstract method GetPerimeter(). Implement it across Triangle and Hexagon classes.",
            t =>
            {
                t.Add(("Given Input: Triangle(3, 4, 5), Hexagon(4) -> Expected Output: Triangle Perimeter = 12 / Hexagon Perimeter = 24", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Triangle Perimeter = 12\nHexagon Perimeter = 24",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise27))));
            });

    public static PynativeExerciseRunner.SuiteResult Test28_LatteBrew() =>
        PynativeExerciseRunner.Run(28, "Coffee Machine Blueprint (Mixing Concrete & Abstract Methods)",
            "Create an abstract WarmBeverage class with a concrete method BoilWater() and abstract methods Brew() and AddCondiments(). Implement a Latte class.",
            t =>
            {
                t.Add(("Given Input: None -> Expected Output: Boiling water to 100°C. / Brewing espresso shots. / Adding steamed milk.", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Boiling water to 100°C.\nBrewing espresso shots.\nAdding steamed milk.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise28))));
            });

    public static PynativeExerciseRunner.SuiteResult Test29_PdfParser() =>
        PynativeExerciseRunner.Run(29, "Document Parser (Abstract Class with a Constructor)",
            "Design an abstract Document class with a concrete constructor that initializes the filepath, and an abstract ParseContent() method implemented by PdfParser and CsvParser.",
            t =>
            {
                t.Add(("Given Input: filePath = \"report.pdf\" -> Expected Output: Parsing PDF content from report.pdf", () =>
                    PynativeExerciseRunner.AssertEqual("Parsing PDF content from report.pdf",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise29))));
            });

    public static PynativeExerciseRunner.SuiteResult Test30_PayPalProcessPayment() =>
        PynativeExerciseRunner.Run(30, "Online Payment Gateway (Shared Helper Method in an Abstract Class)",
            "Create an abstract PaymentProcessor class with a concrete ValidateTransaction() helper and abstract ProcessPayment() method for PayPal and Stripe integrations.",
            t =>
            {
                t.Add(("Given Input: amount = 150.00 -> Expected Output: Processing $150 through PayPal.", () =>
                    PynativeExerciseRunner.AssertEqual("Processing $150 through PayPal.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise30))));
            });

    public static PynativeExerciseRunner.SuiteResult Test31_GoblinDragonExecuteTurn() =>
        PynativeExerciseRunner.Run(31, "Game AI Behavior (Abstract Methods & Abstract Properties)",
            "Create an abstract EnemyAI class. Define an abstract ExecuteTurn() method alongside a protected abstract property AggressionLevel. Implement this in a Goblin and Dragon class.",
            t =>
            {
                t.Add(("Given Input: None -> Expected Output: Goblin attacks cautiously with aggression level 3. / Dragon unleashes a devastating attack with aggression level 9.", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Goblin attacks cautiously with aggression level 3.\nDragon unleashes a devastating attack with aggression level 9.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise31))));
            });

    public static PynativeExerciseRunner.SuiteResult Test32_AllInOnePrinter() =>
        PynativeExerciseRunner.Run(32, "The Print & Scan Combo (Multiple Interface Implementation)",
            "Create IPrinter and IScanner interfaces. Implement both in a single AllInOnePrinter class to show multiple interface inheritance.",
            t =>
            {
                t.Add(("Given Input: Print(\"Report.docx\"), Scan(\"Receipt.jpg\") -> Expected Output: Printing: Report.docx / Scanning: Receipt.jpg", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Printing: Report.docx\nScanning: Receipt.jpg",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise32))));
            });

    public static PynativeExerciseRunner.SuiteResult Test33_DriverExplicitTurns() =>
        PynativeExerciseRunner.Run(33, "Explicit Conflict Resolution (Explicit Interface Implementation)",
            "Create two interfaces, ILeftTurn and IRightTurn, both containing a method named Execute(). Implement both explicitly in a Driver class to avoid naming collisions.",
            t =>
            {
                t.Add(("Given Input: None -> Expected Output: Turning left. / Turning right.", () =>
                    PynativeExerciseRunner.AssertEqual("Turning left.\nTurning right.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise33))));
            });

    public static PynativeExerciseRunner.SuiteResult Test34_ConsoleLogger() =>
        PynativeExerciseRunner.Run(34, "Default Logger Logic (Default Interface Methods)",
            "Create an ILogger interface with an abstract LogError(string msg) method, and a default interface method LogInfo(string msg) that prints a timestamped message directly from the interface contract.",
            t =>
            {
                t.Add(("Given Input: LogError(\"Something went wrong.\"), LogInfo(\"Application started.\") -> Expected Output: [ERROR] Something went wrong. / [INFO HH:mm:ss] Application started.", () =>
                {
                    string output = OopConsoleHelper.CaptureConsole(OopExercises.RunExercise34);
                    PynativeExerciseRunner.PrintOutput(output, "[ERROR] Something went wrong.\n[INFO HH:mm:ss] Application started. (timestamp varies)");
                    if (!output.StartsWith("[ERROR] Something went wrong.", StringComparison.Ordinal))
                        throw new InvalidOperationException("expected LogError line to start with [ERROR] Something went wrong.");
                    if (!output.Contains("[INFO", StringComparison.Ordinal) ||
                        !output.Contains("Application started.", StringComparison.Ordinal))
                        throw new InvalidOperationException("expected LogInfo line to contain [INFO and Application started.");
                }));
            });

    public static PynativeExerciseRunner.SuiteResult Test35_PluginHost() =>
        PynativeExerciseRunner.Run(35, "Plugin Architecture (Interface-Based Extensibility)",
            "Design an IPlugin interface with a Start() method. Write a host program that accepts any object implementing IPlugin to dynamically extend functionality.",
            t =>
            {
                t.Add(("Given Input: LoggingPlugin, AnalyticsPlugin -> Expected Output: Logging plugin started. / Analytics plugin started.", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Logging plugin started.\nAnalytics plugin started.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise35))));
            });

    public static PynativeExerciseRunner.SuiteResult Test36_WeaponSortByDamage() =>
        PynativeExerciseRunner.Run(36, "Sortable Inventory (IComparable<T>)",
            "Create a Weapon class with Name and Damage properties. Implement the native .NET IComparable<Weapon> interface to sort a list of weapons by their damage values.",
            t =>
            {
                t.Add(("Given Input: Dagger (15), Greatsword (45), Bow (25) -> Expected Output: Dagger - 15 / Bow - 25 / Greatsword - 45", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Dagger - 15\nBow - 25\nGreatsword - 45",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise36))));
            });

    public static PynativeExerciseRunner.SuiteResult Test37_DatabaseSessionDispose() =>
        PynativeExerciseRunner.Run(37, "Disposable Resources (IDisposable)",
            "Create a DatabaseSession class that implements IDisposable. Demonstrate its usage inside a C# using statement block to show structured resource management.",
            t =>
            {
                t.Add(("Given Input: None -> Expected Output: Database session opened. / Running database query. / Database session closed.", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "Database session opened.\nRunning database query.\nDatabase session closed.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise37))));
            });

    public static PynativeExerciseRunner.SuiteResult Test38_FlyingBoatFlySwim() =>
        PynativeExerciseRunner.Run(38, "Abstract Class vs Interface (Combining Both)",
            "Create a scenario where an object needs to inherit core identity data from an abstract class (Vehicle) but also needs pluggable behaviors from multiple interfaces (IFlyable, ISwimmable). Implement a FlyingBoat class.",
            t =>
            {
                t.Add(("Given Input: Name = \"SkyCruiser\" -> Expected Output: SkyCruiser is soaring through the sky. / SkyCruiser is gliding across the water.", () =>
                    PynativeExerciseRunner.AssertEqual(
                        "SkyCruiser is soaring through the sky.\nSkyCruiser is gliding across the water.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise38))));
            });

    public static PynativeExerciseRunner.SuiteResult Test39_UserExplicitAdminReset() =>
        PynativeExerciseRunner.Run(39, "Explicit Interface Hiding",
            "Create an IAdmin interface with a ResetSystem() method. Implement it explicitly in a User class so that ResetSystem() is completely hidden unless the object is explicitly cast to an IAdmin.",
            t =>
            {
                t.Add(("Given Input: None -> Expected Output: System reset performed.", () =>
                    PynativeExerciseRunner.AssertEqual("System reset performed.",
                        () => OopConsoleHelper.CaptureConsole(OopExercises.RunExercise39))));
            });
}
