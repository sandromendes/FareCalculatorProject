using FareCalculator.Core.Enums;

namespace FareCalculator.Core.Models
{
    public class Vehicle
    {
        public UberType Type { get; set; }
        public int Passengers { get; set; } = 0;
        public decimal Weight { get; set; } = 0;
        public decimal Dimension { get; set; } = 0;
        public int Distance { get; set; } = 0;
    }
}
