using OOP.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Person
{
    public static class CustomerHelper
    {

        public static void AddClient(BankLimit bankLimit)
        {
            
            Student student = new Student(Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()));
            Console.WriteLine("please give account number");
            var accnumber = Console.ReadLine();
            Console.WriteLine($"Please choose currency 1)AMD,2)EUR, 3)USD, 4)Crypto ");
            if (int.TryParse(Console.ReadLine(), out int currencyresult))
            {
                BankAccount bankAccount = new BankAccount(accnumber, (Currency)currencyresult, bankLimit);
                bankAccount.Customers.AddCustomer(student);
                bankAccount.AddToBank(bankAccount);
                
            }
            

        }

        public static void AddClientEmp(BankLimit bankLimit)
        {
            Employee employee = new Employee(Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()));
            Console.WriteLine("please give account number");
            var accnumber1 = Console.ReadLine();
            Console.WriteLine($"Please choose currency 1)AMD,2)EUR, 3)USD, 4)Crypto ");
            if (int.TryParse(Console.ReadLine(), out int currencyresult1))
            {
                BankAccount bankAccount1 = new BankAccount(accnumber1, (Currency)currencyresult1, bankLimit);
                bankAccount1.Customers.AddCustomer(employee);
                bankAccount1.AddToBank(bankAccount1);
            }
            employee.ChangeName();
        }
        public static double DoOperation()
        {
            Console.WriteLine("Please enter the desired amount =>");
            if (double.TryParse(Console.ReadLine(), out double ammount))
            {
                return ammount;
            }
            return default;
        }
    }
}
