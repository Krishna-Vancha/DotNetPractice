using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;
using System.Xml.Linq;

namespace ConsoleApp1.C__Practise.PYnative.OOP;

// Source: https://pynative.com/csharp-oop-exercises/
// "C# OOP Exercises: 40 Coding Problems with Solutions" (39 exercises listed on the site)
//
// How to practice (same pattern as Exercise 3):
// 1. Read the Exercise block: Practice Problem, Purpose, Given Input, Expected Output (copied exactly from the site).
// 2. Under "--- Your solution ---", write the class(es) the Practice Problem asks for.
// 3. Implement RunExerciseNN() to run the Given Input (create objects, print results, return values if needed).
// 4. Run: dotnet run -- oop N  — tests call ONLY RunExerciseNN(); they do not contain your solution.

public static partial class OopExercises
{
    // Exercise 1: The Digital Watch (Class Fields & Methods)
    //
    // Practice Problem: Create a DigitalWatch class with fields for hours and minutes. Implement a method to add time and print the current time.
    //
    // Purpose: This exercise helps you practice combining fields and methods inside a class, where a method reads and updates the object's own data.
    //
    // Given Input: Starting time 10:45, add 30 minutes
    //
    // Expected Output: 11:15
    //
    // --- Your solution: DigitalWatch class + RunExercise01() below ---

    public static void RunExercise01() =>
        throw new NotImplementedException();

    // Exercise 2: Library Book Tracker (Multiple Constructors)
    //
    // Practice Problem: Build a Book class. Use multiple constructors: a default constructor, one taking just the title and author, and one taking title, author, and ISBN.
    //
    // Purpose: This exercise helps you practice constructor overloading, giving a class several ways to be created depending on how much information is available.
    //
    // Given Input: book1 (no arguments), book2 = ("1984", "George Orwell"), book3 = ("Dune", "Frank Herbert", "978-0441172719")
    //
    // Expected Output:
    // Title: Unknown Title, Author: Unknown Author, ISBN: N/A
    // Title: 1984, Author: George Orwell, ISBN: N/A
    // Title: Dune, Author: Frank Herbert, ISBN: 978-0441172719
    //
    // --- Your solution: Book class + RunExercise02() below ---

    public static void RunExercise02() =>
        throw new NotImplementedException();

    // Exercise 3: Bank Account Snapshot (Read-Only Fields)
    //
    // Practice Problem: Create an Account class where the account number can only be set via the constructor and is read-only afterward (using readonly fields).
    //
    // Purpose: This exercise helps you practice using the readonly keyword, which locks a field's value in place after construction, preventing it from ever being changed again.
    //
    // Given Input: accountNumber = "ACC-10293"
    //
    // Expected Output: Account Number: ACC-10293
    //
    // --- Your solution: Account class + RunExercise03() below ---

    public class Account
    {
        public readonly string AccountNumber;
        public Account(string num)
        {
            AccountNumber=num;
        }

    }  //Rem - Concept  what is readonly(do we have gettters and setters for readonly), init, property readonly
    public static void RunExercise03()
    {
        var account = new Account("ACC-10293");
        Console.WriteLine($"Account Number: {account.AccountNumber}");

    }

    // Exercise 4: The Singleton Configuration (Singleton Pattern)
    //
    // Practice Problem: Create a ConfigurationManager class that uses a private constructor and a static method to ensure only one instance ever exists.
    //
    // Purpose: This exercise helps you practice the Singleton pattern, a common design pattern that guarantees a class has exactly one shared instance throughout a program.
    //
    // Given Input: None
    //
    // Expected Output: Same instance: True
    //
    // (RunExercise04 returns true when GetInstance() yields the same reference twice.)
    //
    // --- Your solution: ConfigurationManager class + RunExercise04() below ---

    public static bool RunExercise04() =>
        throw new NotImplementedException();

    // Exercise 5: Smart Home Thermostat (Private Fields & Public Methods)
    //
    // Practice Problem: Implement a Thermostat class where the internal temperature history array is private, but public methods allow adding new readings.
    //
    // Purpose: This exercise helps you practice encapsulating an array inside a class, exposing only controlled methods to add and view its data instead of the array itself.
    //
    // Given Input: Readings 68.5, 70.2, 69.0
    //
    // Expected Output: Temperature History: 68.5, 70.2, 69
    //
    // --- Your solution: Thermostat class + RunExercise05() below ---
    class Thermostat
    {
        //decimal temperature;
        private List<decimal> temphistory=new List<decimal>();
        public void AddTemp(decimal temp)
        {
            temphistory.Add(temp);
        }
        public IReadOnlyList<decimal> ReadTempHistory()
        {
            return temphistory;
        }   
        // IReadOnlyList, string.Join()


    }
    public static void RunExercise05()
    {
        Thermostat readings=new Thermostat();
        readings.AddTemp(68.5m);
        readings.AddTemp(70.2m);
        readings.AddTemp(69m);
        Console.WriteLine($"Temperature History: {string.Join(", ", readings.ReadTempHistory())}");

    }
        

