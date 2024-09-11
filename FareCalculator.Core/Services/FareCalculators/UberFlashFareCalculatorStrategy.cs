using FareCalculator.Core.Models;
using FareCalculator.Core.Services.FareCalculators.Interfaces;

namespace FareCalculator.Core.Services.FareCalculators
{
    public class UberFlashFareCalculatorStrategy : IFareCalculatorStrategy
    {
        public decimal CalculateFare(Vehicle vehicle, int distance, decimal weight = 0, decimal dimension = 0)
        {
            var uberFlash = (UberFlash)vehicle;
            decimal fare = uberFlash.BaseFare + uberFlash.RatePerKm * distance;

            if (weight > 10)
                fare += 2.00m;

            if (dimension > 1.0m)
                fare += 1.50m;

            return fare;
        }
    }

}
