// 12. Scenario:
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Plant
{
    public string PlantName { get; set; }
    public int NoOfSapling { get; set; }
    public string Category { get; set; }
    public int PricePerSapling { get; set; }
}

public class PlantUtility : Plant
{
    public Plant ExtractDetails(string plantDetails)
    {
        var details = plantDetails.Split(':');
        PlantName = details[0];
        NoOfSapling = Convert.ToInt32(details[1]);
        Category = details[2];
        PricePerSapling = Convert.ToInt32(details[3]);
        return this;
    }

    public double CalculateCost()
    {
        double totalAmount = NoOfSapling * PricePerSapling;
        double discount = 0;
        if (totalAmount > 500 && totalAmount <= 1000)
        {
            discount = totalAmount * 0.1;
        }
        else if (totalAmount > 1000)
        {
            discount = totalAmount * 0.2;
        }
        return totalAmount - discount;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the plant details");
        string plantDetails = Console.ReadLine();

        PlantUtility plantUtility = new PlantUtility();
        Plant plant = plantUtility.ExtractDetails(plantDetails);

        double cost = plantUtility.CalculateCost();

        Console.WriteLine($"Plant name is : {plant.PlantName}");
        Console.WriteLine($"No of sapling is : {plant.NoOfSapling}");
        Console.WriteLine($"Category : {plant.Category}");
        Console.WriteLine($"Price per sapling : {plant.PricePerSapling}");
        Console.WriteLine($"Total cost is : {cost}");
    }
}
