using FareCalculator.Core.Enums;
using FareCalculator.Core.Services.Interfaces;
using PCLMock;
using System.Threading.Tasks;

namespace FareCalculator.Tests.Mocks
{
    public class DistanceCalculatorServiceMock : MockBase<IDistanceCalculatorService>, IDistanceCalculatorService
    {
        public DistanceCalculatorServiceMock(MockBehavior behavior = MockBehavior.Loose)
            : base(behavior)
        {
        }

        public Task<int> CalculateDistanceAsync(CityTypes origin, CityTypes destination)
        {
            return this.Apply(x => x.CalculateDistanceAsync(origin, destination));
        }
    }
}
