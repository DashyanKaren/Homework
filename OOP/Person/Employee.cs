﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Person
{
    
    internal class Employee : Person
    {
        public Action Action;  
       

        public int WorkExperience { get; set; }
        public double MonthlySalary { get; set; }


        public Employee(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            
        }

        public void ChangeName() 
        {
            //Action?.Invoke();
        }

        public override string ToString()
        {
            return "I'm Employee";
        }
    }
}
