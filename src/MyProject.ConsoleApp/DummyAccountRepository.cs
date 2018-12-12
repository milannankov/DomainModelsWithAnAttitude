using MyProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ConsoleApp
{
    public class DummyAccountRepository : IAccountRepository
    {
        private BankAccount account101;
        private BankAccount account201;

        public DummyAccountRepository()
        {
            this.account101 = new BankAccount("101", new Money(Currency.BGN, 5000));
            this.account201 = new BankAccount("201", new Money(Currency.USD, 10000));
        }

        public BankAccount RetrieveAccount(string accountId)
        {
            if(accountId == "101")
            {
                return this.account101;
            }

            if (accountId == "201")
            {
                return this.account201;
            }

            return null;
        }

        public void SaveAccount(BankAccount account)
        {
            
        }
    }
}
