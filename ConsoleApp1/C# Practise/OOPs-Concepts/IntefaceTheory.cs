using System;

namespace ConsoleApp1.C__Practise.OOPs_Concepts
{
    public interface IExample
    {
        void Save();
        // default method on the interface
        void LogError(string message)
        {
            Console.WriteLine(message);
        }
    }

    internal class IntefaceTheory : IExample
    {
        public static void Main(string[] args)
        {
            var example = new IntefaceTheory();
            example.LogError("Hello");

            Console.WriteLine("--- interface features 1–8 (walkthrough) ---");
            InterfaceFeatureWalkthrough.RunAll();
        }

        public void Save()
        {
            Console.WriteLine("Method id Saved");
        }

        public void LogError(string message)
        {
            Console.WriteLine($"Error in Class Method: {message}");
        }
    }

    /// <summary>
    /// C# 8+ / 11: default methods, static, reabstraction, partial, indexer, event, static abstract operator.
    /// </summary>
    public static class InterfaceFeatureWalkthrough
    {
        public static void RunAll()
        {
            IDefaultMethod a = new DefaultMethodImpl();
            a.Dump("item 1");

            IConfigProps b = new ConfigImpl();
            _ = b.Name;
            _ = b.Description;

            IStaticInInterface.Demo();
            IStaticInInterface.Scratch = 0;

            var c = CtorStruct.Create();
            _ = c;

            IReabstracted r = new ReabstractedImpl();
            r.M();

            IDefaultWithPrivateHelper.Poke();

            IPartialPart.Demo();
            IPartialPart p7 = new PartialPartImpl();
            p7.A(new PartialPartType());

            IIndexerDemo idx = new IndexerImpl();
            _ = idx[2];
            var h = new EventImpl();
            h.Fire();
            _ = OpStruct.Zero + OpStruct.Zero;
        }
    }

    // --- 1. Default (instance) method: body on the interface ---

    public interface IDefaultMethod
    {
        void Dump(string s);
        void DumpLine(string s) => Dump("LINE: " + s);
    }

    public sealed class DefaultMethodImpl : IDefaultMethod
    {
        public void Dump(string s) => Console.WriteLine("1) " + s);
    }

    // --- 2. Default property (expression-bodied get) ---

    public interface IConfigProps
    {
        string Name { get; }
        string Description => "2) default description on interface";
    }

    public sealed class ConfigImpl : IConfigProps
    {
        public string Name => "2) my name";
    }

    // --- 3. static members + const (C# 8+ on interface) ---

    public interface IStaticInInterface
    {
        public const int Version = 3;

        public static int Scratch
        {
            get => s_scratch;
            set => s_scratch = value;
        }

        private static int s_scratch = 0;

        static IStaticInInterface() => s_scratch = 0;

        static void Demo() => s_scratch = Version;
    }

    // --- 4 + 8 (operator) — static abstract in generic (C# 11) —

    public interface ICreatableSelf<T> where T : ICreatableSelf<T>
    {
        static abstract T Create();
    }

    public readonly struct CtorStruct : ICreatableSelf<CtorStruct>
    {
        public static CtorStruct Create() => default;
    }

    // --- 5. Re-abstract: derived interface with new abstract member (C# 8) ---

    public interface IHasDefaultM
    {
        void M() => Console.WriteLine("5) default IHasDefaultM.M");
    }

    public interface IReabstracted : IHasDefaultM
    {
        new abstract void M();
    }

    public sealed class ReabstractedImpl : IReabstracted
    {
        public void M() => Console.WriteLine("5) reimplemented IReabstracted.M");
    }

    // --- 6. private member in interface (C# 8) — only callable from other members in this interface ---

    public interface IDefaultWithPrivateHelper
    {
        static void Poke()
        {
            Helper("6)");
        }

        private static void Helper(string tag) => Console.WriteLine(tag + " private helper in interface");
    }

    // --- 7. partial interface — split across two declarations in this file (can be other files) ---

    public partial interface IPartialPart
    {
        void A(PartialPartType x) => B(x, 0);
    }

    public partial interface IPartialPart
    {
        public static void Demo() { }

        private void B(PartialPartType x, int n) => x.Run(n);
    }

    public sealed class PartialPartType
    {
        public void Run(int n) => Console.WriteLine("7) partial. B called " + n);
    }

    public sealed class PartialPartImpl : IPartialPart
    {
    }

    // --- 8. indexers, event, static abstract operator ---

    public interface IIndexerDemo
    {
        int this[int index] { get => index * 2; }
    }

    public sealed class IndexerImpl : IIndexerDemo
    {
    }

    public interface IEventDemo
    {
        event EventHandler? Ticked;
    }

    public sealed class EventImpl : IEventDemo
    {
        public event EventHandler? Ticked;

        public void Fire() => Ticked?.Invoke(this, EventArgs.Empty);
    }

    public interface IAddable<T> where T : IAddable<T>
    {
        static abstract T operator +(T left, T right);
    }

    public readonly struct OpStruct : IAddable<OpStruct>
    {
        public int Value { get; }
        public OpStruct(int v) => Value = v;
        public static OpStruct Zero => new(0);

        public static OpStruct operator +(OpStruct a, OpStruct b) => new(a.Value + b.Value);
    }
}
