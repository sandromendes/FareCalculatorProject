using FareCalculator.Core.Models;
using FareCalculator.Core.Services.FareCalculators.Interfaces;

namespace FareCalculator.Core.Services.FareCalculators
{
    public class UberXFareCalculatorStrategy : IFareCalculatorStrategy
    {
        public decimal CalculateFare(UberRideBase uberRide, int distance, decimal weight = 0, decimal dimension = 0)
        {
            var uberX = uberRide as UberX;
            decimal fare = uberX.BaseFare + uberX.RatePerKm * distance;

            if (uberX.Passengers == 1)
                return fare;
            else if (uberX.Passengers == 2)
                return fare - 0.50m;
            else
                return fare - 1.00m;
        }
    }

}
