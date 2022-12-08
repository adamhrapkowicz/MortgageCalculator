public class MortgageCalculator
{
    internal object CalculateCost(double price, double annualIntrest, double numberOfYears)
    {
        double cost = 0;
        var remainingAmount = price;
        var monthlyIntrest = annualIntrest / 100 /12;
        var numberOfMonths = numberOfYears * 12;
        var monthlyPayment = price / numberOfMonths;

        for (var i = 0; i < numberOfMonths; i++)
        {
            cost += remainingAmount * monthlyIntrest;
            remainingAmount -= monthlyPayment;
        }
        return cost;
    }
}