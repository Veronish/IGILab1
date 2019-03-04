using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using lab1core.Modules;

namespace lab1core
{
    public class CheckContext : DbContext
    {
        public DbSet <Check> Checks           { get; set; }
        public DbSet <Violation> Violations   { get; set; }
        public DbSet <Interprise> Interprises { get; set; }
        public DbSet <Inspector> Inspectors   { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json"); ;
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
        }
    }
}
