using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2.Core.Database.Actions
{
    public static class CheckIf
    {
        public static bool PersonExists(string name)
        {
            using (var db = new BankingSystemEntities())
            {
                return db.People.FirstOrDefault(p => p.Name == name) != null;
            }
        }

        public static bool SavingsExistsForPerson(int personId)
        {
            using (var db = new BankingSystemEntities())
            {
                return db.SavingsAccounts.FirstOrDefault(s => s.PersonId == personId) != null;
            }
        }

        public static bool CheckingsExistsForPerson(int personId)
        {
            using (var db = new BankingSystemEntities())
            {
                return db.CheckingsAccounts.FirstOrDefault(s => s.PersonId == personId) != null;
            }
        }
    }
}
