using Bank2.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2.Core.Services
{
    public class PersonService : IPersonService
    {
        public int GetPersonByName(string name) 
        {
            using (BankingSystemEntities db = new BankingSystemEntities())
            {
                var person =  db.People.FirstOrDefault(p => p.Name == name);
                if (person == null)
                {
                    var newperson = new Person{Name = name};
                    db.People.Add(newperson);
                    db.SaveChanges();
                    return newperson.ID;
                }
                return person.ID;
            }
        } 
    }
}
