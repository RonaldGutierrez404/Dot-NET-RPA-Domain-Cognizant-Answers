// 6. Property Tax Management
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 public class PropertyTax
 {
     public string PlotNumber { get; set; }
     public string OwnerName { get; set; }
     public string BuildingType { get; set; }
     public int SquareFeet { get; set; }
 }

 public class Service : PropertyTax
 {
     public bool ValidatePlotNumber(string plotNumber)
     {
         if (plotNumber.Length != 10)
             return false;

         if (!char.IsLower(plotNumber[0]) || !char.IsLower(plotNumber[1]) || !char.IsLower(plotNumber[2]))
             return false;

         if (plotNumber[3] != '/')
             return false;

         for (int i = 4; i < 10; i++)
         {
             if (!char.IsDigit(plotNumber[i]))
                 return false;
         }

         return true;
     }

     public double CalculateTaxAmount()
     {
         double taxAmount = 0.0;

         if (BuildingType == "Commercial")
             taxAmount = SquareFeet * 1.5;
         else if (BuildingType == "Residential")
             taxAmount = SquareFeet * 0.75;

         return taxAmount;
     }
 }

 public class Program
 {
     static void Main(string[] args)
     {
         Console.WriteLine("Enter the plot number");
         string plotNumber = Console.ReadLine();

         Console.WriteLine("Enter the owner name");
         string ownerName = Console.ReadLine();

         Console.WriteLine("Enter the building type");
         string buildingType = Console.ReadLine();

         Console.WriteLine("Enter the square feet");
         int squareFeet = int.Parse(Console.ReadLine());

         Service service = new Service();
         service.PlotNumber = plotNumber;
         service.OwnerName = ownerName;
         service.BuildingType = buildingType;
         service.SquareFeet = squareFeet;

         if (service.ValidatePlotNumber(plotNumber))
         {
             double taxAmount = service.CalculateTaxAmount();
             Console.WriteLine("\nTax Amount: " + taxAmount.ToString());
         }
         else
         {
             Console.WriteLine("\nInvalid plot number");
         }
     }
 }