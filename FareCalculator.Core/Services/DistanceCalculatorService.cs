using FareCalculator.Core.Enums;
using FareCalculator.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FareCalculator.Core.Services
{
    public class DistanceCalculatorService : IDistanceCalculatorService
    {
        private static Dictionary<CityTypes, Dictionary<CityTypes, int>> _distances = 
            new Dictionary<CityTypes, Dictionary<CityTypes, int>>
        {
            {
                CityTypes.RECIFE, new Dictionary<CityTypes, int>
                {
                    { CityTypes.RECIFE, 0 },
                    { CityTypes.OLINDA, 8 },
                    { CityTypes.JABOATAO_DOS_GUARARAPES, 17 },
                    { CityTypes.PAULISTA, 12 },
                    { CityTypes.CABO_DE_SANTO_AGOSTINHO, 30 },
                    { CityTypes.IGARASSU, 23 },
                    { CityTypes.ABREU_E_LIMA, 24 },
                    { CityTypes.SAO_LOURENCO_DA_MATA, 16 },
                    { CityTypes.MORENO, 26 },
                    { CityTypes.ITAMARACA, 48 },
                    { CityTypes.ARACOIABA, 40 }
                }
            },
            {
                CityTypes.OLINDA, new Dictionary<CityTypes, int>
                {
                    { CityTypes.RECIFE, 8 },
                    { CityTypes.OLINDA, 0 },
                    { CityTypes.JABOATAO_DOS_GUARARAPES, 17 },
                    { CityTypes.PAULISTA, 10 },
                    { CityTypes.CABO_DE_SANTO_AGOSTINHO, 28 },
                    { CityTypes.IGARASSU, 21 },
                    { CityTypes.ABREU_E_LIMA, 22 },
                    { CityTypes.SAO_LOURENCO_DA_MATA, 14 },
                    { CityTypes.MORENO, 25 },
                    { CityTypes.ITAMARACA, 46 },
                    { CityTypes.ARACOIABA, 38 }
                }
            },
            {
                CityTypes.JABOATAO_DOS_GUARARAPES, new Dictionary<CityTypes, int>
                {
                    { CityTypes.RECIFE, 17 },
                    { CityTypes.OLINDA, 17 },
                    { CityTypes.JABOATAO_DOS_GUARARAPES, 0 },
                    { CityTypes.PAULISTA, 20 },
                    { CityTypes.CABO_DE_SANTO_AGOSTINHO, 15 },
                    { CityTypes.IGARASSU, 13 },
                    { CityTypes.ABREU_E_LIMA, 15 },
                    { CityTypes.SAO_LOURENCO_DA_MATA, 9 },
                    { CityTypes.MORENO, 15 },
                    { CityTypes.ITAMARACA, 35 },
                    { CityTypes.ARACOIABA, 28 }
                }
            },
            {
                CityTypes.PAULISTA, new Dictionary<CityTypes, int>
                {
                    { CityTypes.RECIFE, 12 },
                    { CityTypes.OLINDA, 10 },
                    { CityTypes.JABOATAO_DOS_GUARARAPES, 20 },
                    { CityTypes.PAULISTA, 0 },
                    { CityTypes.CABO_DE_SANTO_AGOSTINHO, 18 },
                    { CityTypes.IGARASSU, 24 },
                    { CityTypes.ABREU_E_LIMA, 20 },
                    { CityTypes.SAO_LOURENCO_DA_MATA, 15 },
                    { CityTypes.MORENO, 28 },
                    { CityTypes.ITAMARACA, 39 },
                    { CityTypes.ARACOIABA, 33 }
                }
            },
            {
                CityTypes.CABO_DE_SANTO_AGOSTINHO, new Dictionary<CityTypes, int>
                {
                    { CityTypes.RECIFE, 30 },
                    { CityTypes.OLINDA, 28 },
                    { CityTypes.JABOATAO_DOS_GUARARAPES, 15 },
                    { CityTypes.PAULISTA, 18 },
                    { CityTypes.CABO_DE_SANTO_AGOSTINHO, 0 },
                    { CityTypes.IGARASSU, 35 },
                    { CityTypes.ABREU_E_LIMA, 32 },
                    { CityTypes.SAO_LOURENCO_DA_MATA, 20 },
                    { CityTypes.MORENO, 40 },
                    { CityTypes.ITAMARACA, 12 },
                    { CityTypes.ARACOIABA, 29 }
                }
            },
            {
                CityTypes.IGARASSU, new Dictionary<CityTypes, int>
                {
                    { CityTypes.RECIFE, 23 },
                    { CityTypes.OLINDA, 21 },
                    { CityTypes.JABOATAO_DOS_GUARARAPES, 13 },
                    { CityTypes.PAULISTA, 24 },
                    { CityTypes.CABO_DE_SANTO_AGOSTINHO, 35 },
                    { CityTypes.IGARASSU, 0 },
                    { CityTypes.ABREU_E_LIMA, 11 },
                    { CityTypes.SAO_LOURENCO_DA_MATA, 12 },
                    { CityTypes.MORENO, 20 },
                    { CityTypes.ITAMARACA, 32 },
                    { CityTypes.ARACOIABA, 25 }
                }
            },
            {
                CityTypes.ABREU_E_LIMA, new Dictionary<CityTypes, int>
                {
                    { CityTypes.RECIFE, 24 },
                    { CityTypes.OLINDA, 22 },
                    { CityTypes.JABOATAO_DOS_GUARARAPES, 15 },
                    { CityTypes.PAULISTA, 20 },
                    { CityTypes.CABO_DE_SANTO_AGOSTINHO, 32 },
                    { CityTypes.IGARASSU, 11 },
                    { CityTypes.ABREU_E_LIMA, 0 },
                    { CityTypes.SAO_LOURENCO_DA_MATA, 14 },
                    { CityTypes.MORENO, 22 },
                    { CityTypes.ITAMARACA, 33 },
                    { CityTypes.ARACOIABA, 28 }
                }
            },
            {
                CityTypes.SAO_LOURENCO_DA_MATA, new Dictionary<CityTypes, int>
                {
                    { CityTypes.RECIFE, 16 },
                    { CityTypes.OLINDA, 14 },
                    { CityTypes.JABOATAO_DOS_GUARARAPES, 9 },
                    { CityTypes.PAULISTA, 15 },
                    { CityTypes.CABO_DE_SANTO_AGOSTINHO, 20 },
                    { CityTypes.IGARASSU, 12 },
                    { CityTypes.ABREU_E_LIMA, 14 },
                    { CityTypes.SAO_LOURENCO_DA_MATA, 0 },
                    { CityTypes.MORENO, 20 },
                    { CityTypes.ITAMARACA, 28 },
                    { CityTypes.ARACOIABA, 24 }
                }
            },
            {
                CityTypes.MORENO, new Dictionary<CityTypes, int>
                {
                    { CityTypes.RECIFE, 26 },
                    { CityTypes.OLINDA, 25 },
                    { CityTypes.JABOATAO_DOS_GUARARAPES, 15 },
                    { CityTypes.PAULISTA, 28 },
                    { CityTypes.CABO_DE_SANTO_AGOSTINHO, 40 },
                    { CityTypes.IGARASSU, 20 },
                    { CityTypes.ABREU_E_LIMA, 22 },
                    { CityTypes.SAO_LOURENCO_DA_MATA, 20 },
                    { CityTypes.MORENO, 0 },
                    { CityTypes.ITAMARACA, 35 },
                    { CityTypes.ARACOIABA, 30 }
                }
            },
            {
                CityTypes.ITAMARACA, new Dictionary<CityTypes, int>
                {
                    { CityTypes.RECIFE, 48 },
                    { CityTypes.OLINDA, 46 },
                    { CityTypes.JABOATAO_DOS_GUARARAPES, 35 },
                    { CityTypes.PAULISTA, 39 },
                    { CityTypes.CABO_DE_SANTO_AGOSTINHO, 12 },
                    { CityTypes.IGARASSU, 32 },
                    { CityTypes.ABREU_E_LIMA, 33 },
                    { CityTypes.SAO_LOURENCO_DA_MATA, 28 },
                    { CityTypes.MORENO, 35 },
                    { CityTypes.ITAMARACA, 0 },
                    { CityTypes.ARACOIABA, 15 }
                }
            },
            {
                CityTypes.ARACOIABA, new Dictionary<CityTypes, int>
                {
                    { CityTypes.RECIFE, 40 },
                    { CityTypes.OLINDA, 38 },
                    { CityTypes.JABOATAO_DOS_GUARARAPES, 28 },
                    { CityTypes.PAULISTA, 33 },
                    { CityTypes.CABO_DE_SANTO_AGOSTINHO, 29 },
                    { CityTypes.IGARASSU, 25 },
                    { CityTypes.ABREU_E_LIMA, 28 },
                    { CityTypes.SAO_LOURENCO_DA_MATA, 24 },
                    { CityTypes.MORENO, 30 },
                    { CityTypes.ITAMARACA, 15 },
                    { CityTypes.ARACOIABA, 0 }
                }
            }
        };

        public async Task<int> CalculateDistanceAsync(CityTypes origin, CityTypes destination)
        {
            if (_distances.TryGetValue(origin, out var destinations) && 
                    destinations.TryGetValue(destination, out var distance))
                {
                    return await Task.FromResult(distance);
                }

            if (_distances.TryGetValue(destination, out var reverseDestinations) &&
                reverseDestinations.TryGetValue(origin, out var reverseDistance))
                {
                    return reverseDistance;
                }

            throw new ArgumentException("Distance not available for the selected cities.");
        }
    }
}
