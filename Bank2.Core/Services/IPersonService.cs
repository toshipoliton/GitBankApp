using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2.Core.Services
{
    public interface IPersonService
    {
        int GetPersonByName(string name);
    }
}
