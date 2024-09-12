using FareCalculator.Core.Models;
using FareCalculator.Core.Services.Interfaces;
using System;

namespace FareCalculator.Core.Services
{
    public class FareCalculatorService : IFareCalculatorService
    {
        public FareCalculatorService()
        {
        }

        public decimal CalculateFare(Vehicle vehicle, int distance, decimal weight = 0, decimal dimension = 0)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            return vehicle.CalculateFare(distance);
        }
    }
}
