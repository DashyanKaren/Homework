using OOP.Bank;
using OOP.Person;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankLimit bankLimit = new BankLimit();
            do
            {
                Console.WriteLine("Please add person type 1) Student 2) Employee   or type Start to start operation between clients");
                int.TryParse(Console.ReadLine(), out int result);
                Console.WriteLine("Please Write First Name Last Name and age");

                switch (result)
                {

                    case 1:
                        CustomerHelper.AddClient(bankLimit);
                        break;
                    case 2:
                        CustomerHelper.AddClientEmp(bankLimit);
                        break;

                    default: break;
                }
            }
            while (Console.ReadLine() != "start");

            do
            {
                Console.Write("Please enter Account number => ");
                var accnum = Console.ReadLine();
                Console.WriteLine($"Please choose currency 1)AMD,2)EUR, 3)USD, 4)Crypto ");
                var cuur = Console.ReadLine();
                Console.WriteLine("What do You wanna do 1)Deposit 2)Withdraw 3)Check balance 4)Transfer or type exit to end");
                if (int.TryParse(Console.ReadLine(), out int oper))
                {
                    var currentAcc = BankAccount.CheckExist(accnum);
                    switch (oper)
                    {
                        case 1:
                            var ammount = CustomerHelper.DoOperation();
                            if (ammount != default)
                            {
                                currentAcc.DoDeposit(ammount);
                            }
                            break;
                        case 2:
                            var ammount1 = CustomerHelper.DoOperation();
                            if (ammount1 != default)
                            {
                                currentAcc.DoWithdrawal(ammount1);
                            }
                            break;
                        case 3:
                            Console.WriteLine(currentAcc.ToString());
                            break;
                        case 4:
                            Console.WriteLine("please enter to who you want to do transfer");
                            var secondAcc = Console.ReadLine();
                            Console.WriteLine("please enter how much to transfer");
                            int.TryParse(Console.ReadLine(), out int amountToTransfer);
                            BankOperation bankOperation = new BankOperation();
                            var secondCustomer = BankAccount.CheckExist(secondAcc);
                            bankOperation.TranferToAccount(currentAcc, secondCustomer, amountToTransfer);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter valid currency");
                }
            }
            while (Console.ReadLine() != "exit");
        }
    }
}