using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp1.C__Practise.OOPs_Concepts
{
     class Abstraction
    {

        public static void Main(string[] args)
        {
           PaymentProcessor upi = new UpiProcessor(499m);
            PaymentProcessor creditCard = new CreditCardProcessor(499m);

            creditCard.Pay();
            upi.Pay();
            PaymentProcessor invalid = new UpiProcessor(0m);
            invalid.Pay();
        }
    }
    public abstract class Shape
    {    
        public string name { get; set; }
        public Shape(string Name)
        {
            name=Name;
        }

        public abstract double GetArea();
        public abstract double GetPerimeter();

       public virtual void PrintCategory()
        {
            Console.WriteLine($"{name } is a Generic Shape");
        }

    }
    abstract class Polygon : Shape
    {
        public Polygon(string name) : base(name)
        { }
        public abstract int NumberOfSides();
        

    }
     class Triangle : Polygon
    {
       public double sideA, sideB, sideC;
        public double height;
        public double Base;

        public Triangle(double sideA, double sideB, double sideC, double height, double @base) : base("Triangle")
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
            this.height = height;
            Base = @base;
        }

        public override double GetArea()
        {
            return 0.5 * height * Base;
        }
        public override double GetPerimeter()
        { 
            return sideA+sideB+sideC;
        }
        public override int NumberOfSides()
        {
            return 3;
        }
        public override void PrintCategory()
        {
            Console.WriteLine($"{name} is a Generic Shape");
        }

    }

    class Circle : Shape {

        public int radius { get; set; }
        public override double GetArea()=> Math.PI*radius*radius; 
        public override double GetPerimeter() => 2* Math.PI*radius;


        public Circle(int r) : base("circle")
        { 
            radius = r;
        }

        public override void PrintCategory()
        {
            Console.WriteLine($"{name} is   Circle Shape");
        }
    }
    class Rectangle : Shape
    {

        double height { get; set; }
        double length { get; set; }

        public Rectangle( double h, double l) : base("Rectangle")
        { 
            height = h; 
            length= l;
        }
        public override double GetArea()=> length*height;
        public override double GetPerimeter() => 2 * (length + height);
        public override void PrintCategory()
        {
            Console.WriteLine($"{name} is a Generic Shape");
        }
    }
    public interface IResizable
    {
       public void Resize(double factor);
    }
    public class ResizableCircle : Shape, IResizable  //order matters
    {
        public double Radius { get; set; }
        public ResizableCircle(double radius)  : base("ResizableCircle")
        {
            Radius = radius;
        }
        public override double GetArea() => Math.PI * Radius * Radius;
        public override double GetPerimeter() => 2 * Math.PI * Radius;

         void IResizable.Resize(double factor)     //Why interface name and no access modifier?
        {
            Radius*=factor;
        }
        public override void PrintCategory()
        {
            Console.WriteLine($"{name} is a Generic Shape");
        }
    }

    public interface IMovable{ 
            void Move();
        }
    public interface IDrawable
    {
        void Draw();
    }
    public class Vehicle : IMovable, IDrawable
    { 
        string Type { get; set; }
        public Vehicle(string type)
        {
            Type = type;
        }
        public void Draw()
        {
            Console.WriteLine($"Drawing a {Type} on the screen");
        }
        
        public void Move()
        {
            Console.WriteLine($"{Type} is Moving on the Road");
        }
    }
    public abstract class PaymentProcessor
    {
        decimal Amount { get; set; }
        public PaymentProcessor(decimal amount)
        {
            Amount = amount;
        }
        public void Pay()
        {
            Validate();
            ProcessPayment();
            Console.WriteLine("Payment Completed");
        }
        private void Validate()
        {
            if (Amount <= 0)
            {
                throw new InvalidOperationException();
            }
        }
        protected abstract void ProcessPayment();
        


    }
    public class CreditCardProcessor : PaymentProcessor
    {
        public CreditCardProcessor(decimal amount) : base(amount)
        { }
        protected override void ProcessPayment()
        {
            Console.WriteLine("Charging Via Payment Gateway");
        }
    }
    public class UpiProcessor : PaymentProcessor
    {

        public UpiProcessor(decimal amount) : base(amount)
        { }
        protected override void ProcessPayment()
        {
            Console.WriteLine("Charging Via UPI Gateway");
        }
    }

}
