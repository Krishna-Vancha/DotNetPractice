using System;
using System.Linq;

namespace ConsoleApp1.CSharpPractise.Advanced;

/*
 * =============================================================================
 * Delegates in C# — interview notes (read with the code below)
 * =============================================================================
 *  QuickReview/Subtopics: Single, multicast, Func/Action/Predicate, lambdas, closures, variance, events.
 * 1) What is a delegate?
 *    - A type-safe “function pointer” / object that holds one or more methods to call.
 *    - Declared with: delegate ReturnType Name( parameters );
 *    - Instances point to static or instance methods (or lambdas) with a compatible signature.
 *
 * 2) Single vs multicast
 *    - A delegate variable can reference one method or many (multicast) via += / -=.
 *    - For void-returning delegates (e.g. Action), invoking calls all targets in order.
 *    - For non-void return types, invoking the whole multicast still runs all, but the
 *     ** *return value* you get is only from the *last* handler in the invocation list.  //rememeber in multicast delegate (with return type) when triggered, which method value is returned
 *      (Interview: do not assume you get “the sum” of returns — design void + out/ref or
 *      iterate GetInvocationList yourself if you need each result.)
 *
 * 3) Func<T,...>, Action<...>, Predicate<T>
 *    - Func<..., TResult>: last type param is return type; Func with no args: Func<TResult>.
 *    - Action<...>: void return. Action with no args: Action.
 *    - Predicate<T> is equivalent to Func<T, bool> (legacy name, common in older APIs).
 *
 * 4) Lambdas and anonymous methods
 *    - Lambda: (x, y) => x + y  — can capture outer variables (closures); captures are
 *      often implemented as compiler-generated fields (interview: lifetime / GC awareness).
 *    - Anonymous method (older): delegate(int x, int y) { return x + y; }
 *
 * 5) Variance (delegate compatibility)
 *    - Return type covariance: a method that returns Derived can match a delegate that
 *      returns Base (return type can be “more specific” on the method).
 *    - Parameter contravariance: a method that accepts Base can match a delegate that
 *      passes Derived (parameter can be “wider” on the method).
 *    - Applies to generic Func/Action in .NET when the type parameters line up (e.g.
 *      Func<string> assigned where Func<object> expected for return covariance cases).
 *
 * 6) Null-safety and Invoke
 *    - Delegate variables can be null. Use d?.Invoke(args) or if (d != null) d(args);
 *    - Events often use a private delegate backing field and a public add/remove only.
 *
 * 7) GetInvocationList
 *    - d.GetInvocationList() returns Delegate[] — invoke each to handle return values
 *      per handler or to catch exceptions per handler.
 *
 * 8) Exceptions in multicast
 *    - Default: if one handler throws, later handlers may not run (short-circuit).
 *    - Interview: for reliability, invoke each via GetInvocationList in try/catch per item.
 *
 * 9) Events vs delegates (pattern)
 *    - event keyword: from outside the type, only += and -= are allowed (encapsulation).
 *    - Inside the type, you invoke the backing delegate (typically with a protected
 *      OnXxx method and null-conditional Invoke).
 *
 * 10) ref / out / in with Func/Action
 *     - Func/Action generic types do not support ref/out parameters in the usual BCL
 *       definitions; use a custom delegate type for ref/out, or a small struct result type.  
 *
 * 11) Method group conversion
 *     - You can assign a method name to a compatible delegate without "new DelegateType(Method)"
 *       when the compiler can infer the type (method group conversion).
 * =============================================================================
 */

//Interview Quick revision  Notes for Delegates  


/// <summary>Runnable samples + notes in the file header for delegate interviews.</summary>
public static class DelegatesTheory
{
    public static void RunAllDemos()
    {
        CustomDelegate_Section();
        Multicast_Section();
        FuncActionPredicate_Section();
        LambdaAndClosure_Section();
        Variance_Section();
        InvocationListAndException_Section();
        EventPattern_Section();
    }

    #region Custom delegate type

    public delegate int BinaryIntOp(int a, int b);

