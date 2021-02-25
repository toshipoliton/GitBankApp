using System;

namespace Bank2.Core.Database.Actions
{
    public static class InsertOrUpdate
    {
        public static int Person(string name)
        {
            if (CheckIf.PersonExists(name))
            {
                var person = Get.PersonByName(name);
                Update.Person(person.ID, name);
                return person.ID;
            }
            else
                return Insert.Person(name);
        }


        public static Guid CheckingsAccount(int personid, decimal amount)
        {
            if (CheckIf.CheckingsExistsForPerson(personid))
            {
                var account = Get.CheckingsAccount(personid);
                return account.AccountId;
            }
            else
                return Insert.CheckingsAccount(personid, amount);
        }
        public static Guid SavingsAccount(int personid, decimal amount)
        {
            if (CheckIf.SavingsExistsForPerson(personid))
            {
                var account = Get.SavingsAccount(personid);
                return account.AccountId;
            }
            else
                return Insert.SavingsAccount(personid, amount);
        }
    }
}
