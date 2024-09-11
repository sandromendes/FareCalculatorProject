using FareCalculator.Core.Models;

namespace FareCalculator.Core.Services.FareCalculators.Interfaces
{
    public interface IFareCalculatorStrategy
    {
        decimal CalculateFare(Vehicle vehicle, int distance, decimal weight = 0, decimal dimension = 0);
    }
}
