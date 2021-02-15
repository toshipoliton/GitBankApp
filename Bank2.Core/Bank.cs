using System;
using System.Collections.Generic;
using Bank2.Core.Accounts.Base;
using Bank2.Core.Accounts.Enum;
using Bank2.Core.Accounts;

namespace Bank2.Core
{
        //toshi4567
    public class Bank
    {
        private int _intrestRate;
        private List<Account> _accounts;
        public List<Account> accounts => _accounts;

        public Bank()
        {
            _intrestRate = 10;
            _accounts = new List<Account>();
        }

        public Bank(int intrest)
        {
            _intrestRate = intrest;
            _accounts = new List<Account>();
        }

        /// <summary>
        /// Create Bank Account
        /// </summary>
        /// <param name="accounttype">enum AccountType</param>
        /// <param name="amount">double amount</param>
        /// <returns>returns the account number</returns>
        public string CreateBankAccount(AccountType accounttype, double amount)
        {
            Account a;
            var id = Guid.NewGuid().ToString();
            switch (accounttype)
            {
                case AccountType.CheckingsAcccount:
                    a = new CheckingsAccount(id, amount);
                    _accounts.Add(a);
                    return a.AccountNumber;
                case AccountType.SavingsAccount:
                    a = new SavingsAccount(id, amount, _intrestRate);
                    _accounts.Add(a);
                    return a.AccountNumber;
                case AccountType.LosingsAccount:
                    a = new LosingsAccount(id, amount, _intrestRate);
                    _accounts.Add(a);
                    return a.AccountNumber;
                default:
                    return string.Empty;
            }            
        }

        public void Deposit(string accountnumber, double amount)
        {
            var account = FindAccount(accountnumber);

            if (account != null) 
                account.Deposit(amount);

            Console.WriteLine(GetAmount(accountnumber));
        }

        private Account FindAccount(string accountnumber)
        {
            foreach (var account in _accounts)
            {
                if (account.AccountNumber == accountnumber)
                {
                    return account;
                }
            }
            return null;
        }

        public double GetAmount(string accountnumber)
        {
            var account = FindAccount(accountnumber);
            return (account != null) ? account.Balance : 0;
        }

        public void Withdrawl(string accountnumber, double amount)
        {
            var account = FindAccount(accountnumber);
            if (account != null) account.WithDraw(amount);
        }

        public void Transfer(string accountone, string accounttwo, double amount)
        {
            Withdrawl(accountone, amount);
            Deposit(accounttwo, amount);
        }      
    }
}
