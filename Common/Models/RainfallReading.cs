using System;

namespace Common.Models
{
    public class RainfallReading
    {
        public int Id { get; set; }
        public string? StationId { get; set; }
        public DateTime DateMeasured { get; set; }
        public decimal AmountMeasured { get; set; }
    }
}
