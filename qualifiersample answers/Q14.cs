// 14. Pearl Drink app 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 public class Program
 {
     public static Dictionary<string, int> beverageDetails = new Dictionary<string, int>()
	 {
	  {"Fanta", 55},
    {"AppyFizz", 100},
    {"Almond Milk", 75},
    {"Pepsi", 50},
    {"Coca-Cola", 60}
	 };

     public static Dictionary<string, int> SearchBeverage(string beverageName)
     {
         if (beverageDetails.ContainsKey(beverageName))
         {
             return new Dictionary<string, int> { { beverageName, beverageDetails[beverageName] } };
         }
         else
         {
             Console.WriteLine("Beverage Not Found");
             return new Dictionary<string, int>();
         }
     }

     public static Dictionary<string, int> UpdateBeveragePrice(string beverageName, int price)
     {
         if (beverageDetails.ContainsKey(beverageName))
         {
             beverageDetails[beverageName] = price;
             return new Dictionary<string, int> { { beverageName, price } };
         }
         else
         {
             Console.WriteLine("Beverage Not Found");
             return new Dictionary<string, int>();
         }
     }

     public static Dictionary<string, int> SortByBeverageName()
     {
         return beverageDetails.OrderBy(b => b.Key).ToDictionary(b => b.Key, b => b.Value);
     }

     public static void Main(string[] args)
     {
         while (true)
         {
             Console.WriteLine("1. Search by beverage name");
             Console.WriteLine("2. Update beverage price");
             Console.WriteLine("3. Sort beverages by name");
             Console.WriteLine("4. Exit");
             Console.WriteLine("Enter your choice");
             var choice = Convert.ToInt32(Console.ReadLine());

             switch (choice)
             {
                 case 1:
                     Console.WriteLine("Enter the beverage name");
                     var beverageName = Console.ReadLine();
                     var beverage = SearchBeverage(beverageName);
                     foreach (var b in beverage)
                     {
                         Console.WriteLine($"{b.Key} {b.Value}");
                     }
                     break;
                 case 2:
                     Console.WriteLine("Enter the beverage name");
                     beverageName = Console.ReadLine();
                     Console.WriteLine("Enter the beverage price");
                     var price = Convert.ToInt32(Console.ReadLine());
                     var updatedBeverage = UpdateBeveragePrice(beverageName, price);
                     foreach (var b in updatedBeverage)
                     {
                         Console.WriteLine($"{b.Key} {b.Value}");
                     }
                     break;
                 case 3:
                     var sortedBeverages = SortByBeverageName();
                     foreach (var b in sortedBeverages)
                     {
                         Console.WriteLine($"{b.Key} {b.Value}");
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