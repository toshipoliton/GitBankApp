using Bank2.Core.Accounts.Base;

namespace Bank2
{
    public class SavingsAccount : Account
    {
        private double _interest;
        public SavingsAccount(string Number, double Amount, double interest) : base(Number, Amount) 
        {
            _interest = interest;
        }

        public override void WithDraw(double amount)
        {
            // check to see if we have enough balance..
            if (Balance < amount) throw new ApplicationException("not sufficient funds");
            
            Balance -= amount;
        }

        public override void Deposit(double amount)
        {
            base.Deposit(amount + CalculateInterest(Balance + amount));
        }

        double CalculateInterest(double amount)
        {
            return _interest / 100 * amount;
        }
    }
}