using System;

// Interface 1
interface ILength
{
    int Length { get; set; }
}

// Interface 2
interface IBreadth
{
    int Breadth { get; set; }
}

// Class implements both interfaces
class Rectangle : ILength, IBreadth
{
    public int Length { get; set; }
    public int Breadth { get; set; }

    public int Area()
    {
        return Length * Breadth;
    }

    static void Main()
    {
        Rectangle r = new Rectangle();
        r.Length = 5;
        r.Breadth = 4;

        Console.WriteLine("Area = " + r.Area());
        Console.ReadLine(); // Keep console window open
    }
}
