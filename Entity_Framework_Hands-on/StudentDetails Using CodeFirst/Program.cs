using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement               //DO NOT Change the namespace name
{
    public class Program              //DO NOT Change the class name
    {
        public static void Main(string[] args)
        {
            //Implement the code here
             Console.WriteLine("Enter Student Id");
    int id = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Enter Student Name");
    string name = Console.ReadLine();

    Console.WriteLine("Enter Department");
    string department = Console.ReadLine();

    Console.WriteLine("Enter Enrollment Date");
    DateTime date = Convert.ToDateTime(Console.ReadLine());

    Console.WriteLine("Enter PhoneNumber");
    long phone = Convert.ToInt64(Console.ReadLine());

    Student student = new Student()
    {
        StudentId = id,
        StudentName = name,
        Department = department,
        EnrolledDate = date,
        PhoneNumber = phone
    };

    Program program = new Program();
    program.AddStudent(student);

    Console.WriteLine("Details Added Successfully");
        }
        
        public void AddStudent(Student student){       //Do not change the method signature
            
            //Add the student details to database. 
             using (var context = new CollegeContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }
    }
}