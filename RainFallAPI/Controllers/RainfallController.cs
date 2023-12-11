using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common.Models;
using Common.Interfeces;
using RainFallAPI.Services;

namespace RainFallAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallService _rainfallService;

        public RainfallController(IRainfallService rainfallService)
        {
            _rainfallService = rainfallService;
        }
        /// <summary>
        /// Gets rainfall readings by station Id.
        /// Example URL: rainfall/id/003/readings?count=5
        /// </summary>
        /// <param name="stationId">The id of the reading station.</param>
        /// <param name="count">The number of readings to return.</param>
        /// <returns>A list of rainfall readings.</returns>
        [HttpGet("id/{stationId}/readings")]
        public IActionResult GetRainfallReadings(string stationId, [FromQuery] int count = 10)
        {
            var readings = _rainfallService.GetRainfallReadings(stationId, count);

            if (readings.Count == 0)
            {
                return NotFound(new ErrorResponse { Message = "No readings found for the specified stationId" });
            }

            return Ok(new RainfallReadingResponse { Readings = readings });
        }
        /// <summary>
        /// Gets all rainfall readings.
        /// Example URL: rainfall/test
        /// </summary>
        /// <returns>A list of all rainfall readings.</returns>
        [HttpGet("test")]
        public IActionResult TestDatabaseQuery()
        {
            var readings = _rainfallService.TestDatabaseQuery();
            return Ok(new RainfallReadingResponse { Readings = readings });
        }
    }
}