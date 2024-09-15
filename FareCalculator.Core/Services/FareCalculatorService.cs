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

        public decimal CalculateFare(UberRideBase uberRide, int distance, decimal weight = 0, decimal dimension = 0)
        {
            if (uberRide == null)
            {
                throw new ArgumentNullException(nameof(uberRide));
            }

            return uberRide.CalculateFare(distance);
        }
    }
}
