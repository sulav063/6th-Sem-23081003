using System;
using System.Linq;
using System.Collections.Generic;

namespace Utilities
{
    public class MarksAbove80LINQ
    {
        public static void Run()
        {
            // List of student marks
            List<int> marks = new List<int> { 85, 76, 92, 65, 88, 79, 95, 72 };

            // Find marks greater than 80 using LINQ
            var highMarks = marks.Where(score => score > 80).ToList();

            // Show the count and list of high marks
            Console.WriteLine($"Students with marks > 80: {highMarks.Count}");
            Console.WriteLine("High marks:");
            foreach (int mark in highMarks)
            {
                Console.WriteLine(mark);
            }
        }
    }
}
