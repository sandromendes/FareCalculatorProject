namespace FareCalculator.Core.Models
{
    public class UberBlack : PassengerCar
    {
        public override int Passengers { get; set; } = 1;
        public override decimal BaseFare => 15.00m;
        public override decimal RatePerKm => 2.00m;
    }
}
