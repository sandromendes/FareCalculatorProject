using FareCalculator.Core.Models;

namespace FareCalculator.Core.Services.Interfaces
{
    public interface IFareCalculatorService
    {
        decimal CalculateFare(UberRideBase uberRide, int distance, decimal weight = 0, decimal dimension = 0);
    }
}
