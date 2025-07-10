using System;

class ReverseArray
{
    static void Main()
    {
        int[] arr;

        while (true)
        {
            Console.Write("Enter array elements: ");
            string inputLine = Console.ReadLine();

            // Correct Split usage with options
            string[] tokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            arr = new int[tokens.Length];
            bool valid = true;

            for (int i = 0; i < tokens.Length; i++)
            {
                if (int.TryParse(tokens[i], out int num))
                {
                    arr[i] = num;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    valid = false;
                    break;
                }
            }

            if (valid)
                break; // Exit the input loop if all inputs were valid
        }

        // Display original array
        Console.WriteLine("\nOriginal array:");
        foreach (int i in arr)
            Console.Write(i + " ");

        // Reverse the array
        Array.Reverse(arr);

        // Display reversed array
        Console.WriteLine("\nReversed array:");
        foreach (int i in arr)
            Console.Write(i + " ");

        Console.ReadLine(); // Optional
    }
}