    // Exercise 6: E-Commerce Product (Internal Access Modifier)
    //
    // Practice Problem: Create a Product class utilizing internal modifiers to ensure the product's discount logic is only accessible within its own project assembly.
    //
    // Purpose: This exercise helps you practice the internal access modifier, which restricts visibility to code within the same project, striking a middle ground between public and private.
    //
    // Given Input: Name = "Wireless Mouse", Price = 25.00
    //
    // Expected Output: Discounted Price for Wireless Mouse: 22.5
    //
    // --- Your solution: Product class + RunExercise06() below ---
    internal class Product
    {
        public string Name { get; set; } = null;
        public double Price { get; set; }

        internal double ProductDiscount()
        {
            return Price / 10;
        }

    }
    public static void RunExercise06() 
        {
        Product mouse = new Product { Name = "Wireless Mouse", Price = 25.00 };
        double discount = mouse.ProductDiscount();

       Console.WriteLine($"Discounted Price for {mouse.Name}: {mouse.Price-discount}");

        }

    // Exercise 7: Static Math Utility (Static Class & Methods)
    //
    // Practice Problem: Design a MathWizard class that is marked static, containing static methods for calculating factorials and absolute differences, without instantiation.
    //
    // Purpose: This exercise helps you practice building a static utility class, useful for grouping related helper methods that don't need any per-object state.
    //
    // Given Input: Factorial(5), AbsoluteDifference(10, 3)
    //
    // Expected Output:
    // Factorial of 5 = 120
    // Absolute Difference = 7
    //
    // --- Your solution: MathWizard class + RunExercise07() below ---
    public class MathWizard
    {
        static public long Factorial(int n)
        {

            if (n == 0 || n == 1) { return 1; }
            else
            {
                return n * Factorial(n - 1);
            }
        }
       static public int AbsoluteDifference(int m, int n)
        { return Math.Abs(m-n);
        }    //Rem Math.Abs()
    }
    public static void RunExercise07()
    {
        //Console.Write("  ");
        Console.WriteLine($"Factorial of 5 = {MathWizard.Factorial(5)}\nAbsolute Difference = {MathWizard.AbsoluteDifference(10, 3)}");
    }

    // Exercise 8: Destructor Cleanup (Finalizers)
    //
    // Practice Problem: Create a ResourceWrapper class that simulates opening a file. Implement a finalizer/destructor (~ResourceWrapper()) that prints a message when the garbage collector claims the object.
    //
    // Purpose: This exercise helps you practice writing a finalizer, a special method that C#'s garbage collector calls automatically before reclaiming an object's memory.
    //
    // Given Input: None
    //
    // Expected Output:
    // File opened.
    // File handle cleaned up by garbage collector.
    //
    // --- Your solution: ResourceWrapper class + RunExercise08() below ---
    class ResourceWrapper
    {
        public ResourceWrapper()
        { 
            Console.WriteLine("File opened.");
        }
         ~ResourceWrapper()
        {
            Console.WriteLine("File handle cleaned up by garbage collector.");
        }
    }
    public static void RunExercise08()
    {
        ResourceWrapper obj = new ResourceWrapper();
        obj = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();

    }  //Need to practise code again 
       // rem concept GC.Collect(), GC.WaitForPendingFinalizers(), ~ClassName()


    // Exercise 9: Secure User Profile (Custom Property Get/Set)
    //
    // Practice Problem: Create a UserProfile class where the Password property can be set, but reading it always returns "********".
    //
    // Purpose: This exercise helps you practice writing a custom property accessor, where the get and set blocks don't simply mirror a single backing field.
    //
    // Given Input: Password = "MySecret123"
    //
    // Expected Output: ********
    //
    // --- Your solution: UserProfile class + RunExercise09() below ---
    class UserProfile()
    {
        private string password;
        public string Password
        {
            set => password = value;
            get=>  "********";
        }

    }
    public static string RunExercise09()
    {
        UserProfile user=new UserProfile();

        user.Password="MySecret123";
        //Console.WriteLine(user.GetPassword());
        return user.Password;
    }

    // Exercise 10: The Immutable Rectangle (Init-Only Properties)
    //
    // Practice Problem: Design a Rectangle class using init accessors for Width and Height, ensuring they can only be set during object initialization and never changed again.
    //
    // Purpose: This exercise helps you practice the init accessor, a modern C# feature that allows a property to be set only when the object is first created.
    //
    // Given Input: Width = 10, Height = 5
    //
    // Expected Output: Width: 10, Height: 5
    //
    // --- Your solution: Rectangle class + RunExercise10() below ---
    public class Rectangle
    { 
        public int Height { get; init; }
        public int Width { get; init; }
        //public Rectangle(int height, int width)
        //{
        //    Height = height;
        //    Width = width;
        //}
    }
    public static void RunExercise10()
    {
        Rectangle rec = new Rectangle() { Height=5,
            Width=10
        };

        Console.WriteLine($"Width: {rec.Width}, Height: {rec.Height}");

    }


