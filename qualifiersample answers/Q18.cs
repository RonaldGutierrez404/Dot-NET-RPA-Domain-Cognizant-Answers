// Atmosphere Data

using System;
using System.Collections.Generic;

namespace AtmosphereData
{
    public class Atmosphere
    {
        public string Location { get; set; }
        public string Date { get; set; }
        public int Temperature { get; set; }
        public string Status { get; set; }
    }

    public class Program
    {
        public static List<Atmosphere> AtmosphereList = new List<Atmosphere>();

        public static void AddAtmosphereDetails(string[] AtmosphereDetails)
        {
            foreach (var detail in AtmosphereDetails)
            {
                var splitDetails = detail.Split(',');
                AtmosphereList.Add(new Atmosphere
                {
                    Location = splitDetails[0],
                    Date = splitDetails[1],
                    Temperature = int.Parse(splitDetails[2]),
                    Status = splitDetails[3]
                });
            }
        }

        public static List<Atmosphere> ViewDetailsByLocation(string location)
        {
            return AtmosphereList.FindAll(a => a.Location == location);
        }

        public static List<Atmosphere> ViewDetailsByDate(string date)
        {
            return AtmosphereList.FindAll(a => a.Date == date);
        }

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("1. Add Atmosphere Details");
                Console.WriteLine("2. View Details By Location");
                Console.WriteLine("3. View Details By Date");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter the choice");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the number of entries");
                        int entries = int.Parse(Console.ReadLine());
                        string[] AtmosphereDetails = new string[entries];
                        for (int i = 0; i < entries; i++)
                        {
                            AtmosphereDetails[i] = Console.ReadLine();
                        }
                        AddAtmosphereDetails(AtmosphereDetails);
                        break;
                    case 2:
                        Console.WriteLine("Enter the location");
                        string location = Console.ReadLine();
                        List<Atmosphere> atmospheresByLocation = ViewDetailsByLocation(location);
                        if (atmospheresByLocation.Count == 0)
                        {
                            Console.WriteLine("Location is not found");
                        }
                        else
                        {
                            foreach (var atmosphere in atmospheresByLocation)
                            {
                                Console.WriteLine($"{atmosphere.Location}\t{atmosphere.Date}\t{atmosphere.Temperature}\t{atmosphere.Status}");
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the date");
                        string date = Console.ReadLine();
                        List<Atmosphere> atmospheresByDate = ViewDetailsByDate(date);
                        if (atmospheresByDate.Count == 0)
                        {
                            Console.WriteLine("Date is not found");
                        }
                        else
                        {
                            foreach (var atmosphere in atmospheresByDate)
                            {
                                Console.WriteLine($"{atmosphere.Location}\t{atmosphere.Date}\t{atmosphere.Temperature}\t{atmosphere.Status}");
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Thank you.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            } while (choice != 4);
        }
    }
}
