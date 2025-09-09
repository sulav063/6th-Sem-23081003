using System;
using System.Linq;

namespace Lab4Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Display all students first
            DisplayStudents();

            // Insert a new student
            InsertStudent("Sita", 17);

            // Update student with ID = 1
            UpdateStudent(1, "Gaurav", 20);

            // Delete student with ID = 2
            DeleteStudent(2);

            // Display all students again
            DisplayStudents();

            Console.ReadLine();
        }

        // === READ ===
        static void DisplayStudents()
        {
            using (var db = new Lab4Q2DBEntities())
            {
                Console.WriteLine("\n=== Student Records ===");
                var students = db.Students.ToList();
                foreach (var s in students)
                {
                    Console.WriteLine($"ID: {s.StudentId}, Name: {s.Name}, Age: {s.Age}");
                }
            }
        }

        // === CREATE ===
        static void InsertStudent(string name, int age)
        {
            using (var db = new Lab4Q2DBEntities())
            {
                Student newStudent = new Student
                {
                    Name = name,
                    Age = age
                };

                db.Students.Add(newStudent);
                db.SaveChanges();

                Console.WriteLine($"\nInserted: {name}, Age {age}");
            }
        }

        // === UPDATE ===
        static void UpdateStudent(int id, string newName, int newAge)
        {
            using (var db = new Lab4Q2DBEntities())
            {
                var student = db.Students.Where(x => x.StudentId == id).FirstOrDefault();
                if (student != null)
                {
                    student.Name = newName;
                    student.Age = newAge;
                    db.SaveChanges();

                    Console.WriteLine($"\nUpdated ID={id}: {newName}, Age {newAge}");
                }
                else
                {
                    Console.WriteLine($"\n No student found with ID={id}");
                }
            }
        }

        // === DELETE ===
        static void DeleteStudent(int id)
        {
            using (var db = new Lab4Q2DBEntities())
            {
                var student = db.Students.Where(x => x.StudentId == id).FirstOrDefault();
                if (student != null)
                {
                    db.Students.Remove(student);
                    db.SaveChanges();

                    Console.WriteLine($"\nDeleted student with ID={id}");
                }
                else
                {
                    Console.WriteLine($"\n No student found with ID={id}");
                }
            }
        }
    }
}
