namespace OOPPrime.Models.Cards.Entites
{
    public class Silver : Card
    {
        private const decimal InitialDiscountRate = 2;
        private const decimal DiscountRateForTurnoverThreeHundredAndUp = 3.5m;

        private decimal currentDiscountRate;

        public Silver(string firstName, string lastName, int age, decimal turnover) 
            : base(firstName, lastName, age, turnover)
        {
        }
        
        public override decimal GetDiscountRate()
        {

            if (this.PreviousMonthTurnover <= 300)
            {
                currentDiscountRate = InitialDiscountRate;
            }
            else
            {
                currentDiscountRate = DiscountRateForTurnoverThreeHundredAndUp;
            }

            return currentDiscountRate;
        }
    }
}
