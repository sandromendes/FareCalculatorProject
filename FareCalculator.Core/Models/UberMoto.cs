namespace FareCalculator.Core.Models
{
    public class UberMoto : Motorcycle
    {
        public override decimal BaseFare => 3.00m;
        public override decimal RatePerKm => 0.75m;
    }
}
