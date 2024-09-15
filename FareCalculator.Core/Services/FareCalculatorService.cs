using FareCalculator.Core.Enums;
using FareCalculator.Core.Models;
using FareCalculator.Core.Services.FareCalculators;
using FareCalculator.Core.Services.FareCalculators.Interfaces;
using FareCalculator.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace FareCalculator.Core.Services
{
    public class FareCalculatorService : IFareCalculatorService
    {
        private readonly Dictionary<Type, IFareCalculatorStrategy> _strategies;

        public FareCalculatorService()
        {
            _strategies = new Dictionary<Type, IFareCalculatorStrategy>
            {
                { typeof(UberX), new UberXFareCalculatorStrategy() },
                { typeof(UberVip), new UberVipFareCalculatorStrategy() },
                { typeof(UberBlack), new UberBlackFareCalculatorStrategy() },
                { typeof(UberMoto), new UberMotoFareCalculatorStrategy() },
                { typeof(UberFlash), new UberFlashFareCalculatorStrategy() },
                { typeof(UberFlashMoto), new UberFlashMotoFareCalculatorStrategy() }
            };
        }

        public decimal CalculateFare(UberRideBase uberRide, int distance, decimal weight = 0, decimal dimension = 0)
        {
            if (uberRide == null)
            {
                throw new ArgumentNullException(nameof(uberRide));
            }

            if (_strategies.TryGetValue(uberRide.GetType(), out var strategy))
            {
                return strategy.CalculateFare(uberRide, distance, weight, dimension);
            }

            throw new ArgumentException("Invalid vehicle type.");
        }
    }
}
