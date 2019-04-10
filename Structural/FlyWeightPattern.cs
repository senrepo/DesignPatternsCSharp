using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class FlyWeightPattern
    {
        public static void Test()
        {
            var registerMark = new Registeration("Mark");
            registerMark.Register("1");
            registerMark.Register("2");


            var registerJack = new Registeration("Jack");
            registerJack.Register("3");

            //Both Mark and Jack share the Course object
            registerMark.GetAllRegisterationDetails();
            registerJack.GetAllRegisterationDetails();
        }
    }

    /* Share the common objects with multiple instances of class and which would help reduce to memory useage if we are dealing with large no of objects
     * Each “flyweight” object is divided into two pieces: the state-dependent (extrinsic- non-shared) part, and the state-independent (intrinsic- shared) part.
     */

    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Duration { get; set; }
    }


    //internsic class - shared class
    public abstract class RegistrationBase
    {
        protected static Dictionary<string, Course> Courses = new Dictionary<string, Course>();

        static RegistrationBase()
        {
            Courses.Add("1", new Course { CourseId = "1", CourseName = "C#", Duration = "10 hrs" });
            Courses.Add("2", new Course { CourseId = "2", CourseName = "Javascript", Duration = "6 hrs" });
            Courses.Add("3", new Course { CourseId = "3", CourseName = "JQuery", Duration = "5 hrs" });
        }

        public abstract void Register(string courseId);
        public abstract void GetAllRegisterationDetails();
    }

    //extrinsic class
    public class Registeration : RegistrationBase
    {
        private string name;
        private List<string> registeredCourses = new List<string>();

        public Registeration(string name)
        {
            this.name = name;
        }

        public override void Register(string courseId)
        {
            registeredCourses.Add(courseId);
        }

        public override void GetAllRegisterationDetails()
        {

            foreach (var registeredCourse in registeredCourses)
            {
                var course = Courses[registeredCourse];
                Console.WriteLine("Course Id: " + course.CourseId + ", Course Name: " + course.CourseName + ", Duration: " + course.Duration);
            }
        }
    }

}
