namespace OOPPrime.Core
{
    using System;
    using System.Text;
    using OOPPrime.Exceptions;
    using OOPPrime.Models.Cards.Entites;
    using OOPPrime.Models.Cards.Contracts;

    public class Engine
    {

        public Engine()
        {

        }

        public void Run()
        {
            Console.Write("Please enter First name: ");
            string firstName = Console.ReadLine();

            Console.Write("Please enter Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Please enter age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Please enter previous month turnover: ");

            decimal turnover = decimal.Parse(Console.ReadLine());
            if (turnover < 0)
            {
                throw new ArgumentException(ExceptionMessages.NegativeTurnover);
            }

            try
            {
                ICard card;

                card = new Bronze(firstName, lastName, age, turnover);
                //card = new Silver(firstName, lastName, age, turnover);
                //card = new Gold(firstName, lastName, age, turnover);

                decimal result = 0;

                Console.Write("Please enter purchase value: ");
                decimal purchaseValue = decimal.Parse(Console.ReadLine());
                if (purchaseValue < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativePurchaseValue);
                }

                result = card.CalculateCurrentPurchaseDiscount(purchaseValue);

                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Purchase value: ${purchaseValue:f2}")
                    .AppendLine($"Discount rate: {card.GetDiscountRate():f1}%")
                    .AppendLine($"Discount: ${result:f2}")
                    .AppendLine($"Total: ${purchaseValue - result:f2}");

                Console.WriteLine(sb.ToString().TrimEnd());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
