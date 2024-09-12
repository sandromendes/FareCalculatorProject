using FareCalculator.Core.Enums;

namespace FareCalculator.Core.Models
{
    public abstract class Vehicle
    {
        public abstract decimal BaseFare { get; }
        public abstract decimal RatePerKm { get; }
        public abstract decimal CalculateFare(int distance, decimal weight = 0, decimal dimension = 0);
    }

    public abstract class PassengerCar : Vehicle
    {
        public abstract int Passengers { get; set; }
    }

    public abstract class Car : Vehicle { }

    public abstract class Motorcycle : Vehicle 
    {
    }
}
