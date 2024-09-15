namespace FareCalculator.Core.Models
{
    public class UberFlash : Car
    {
        public decimal Weight { get; set; }
        public decimal Dimension { get; set; }
        public override decimal BaseFare => 8.00m;
        public override decimal RatePerKm => 1.50m;

        public override decimal CalculateFare(int distance, decimal weight = 0, decimal dimension = 0)
        {
            if (weight > 10 || dimension > 1)
                return BaseFare + RatePerKm * distance;
            else
                return BaseFare + distance;
        }
    }
}
