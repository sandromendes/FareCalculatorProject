using FareCalculator.Core.Models;
using FareCalculator.Core.Services;
using FareCalculator.Core.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FareCalculator.Tests
{
    [TestClass]
    public class FareCalculatorServiceTests
    {
        private IFareCalculatorService _fareCalculatorService;
        

        [TestInitialize]
        public void SetUp()
        {
            _fareCalculatorService = new FareCalculatorService();
        }

        /// <summary>
        /// Dado que o usuário selecionou UberX como o tipo de veículo
        /// E o usuário especificou 1 passageiro
        /// Quando a distância for de 1 km
        /// Então o valor da tarifa calculada deve ser 5.50 (5.00 de tarifa base + 0.50 por km)
        /// </summary>
        [TestMethod]
        public void CalculateFare_UberX_1Passenger_1km_ShouldReturn5_50()
        {
            // Arrange
            var vehicle = new UberX { Passengers = 1 };
            int distance = 1;

            // Act
            var fare = _fareCalculatorService.CalculateFare(vehicle, distance);

            // Assert
            Assert.AreEqual(5.50m, fare);
        }

        /// <summary>
        /// Dado que o usuário selecionou UberX como o tipo de veículo
        /// E o usuário especificou 2 passageiros
        /// Quando a distância for de 1 km
        /// Então o valor da tarifa calculada deve ser 5.00 (5.00 de tarifa base + 0.50 por km - 0.50 de desconto)
        /// </summary>
        [TestMethod]
        public void CalculateFare_UberX_2Passengers_1km_ShouldReturn5_00()
        {
            // Arrange
            var vehicle = new UberX { Passengers = 2 };
            int distance = 1;

            // Act
            var fare = _fareCalculatorService.CalculateFare(vehicle, distance);

            // Assert
            Assert.AreEqual(5.00m, fare);
        }

        /// <summary>
        /// Dado que o usuário selecionou UberX como o tipo de veículo
        /// E o usuário especificou 3 passageiros
        /// Quando a distância for de 1 km
        /// Então o valor da tarifa calculada deve ser 4.50 (5.00 de tarifa base + 0.50 por km - 1.00 de desconto)
        /// </summary>
        [TestMethod]
        public void CalculateFare_UberX_3Passengers_1km_ShouldReturn4_50()
        {
            // Arrange
            var vehicle = new UberX { Passengers = 3 };
            int distance = 1;

            // Act
            var fare = _fareCalculatorService.CalculateFare(vehicle, distance);

            // Assert
            Assert.AreEqual(4.50m, fare);
        }

        /// <summary>
        /// Dado que o usuário selecionou UberX como o tipo de veículo
        /// E o usuário especificou 1 passageiro
        /// Quando a distância for de 10 km
        /// Então o valor da tarifa calculada deve ser 10.00 (5.00 de tarifa base + 5.00 por km)
        /// </summary>
        [TestMethod]
        public void CalculateFare_UberX_1Passenger_10km_ShouldReturn10_00()
        {
            // Arrange
            var vehicle = new UberX { Passengers = 1 };
            int distance = 10;

            // Act
            var fare = _fareCalculatorService.CalculateFare(vehicle, distance);

            // Assert
            Assert.AreEqual(10.00m, fare);
        }

        /// <summary>
        /// Dado que o usuário selecionou UberX como o tipo de veículo
        /// E o usuário especificou 2 passageiros
        /// Quando a distância for de 10 km
        /// Então o valor da tarifa calculada deve ser 9.50 (5.00 de tarifa base + 5.00 por km - 0.50 de desconto)
        /// </summary>
        [TestMethod]
        public void CalculateFare_UberX_2Passengers_10km_ShouldReturn9_50()
        {
            // Arrange
            var vehicle = new UberX { Passengers = 2 };
            int distance = 10;

            // Act
            var fare = _fareCalculatorService.CalculateFare(vehicle, distance);

            // Assert
            Assert.AreEqual(9.50m, fare);
        }

        /// <summary>
        /// Dado que o usuário selecionou UberX como o tipo de veículo
        /// E o usuário especificou 3 passageiros
        /// Quando a distância for de 10 km
        /// Então o valor da tarifa calculada deve ser 9.00 (5.00 de tarifa base + 5.00 por km - 1.00 de desconto)
        /// </summary>
        [TestMethod]
        public void CalculateFare_UberX_3Passengers_10km_ShouldReturn9_00()
        {
            // Arrange
            var vehicle = new UberX { Passengers = 3 };
            int distance = 10;

            // Act
            var fare = _fareCalculatorService.CalculateFare(vehicle, distance);

            // Assert
            Assert.AreEqual(9.00m, fare);
        }

        /// <summary>
        /// Dado que o usuário selecionou UberX como o tipo de veículo
        /// E o usuário especificou 1 passageiro
        /// Quando a distância for de 0 km
        /// Então o valor da tarifa calculada deve ser 5.00 (somente a tarifa base)
        /// </summary>
        [TestMethod]
        public void CalculateFare_UberX_1Passenger_0km_ShouldReturn5_00()
        {
            // Arrange
            var vehicle = new UberX { Passengers = 1 };
            int distance = 0;

            // Act
            var fare = _fareCalculatorService.CalculateFare(vehicle, distance);

            // Assert
            Assert.AreEqual(5.00m, fare);
        }

        /// <summary>
        /// Dado que o usuário selecionou UberX como o tipo de veículo
        /// E o usuário especificou 2 passageiros
        /// Quando a distância for de 0 km
        /// Então o valor da tarifa calculada deve ser 4.50 (5.00 de tarifa base - 0.50 de desconto)
        /// </summary>
        [TestMethod]
        public void CalculateFare_UberX_2Passengers_0km_ShouldReturn4_50()
        {
            // Arrange
            var vehicle = new UberX { Passengers = 2 };
            int distance = 0;

            // Act
            var fare = _fareCalculatorService.CalculateFare(vehicle, distance);

            // Assert
            Assert.AreEqual(4.50m, fare);
        }

        /// <summary>
        /// Dado que o usuário selecionou UberX como o tipo de veículo
        /// E o usuário especificou 3 passageiros
        /// Quando a distância for negativa
        /// Então o sistema deve lançar uma exceção indicando que a distância é inválida.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateFare_UberX_NegativeDistance_ShouldThrowException()
        {
            // Arrange
            var vehicle = new UberX { Passengers = 3 };
            int distance = -5;

            // Act
            var fare = _fareCalculatorService.CalculateFare(vehicle, distance);

            // Assert handled by ExpectedException
        }
    }
}
