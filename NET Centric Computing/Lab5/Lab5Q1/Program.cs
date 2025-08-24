using System;
using System.Linq;
using Lab5Q1.Data;
using Lab5Q1.Models;
using Microsoft.EntityFrameworkCore;

using var context = new AppDbContext();

// Seed only once
if (!context.Students.Any())
{
    context.Students.AddRange(
        new Student { Name = "Pragyan", Age = 11 },
        new Student { Name = "Prapti", Age = 20 },
        new Student { Name = "Priyanka", Age = 22 }
    );
    context.SaveChanges();
}

// Query & display
var students = context.Students
    .AsNoTracking()
    .OrderBy(s => s.Id)
    .ToList();

Console.WriteLine("ID\tName\tAge");
foreach (var s in students)
{
    Console.WriteLine($"{s.Id}\t{s.Name}\t{s.Age}");
}

Console.WriteLine("\nDone. Press any key to exit...");
Console.ReadKey();
