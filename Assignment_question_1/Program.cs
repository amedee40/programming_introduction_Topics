using System;

abstract class Expense
{
    public abstract double CalculateExpense();
}

class FuelExpense : Expense
{
    public double Amount { get; set; }

    public override double CalculateExpense() => Amount;
}

class InsuranceExpense : Expense
{
    public double Amount { get; set; }

    public override double CalculateExpense() => Amount;
}

class ParkingExpense : Expense
{
    public double Amount { get; set; }

    public override double CalculateExpense() => Amount;
}

class MaintenanceExpense : Expense
{
    public double Amount { get; set; }

    public override double CalculateExpense() => Amount;
}

class MotorVehicleLoan : Expense
{
    public double PurchasePrice { get; set; }
    public double Deposit { get; set; }
    public double InterestRate { get; set; }
    public int RepaymentMonths { get; set; }

    public override double CalculateExpense()
    {
        double principal = PurchasePrice - Deposit;
        double monthlyInterestRate = InterestRate / 100 / 12;
        double monthlyRepayment = principal * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, RepaymentMonths)) /
                                  (Math.Pow(1 + monthlyInterestRate, RepaymentMonths) - 1);
        return monthlyRepayment;
    }
}

class Program
{
    static void Main(string[] args)
    {
        double grossIncome = 0, taxDeductions = 0, netIncome = 0, remainingIncome = 0;
        Expense[] expenses = new Expense[4];

        bool isRunning = true;

        while (isRunning)
        {
            // Display menu options
            Console.WriteLine("\n--- Motor Vehicle Expense Application ---");
            Console.WriteLine("1. Enter Income Details");
            Console.WriteLine("2. Enter Motor Vehicle Expenses (Fuel, Insurance, Parking, Maintenance)");
            Console.WriteLine("3. Buy or Hire a Motor Vehicle");
            Console.WriteLine("4. Display Results");
            Console.WriteLine("5. Exit");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Select an option (1-5):");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    // Here for Input gross income and for tax deductions
                    // Hope i will remember to convert to a double so i won't have an exception string to double
                    Console.WriteLine("Enter your gross monthly income:");
                    grossIncome = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter your monthly tax deductions:");
                    taxDeductions = Convert.ToDouble(Console.ReadLine());

                    netIncome = grossIncome - taxDeductions;
                    Console.WriteLine($"Net Income calculated: {netIncome}");
                    break;

                case 2:
                    //let me Input expenses (fuel, insurance, parking, maintenance)
                    // my main focus on syntax error
                    Console.WriteLine("Enter your monthly fuel cost:");
                    expenses[0] = new FuelExpense { Amount = Convert.ToDouble(Console.ReadLine()) };

                    Console.WriteLine("Enter your monthly insurance cost:");
                    expenses[1] = new InsuranceExpense { Amount = Convert.ToDouble(Console.ReadLine()) };

                    Console.WriteLine("Enter your monthly parking fees:");
                    expenses[2] = new ParkingExpense { Amount = Convert.ToDouble(Console.ReadLine()) };

                    Console.WriteLine("Enter your monthly maintenance cost:");
                    expenses[3] = new MaintenanceExpense { Amount = Convert.ToDouble(Console.ReadLine()) };
                    break;

                case 3:
                    // how to input a string in a switch case, do some reseach
                    // Buy or hire a motor vehicle
                    Console.WriteLine("Would you like to buy or hire a motor vehicle? (buy/hire)");
                    string choice = Console.ReadLine().ToLower();

                    if (choice == "hire")
                    {
                        Console.WriteLine("Enter the monthly hiring cost:");
                        double hiringCost = Convert.ToDouble(Console.ReadLine());

                        expenses[3] = new FuelExpense { Amount = hiringCost }; // Placeholder for hiring cost(Important to remember)

                        remainingIncome = netIncome - CalculateTotalExpenses(expenses);
                        Console.WriteLine($"Gross Income: {grossIncome}, Net Income: {netIncome}, Remaining after expenses: {remainingIncome}");
                    }
                    else if (choice == "buy")
                    {
                        Console.WriteLine("Enter the purchase price of the vehicle:");
                        double purchasePrice = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter the total deposit:");
                        double deposit = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter the interest rate (%):");
                        double interestRate = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter the number of months to repay (120-240):");
                        int repaymentMonths = Convert.ToInt32(Console.ReadLine());

                        MotorVehicleLoan loan = new MotorVehicleLoan
                        {
                            PurchasePrice = purchasePrice,
                            Deposit = deposit,
                            InterestRate = interestRate,
                            RepaymentMonths = repaymentMonths
                        };

                        double monthlyRepayment = loan.CalculateExpense();

                        if (monthlyRepayment > grossIncome / 3)
                        {
                            Console.WriteLine("Approval is unlikely as the loan exceeds one-third of your gross income.");
                        }

                        expenses[3] = loan; // Store the loan as an expense
                        remainingIncome = netIncome - CalculateTotalExpenses(expenses);
                        Console.WriteLine($"Gross Income: {grossIncome}, Net Income: {netIncome}, Remaining after expenses: {remainingIncome}");
                    }
                    break;

                case 4:
                    // Display gross income, net income, and remaining income after expenses{done as expected }
                    remainingIncome = netIncome - CalculateTotalExpenses(expenses);
                    Console.WriteLine($"Gross Income: {grossIncome}, Net Income: {netIncome}, Remaining after expenses: {remainingIncome}");
                    break;

                case 5:
                    // Exit the program
                    isRunning = false;
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static double CalculateTotalExpenses(Expense[] expenses)
    {
        double total = 0;
        foreach (var expense in expenses)
        {
            if (expense != null)
            {
                total += expense.CalculateExpense();
            }
        }
        return total;
    }
}
