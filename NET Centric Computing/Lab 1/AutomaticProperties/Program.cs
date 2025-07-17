using System;

class Student
{
    // Automatic properties
    public int Id { get; set; }
    public string Name { get; set; }

    static void Main()
    {
        Student s = new Student();

        // Ask user to enter student ID
        Console.Write("Enter Student ID: ");
        s.Id = int.Parse(Console.ReadLine());  // Convert input to int

        // Ask user to enter student name
        Console.Write("Enter Student Name: ");
        s.Name = Console.ReadLine();  // Read string input

        // Display values
        Console.WriteLine("\nStudent Details:");
        Console.WriteLine("Student ID: " + s.Id);
        Console.WriteLine("Student Name: " + s.Name);

        Console.ReadLine(); // To keep the console open
        Console.ReadKey();
    }
}
