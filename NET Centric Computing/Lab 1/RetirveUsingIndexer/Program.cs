using System;

class Students
{
    private string[] names = new string[5]; // Array to store names

    // Indexer to access the names array like a property
    public string this[int index]
    {
        get { return names[index]; }
        set { names[index] = value; }
    }

    static void Main()
    {
        Students s = new Students();

        Console.Write("How many student names do you want to enter (max 5)? ");
        int count;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out count) && count >= 1 && count <= 5)
                break;
            else
                Console.Write("Invalid number. Please enter a number between 1 and 5: ");
        }

        // Store names using indexer
        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter name of student " + i + ": ");
            s[i] = Console.ReadLine();
        }

        // Retrieve and display names using indexer
        Console.WriteLine("\nStudent names:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Student " + i + ": " + s[i]);
        }

        Console.ReadLine(); // Optional to keep the window open
    }
}