    /*
     * Section: named delegate type — explicit signature for callbacks.
     */
    public static void CustomDelegate_Section()
    {
        BinaryIntOp add = AddInts; // method group conversion
        BinaryIntOp mul = new BinaryIntOp(MultiplyInts); // explicit ctor form
        _ = add(2, 3); // 5
        _ = mul(2, 3); // 6
    }

    private static int AddInts(int a, int b) => a + b;
    private static int MultiplyInts(int a, int b) => a * b;

    #endregion

    #region Multicast delegates

    /*
     * Section: += / -= ; void vs non-void return when all handlers run.
     */
    public static void Multicast_Section()
    {
        Action log = () => { };
        log += LogA;
        log += LogB;
        log?.Invoke(); // runs LogA then LogB

        BinaryIntOp? chain = AddInts;
        chain += MultiplyInts; // last in list wins for *return value* of chain(2,3)
        int r = chain!.Invoke(2, 3); // MultiplyInts runs after AddInts; r is 6, not 5
        _ = r;  //what is this statement? To avoid a compiler warning like “r is assigned but its value is never used”

        chain -= AddInts;
        _ = chain?.Invoke(2, 3); // only MultiplyInts
    }

    private static void LogA() { }
    private static void LogB() { }

    #endregion

    #region Func, Action, Predicate

    /*
     * Section: BCL generic delegate types — prefer these over custom names when they fit.
     */
    public static void FuncActionPredicate_Section()
    {
        Func<int, int, int> f = (a, b) => a + b;
        _ = f(1, 2);

        Func<string, bool> isEmpty = string.IsNullOrEmpty;
        _ = isEmpty("");

        Predicate<int> even = x => x % 2 == 0;
        _ = even(4); // same idea as Func<int, bool>

        Action<string> print = s => _ = s.Length;
        print("hi");

        Action noArgs = () => { };
        noArgs();
    }

    #endregion

    #region Lambda and anonymous methods (closures)

    /*
     * Section: lambdas capture locals — compiler generates a display class / fields.
     */
    public static void LambdaAndClosure_Section()
    {
        int factor = 10;
        Func<int, int> scale = x => x * factor; // captures factor
        factor = 2;
        _ = scale(5); // 10 — uses current factor unless loop/classic closure bug pattern in loops

        Func<int, int> oldStyle = delegate (int x) { return x + 1; };
        _ = oldStyle(1);
    }

    #endregion

    #region Covariance and contravariance (delegate assignment)

    /*
     * Section: return type covariance / parameter contravariance for delegate targets.
     */
    public static void Variance_Section()
    {
        // Return covariance: method returns string, delegate type returns object
        Func<object> f = ObjectFactoryReturningString;
        object o = f();

        // Parameter contravariance: delegate passes string, method accepts object
        Action<string> a = AcceptObject;
        a("test");
        _ = o;
    }

    private static string ObjectFactoryReturningString() => "hello";

    private static void AcceptObject(object o) => _ = o?.ToString();

    #endregion

    #region GetInvocationList and multicast exceptions

    /*
     * Section: inspect handlers; default invoke can skip remaining if one throws.
     */
    public static void InvocationListAndException_Section()
    {
        Action? multi = null;
        multi += SafeHandler;
        multi += ThrowingHandler;
        multi += SafeHandler;

        // Default: ThrowingHandler throws — third SafeHandler may not run
        try
        {
            multi?.Invoke();
        }
        catch (InvalidOperationException)
        {
            // expected in demo
        }

        // Per-handler: all get a chance if each wrapped
        foreach (var d in multi!.GetInvocationList().Cast<Action>())
        {
            try
            {
                d();
            }
            catch (InvalidOperationException)
            {
                // log, continue
            }
        }
    }

    private static void SafeHandler() { }

    private static void ThrowingHandler() => throw new InvalidOperationException("demo");

    #endregion

    #region Event pattern (encapsulation)

    /*
     * Section: event — external code can only += / -= ; type can Invoke internally.
     */
    public static void EventPattern_Section()
    {
        var pub = new ButtonPublisher();
        pub.Clicked += (_, _) => { };
        pub.RaiseClick();
    }

    public sealed class ButtonPublisher
    {
        public event EventHandler? Clicked;

        public void RaiseClick() => Clicked?.Invoke(this, EventArgs.Empty);
    }

    #endregion
}
