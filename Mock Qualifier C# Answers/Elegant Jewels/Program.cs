using System;

namespace ElegantJewels
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the bill details");
            string billDetails = Console.ReadLine();

            Service service = new Service();
            service.ExtractDetails(billDetails);

            if (!service.ValidateMetalName())
            {
                Console.WriteLine("Invalid metal name");
                return;
            }

            double totalPrice = service.CalculateTotalPrice();
            Console.WriteLine($"The bill amount is: {totalPrice}");
        }
    }
}