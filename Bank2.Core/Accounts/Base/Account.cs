using Bank2.Core.Accounts.Enum;
using Bank2.Core.Database.Actions;
using System;
namespace Bank2.Core.Accounts.Base
{
    public abstract class Account
    {
        public AccountType TypeOfAccount;
        public decimal Balance;
        public Guid AccountNumber;
        
        public Account(Guid number, decimal amount, AccountType type)
        {
            TypeOfAccount = type;
            Balance = amount;
            AccountNumber = number;
        }

        public virtual void WithDraw(decimal amount)
        {
            Balance -= amount;
            switch(TypeOfAccount)
            {
                case AccountType.SavingsAccount:
                    Update.SavingsAccountAmount(AccountNumber, Balance);
                    break;
                case AccountType.CheckingsAcccount:
                    Update.CheckingsAccountAmount(AccountNumber, Balance);
                    break;
            }
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ApplicationException("Amount must be positive");
            
            Balance += amount; 
            switch (TypeOfAccount)
            {
                case AccountType.SavingsAccount:
                    Update.SavingsAccountAmount(AccountNumber, Balance);
                    break;
                case AccountType.CheckingsAcccount:
                    Update.CheckingsAccountAmount(AccountNumber, Balance);
                    break;
            }
        }
    }
}
