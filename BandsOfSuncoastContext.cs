using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BandsOfSuncoast
{

    class BandsOfSuncoastContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=SuncoastBands");
            // var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            // optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}
