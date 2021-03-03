using System;
using Bank2.Core.Accounts.Enum;
using Bank2.Core;
using System.Collections.Generic;
using Bank2.Core.Services;

namespace Bank2
{
    class Program
    {
        
        private static void Main(string[] args)
        {
            Bank b = new Bank(new PersonService(),new AccountService());
            
            var number = b.CreateBankAccount("Franco", AccountType.SavingsAccount);


            b.Withdrawl(number, 30);

            b.Deposit(number, 45);

            Console.ReadLine();
            
        }
    }
}
