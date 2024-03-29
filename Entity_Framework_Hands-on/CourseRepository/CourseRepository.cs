using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Exercise1             //DO NOT Change the namespace name
{
   public class CourseRepository      //DO NOT Change the class name
    {
        //DO NOT Change the variable or method signature. Add only the required code inside the method.
        
        private CourseContext context;
        
        public CourseRepository(CourseContext context)
        {
            //Implement code here
            this.context = context;
        }
        
        public IList<Course> GetCourseList() => this.context.Courses.ToList();
        // {
        //     //Implement code here
        // }

        public Course GetCourseByID(int courseId) => this.context.Courses.Find(courseId);
        // {
        //      //Implement code here
        // }

        public void InsertCourse(Course course)
        {
             //Implement code here
              this.context.Courses.Add(course);
              this.context.SaveChanges();
        }

        public Course UpdateCourseFee(int id, double fee)
        {
             //Implement code here
             var course = this.context.Courses.Single(c => c.CourseId == id);
             course.CourseFee = fee;
             this.context.SaveChanges();

             return course;
        }
    }
}