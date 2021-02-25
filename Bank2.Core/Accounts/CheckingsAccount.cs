using Bank2.Core.Accounts.Base;
using Bank2.Core.Accounts.Enum;
using System;

namespace Bank2.Core.Accounts
{
    public class CheckingsAccount : Account
    {
        public CheckingsAccount(Guid Number, decimal Amount) : base(Number, Amount, AccountType.CheckingsAcccount) {}
    }
}