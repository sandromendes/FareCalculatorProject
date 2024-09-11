using FareCalculator.Core.Models;
using FareCalculator.Core.Services.FareCalculators.Interfaces;

namespace FareCalculator.Core.Services.FareCalculators
{
    public class UberVipFareCalculatorStrategy : IFareCalculatorStrategy
    {
        public decimal CalculateFare(Vehicle vehicle, int distance, decimal weight = 0, decimal dimension = 0)
        {
            var uberVIP = (UberVip)vehicle;
            var fare = uberVIP.BaseFare + uberVIP.RatePerKm * distance;

            if (uberVIP.Passengers == 1)
                return fare;
            else if (uberVIP.Passengers == 2)
                return fare - 0.50m;
            else
                return fare - 1.00m;
        }
    }

}
