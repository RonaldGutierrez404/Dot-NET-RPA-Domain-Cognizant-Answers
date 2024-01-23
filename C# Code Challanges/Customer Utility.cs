using System;
using System.Collections.Generic;
 
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
 
    public override string ToString()
    {
        return $"{Id} {Name} {City}";
    }
}
 
public class CustomerUtility
{
    public List<Customer> CustList { get; set; } = new List<Customer>();
 
    public List<Customer> AddCustomer(Customer customer)
    {
        CustList.Add(customer);
        return CustList;
    }
 
    public Customer SearchCustomerByID(int customerId)
    {
        return CustList.Find(customer => customer.Id == customerId);
    }
 
    public void DisplayAllCustomers()
    {
        foreach (var customer in CustList)
        {
            Console.WriteLine(customer.ToString());
        }
    }
 
    public void DeleteCustomer(int customerId)
    {
        CustList.RemoveAll(customer => customer.Id == customerId);
    }
}
 
public class Program
{
    public static void Main()
    {
        CustomerUtility customerUtility = new CustomerUtility();
 
        while (true)
        {
            Console.WriteLine("1. Add Customer\n2. Display Customer\n3. Search Customer\n4. Delete Customer\nEnter Your Choice");
            int choice = Convert.ToInt32(Console.ReadLine());
 
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Customer id, name and city");
                    int id = Convert.ToInt32(Console.ReadLine());
                    string name = Console.ReadLine();
                    string city = Console.ReadLine();
                    Customer newCustomer = new Customer { Id = id, Name = name, City = city };
                    customerUtility.AddCustomer(newCustomer);
                    break;
 
                case 2:
                    customerUtility.DisplayAllCustomers();
                    break;
 
                case 3:
                    Console.WriteLine("Enter Customer id");
                    int searchId = Convert.ToInt32(Console.ReadLine());
                    Customer foundCustomer = customerUtility.SearchCustomerByID(searchId);
                    if (foundCustomer != null)
                        Console.WriteLine(foundCustomer.ToString());
                    else
                        Console.WriteLine("Customer not found.");
                    break;
 
                case 4:
                    Console.WriteLine("Enter Customer id");
                    int deleteId = Convert.ToInt32(Console.ReadLine());
                    customerUtility.DeleteCustomer(deleteId);
                    break;
 
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}