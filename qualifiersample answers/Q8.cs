// 8. Grey Batteries 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static SortedDictionary<string, long> upsBatteryDetails = new SortedDictionary<string, long>()
{
    {"Exide Powersafe Plus", 55},
    {"Luminous Inverlast", 100},
    {"Amaron Quanta", 75},
    {"Microtek", 50},
    {"Su-Kam", 60}
};

    public static SortedDictionary<string, long> FindBatteryDetails(long soldCount)
    {
        SortedDictionary<string, long> result = new SortedDictionary<string, long>();

        if (upsBatteryDetails.ContainsValue(soldCount))
        {
            foreach (KeyValuePair<string, long> item in upsBatteryDetails)
            {
                if (item.Value == soldCount)
                {
                    result.Add(item.Key, item.Value);
                    break;
                }
            }
        }

        return result;
    }

    public static List<string> FindMinandMaxSoldBatteries()
    {
        List<string> result = new List<string>();
        long minSoldCount = long.MaxValue;
        long maxSoldCount = long.MinValue;
        string minSoldBattery = "";
        string maxSoldBattery = "";

        foreach (KeyValuePair<string, long> item in upsBatteryDetails)
        {
            if (item.Value < minSoldCount)
            {
                minSoldCount = item.Value;
                minSoldBattery = item.Key;
            }

            if (item.Value > maxSoldCount)
            {
                maxSoldCount = item.Value;
                maxSoldBattery = item.Key;
            }
        }

        result.Add(minSoldBattery);
        result.Add(maxSoldBattery);

        return result;
    }

    public static Dictionary<string, long> SortByCount()
    {
        Dictionary<string, long> result = new Dictionary<string, long>();

        foreach (KeyValuePair<string, long> item in upsBatteryDetails)
        {
            result.Add(item.Key, item.Value);
        }

        result = new Dictionary<string, long>(result.OrderBy(x => x.Value));

        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("1. Find battery details");
        Console.WriteLine("2. Minimum and Maximum sold");
        Console.WriteLine("3. Sort batteries by count");
        Console.WriteLine("4. Exit");

        Console.WriteLine("Enter your choice");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter the sold count");
                long soldCount = long.Parse(Console.ReadLine());

                SortedDictionary<string, long> batteryDetails = FindBatteryDetails(soldCount);

                if (batteryDetails.Count == 0)
                {
                    Console.WriteLine("\nInvalid sold count");
                }
                else
                {
                    Console.WriteLine("\nBattery Details\tSold Count");

                    foreach (KeyValuePair<string, long> item in batteryDetails)
                    {
                        Console.WriteLine(item.Key + "\t" + item.Value);
                    }
                }

                break;

            case 2:
                List<string> minMaxSoldBatteries = FindMinandMaxSoldBatteries();

                Console.WriteLine("\nMinimum and Maximum sold batteries:");
                Console.WriteLine(minMaxSoldBatteries[0] + ", " + minMaxSoldBatteries[1]);

                break;

            case 3:
                Dictionary<string, long> sortedBatteries = SortByCount();

                Console.WriteLine("\nBattery Details\tSold Count");

                foreach (KeyValuePair<string, long> item in sortedBatteries)
                {
                    Console.WriteLine(item.Key + "\t" + item.Value);
                }

                break;

            case 4:
                break;

            default:
                Console.WriteLine("\nInvalid choice");
                break;
        }
    }
}

