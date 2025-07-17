using System;

namespace Lab2
{
    class ImmutableString
    {
        // Static method to run the example
        public static void Run()
        {
            // Declare and initialize a string
            string str1 = "Hello";

            // Assign str1 to str2 (both point to the same value initially)
            string str2 = str1;

            // Modify str1 by appending another string
            str1 += " World";  // This creates a new string and assigns it to str1

            // Output both strings
            Console.WriteLine("str1: " + str1);  // Output: Hello World
            Console.WriteLine("str2: " + str2);  // Output: Hello

            // str2 remains unchanged, proving that strings are immutable (cannot be changed once created)
        }
    }
}
