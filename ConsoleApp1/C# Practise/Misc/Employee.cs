using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApp1.C__Practise.Misc
{
    public class Employee
    {
       public string Name { get; set; }
      protected decimal Salary { get; set; }

        public Employee(string name, decimal salary) {
            Name = name;
            Salary = salary;
            Console.WriteLine("Employee Constructor");

        }
        public override string ToString()
        {
            return $"To string {Name} - {Salary:C}";
        }
        public virtual void ShowDetails()
        {
            Console.WriteLine($"Name is {Name}, Salary is {Salary}");
        }
    }
    public class Manager : Employee
    { 
        public int TeamSize { get; set; }
        public Manager(int teamsize, string name, decimal salary) : base(name, salary)
        { 
            TeamSize = teamsize;
            Console.WriteLine("Manager Constructor");

        }

        public sealed override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine( $" and team size is {TeamSize}");
            Console.WriteLine("Accessing Salary" + Salary);

        }
    }

    public class SeniorManager : Manager { 
        string Region { get; set; }
        public SeniorManager(string region, int teamsize, string name, decimal salary) : base(teamsize,name, salary)
        {

            Console.WriteLine("Senior Manager Constructor");
            Region=region;
        }

        //public override void ShowDetails()
        //{
        //    base.ShowDetails();
        //    Console.WriteLine($" and Region  is {Region}");


        //} cannot be inherited since it is sealed

    }

    public sealed class Intern : Employee
    {
        public string MentorName { get; set; }
        public Intern(string MentorName, string name, decimal salary) : base(name, salary)
        {
            this.MentorName = MentorName;
            Console.WriteLine("Intern Constructor");

        }

        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine($" and Mentor name is {MentorName}");


        }
    }
    //public class InternChild : Intern { 
    //}   cannot be dersived since it  is sealed
    public class Volunteer : Employee {

        public Volunteer(string name, decimal salary) : base( name,  salary)
        {
            Console.WriteLine("Volunteer Constructor");

        }
        public new void ShowDetails()
        {
            Console.WriteLine($"Volunteer Name is {Name}, Salary is {Salary}, unpaid");
        }
    }
}
