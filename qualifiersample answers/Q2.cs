// 2. E-insurance 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Program
    {
        public static Dictionary<string, double> SchemeDetails = new Dictionary<string, double>();

        public static void AddSchemeDetails(string[] scheme)
        {
            foreach (var s in scheme)
            {
                var details = s.Split(':');
                SchemeDetails[details[0]] = Convert.ToDouble(details[1]);
            }
        }

        public static double FindSchemeMonthlyAmount(string schemeName)
        {
            if (SchemeDetails.ContainsKey(schemeName))
            {
                return SchemeDetails[schemeName];
            }
            else
            {
                Console.WriteLine("No schemes are available");
                return -1;
            }
        }

        public static List<string> FindLowestMonthlyAmountScheme()
        {
            var minAmount = SchemeDetails.Values.Min();
            return SchemeDetails.Where(x => x.Value == minAmount).Select(x => x.Key).ToList();
        }

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add Scheme Details");
                Console.WriteLine("2. View Monthly Amount Based on Name");
                Console.WriteLine("3. View Schemes With Lowest Monthly Amount");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter the choice");
                var choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the number of entries");
                        var entries = Convert.ToInt32(Console.ReadLine());
                        var schemes = new string[entries];
                        for (int i = 0; i < entries; i++)
                        {
                            schemes[i] = Console.ReadLine();
                        }
                        AddSchemeDetails(schemes);
                        break;
                    case 2:
                        Console.WriteLine("Enter the scheme name needs to be searched");
                        var schemeName = Console.ReadLine();
                        var amount = FindSchemeMonthlyAmount(schemeName);
                        if (amount != -1)
                        {
                            Console.WriteLine("Amount is : " + amount);
                        }
                        break;
                    case 3:
                        var lowestSchemes = FindLowestMonthlyAmountScheme();
                        Console.WriteLine("Schemes with the lowest monthly amount are:");
                        foreach (var scheme in lowestSchemes)
                        {
                            Console.WriteLine(scheme);
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
}