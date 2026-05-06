# C# notes

## Index

Each topic has its own section below so you can scan and revise one topic at a time.

### **Topics**

Each topic: heading line, then comma-separated “flash” notes on the next line.

**1. Optional parameters :**

use `=` for default in declaration , use `name:` to pass a named arg at the call site , `int x = default` here `x` is `0` (type’s default) , defaults are compile-time constants

**2. Value types and reference types :**

value = often stack/inlined , assign copies bits , ref type = ref to heap (usually) , `string` ref + immutable

**3. ref, in, and out parameters :**

`ref` = alias read/write must assign before call , `out` = must assign in callee Try-pattern , `in` = by-ref read-only big struct

**4. Structs :**

value type no class inheritance , copy cost , `readonly` / `ref` struct / `record struct` = special flavors

**5. Type casting :**

`(T)` explicit , upcast free , downcast/unbox can throw `InvalidCast` , `checked` overflow option

**6. Type conversion :**

`TryParse` safe from strings , `Parse` throws , `Convert.*` for mixed/rounding — pick culture

**7. The `is` operator :**

`is T x` binds + test , `is not null` , no exception if false

**8. The `as` operator (safe casting) :**

ref + nullable: `x as T` or null , value unbox: `as int?` not `as int`

**9. Delegates :**

single/ mul;ticast , .Invoke(), can assign method or new DelegateName();, Covarience, contra varience , `Func` last type = return , `Action` void , Predicate , multicast `+=` / `-=` , non-void = last return only from `Invoke`

**10. Inheritance (concepts, keywords) :**

`virtual`/`override` = runtime through base ref , `new` = hide compile-time type matters , `base()` ctor chain , upcast only without cast

**11. Interfaces (C# 8+ / 11+) :**

instance `void M()` not implemented by `static` method; default + `static` on interface; `static abstract` generic patterns (C# 11) — *see* `IntefaceTheory` / BCL docs

**12. Discards `_` / `_ =` :**

`out _` unused out , deconstruction ignore , `_ = r` “evaluate but drop” to silence unused — not the same as `var`, if a variable is declared and not used compiler throws waring , to avoid that use _=

**13. Delegates — types, built-ins, variance, lambdas :**

custom `delegate` types vs `Func` / `Action` / `Predicate` , covariance/contravariance when assigning compatible method groups

**14. Lambdas :**

**15. Events :**

Observer pattern (publisher/subscriber) , `event` keyword on delegate-like field , `EventHandler<CustomEventArgs>` , derive `CustomEventArgs` from `EventArgs` to send data when raised , event (delegate) owned by publisher — publisher triggers , subscriber contains / registers handlers for that event (`+=`)

**16. Exceptions (OOP) :**

`try` / `catch` / `finally` / `throw` — no checked exceptions (unlike Java); derive custom types from `Exception` for domain errors , **catch order** = most-specific subtype **before** base types (polymorphism / `is`-hierarchy) , `catch (Exception ex) when (predicate)` for filters , bare `throw;` rethrows **preserving stack trace** , `throw ex;` **resets** stack — avoid , wrap / chain with `InnerException` , `finally` runs on all exit paths (including `return`) for cleanup

**17. KeyWords:** readonly, const, Yield, _=, 

**18. IEnumerable :**

`IEnumerable` / `IEnumerable<T>` — read-only forward-only sequence; **`foreach`** uses `GetEnumerator()` then **`MoveNext()`** / **`Current`** (or pattern-based dispose) , **`IEnumerator`** / **`IEnumerator<T>`** — `Current`, `MoveNext()`, `Reset` (legacy); **`IDisposable`** on generic enumerator , **`yield return`** / **`yield break`** — compiler iterator state machine , **LINQ / deferred execution** — many ops return `IEnumerable`; runs when you enumerate , **`IEnumerable<out T>`** — covariance (e.g. assign `IEnumerable<Derived>` to `IEnumerable<Base>`)

**19. Reflection :**

**Quick review / subtopics:** Reflection , Assembly , Type , MemberInfo , BindingFlags , late binding , dynamic invocation , attributes , performance overhead , real-world use cases , security concerns — **`System.Reflection`** inspects **metadata** and interacts with types **at runtime** even when they were unknown at compile time.

*Source:* `ConsoleApp1\C# Practise\Advanced\ReflectionTheory.cs` (comment lines 12–18).

**20. Span<T> / ReadOnlySpan<T> :**

*QuickRecap:* reference struct / `ref struct` that does not create new memory; it just points to existing contiguous memory , `Span<T>` , `ReadOnlySpan<T>` , `.Slice(start, length)` , index access `[]`

### **Exceptions**

**QuickReview / subtopics:** try, catch, finally, throw (`throw;` vs `throw new …`); use `TryParse` or null-checks to avoid the high performance cost of throwing.

**finally** — takes no exception parameter; use an exception filter on `catch` with `when (condition)`.

**Members:** `ex.Message`, `ex.StackTrace`; **custom exceptions** inherit `Exception`.

In C#, exceptions use try–catch–finally: **try** holds risky code, **catch** handles errors, and **finally** always runs for cleanup. **`throw;`** preserves the original stack trace; **`throw new Exception`** creates a new throw site. For performance, **`TryParse`** is preferred over exceptions for validation. Use **`when`** for conditional catching. **Custom exceptions** define domain-specific errors.

*Source:* `ConsoleApp1\C# Practise\OOPs-Concepts\ExceptionsTheory.cs` (comment lines 10–13).

------------------------------------------------------------------------------------------------------------------------

## Exceptions

*Quick review — same bullets as the practice class comments (lines 10–13).*

**QuickReview / subtopics:** try, catch, finally, throw (`throw;` vs `throw new …`); use `TryParse` or null-checks to avoid the high performance cost of throwing.

**finally** — takes no exception parameter; use an exception filter on `catch` with `when (condition)`.

**Members:** `ex.Message`, `ex.StackTrace`; **custom exceptions** inherit `Exception`.

In C#, exceptions use try–catch–finally: **try** holds risky code, **catch** handles errors, and **finally** always runs for cleanup. **`throw;`** preserves the original stack trace; **`throw new Exception`** creates a new throw site. For performance, **`TryParse`** is preferred over exceptions for validation. Use **`when`** for conditional catching. **Custom exceptions** define domain-specific errors.

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
