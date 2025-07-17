using System;

// Create a special error called LowBalanceException
class LowBalanceException : Exception
{
    public LowBalanceException(string message) : base(message)
    {
    }
}

class BalanceCheck
{
    public static void Run()
    {
        try
        {
            // Ask user to enter current balance
            Console.Write("Enter balance: ");
            int balance = int.Parse(Console.ReadLine());

            // Ask user to enter amount to withdraw
            Console.Write("Enter withdraw amount: ");
            int withdraw = int.Parse(Console.ReadLine());

            // If withdraw amount is more than balance, show error
            if (withdraw > balance)
            {
                throw new LowBalanceException("Not enough balance to withdraw.");
            }

            // Otherwise, print remaining balance
            Console.WriteLine("Remaining balance: " + (balance - withdraw));
        }
        catch (LowBalanceException ex)
        {
            // This runs if low balance error happens
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (FormatException)
        {
            // This runs if user enters invalid number
            Console.WriteLine("Please enter a valid number.");
        }
    }
}
