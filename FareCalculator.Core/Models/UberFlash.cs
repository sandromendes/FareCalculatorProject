namespace FareCalculator.Core.Models
{
    public class UberFlash : Car
    {
        public decimal Weight { get; set; }
        public decimal Dimension { get; set; }
        public override decimal BaseFare => 8.00m;
        public override decimal RatePerKm => 2.00m;

        public override decimal CalculateFare(int distance, decimal weight = 0, decimal dimension = 0)
        {
            return weight > 10 || dimension > 1 ? BaseFare + 1.50m * distance : BaseFare + 1.00m * distance;
        }
    }
}
