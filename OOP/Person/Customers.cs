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

        public Employee Employee;

        public void PersonAdded() 
        {
            Console.WriteLine("one person added succsefully");
        }

        public void AddCustomer(Person person)
        {
            if (person is Student student) 
            {
                
                students.Add(student);
                student.Action = PersonAdded;
                return;
            };

            if (person is Employee employee)
            {
                employee.Action = PersonAdded;
                employees.Add(employee);
                return;
            }
        }
    }
}
