namespace OOPPrime.Models.Cards.Contracts
{
    public interface ICard
    {
        string OwnerFirstName { get; }

        string OwnerLastName { get; }

        int OwnerAge { get; }

        decimal PreviousMonthTurnover { get; }

        decimal CalculateCurrentPurchaseDiscount(decimal valueOfPurchase);

        decimal GetDiscountRate();
    }
}
