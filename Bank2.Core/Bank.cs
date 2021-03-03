using System;
using System.Collections.Generic;
using Bank2.Core.Accounts.Base;
using Bank2.Core.Accounts.Enum;
using Bank2.Core.Services;

namespace Bank2.Core
{
        //toshi4567
    public class Bank
    {
        #region fields for the back
        private List<Account> _accounts;    
        public List<Account> accounts => _accounts;
        IPersonService _personservice;
        IAccountService _accountService;
        #endregion // fields

        #region constructors
        public Bank(IPersonService ps, IAccountService acs)
        {
            _accounts = new List<Account>();
            _personservice = ps;
            _accountService = acs;
        }
        public Bank() : this(new PersonService(), new AccountService()){}
        #endregion // constructors

        /// <summary>
        /// Create Bank Account
        /// </summary>
        /// <param name="accounttype">enum AccountType</param>
        /// <param name="amount">double amount</param>
        /// <returns>returns the account number</returns>
        public Guid CreateBankAccount(string personName, AccountType accounttype, decimal amount = 0)
        {
            var personId = _personservice.GetPersonByName(personName);
            switch (accounttype)
            {
                case AccountType.CheckingsAcccount:
                    var account = _accountService.CreateCheckingsAccount(personId, amount);
                    _accounts.Add(account);
                    return account.AccountNumber;
                case AccountType.SavingsAccount:
                    var saccount = _accountService.CreateSavingsAccount(personId, amount);
                    _accounts.Add(saccount);
                    return saccount.AccountNumber;
                default:
                    return Guid.Empty;
            }            
        }

        public void Deposit(Guid accountnumber, decimal amount)
        {
            var account = FindAccount(accountnumber);
            if (account != null)
            {
                account.Deposit(amount);
                _accountService.UpdateBalance(account, account.Balance);
            }

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
            if (account != null)
            {
                account.WithDraw(amount);
                _accountService.UpdateBalance(account, account.Balance);
            }
            Console.WriteLine(GetAmount(accountnumber));
        }

        public void Transfer(Guid accountone, Guid accounttwo, decimal amount)
        {
            Withdrawl(accountone, amount);
            Deposit(accounttwo, amount);
        }      
    }
}
