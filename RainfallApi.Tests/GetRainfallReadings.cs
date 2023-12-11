using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RainFallAPI.Controllers;
using Common.Models;
using Common.Interfeces;
using RainFallAPI.Services;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace RainFallAPI.Tests
{
    [TestFixture]
    public class RainfallControllerTests
    {
        private readonly ILogger<RainfallController> logger; // Declare logger as a class-level field

        public RainfallControllerTests()
        {
            // Initialize logger in the constructor
            logger = new Mock<ILogger<RainfallController>>().Object;
        }

        [Test]
        public void GetRainfallReadings_ReturnsOkResultWithReadings()
        {
            // Arrange
            var mockRainFallAPI = new Mock<IRainfallService>();
            var controller = new RainfallController(mockRainFallAPI.Object);

            var stationId = "003";
            var count = 10;

            var expectedReadings = new List<RainfallReading>
            {
                new RainfallReading { Id = 3,StationId = "003", DateMeasured = DateTime.Now.AddDays(-1), AmountMeasured = 7.45m },
                new RainfallReading { Id = 6,StationId = "003", DateMeasured = DateTime.Now.AddDays(-1), AmountMeasured = 18.5m }
            };

            mockRainFallAPI.Setup(service => service.GetRainfallReadings(stationId, count))
                .Returns(expectedReadings);

            // Act
            var result = controller.GetRainfallReadings(stationId, count) as ObjectResult;

            // Assert
            logger.LogInformation($"GetRainfallReadings_ReturnsOkResultWithReadings Result: {result}");
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var responseData = result.Value as RainfallReadingResponse;
            Assert.IsNotNull(responseData);
            Assert.That(responseData.Readings, Is.EqualTo(expectedReadings));
        }

        [Test]
        public void GetRainfallReadings_ReturnsNotFoundForEmptyReadings()
        {
            // Arrange
            var mockRainFallAPI = new Mock<IRainfallService>();
            var controller = new RainfallController(mockRainFallAPI.Object);

            var stationId = "113";
            var count = 10;

            mockRainFallAPI.Setup(service => service.GetRainfallReadings(stationId, count))
                .Returns(new List<RainfallReading>());

            // Act
            var result = controller.GetRainfallReadings(stationId, count) as ObjectResult;

            // Assert
            logger.LogInformation($"GetRainfallReadings_ReturnsNotFoundForEmptyReadings Result: {result}");
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(404));

            var errorResponse = result.Value as ErrorResponse;
            Assert.IsNotNull(errorResponse);
            Assert.That(errorResponse.Message, Is.EqualTo("No readings found for the specified stationId"));
        }
    }
}