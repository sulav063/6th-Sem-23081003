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
        // Ask user to enter two numbers
        Console.Write("Enter first number: ");
        int input1 = int.Parse(Console.ReadLine());  // Convert input to integer

        Console.Write("Enter second number: ");
        int input2 = int.Parse(Console.ReadLine());  // Convert input to integer

        // Create an object and pass values to constructor
        AddTwoDigits obj = new AddTwoDigits(input1, input2);

        // Call the Add method and display result
        Console.WriteLine("The sum is: " + obj.Add());

        Console.ReadLine(); // To keep the console window open
    }
}
