using FareCalculator.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FareCalculator.Tests
{
    [TestClass]
    public class DomainUnitTests
    {
        /// <summary>
        /// Cenário: Cálculo da tarifa do UberVIP com 1 passageiro
        /// Dado que o veículo é um UberVIP com 1 passageiro
        /// Quando a distância percorrida é de 20 km
        /// Então a tarifa total deve ser R$ 40,00
        /// </summary>

        [TestMethod]
        public void CalculateFare_UberVip_WhenOnePassengerAnd20kmOfDistance_ShouldReturns40()
        {
            // Arrange
            var uberRide = new UberVip
            {
                Passengers = 1
            };

            var distance = 20;

            // Act
            var fare = uberRide.CalculateFare(distance);

            // Assert
            Assert.AreEqual(40.0m, fare);
        }
    }
}
