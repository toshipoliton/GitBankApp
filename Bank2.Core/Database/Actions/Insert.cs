using System;

namespace Bank2.Core.Database.Actions
{
    public static class InsertOrUpdate
    {

    }
        


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

        public static void CheckingsAccount(int personId)
        {
            if (CheckIf.CheckingsExistsForPerson(personId)) return;
            using (var db = new BankingSystemEntities())
            {
                var account = new CheckingsAccount
                {
                    PersonId = personId,
                    AccountId = Guid.NewGuid(),
                    Amount = 0
                };
                db.CheckingsAccounts.Add(account);
                db.SaveChanges();
            }
        }

        public static void SavingsAccount(int personId)
        {
            if (CheckIf.SavingsExistsForPerson(personId)) return;
            using (var db = new BankingSystemEntities())
            {
                var account = new SavingsAccount
                {
                    PersonId = personId,
                    AccountId = Guid.NewGuid(),
                    Amount = 0, 
                    Interest = 10
                };
                db.SavingsAccounts.Add(account);
                db.SaveChanges();
            }
        }
    }
}
