namespace FareCalculator.Core.Models
{
    public class UberVip : PassengerCar
    {
        public override int Passengers { get; set; } = 1;
        public override decimal BaseFare => 10.00m;
        public override decimal RatePerKm => 1.50m;
    }
}
