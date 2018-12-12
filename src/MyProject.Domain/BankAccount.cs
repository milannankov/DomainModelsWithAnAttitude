using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Domain
{
    public class BankAccount
    {
        public string Id { get; }
        public Money Balance { get; private set;}

        public BankAccount(string id, Money balance)
        {
            if(string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
            this.Balance = balance;
        }

        public void Deposit(Money depositAmount)
        {
            if(!this.Balance.HasSameCurrency(depositAmount))
            {
                throw new InvalidOperationException("Cannot deposit using different currency.");
            }

            this.Balance = this.Balance.Add(depositAmount);
        }

        public void Debit(Money debitAmount)
        {
            if (!this.Balance.HasSameCurrency(debitAmount))
            {
                throw new InvalidOperationException("Cannot debit using different currency.");
            }

            this.Balance = this.Balance.Subtract(debitAmount);
        }
    }
}