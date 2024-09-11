using FareCalculator.Core.Models;
using FareCalculator.Core.Services.FareCalculators.Interfaces;

namespace FareCalculator.Core.Services.FareCalculators
{
    public class UberBlackFareCalculatorStrategy : IFareCalculatorStrategy
    {
        public decimal CalculateFare(Vehicle vehicle, int distance, decimal weight = 0, decimal dimension = 0)
        {
            var uberBlack = (UberBlack)vehicle;
            var fare = uberBlack.BaseFare + uberBlack.RatePerKm * distance;

            if (uberBlack.Passengers == 1)
                return fare;
            else if (uberBlack.Passengers == 2)
                return fare - 1.00m;
            else
                return fare - 2.00m;
        }
    }

}
