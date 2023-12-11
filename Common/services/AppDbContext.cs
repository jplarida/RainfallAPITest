using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Models;
namespace Common.Services
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RainfallReading> RainfallReadings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the model (e.g., add indexes, unique constraints)
            modelBuilder.Entity<RainfallReading>().HasKey(r => r.Id);
            // Seed sample data
            modelBuilder.Entity<RainfallReading>().HasData(
                new RainfallReading { Id = 1, StationId = "123", DateMeasured = DateTime.Now.AddDays(-1), AmountMeasured = 12.65m },
                new RainfallReading { Id = 2,StationId = "103", DateMeasured = DateTime.Now, AmountMeasured = 8.0m },
                new RainfallReading { Id = 3,StationId = "003", DateMeasured = DateTime.Now.AddDays(-1), AmountMeasured = 7.45m },
                new RainfallReading { Id = 4,StationId = "123", DateMeasured = DateTime.Now.AddDays(-1), AmountMeasured = 17.635m },
                new RainfallReading { Id = 5,StationId = "123", DateMeasured = DateTime.Now.AddDays(-1), AmountMeasured = 10.533m },
                new RainfallReading { Id = 6,StationId = "003", DateMeasured = DateTime.Now.AddDays(-1), AmountMeasured = 18.5m },
                new RainfallReading { Id = 7,StationId = "103", DateMeasured = DateTime.Now.AddDays(-1), AmountMeasured = 9.56m },
                new RainfallReading { Id = 8,StationId = "123", DateMeasured = DateTime.Now.AddDays(-1), AmountMeasured = 15.501m }
                // Add more sample records as needed
            );
        }


        
    }
}