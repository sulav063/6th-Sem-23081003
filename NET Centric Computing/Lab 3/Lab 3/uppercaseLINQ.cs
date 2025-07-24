using System;
using System.Linq;

namespace Utilities
{
    public class UppercaseLINQ
    {
        public static void Run()
        {
            // Clear the console to show only current output
            Console.Clear();

            // Ask user for input string
            Console.WriteLine("Enter a string:");
            string text = Console.ReadLine();

            // Find uppercase letters using LINQ
            var uppercase = text.Where(letter => char.IsUpper(letter)).ToList();

            // Show uppercase letters
            Console.WriteLine("Uppercase letters:");
            foreach (char letter in uppercase)
            {
                Console.WriteLine(letter);
            }
        }
    }
}