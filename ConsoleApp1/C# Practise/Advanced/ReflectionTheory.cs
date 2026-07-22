using System;
using System.Reflection;

namespace ReflectionDemo
{
    // ====================================================================
    // NOTES: Reflection in C#
    // ====================================================================
    //
    // WHAT IS REFLECTION?
    // --------------------
    // Reflection is a feature in .NET that lets you inspect and interact
    // with metadata about types, methods, properties, and assemblies AT
    // RUNTIME — even types you didn't know about at compile time.
    // It lives in the System.Reflection namespace.
    //  Spoonfeed: 
    // CORE USES
    // ---------
    // - Inspecting type information (classes, interfaces, structs, enums)
    // - Creating instances of types dynamically
    // - Invoking methods/properties dynamically
    // - Reading custom attributes
    // - Late binding (calling members without knowing them at compile time)
    // - Building tools like serializers, ORMs, dependency injection
    //   containers, unit test runners
    //
    // KEY CLASSES
    // -----------
    //   Type            -> Represents type metadata (fields, methods,
    //                       properties, etc.)
    //   Assembly        -> Represents a loaded assembly; can load/inspect
    //                       other assemblies
    //   MethodInfo      -> Metadata about a method; used to invoke it
    //   PropertyInfo    -> Metadata about a property
    //   FieldInfo       -> Metadata about a field
    //   ConstructorInfo -> Metadata about constructors
    //   Activator       -> Used to create instances dynamically
    //
    // GETTING A Type OBJECT
    // ----------------------
    //   Type t1 = typeof(MyClass);           // compile-time known type
    //   Type t2 = obj.GetType();             // runtime instance
    //   Type t3 = Type.GetType("Namespace.MyClass, AssemblyName");
    //                                         // by string name
    //
    // COMMON EXAMPLES
    // ----------------
    // Inspect a type:
    //   Type type = typeof(Person);
    //   Console.WriteLine(type.Name);
    //   Console.WriteLine(type.Namespace);
    //   foreach (var prop in type.GetProperties())
    //       Console.WriteLine(prop.Name + " : " + prop.PropertyType);
    //   foreach (var method in type.GetMethods())
    //       Console.WriteLine(method.Name);
    //
    // Create an instance dynamically:
    //   object obj = Activator.CreateInstance(typeof(Person));
    //
    // Invoke a method dynamically:
    //   MethodInfo method = type.GetMethod("SayHello");
    //   method.Invoke(obj, null); // null = no parameters
    //
    // Get/Set a property value:
    //   PropertyInfo prop = type.GetProperty("Name");
    //   prop.SetValue(obj, "Alice");
    //   var value = prop.GetValue(obj);
    //
    // Read custom attributes:
    //   var attrs = type.GetCustomAttributes(typeof(MyCustomAttribute), true);
    //
    // Load an external assembly:
    //   Assembly asm = Assembly.LoadFrom("SomeLibrary.dll");
    //   foreach (Type t in asm.GetTypes())
    //       Console.WriteLine(t.FullName);
    //
    // BINDING FLAGS (for private/static members)
    // --------------------------------------------
    //   BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
    //   FieldInfo field = type.GetField("_secret", flags);
    //
    //   Common flags: Public, NonPublic, Instance, Static, DeclaredOnly
    //
    // PROS & CONS
    // -----------
    // Pros:
    //   - Enables generic, flexible frameworks (DI, serialization, ORMs)
    //   - Useful for plugin architectures / late binding
    //   - Good for testing tools/debuggers
    //
    // Cons:
    //   - Slower than direct calls (metadata lookup overhead)
    //   - Bypasses compile-time type safety
    //   - Can break encapsulation (accessing private members)
    //   - Harder to maintain/refactor safely
    //
    // PERFORMANCE TIP
    // ----------------
    // For repeated reflection calls, cache MethodInfo/PropertyInfo objects,
    // or use compiled expressions / Delegate.CreateDelegate for near-native
    // speed instead of calling Invoke() every time.
    //
    // RELATED CONCEPTS
    // -----------------
    //   - Attributes: metadata classes reflection often reads
    //     ([Serializable], custom attributes)
    //   - Expression Trees: faster alternative for dynamic invocation
    //   - dynamic keyword: simpler dynamic dispatch, different mechanism
    //     (DLR, not reflection)
    //   - Reflection.Emit: generates IL code at runtime (advanced use case)
    // ====================================================================

