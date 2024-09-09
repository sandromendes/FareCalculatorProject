using FareCalculator.Core.Enums;
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateFare_NullVehicle_ThrowsArgumentNullException()
        {
            _fareCalculatorService.CalculateFare(null, 10);
        }

        [TestMethod]
        public void CalculateFare_UberX_NoPassengers_ReturnsExpectedFare()
        {
            var vehicle = new Vehicle { Type = UberType.UberX, Passengers = 0 };
            var fare = _fareCalculatorService.CalculateFare(vehicle, 10);

            Assert.AreEqual(5.00m + 0.50m * 10, fare);
        }

        [TestMethod]
        public void CalculateFare_UberX_OnePassenger_ReturnsExpectedFare()
        {
            var vehicle = new Vehicle { Type = UberType.UberX, Passengers = 1 };
            var fare = _fareCalculatorService.CalculateFare(vehicle, 10);

            Assert.AreEqual(5.00m + 1.00m * 10, fare);
        }
    }
}
