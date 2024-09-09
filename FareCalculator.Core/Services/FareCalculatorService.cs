using FareCalculator.Core.Enums;
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

            decimal fare;

            if (vehicle.Type == UberType.UberX)
            {
                if (vehicle.Passengers == 0)
                    fare = 5.00m + 0.50m * distance;
                else if (vehicle.Passengers == 1)
                    fare = 5.00m + 1.00m * distance;
                else if (vehicle.Passengers == 2)
                    fare = 5.00m - 0.50m + 1.00m * distance;
                else
                    fare = 5.00m - 1.00m + 1.00m * distance;
            }
            else if (vehicle.Type == UberType.UberVIP)
            {
                if (vehicle.Passengers == 0)
                    fare = 10.00m + 0.75m * distance;
                else if (vehicle.Passengers == 1)
                    fare = 10.00m + 1.50m * distance;
                else if (vehicle.Passengers == 2)
                    fare = 10.00m - 0.50m + 1.50m * distance;
                else
                    fare = 10.00m - 1.00m + 1.50m * distance;
            }
            else if (vehicle.Type == UberType.UberBlack)
            {
                if (vehicle.Passengers == 0)
                    fare = 15.00m + 1.00m * distance;
                else if (vehicle.Passengers == 1)
                    fare = 15.00m + 2.00m * distance;
                else if (vehicle.Passengers == 2)
                    fare = 15.00m - 1.00m + 2.00m * distance;
                else
                    fare = 15.00m - 2.00m + 2.00m * distance;
            }
            else if (vehicle.Type == UberType.UberMoto)
            {
                fare = 3.00m + 0.50m * distance;
            }
            else if (vehicle.Type == UberType.Flash)
            {
                if (weight > 10)
                    fare = 4.00m + 1.00m * distance;
                else
                    fare = 4.00m + 0.50m * distance;
            }
            else if (vehicle.Type == UberType.FlashMoto)
            {
                if (weight > 20 || dimension > 1)
                    fare = 8.00m + 1.50m * distance;
                else
                    fare = 8.00m + 1.00m * distance;
            }
            else
            {
                throw new ArgumentException("Not a known vehicle type", nameof(vehicle));
            }

            return fare;
        }
    }
}
