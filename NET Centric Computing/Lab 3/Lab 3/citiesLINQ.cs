using System;
using System.Linq;

namespace Utilities
{
    public class CitiesLINQ
    {
        public static void Run()
        {
            // Clear the screen
            Console.Clear();

            // List of cities
            string[] cities = { "ROME", "LONDON", "NAIROBI", "CALIFORNIA",
                               "ZURICH", "NEWDELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };

            // Ask for start letter
            Console.WriteLine("Type one letter to start the city name:");
            string startInput = Console.ReadLine();

            // Ask for end letter
            Console.WriteLine("Type one letter to end the city name:");
            string endInput = Console.ReadLine();

            // Check if inputs are one letter
            if (startInput.Length != 1 || endInput.Length != 1)
            {
                Console.WriteLine("Please type only one letter for each!");
                return;
            }

            // Get start and end letters (make them uppercase)
            char startLetter = char.ToUpper(startInput[0]);
            char endLetter = char.ToUpper(endInput[0]);

            // Find cities that start and end with the letters
            var matchingCities = cities.Where(city => city[0] == startLetter &&
                                                    city[city.Length - 1] == endLetter);

            // Show cities
            Console.WriteLine($"Cities starting with '{startLetter}' and ending with '{endLetter}':");
            if (matchingCities.Any())
            {
                foreach (string city in matchingCities)
                {
                    Console.WriteLine(city);
                }
            }
            else
            {
                Console.WriteLine("No cities found!");
            }
        }
    }
}