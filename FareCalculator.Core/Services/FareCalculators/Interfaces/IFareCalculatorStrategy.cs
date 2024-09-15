using FareCalculator.Core.Models;

namespace FareCalculator.Core.Services.FareCalculators.Interfaces
{
    public interface IFareCalculatorStrategy
    {
        decimal CalculateFare(UberRideBase uberRide, int distance, decimal weight = 0, decimal dimension = 0);
    }
}
