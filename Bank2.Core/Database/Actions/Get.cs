using Bank2.Core.Accounts.Base;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2.Core.Database.Actions
{
    public static class Get
    {
        public static Person PersonById(int id)
        {
            using(var db = new BankingSystemEntities())
            {
                return db.People.FirstOrDefault(p => p.ID == id);
            }
        }

        public static Person PersonByName(string name)
        {
            using (var db = new BankingSystemEntities())
            {
                return db.People.FirstOrDefault(p => p.Name == name);
            }
        }

        public static CheckingsAccount CheckingsAccount(int personId)
        {
            using (var db = new BankingSystemEntities())
            {
                return db.CheckingsAccounts.FirstOrDefault(p => p.PersonId == personId);
            }
        }

        public static SavingsAccount SavingsAccount(int personId)
        {
            using (var db = new BankingSystemEntities())
            {
                return db.SavingsAccounts.FirstOrDefault(p => p.PersonId == personId);
            }
        }
    }
}
