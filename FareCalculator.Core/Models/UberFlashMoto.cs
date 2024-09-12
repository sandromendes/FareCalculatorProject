namespace FareCalculator.Core.Models
{
    public class UberFlashMoto : Motorcycle
    {
        public decimal Weight { get; set; }
        public override decimal BaseFare => 4.00m;
        public override decimal RatePerKm => 1.00m;

        public override decimal CalculateFare(int distance, decimal weight = 0, decimal dimension = 0)
        {
            return weight > 20 ? BaseFare + 1.50m * distance : BaseFare + 1.00m * distance;
        }
    }
}
