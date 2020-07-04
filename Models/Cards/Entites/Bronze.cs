namespace OOPPrime.Models.Cards.Entites
{
    public class Bronze : Card
    {
        private const decimal InitialDiscountRate = 0;
        private const decimal DiscountRateForValueInRangeOneHundredAndThreeHundred = 1;
        private const decimal DiscountRateForOverThreeHundredValue = 2.5m;

        private decimal currentDiscountRate;

        public Bronze(string firstName, string lastName, int age, decimal turnover)
            : base(firstName, lastName, age, turnover)
        {
        }

        public override decimal GetDiscountRate()
        {

            if (this.PreviousMonthTurnover < 100)
            {
                currentDiscountRate = InitialDiscountRate;
            }
            else if (this.PreviousMonthTurnover >= 100 && PreviousMonthTurnover <= 300)
            {
                currentDiscountRate = DiscountRateForValueInRangeOneHundredAndThreeHundred;
            }
            else if (this.PreviousMonthTurnover > 300)
            {
                currentDiscountRate = DiscountRateForOverThreeHundredValue;
            }
            return currentDiscountRate;
        }
    }
}
