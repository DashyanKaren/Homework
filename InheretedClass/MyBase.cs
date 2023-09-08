using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InheretedClass
{
    public class Person
    {
        private int Age { get; set; }
        private string Name { get; set; }
        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }
        
        public override string ToString()
        {
           return ($"hello my Name is {Name}, I am {Age} years old!");
        }
    }

    public class Worker : Person
    {
        private double Salary { get; set; }
        private int Age { get; set; }
        private string Name { get; set; }
        public Worker(int age, string name, double salary) : base(age, name) 
        {
            Age = age;
            Name=name;
            Salary = salary;
        }
        public void GetOlder()
        {
            Age++;
        }
        public override string ToString()
        {
           return $"hello my Name is {Name}, I am {Age} years old, my salary is {Salary} dollars!!!";
        }


    }
}
