
namespace Bank2.Core.Accounts.Base
{
    public abstract class Account
    {
        public double Balance;
        public string AccountNumber;
        
        public Account(string number, double amount)
        {
            Balance = amount;
            AccountNumber = number;
        }

        public virtual void WithDraw(double amount)
        {
            Balance -= amount;
        }

        public virtual void Deposit(double amount)
        {
            if (amount <= 0) throw new ApplicationException("Amount must be positive");
            
            Balance += amount;
        }
    }
}
