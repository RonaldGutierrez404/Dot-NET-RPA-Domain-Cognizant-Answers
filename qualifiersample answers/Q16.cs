// Financial App

using System;

namespace FinancialApp
{
    public class Card
    {
        public long CardNumber { get; set; }
        public long BalanceAmount { get; set; }
    }

    public class Service : Card
    {
        public bool ValidateCardNumber()
        {
            return CardNumber.ToString().Length == 16;
        }

        public double[] Withdraw(long withdrawnAmount)
        {
            if (withdrawnAmount > BalanceAmount)
            {
                return new double[0];
            }

            double cashbackPercentage = 0;
            if (withdrawnAmount >= 100 && withdrawnAmount <= 500)
            {
                cashbackPercentage = 0.10;
            }
            else if (withdrawnAmount > 500 && withdrawnAmount <= 1000)
            {
                cashbackPercentage = 0.15;
            }
            else if (withdrawnAmount > 1000)
            {
                cashbackPercentage = 0.20;
            }

            double cashback = withdrawnAmount * cashbackPercentage;
            BalanceAmount -= withdrawnAmount;

            return new double[] { BalanceAmount, cashback };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();

            Console.WriteLine("Enter the card number");
            service.CardNumber = long.Parse(Console.ReadLine());

            if (!service.ValidateCardNumber())
            {
                Console.WriteLine("Invalid Card Number");
                return;
            }

            Console.WriteLine("Enter the card limit");
            service.BalanceAmount = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter the amount to be withdrawn");
            long withdrawnAmount = long.Parse(Console.ReadLine());

            double[] result = service.Withdraw(withdrawnAmount);

            if (result.Length == 0)
            {
                Console.WriteLine("Insufficient Balance");
            }
            else
            {
                Console.WriteLine($"Available balance is: {result[0]}");
                Console.WriteLine($"Cashback is: {result[1]}");
            }
        }
    }
}