    // ------------------------------------------------------------------
    // Supporting types used by ReflectionTheory to demonstrate reflection
    // ------------------------------------------------------------------

    // A custom attribute we can read back via reflection
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class MyCustomAttribute : Attribute
    {
        public string Description { get; }
        public MyCustomAttribute(string description) => Description = description;
    }

    // Sample class that ReflectionTheory will inspect, instantiate, and invoke
    [MyCustomAttribute("This is a sample class used for reflection demos")]
    public class Person
    {
        private string _secret = "hidden-value";

        public string Name { get; set; } = "Unknown";
        public int Age { get; set; }

        public Person() { }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void SayHello()
        {
            Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }

        public string Greet(string greeting)
        {
            return $"{greeting}, {Name}!";
        }
    }

    // ------------------------------------------------------------------
    // ReflectionTheory: one method per reflection concept
    // ------------------------------------------------------------------
    public class ReflectionTheory
    {
        // 1. GETTING A TYPE OBJECT
        // Type is the entry point to almost all reflection operations.
        // You can get it 3 main ways: typeof(), obj.GetType(), or Type.GetType("name").
        public void GetTypeObject()
        {
            Type t1 = typeof(Person);                     // compile-time known type
            Person p = new Person();
            Type t2 = p.GetType();                         // from a runtime instance
            Type t3 = Type.GetType("ReflectionDemo.Person"); // by fully qualified string name

            Console.WriteLine($"typeof(): {t1.FullName}");
            Console.WriteLine($"GetType(): {t2.FullName}");
            Console.WriteLine($"Type.GetType(): {t3?.FullName ?? "not found"}");
        }

        // 2. INSPECTING TYPE METADATA
        // Once you have a Type, you can list its properties, methods, fields, etc.
        public void InspectType()
        {
            Type type = typeof(Person);

            Console.WriteLine($"Name: {type.Name}");
            Console.WriteLine($"Namespace: {type.Namespace}");
            Console.WriteLine($"IsClass: {type.IsClass}");
            Console.WriteLine($"BaseType: {type.BaseType}");

            Console.WriteLine("Properties:");
            foreach (PropertyInfo prop in type.GetProperties())
                Console.WriteLine($"  {prop.PropertyType.Name} {prop.Name}");

            Console.WriteLine("Methods:");
            foreach (MethodInfo method in type.GetMethods())
                Console.WriteLine($"  {method.Name}");
        }

        // 3. CREATING AN INSTANCE DYNAMICALLY
        // Activator.CreateInstance can call a parameterless constructor
        // or a specific one if you pass constructor arguments.
        public void CreateInstanceDynamically()
        {
            // Parameterless constructor
            object obj1 = Activator.CreateInstance(typeof(Person));
            Console.WriteLine($"Created (default ctor): {(obj1 as Person)?.Name}");

            // Constructor with arguments
            object obj2 = Activator.CreateInstance(typeof(Person), "Alice", 30);
            Console.WriteLine($"Created (ctor w/ args): {(obj2 as Person)?.Name}, {(obj2 as Person)?.Age}");
        }

        // 4. INVOKING A METHOD DYNAMICALLY
        // GetMethod() finds the MethodInfo, then Invoke() calls it on an instance.
        public void InvokeMethodDynamically()
        {
            Person person = new Person("Bob", 25);
            Type type = person.GetType();

            // Method with no parameters
            MethodInfo sayHello = type.GetMethod("SayHello");
            sayHello.Invoke(person, null); // null = no arguments

            // Method with parameters
            MethodInfo greet = type.GetMethod("Greet");
            object result = greet.Invoke(person, new object[] { "Hi" });
            Console.WriteLine(result);
        }

        // 5. GETTING AND SETTING PROPERTY VALUES
        // PropertyInfo lets you read/write a property without knowing
        // its name at compile time (useful for serializers, mappers, etc.)
        public void GetSetPropertyValues()
        {
            Person person = new Person();
            Type type = person.GetType();

            PropertyInfo nameProp = type.GetProperty("Name");
            nameProp.SetValue(person, "Charlie");

            object value = nameProp.GetValue(person);
            Console.WriteLine($"Name property value: {value}");
        }

