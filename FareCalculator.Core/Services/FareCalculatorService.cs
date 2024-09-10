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

            switch (vehicle)
            {
                case UberX uberX:
                    fare = CalculateUberXFare(uberX, distance);
                    break;

                case UberVip uberVIP:
                    fare = CalculateUberVIPFare(uberVIP, distance);
                    break;

                case UberBlack uberBlack:
                    fare = CalculateUberBlackFare(uberBlack, distance);
                    break;

                case UberMoto uberMoto:
                    fare = CalculateUberMotoFare(uberMoto, distance);
                    break;

                case FlashMoto flashMoto:
                    fare = CalculateFlashMotoFare(flashMoto, distance, weight);
                    break;

                case UberFlash uberFlash:
                    fare = CalculateUberFlashFare(uberFlash, distance, weight, dimension);
                    break;

                default:
                    throw new ArgumentException("Not a known vehicle type", nameof(vehicle));
            }

            return fare;
        }

        private decimal CalculateUberXFare(UberX uberX, int distance)
        {
            decimal fare = uberX.BaseFare + uberX.RatePerKm * distance;

            if (uberX.Passengers == 1)
                return fare;
            else if (uberX.Passengers == 2)
                return fare - 0.50m;
            else
                return fare - 1.00m;
        }

        private decimal CalculateUberVIPFare(UberVip uberVIP, int distance)
        {
            decimal fare = uberVIP.BaseFare + uberVIP.RatePerKm * distance;

            if (uberVIP.Passengers == 1)
                return fare;
            else if (uberVIP.Passengers == 2)
                return fare - 0.50m;
            else
                return fare - 1.00m;
        }

        private decimal CalculateUberBlackFare(UberBlack uberBlack, int distance)
        {
            decimal fare = uberBlack.BaseFare + uberBlack.RatePerKm * distance;

            if (uberBlack.Passengers == 1)
                return fare;
            else if (uberBlack.Passengers == 2)
                return fare - 1.00m;
            else
                return fare - 2.00m;
        }

        private decimal CalculateUberMotoFare(UberMoto uberMoto, int distance)
        {
            return uberMoto.BaseFare + uberMoto.RatePerKm * distance;
        }

        private decimal CalculateFlashMotoFare(FlashMoto flashMoto, int distance, decimal weight)
        {
            return weight > 20 ? flashMoto.BaseFare + 1.50m * distance : flashMoto.BaseFare + 1.00m * distance;
        }

        private decimal CalculateUberFlashFare(UberFlash uberFlash, int distance, decimal weight, decimal dimension)
        {
            return weight > 10 || dimension > 1 ? uberFlash.BaseFare + 1.50m * distance : uberFlash.BaseFare + 1.00m * distance;
        }
    }
}
