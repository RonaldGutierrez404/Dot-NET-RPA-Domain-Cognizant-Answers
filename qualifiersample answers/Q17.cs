// Fashion Store 

using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionStore
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class Program
    {
        public static Dictionary<int, Product> products = new Dictionary<int, Product>();

        public static Dictionary<int, Product> SearchProduct(string productName)
        {
            var result = products.Where(p => p.Value.Name == productName).ToDictionary(p => p.Key, p => p.Value);
            if (result.Count == 0)
            {
                Console.WriteLine("Product Not Found");
            }
            return result;
        }

        public static Dictionary<int, Product> UpdateProductPrice(string productName, double price)
        {
            var result = products.Where(p => p.Value.Name == productName).ToDictionary(p => p.Key, p => p.Value);
            if (result.Count == 0)
            {
                Console.WriteLine("Product Not Found");
            }
            else
            {
                foreach (var item in result)
                {
                    item.Value.Price = price;
                }
            }
            return result;
        }

        public static Dictionary<int, Product> SortByProductName()
        {
            return products.OrderBy(p => p.Value.Name).ToDictionary(p => p.Key, p => p.Value);
        }

        static void Main(string[] args)
        {
            // Add your products to the 'products' dictionary here
            products.Add(1, new Product { Id = 1, Name = "Shirt", Price = 450 });
            products.Add(2, new Product { Id = 2, Name = "Pant", Price = 500 });
            products.Add(3, new Product { Id = 3, Name = "Shoe", Price = 250 });

            while (true)
            {
                Console.WriteLine("1. Search product by name");
                Console.WriteLine("2. Update product price");
                Console.WriteLine("3. Sort product by name");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter a product name to search:");
                        string searchName = Console.ReadLine();
                        var searchResult = SearchProduct(searchName);
                        foreach (var item in searchResult)
                        {
                            Console.WriteLine($"Product ID: {item.Value.Id}   Name: {item.Value.Name}   Price: {item.Value.Price}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter a product name to update:");
                        string updateName = Console.ReadLine();
                        Console.WriteLine("Enter a new price for the product:");
                        double newPrice = Convert.ToDouble(Console.ReadLine());
                        var updateResult = UpdateProductPrice(updateName, newPrice);
                        foreach (var item in updateResult)
                        {
                            Console.WriteLine($"Product ID: {item.Value.Id}   Name: {item.Value.Name}   Price: {item.Value.Price}");
                        }
                        break;
                    case 3:
                        var sortedProducts = SortByProductName();
                        foreach (var item in sortedProducts)
                        {
                            Console.WriteLine($"Product ID: {item.Value.Id}   Name: {item.Value.Name}   Price: {item.Value.Price}");
                        }
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
        }
    }
}
