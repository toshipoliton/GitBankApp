using Bank2.Core.Accounts.Base;
using Bank2.Core.Accounts.Enum;
using System;
namespace Bank2
{
    public class SavingsAccount : Account
    {
        private decimal _interest;
        public SavingsAccount(Guid Number, decimal Amount, decimal interest) : base(Number, Amount, AccountType.SavingsAccount) 
        {
            _interest = interest;
        }

        public override void WithDraw(decimal amount)
        {
            // check to see if we have enough balance..
            if (Balance < amount) throw new ApplicationException("not sufficient funds");
            
            Balance -= amount;
        }

        public override void Deposit(decimal amount)
        {
            base.Deposit(amount + CalculateInterest(Balance + amount));
        }

        decimal CalculateInterest(decimal amount)
        {
            return _interest / 100 * amount;
        }
    }
}