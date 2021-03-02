using Bank2.Core.Accounts;
using Bank2.Core.Accounts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2.Core.Services
{
    public interface IAccountService
    {
        CheckingsAccount createCheckingsAccount(int personId, decimal amount);
        SavingsAccount createSavingsAccount(int personId, decimal amount);

        void UpdateBalance(Account account, decimal amount);
    }
}
