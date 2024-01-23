using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Net_App1
{
    public class Program
    {
        static void Main(string[] args)
        {
            CollegeUtility collegeUtility = new CollegeUtility();
            int choice;
            do
            {
                Console.WriteLine("Enter the choice");
                Console.WriteLine("1. Delete the college id in the database.");
                Console.WriteLine("2. Get College By Id");
                Console.WriteLine("3. Calculate the Fees of the College.");
                Console.WriteLine("4. Exit");
                Console.Write("Select Your Choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the Id : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        bool isDeleted = collegeUtility.DeleteCollegeById(id);
                        Console.WriteLine(isDeleted ? "College Information Deleted Successfully" : "College Information Deletion Failed");
                        break;
                    case 2:
                        Console.Write("Enter the College id : ");
                        id = Convert.ToInt32(Console.ReadLine());
                        College college = collegeUtility.GetCollegeById(id);
                        Console.WriteLine($"{college.Id} {college.Name} {college.Location} {college.StudentsCount}");
                        break;
                    case 3:
                        Console.Write("Enter the College Name : ");
                        string collegeName = Console.ReadLine();
                        Console.Write("Enter the Department : ");
                        string department = Console.ReadLine();
                        int fees = collegeUtility.CalculateFees(collegeName, department);
                        Console.WriteLine($"The calculated fees is {fees}");
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            } while (choice != 4);
        }
    }
}