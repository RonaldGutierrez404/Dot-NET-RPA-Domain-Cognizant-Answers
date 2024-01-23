// Hill Height

using System;
using System.Collections.Generic;
using System.Linq;

namespace HillHeight
{
    public class Program
    {
        public static Dictionary<string, int> HillDetails = new Dictionary<string, int>();

        public static void AddHillDetails(string[] hill)
        {
            foreach (var h in hill)
            {
                var details = h.Split(':');
                HillDetails[details[0]] = int.Parse(details[1]);
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
                return -1;
            }
        }

        public static List<string> FindTheHighestHills()
        {
            var max = HillDetails.Values.Max();
            return HillDetails.Where(h => h.Value == max).Select(h => h.Key).ToList();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add Hill Details\n2. View Hill Height\n3. View Hills With Highest Height\n4. Exit");
                Console.WriteLine("Enter the choice");
                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the number of entries");
                        var entries = int.Parse(Console.ReadLine());
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
                        if (height == -1)
                        {
                            Console.WriteLine("No hills are available");
                        }
                        else
                        {
                            Console.WriteLine($"Height is : {height}");
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
                        return;
                }
            }
        }
    }
}