    // Exercise 11: Auto-Property Rental Car (Auto-Properties vs Backing Fields)
    //
    // Practice Problem: Create a RentalCar class using auto-properties for Make and Model, but use a backing field for Odometer to ensure it can never be rolled backward.
    //
    // Purpose: This exercise helps you practice mixing simple auto-properties with a manually written property, used whenever a setter needs custom validation logic.
    //
    // Given Input: Set Odometer to 5000, then attempt to set it to 3000
    //
    // Expected Output: Odometer: 5000
    //
    // --- Your solution: RentalCar class + RunExercise11() below ---
    public class RentalCar
    {
        public int Make { get; set; }
        public string Model { get; set; }
        private long odometer;
        public long Odometer
        {
            get { return odometer; }
            set { if (value > odometer)
                {
                    odometer = value;
                }
                
            }
        }
     }
    public static void RunExercise11()
    {
        RentalCar car=new RentalCar() { 
        };
        car.Odometer = 5000;
        car.Odometer = 3000;
        Console.WriteLine($"Odometer: {car.Odometer}");

    }

    // Exercise 12: Smart Wardrobe Temperature (Validated Property Setter)
    //
    // Practice Problem: Create a Clothing class with a TargetTemperature property. Throw an ArgumentException in the set accessor if the value falls outside 15°C to 30°C.
    //
    // Purpose: This exercise helps you practice validating input inside a property setter, rejecting invalid values before they are ever stored.
    //
    // Given Input: Attempt to set TargetTemperature to 40, then set it to 22
    //
    // Expected Output:
    // Error: Temperature must be between 15 and 30 degrees Celsius.
    // Target Temperature: 22
    //
    // --- Your solution: Clothing class + RunExercise12() below ---
    public class Clothing
    {
        private int TargetTemperature;
        public int Temperature
        {
            get => TargetTemperature;
            set {
                if (value > 30 || value < 15)
                {
                    throw new ArgumentException("Error: Temperature must be between 15 and 30 degrees Celsius.");
                }
                else {
                    TargetTemperature = value;

                }
            }
        }
    }
    public static void RunExercise12()
    {
        Clothing cl = new Clothing();
        try
        {
            cl.Temperature = 12;
        }
        catch (Exception E)
        {
            Console.WriteLine(E.Message);
        }
        cl.Temperature = 22;
        Console.WriteLine($"Target Temperature: {cl.Temperature}");
    }

    // Exercise 13: Calculated Circle (Read-Only Computed Property)
    //
    // Practice Problem: Design a Circle class with a read-only calculated property Area that dynamically computes ? r² whenever called.
    //
    // Purpose: This exercise helps you practice a computed property, one that has no backing field at all and instead calculates its value fresh from other properties every time it is read.
    //
    // Given Input: Radius = 5
    //
    // Expected Output: Area = 78.54
    //
    // --- Your solution: Circle class + RunExercise13() below ---
    class Circle
    { 
       public double Radius { get; set; }
        public double Area
        {
            get { return Math.PI * Radius * Radius; }
        }
    }
    public static void RunExercise13()
        {
        Circle cl = new Circle();
        cl.Radius = 5;
        Console.WriteLine($"Area = {Math.Round(cl.Area,2)}");
        }

    // Exercise 14: Flight Reservation (Private Set with Controlled Method)
    //
    // Practice Problem: Implement a Flight class where the SeatNumber has a public get but a private set, modifiable only by the internal AssignSeat() method.
    //
    // Purpose: This exercise helps you practice restricting how a property can be changed, allowing anyone to read it while limiting writes to controlled logic inside the class.
    //
    // Given Input: AssignSeat("14A")
    //
    // Expected Output: Seat Number: 14A
    //
    // --- Your solution: Flight class + RunExercise14() below ---
    class Flight
    {
        public string SeatNumber { get; private set; }

        internal void AssignSeat(string seat)
        {
            SeatNumber=seat;
        }


    }
    public static void RunExercise14()
    { 
        Flight flight = new Flight();
        flight.AssignSeat("14A");
        Console.WriteLine($"Seat Number: {flight.SeatNumber}");
    }

    // Exercise 15: Game Character Health (Property Triggering Side Effects)
    //
    // Practice Problem: Create a Hero class where setting Health automatically triggers a boolean property IsAlive to flip to false if health hits 0.
    //
    // Purpose: This exercise helps you practice having a property setter update related state elsewhere in the object, instead of just storing a single value.
    //
    // Given Input: Set Health to 50, then set it to 0
    //
    // Expected Output:
    // Is Alive: True
    // Is Alive: False
    //
    // --- Your solution: Hero class + RunExercise15() below ---
    class Hero
    {
        private int health;
        public bool isAlive { get; private set; } = true;

        public int Health
        {
            get { return health; }
            set { health = value;
                if (value == 0)
                {
                    isAlive = false;
                }
            
            }
        }
    }
    public static void RunExercise15()
    { Hero obj=new Hero();
        obj.Health = 50;
        Console.WriteLine($"Is Alive: {obj.isAlive}");
        obj.Health = 0;
        Console.WriteLine($"Is Alive: {obj.isAlive}");
    }
       

    // Exercise 16: Bank Yield Calculator (Custom Set Logic with Bonus)
    //
    // Practice Problem: Create a SavingsAccount with a Balance property. Use custom get/set blocks to automatically calculate and apply a 2% bonus if the deposit exceeds $10,000.
    //
    // Purpose: This exercise helps you practice applying business logic directly inside a setter, transforming an incoming value before it is stored.
    //
    // Given Input: Balance = 15000
    //
    // Expected Output: Balance = 15300
    //
    // --- Your solution: SavingsAccount class + RunExercise16() below ---
    class SavingsAccount
    {
        public int balance;

