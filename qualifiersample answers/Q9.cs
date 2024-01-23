// 9. Global Technologies
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public double Salary { get; set; }
    public int IncrementPercentage { get; set; }
}

public class Service : Employee
{
    public bool FindIncrementPercentage(int yearsOfExperience)
    {
        if (yearsOfExperience >= 1 && yearsOfExperience <= 5)
        {
            IncrementPercentage = 15;
            return true;
        }
        else if (yearsOfExperience >= 6 && yearsOfExperience <= 10)
        {
            IncrementPercentage = 30;
            return true;
        }
        else if (yearsOfExperience >= 11 && yearsOfExperience <= 15)
        {
            IncrementPercentage = 45;
            return true;
        }
        else
        {
            return false;
        }
    }

    public double CalculateIncrementedSalary()
    {
        return Salary + ((Salary * IncrementPercentage) / 100);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the employee id");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the employee name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the salary");
        double salary = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the number of years in experience");
        int experience = Convert.ToInt32(Console.ReadLine());

        Service service = new Service
        {
            EmployeeId = id,
            EmployeeName = name,
            Salary = salary
        };

        if (!service.FindIncrementPercentage(experience))
        {
            Console.WriteLine("Invalid Years of Experience");
            return;
        }

        double incrementedSalary = service.CalculateIncrementedSalary();

        Console.WriteLine("Incremented Salary - " + incrementedSalary);
    }
}