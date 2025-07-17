using System;
using System.Collections.Generic;

class CustomerDictionary
{
    public static void Run()
    {
        // Make a dictionary to keep customer ID and name
        Dictionary<int, string> customers = new Dictionary<int, string>();

        // Ask how many customers to add
        Console.Write("How many customers? ");
        int count = int.Parse(Console.ReadLine());

        // Repeat for each customer
        for (int i = 0; i < count; i++)
        {
            // Get customer ID
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            // Get customer name
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            // Add to dictionary
            customers.Add(id, name);
        }

        // Show all customers
        Console.WriteLine("\nCustomers:");
        foreach (var c in customers)
        {
            Console.WriteLine("ID: " + c.Key + ", Name: " + c.Value);
        }
    }
}
