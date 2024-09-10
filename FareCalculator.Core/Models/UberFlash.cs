namespace FareCalculator.Core.Models
{
    public class UberFlash : Car
    {
        public decimal Weight { get; set; }
        public decimal Dimension { get; set; }
        public override decimal BaseFare => 8.00m;
        public override decimal RatePerKm => 2.00m;
    }
}