        public int Balance
        {
            get { return balance; }
            set { balance= value + (value * 2 / 100); } 
        }

    }
    public static void RunExercise16()
    {
        SavingsAccount obj=new SavingsAccount();
        obj.Balance = 15000;
        Console.WriteLine($"Balance = {obj.Balance}");
    }

    // Exercise 17: Vehicle Hierarchy (Inheritance & Method Overriding)
    //
    // Practice Problem: Create a base class Vehicle and derived classes Car and Motorcycle. Override a StartEngine() method to print unique startup sounds.
    //
    // Purpose: This exercise helps you practice inheritance with more than one derived class, each providing its own version of a shared base class method.
    //
    // Given Input: None
    //
    // Expected Output:
    // Vroom! The car engine roars to life.
    // Vroooom! The motorcycle engine revs up.
    //
    // --- Your solution: Vehicle, Car, Motorcycle classes + RunExercise17() below ---
    class Vehicle {
        public virtual void  StartEngine()
        {
            Console.WriteLine("Vehicle Engine has started");
        }
    }
    class Car : Vehicle {
        public override void StartEngine()
        {
            Console.WriteLine("Vroom! The car engine roars to life.");
        }
    }
    class Motorcycle : Vehicle {
        public override void StartEngine()
        {
            Console.WriteLine("Vroooom! The motorcycle engine revs up.");
        }
    }
    public static void RunExercise17()
    {
        Vehicle carobj=new Car();
        carobj.StartEngine();
        Vehicle motorcycle =new Motorcycle();
        motorcycle.StartEngine();

    }

    // Exercise 18: The Sealed Security System (Sealed Classes)
    //
    // Practice Problem: Design a SecurityCore base class. Create a StrictAuth derived class and mark it as sealed so no other class can inherit and potentially alter its authentication logic.
    //
    // Purpose: This exercise helps you practice the sealed keyword, which stops a class from being used as a base class for further inheritance.
    //
    // Given Input: None
    //
    // Expected Output: Running strict authentication checks.
    //
    // --- Your solution: SecurityCore, StrictAuth classes + RunExercise18() below ---
    class SecurityCore
    {
        public virtual void Authenticate()
        {
            Console.WriteLine("Running base authentication.");
        }
    }
    sealed class StrictAuth : SecurityCore
    {
        public override void Authenticate()
        {
            Console.WriteLine("Running strict authentication checks.");
        }
    }
    public static void RunExercise18()
    {
        SecurityCore auth = new StrictAuth();
        auth.Authenticate();
    }

    // Exercise 19: Employee Payroll System (Virtual & Override Across Multiple Subclasses)
    //
    // Practice Problem: Write a base Employee class with a CalculatePay() method. Create HourlyEmployee and SalariedEmployee subclasses that override the calculation using virtual and override.
    //
    // Purpose: This exercise helps you practice applying method overriding across multiple different subclasses, each calculating a shared concept in its own way.
    //
    // Given Input: Hourly employee: rate $20, hours 80. Salaried employee: monthly salary $4000.
    //
    // Expected Output:
    // Hourly Employee Pay = 1600
    // Salaried Employee Pay = 4000
    //
    // --- Your solution: Employee, HourlyEmployee, SalariedEmployee classes + RunExercise19() below ---
    class Employee
    {
      
        public virtual double CalculatePay()
        {
            return 0;
        }

    }
    class HourlyEmployee : Employee {
       public double hours { get; set; }
        public double pay { get; set; }
        public override double CalculatePay()
        {
            return hours * pay;
        }
    }
    class SalariedEmployee : Employee
    {   public double pay { get; set; }
        public override double CalculatePay()
        {
            return pay;
        }
    }

    public static void RunExercise19()
    {
        HourlyEmployee emp=new HourlyEmployee();
        emp.hours = 20;
        emp.pay = 80;
        Console.WriteLine(emp.CalculatePay());
        SalariedEmployee semp=new SalariedEmployee();
        semp.pay = 4000;
        Console.WriteLine(semp.CalculatePay());
    }
    // Exercise 20: Base Constructor Chaining (The base Keyword)
    //
    // Practice Problem: Create a Person base class requiring a name in its constructor. Create a Student derived class that passes the name to the base constructor using the base keyword.
    //
    // Purpose: This exercise helps you practice constructor chaining across an inheritance hierarchy, letting a derived class forward data to its base class instead of duplicating logic.
    //
    // Given Input: name = "Emma", school = "Springfield High"
    //
    // Expected Output: Name: Emma, School: Springfield High
    //
    // --- Your solution: Person, Student classes + RunExercise20() below ---
    class Person
    {
        public string Name;
        public Person(string name)
        {
            Name = name;
        }
    }
    class Student : Person
    {
        public string School;
        public Student(string school, string name) : base(name)
        { 
            School = school;
        }
    }
    public static void RunExercise20()
    {
        Student student = new Student("SPR School", "Krishna");
        Console.WriteLine($"Name: {student.Name}, School: {student.School}");

    }

