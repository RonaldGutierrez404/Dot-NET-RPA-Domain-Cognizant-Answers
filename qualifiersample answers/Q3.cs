// 3.E-Restaurant
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class FoodDetails
    {
        public string FoodType { get; set; }
        public int Quantity { get; set; }
        public int PricePerPiece { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
    }

    public class Billing : FoodDetails
    {
        public bool ValidateFoodType(string foodType)
        {
            return foodType == "Samosa" || foodType == "Spring Roll" || foodType == "Empanada";
        }

        public FoodDetails GenerateBill()
        {
            TotalPrice = Quantity * PricePerPiece;
            if (TotalPrice >= 100 && TotalPrice <= 500)
            {
                Discount = TotalPrice * 0.1;
            }
            else if (TotalPrice > 500 && TotalPrice <= 1000)
            {
                Discount = TotalPrice * 0.15;
            }
            else if (TotalPrice > 1000)
            {
                Discount = TotalPrice * 0.2;
            }
            else
            {
                Discount = 0;
            }
            return this;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the food type");
            string foodType = Console.ReadLine();
            Console.WriteLine("Enter the quantity");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the price per piece");
            int pricePerPiece = Convert.ToInt32(Console.ReadLine());

            Billing billing = new Billing
            {
                FoodType = foodType,
                Quantity = quantity,
                PricePerPiece = pricePerPiece
            };

            if (!billing.ValidateFoodType(foodType))
            {
                Console.WriteLine("Invalid food type");
                return;
            }

            FoodDetails foodDetails = billing.GenerateBill();

            Console.WriteLine($"FoodType\tQuantity\tPricePerPiece\tDiscount\tTotalPrice");
            Console.WriteLine($"{foodDetails.FoodType}\t{foodDetails.Quantity}\t{foodDetails.PricePerPiece}\t{foodDetails.Discount}\t{foodDetails.TotalPrice}");
        }
    }
}