using FareCalculator.Core.Models;
using FareCalculator.Core.Services.FareCalculators.Interfaces;

namespace FareCalculator.Core.Services.FareCalculators
{
    public class UberFlashMotoFareCalculatorStrategy : IFareCalculatorStrategy
    {
        public decimal CalculateFare(Vehicle vehicle, int distance, decimal weight = 0, decimal dimension = 0)
        {
            var uberFlashMoto = (UberFlashMoto)vehicle;
            decimal fare = uberFlashMoto.BaseFare + uberFlashMoto.RatePerKm * distance;

            if (weight > 10)
                fare += 1.00m;

            if (dimension > 0.5m)
                fare += 1.00m;

            return fare;
        }
    }

}
