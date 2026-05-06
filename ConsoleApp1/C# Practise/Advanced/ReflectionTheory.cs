using System;
using System.Reflection;
using System.Linq;

namespace ConsoleApp1.CSharpPractise.Advanced;

/*
 * =============================================================================
 * Reflection in C# — study notes (interview-oriented)
 * =============================================================================
 *
 * Quick Review/Subtopics:
 * Reflection?, Assembly?, Type?, MemberInfo?, BindingFlags?,
 * late binding?, dynamic invocation?, attributes?,
 * performance overhead?, real-world use cases?, security concerns?
 *
 * Reflection in C# allows you to **inspect metadata and interact with types
 * at runtime** — even if they are unknown at compile time.
 *
 * =============================================================================
 *
 * 1) Core Concept: What is Reflection?
 * =============================================================================
 *
 * - Namespace: System.Reflection
 * - Allows:
 *      - Inspect types (classes, methods, properties)
 *      - Create instances dynamically
 *      - Invoke methods at runtime
 *      - Access private members (with permissions)
 *
 * Example:
 *      Type type = typeof(MyClass);
 *
 * Think:
 * - Reflection = "runtime inspection + runtime execution"
 *
 * =============================================================================
 *
 * 2) Key Classes in Reflection
 * =============================================================================
 *
 * Type:
 * - Represents metadata of a class, Name of the class
 *
 * Assembly:
 * - Represents compiled code (DLL / EXE)
 *
 * MemberInfo:
 * - Base class for members (MethodInfo, PropertyInfo, FieldInfo)
 *
 * MethodInfo:
 * - Represents methods
 *
 * PropertyInfo:
 * - Represents properties
 *
 * FieldInfo:
 * - Represents fields
 *
 * =============================================================================
 *
 * 3) Getting Type Information
 * =============================================================================
 *
 * Ways:
 *
 * 1. typeof():
 *      Type t = typeof(string);
 *
 * 2. GetType():
 *      obj.GetType();
 *
 * 3. From Assembly:
 *      Assembly.GetExecutingAssembly().GetType("Namespace.ClassName");
 *
 * =============================================================================
 *
 * 4) Inspecting Members
 * =============================================================================
 *
 * Get Methods:
 *      type.GetMethods();
 *
 * Get Properties:
 *      type.GetProperties();
 *
 * Get Fields:
 *      type.GetFields();
 *
 * Filtering:
 * - Use BindingFlags
 *
 * Example:
 *      type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
 *
 * =============================================================================
 *
 * 5) Creating Objects Dynamically (Late Binding)
 * =============================================================================
 *
 * Without "new" keyword:
 *
 *      object obj = Activator.CreateInstance(type);
 *
 * Use case:
 * - Plugins
 * - Dependency Injection containers
 *
 * =============================================================================
 *
 * 6) Invoking Methods Dynamically
 * =============================================================================
 *
 *      MethodInfo method = type.GetMethod("SayHello");
 *      method.Invoke(obj, null);
 *
 * With parameters:
 *      method.Invoke(obj, new object[] { "John" });
 *
 * =============================================================================
 *
 * 7) Accessing Properties & Fields
 * =============================================================================
 *
 * Property:
 *      var prop = type.GetProperty("Name");
 *      prop.SetValue(obj, "Alice");
 *      var value = prop.GetValue(obj);
 *
 * Field:
 *      var field = type.GetField("age");
 *      field.SetValue(obj, 25);
 *
 * =============================================================================
 *
 * 8) BindingFlags (VERY IMPORTANT)
 * =============================================================================
 *
 * Controls visibility and scope:
 *
 * Common flags:
 * - Public / NonPublic
 * - Instance / Static
 * - DeclaredOnly
 *
 * Example:
 *      BindingFlags.NonPublic | BindingFlags.Instance
 *
 * Used to access:
 * - Private methods
 * - Private fields
 *
 * =============================================================================
 *
 * 9) Attributes & Reflection
 * =============================================================================
 *
 * Reflection is heavily used with Attributes.
 *
 * Example:
 *      [Obsolete]
 *      public void OldMethod() { }
 *
 * Reading:
 *      type.GetCustomAttributes();
 *
 * Use cases:
 * - Validation frameworks
 * - ORMs (Entity Framework)
 * - ASP.NET Core routing
 *
 * =============================================================================
 *
 * 10) Performance Considerations
 * =============================================================================
 *
 * Reflection is:
 * - Slower than direct code
 * - Uses runtime lookup
 *
 * Why slow?
 * - Metadata inspection
 * - No compile-time optimization
 *
 * Optimization:
 * - Cache results (Type, MethodInfo)
 * - Avoid in tight loops
 *
 * =============================================================================
 *
 * 11) Real-World Use Cases
 * =============================================================================
 *
 * - Dependency Injection containers
 * - Serialization (JSON/XML)
 * - ORMs (Entity Framework)
 * - Unit testing frameworks
 * - Plugin systems
 *
 * =============================================================================
 *
 * 12) Reflection vs Dynamic
 * =============================================================================
 *
 * Reflection:
 * - Verbose
 * - Manual control
 *
 * dynamic keyword:
 * - Cleaner syntax
 * - Runtime binding handled automatically
 *
 * Trade-off:
 * - dynamic uses reflection internally
 *
 * =============================================================================
 *
 * 13) Security Considerations
 * =============================================================================
 *
 * Reflection can:
 * - Access private members
 * - Break encapsulation
 *
 * Risks:
 * - Sensitive data exposure
 *
 * Best practice:
 * - Use only when necessary
 *
 * =============================================================================
 *
 * 14) Best Practices
 * =============================================================================
 *
 * - Avoid reflection in performance-critical paths
 * - Cache metadata when reused
 * - Prefer interfaces / generics if possible
 * - Use reflection for extensibility, not core logic
 *
 * =============================================================================
 */

public static class ReflectionTheory
{
    public static void RunAllDemos()
    {
        TypeInspectionDemo();
        MethodInvocationDemo();
        PropertyAccessDemo();
    }

    #region Type Inspection

    public static void TypeInspectionDemo()
    {
        Type type = typeof(SampleClass);

        Console.WriteLine($"Class Name: {type.Name}");

        foreach (var method in type.GetMethods())
        {
            Console.WriteLine($"Method: {method.Name}");
        }
    }

    #endregion

    #region Method Invocation

    public static void MethodInvocationDemo()
    {
        Type type = typeof(SampleClass);
        object obj = Activator.CreateInstance(type);

        MethodInfo method = type.GetMethod("SayHello");
        method.Invoke(obj, null);
    }

    #endregion

    #region Property Access

    public static void PropertyAccessDemo()
    {
        Type type = typeof(SampleClass);
        object obj = Activator.CreateInstance(type);

        PropertyInfo prop = type.GetProperty("Name");

        prop.SetValue(obj, "Alice");

        Console.WriteLine(prop.GetValue(obj));
    }

    #endregion
}

public class SampleClass
{
    public string Name { get; set; }

    public void SayHello()
    {
        Console.WriteLine("Hello from Reflection!");
    }
}