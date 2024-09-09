using FareCalculator.Core.Enums;
using System.Threading.Tasks;

namespace FareCalculator.Core.Services.Interfaces
{
    public interface IDistanceCalculatorService
    {
        Task<int> CalculateDistanceAsync(CityTypes origin, CityTypes destination);
    }
}
