using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors_Hut
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the parking details");
            string parkingDetails = Console.ReadLine();

            Service service = new Service();
            service.ExtractDetails(parkingDetails);

            if (service.ValidateVehicleType())
            {
                double totalAmount = service.CalculateTotalAmount();
                Console.WriteLine($"The amount to be paid: {totalAmount}");
            }
            else
            {
                Console.WriteLine("Invalid vehicle type");
            }
        }
    }
}