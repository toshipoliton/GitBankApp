using System;

namespace Bank2.Core.Database.Actions
{



    public static class Insert
    {
        public static int Person(string name)
        {            
            using (var db = new BankingSystemEntities())
            {
                var person = new Person
                {
                    Name = name
                };

                db.People.Add(person);
                db.SaveChanges();
                return person.ID;
            }
        }

        public static Guid CheckingsAccount(int personId, decimal amount)
        {
            using (var db = new BankingSystemEntities())
            {
                var account = new CheckingsAccount
                {
                    PersonId = personId,
                    AccountId = Guid.NewGuid(),
                    Amount = amount
                };
                db.CheckingsAccounts.Add(account);
                db.SaveChanges();
                return account.AccountId;
            }
        }

        public static Guid SavingsAccount(int personId, decimal amount)
        {
            using (var db = new BankingSystemEntities())
            {
                var account = new SavingsAccount
                {
                    PersonId = personId,
                    AccountId = Guid.NewGuid(),
                    Amount = amount, 
                    Interest = 10
                };
                db.SavingsAccounts.Add(account);
                db.SaveChanges();
                return account.AccountId;
            }
        }
    }
}
