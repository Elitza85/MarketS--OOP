namespace OOPPrime.Models.Cards.Entites
{
    using System;
    using OOPPrime.Exceptions;
    using OOPPrime.Models.Cards.Contracts;

    public abstract class Card : ICard
    {
        private const int MinNameLength = 3;
        private const int MinAge = 18;
        private const int MaxAge = 110;

        private string firstName;
        private string lastName;
        private int age;
        private decimal turnover;

        decimal discountForCurrentPurchase;

        public Card(string firstName, string lastName, int age, decimal turnover)
        {
            this.OwnerFirstName = firstName;
            this.OwnerLastName = lastName;
            this.OwnerAge = age;
            this.PreviousMonthTurnover = turnover;
        }
        public string OwnerFirstName
        {
            get => this.firstName;
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentNullException(String
                        .Format(ExceptionMessages.NullOrEmptyFirstName, MinNameLength));
                }
                this.firstName = value;
            }
        }

        public string OwnerLastName
        {
            get => this.lastName;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NullOrEmptyLastName);
                }
                this.lastName = value;
            }
        }

        public int OwnerAge
        {
            get => this.age;
            private set
            {
                if (value <= MinAge || value > MaxAge)
                {
                    throw new ArgumentException(String
                        .Format(ExceptionMessages.InvalidAge, MinAge, MaxAge));
                }
                this.age = value;
            }
        }

        public decimal PreviousMonthTurnover
        {
            get => this.turnover;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeTurnover);
                }
                this.turnover = value;
            }
        }

        public virtual decimal CalculateCurrentPurchaseDiscount(decimal valueOfPurchase)
        {
            decimal currentDiscountRate = GetDiscountRate();
            discountForCurrentPurchase = (valueOfPurchase / 100) * currentDiscountRate;

            return discountForCurrentPurchase;
        }

        public abstract decimal GetDiscountRate();
    }
}
