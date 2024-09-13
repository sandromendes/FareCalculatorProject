using FareCalculator.Core.Models;
using FareCalculator.Core.Services.Interfaces;
using PCLMock;

namespace FareCalculator.Tests.Mocks
{
    public class FareCalculatorServiceMock : MockBase<IFareCalculatorService>, IFareCalculatorService
    {
        public FareCalculatorServiceMock(MockBehavior behavior = MockBehavior.Loose)
            : base(behavior)
        {
        }

        public decimal CalculateFare(UberRideBase vehicle, int distance, decimal weight, decimal volume)
        {
            return this.Apply(x => x.CalculateFare(vehicle, distance, weight, volume));
        }
    }
}
