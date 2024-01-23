// 11. Scenario:Boutique 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Order
{
    public string CustomerCode { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double ProductPrice { get; set; }
}

public class OrderDetails : Order
{
    public bool ValidateCustomerCode()
    {
        if (CustomerCode.Length == 5 && char.IsUpper(CustomerCode[0]) && char.IsUpper(CustomerCode[1]) && char.IsDigit(CustomerCode[2]) && char.IsDigit(CustomerCode[3]) && char.IsDigit(CustomerCode[4]))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Order CalculatePriceWithDeliveryCharge()
    {
        double deliveryCharge = 0;
        if (ProductPrice < 500)
        {
            deliveryCharge = ProductPrice * 0.4;
        }
        else if (ProductPrice >= 500 && ProductPrice <= 1000)
        {
            deliveryCharge = ProductPrice * 0.1;
        }
        ProductPrice += deliveryCharge;
        return this;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the customer code");
        string customerCode = Console.ReadLine();

        OrderDetails orderDetails = new OrderDetails
        {
            CustomerCode = customerCode
        };

        if (!orderDetails.ValidateCustomerCode())
        {
            Console.WriteLine("Invalid customer code");
            return;
        }

        Console.WriteLine("Enter the product id");
        orderDetails.ProductId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the product name");
        orderDetails.ProductName = Console.ReadLine();
        Console.WriteLine("Enter the price");
        orderDetails.ProductPrice = Convert.ToDouble(Console.ReadLine());

        Order order = orderDetails.CalculatePriceWithDeliveryCharge();

        Console.WriteLine($"Customer Code : {order.CustomerCode}");
        Console.WriteLine($"Product Id : {order.ProductId}");
        Console.WriteLine($"Product Name : {order.ProductName}");
        Console.WriteLine($"Amount With Delivery Charge : {order.ProductPrice}");
    }
}