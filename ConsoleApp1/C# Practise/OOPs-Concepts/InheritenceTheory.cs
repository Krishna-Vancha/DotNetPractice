using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleApp1.C__Practise.OOPs_Concepts
{
    /*
     * =============================================================================
     * Inheritance in C# — notes
     * =============================================================================
     *
     * 1. Basics
     *    - Syntax: class Derived : Base { } — Derived inherits members from Base (not private).
     *    - Is-a: Manager is an Employee → Employee e = new Manager(); is valid (upcast).
     *    - Not the other way implicitly: Manager m = new Employee(); does not compile.
     *      Use cast only when you know runtime type: (Manager)e or e as Manager.
     *
     * 2. Constructors
     *    - Every derived constructor must call a base constructor (explicitly or implicit base()).
     *    - Explicit: public Manager(string name) : base(name) { }
     *
     * 3. Access (inheritance-related)
     *    - public — everywhere; protected — type + derived; private — not visible in derived code.
     *
     * 4. virtual and override (polymorphism)
     *    - virtual on base: implementation may be replaced in derived.
     *    - override in derived: runtime dispatch — Employee e = new Manager(); e.DisplayInfo();
     *      runs Manager if DisplayInfo is virtual/override.
     *
     * 5. Method hiding — new
     *    - new on derived method: intentionally same name/signature as base; hides base member.
     *    - Not object creation — signals intent and fixes hiding warnings.
     *    - Employee e = new Manager(); e.MethodHide(); — if non-virtual + new in Manager,
     *      runs Employee’s method; ((Manager)e).MethodHide() runs Manager’s.
     *
     * 6. override vs new
     *    - virtual + override: Base b = new Derived(); b.M() → Derived’s M.
     *    - new (hiding): Base b = new Derived(); b.M() → Base’s M (unless cast to Derived).
     *    - Same method cannot be both override and new.
     *
     * 7. base keyword
     *    - base(...) — chain base constructor; base.Method() — call base from override.
     *
     * 8. sealed
     *    - sealed class — no further inheritance; sealed override void M() — no further override.
     *
     * 9. abstract (often with inheritance)
     *    - abstract class — not instantiated; abstract methods overridden in concrete derived types.
     *
     * 10. Mental model
     *     - Left-hand type: access without cast; non-virtual / hidden method resolution.
     *     - Runtime object: virtual/override dispatch, GetType(), cast validity.
     *
     * 11. DerivedClass obj = new BaseClass(); fails because Base is not a Derived — implicit
     *     downcast is unsafe; only Derived → Base reference is always allowed without cast.
     * =============================================================================
     */
    public class InheritenceTheory
    {
        public static void Main(string[] args)
        {
            Employee emp = new Manager("Sri Rama");
            emp.DisplayInfo();
            Employee methodHideObj = new Manager("sri Krishna");
            methodHideObj.MethodHide();

        }
    }
    public class Employee
    {  public Employee()
        { 
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public Employee(int id, string name, string department)
        {
            Id = id;
            Name = name;
            Department = department;
        }
        public Employee(string name)
        {
        
            Name = name;
            
        }
        public void MethodHide()
        {
            Console.WriteLine("Employee Method Hidden");
        }
        public virtual void DisplayInfo()
        {
            // Console.WriteLine($"ID: {Id}, Name: {Name}, Department: {Department}");
            Console.WriteLine("Employee method");
        }
    }
    public class Manager : Employee {
        public Manager(string name) : base(name) { } //remeber how to call a base class constructor from derived
        public int TeamSize { get; set; } //remember •	In C#, a derived class constructor must call a base class constructor. 
        public override void DisplayInfo()
        {
           // base.DisplayInfo();
            Console.WriteLine("Manager Method");
        }
        public new void MethodHide()
        {
            Console.WriteLine("Manager Method Hidden");   //remember that new ona method is  used to let compiler know that we are hiding the base class method, and not overriding it.
        }

    }
}

