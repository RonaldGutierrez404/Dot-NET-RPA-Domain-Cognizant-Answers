// 13. Konark Health Care
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Vaccine
{
    public string BookingId { get; set; }
    public string Name { get; set; }
    public string VaccineType { get; set; }
    public string DoseNumber { get; set; }
    public string BookingDate { get; set; }
}

public class Program
{
    public static List<Vaccine> VaccineList = new List<Vaccine>();

    public static void AddVaccineDetails(string[] vaccineDetails)
    {
        foreach (var detail in vaccineDetails)
        {
            var details = detail.Split(',');
            VaccineList.Add(new Vaccine
            {
                BookingId = details[0].Trim(),
                Name = details[1].Trim(),
                VaccineType = details[2].Trim(),
                DoseNumber = details[3].Trim(),
                BookingDate = details[4].Trim()
            });
        }
    }

    public static List<Vaccine> ViewBookingDetailsByDoseNumber(string doseNumber)
    {
        var result = VaccineList.Where(v => v.DoseNumber == doseNumber).ToList();
        if (!result.Any())
        {
            Console.WriteLine("Dose number not found");
        }
        return result;
    }

    public static List<Vaccine> ViewBookingDetailsByVaccineType(string vaccineType)
    {
        var result = VaccineList.Where(v => v.VaccineType == vaccineType).ToList();
        if (!result.Any())
        {
            Console.WriteLine("Vaccine type not found");
        }
        return result;
    }

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Add Vaccine Details");
            Console.WriteLine("2. View Details By Dose Number");
            Console.WriteLine("3. View Details By Vaccine Type");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter the choice");
            var choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the number of entries");
                    var entries = Convert.ToInt32(Console.ReadLine());
                    var vaccines = new string[entries];
                    for (int i = 0; i < entries; i++)
                    {
                        vaccines[i] = Console.ReadLine();
                    }
                    AddVaccineDetails(vaccines);
                    break;
                case 2:
                    Console.WriteLine("Enter the dose number");
                    var doseNumber = Console.ReadLine();
                    var doseNumberResult = ViewBookingDetailsByDoseNumber(doseNumber);
                    foreach (var vaccine in doseNumberResult)
                    {
                        Console.WriteLine($"{vaccine.BookingId} {vaccine.Name} {vaccine.VaccineType} {vaccine.DoseNumber} {vaccine.BookingDate}");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter the vaccine type");
                    var vaccineType = Console.ReadLine();
                    var vaccineTypeResult = ViewBookingDetailsByVaccineType(vaccineType);
                    foreach (var vaccine in vaccineTypeResult)
                    {
                        Console.WriteLine($"{vaccine.BookingId} {vaccine.Name} {vaccine.VaccineType} {vaccine.DoseNumber} {vaccine.BookingDate}");
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