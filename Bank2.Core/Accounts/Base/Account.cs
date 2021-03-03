using Bank2.Core.Accounts.Enum;
using System;
namespace Bank2.Core.Accounts.Base
{
    public abstract class Account
    {
        public decimal Balance;
        public Guid AccountNumber;
        
        public Account(Guid number, decimal amount)
        {
            Balance = amount;
            AccountNumber = number;
        }

        public virtual void WithDraw(decimal amount)
        {
            Balance -= amount;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Amount must be positive");
                return;
            }
            Balance += amount; 
        }
    }
}
