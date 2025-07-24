using System;

delegate int AddDelegate(int a, int b);

class DelegateAdd
{
    // Method that matches the delegate signature
    public static int Add(int x, int y) => x + y;

    // Entry method to run the delegate example
    public static void Run()
    {
        // Assign the Add method to the delegate
        AddDelegate add = Add;

        // Take two numbers from the user
        Console.Write("Enter two numbers: ");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());

        // Call the delegate and print the sum
        Console.WriteLine("Sum: " + add(num1, num2));
        Console.ReadLine();
    }
}
