using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Person
{
    internal class Customers
    {
        public static List<Student> students = new List<Student>();
        public static List<Employee> employees = new List<Employee>();
       
        public void AddCustomer(Person person)
        {
            if (person is Student student) 
            {
                students.Add(student);
                return;
            };

            if (person is Employee employee)
            {
                employees.Add(employee);
                return;
            }
        }
    }
}
