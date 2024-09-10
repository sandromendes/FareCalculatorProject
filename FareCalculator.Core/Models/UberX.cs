namespace FareCalculator.Core.Models
{
    public class UberX : PassengerCar
    {
        public override int Passengers { get ; set; } = 1;
        public override decimal BaseFare => 5.00m;
        public override decimal RatePerKm => 0.50m;
    }
}
