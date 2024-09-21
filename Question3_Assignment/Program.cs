using System;

class Program
{
    static void Main()
    {
        // le menu pour l'utilisateur
        Console.WriteLine("Welcome to Zanempilo's Volleyball Calculator");
        Console.WriteLine("Conceived by Amedee Nsongye");
        Console.WriteLine("1. Calculate Volleyball Weekends");
        Console.WriteLine("2. Exit");
        Console.Write("Please select an option: ");

        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                CalculateVolleyballWeekends();
                break;
            case 2:
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid option. Please restart the program and select a valid option.");
                break;
        }
    }

    static void CalculateVolleyballWeekends()
    {
        int totalWeekends = 48;
        double weekendsNotWorking = 0.75 * totalWeekends;
        double weekendsInDurban = weekendsNotWorking;

        Console.Write("Enter the number of times Zanempilo travels to his hometown (h): ");
        int h = int.Parse(Console.ReadLine());

        Console.Write("Is it a leap year? (yes/no): ");
        string isLeapYearInput = Console.ReadLine().ToLower();
        bool isLeapYear = isLeapYearInput == "yes";

        double weekendsPlayingInDurban = weekendsInDurban - h;

        if (isLeapYear)
        {
            weekendsPlayingInDurban *= 1.20; // Increase by 20%
        }

        double volleyballWeekends = weekendsPlayingInDurban;

        Console.WriteLine($"Zanempilo plays volleyball approximately {Math.Floor(volleyballWeekends)} times a year.");
    }
}























/*  int weekendsInYear = 48;


double leapYearIncrease = 0.20;

int regularYearSessions = weekendsInYear;

int additionalLeapYearSessions = (int)(weekendsInYear * leapYearIncrease);

int leapYearSessions = regularYearSessions + additionalLeapYearSessions;

// Output the results
Console.WriteLine("Volleyball sessions in a regular year: " + regularYearSessions);
Console.WriteLine("Volleyball sessions in a leap year: " + leapYearSessions);
*/
