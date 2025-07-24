using System;

// Define interface
interface Calculator
{
    void Add(int a, int b);
    void Subtract(int a, int b);
    void Multiply(int a, int b);
    void Divide(int a, int b);
}

class SimpleCalculator : Calculator
{
    // Implement Add method
    public void Add(int a, int b)
    {
        Console.WriteLine($"Addition: {a + b}");
    }
    // Implement Subtract method
    public void Subtract(int a, int b)
    {
        Console.WriteLine($"Subtraction: {a - b}");
    }
    // Implement Multiply method
    public void Multiply(int a, int b)
    {
        Console.WriteLine($"Multiplication: {a * b}");
    }
    // Implement Divide method
    public void Divide(int a, int b)
    {
        if (b != 0)
            Console.WriteLine($"Division: {a / (double)b}");
        else
            Console.WriteLine("Cannot divide by zero.");
    }
    // Static method to run the example
    public static void Run()
    {
        SimpleCalculator calc = new SimpleCalculator();
        calc.Add(10, 5);
        calc.Subtract(10, 5);
        calc.Multiply(10, 5);
        calc.Divide(10, 5);
        calc.Divide(10, 0); // Test division by zero
        Console.ReadLine();
    }
}