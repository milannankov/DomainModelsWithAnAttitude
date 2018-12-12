using MyProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new DummyAccountRepository();

            var transferFunds = new TransferFunds(repository);
            transferFunds.Perform("101", new Money(Currency.USD, 100), "201");
        }
    }
}
