using FareCalculator.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FareCalculator.Tests
{
    [TestClass]
    public class FareCalculatorDomainTests
    {
        /// <summary>
        /// Cenário: Cálculo da tarifa do UberBlack com 1 passageiro
        /// Dado que o veículo é um UberBlack com 1 passageiro
        /// Quando a distância percorrida é de 5 km
        /// Então a tarifa total deve ser R$ 25,00
        /// </summary>
        [TestMethod] 
        public void FareCalculator_UberBlack_WhenOnePassengerAndDistance5Km_ShouldReturn25() 
        {
            // Arrange
            var uberRide = new UberBlack { Passengers = 1 };
            var distance = 5;

            // Act
            var fare = uberRide.CalculateFare(distance);

            // Assert
            Assert.AreEqual(25.0m, fare);
        }
    }
}
