using FareCalculator.Core.Common;
using FareCalculator.Core.Enums;
using FareCalculator.Core.Models;
using FareCalculator.Core.Services;
using FareCalculator.Core.Services.Interfaces;
using FareCalculator.Tests.Mocks;
using FareCalculator.ViewModels.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCLMock;
using System.Threading.Tasks;

namespace FareCalculator.Tests
{
    [TestClass]
    public class FareCalculatorPageViewModelTests
    {
        private FareCalculatorPageViewModel _viewModel;

        private IFareCalculatorService _fareCalculatorService;

        private readonly FareCalculatorServiceMock _fareCalculatorServiceMock;
        private readonly DistanceCalculatorServiceMock _distanceCalculatorServiceMock;

        public FareCalculatorPageViewModelTests()
        {
            _fareCalculatorServiceMock = new FareCalculatorServiceMock(MockBehavior.Loose);
            _distanceCalculatorServiceMock = new DistanceCalculatorServiceMock(MockBehavior.Loose);
        }

        /// <summary>
        /// Cenário: Calcular tarifa para Uber X com distância entre Recife e Olinda.
        /// Dado que a opção de Uber selecionada é "UBER_X"
        /// E que a origem é "RECIFE" e o destino é "OLINDA"
        /// Quando o comando de calcular tarifa é executado
        /// Então a distância deve ser calculada como 10 km
        /// E a tarifa deve ser calculada corretamente como R$ 15,00
        /// </summary>
        [TestMethod]
        public async Task ExecuteCalculateFare_ShouldCalculateFare_ForUberX()
        {
            // Arrange
            _viewModel = new FareCalculatorPageViewModel(
                _fareCalculatorServiceMock,
                _distanceCalculatorServiceMock
            );

            _viewModel.SelectedUberOption = UberType.UBER_X.GetDescription();
            _viewModel.SelectedOrigin = CityTypes.RECIFE.GetDescription();
            _viewModel.SelectedDestination = CityTypes.OLINDA.GetDescription();
            _distanceCalculatorServiceMock
                .When(x => x.CalculateDistanceAsync(CityTypes.RECIFE, CityTypes.OLINDA))
                .Return(Task.FromResult(10)); // 10 km

            _fareCalculatorServiceMock
                .When(x => x.CalculateFare(It.IsAny<UberRideBase>(), 10, 0, 0))
                .Return(15); // Tarifa de R$ 15,00

            // Act
            _viewModel.ExecuteCalculateFare();

            // Assert
            Assert.AreEqual("Calculated Fare: R$ 15,00", _viewModel.FareResult);
            Assert.AreEqual("Calculated Distance: 10 km", _viewModel.DistanceResult);
        }

        /// <summary>
        /// Cenário: Calcular tarifa para Uber Flash com peso e dimensões válidos.
        /// Dado que a opção de Uber selecionada é "UBER_FLASH"
        /// E que a origem é "RECIFE" e o destino é "OLINDA"
        /// E que o peso é 5 kg e as dimensões são 10 x 10 x 10
        /// Quando o comando de calcular tarifa é executado
        /// Então a distância deve ser calculada como 10 km
        /// E a tarifa deve ser calculada corretamente como R$ 30,00
        /// </summary>
        [TestMethod]
        public async Task ExecuteCalculateFare_ShouldCalculateFare_ForUberFlash()
        {
            // Arrange
            _fareCalculatorService = new FareCalculatorService();

            _viewModel = new FareCalculatorPageViewModel(_fareCalculatorService, _distanceCalculatorServiceMock);

            _viewModel.SelectedUberOption = UberType.UBER_FLASH.GetDescription();
            _viewModel.SelectedOrigin = CityTypes.RECIFE.GetDescription();
            _viewModel.SelectedDestination = CityTypes.OLINDA.GetDescription();
            _viewModel.Weight = 5; // Peso em kg
            _viewModel.Height = 10;
            _viewModel.Width = 10;
            _viewModel.Length = 10;

            _distanceCalculatorServiceMock
                .When(x => x.CalculateDistanceAsync(CityTypes.RECIFE, CityTypes.OLINDA))
                .Return(Task.FromResult(8)); // 10 km

            // Act
            _viewModel.ExecuteCalculateFare();

            // Assert
            Assert.AreEqual("Calculated Fare: R$ 12,00", _viewModel.FareResult);
            Assert.AreEqual("Calculated Distance: 8 km", _viewModel.DistanceResult);
        }

        /// <summary>
        /// Cenário: Limpar campos após cálculo da tarifa.
        /// Dado que a tarifa foi calculada com sucesso
        /// Quando o comando de limpar é executado
        /// Então todos os campos devem ser redefinidos para seus valores padrão
        /// </summary>
        [TestMethod]
        public void ExecuteClear_ShouldResetFields()
        {
            // Arrange
            _viewModel = new FareCalculatorPageViewModel(
                _fareCalculatorServiceMock,
                _distanceCalculatorServiceMock
            );

            _viewModel.SelectedUberOption = UberType.UBER_X.GetDescription();
            _viewModel.SelectedOrigin = CityTypes.RECIFE.GetDescription();
            _viewModel.SelectedDestination = CityTypes.OLINDA.GetDescription();

            _distanceCalculatorServiceMock
                .When(x => x.CalculateDistanceAsync(CityTypes.RECIFE, CityTypes.OLINDA))
                .Return(Task.FromResult(10)); // 10 km

            _fareCalculatorServiceMock
                .When(x => x.CalculateFare(It.IsAny<UberRideBase>(), 10, 0, 0))
                .Return(15); // Tarifa de R$ 15,00

            _viewModel.FareResult = "Calculated Fare: R$ 15,00";
            _viewModel.DistanceResult = "Calculated Distance: 10 km";
            _viewModel.Weight = 5;
            _viewModel.Height = 10;
            _viewModel.Width = 10;
            _viewModel.Length = 10;

            // Act
            _viewModel.ClearCommand.Execute(null);

            // Assert
            Assert.AreEqual(UberType.UBER_X.GetDescription(), _viewModel.SelectedUberOption);
            Assert.AreEqual(CityTypes.RECIFE.GetDescription(), _viewModel.SelectedOrigin);
            Assert.AreEqual(CityTypes.OLINDA.GetDescription(), _viewModel.SelectedDestination);
            Assert.AreEqual(0, _viewModel.Weight);
            Assert.AreEqual(0, _viewModel.Height);
            Assert.AreEqual(0, _viewModel.Width);
            Assert.AreEqual(0, _viewModel.Length);
            Assert.AreEqual(string.Empty, _viewModel.FareResult);
            Assert.AreEqual(string.Empty, _viewModel.DistanceResult);
        }
    }
}