    // Exercise 21: The Sealed Method (Sealed Overrides)
    //
    // Practice Problem: In an RPGCharacter hierarchy, create a virtual Move() method. Have a Knight class override Move(), but mark the overridden method as sealed to stop subclasses of Knight (like Paladin) from changing it again.
    //
    // Purpose: This exercise helps you practice sealing a single overridden method rather than an entire class, locking in specific behavior partway through an inheritance chain.
    //
    // Given Input: None
    //
    // Expected Output: The knight marches forward in heavy armor.
    //
    // --- Your solution: RPGCharacter, Knight classes + RunExercise21() below ---

    public static void RunExercise21()
    {

        Knight obj = new Knight();
        obj.Move();
    }

    // Exercise 22: Zoo Soundboard (Runtime Polymorphism)
    //
    // Practice Problem: Create an array of Animal objects containing Lion, Sparrow, and Frog instances. Loop through the array and call a virtual MakeSound() method to demonstrate runtime polymorphism.
    //
    // Purpose: This exercise helps you practice runtime polymorphism, where a single loop can call the correct overridden method for each object without knowing its specific type in advance.
    //
    // Given Input: animals = [Lion, Sparrow, Frog]
    //
    // Expected Output:
    // Roar!
    // Tweet!
    // Ribbit!
    //
    // --- Your solution: Animal, Lion, Sparrow, Frog classes + RunExercise22() below ---
    class RPGCharacter
    {
        public virtual void  Move()
        {
            Console.WriteLine();
        }
    }
    class Knight : RPGCharacter
    {
        public sealed override void Move()
        {
            Console.WriteLine("The knight marches forward in heavy armor.");
        }
    }

    public class Animal
    {
        public virtual void MakeSound() {
            Console.WriteLine();
        }
    }
    public class Lion : Animal
    {
        public override void MakeSound() {
            Console.WriteLine("Roar!");
        }
    }
    public class Frog : Animal
    {
        public override void MakeSound() {
            Console.WriteLine("Ribbit!");
        }
    }
    public class Sparrow : Animal
    {
        public override void MakeSound() {
            Console.WriteLine("Tweet!");
        }
    }
    public static void RunExercise22()
    {
           List<Animal> list=new List<Animal>() {new Lion(),new  Sparrow(),new Frog()};   
        foreach(Animal a in list)
        { 
            a.MakeSound();
        }
        
    }

    // Exercise 23: Shadowing vs Overriding (The new Keyword)
    //
    // Practice Problem: Create a base class with a method Display(). Create a derived class that uses the new keyword to shadow it. Write a test script showing the behavior difference when cast as the base type versus the derived type.
    //
    // Purpose: This exercise helps you practice recognizing the difference between shadowing (new) and overriding (override), since shadowing depends on the variable's declared type rather than the object's actual type.
    //
    // Given Input: None
    //
    // Expected Output:
    // Display from DerivedClass
    // Display from BaseClass
    //
    // --- Your solution: BaseClass, DerivedClass + RunExercise23() below ---
    class BaseClass
    {
        public virtual void Display()
        { 
            Console.WriteLine("Display from BaseClass");
        }
    }
    class DerivedClass : BaseClass 
    {
        public new void Display()
        {
            Console.WriteLine("Display from DerivedClass");
        }
    }
    public static void RunExercise23() {
        DerivedClass derived = new DerivedClass();
        BaseClass baseRef = derived;

        derived.Display();
        baseRef.Display();

    }

    // Exercise 24: Multi-level Appliance (Multi-level Inheritance & base Calls)
    //
    // Practice Problem: Build an inheritance chain: Device -> KitchenAppliance -> Microwave. Override a PowerOn() method at each level, ensuring the lower levels call base.PowerOn() first.
    //
    // Purpose: This exercise helps you practice a three-level inheritance chain, where each level adds its own behavior on top of everything the levels above it already do.
    //
    // Given Input: None
    //
    // Expected Output:
    // Device powering on.
    // Kitchen appliance initializing.
    // Microwave ready to heat.
    //
    // --- Your solution: Device, KitchenAppliance, Microwave classes + RunExercise24() below ---

    class Device
    {
        public virtual void PowerOn()
        { 
            Console.WriteLine("Device powering on.");
        }
    }

    class KitchenAppliance : Device
    {
        public override void PowerOn()
        {
            base.PowerOn();
            Console.WriteLine("Kitchen appliance initializing.");
        }
    }

    class Microwave : KitchenAppliance
    {
        public override void PowerOn()
        {
            base.PowerOn();
            Console.WriteLine("Microwave ready to heat.");
        }
    }
    public static void RunExercise24() {

        Microwave obj=new Microwave();
        obj.PowerOn();
    }

    // Exercise 25: Dynamic UI Rendering (Polymorphic Collections)
    //
    // Practice Problem: Create a UIElement class with a virtual Draw() method. Create Button, TextBox, and Checkbox overrides. Implement a Canvas class that holds a list of UIElements and renders them all simultaneously.
    //
    // Purpose: This exercise helps you practice storing a mix of different subclasses in a single collection and rendering all of them polymorphically through one shared method.
    //
    // Given Input: elements = [Button, TextBox, Checkbox]
    //
    // Expected Output:
    // Drawing a button.
    // Drawing a text box.
    // Drawing a checkbox.
    //
    // --- Your solution: UIElement, Button, TextBox, Checkbox, Canvas classes + RunExercise25() below ---