        // 6. ACCESSING PRIVATE / NON-PUBLIC FIELDS
        // BindingFlags control which members GetField/GetMethod/etc. can see.
        // By default, only public instance members are returned.
        public void AccessPrivateField()
        {
            Person person = new Person();
            Type type = person.GetType();

            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
            FieldInfo secretField = type.GetField("_secret", flags);

            object originalValue = secretField.GetValue(person);
            Console.WriteLine($"Original secret: {originalValue}");

            secretField.SetValue(person, "new-hidden-value");
            Console.WriteLine($"Updated secret: {secretField.GetValue(person)}");
        }

        // 7. READING CUSTOM ATTRIBUTES
        // Attributes attached to a class/property/method can be read
        // back at runtime. This is how frameworks like ASP.NET, EF, and
        // serializers implement behavior driven by [Attribute] tags.
        public void ReadCustomAttributes()
        {
            Type type = typeof(Person);

            object[] attributes = type.GetCustomAttributes(typeof(MyCustomAttribute), true);
            foreach (object attr in attributes)
            {
                if (attr is MyCustomAttribute custom)
                    Console.WriteLine($"Found attribute: {custom.Description}");
            }
        }

        // 8. INSPECTING AN ASSEMBLY
        // An Assembly represents a loaded .dll/.exe. You can enumerate
        // every type it contains, which is the basis of plugin systems.
        public void InspectAssembly()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine($"Assembly: {assembly.GetName().Name}");

            Console.WriteLine("Types in this assembly:");
            foreach (Type t in assembly.GetTypes())
                Console.WriteLine($"  {t.FullName}");
        }

        // 9. USING CONSTRUCTORINFO DIRECTLY
        // Instead of Activator.CreateInstance, you can fetch a specific
        // ConstructorInfo and invoke it manually (more control, e.g. for
        // choosing between overloaded constructors explicitly).
        public void InvokeConstructorDirectly()
        {
            Type type = typeof(Person);

            ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string), typeof(int) });
            object instance = ctor.Invoke(new object[] { "Dana", 40 });

            Console.WriteLine($"Created via ConstructorInfo: {(instance as Person)?.Name}");
        }

        // 10. CHECKING TYPE RELATIONSHIPS
        // Reflection can answer questions like "does this type implement
        // this interface?" or "is this type assignable to that one?" —
        // useful for plugin discovery / generic frameworks.
        public void CheckTypeRelationships()
        {
            Type personType = typeof(Person);
            Type objectType = typeof(object);

            Console.WriteLine($"Is Person assignable to object? {objectType.IsAssignableFrom(personType)}");
            Console.WriteLine($"Is Person a value type? {personType.IsValueType}");
            Console.WriteLine($"Is Person sealed? {personType.IsSealed}");
        }

        // Runs every demo method in order so you can see full output at once.
        public void RunAll()
        {
            void Section(string title, Action action)
            {
                Console.WriteLine($"\n--- {title} ---");
                action();
            }

            Section(nameof(GetTypeObject), GetTypeObject);
            Section(nameof(InspectType), InspectType);
            Section(nameof(CreateInstanceDynamically), CreateInstanceDynamically);
            Section(nameof(InvokeMethodDynamically), InvokeMethodDynamically);
            Section(nameof(GetSetPropertyValues), GetSetPropertyValues);
            Section(nameof(AccessPrivateField), AccessPrivateField);
            Section(nameof(ReadCustomAttributes), ReadCustomAttributes);
            Section(nameof(InspectAssembly), InspectAssembly);
            Section(nameof(InvokeConstructorDirectly), InvokeConstructorDirectly);
            Section(nameof(CheckTypeRelationships), CheckTypeRelationships);
        }
    }

    // ------------------------------------------------------------------
    // Entry point to try it out
    // ------------------------------------------------------------------
    public class Program
    {
        public static void Main(string[] args)
        {
            var theory = new ReflectionTheory();
            theory.RunAll();
        }
    }
}