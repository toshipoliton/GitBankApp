using System;
using System.Collections.Generic;
using Bank2.Core.Accounts.Base;
using Bank2.Core.Accounts.Enum;
using Bank2.Core.Accounts;
using Bank2.Core.Database.Actions;

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

        private int CreateOrReturnPerson(string name)
        {
            if(CheckIf.PersonExists(name))
            {
                return Get.PersonByName(name).ID;
            }
            else
            {
                return Insert.Person(name);                
            }
        }

        /// <summary>
        /// Create Bank Account
        /// </summary>
        /// <param name="accounttype">enum AccountType</param>
        /// <param name="amount">double amount</param>
        /// <returns>returns the account number</returns>
        public Guid CreateBankAccount(string personName, AccountType accounttype)
        {
            var personId = CreateOrReturnPerson(personName);
            Account a;
            var id = Guid.NewGuid().ToString();
            switch (accounttype)
            {
                case AccountType.CheckingsAcccount:                    
                    Insert.CheckingsAccount(personId);
                    var checkings = Get.ChekcingsAccount(personId);
                    a = new CheckingsAccount(checkings.AccountId, checkings.Amount);
                    _accounts.Add(a);
                    return a.AccountNumber;
                case AccountType.SavingsAccount:                    
                    Insert.SavingsAccount(personId);
                    var savings = Get.SavingsAccount(personId);
                    a = new SavingsAccount(savings.AccountId, savings.Amount, savings.Interest);
                    _accounts.Add(a);
                    return a.AccountNumber;
                default:
                    return Guid.Empty;
            }            
        }

        public void Deposit(Guid accountnumber, decimal amount)
        {
            var account = FindAccount(accountnumber);

            if (account != null) 
                account.Deposit(amount);

            Console.WriteLine(GetAmount(accountnumber));
        }

        private Account FindAccount(Guid accountnumber)
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

        public decimal GetAmount(Guid accountnumber)
        {
            var account = FindAccount(accountnumber);
            return (account != null) ? account.Balance : 0;
        }

        public void Withdrawl(Guid accountnumber, decimal amount)
        {
            var account = FindAccount(accountnumber);
            if (account != null) account.WithDraw(amount);
        }

        public void Transfer(Guid accountone, Guid accounttwo, decimal amount)
        {
            Withdrawl(accountone, amount);
            Deposit(accounttwo, amount);
        }      
    }
}
