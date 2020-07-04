namespace OOPPrime.Models.Cards.Entites
{
    using System;

    public class Gold : Card
    {
        private const decimal InitialDiscount = 2;
        private const decimal GrowingRate = 1;
        private const decimal MaxDiscount = 10;

        private decimal currentDiscountRate;
            
        public Gold(string firstName, string lastName, int age, decimal turnover) 
            : base(firstName, lastName, age, turnover)
        {
        }

        public override decimal GetDiscountRate()
        {
            if (this.PreviousMonthTurnover < 100)
            {
                currentDiscountRate = InitialDiscount;
            }
            else if (this.PreviousMonthTurnover>=100 && this.PreviousMonthTurnover < 900)
            {
                decimal rate = 0;
                rate = Math.Floor(this.PreviousMonthTurnover / 100);
                currentDiscountRate = InitialDiscount + rate;
            }
            else
            {
                currentDiscountRate = MaxDiscount;
            }

            return currentDiscountRate;
        }
    }
}
