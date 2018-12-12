using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Domain
{
    public class Money : ValueObject
    {
        public Currency Currency { get; }
        public double Amount { get; }

        public Money(Currency currency, double amount)
        {
            if(amount < 0)
            {
                throw new InvalidOperationException("Cannot have negative amounts");
            }

            this.Currency = currency;
            this.Amount = amount;
        }

        public bool HasSameCurrency(Money other)
        {
            return this.Currency == other.Currency;
        }

        public Money Add(Money other)
        {
            var newMoney = new Money(this.Currency, this.Amount + other.Amount);

            return newMoney;
        }

        public Money Subtract(Money other)
        {
            var newMoney = new Money(this.Currency, this.Amount - other.Amount);

            return newMoney;
        }

        public Money Convert(Currency otherCurrency)
        {
            var multiplier = this.GetMultiplier(this.Currency, otherCurrency);
            var newAmount = this.Amount * multiplier;

            var newMoney = new Money(otherCurrency, newAmount);

            return newMoney;
        }

        private double GetMultiplier(Currency from, Currency to)
        {
            var multiplier = 1.0;

            if(from == to)
            {
                return multiplier;
            }

            if(from == Currency.BGN)
            {
                switch (to) {
                    case Currency.EUR:
                        multiplier = 0.98;
                        break;
                    case Currency.USD:
                        multiplier = 0.7;
                        break;
                }
            }

            if (from == Currency.EUR)
            {
                switch (to)
                {
                    case Currency.BGN:
                        multiplier = 1.96;
                        break;
                    case Currency.USD:
                        multiplier = 1.2;
                        break;
                }
            }

            if (from == Currency.USD)
            {
                switch (to)
                {
                    case Currency.BGN:
                        multiplier = 1.5;
                        break;
                    case Currency.EUR:
                        multiplier = 0.99;
                        break;
                }
            }

            return multiplier;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Amount;
            yield return this.Currency;
        }
    }
}