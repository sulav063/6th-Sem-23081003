using System;
using System.Collections.Generic;

class GenericList
{
    public static void Run()
    {
        List<int> numbers = new List<int>(); // Create list

        for (int i = 1; i <= 10; i++)
        {
            numbers.Add(i); // Add numbers to list
        }

        Console.WriteLine("Numbers from 1 to 10:");
        foreach (int n in numbers)
        {
            Console.WriteLine(n); // Print numbers
        }
    }
}
