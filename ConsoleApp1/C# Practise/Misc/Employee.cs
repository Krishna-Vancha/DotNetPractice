using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.C__Practise.Misc
{
    internal class Employee
    {
        public string Name { get; set; }
        public int salary { get; set; }

        public int experience { get; set; }


       public int CalculateSalary()
        {
            salary = experience * 1000;
            return salary;
        }
        public Employee()
        { 
        }
    }
}
