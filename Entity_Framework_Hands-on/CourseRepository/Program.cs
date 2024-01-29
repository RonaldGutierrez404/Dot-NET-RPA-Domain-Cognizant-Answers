using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1       //DO NOT Change the namespace name
{
    public class Program         //DO NOT Change the class name
    {
        static void Main(string[] args)
        {
            //Implement code here
            CourseContext context = new CourseContext();
        CourseRepository courseRepo = new CourseRepository(context);

        // Add course details
        Course course1 = new Course { CourseId = 1001, CourseName = "Java Programming", Duration = 3, CourseFee = 6000, InstructorName = "SAM" };
        courseRepo.InsertCourse(course1);
        Console.WriteLine("Details Added Successfully.");

        Course course2 = new Course { CourseId = 1002, CourseName = "Dot Net", Duration = 4, CourseFee = 8000, InstructorName = "SANDY" };
        courseRepo.InsertCourse(course2);
        Console.WriteLine("Details Added Successfully.");

        // Retrieve course details by id
        Course retrievedCourse = courseRepo.GetCourseByID(1002);
        Console.WriteLine($"{retrievedCourse.CourseId}-{retrievedCourse.CourseName}-{retrievedCourse.Duration}-{retrievedCourse.CourseFee}-{retrievedCourse.InstructorName}");

        // Retrieve the entire list of course details
        IList<Course> courseList = courseRepo.GetCourseList();
        foreach (Course course in courseList)
        {
            Console.WriteLine($"{course.CourseId}-{course.CourseName}-{course.Duration}-{course.CourseFee}-{course.InstructorName}");
        }

        // Update course fee
        Course updatedCourse = courseRepo.UpdateCourseFee(1001, 10000);
        Console.WriteLine("Updated Successfully");
        }
    }
}