using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using Common.Interfeces;
using Common.Services;

namespace RainFallAPI.Services
{
    public class RainfallService : IRainfallService
    {
        private readonly AppDbContext _dbContext;
        public RainfallService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual List<RainfallReading> GetRainfallReadings(string stationId, int count)
        {
            // Your logic to retrieve rainfall readings goes here
            var readings = _dbContext.RainfallReadings
                .Where(r => r.StationId == stationId)
                .OrderByDescending(r => r.DateMeasured)
                .Take(count)
                .ToList();

            return readings;
        }

        public virtual List<RainfallReading> TestDatabaseQuery()
        {
            var readings = _dbContext.RainfallReadings.ToList();
            return readings;
        }
    }
}