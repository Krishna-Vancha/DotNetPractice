#define DEBUG  // Preprocessor directive to enable testing code
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    [Flags]
    public enum UserPermissions
    {
        None = 0,
        Read = 1 << 0,
        Write = 1 << 1,
        Execute = 1 << 2,
        Delete = 1 << 3,
        ReadWrite = Read | Write
    }

    internal class Coding
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello!");
            //ShowDynamicExample();

            //  ShowBitwiseOperators();
            // ShowEnumFlagsExample();
            // ShowPreprocessorDirectives();
            //ClassIndexerExample();
            //ShowAnonymousTypes();
            //ShowTuplesExample();
            //ShowOverideOperators();
            // ShowLinqExample();
            //ShowAsyncAwaitExample();
            //while (true)
            //{ 
            //    Thread.Sleep(1001);
            //    Console.WriteLine("task is going");
            //}

            //Thread workerThread = new Thread(new ThreadStart(ShowDeadLockExample));
            //workerThread.Start();
            // Console.WriteLine("Main thread continues...");
            // workerThread.Join(); // Wait for the worker thread to finish
            // Console.WriteLine("Main thread ends here");

          ShowStrings();



        }
        /*Type: It is a Reference Type, but it behaves like a value type for equality (== compares values, not memory addresses).
         Feature,Syntax,Purpose
Verbatim,"string s = @""C:\Users"";",Ignores escape characters (like \).
Interpolation,"$""Hello {name}""",Inject variables directly into text.
Raw String,"""""""{""key"": ""val""}""""""",New in C# 11; handles quotes/newlines easily.
         tRIM (REMOVES SPACES AT BEGGINING AND END) AND SPLIT BASED ON PROVIDED CHAR , Substring(start, length): Extracts a part of the string.
        C. Splitting & JoiningSplit(char): Breaks a string into an array (e.g., "A,B".Split(',') $\rightarrow$ ["A", "B"]).string.Join(sep, array): Combines 
        an array into one string with a separator.
        5. KEY RULES (IMPORTANT FOR INTERVIEW)
✔ Interning: C# stores one copy of identical string literals in a "String Intern Pool" to save memory.
✔ Equality: s1 == s2 checks if the text is the same, not if they are the same object.
✔ Null vs Empty: null means no object exists; "" (Empty) is an object with zero characters.
        🟢 6. QUICK REVISION (1-MINUTE)
✔ Immutability = Strings cannot be changed in place.
✔ Interpolation = Use $ for clean formatting.
✔ Verbatim = Use @ for file paths.
✔ StringBuilder = Use for loops/heavy building.
✔ IsNullOrWhiteSpace = Best way to validate user input.
        dIFFERENCE BETWEEN nULL(nO oBJECT), eMPTY , wHITESPACE
         
         */
        public static void ShowStrings()
        {  //Literal
            string s = "Hel\\lo";
            //Verbatium for ignore escape chars
            string st = @"C:\users";


            //String Interpolation Inside: You can use single quotes, double quotes, and newlines freely without any escape characters, No \" or \n needed Indentation is handled by the closing quotes' position. $$""" = Interpolation that ignores single { }.
            string name = "Krishna";

            //New in C# 11; handles quotes/newlines easily.
            string str = """ Hello "Krishna" """;
            Console.WriteLine(str);
            Console.WriteLine(str.Contains("Hello"));
            Console.WriteLine(str.StartsWith("Hello"));
            Console.WriteLine(str.EndsWith("Krishna"));
            Console.WriteLine(str.IndexOf("Krishna"));
            Console.WriteLine(str.Replace("Krishna", "Bunty"));
            Console.WriteLine(str.ToUpper());
            Console.WriteLine(str.ToLower());
            Console.WriteLine(str.Trim()); //Removes white spaces from start and end
            Console.WriteLine(str.Substring(1, 5)); //Extracts substring starting at index 1 with length 5
            Console.WriteLine(str.Split(' ')); //Splits the string into an array based on the space character  


        }

        #region
        /*
         ### 🧠 C# MULTITHREADING – INTERVIEW NOTES

### 🟢 1. WHAT IS MULTITHREADING?
👉 **Multithreading** is the ability of a CPU to execute multiple **Threads** (workers) simultaneously within a single process.
👉 **Goal:** Perform multiple tasks at the same time (Parallelism) or keep the UI responsive while doing heavy background work.

### 🟢 2. CORE COMPONENTS & SYNTAX


| Component | Syntax / Example | Purpose |
| :--- | :--- | :--- |
| **Thread** | `Thread t1 = new Thread(MethodName);` | Creates a new worker. |
| **Start** | `t1.Start();` | Tells the OS to begin executing the thread. |
| **Join** | `t1.Join();` | The **Main** thread waits until `t1` finishes. |
| **Sleep** | `Thread.Sleep(1000);` | Pauses the current thread for X milliseconds. |
| **IsAlive** | `if (t1.IsAlive) { ... }` | Checks if the thread is still running. |

**Basic Syntax Example:**
```csharp
void Print() { Console.WriteLine("Worker Thread Running"); }

Thread t = new Thread(Print);
t.Start(); // Starts the worker
t.Join();  // Main thread waits here until Print() is done
Console.WriteLine("Worker Finished!");
```

### 🟢 3. THREAD SAFETY: THE `lock` KEYWORD
👉 **Problem:** If two threads try to update the same variable at the same time, the data gets corrupted.
👉 **Solution:** Use `lock` to ensure only **one** thread can enter a block of code at a time.

```csharp
private static readonly object _locker = new object();
int counter = 0;

void Increment() {
    lock (_locker) {
        counter++; // Safe: only one thread can touch 'counter' at a time
    }
}
```

### 🟢 4. CRITICAL CONCEPTS (INTERVIEW "MUST-KNOW")
| Concept | Definition | Analogy |
| :--- | :--- | :--- |
| **Race Condition** | Two threads "race" to update data, leading to unpredictable results. | Two people trying to write on the same sticky note at once. |
| **Deadlock** | Thread A waits for B, and Thread B waits for A. Both are stuck forever. | Two people at a door, both saying "After you," but neither moves. |
| **Thread Pool** | A collection of pre-created threads managed by the CLR. | A pool of on-call workers instead of hiring a new person every time. |
| **Foreground vs Background** | Foreground threads keep the app alive; Background threads close when the app exits. | Foreground = Pilot; Background = Cabin lights. |



### 🟢 5. HOW TO PREVENT DEADLOCKS
👉 **Rule 1:** Always acquire locks in the **same order**.
👉 **Rule 2:** Avoid nested locks (locking inside a lock).
👉 **Rule 3:** Use `Monitor.TryEnter()` which has a timeout, so it doesn't wait forever.

### 🟢 6. MULTITHREADING VS. ASYNC
This is a high-probability interview question:
* **Multithreading:** About **Workers**. You hire more people to do more work at once (CPU-bound).
* **Asynchronous:** About **Waiting**. You free up the worker while the "oven" is cooking (I/O-bound).

### 🟢 7. COMMON INTERVIEW QUESTIONS
👉 **Q1: Can we restart a thread after it has finished?**
❌ No. Once a thread completes, it cannot be restarted. You must create a new `Thread` object.
👉 **Q2: Why do we use a `private static readonly object` for locking?**
✔ To prevent external code from locking on our object, which could cause a deadlock. `readonly` ensures the reference doesn't change.
👉 **Q3: What is the difference between `Thread.Sleep()` and `Thread.Yield()`?**
✔ `Sleep` forces a pause. `Yield` tells the CPU: "I'm willing to give up my turn if another thread needs to run."

### 🟢 8. QUICK REVISION (1-MINUTE)
✔ `Thread` = An OS-level worker.
✔ `Start()` to run, `Join()` to wait.
✔ `lock` prevents **Race Conditions**.
✔ **Deadlocks** happen when threads wait for each other in a circle.
✔ Use **Thread Pool** for short-lived tasks to save resources.

### 🎯 FINAL INTERVIEW LINE
> "Multithreading in C# allows for parallel execution by managing multiple threads, but it requires careful synchronization using the `lock` keyword to prevent race conditions and consistent lock-ordering to avoid deadlocks."

---

**Would you like to see a code example of a Deadlock so you know exactly what to look for during a code review?**
         */
        #endregion
        public static void ShowMultiThreadiing()
        { 
            Console.WriteLine(" thread starts work...");
            Thread.Sleep(1000);
            Console.WriteLine("Thread ends here");
            ShowThreadRaceCondition();
        }
        public static void ShowThreadRaceCondition()
        {
            int counter = 0;

            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {  
                    counter++;
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    counter++;
                }
            });

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            Console.WriteLine("Counter value: " + counter + " (expected 2000000, may be less due to race condition)");
        }
        public static void ShowDeadLockExample()
        { 
            Object lock1= new Object();
            Object lock2= new Object();

            Thread t1=new Thread(() =>
            {
                lock (lock1)
                {   
                    Console.WriteLine("Thread 1 acquired lock1");
                    Thread.Sleep(100); // Simulate some work
                    lock (lock2)
                    {
                        Console.WriteLine("Thread 1 acquired lock2");
                    }

                }
            }
                );
            Thread t2 = new Thread( () =>
            {
                lock (lock2)
                {
                    Thread.Sleep(100); // Simulate some work
                    Console.WriteLine("Thread 1 acquired lock1");
                    lock (lock1)
                    {
                        Console.WriteLine("Thread 1 acquired lock2");
                    }

                }
            }
                );
            t1.Start(); t2.Start();
            t1.Join(); t2.Join();




        }
        #region
        /*
         * 
         Asynchronus programming helps to run long running tasks without freezing the program/application ,👉 “Async programming lets your program continue executing while waiting for long operations to complete.”
        Async marks the method as asynchronous, allowing the use of await inside it. Await pauses the method execution until the awaited task completes, without blocking the thread. This enables responsive applications that can handle multiple tasks concurrently.
        Await can only be used inside methods marked with async, and it can be applied to any task-returning method. When the awaited task completes, the method resumes execution from the point of the await statement.
        👉 A Task represents a Promise or a Future.
👉 It tells the caller: "I have started this work. I don't have the result yet, but I am giving you this 'receipt' (the Task object) so you can check on the status or wait for it later.
        Thread.Sleep(100) can be used to wait but it blocks the main thread.
        A non-blocking execution model allows a single thread to start a long-running task
        (for example, a database query) and then continue doing other work until that
        task completes. A thread is the smallest unit of execution in an operating system.

        Example (conceptual):

            public async Task ProcessData()
            {
                Console.WriteLine("Thread 1 starts work...");

                // Thread 1 is now free to do other work while awaiting
                await Task.Delay(2000);

                // A thread (maybe Thread 1, maybe another) comes back to finish:
                Console.WriteLine("Work finished!");
            }

        Note: 'async' does not mean parallel (multi-threading). It means waiting without
        holding a thread. The Thread Pool is a collection of worker threads used by the runtime.

        | Return Type | Use Case                |
| ----------- | ----------------------- |
| `Task`      | No return value         |
| `Task<T>`   | Returns value           |
| `void`      | Only for event handlers |
        Parallel execution 
        Task t1 = Task.Delay(1000);
        Task t2 = Task.Delay(2000);
        await Task.WhenAll(t1, t2);

         */

        #endregion
        public static async Task ShowAsyncAwaitExample()
        { 
            await Task.Delay(2000); // Simulate async work
            Console.WriteLine("task is done");


        }
        private static void ShowBitwiseOperators()
        {
            #region BitwiseOperatorNotes
            /*
            🧠 BITWISE OPERATORS – NOTES

            • WHAT: Bitwise operators operate on the binary representation of integer types.
            • COMMON OPERATORS:
              - &  (AND)   : bit is 1 only if both operands' bits are 1
              - |  (OR)    : bit is 1 if either operand's bit is 1
              - ^  (XOR)   : bit is 1 if exactly one operand's bit is 1
              - ~  (NOT)   : unary bitwise complement (flips all bits)
              - << (LSHIFT): shifts bits left (multiplies by 2^n for unsigned)
              - >> (RSHIFT): shifts bits right (sign-preserving for signed types)

            • USES: low-level programming, flags, masks, performance-sensitive code.
            • CAUTIONS:
              - Watch signed vs unsigned behavior for shifts.
              - Shifting by an amount >= width of the type is undefined/implementation-defined.
              - Use parentheses when mixing with arithmetic.

            • EXAMPLE:
              int a = 5;  // 0101
              int b = 3;  // 0011
              a & b == 1;  (0001)

            */
            #endregion
            Console.WriteLine("Bitwise Operators &, |, ^, ~, <<, >>");
            Console.Write("Enter first integer: ");
            string input1 = Console.ReadLine();
            if (!int.TryParse(input1, out int a))
            {
                Console.WriteLine("Invalid input for first integer.");
                return;
            }
            Console.Write("Enter second integer: ");
            string input2 = Console.ReadLine();
            if (!int.TryParse(input2, out int b))
            {
                Console.WriteLine("Invalid input for second integer.");
                return;
            }

            Console.WriteLine($"AND (bitwise) Operator: {a & b}");
            Console.WriteLine($"OR (bitwise) Operator: {a | b}");
            Console.WriteLine($"XOR (bitwise) Operator: {a ^ b}");
            Console.WriteLine($"NOT (bitwise) Operator on b: {~b}");
            Console.WriteLine($"Left shift Operator: {a << b}");
            Console.WriteLine($"Right shift Operator: {a >> b}");
        }
        private static void ShowEnumFlagsExample()
        {
            #region EnumFlagsNotes
            /*
            🧠 ENUM FLAGS – NOTES

            • WHAT: Mark enum with [Flags] to use bitwise operations for combinations of values.
            • WHY: Represents sets of options/permissions efficiently using bit fields.
            • KEY METHODS:
              - HasFlag(flag): checks whether a flag is set.
              - Bitwise OR (|) to add, AND with complement (& ~) to remove, XOR (^) to toggle.

            • RULES:
              - Assign powers of two: 1<<0, 1<<1, 1<<2 ...
              - Provide a None = 0 member.
              - Use combined convenience members (e.g., ReadWrite = Read | Write).

            • EXAMPLE:
              var p = Read | Write; p.HasFlag(Read) == true; p |= Execute; p &= ~Write;

            */
            #endregion
            Console.WriteLine("Enum Flags Example:");

            UserPermissions perm = UserPermissions.Read | UserPermissions.Write;
            Console.WriteLine($"Permissions :{perm}");

            if (perm.HasFlag(UserPermissions.Read))
            {
                Console.WriteLine("User has Read permission.");
            }

            // adding flag
            perm |= UserPermissions.Execute;

            // removing flag
            perm &= ~UserPermissions.Write;
            Console.WriteLine($"Updated Permissions :{perm}");
            if (perm.HasFlag(UserPermissions.Execute))
            {
                Console.WriteLine("User has Execute permission.");
            }

            // Toggling flag
            perm ^= UserPermissions.Delete;
            Console.WriteLine($"Toggled Permissions :{perm}");
            if (perm.HasFlag(UserPermissions.Delete))
            {
                Console.WriteLine("User has Delete permission.");
            }
        }
        private static void ShowPreprocessorDirectives()
        {
            #region PreprocessorNotes
            /*
            🧠 PREPROCESSOR DIRECTIVES – NOTES

            • WHAT: #if, #else, #endif, #define control conditional compilation.
            • USE: enable/disable debug-only code, compile different targets, platform-specific blocks.
            • EXAMPLE: #if DEBUG ... #endif — code inside only included when DEBUG is defined.
            • CAUTION: Preprocessor symbols are not C# variables — they are build-time flags.

            */
            #endregion
#if DEBUG
            Console.WriteLine("Debug code is enabled.");
#else
            Console.WriteLine("Debug code is disabled.");
#endif
            Console.WriteLine("This code runs regardless of the Debug directive.");
        }

        private static void ShowDynamicExample()
        {
            #region DynamicNotes
            /*
            ### 🧠 C# DYNAMIC KEYWORD – INTERVIEW NOTES

            ### 🟢 1. WHAT IS DYNAMIC?
            👉 The `dynamic` keyword tells the compiler to **skip static type checking** at compile time.
            👉 The type is resolved only at **Runtime** using the **DLR (Dynamic Language Runtime)**.

            ### 🟢 2. WHY DO WE USE IT?
            ✔ **COM Interop:** Easy communication with Office apps (Excel/Word).
            ✔ **Reflection:** Much cleaner syntax than using `MethodInfo.Invoke`.
            ✔ **JSON/API:** Handling data where the structure isn't known until runtime.
            ✔ **Dynamic Languages:** Integrating with Python (IronPython) or Ruby.

            ### 🟢 3. BASIC SYNTAX

            ```csharp
            dynamic value = "Hello"; 
            Console.WriteLine(value.Length); // Works

            value = 100; // Type changed from string to int
            value = value + 50; // Works at runtime (result: 150)

            ```

            ### 🟢 4. DYNAMIC VS OBJECT VS VAR
            | Feature | **dynamic** | **object** | **var** |
            | :--- | :--- | :--- | :--- |
            | **Checking** | Runtime | Compile-time | Compile-time |
            | **Casting** | Not needed | **Required** | Not needed |
            | **IntelliSense** | ❌ No | ✅ Yes (Base) | ✅ Yes (Full) |
            | **Performance** | Slower (DLR) | Fast | Fast |

            ### 🟢 5. KEY RULES (IMPORTANT FOR INTERVIEW)
            ✔ **DLR:** It runs on the Dynamic Language Runtime.
            ✔ **No IntelliSense:** The IDE doesn't know the members, so no autocomplete.
            ✔ **Implicit Conversion:** Can be assigned to any type without an explicit cast.
            ✔ **Errors:** Typos cause `RuntimeBinderException` at runtime, not build errors.

            ### 🟢 6. LIMITATIONS
            ❌ **Extension Methods:** You cannot call extension methods on dynamic types.
            ❌ **Performance:** There is a slight overhead because of runtime lookups.
            ❌ **Refactoring:** Renaming a method won't automatically update dynamic calls.

            ### 🟢 7. COMMON INTERVIEW QUESTIONS
            👉 **Q1: Can `var` change types like `dynamic`?**
            ❌ No. `var` is statically typed; the compiler just guesses the type once.
            👉 **Q2: What happens if a dynamic method doesn't exist?**
            💥 It throws a `RuntimeBinderException` when that line executes.
            👉 **Q3: Is dynamic the same as `object`?**
            ❌ No. `object` requires casting to access members; `dynamic` does not.

            ### 🟢 8. QUICK REVISION (1-MINUTE)
            ✔ `dynamic` = Bypasses compile-time checks.
            ✔ Uses **DLR** for runtime resolution.
            ✔ No casting needed, but no IntelliSense either.
            ✔ Great for JSON, COM, and Reflection.

            ### 🎯 FINAL INTERVIEW LINE
            > "The `dynamic` keyword in C# enables late binding by bypassing compile-time type checking, allowing for flexible coding in scenarios like COM Interop or Reflection where types are only known at runtime."
            */
            #endregion

            dynamic value = "Hello World";
            Console.WriteLine(value.Length); // Works fine

            value = 100; // Type changed from string to int
            value = value + 50; // Works at runtime (result: 150)
            Console.WriteLine(value);
        }

        public static void ClassIndexerExample()
        {
            #region ClassIndexerNotes
            /*
            🧠 CLASS INDEXER – NOTES

            • WHAT: Allows objects to be accessed like arrays using this[index].
            • SYNTAX: public T this[int index] { get { ... } set { ... } }
            • RULES: Uses 'this', cannot be static, can be overloaded, must have at least one parameter.
            • USE: custom collection wrappers, simplified access to internal fields.
            */
            #endregion
            ClassIndexer classIndexer = new ClassIndexer
            {
                a = 3,
                b = 5
            };
            classIndexer[0] = 10; // Sets a to 10

            Console.WriteLine(classIndexer[0]); // Output
        }
        public static void ShowAnonymousTypes()
        {
            #region AnonymousTypeNotes
            /* ### 🧠 C# ANONYMOUS TYPES – INTERVIEW NOTES

            ### 🟢 1. WHAT IS AN ANONYMOUS TYPE?
            👉 An **Anonymous Type** allows you to create an object without explicitly defining a class first.
            👉 It is a **read-only** object created on the fly, typically used for temporary data storage.

            ### 🟢 2. WHY DO WE USE THEM?
            ✔ **LINQ Queries:** Great for selecting a subset of properties from a database model.
            ✔ **Temporary Storage:** Useful when you need a "data container" for a short time and don't want to clutter your project with small classes.
            ✔ **Reduced Boilerplate:** No need to write constructors or override `ToString()`.

            ### 🟢 3. BASIC SYNTAX

            ```csharp
            // The 'new' keyword without a class name creates an anonymous type
            var student = new { ID = 1, Name = "Bunty", Major = "CS" };

            Console.WriteLine(student.Name); // Output: Bunty
            // student.ID = 2; // ❌ ERROR: Properties are Read-Only

            ```

            ### 🟢 4. KEY RULES (IMPORTANT FOR INTERVIEW)
            ✔ **`var` is Mandatory:** Since the type has no name, you must use `var` so the compiler can infer the type.
            ✔ **Read-Only:** All properties are **init-only**. You cannot change their values after creation.
            ✔ **Reference Type:** They are objects (Reference Types) derived directly from `System.Object`.
            ✔ **Scope:** They are generally **method-scoped**. You cannot easily pass an anonymous type as a parameter to another method (unless you use `dynamic` or `object`).

            ### 🟢 5. BEHIND THE SCENES (THE "PRO" KNOWLEDGE)
            👉 **Compiler Generated:** The C# compiler generates a class name at compile time (e.g., `<>f__AnonymousType0`).
            👉 **Property Projection:** If you have a variable `Name`, you can simplify the declaration:

            ```csharp
            string Name = "Bunty";
            var person = new { Name }; // Property name is automatically "Name"

            ```
            👉 **Equality:** Two anonymous objects are considered equal if they have the same **properties**, **types**, and **order** of properties.

            ### 🟢 6. ANONYMOUS TYPE VS TUPLES
            | Feature | **Anonymous Type** | **ValueTuple** |
            | :--- | :--- | :--- |
            | **Mutability** | **Read-Only** | Can be Mutable |
            | **Naming** | Named Properties | Named or Item1, Item2 |
            | **Passing** | Hard to pass between methods | Easy to return from methods |
            | **Type** | Reference Type (Class) | Value Type (Struct) |

            ### 🟢 7. COMMON INTERVIEW QUESTIONS
            👉 **Q1: Can we change the value of an anonymous type property?**
            ❌ No. They are immutable (read-only). You must create a new object.
            👉 **Q2: Can an anonymous type have methods?**
            ❌ No. They only contain public read-only properties.
            👉 **Q3: What is the base class of an anonymous type?**
            ✔ It inherits directly from `System.Object`.
            👉 **Q4: How does the compiler handle two identical anonymous types?**
            ✔ If the property names, types, and order match within the same assembly, the compiler uses the **same generated class** for both.

            ### 🟢 8. QUICK REVISION (1-MINUTE)
            ✔ `new { Prop = Value }` creates it.
            ✔ Must use `var`.
            ✔ Properties are **Read-Only**.
            ✔ Primarily used for **LINQ projections**.

            ### 🎯 FINAL INTERVIEW LINE
            > "Anonymous types provide a convenient way to encapsulate a set of read-only properties into a single object without having to explicitly define a type. They are most commonly used in LINQ 'select' clauses to transform data into temporary structures."
            */
            #endregion

            var anonymousObject = new { Name = "Krishna", Height = 5.7 };
            // anonymousObject.Name = "New Name"; // Error: Anonymous types are immutable

            dynamic anonymousObject2 = new { city = "Houston", area = "Elridge" };
            Console.WriteLine($"Name: {anonymousObject.Name}, Height: {anonymousObject.Height}");
            Console.WriteLine(anonymousObject.GetType());

        }


        #region  TuplesNotes
        /*   


## 🔹 Definition

* A **tuple** is a lightweight data structure to hold **multiple values in one variable**
* Can store **different data types**
* No need to define a class

---

## 🔹 Syntax (Modern - ValueTuple)

```csharp
var person = (Name: "John", Age: 25);
```

---

## 🔹 Key Features

* ✔ Stores multiple values
* ✔ Supports **named fields**
* ✔ Lightweight (value type)
* ✔ Useful for **temporary data grouping**

---

## 🔹 Accessing Values

### By position

```csharp
person.Item1
```

### By name (preferred)

```csharp
person.Name
```

---

## 🔹 Returning Multiple Values

```csharp
(string Name, int Age) GetPerson()
{
    return ("John", 25);
}
```

---

## 🔹 Deconstruction

```csharp
var (name, age) = GetPerson();
```

---

## 🔹 Tuple vs Class

| Tuple                    | Class            |
| ------------------------ | ---------------- |
| Lightweight              | Heavy            |
| No behavior              | Supports methods |
| Short-term use           | Long-term model  |
| Less readable (if large) | More structured  |

---

## 🔹 ValueTuple vs Tuple

| ValueTuple     | Tuple        |
| -------------- | ------------ |
| Modern (C# 7+) | Old          |
| Faster         | Slower       |
| Named fields   | Item1, Item2 |
| Preferred      | Avoid        |

---

## 🔹 Mutability

```csharp
var t = (Name: "Alice", Age: 30);
t.Age = 31; // allowed
```

---

## 🔹 Common Use Cases

* Returning multiple values from methods
* LINQ projections
* Temporary data storage
* Swapping values

---

## 🔹 Example (LINQ)

```csharp
var result = list.Select(x => (x.Name, x.Age));
```

---

## 🔹 Important Points

* Value type → stored on stack (usually)
* Internally uses `System.ValueTuple`
* Keep tuples **small (2–3 items max)**

---

## 🔹 Pitfalls

* ❌ Overusing tuples → hurts readability
* ❌ Large tuples → confusing (`Item1, Item2...`)
* ❌ Not suitable for domain models

---

## 🔹 Interview One-Liner

👉 *"Tuples in C# are lightweight value types used to group multiple values temporarily without defining a class, commonly used for returning multiple values from methods."*

---

         */
        #endregion
        public static void ShowTuplesExample()
        {
            var tuple1 = (1, "Hello");
            Console.WriteLine(tuple1.Item1);
            //Named Tuples
            var tuple2 = (Id: 2, Name: "Sri Ram");
            Console.WriteLine(GetTuple());
            //Deconstruction
            //Updating Tuple values
            tuple2.Name = "New Name";
            Console.WriteLine(tuple2);



        }
        public static (int, string) GetTuple()
        {
            return (3, "Return Tuple");
        }


        #region
        /* Linq is a powerful feature in C# that allows you to query and manipulate data in a more readable and concise way. It stands for Language Integrated Query and provides a set of methods and syntax for working with collections of data, such as arrays, lists, and databases.
         * Linq allows you to perform operations like filtering, sorting, grouping, and projecting data using a fluent syntax. It can be used with various data sources, including in-memory collections, databases, XML, and more.
         * belongs to System.Linq namespace and provides a set of extension methods for querying and manipulating data in collections. It allows you to write queries in a more readable and concise way, similar to SQL syntax, but integrated into the C# language.
         * 
         * 
         * 
         * 
         */
        #endregion
        public static void ShowLinqExample()
        {
            List<Player> playersList = new List<Player>
            {
              new Player{playerName="Krishna", team="Red" },
               new Player{playerName="Bunty", team="Blue" },
               new Player{playerName="Sri Ram", team="Red" },
                new Player{playerName="Shiva",team="Pink" }
     
            };

            List<Player> list= playersList.Where(p=>p.team=="Red").ToList();
            IEnumerable<Player> redPlayer=
                from p in playersList
                where p.team=="Red"
                select p;
            foreach (var player in redPlayer)
            {
                Console.WriteLine(player.playerName);
            }

        }






        public static void ShowOverideOperators()
        {
            ResourceAmount obj1 = new ResourceAmount("Gold", 100);
            ResourceAmount obj2 = new ResourceAmount("Gold", 50);
            ResourceAmount result = obj1 + obj2;
            Console.WriteLine($"Resource: {result.resourceName}, Amount: {result.amount}");
        }

        public class ClassIndexer
        {
            public int a;
            public int b;
            public int this[int input]
            {
                get
                {
                    switch (input)
                    {
                        case 0: return a;
                        case 1: return b;
                        default:
                            throw new IndexOutOfRangeException("Index shouldbe be between o and 2");
                    }
                }
                set
                {
                    switch (input)
                    {
                        case 0: a = value; break;
                        case 1: b = value; break;
                        default: throw new IndexOutOfRangeException("Index shouldbe be between o and 2");
                    }
                }
            }
        }
        public class ResourceAmount
        {
            public string resourceName;
            public int amount;
            public ResourceAmount(string resourceName, int amount)
            {
                this.resourceName = resourceName;
                this.amount = amount;
            }
            public static ResourceAmount operator +(ResourceAmount obj1, ResourceAmount obj2)
            {
                return new ResourceAmount(obj1.resourceName, obj1.amount + obj2.amount);
            }


        }
        public class Player
        {
            public string playerName;
            public string team;
            public Player() { }
            public Player(string playerName, string team) {
                this.playerName = playerName;
                this.team = team;
            }

        }

    }
}
