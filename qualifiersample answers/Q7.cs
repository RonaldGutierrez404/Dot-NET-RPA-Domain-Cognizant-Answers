// 7. Rating Grade

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static List<int> MarkList = new List<int>();

    public static void AddMarks(int marks)
    {
        MarkList.Add(marks);
    }

    public static double GetGPAScored()
    {
        if (MarkList.Count == 0)
        {
            Console.WriteLine("No Marks Available");
            return -1;
        }
        else
        {
            double gpa = 0;
            foreach (var mark in MarkList)
            {
                gpa += mark * 3;
            }
            gpa /= MarkList.Count * 3;
            return gpa;
        }
    }

    public static char GetGradeScored(double gpa)
    {
        if (gpa < 5 || gpa > 10)
        {
            Console.WriteLine("Invalid GPA");
            return '\0';
        }
        else if (gpa == 10) return 'S';
        else if (gpa >= 9) return 'A';
        else if (gpa >= 8) return 'B';
        else if (gpa >= 7) return 'C';
        else if (gpa >= 6) return 'D';
        else return 'E';
    }

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Add Mark");
            Console.WriteLine("2. Calculate GPA");
            Console.WriteLine("3. Get Grade");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice");
            var choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the mark scored");
                    var mark = Convert.ToInt32(Console.ReadLine());
                    AddMarks(mark);
                    break;
                case 2:
                    var gpa = GetGPAScored();
                    if (gpa != -1)
                    {
                        Console.WriteLine("GPA Scored: " + gpa);
                    }
                    break;
                case 3:
                    gpa = GetGPAScored();
                    if (gpa != -1)
                    {
                        var grade = GetGradeScored(gpa);
                        if (grade != '\0')
                        {
                            Console.WriteLine("Grade Scored: " + grade);
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("Thank You");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}