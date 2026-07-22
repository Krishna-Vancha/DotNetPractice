# C# notes

## Topics

Master list of topics covered in this file. Each item links to a full section below (search the heading name).

### C# concepts

1. Optional parameters  
2. Value types and reference types  
3. ref, in, and out parameters  
4. Structs  
5. Type casting  
6. Type conversion  
7. The `is` operator  
8. The `as` operator (safe casting)  
9. Discards `_` / `_ =`  
10. Keywords (const, readonly, yield, typeof, nameof, sizeof, default, init, sealed, Span, WinForms, extern, dynamic)  
11. Nullable in C#

### OOP

12. Encapsulation (data hiding, private fields, validation via methods/properties)  
13. Abstraction (hide complexity; interfaces, public contracts vs hidden implementation)  
14. Inheritance (concepts, keywords)  
15. Polymorphism — static and dynamic (overview)  
16. Method and constructor overloading  
17. Method overriding  
18. Interfaces (C# 8+ / 11+)  
19. Delegates (types, built-ins, variance, multicast)  
20. Lambdas  
21. Events  
22. Exceptions

### Advanced & collections

23. IEnumerable  
24. Reflection  
25. Span<T> / ReadOnlySpan<T>  
26. Expression-bodied members (vs lambdas)  
27. Data boxing and unboxing  
28. LINQ (Language Integrated Query)

---

## Index

Each topic has its own section below so you can scan and revise one topic at a time. Use **Topics** above for the grouped list; use the sections under this index for full notes and flash summaries.

### **Exceptions**

**QuickReview / subtopics:** try, catch, finally, throw (`throw;` vs `throw new …`); use `TryParse` or null-checks to avoid the high performance cost of throwing.

**finally** — takes no exception parameter; use an exception filter on `catch` with `when (condition)`.

**Members:** `ex.Message`, `ex.StackTrace`; **custom exceptions** inherit `Exception`.

In C#, exceptions use try–catch–finally: **try** holds risky code, **catch** handles errors, and **finally** always runs for cleanup. **`throw;`** preserves the original stack trace; **`throw new Exception`** creates a new throw site. For performance, **`TryParse`** is preferred over exceptions for validation. Use **`when`** for conditional catching. **Custom exceptions** define domain-specific errors.

*Source:* `ConsoleApp1\C# Practise\OOPs-Concepts\ExceptionsTheory.cs` (comment lines 10–13).

### **Polymorphism**

**QuickReview / subtopics:** static (compile-time) vs dynamic (runtime); method overloading; constructor overloading; method overriding (`virtual` / `override` / `sealed`); reference type vs object type rule.

**Static polymorphism** — compiler picks overload at compile time from name + parameter types/count/order; includes **method overloading** and **constructor overloading**; optional implicit widening (e.g. `int` → `double`) when no exact match.

**Dynamic polymorphism** — runtime dispatch via virtual method table; base reference + derived object → **which method runs** follows **object type**; **member visibility** follows **reference type**; requires `virtual` / `abstract` / `override` in C#.

**Overriding** — `override` replaces base behavior; `new` hides without overriding; `sealed override` stops further overrides.

*Source:* `ConsoleApp1\C# Practise\OOPs-Concepts\OppsTheory.cs` (comment lines 10–38).

### **Inheritance (types)**

**QuickReview / subtopics:** single (one base class); multilevel chain (`Device` → `Phone` → `SmartPhone`); hierarchical (many children, one base); multiple classes **not** allowed — use multiple **interfaces**; diamond problem avoided.

*Source:* `ConsoleApp1\C# Practise\OOPs-Concepts\InheritanceTheory.cs` — `RunDemo()`. *Also:* `InheritenceTheory.cs` (Employee/Manager, `virtual`/`override`/`new`).

### **Keywords**

**QuickReview / subtopics:** const, readonly, yield, typeof, nameof, sizeof, default, init, sealed, `Span<T>`, WinForms, extern + DllImport, dynamic (late binding).

*Source:* `ConsoleApp1\C# Practise\C#Basics\KeyWords.cs` (study notes + `RunSealedDemo`, `SecurityUtilities`).

### **Expression-bodied members**

**QuickReview / subtopics:** `=>` syntax; single-expression bodies; methods, properties, accessors, constructors; implicit `return`; vs lambda expressions (`Func`/`Action`, closures).

*Source:* `ConsoleApp1\C# Practise\Advanced\ExpressionBodiedTheory.cs` — `RunDemo()`, `UserProfile`, `MemberVsLambdaDemo`.

### **Data boxing and unboxing**

**QuickReview / subtopics:** value → `object` (implicit boxing, heap alloc); unbox with explicit cast; `InvalidCastException` on type mismatch; GC cost; prefer `List<T>` over `ArrayList`; avoid invisible boxing in string concat.

*Source:* `ConsoleApp1\C# Practise\Advanced\BoxingTheory.cs` — `RunDemo()`.

### **LINQ**

**QuickReview / subtopics:** `IEnumerable<T>` / `IQueryable<T>`; deferred execution; Where, Select, OrderBy, GroupBy, Sum/Count/Average; Any/All/Contains; First/Last/Single; Take/Skip; Distinct/Union/Intersect/Except; Join.

*Source:* `ConsoleApp1\C# Practise\Advanced\LinqTheory.cs` — `RunAllDemos()` (10 section demos).

------------------------------------------------------------------------------------------------------------------------

## Exceptions

*Quick review — same bullets as the practice class comments (lines 10–13).*

**QuickReview / subtopics:** try, catch, finally, throw (`throw;` vs `throw new …`); use `TryParse` or null-checks to avoid the high performance cost of throwing.

**finally** — takes no exception parameter; use an exception filter on `catch` with `when (condition)`.

**Members:** `ex.Message`, `ex.StackTrace`; **custom exceptions** inherit `Exception`.

In C#, exceptions use try–catch–finally: **try** holds risky code, **catch** handles errors, and **finally** always runs for cleanup. **`throw;`** preserves the original stack trace; **`throw new Exception`** creates a new throw site. For performance, **`TryParse`** is preferred over exceptions for validation. Use **`when`** for conditional catching. **Custom exceptions** define domain-specific errors.

------------------------------------------------------------------------------------------------------------------------

## Polymorphism

*Quick revision — static vs dynamic; overloading vs overriding*

**Definition:** One interface, many forms — the same operation can behave differently depending on type, signature, or runtime object.

### 1. Static polymorphism (compile-time / early binding)

- The **compiler** chooses the exact method or constructor **before** the program runs.
- Resolution uses **method name** + **parameter types**, **count**, and **order** (the signature).
- **No runtime lookup** for which overload — faster at call sites.
- **Examples:** **method overloading**, **constructor overloading**.
- If there is no exact match, the compiler may apply **implicit conversions** (e.g. promote `int` to `double` to match another overload).

```csharp
public int Sum(int a, int b) => a + b;
public double Sum(double a, int b, int c) => a + b + c;
// Sum(5, 6)     → int, int overload
// Sum(5, 6, 7)  → may use double, int, int overload (first arg widened)
```

### 2. Method overloading

- **Same method name**, **different parameter lists** in the **same** type (or inherited overloads visible to the caller).
- Return type **alone** does not distinguish overloads — signatures must differ.
- Used for APIs that do the same logical thing with different inputs (e.g. `Write(string)` vs `Write(byte[])`).

### 3. Constructor overloading

- **Same type name** as the class; multiple constructors with **different parameter lists**.
- **`this(...)`** chains to another constructor in the same class; **`base(...)`** chains to a base-class constructor.
- Lets callers construct objects in different ways (`new Point()`, `new Point(1, 2)`).

### 4. Dynamic polymorphism (runtime / late binding)

- The method executed is chosen at **runtime** from the **actual object type** on the heap (virtual dispatch / V-table).
- **Base reference, derived object:** `Base b = new Derived(); b.M();` — if `M` is **overridden**, **Derived**’s `M` runs; if only **hidden** with `new`, behavior depends on **reference** type at compile time for that call.
- **C# contract:** base member must be **`virtual`**, **`abstract`**, or already **`override`**; derived uses **`override`** to replace behavior.

### 5. Method overriding

| Keyword | Role |
|--------|------|
| **`virtual`** | Base allows derived to **override** |
| **`override`** | Derived **replaces** base implementation |
| **`sealed override`** | Override allowed here, **no further** override in subclasses |
| **`new`** | **Hides** base member; **not** dynamic override — call through base ref uses base unless cast |

```csharp
public class Parent
{
    public virtual void Display() => Console.WriteLine("Parent");
}
public class Child : Parent
{
    public override void Display() => Console.WriteLine("Child");
}
Parent p = new Child();
p.Display(); // "Child" — runtime type wins for virtual/override
```

### 6. Reference type vs object type (interview rule)

- **`Base b = new Derived();`**
- **Which members you can name** (visibility): **reference type** (`Base`).
- **Which overridden method runs:** **object creation type** (`Derived`) for `virtual`/`override`.
- **`new` hiding:** calling through `Parent` reference may still invoke **Parent**’s method even if object is `Child`.

### 7. Static vs dynamic — quick compare

| | Static (overloading) | Dynamic (overriding) |
|--|---------------------|----------------------|
| **When resolved** | Compile time | Runtime |
| **Mechanism** | Signature match | `virtual` / `override` |
| **Same name** | Yes, different parameters | Yes, same signature in hierarchy |
| **Typical keywords** | (none required) | `virtual`, `override`, `sealed` |

*Practice / demos:* `ConsoleApp1\C# Practise\OOPs-Concepts\OppsTheory.cs` — `RunAllDemos()`, `StaticPolymorphismDemo`, `ParentClass` / `ChildClass`.

------------------------------------------------------------------------------------------------------------------------

## Inheritance (types in C#)

*Quick revision — single, multilevel, hierarchical, interfaces vs multiple class bases (`InheritanceTheory.cs`)*

### 1. Single inheritance (supported)

- A derived class inherits from **exactly one** base class: `class Phone : Device`.
- C# allows **single class inheritance** to avoid the **diamond problem** (two bases with the same method name → ambiguity).

### 2. Multilevel inheritance (supported)

- Linear chain: `SmartPhone` → `Phone` → `Device`.
- `SmartPhone` sees members from the whole chain (`TurnOn`, `MakeCall`, `Browse`).

```csharp
public class Device { public void TurnOn() { } }
public class Phone : Device { public void MakeCall() { } }
public class SmartPhone : Phone { public void Browse() { } }
```

### 3. Hierarchical inheritance (supported)

- **Multiple** derived classes share **one** base: `SmartPhone` and `Laptop` both extend `Device`, but not each other.

### 4. Multiple inheritance (classes: not supported; interfaces: supported)

- **Invalid:** `class TechGadget : Device, Phone` — compile error (only one base class).
- **Valid:** `class TechGadget : Device, IWifiConnectable, ICamera` — one class + many interfaces.

| Type | Supported in C#? | Mechanism |
|------|------------------|-----------|
| Single | Yes | `class D : B` |
| Multilevel | Yes | Chain of `:` |
| Hierarchical | Yes | Many `: B` |
| Multiple (classes) | No | Use interfaces |
| Multiple (interfaces) | Yes | `class C : B, I1, I2` |

*Practice:* `InheritanceTheory.RunDemo()` — also called from `OppsTheory.RunAllDemos()`.  
*Related:* **Polymorphism**, **Interfaces**, `InheritenceTheory.cs` (Employee/Manager, `base`, `virtual`, `override`, `new`).

*Code reference:* `ConsoleApp1\C# Practise\OOPs-Concepts\InheritanceTheory.cs`

------------------------------------------------------------------------------------------------------------------------

## Keywords

*Quick revision — C# keywords and related features from `KeyWords.cs`*

### 1. `const`

- Value fixed at **compile time**; must be initialized where declared.
- **Implicitly static** (no instance `const` fields).
- Allowed types: primitives, `enum`, `string`, `null` for reference types where applicable, and other const-dependent constants — **not** arbitrary runtime objects.

### 2. `readonly`

- For **fields**: can be assigned in declaration or in constructors (instance or static depending on field); value fixed after construction completes.
- Broader type surface than `const` — reference types, structs, etc.

### 3. `const` vs `readonly` (quick compare)

| | **const** | **readonly** |
|---|-----------|--------------|
| When fixed | Compile time | After construction |
| Typical use | Literals, fixed config | Instance config set once in ctor |

### 4. `yield` (`yield return` / `yield break`)

- Used in **iterator** methods returning `IEnumerable` / `IEnumerator` / async streams.
- Compiler builds a **state machine** — lazy evaluation (values produced on demand).

### 5. `typeof`

- `Type t = typeof(string);` — obtains `System.Type` at **compile time** for a type known in source (metadata token).

### 6. `nameof`

- `nameof(myVar)` / `nameof(MyType.Member)` — string name at **compile time**; safe for refactors (`ArgumentException`, logging, `INotifyPropertyChanged`).

### 7. `sizeof`

- `sizeof(int)` — size in bytes for **unmanaged value types** (unsafe-context rules apply for some types in older language versions).

### 8. `default`

- `default` / `default(T)` — type’s default value (`0`, `false`, `null` for refs, etc.).
- **Default inference** with target typing in modern C#.

### 9. `init`

- Used on property or indexer **setters** assignable only during object initialization, in a constructor, or in a `with` expression for records.
- Good for **immutable DTO-style** objects: set at creation, not modified later.

### 10. `sealed`

- **On a class:** no other class may inherit (`public sealed class AppSettings { }`).
- **On a method with `override`:** `public sealed override void M() { }` — derived classes cannot override `M` again (final override).
- **Not** the same as `static`: `sealed` blocks subclassing; `static` is type-level, no instance.
- Common pairs: `virtual` → `override` → `sealed override`; or `sealed class` when the type must not be extended.

*Practice:* `KeyWords.RunSealedDemo()` — `SealedOverrideChild`, `SealedClass` with `init` property.

### 11. `Span<T>` (related feature, not a keyword)

- **Ref struct** that does not create new memory; points to existing contiguous memory.
- **`Span<T>`:** mutable view; **`ReadOnlySpan<T>`:** read-only view (strings, read-only data).
- **`.Slice(start, length)`** — another view without allocation or copying.
- Index `[]` reads/writes through the view; modifying `Span<T>` can modify the original array/memory.
- **Stack-only:** cannot be boxed, stored in class fields, or used across **async** / **`yield`** boundaries.

*See also:* **`Span<T>` / `ReadOnlySpan<T>`** in Topics (Advanced).

### 12. Windows Forms (WinForms)

- Free and open-source **GUI** class library included as part of the **.NET** framework.
- Introduced by Microsoft as the original **drag-and-drop** framework to build rich, **native desktop** applications for **Windows**.

### 13. `extern`

- **Modifier:** declares a method implemented **outside** your C# source code (no method body in C#).
- Tells the compiler: trust this **signature**; implementation is supplied at **runtime** (often a native Windows DLL via **P/Invoke**).
- Common pattern:

```csharp
[DllImport("advapi32.dll", SetLastError = true)]
public static extern bool RevertToSelf();
```

*Practice:* `KeyWords.SecurityUtilities` — `extern` + `DllImport` on `advapi32.dll` (Windows only; do not call without understanding impersonation context).

### 14. `dynamic`

- Keyword introduced in **C# 4.0**: tells the compiler to **bypass compile-time type checking**.
- Calls, properties, and operations on a `dynamic` variable are resolved **entirely at runtime** (DLR), not at build time.
- **Use when:** COM interop, some JSON/scripting scenarios, late-bound APIs where the compile-time type is unknown.
- **Trade-off:** typos and missing members surface at runtime (`RuntimeBinderException`), not as compile errors; limited IntelliSense.
- **`dynamic` vs `var`:** `var` is still **statically typed** at compile time; `dynamic` defers typing to runtime.
- **`dynamic` vs `object`:** `object` requires explicit casts; `dynamic` allows direct member access when the runtime type supports it.

*Practice:* `KeyWords.RunDynamicDemo()`

*Code reference:* `ConsoleApp1\C# Practise\C#Basics\KeyWords.cs`

------------------------------------------------------------------------------------------------------------------------

## Expression-bodied members

*Quick revision — C# 6+ `=>` syntax for concise class members (`ExpressionBodiedTheory.cs`)*

### Definition

Introduced in **C# 6** (expanded in later versions). Expression-bodied members replace a traditional `{ ... }` block that contains **only one expression** with the fat-arrow operator (`=>`).

- **Syntax:** `member_signature => expression;`
- **Rule:** Use only when the body is a **single** statement or expression.
- **Return:** For value-returning members (methods, property getters), **`return` is implicit** — do not write it.

### Supported member categories

- Methods (value-returning or `void`)
- Read-only properties
- Property accessors (`get` / `set` blocks)
- Constructors and destructors
- Indexers

### Examples (`UserProfile`)

```csharp
// Constructor
public UserProfile(string firstName, string lastName) =>
    (_firstName, _lastName) = (firstName, lastName);

// Read-only property
public string FullName => $"{_firstName} {_lastName}";

// Accessors with validation
public int Age
{
    get => _age;
    set => _age = value > 0 ? value : throw new ArgumentException("Age must be positive.");
}

// Value-returning method
public string GetGreeting() => $"Hello, my name is {FullName}!";

// Void method
public void LogToConsole() => Console.WriteLine($"Log Triggered for: {FullName}");
```

### Architectural benefit

Reduces boilerplate in small utility types, DTOs, and domain entities **without** a runtime performance penalty — the compiler emits the same kind of IL as a normal member body.

### Expression-bodied members vs lambda expressions

| | **Expression-bodied member** | **Lambda expression** |
|---|------------------------------|------------------------|
| **Purpose** | Shorthand for a **named** class member | **Anonymous** function passed as data |
| **Left of `=>`** | Member name + signature | Parameter list |
| **Lifetime** | Permanent part of the type | Often stored in `Func<>` / `Action<>` or passed to a method |
| **Closures** | No — normal instance/static member | Yes — can capture outer locals |

**Mental model:**

- Expression-bodied member = *how you define a permanent class member concisely.*
- Lambda expression = *inline code passed on-the-fly to a delegate or API.*

```csharp
// Expression-bodied member (named, belongs to the class)
public int MultiplyByTwo(int number) => number * 2;

// Lambda (anonymous, assigned to Func<>)
Func<int, int> lambdaProcessor = (x) => x * 2;
```

*Practice:* `ExpressionBodiedTheory.RunDemo()` — `UserProfile` samples + `MemberVsLambdaDemo.RunPipeline()`.  
*Related:* **Lambdas** (`LambdaTheory.cs`), **Delegates**.

*Code reference:* `ConsoleApp1\C# Practise\Advanced\ExpressionBodiedTheory.cs`

------------------------------------------------------------------------------------------------------------------------

## Data boxing and unboxing

*Quick revision — value type ↔ reference type conversions (`BoxingTheory.cs`)*

### 1. Boxing (value type → reference type)

- **Allocation:** A new object wrapper is allocated on the managed **heap**.
- **Copying:** The value (often in a stack frame or register) is **copied** into that heap object.
- **Conversion:** Happens **implicitly** — no cast required (e.g. assign `int` to `object`).

```csharp
int stackValue = 150;
object boxedObject = stackValue;  // boxing
```

### 2. Unboxing (reference type → value type)

- **Verification:** The CLR checks the boxed object’s **exact** underlying type.
- **Copying:** The value is copied from the heap object into a value-type variable.
- **Conversion:** Requires an **explicit cast**. Wrong type → `InvalidCastException` (not numeric truncation).

```csharp
int unboxedValue = (int)boxedObject;  // unboxing

double d = 99.99;
object boxed = d;
int bad = (int)boxed;  // InvalidCastException — must unbox as double, then cast if needed
```

### 3. Performance impact

- Boxing causes **heap allocation** → more work for the **GC**.
- Thousands of boxing operations in loops (e.g. legacy non-generic collections) add noticeable CPU overhead.
- **Invisible boxing:** concatenating value types with `+` on `object`-based APIs can box (e.g. `"Age: " + age`).
- **Prefer:** `List<T>` over `ArrayList`, generics over `object`, interpolated strings / `ToString()` instead of boxing through `object`.

```csharp
int age = 26;
Console.WriteLine("User Age: " + age);           // may box
Console.WriteLine($"User Age: {age.ToString()}"); // avoids boxing via object
```

*Practice:* `BoxingTheory.RunDemo()` — pipeline, failed unbox, performance examples.  
*Related:* **Value types and reference types**, **Generics**, **Structs** (boxing section).

*Code reference:* `ConsoleApp1\C# Practise\Advanced\BoxingTheory.cs`

------------------------------------------------------------------------------------------------------------------------

## LINQ (Language Integrated Query)

*Quick revision — query in-memory sequences with `System.Linq` (`LinqTheory.cs`)*

### Definition

**LINQ** lets you **filter, sort, group, and project** data using a consistent syntax over **`IEnumerable<T>`** (in memory) or **`IQueryable<T>`** (remote providers such as EF Core). It lives in **`System.Linq`** as **extension methods**; predicates and projections are usually **lambdas**.

### Two syntax styles

| Style | Example |
|-------|---------|
| **Method** | `players.Where(p => p.Team == "Red").Select(p => p.Name)` |
| **Query** | `from p in players where p.Team == "Red" select p.Name` |

Both compile to similar operator chains; use whichever reads clearer for the team.

### Deferred vs immediate execution

| Kind | Examples | When it runs |
|------|----------|--------------|
| **Deferred** | `Where`, `Select`, `OrderBy`, `GroupBy` | When the result is **enumerated** (`foreach`, `ToList`, etc.) |
| **Immediate** | `ToList`, `ToArray`, `Count()`, `Sum()`, `First()`, `Max()` | **Right away**; often allocates or fully consumes the sequence |

- Enumerating the **same deferred chain twice** runs the pipeline **twice** — materialize with **`ToList()`** if you need multiple passes.
- **`IQueryable<T>`** uses **expression trees** so a provider can translate the query (e.g. to SQL); **`IEnumerable<T>`** LINQ runs **in-process** on your objects.

### Operators by category (`LinqTheory` demos)

| # | Category | Main methods | Demo |
|---|----------|--------------|------|
| 1 | **Filtering** | `Where` | `Filtering_Demo` |
| 2 | **Projection** | `Select` | `Projection_Demo` |
| 3 | **Sorting** | `OrderBy`, `OrderByDescending`, `ThenBy` | `Sorting_Demo` |
| 4 | **Grouping** | `GroupBy` | `Grouping_Demo` |
| 5 | **Aggregation** | `Sum`, `Count`, `Average`, `Min`, `Max` | `Aggregation_Demo` |
| 6 | **Quantifiers** | `Any`, `All`, `Contains` | `Quantifier_Demo` |
| 7 | **Element** | `First`, `FirstOrDefault`, `Last`, `Single` | `Element_Demo` |
| 8 | **Partitioning** | `Take`, `Skip` | `Partitioning_Demo` |
| 9 | **Set** | `Distinct`, `Union`, `Intersect`, `Except` | `SetOperations_Demo` |
| 10 | **Join** | `Join` (inner join, SQL-like) | `Join_Demo` |

### Example snippets

```csharp
// Filtering
numbers.Where(n => n % 2 == 0);

// Projection
names.Select(n => n.Length);

// Join
students.Join(departments, s => s.DepartmentId, d => d.Id, (s, d) => new { s.Name, d.Department });
```

### Performance (interview)

- LINQ often allocates **delegates** and **iterators** — fine for most app code; profile hot paths.
- Prefer a **`for`** loop on **`List<T>`** when micro-optimization matters.
- Avoid **multiple enumerations** of an expensive deferred chain without caching.

*Practice:* `LinqTheory.RunAllDemos()` or `LinqTheory.RunDemo()` — all 10 sections above.  
*Related:* **Lambdas**, **Delegates**, **IEnumerable**, **Collections** (LINQ section in `Collections.cs`).

*Code reference:* `ConsoleApp1\C# Practise\Advanced\LinqTheory.cs`

------------------------------------------------------------------------------------------------------------------------

## Optional parameters

*Quick revision — optional parameters in method signatures*

### 1. Optional parameters syntax

To make a parameter optional, you assign it a value in the method declaration. If the caller omits the argument, the default value is used.

- **Syntax:** `public void LogMessage(string message, int priority = 1)`

### 2. Strict constraints

- **Placement:** Optional parameters **must** appear at the end of the parameter list, after all required parameters.
- **Evaluation:** Default values must be **constant expressions** (literals, `const`, `default`, or `null`). They are evaluated at compile time, not runtime.

### 3. Use cases and alternatives

- **Overloading:** Optional parameters are a modern alternative to method overloading, reducing boilerplate when you have multiple versions of the same method.
- **Named arguments:** These let you skip certain optional parameters and specify only the ones you want to change (e.g. `LogMessage("Test", priority: 5)`).  //remember this is how you override the default value of optional param, (use : , not =)

### 4. The `[Optional]` attribute

You can use the `[Optional]` attribute from `System.Runtime.InteropServices`.

- **Note:** If no default value is provided with this attribute, the parameter uses the type’s default value (e.g. `0` for `int`, `null` for `string`).

### 5. Syntax for default, const, and null

Optional parameters can be initialized using various constant types:

- **Literal/constant:** `public void SetScore(int score = 100)`
- **Const field:** `public void SetRole(string role = UserRoles.Guest)` (where `Guest` is a `const string`)
- **Null (for reference/nullable types):** `public void Notify(string? message = null)`
- **Default keyword:** `public void Reset<T>(T value = default)`

------------------------------------------------------------------------------------------------------------------------

## Value types and reference types

*Quick revision — value vs reference semantics*

### 1. Core idea

- **Value types** are stored in **stack** memory (or **inlined** inside other types). **Assignment copies the whole value.**
- **Reference types** store a **reference** to an object, usually on the **heap**. **Assignment copies the reference;** two variables can point to the **same** object.

### 2. What counts as which

- **Value types:** `struct`, `enum`, **built-in primitives** (`int`, `bool`, `char`, `double`, `decimal`, etc.), and **`record struct`**. Tuples can be struct-based value types depending on use.
- **Reference types:** `class`, `interface`, `delegate`, **arrays** (all element kinds), `string` (**reference**, **immutable**), **`record` / `record class`** (reference by default), etc.

### 3. Default values

- **Value type:** `default` is **all-bits-zero** (e.g. `0`, `false`, and default-initialized instance fields of a struct instance).
- **Reference type:** `default` is **`null`** (nullable reference type annotations affect warnings, not the runtime meaning of `null` for reference types).

### 4. Copying and assignment

- **Value type:** `b = a` → **independent** copy (unless `ref` / `in` / `out` in the API).
- **Reference type:** `b = a` → **same object;** mutations through one variable are visible through the other. 

### 5. `struct` vs `class` (typical use)

- **`struct`:** Prefer **small**, **immutable** or short-lived; **no inheritance** (can implement **interfaces**); large structs are costly to copy.
- **`class`:** Identity, **inheritance**, often larger or longer-lived; **mutable** when that is the design.

### 6. Special cases

- **Boxing:** Storing a **value type** in `object` or a **variable of an interface** the struct implements **allocates** a boxed object on the heap.
- **Strings:** **Reference** type, **immutable**; “modifying” creates a **new** string instance.
- **Nullable value types** (`int?`, `T?` for `struct T`): still a value type, with a **null** state; use **`.HasValue`** / **`.Value`** (or pattern matching in modern C#).

### 7. Parameter passing (quick revision)

- **By value (default):** For value types, copies the **value**; for reference types, copies the **reference** (still one shared object on the heap).
- **`ref` / `out` / `in`:** `ref` and `out` pass the **location** (aliasing). `in` is read-only by reference, mainly relevant for **large structs** to avoid copy cost.

------------------------------------------------------------------------------------------------------------------------

## ref, in, and out parameters

*Quick revision — pass by reference vs default parameter passing*

### 1. Default passing vs `ref` / `in` / `out`

- **By value (default):** For value types, the **value** is copied; for reference types, the **reference** is copied. You can **mutate the object** through a reference-type parameter, but you **cannot** reassign the **caller’s variable** to a different object from inside the method.
- **`ref` / `in` / `out`:** Pass the **variable’s storage location** (an **alias** to the caller’s slot), not a copy of the value. The callee can read/write the **same** storage the caller has (subject to `in` / `out` rules below).

### 2. `ref`

- **Meaning:** Parameter is an **alias** to the caller’s variable; **read and write** are allowed.
- **Caller must** pass an **assignable** storage (e.g. a local, field) that is **definitely assigned** before the call. Use `ref` at the call site: `M(ref x)`.
- **Use cases:** Avoid copying **large structs**; “return” values by updating a passed-in variable; APIs that need two-way R/W through one parameter.

### 3. `out`

- **Meaning:** Like `ref`, but the method **must assign** every `out` parameter on **all** code paths before returning (compiler-enforced in normal methods).
- **Caller** does not need a meaningful value before the call; the method is responsible for assignment — typical for `Try` patterns: `bool TryParse(string s, out int result)`.
- **Call site:** `M(out x)` or `M(out var x)` or discard with `out _`.

### 4. `in`

- **Meaning:** **Read-only by reference** — pass the **address** of the argument but the callee **must not** assign to or modify the parameter (only read).
- **Use cases:** **Large** `struct` arguments where you want to **avoid** copying the whole struct on the stack. For **small** structs, **by value** is often still cheap; `in` adds an extra indirection — not always a win for tiny types.
- **Call site:** `M(in x)`; the compiler can pass a temporary when allowed by language rules.

### 5. Quick comparison

|        | `ref`      | `out`           | `in`              |
|--------|------------|-----------------|-------------------|
| Read   | Yes        | Yes (after the method assigns) | Yes  |
| Write  | Yes        | Yes (method must assign) | **No** (read-only) |
| Caller must assign before call | **Yes** | **No** | (depends on use; often just pass storage) |

### 6. Extras to remember

- **`out var` / `out _`** — declare the variable at the call site or discard a result.
- **`ref` return** / **`ref` locals** — different feature: return an alias to storage (e.g. `array[i]`). Related idea, not the same as `ref` parameters only.
- **Properties** are generally **not** valid as `ref` / `out` in the same way as **fields** and **locals** (they are not true storage in the same sense; rules have evolved for *ref* returns on certain members in advanced cases).
- **`in` and non-`readonly` struct:** The compiler may **defensively copy** a non-readonly `struct` when you call an instance method on an `in` parameter to preserve “unchanged from caller’s view.” **`readonly struct` + `in`** is a common pattern to avoid that surprise for large data.
- **Async** methods, **iterators** (`yield`), and some other signatures have **restrictions** on `ref` / `in` / `out` parameters — not every method shape can use them.

------------------------------------------------------------------------------------------------------------------------

## Structs

*Theory, syntax, and main language rules for `struct` in C#*

### 1. What a struct is

- A **`struct`** (structure) is a **value type** (unlike `class`, which is a reference type).
- All structs implicitly derive from **`System.ValueType`**, which derives from **`object`**. You **cannot** specify a base **class** for a struct; you **can** implement **one or more interfaces**.
- **Memory:** Instances are often on the **stack** (locals, parameters) or **inlined** inside other objects. **Not** “always stack” — e.g. **array** elements, **fields** of a class, **boxing** put data on the **heap** when applicable.
- **Copy semantics:** Assigning or passing by value (default) **copies the whole instance** (field by field). Large structs are expensive to copy.
- **Default value:** `default(T)` and `new T()` for a **non-generic** value type struct: **all instance fields** set to **their** defaults (numeric `0`, `null` for refs, etc.). C# 10+ allows an **explicit** parameterless constructor: `struct S { public S() { ... } }` — if present, that logic runs for `new S()`; `default(S)` is still the **uninitialized**/zero pattern unless you adopt types where that is unified (see language version rules for *default struct* and field initialization).

### 2. Basic declaration and instance syntax

```csharp
public struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;   // all instance fields must be assigned in every constructor
    }
}

// Usage
Point p1 = new Point(1, 2);
Point p2;              // all fields are default-initialized when local is a struct
Point p3 = default;     // all-bits default (same idea as "zeroed" for fields)
```

- **Field initialization at declaration:** C# 10+ allows `public int X { get; set; } = 0;` and field initializers on struct fields; rules for **definite assignment** in constructors must still be satisfied.
- **Parameterless instance constructor** (C# 10+): You may declare `public S() { }` to customize initialization for `new S()`.

### 3. `readonly struct`

- The whole type is a **`readonly` struct** — **instance** members (unless `static`) must not mutate the instance. Helps **immutability** and pairs well with `in` parameters to avoid **defensive copies** when the compiler can prove methods don’t mutate.
- **Syntax:** `public readonly struct Point3D { ... }`
- A **`readonly`** instance **method** or **readonly** property in a *non-readonly* struct is also possible — marks that member as not mutating the instance and affects **defensive copy** elision in some cases.

```csharp
public struct Counter
{
    public int Value;

    public readonly int Doubled() => Value * 2;   // promises not to mutate
}
```

### 4. `ref struct`

- A **`ref struct`** type is **stack-only**: it **cannot** be boxed, stored on the heap, or be a field of a normal `class`/`struct` in ways that would escape the stack; used for high-performance and **`Span<T>`-style** APIs.
- **Typical use:** `ReadOnlySpan<char>`, custom stack-only buffers, **avoid allocations**.
- **Syntax:** `public ref struct MyBuffer { ... }`
- **Limitations (summary):** Cannot be cast to `object` / `IEnumerable` if that implies boxing; **async** and **`yield` iterator** method restrictions apply to **ref** locals and often **ref struct** in locals.

### 5. `record struct` (C# 10+)

- **`record struct`** = value type with **value-based equality** and **synthesized** members (`ToString`, `==`, `Equals`, `GetHashCode`, **with**-expressions for `record` copy-with-modify) subject to the exact `record` rules in your language version.
- **Syntax examples:**

```csharp
public record struct PointR(int X, int Y);
public readonly record struct Person(string Name, int Age);
```

### 6. Inheritance, interfaces, and `this`

- **No class inheritance** — a `struct` may **not** derive from another `struct` or `class` (except the implicit `ValueType` / `object` chain).
- **Interfaces:** `struct` **can** implement **interfaces** (one type can implement `IComparable<T>`, `IDisposable`, etc.).
- **`this`:** Instance methods have `this` as a **value**-typed receiver (unless in a `ref` extension context or very advanced patterns). Mutating a **copy** in a method that takes `this` by value in certain patterns is a **classic gotcha** — for heavy mutation, `ref`/`ref` extensions or reassign the **whole** struct in a clear way; prefer **immutability** for small DTOs.

### 7. `static` members, `const`, `out` in constructors

- **Static** fields, methods, and properties on structs behave like on classes (no per-instance `this` for `static` members).
- **Instance constructors** must **assign** every **instance** field in **all** code paths (unless rules are satisfied with field initializers, depending on version and pattern).
- You **cannot** declare a **destructor (finalizer)** for a `struct` in the usual C# sense; cleanup uses **`IDisposable`** or scope patterns.

### 8. `default`, `is`, and boxing

- **`default(S)`** — the default instance (field-wise zero/default).
- **Boxing** — if you assign a struct to **`object`**, an **interface** the struct implements, or otherwise box, a **box** is an **object on the heap**; **unboxing** gives you a **copy** of the value. Avoid accidental boxing in **hot** paths.
- **Pattern** — `o is MyStruct s` and modern pattern matching with structs follow the usual `is` rules.

### 9. `unsafe` / `fixed` and layout (awareness)

- You can use **`[StructLayout(LayoutKind.Sequential, Pack = 1)]`** and related attributes for interop, binary protocols, and alignment. **`unsafe`** code with **pointers** and **`fixed` buffers** (e.g. `fixed byte buffer[...]` in a struct) need an **`unsafe`** context and the appropriate project flags.
- **`sizeof(S)`** — compile-time `sizeof` in **unsafe** context, or for **unmanaged** types, rules per language; **`Marshal.SizeOf`** for interop (may differ with padding). Treat as an **interop/debugging** tool more than day-to-day business logic.

### 10. When to prefer `struct` vs `class` (practical)

| Prefer **`struct`** | Prefer **`class`** |
|--------------------|--------------------|
| Small, often **&lt; ~16–32 bytes** (rule of thumb, not a law) | **Identity**, share references, **inherit** behavior |
| **Immutable** or short-lived, **huge** numbers of instances | **Large** payload, long-lived, **mutable** graphs |
| No need for a shared reference identity | Need **`null`**, **polymorphism** via `virtual` in a hierarchy |

- **Readonly struct + small** types: **coordinates**, **keys** in some algorithms, **numeric** wrappers, **`record struct`** for simple DTOs.
- If the type is **big** or **frequently** boxed or copied through interfaces, a **`class`** may be **clearer** and sometimes **faster**—**profile** when in doubt.

------------------------------------------------------------------------------------------------------------------------

## Type casting

*Quick revision — `(T)expr`, implicit / explicit, upcast, downcast, unboxing, `checked` / `unchecked`, `enum`*

### 1. The cast expression `(T)expr`

- The **cast expression** applies a conversion to `expr` and is written **`(T)expr`**, where `T` is a type. It is used for **explicit** language conversions, **downcasts**, **unboxing**, **enum** conversions, and **user-defined** `explicit operator` results.

### 2. Implicit vs explicit

- **Implicit** — the compiler applies the conversion **without** `(T)` (e.g. `int` → `long` where allowed; **derived → base** reference **upcast** is implicit).
- **Explicit** — you must write `(T)`: e.g. **narrowing** numerics, **(Derived)baseRef** for **downcast**, **(int)** from boxed `int`, `(MyEnum)`.

### 3. Upcast and downcast (reference types and OOP)

- **Upcast** — e.g. `Base b = derived;` — no cast; **safe** (derived *is* a base).
- **Downcast** — e.g. `(Cat)animal` — **runtime** check; if the object is **not** actually a `Cat`, **`InvalidCastException`**.

### 4. Unboxing (value types and `object`)

- **Unboxing** — e.g. `object o = 42; int n = (int)o;` — the **boxed** value must be **exactly** the target value type, or the cast **throws** `InvalidCastException`. (Related: **boxing** = value type → `object` / interface, may allocate a box on the heap.)

### 5. `checked` and `unchecked` (integers)

- In **`checked`** context, overflowing integer operations / some conversions can throw **`OverflowException`**. Default in many projects is **unchecked** — overflow **wraps** for integer math.
- Use **Financial / strict** scenarios: `checked` blocks or `decimal` as appropriate; know your project’s checked overflow setting.

### 6. `enum`

- Every `enum` has an **underlying integral type** (default `int`). You can convert with **`(int)myEnum`** and **`(MyEnum)int`**. A numeric value that is **not** a named member can still be produced — validate with **`Enum.IsDefined`** or design if you care about “invalid” combinations.

*Syntax / examples to remember:*

```csharp
long w = 100; byte b = (byte)w;     // explicit narrow
Animal a = new Cat(); var c = (Cat)a; // downcast
object o = 7; int? n = o as int?;    // or (int)o for unbox
```

```csharp
checked { /* int x = int.MaxValue; int y = x + 1; */ } // can throw
```

```csharp
enum Day { Mon = 1, Tue, Wed }
int code = (int)Day.Tue;
Day d = (Day)2;
```

------------------------------------------------------------------------------------------------------------------------

## Type conversion

*Quick revision — `Parse`, `TryParse`, `Convert`*

### 1. What “conversion” means here

- This is **not** only `(T)expr` — it includes **parsing** strings, **`Convert`**, and BCL helpers that return a **new** representation of data (string ↔ numbers, `object` ↔ type, etc.).

### 2. `Parse` and `TryParse` (string → numeric and similar)

- **`int.Parse("42")`** — returns `int`; throws on bad format (e.g. `FormatException`, or `ArgumentNullException` for null in many overloads).
- **`int.TryParse("42", out int n)`** — returns **`bool`**: `true` if parse succeeded, assigns `n`; use for **untrusted** or **user** input to avoid exception-driven flow.
- Specify **culture** when needed: **`CultureInfo.CurrentCulture`**, **`InvariantCulture`**, and **`NumberStyles`** for portable formats and decimals.
- There are `Parse`/`TryParse` for **`double`**, **`decimal`**, **`DateTime`**, **`bool`**, and more — always check the exact overload and culture behavior you rely on in code reviews.

### 3. `Convert` (many types, uniform static API)

- **`Convert`**: static methods like **`Convert.ToInt32(object)`**, **`ToInt32(string)`**, **`ToDouble`**, etc., often go through **convertible** patterns (`IConvertible` model).
- Rounding, **`null`**, and **overflow** behavior are **per overload** — e.g. **`Convert.ToInt32(3.6)`** is **rounded**; different from a raw `unchecked` trunch of `(int)3.6` in style.
- Useful when the source is **`object`**-like or you want a **single** BCL name for “make this a number / string / date”.

*Examples:*

```csharp
int a = int.Parse("40", CultureInfo.InvariantCulture);
_ = int.TryParse("x", out _);
int b = Convert.ToInt32(3.6d);
int c = Convert.ToInt32("5");
```

*Interview line:* use **`TryParse`** for user input, **`Parse`** for trusted or already-validated strings, **`Convert`** for heterogeneous or box-like sources and consistent rounding rules — and **pick culture** explicitly for anything user-visible.

------------------------------------------------------------------------------------------------------------------------

## 3. The `is` operator

**What it is:** The `is` operator tests whether the **runtime** value of an expression matches a **type** or a **pattern**. For a simple type test (`expr is T`) the result is **`true`** or **`false`**. A failed type match does **not** throw; it is simply **`false`**. (This is a **test**, not a cast.)

- **Usage**
  - Use it when you need: “**Is** this a `T` before I use it that way?” — e.g. `if (o is string) { … }`.
  - Prefer **`if (o is T x)`** (declaration pattern) to get a variable `x` of type `T` in the `true` branch, instead of `is` + separate `(T)o` (avoids two type checks and keeps code clear).
  - **Patterns:** `o is not null`, `o is not string`, `o switch { Cat c => …, _ => … }` — in `switch`, list **more specific** types (e.g. `Cat`) **before** more general base types (`Animal`).

- **Limitation / note**
  - It is **not** a replacement for a **cast** by itself when you need the value: use **`is T x`** or `as` + null-check or `(T)o` depending on the case. Method parameters named **`out`** are unrelated to `is`.
  - If failure must be **exceptional** and the value **must** be a `T`, a direct **cast** `(T)o` may be appropriate (throws `InvalidCastException` on bad downcast/unbox).

```csharp
if (o is int n) { }           // int from boxed object
if (o is string s) { }         // s available in the block
if (o is not null) { }
```

------------------------------------------------------------------------------------------------------------------------

## 4. The `as` operator (safe casting)

**What it is:** The `as` operator **attempts** to treat a value as another type. If the conversion is not valid, it returns **`null`** (for the allowed **reference** and **nullable** cases) instead of throwing `InvalidCastException` like a bad **cast** `(T)o` would.

- **Usage** — Best for **reference types** when you are **not certain** of the runtime type, then you **null-check** before use.

  - Example: `var cat = animal as Cat; if (cat is not null) { … }`

- **Limitation** — It **cannot** be used to convert to a **non-nullable value type** (e.g. a raw `int`).

  - `o as int` does **not** compile. Use **`(int)o`** to unbox, **`o is int x`**, or **`o as int?`** when you want a nullable result without throwing on mismatch.

- **Interview one-liner:** `as` = “try and give me **T** or **null** for references / nullable; `(T)` = “must be **T** or **throw**.”

```csharp
object? o = "a";
string? s = o as string;  // "a"

object? n = 1;
string? t = n as string;  // null (not a string)

int? boxed = n as int?;   // nullable unbox, not: n as int
```

------------------------------------------------------------------------------------------------------------------------

## Delegates

**What it is:** A **delegate** is a **type** that describes the signature of one or more callable methods (static or instance). A variable of that type **holds a reference** to a method (or several in a **multicast** list). It is C#’s type-safe way to pass **callbacks** and build **events**.

- **Declaration (custom type)** — `public delegate int MyDel(int x, int y);` then `MyDel d = SomeMethod;` or `d = (a,b) => a+b;`.

- **Usage**
  - Pass behavior into APIs (callbacks, strategies, async completion historically).
  - Combine handlers with **`+=`** / remove with **`-=`** (multicast).
  - Invoke with **`d?.Invoke(args)`** or **`d(args)`** — handle **`null`** (no subscribers).

- **Multicast**
  - **`Action` / void delegates:** invoking runs **all** subscribers in order.
  - **Non-void (e.g. `Func`, custom `int` delegate):** all may still run, but the **return value** of a single **`Invoke`** is only from the **last** handler — do not rely on “merging” returns unless you loop **`GetInvocationList()`** yourself.

- **`Func`, `Action`, `Predicate`**
  - **`Func<T1,...,TResult>`** — last type argument is **return** type; `Func<TResult>` has no parameters.
  - **`Action<...>`** / **`Action`** — **void** return.
  - **`Predicate<T>`** — same role as **`Func<T, bool>`** (older BCL name).

- **Lambdas & anonymous methods**
  - **`(x) => x * 2`** — can **capture** locals (closure); interview: compiler may emit a class + fields; watch **capture in loops** (classic “all closures share one variable” gotcha without a local copy).
  - **`delegate(int x) { return x; }`** — older **anonymous method** syntax.

- **Variance (interview)**
  - **Return type covariance** — a method returning **`Derived`** can satisfy a delegate that returns **`Base`**.
  - **Parameter contravariance** — a method taking **`Base`** can satisfy a delegate that passes **`Derived`**.
  - Applies to matching **method groups** to **delegate** / **`Func`/`Action`** types when generic parameters align.

- **Exceptions in multicast**
  - If one handler **throws**, **later** handlers may **not** run on a plain **`Invoke`**. For robustness, call each entry from **`GetInvocationList()`** in its own **try/catch** if needed.

- **Events vs bare delegate**
  - **`event`** — outside the declaring type, only **`+=`** / **`-=`** (encapsulation); inside, **`OnXxx`** + **`?.Invoke`**. **`EventHandler`**, **`EventHandler<TEventArgs>`** are common patterns.

- **Limitation**
  - Standard **`Func` / `Action`** do not model **`ref` / `out` / `in`** parameters — define a **custom `delegate`** or use a **result struct** / tuple.

- **Code reference** — `ConsoleApp1\C# Practise\Advanced\DelegatesTheory.cs`: **`DelegatesTheory.RunAllDemos()`** runs sections (custom delegate, multicast, `Func`/`Action`/`Predicate`, lambda/closure, variance, `GetInvocationList` + exceptions, **`event`** sample).

```csharp
Action a = () => { };
a += () => { };
a?.Invoke();

Func<int, int, int> add = (x, y) => x + y;

public event EventHandler? Something;
protected void OnSomething() => Something?.Invoke(this, EventArgs.Empty);
```
