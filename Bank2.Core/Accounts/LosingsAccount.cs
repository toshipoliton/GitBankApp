using Bank2.Core.Accounts.Base;

namespace Bank2
{
    public class LosingsAccount : Account
    {
        private double _interest;
        public LosingsAccount(string Number, double Amount, double interest) : base(Number, Amount)
        {
            _interest = interest;
        }

        public override void WithDraw(double amount)
        {
            Balance -= amount;
        }

        public override void Deposit(double amount)
        {
            base.Deposit(amount - CalculateInterest(Balance + amount));
        }

        double CalculateInterest(double amount)
        {
            return _interest / 100 * amount;
        }
    }
}