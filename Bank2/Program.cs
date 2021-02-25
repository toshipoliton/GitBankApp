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
            
            var number = b.CreateBankAccount("Toshi", AccountType.CheckingsAcccount);


            b.Withdrawl(number, 20);

            b.Deposit(number, 100);

            Console.ReadLine();
        }
    }
}
