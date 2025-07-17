using System;

class AddTwoDigits
{
    int num1, num2;

    // Constructor to initialize values
    public AddTwoDigits(int a, int b)
    {
        num1 = a;
        num2 = b;
    }

    // Method to add the two numbers
    public int Add()
    {
        return num1 + num2;
    }

    static void Main()
    {
        int input1, input2;

        Console.Write("Enter first number: ");
        while (!int.TryParse(Console.ReadLine(), out input1))
        {
            Console.Write("Invalid input. Please enter a valid number: ");
        }

        Console.Write("Enter second number: ");
        while (!int.TryParse(Console.ReadLine(), out input2))
        {
            Console.Write("Invalid input. Please enter a valid number: ");
        }

        AddTwoDigits obj = new AddTwoDigits(input1, input2);
        Console.WriteLine("The sum is: " + obj.Add());

        Console.ReadLine(); // Keep console window open
        Console.ReadKey();
    }
}
