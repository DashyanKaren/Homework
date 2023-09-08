using OOP.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Bank
{
    internal class BankAccount : BaseAccount
    {
        
        private BankLimit bankLimit;
        public Customers Customers { get; set; }
        public BankAccount(string accountNumber, Currency currency, BankLimit limit)
            : base(accountNumber, currency)
        {
            bankLimit = limit;
            Customers = new Customers();
        }
        public void AddToBank(BankAccount bankAccount)
        {
            bankAccounts.Add(bankAccount);
        }

        public override void DoDeposit(double amount)
        {
            if (bankLimit.IsInDayLimit(amount))
            { base.DoDeposit(amount); }
        }
        public static BankAccount CheckExist(string accNumber)
        {
            foreach (BankAccount bankAccount in bankAccounts)
            {
                if (bankAccount.AccountNumber==accNumber)
                {
                    return bankAccount;
                }
            }
            return null;
        }
    }
}
