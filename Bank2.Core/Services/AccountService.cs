using Bank2.Core.Accounts;
using Bank2.Core.Accounts.Base;
using Bank2.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2.Core.Services
{
    public class AccountService : IAccountService
    {
        public Bank2.Core.Accounts.CheckingsAccount createCheckingsAccount(int personId, decimal amount)
        {
            using (var db = new BankingSystemEntities())
            {
                var Account = db.CheckingsAccounts.FirstOrDefault(p => p.PersonId == personId);
                if (Account == null) {
                    var NewAccount = new Bank2.Core.Database.CheckingsAccount
                    {
                        PersonId = personId,
                        AccountId = Guid.NewGuid(),
                        Amount = amount
                    };
                    db.CheckingsAccounts.Add(NewAccount);
                    db.SaveChanges();
                    return new Bank2.Core.Accounts.CheckingsAccount(NewAccount.AccountId, NewAccount.Amount);
                }
                return new Bank2.Core.Accounts.CheckingsAccount(Account.AccountId, Account.Amount);
            }
        }

        public Bank2.Core.Accounts.SavingsAccount createSavingsAccount(int personId, decimal amount)
        {
            using (var db = new BankingSystemEntities())
            {
                var Account = db.SavingsAccounts.FirstOrDefault(p => p.PersonId == personId);
                if (Account == null) {
                    var NewAccount = new Bank2.Core.Database.SavingsAccount
                    {
                        PersonId = personId,
                        AccountId = Guid.NewGuid(),
                        Amount = amount,
                        Interest = 10
                    };
                    db.SavingsAccounts.Add(NewAccount);
                    db.SaveChanges();
                    return new Bank2.Core.Accounts.SavingsAccount(NewAccount.AccountId, NewAccount.Amount, NewAccount.Interest);
                }
                return new Bank2.Core.Accounts.SavingsAccount(Account.AccountId, Account.Amount, Account.Interest);
            }
        }

        public void UpdateBalance(Account account, decimal amount) {
            var savingsaccount = account as Accounts.SavingsAccount;
            if (savingsaccount != null)
            {
                using (var db = new BankingSystemEntities())
                {
                    var target = db.SavingsAccounts.FirstOrDefault(a => a.AccountId == savingsaccount.AccountNumber);
                    if (target == null) return;
                    target.Amount = amount;
                    db.SaveChanges();
                }
            }
            var checkingsaccount = account as Accounts.CheckingsAccount;
            if (checkingsaccount != null)
            {
                using (var db = new BankingSystemEntities())
                {
                    var target = db.CheckingsAccounts.FirstOrDefault(a => a.AccountId == checkingsaccount.AccountNumber);
                    if (target == null) return;
                    target.Amount = amount;
                    db.SaveChanges();
                }
            }
        }
    }
}