    public static void RunExercise25() =>
        throw new NotImplementedException();

    // Exercise 26: Database Connector (Abstract Classes & Methods)
    //
    // Practice Problem: Create an abstract DatabaseConnection class with abstract methods OpenConnection() and CloseConnection(). Implement concrete SqlConnection and MongoDbConnection classes.
    //
    // Purpose: This exercise helps you practice defining an abstract class that cannot be instantiated on its own, forcing every subclass to supply its own implementation for each abstract method.
    //
    // Given Input: None
    //
    // Expected Output:
    // Opening SQL Server connection.
    // Closing SQL Server connection.
    //
    // --- Your solution: DatabaseConnection, SqlConnection, MongoDbConnection classes + RunExercise26() below ---
    public abstract class DatabaseConnection
    {
        public abstract void OpenConnection();
        public abstract void CloseConnection(); 
    }
    public class SqlConnection : DatabaseConnection {
        public override void OpenConnection()
        { 
            Console.WriteLine("Opening SQL Server connection.");
        }
        public override void CloseConnection() {
            Console.WriteLine("Closing SQL Server connection.");
        }
    }
    public class MongoDbConnection : DatabaseConnection {
        public override void OpenConnection()
        { }
        public override void CloseConnection() { }
    }
    public static void RunExercise26() {
        SqlConnection sq=new SqlConnection();
        sq.OpenConnection();
        sq.CloseConnection();
    }

    // Exercise 27: Abstract Shape Factory (Abstract Methods with Different Data)
    //
    // Practice Problem: Design an abstract Shape class with an abstract method GetPerimeter(). Implement it across Triangle and Hexagon classes.
    //
    // Purpose: This exercise helps you practice implementing the same abstract method across shapes that each need completely different data and formulas to calculate their result.
    //
    // Given Input: Triangle(3, 4, 5), Hexagon(4)
    //
    // Expected Output:
    // Triangle Perimeter = 12
    // Hexagon Perimeter = 24
    //
    // --- Your solution: Shape, Triangle, Hexagon classes + RunExercise27() below ---

    public abstract class Shape
    {
        public abstract double GetPerimeter();
    }
    public class Hexagon : Shape
    {   
        public double side { get; set; }
        public override double GetPerimeter()
        {
            return side * 6;
        }
    }
    public class Triangle : Shape
    {
        public double sideA { get; set; }

        public double sideB { get; set; }

        public double sideC { get; set; }
        public override double GetPerimeter()
        {
            return sideA + sideB + sideC;
        }
    }
    public static void RunExercise27()
    { 
        Triangle triangle = new Triangle();
        triangle.sideA = 30;
        triangle.sideB = 30;
        triangle.sideC = 30;
        Hexagon hexagon = new Hexagon();
        hexagon.side = 30;
        Console.WriteLine(triangle.GetPerimeter());
        Console.WriteLine(hexagon.GetPerimeter());

    }

    // Exercise 28: Coffee Machine Blueprint (Mixing Concrete & Abstract Methods)
    //
    // Practice Problem: Create an abstract WarmBeverage class with a concrete method BoilWater() and abstract methods Brew() and AddCondiments(). Implement a Latte class.
    //
    // Purpose: This exercise helps you practice mixing shared, ready-to-use logic with abstract methods in the same class, so subclasses only need to fill in the steps that actually vary.
    //
    // Given Input: None
    //
    // Expected Output:
    // Boiling water to 100°C.
    // Brewing espresso shots.
    // Adding steamed milk.
    //
    // --- Your solution: WarmBeverage, Latte classes + RunExercise28() below ---

    public static void RunExercise28() =>
        throw new NotImplementedException();

    // Exercise 29: Document Parser (Abstract Class with a Constructor)
    //
    // Practice Problem: Design an abstract Document class with a concrete constructor that initializes the filepath, and an abstract ParseContent() method implemented by PdfParser and CsvParser.
    //
    // Purpose: This exercise helps you practice giving an abstract class its own constructor, even though the class itself can never be instantiated directly, since subclasses still rely on it through base(...).
    //
    // Given Input: filePath = "report.pdf"
    //
    // Expected Output: Parsing PDF content from report.pdf
    //
    // --- Your solution: Document, PdfParser, CsvParser classes + RunExercise29() below ---
    public abstract class Document
    {
        public string filepath;

        public Document(string path)
        {
            filepath = path;
        }
       public abstract void ParseContent();
    }
    public class PdfParser : Document
    {    public PdfParser(string name) :base(name)
        { 
        }
        public override void ParseContent()
        {
            Console.WriteLine(filepath);
        }
    }

    public static void RunExercise29() {
        PdfParser obj = new PdfParser("temp\\folder");
        obj.ParseContent();
    }

    // Exercise 30: Online Payment Gateway (Shared Helper Method in an Abstract Class)
    //
    // Practice Problem: Create an abstract PaymentProcessor class with a concrete ValidateTransaction() helper and abstract ProcessPayment() method for PayPal and Stripe integrations.
    //
    // Purpose: This exercise helps you practice sharing common validation logic across every subclass, so each payment provider can reuse it instead of duplicating the same check.
    //
    // Given Input: amount = 150.00
    //
    // Expected Output: Processing $150 through PayPal.
    //
    // --- Your solution: PaymentProcessor, PayPal, Stripe classes + RunExercise30() below ---

  

