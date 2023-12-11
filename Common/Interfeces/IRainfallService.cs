using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfeces
{
    public interface IRainfallService
    {
        List<RainfallReading> GetRainfallReadings(string stationId, int count);
        List<RainfallReading> TestDatabaseQuery();
    }
}