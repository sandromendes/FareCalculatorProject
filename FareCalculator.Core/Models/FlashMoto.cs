namespace FareCalculator.Core.Models
{
    public class FlashMoto : Motorcycle
    {
        public decimal Weight { get; set; }
        public override decimal BaseFare => 4.00m;
        public override decimal RatePerKm => 1.00m;
    }
}