    // Exercise 31: Game AI Behavior (Abstract Methods & Abstract Properties)
    //
    // Practice Problem: Create an abstract EnemyAI class. Define an abstract ExecuteTurn() method alongside a protected abstract property AggressionLevel. Implement this in a Goblin and Dragon class.
    //
    // Purpose: This exercise helps you practice using an abstract property alongside an abstract method, showing that properties, not just methods, can also be left for subclasses to define.
    //
    // Given Input: None
    //
    // Expected Output:
    // Goblin attacks cautiously with aggression level 3.
    // Dragon unleashes a devastating attack with aggression level 9.
    //
    // --- Your solution: EnemyAI, Goblin, Dragon classes + RunExercise31() below ---
    public abstract class EnemyAI
    { public abstract void ExecuteTurn();

        protected abstract int AggressionLevel { get; }
    }
    public class Goblin: EnemyAI
     {
        protected override int AggressionLevel => 3;
        public override void ExecuteTurn()
        { 
            Console.WriteLine($"{AggressionLevel}");
        }


    }

    public static void RunExercise31()
    {
        Goblin gob = new Goblin();
        gob.ExecuteTurn();
    }

    // Exercise 32: The Print & Scan Combo (Multiple Interface Implementation)
    //
    // Practice Problem: Create IPrinter and IScanner interfaces. Implement both in a single AllInOnePrinter class to show multiple interface inheritance.
    //
    // Purpose: This exercise helps you practice implementing more than one interface on a single class, something C# allows even though it only permits inheriting from one base class.
    //
    // Given Input: Print("Report.docx"), Scan("Receipt.jpg")
    //
    // Expected Output:
    // Printing: Report.docx
    // Scanning: Receipt.jpg
    //
    // --- Your solution: IPrinter, IScanner, AllInOnePrinter + RunExercise32() below ---

    public static void RunExercise30() =>
        throw new NotImplementedException();

    public interface IPrinter { 
        void Print();
    }
    public interface IScanner
    {
         void Scan();
    }

    public class AllInOnePrinter : IPrinter, IScanner
    {
        public  void Print()
        {
            Console.WriteLine("Printing");
        }
        public  void Scan()
        {
            Console.WriteLine("Scanning");
        }
    }
    public static void RunExercise32() {
        AllInOnePrinter obj = new AllInOnePrinter();
        obj.Print();
        obj.Scan();
    }

    // Exercise 33: Explicit Conflict Resolution (Explicit Interface Implementation)
    //
    // Practice Problem: Create two interfaces, ILeftTurn and IRightTurn, both containing a method named Execute(). Implement both explicitly in a Driver class to avoid naming collisions.
    //
    // Purpose: This exercise helps you practice explicit interface implementation, the technique C# provides for resolving a naming conflict when two interfaces share an identical method name.
    //
    // Given Input: None
    //
    // Expected Output:
    // Turning left.
    // Turning right.
    //
    // --- Your solution: ILeftTurn, IRightTurn, Driver classes + RunExercise33() below ---

    interface ILeftTurn
    { 
        void Execute();
    }
    interface IRightTurn
    {
        void Execute();
    }
    class Driver : ILeftTurn, IRightTurn
    {
        void ILeftTurn.Execute()
        { 
            Console.WriteLine("Turning Left");
        }
        void IRightTurn.Execute()
        {
            Console.WriteLine("Turning Right");
        }
    }
    public static void RunExercise33()
    {
        //Driver driver = new Driver();
        ILeftTurn leftTurn=new Driver();
        IRightTurn rightTurn = new Driver();
        leftTurn.Execute();
        rightTurn.Execute();


    }

    // Exercise 34: Default Logger Logic (Default Interface Methods)
    //
    // Practice Problem: Create an ILogger interface with an abstract LogError(string msg) method, and a default interface method LogInfo(string msg) that prints a timestamped message directly from the interface contract.
    //
    // Purpose: This exercise helps you practice default interface methods, a modern C# feature that lets an interface provide a ready-to-use implementation instead of forcing every class to write it.
    //
    // Given Input: LogError("Something went wrong."), LogInfo("Application started.")
    //
    // Expected Output:
    // [ERROR] Something went wrong.
    // [INFO 14:32:10] Application started.
    //
    // (The timestamp will differ depending on when you run the program.)
    //
    // --- Your solution: ILogger, ConsoleLogger + RunExercise34() below ---

    interface ILogger
    {
         void LogError(string msg);
        public void LogInfo(string msg)
        {
            Console.WriteLine(msg);
        }
    }
    public class ConsoleLogger : ILogger
    {
         public void LogError(string msg)
       { 
            Console.WriteLine(msg);
       }
     }
    public static void RunExercise34()
    { 

    }

