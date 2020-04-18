using CoreAPI.Domain.Entities;
using CoreAPI.Domain.ValueObjects;
using CoreAPI.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

using System;
using System.IO;

namespace CoreAPI.Infra.Data.Contexts
{
    public class SQLiteDbContext : DbContext
    {
        public DbSet<Machine> Machines { get; set; }
        public DbSet<AntivirusInfo> AntivirusInfos { get; set; }
        public DbSet<HardDriveInfo> HardDriveInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            optionsBuilder.UseSqlite(config["SQLiteConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MachineMap());
            modelBuilder.ApplyConfiguration(new HardDriveInfoMap());
        }
    }
}
