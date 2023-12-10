using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RainFallAPI.Controllers;
using Common.Models;
using Common.Interfeces;
using RainFallAPI.Services;
using System;
using System.Collections.Generic;

namespace RainFallAPI.Tests
{
    [TestFixture]
    public class RainfallControllerTests
    {
        [Test]
        public void GetRainfallReadings_ReturnsOkResultWithReadings()
        {
            // Arrange
            var mockRainFallAPI = new Mock<IRainfallService>();
            var controller = new RainfallController(mockRainFallAPI.Object);

            var stationId = "1";
            var count = 10;

            var expectedReadings = new List<RainfallReading>
            {
                new RainfallReading { DateMeasured = DateTime.Now, AmountMeasured = 5.6M },
                new RainfallReading { DateMeasured = DateTime.Now.AddDays(-1), AmountMeasured = 3.2M }
            };

            mockRainFallAPI.Setup(service => service.GetRainfallReadings(stationId, count))
                .Returns(expectedReadings);

            // Act
            var result = controller.GetRainfallReadings(stationId, count) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            var responseData = result.Value as RainfallReadingResponse;
            Assert.IsNotNull(responseData);
            Assert.AreEqual(expectedReadings, responseData.Readings);
        }

        [Test]
        public void GetRainfallReadings_ReturnsNotFoundForEmptyReadings()
        {
            // Arrange
            var mockRainFallAPI = new Mock<IRainfallService>();
            var controller = new RainfallController(mockRainFallAPI.Object);

            var stationId = "2";
            var count = 10;

            mockRainFallAPI.Setup(service => service.GetRainfallReadings(stationId, count))
                .Returns(new List<RainfallReading>());

            // Act
            var result = controller.GetRainfallReadings(stationId, count) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);

            var errorResponse = result.Value as ErrorResponse;
            Assert.IsNotNull(errorResponse);
            Assert.AreEqual("No readings found for the specified stationId", errorResponse.Message);
        }
    }
}