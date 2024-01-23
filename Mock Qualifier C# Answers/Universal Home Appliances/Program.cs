using System;
using System.Collections.Generic;

namespace UniversalHomeAppliances
{
    public class Program
    {
        public static Dictionary<int, Appliance> applianceDetails = new Dictionary<int, Appliance>();

        public static Dictionary<string, string> GetApplianceDetails(string applianceId)
        {
            var result = new Dictionary<string, string>();
            foreach (var item in applianceDetails)
            {
                if (item.Value.Id == applianceId)
                {
                    result.Add(item.Value.Id, $"{item.Value.Name}_{item.Value.Brand}");
                    break;
                }
            }
            return result;
        }

       public static Dictionary<string, string> FindApplianceWithPriceRange(double minRange, double maxRange)
{
  var result = new Dictionary<string, string>();

  // Clear result to start fresh
  result.Clear(); 

  // Loop through each appliance
  foreach (var item in applianceDetails)  
  {
    // Check if price is within range (inclusive)
    if (item.Value.Price >= minRange && item.Value.Price <= maxRange)
    {
       // Add appliance details to result
       result.Add(item.Value.Id, $"{item.Value.Name}_{item.Value.Brand}");
    }
  }

  // If no appliances found, return empty dict
  if (result.Count == 0)
  {
    return new Dictionary<string, string>(); 
  }

  // Return result with appliances in range
  return result;
}

        public static Dictionary<int, Appliance> FindHighCostAppliance()
        {
            var result = new Dictionary<int, Appliance>();
            double maxPrice = 0;
            foreach (var item in applianceDetails)
            {
                if (item.Value.Price > maxPrice)
                {
                    maxPrice = item.Value.Price;
                    result.Clear();
                    result.Add(item.Key, item.Value);
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            // Initialize the applianceDetails dictionary here
            // Get the values from the user
            // Call the methods accordingly
            // Display the result as per the Sample Input/Output given

            while (true)
            {
                Console.WriteLine("\n1. Get appliance details");
                Console.WriteLine("2. Find appliance with price range");
                Console.WriteLine("3. Find high cost appliance");
                Console.WriteLine("4. Exit");
                Console.Write("\nEnter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the appliance id: ");
                        string id = Console.ReadLine();
                        var details = GetApplianceDetails(id);
                        if (details.Count == 0)
                        {
                            Console.WriteLine("Appliance id not found");
                        }
                        else
                        {
                            foreach (var detail in details)
                            {
                                Console.WriteLine($"{detail.Key} {detail.Value}");
                            }
                        }
                        break;

                    case 2:
                        Console.Write("Enter the minimum price range: ");
                        double minRange = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter the maximum price range: ");
                        double maxRange = Convert.ToDouble(Console.ReadLine());
                        var appliances = FindApplianceWithPriceRange(minRange, maxRange);
                        if (appliances.Count == 0)
                        {
                            Console.WriteLine("Appliance not found");
                        }
                        else
                        {
                            foreach (var appliance in appliances)
                            {
                                Console.WriteLine($"{appliance.Key} {appliance.Value}");
                            }
                        }
                        break;

                    case 3:
                        var highCostAppliance = FindHighCostAppliance();
                        foreach (var appliance in highCostAppliance)
                        {
                            Console.WriteLine($"ID : {appliance.Value.Id}, Name : {appliance.Value.Name}, Brand : {appliance.Value.Brand}, Price : {appliance.Value.Price}");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}