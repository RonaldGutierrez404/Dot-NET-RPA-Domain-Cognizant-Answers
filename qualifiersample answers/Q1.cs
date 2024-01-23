// 1.Power Managements 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Try
    {
        public static Dictionary<string, int> PowerBankDetails = new Dictionary<string, int>();

        public static void AddPowerBankDetails(string[] powerBank)
        {
            foreach (var item in powerBank)
            {
                var details = item.Split(':');
                PowerBankDetails.Add(details[0], int.Parse(details[1]));
            }
        }

        public static int FindBatteryPower(string powerBankName)
        {
            if (PowerBankDetails.ContainsKey(powerBankName))
            {
                return PowerBankDetails[powerBankName];
            }
            else
            {
                Console.WriteLine("No power banks are available");
                return -1;
            }
        }

        public static List<string> FindTheHighestPowerBattery()
        {
            var maxPower = PowerBankDetails.Values.Max();
return PowerBankDetails.Where(x => x.Value == maxPower).Select(x => x.Key).ToList();
        }


        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add Power Bank Details");
                Console.WriteLine("2. View Battery Power");
          Console.WriteLine("3. View Power Banks With Highest Battery Power");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter the choice");
                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the number of entries");
                        var entries = int.Parse(Console.ReadLine());
                        var powerBanks = new string[entries];
                        for (int i = 0; i < entries; i++)
                        {
                            powerBanks[i] = Console.ReadLine();
                        }
                        AddPowerBankDetails(powerBanks);
                        break;
                    case 2:
         Console.WriteLine("Enter the power bank name needs to be searched");
                   var powerBankName = Console.ReadLine();
                        var power = FindBatteryPower(powerBankName);
                        if (power != -1)
                        {
                            Console.WriteLine(power);
                        }
                        break;
                    case 3:
                        var highestPowerBanks = FindTheHighestPowerBattery();
            Console.WriteLine("Power Banks with the highest battery power are:");
                        foreach (var bank in highestPowerBanks)
                        {
                            Console.WriteLine(bank);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Thank you.");
                        return;
                }
            }
        }
    }
}
