using FareCalculator.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace FareCalculator.Core.Services
{
    public class DistanceCalculatorService : IDistanceCalculatorService
    {
        public async Task<int> CalculateDistanceAsync(string startPoint, string endPoint)
        {
            await Task.Delay(1000);

            Random random = new Random();
            return random.Next(1, 50); // REturns distance between 1 to 50 km
        }
    }

}
