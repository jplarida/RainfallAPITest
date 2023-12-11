using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using Common.Interfeces;

namespace RainFallAPI.Services
{
    public class RainfallService : IRainfallService
    {
        public virtual List<RainfallReading> GetRainfallReadings(string stationId, int count)
        {
            // Your logic to retrieve rainfall readings goes here
            var readings = new List<RainfallReading>
            {
                new RainfallReading { DateMeasured = DateTime.Now, AmountMeasured = 5.6M },
                new RainfallReading { DateMeasured = DateTime.Now.AddDays(-1), AmountMeasured = 3.2M }
            };
            return readings;
        }
    }
}