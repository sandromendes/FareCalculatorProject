﻿namespace FareCalculator.Core.Models
{
    public abstract class UberRideBase
    {
        public abstract decimal BaseFare { get; }
        public abstract decimal RatePerKm { get; }
    }

    public abstract class PassengerCar : UberRideBase
    {
        public abstract int Passengers { get; set; }
    }

    public abstract class Car : UberRideBase { }

    public abstract class Motorcycle : UberRideBase { }
}