    // Exercise 35: Plugin Architecture (Interface-Based Extensibility)
    //
    // Practice Problem: Design an IPlugin interface with a Start() method. Write a host program that accepts any object implementing IPlugin to dynamically extend functionality.
    //
    // Purpose: This exercise helps you practice programming against an interface rather than a specific class, allowing a host program to work with any plugin, even ones written later.
    //
    // Given Input: LoggingPlugin, AnalyticsPlugin
    //
    // Expected Output:
    // Logging plugin started.
    // Analytics plugin started.
    //
    // --- Your solution: IPlugin, LoggingPlugin, AnalyticsPlugin, PluginHost + RunExercise35() below ---
    public interface IPlugin
    {
        void Start();
    }
    public class LoggingPlugin: IPlugin
    { 
        public void Start()
        { 
            Console.WriteLine("Started Logging Plugin");
        }
    }
    public class AnalyticsPlugin : IPlugin
    {
        public void Start()
        {
            Console.WriteLine("Started Analytics Plugin");
        }
    }
    public class HostPlugin
    {
        public void RunPlugin(IPlugin plugin)
        {
            plugin.Start();
        }
    }
    public static void RunExercise35()
    {
        AnalyticsPlugin plug=new AnalyticsPlugin();
        HostPlugin hostPlugin=new HostPlugin();
        hostPlugin.RunPlugin(plug);
    }

    // Exercise 36: Sortable Inventory (IComparable<T>)
    //
    // Practice Problem: Create a Weapon class with Name and Damage properties. Implement the native .NET IComparable<Weapon> interface to sort a list of weapons by their damage values.
    //
    // Purpose: This exercise helps you practice implementing a built-in .NET interface, letting your own custom objects work directly with methods like List<T>.Sort().
    //
    // Given Input: Dagger (15), Greatsword (45), Bow (25)
    //
    // Expected Output:
    // Dagger - 15
    // Bow - 25
    // Greatsword - 45
    //
    // --- Your solution: Weapon class + RunExercise36() below ---
    class Weapon :IComparable<Weapon>
    { 
        public string Name { get; set; }
        public int Damage { get; set; }

        public int CompareTo(Weapon weapon)
        { 
            return weapon.Damage.CompareTo(Damage);
        }

    }
    public static void RunExercise36()
    { 
        List<Weapon> list=new List<Weapon>();
        list.Add(new Weapon { Name = "Dagger", Damage = 15 });
        list.Add(new Weapon { Name = "Bow", Damage = 25 });
        list.Add(new Weapon { Name = "Greatsword", Damage = 45});

        foreach (Weapon weapon in list)
        { 
            Console.WriteLine($"{weapon.Name} - {weapon.Damage}");
        }

    }

    // Exercise 37: Disposable Resources (IDisposable)
    //
    // Practice Problem: Create a DatabaseSession class that implements IDisposable. Demonstrate its usage inside a C# using statement block to show structured resource management.
    //
    // Purpose: This exercise helps you practice the IDisposable pattern, which guarantees that cleanup code runs automatically once a using block finishes, even if an error occurs inside it.
    //
    // Given Input: None
    //
    // Expected Output:
    // Database session opened.
    // Running database query.
    // Database session closed.
    //
    // --- Your solution: DatabaseSession class + RunExercise37() below ---
    public class DatabaseSession: IDisposable
    {
        public DatabaseSession()
        { 
            Console.WriteLine("Database Session Opened");
        }
        public void Dispose()
        {
            Console.WriteLine("Database session closed.");
        }
    }
    public static void RunExercise37()
    {
        using (DatabaseSession obj = new DatabaseSession())
        {
            Console.WriteLine("Running Dispose");
        }
    }

    // Exercise 38: Abstract Class vs Interface (Combining Both)
    //
    // Practice Problem: Create a scenario where an object needs to inherit core identity data from an abstract class (Vehicle) but also needs pluggable behaviors from multiple interfaces (IFlyable, ISwimmable). Implement a FlyingBoat class.
    //
    // Purpose: This exercise helps you practice combining a single abstract base class with multiple interfaces on the same class, since C# allows one base class but any number of interfaces.
    //
    // Given Input: Name = "SkyCruiser"
    //
    // Expected Output:
    // SkyCruiser is soaring through the sky.
    // SkyCruiser is gliding across the water.
    //
    // --- Your solution: Vehicle (abstract), IFlyable, ISwimmable, FlyingBoat + RunExercise38() below ---
    // (Note: Exercise 17 already declares a Vehicle class in this file; use a different name or a nested scope for this one.)

    public static void RunExercise38() =>
        throw new NotImplementedException();

    // Exercise 39: Explicit Interface Hiding
    //
    // Practice Problem: Create an IAdmin interface with a ResetSystem() method. Implement it explicitly in a User class so that ResetSystem() is completely hidden unless the object is explicitly cast to an IAdmin.
    //
    // Purpose: This exercise helps you practice using explicit interface implementation deliberately as a way to hide sensitive functionality from casual, everyday use of a class.
    //
    // Given Input: None
    //
    // Expected Output: System reset performed.
    //
    // --- Your solution: IAdmin, User class + RunExercise39() below ---

    interface IAdmin
    {
        void ResetSystem();
    }
    public class User : IAdmin
    {
        public void ResetSystem()
        {
            Console.WriteLine("Hiding Implementation");
        }
    }
    public static void RunExercise39()
    {
        User obj=new User();
        IAdmin iobj=obj;
        iobj.ResetSystem();
    }
}
