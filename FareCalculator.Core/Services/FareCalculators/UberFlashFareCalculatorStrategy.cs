using FareCalculator.Core.Models;
using FareCalculator.Core.Services.FareCalculators.Interfaces;

namespace FareCalculator.Core.Services.FareCalculators
{
    public class UberFlashFareCalculatorStrategy : IFareCalculatorStrategy
    {
        public decimal CalculateFare(UberRideBase uberRide, int distance, decimal weight = 0, decimal dimension = 0)
        {
            var uberFlash = (UberFlash)uberRide;

            if (weight > 10 || dimension > 1)
                return uberFlash.BaseFare + uberFlash.RatePerKm * distance;
            else
                return uberFlash.BaseFare + distance;
        }
    }

}
