using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watch_Precision.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Windows;

namespace Watch_Precision.Data
{
    internal class WatchPrecisionContext : DbContext
    {
        public DbSet<Watch> Watches { get; set; } = null!;
        public DbSet<Measurement> Measurements { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // For some reason this doesn't work.
            //var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            //optionsBuilder.UseSqlite(connectionString);
            //optionsBuilder.UseSqlite(Configuration.GetConnectionString("Default"));

            optionsBuilder.UseSqlite("Data Source=.\\watch.db;");
        }

    }
}
