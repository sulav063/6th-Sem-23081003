using System;
using System.Linq;

namespace Utilities
{
    public class CharFrequencyLINQ
    {
        public static void Run()
        {
            // Get string from user
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            // Count each character using LINQ
            var frequency = input.GroupBy(c => c)
                                .Select(group => new { Character = group.Key, Count = group.Count() })
                                .OrderBy(x => x.Character);

            // Show character counts
            Console.WriteLine("Character counts:");
            foreach (var item in frequency)
            {
                Console.WriteLine($"Character '{item.Character}' appears {item.Count} times");
            }
        }
    }
}