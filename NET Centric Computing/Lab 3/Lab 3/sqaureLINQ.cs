using System;
using System.Linq;

namespace Utilities
{
    public class SquareLINQ
    {
        public static void Run()
        {
            // Array of numbers
            int[] numbers = { 1, 2, 3, 4, 5 };

            // Calculate squares using LINQ
            var squares = numbers.Select(num => new { Number = num, Square = num * num });

            // Show numbers and their squares
            Console.WriteLine("Number squares:");
            foreach (var item in squares)
            {
                Console.WriteLine($"Square of Number {item.Number} is {item.Square}");
            }
        }
    }
}