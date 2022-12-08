
double price = 0.0;
double annualIntrest;
double numberOfYears;

while (price < 10000)
{
    price = GetPriceFromUser();
    if (price >= 10000)
        break;
    Console.WriteLine($"The minimum value of mortgage is £10000");
}

do
{
    annualIntrest = GetAnnualIntrestFromUser();
    if (annualIntrest < 0.01 || annualIntrest > 50)
    {
        Console.WriteLine($"The intrest rate must be between 0.01 and 50%");
    }
} while (annualIntrest < 0.01 || annualIntrest > 50);

do
{
    numberOfYears = GetNumberOfYearsFromUsers();
    if (numberOfYears < 1 || numberOfYears >30)
    {
        Console.WriteLine($"The lenght of mortgage must be between 1 and 30 years");
    }
} while (numberOfYears < 1 || numberOfYears >30);

var mortgageCalculator = new MortgageCalculator();

var cost = mortgageCalculator.CalculateCost(price, annualIntrest,numberOfYears);

Console.WriteLine($"The cost of your mortgage is £{cost:N2} on top of what you borrow.");

double GetNumberOfYearsFromUsers()
{
    return GetDoubleFromUser("Enter the lenght of your mortgage in years.");
}

double GetAnnualIntrestFromUser()
{
    return GetDoubleFromUser("Enter the intrest rate in %.");
}

double GetPriceFromUser()
{
    return GetDoubleFromUser("Enter the price of the house in £.");
}

double GetDoubleFromUser(string messageForUser)
{
    var validInput = false;
    double result = 0.0;
    while(!validInput)
    {
        Console.WriteLine(messageForUser);
        var input = Console.ReadLine();
        validInput = double.TryParse(input, out result);
    }
    return result;
}