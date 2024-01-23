using System;

public abstract class Employee
{
    protected string name;
    protected double salary;
    public Employee(string name, double salary)
    {
        this.name = name;
        this.salary = salary;
    }
    public abstract void Print();
}
public class Programmer : Employee
{
    protected string domain;
    public Programmer(string domain) : base("Unknown", 0)
    {
        this.domain = domain;
    }
 
    public Programmer(string name, double salary, string domain) : base(name, salary)
    {
        this.domain = domain;
    }
 
    // implement the IIncrementable interface
    public double Increment()
    {
        // programmers get a 10% raise during increment
        salary = salary * 1.1;
        return salary;
    }
 
    // override the abstract method to print the details of the programmer
    public override void Print()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Salary: {salary}");
        Console.WriteLine($"Domain: {domain}");
    }
}
 
// create a class Manager that inherits Employee
public class Manager : Employee
{
    // protected field for teamId
    protected string teamId;
 
    // parameterized constructor that accepts teamId as parameter
    public Manager(string teamId) : base("Unknown", 0)
    {
        this.teamId = teamId;
    }
 
    // parameterized constructor that accepts name, salary, and teamId as parameters
    public Manager(string name, double salary, string teamId) : base(name, salary)
    {
        this.teamId = teamId;
    }
 
    // implement the IIncrementable interface
    public double Increment()
    {
        // managers get a 50% raise during increment
        salary = salary * 1.5;
        return salary;
    }
 
    // override the abstract method to print the details of the manager
    public override void Print()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Salary: {salary}");
        Console.WriteLine($"TeamId: {teamId}");
    }
}
 
// create an interface IIncrementable
public interface IIncrementable
{
    // method to return the incremented salary
    double Increment();
}
 
// create a public class Program
public class Program
{
    // define the Main method
    public static void Main(string[] args)
    {
        // create objects for Programmer and Manager by calling their constructors
        Programmer p1 = new Programmer("Akash", 30000, "JAVA");
        Manager m1 = new Manager("Adam", 50000, "JA01");
 
        // call their Increment method and print the results
        p1.Increment();
        m1.Increment();
        p1.Print();
        m1.Print();
    }
}