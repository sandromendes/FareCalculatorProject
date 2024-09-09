using System.Threading.Tasks;

namespace FareCalculator.Core.Services.Interfaces
{
    public interface IDistanceCalculatorService
    {
        Task<int> CalculateDistanceAsync(string startPoint, string endPoint);
    }
}
