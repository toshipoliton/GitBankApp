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
            //double NewBalance;
            //string balance;
            //Account bank = new Account();

            //Console.WriteLine("Current balance is 500.00");
            //Console.WriteLine("Press D for Deposit or press W for Withdrawl");

            //balance = Console.ReadLine();

            //if (balance == "D")
            //{
            //    NewBalance = bank.deposit();

            //    Console.WriteLine("Your new blance is {0}", NewBalance);
            //}

            //if (balance == "W")
            //{
            //    NewBalance = bank.withdrawl();
            //    Console.WriteLine("Your new blance is {0}", NewBalance);
            //}
            Bank b = new Bank();
            
            var number = b.CreateBankAccount(AccountType.SavingsAccount, 0);


            b.Withdrawl(number, -20);

            Console.ReadLine();
        }
    }
}
