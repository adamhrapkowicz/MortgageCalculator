using System;

public class Program
{
    public static void Main(string[] args)
    {
        var price = GetValidatedPriceFromUser();
        var annualIntrest = GetAnnualIntrestFromUser();
        var numberOfYears = GetNumberOfYearsFromUsersValidated();

        var mortgageCalculator = new MortgageCalculator();
        var cost = mortgageCalculator.CalculateCost(price, annualIntrest, numberOfYears);
        Console.WriteLine($"The cost of your mortgage is £{cost:N2} on top of what you borrow.");
    }

    private static double GetValidatedPriceFromUser()
    {
        double price = 0;

        while (price < 10000)
        {
            price = GetPriceFromUser();
            if (price <= 10000)
                Console.WriteLine($"The minimum value of mortgage is £10000");
        }

        return price;
    }

    private static double GetNumberOfYearsFromUsersValidated()
    {
        double numberOfYears;
        do
        {
            numberOfYears = GetNumberOfYearsFromUsers();
            if (numberOfYears < 1 || numberOfYears > 30)
            {
                Console.WriteLine($"The lenght of mortgage must be between 1 and 30 years");
            }
        } while (numberOfYears < 1 || numberOfYears > 30);
        return numberOfYears;
    }

    private static bool IsWithinAllowedRange(double annualIntrest)
    {
        if (annualIntrest > 0.01 && annualIntrest < 50)
        {
            return true;
        }

        Console.WriteLine($"The intrest rate must be between 0.01 and 50%");
        return false;
    }

    static double GetNumberOfYearsFromUsers()
    {
        return GetDoubleFromUser("Enter the lenght of your mortgage in years.");
    }

    static double GetAnnualIntrestFromUser()
    {
        var validInput = false;
        double annualIntrest = 0.0;
        while (!validInput)
        {
            Console.WriteLine("Enter the intrest rate in %.");

            var input = Console.ReadLine();
            validInput =
                double.TryParse(input, out annualIntrest)
                && IsWithinAllowedRange(annualIntrest);
        }

        return annualIntrest;
    }

    static double GetPriceFromUser()
    {
        return GetDoubleFromUser("Enter the price of the house in £.");
    }

    static double GetDoubleFromUser(string messageForUser)
    {
        var validInput = false;
        double result = 0.0;
        while (!validInput)
        {
            Console.WriteLine(messageForUser);
            var input = Console.ReadLine();
            validInput = double.TryParse(input, out result);
        }
        return result;
    }
}