using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Domain
{
    public interface IAccountRepository
    {
        BankAccount RetrieveAccount(string accountId);
        void SaveAccount(BankAccount account);
    }
}