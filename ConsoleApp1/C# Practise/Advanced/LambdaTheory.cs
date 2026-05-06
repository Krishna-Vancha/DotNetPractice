using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.CSharpPractise.Advanced;

/*
 * LAMBDAS — simple map (pair with RunAllDemos)
 * --------------------------------------------
 *
 * WHAT   Inline anonymous function. Assign to Func/Action (or pass to LINQ) —
 *        compiler turns it into a method, sometimes a tiny class to hold
 *        "captured" outer variables (closure).
 *
 * SHAPE  (a,b) => a+b           one expression 
 *        (a,b) => { ...; return x; }   many steps, use { }
 *        () => x      no args    |    x => 2*x    one arg (parens optional)
 *
 * TYPES  Func<in..., TOut>  last type = return.  Action<...> / Action = void.
 *        Left side of = gives types to x => ... (not `var` alone on the left).
 *
 * USE    list.Where(x => x > 0), .Select(x => x.Name)  (LINQ = lambdas everywhere)
 *
 * CLOSURE  Lambda uses an outer local → delegate keeps that variable alive;
 *        same storage as the outer code. for-loops: use "int copy = i" per
 *        iteration if you build a list of lambdas (see CommonPitfall_LoopCapture).
 *
 * EXTRA  static x => ...  cannot capture this/locals (C# 9+)
 *        (_, y) => ...  ignore a parameter
 *        async () => await ...  returns Task; avoid async void except UI events
 *        Expression<Func<...>>  = tree for EF/LINQ providers, not direct IL
 *
 * ONE LINE:  "Short method you write in place; types from Func/Action or the
 *        method you pass to; can remember outside variables (closure)."
 */

/// <summary> Runnable samples — see file comment for the big picture. </summary>
public static class LambdaTheory
{
    public static void Main(string[] args) => RunAllDemos();

    public static void RunAllDemos()
    {
        Console.WriteLine("=== LambdaTheory ===");
        ExpressionVsStatementLambdas();
        FuncActionAndInference();
        SingleParameterAndZeroParameter();
        ClosuresAndCapture();
        StaticLambda();
        DiscardParameters();
        AsyncLambdaSample();
        LinqLambdas();
        ExpressionTreeVsDelegateNote();
        CommonPitfall_LoopCapture();
    }

    // 1–2: one expression vs { block }

    private static void ExpressionVsStatementLambdas()
    {
        Func<int, int, int> add = (a, b) => a + b;

        Func<int, int, int> mul = (a, b) =>
        {
            var product = a * b;
            return product;
        };

        Console.WriteLine($"add(2,3)={add(2, 3)}  mul(2,3)={mul(2, 3)}");
    }

    // 3: Func / Action

    private static void FuncActionAndInference()
    {
        Func<int, bool> isEven = n => n % 2 == 0;
        Action<string> print = s => Console.WriteLine(s);
        print($"isEven(4)={isEven(4)}");
    }

    // 4: one arg, zero arg

    private static void SingleParameterAndZeroParameter()
    {
        Func<int, int> square = x => x * x;
        Func<int> answer = () => 42;
        Console.WriteLine($"square(5)={square(5)} answer={answer()}");
    }

    // 5: closure (uses outer var)

    private static void ClosuresAndCapture()
    {
        var prefix = "[log] ";
        Action<string> log = msg => Console.WriteLine(prefix + msg);
        log("closure captured prefix");
    }

    // 6: static lambda (no capture of outer mutable / instance)

    private static void StaticLambda()
    {
        const int offset = 1;
        Func<int, int> f = static x => x + offset;
        Console.WriteLine($"static lambda: f(9)={f(9)}");
    }

    // 7: discard

    private static void DiscardParameters()
    {
        Action<int, string> showName = (_, name) => Console.WriteLine($"name only: {name}");
        showName(999, "discarded int");
    }

    // 8: async

    private static void AsyncLambdaSample()
    {
        Func<Task<int>> work = async () =>
        {
            await Task.Delay(1);
            return 7;
        };
        int n = work().GetAwaiter().GetResult();
        Console.WriteLine($"async lambda result={n}");
    }

    // 9: LINQ

    private static void LinqLambdas()
    {
        int[] xs = { 3, 1, 4, 1, 5 };
        var evens = xs.Where(n => n % 2 == 0).ToList();
        Console.WriteLine($"LINQ Where even count={evens.Count}");
    }

    // 10: expression tree

    private static void ExpressionTreeVsDelegateNote()
    {
        System.Linq.Expressions.Expression<Func<int, int>> expr = x => x + 1;
        Func<int, int> compiled = expr.Compile();
        Console.WriteLine($"compiled expression tree: {compiled(5)}");
    }

    // 11: loop + capture (copy per iteration)

    private static void CommonPitfall_LoopCapture()
    {
        var actions = new List<Action>();
        for (int i = 0; i < 3; i++)
        {
            int copy = i;
            actions.Add(() => Console.WriteLine($"captured copy={copy}"));
        }

        foreach (var a in actions)
        {
            a();
        }
    }
}
