using System;
using System.Threading;

class Program
{
    public delegate void TribonacciDelegate(int nthTerm);

    private static void nthTribonacci(int nthTerm)
    {
        int number1 = 0, number2 = 1, number3 = 1, nthNumber = 0;

        if (nthTerm == 0)
        {
            Console.WriteLine("Term #0: 0");
        }
        else if (nthTerm == 1 || nthTerm == 2)
        {
            Console.WriteLine("Term #1 and Term #2: 1");
        }
        else
        {
            for (int i = 0; i < nthTerm; i++)
            {
                Console.WriteLine("Term #" + i + ": " + number1);
                nthNumber = number1 + number2 + number3;
                number1 = number2;
                number2 = number3;
                number3 = nthNumber;
            }
        }
    }

    private static void TribonacciCallback(IAsyncResult ar)
    {
        TribonacciDelegate tribonacciDelegate = (TribonacciDelegate)ar.AsyncState;
        tribonacciDelegate.EndInvoke(ar);

        Console.WriteLine($"Tribonacci calculation finished.");
        Console.WriteLine($"Callback Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine($"Is Callback Thread from Thread Pool: {Thread.CurrentThread.IsThreadPoolThread}");
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Calculate Tribonacci number");
        Console.WriteLine("2. Instructions");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option: ");
    }

    static void ShowInstructions()
    {
        Console.WriteLine("\nInstructions:");
        Console.WriteLine("1. Choose 'Calculate Tribonacci number' to input the nth number.");
        Console.WriteLine("2. The program will calculate the Tribonacci number asynchronously.");
        Console.WriteLine("3. While the calculation is happening, the main thread will continue to display its Thread ID.");
        Console.WriteLine("4. You can exit by choosing the 'Exit' option.");
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    try
                    {
                        Console.WriteLine("Please enter a number to calculate the Tribonacci sequence: ");
                        int nthNumber = int.Parse(Console.ReadLine());

                        TribonacciDelegate tribonacciDelegate = new TribonacciDelegate(nthTribonacci);

                        
                        AsyncCallback callback = new AsyncCallback(TribonacciCallback);
                        IAsyncResult result = tribonacciDelegate.BeginInvoke(nthNumber, callback, tribonacciDelegate);

                        
                        while (!result.IsCompleted)
                        {
                            Console.WriteLine($"Main Thread ID: {Thread.CurrentThread.ManagedThreadId}");
                            Console.WriteLine($"Is Main Thread from Thread Pool: {Thread.CurrentThread.IsThreadPoolThread}");
                            Console.WriteLine("Main thread continuing to do work...");
                            Thread.Sleep(1000);  
                        }

                        Console.WriteLine("Main thread completed its work.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid number. Please try again.");
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;

                case "2":
                    ShowInstructions();
                    break;

                case "3":
                    exit = true;
                    Console.WriteLine("Exiting the program...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose 1, 2, or 3.");
                    break;
            }
        }
    }
}
