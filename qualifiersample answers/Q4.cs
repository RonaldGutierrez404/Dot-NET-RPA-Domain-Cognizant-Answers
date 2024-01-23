// 4. Hill Adventure
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static Dictionary<string, int> HillDetails = new Dictionary<string, int>();

    public static void AddHillDetails(string[] hill)
    {
        foreach (var h in hill)
        {
            var details = h.Split(':');
            HillDetails[details[0]] = Convert.ToInt32(details[1]);
        }
    }

    public static int FindHillHeight(string hillName)
    {
        if (HillDetails.ContainsKey(hillName))
        {
            return HillDetails[hillName];
        }
        else
        {
            Console.WriteLine("No hills are available");
            return -1;
        }
    }

    public static List<string> FindTheHighestHills()
    {
        var maxHeight = HillDetails.Values.Max();
        return HillDetails.Where(x => x.Value == maxHeight).Select(x => x.Key).ToList();
    }

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Add Hill Details");
            Console.WriteLine("2. View Hill Height");
            Console.WriteLine("3. View Hills With Highest Height");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter the choice");
            var choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the number of entries");
                    var entries = Convert.ToInt32(Console.ReadLine());
                    var hills = new string[entries];
                    for (int i = 0; i < entries; i++)
                    {
                        hills[i] = Console.ReadLine();
                    }
                    AddHillDetails(hills);
                    break;
                case 2:
                    Console.WriteLine("Enter the hill name needs to be searched");
                    var hillName = Console.ReadLine();
                    var height = FindHillHeight(hillName);
                    if (height != -1)
                    {
                        Console.WriteLine("Height is : " + height);
                    }
                    break;
                case 3:
                    var highestHills = FindTheHighestHills();
                    Console.WriteLine("Hill names with the highest height are:");
                    foreach (var hill in highestHills)
                    {
                        Console.WriteLine(hill);
                    }
                    break;
                case 4:
                    Console.WriteLine("Thank you.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}