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
        
    }
}