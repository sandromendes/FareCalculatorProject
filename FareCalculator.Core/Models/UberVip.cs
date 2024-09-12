namespace FareCalculator.Core.Models
{
    public class UberVip : PassengerCar
    {
        public override int Passengers { get; set; } = 1;
        public override decimal BaseFare => 10.00m;
        public override decimal RatePerKm => 1.50m;

        public override decimal CalculateFare(int distance, decimal weight = 0, decimal dimension = 0)
        {
            decimal fare = BaseFare + RatePerKm * distance;

            if (Passengers == 1)
                return fare;
            else if (Passengers == 2)
                return fare - 0.50m;
            else
                return fare - 1.00m;
        }
    }
}
