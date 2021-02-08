using Bank2.Core.Accounts.Base;

namespace Bank2.Core.Accounts
{
    public class CheckingsAccount : Account
    {
        public CheckingsAccount(string Number, double Amount) : base(Number, Amount) {}
    }
}