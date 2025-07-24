using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
    public class JoinojectLINQ
    {
        public static void Run()
        {
            // List of students (ID, Name)
            var students = new List<(int Id, string Name)>
            {
                (1, "John"),
                (2, "Jane")
            };

            // List of courses (StudentID, CourseName)
            var courses = new List<(int StudentId, string CourseName)>
            {
                (1, "Math"),
                (1, "Physics"),
                (2, "Chemistry")
            };

            // Join students and courses using LINQ
            var result = from student in students
                         join course in courses
                         on student.Id equals course.StudentId
                         select new { student.Name, course.CourseName };

            // Show joined results
            Console.WriteLine("Student courses:");
            foreach (var item in result)
            {
                Console.WriteLine($"Student: {item.Name}, Course: {item.CourseName}");
            }
        }
    }
}