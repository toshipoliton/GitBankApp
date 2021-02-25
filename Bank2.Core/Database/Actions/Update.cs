using System.Linq;
using System;

namespace Bank2.Core.Database.Actions
{
    public static class Update
    {
        public static void Person(int id, string name)
        {
            using (var db = new BankingSystemEntities())
            {
                var person = db.People.FirstOrDefault(p => p.ID == id);
                if (person == null) return;
                person.Name = name;
                db.SaveChanges();
            }
        }
        public static void CheckingsAccountAmount(Guid id, decimal amount)
        {
            using (var db = new BankingSystemEntities())
            {
                var account = db.CheckingsAccounts.FirstOrDefault(a => a.AccountId == id);
                if (account == null) return;
                account.Amount = amount;
                db.SaveChanges();
            }
        }
        public static void SavingsAccountAmount(Guid id, decimal amount)
        {
            using (var db = new BankingSystemEntities())
            {
                var account = db.SavingsAccounts.FirstOrDefault(a => a.AccountId == id);
                if (account == null) return;
                account.Amount = amount;
                db.SaveChanges();
            }
        }
    }
}
