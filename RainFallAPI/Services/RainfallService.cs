using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;

namespace RainFallAPI.Services
{
    public class RainfallService
    {
        public List<RainfallReading> GetRainfallReadings(string stationId, int count)
        {
            // Your logic to retrieve rainfall readings goes here
            var readings = new List<RainfallReading>
            {
                new RainfallReading { DateMeasured = DateTime.Now, AmountMeasured = 5.6M },
                new RainfallReading { DateMeasured = DateTime.Now.AddDays(-1), AmountMeasured = 3.2M }
                // Add more readings as needed
            };

            return readings;
        }
    }
}