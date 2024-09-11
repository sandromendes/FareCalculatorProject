using FareCalculator.Core.Models;
using FareCalculator.Core.Services.FareCalculators.Interfaces;

namespace FareCalculator.Core.Services.FareCalculators
{
    public class UberMotoFareCalculatorStrategy : IFareCalculatorStrategy
    {
        public decimal CalculateFare(Vehicle vehicle, int distance, decimal weight = 0, decimal dimension = 0)
        {
            var uberMoto = (UberMoto)vehicle;
            return uberMoto.BaseFare + uberMoto.RatePerKm * distance;
        }
    }

}
