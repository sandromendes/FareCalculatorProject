namespace FareCalculator.Core.Models
{
    public class UberBlack : PassengerCar
    {
        public override int Passengers { get; set; } = 1;
        public override decimal BaseFare => 15.00m;
        public override decimal RatePerKm => 2.00m;

        public override decimal CalculateFare(int distance, decimal weight = 0, decimal dimension = 0)
        {
            decimal fare = BaseFare + RatePerKm * distance;

            if (Passengers == 1)
                return fare;
            else if (Passengers == 2)
                return fare - 1.00m;
            else
                return fare - 2.00m;
        }
    }
}
