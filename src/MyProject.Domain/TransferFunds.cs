using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Domain
{
    public class TransferFunds
    {
        private IAccountRepository accountRepository;

        public TransferFunds(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public void Perform(string sourceAccount, Money moneyToTransfer, string targetAccount)
        {
            var source = this.accountRepository.RetrieveAccount(sourceAccount);
            var target = this.accountRepository.RetrieveAccount(targetAccount);

            if(source == null || target == null)
            {
                throw new Exception("Source or target account not found");
            }

            var sourceMoney = moneyToTransfer.Convert(source.Balance.Currency);
            var targetMoney = moneyToTransfer.Convert(target.Balance.Currency);
            source.Debit(sourceMoney);
            target.Deposit(targetMoney);

            this.accountRepository.SaveAccount(source);
            this.accountRepository.SaveAccount(target);
        }
    }
}