using System.Collections.Generic;

namespace Common.Models
{
    public class RainfallReadingResponse
    {
        public RainfallReadingResponse()
        {
            Readings = new List<RainfallReading>();
        }
        public List<RainfallReading> Readings { get; set; }
    }
}