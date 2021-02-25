using System;
using Bank2.Core.Accounts.Enum;
using Bank2.Core;
using System.Collections.Generic;

namespace Bank2
{
    class Program
    {
        
        private static void Main(string[] args)
        {

            Bank b = new Bank();
            
            var number = b.CreateBankAccount("Toshi", AccountType.SavingsAccount);


            b.Deposit(number, 20);

            Console.ReadLine();
        }
    }
}
