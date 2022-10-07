using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watch_Precision.Models;
using System.Configuration;

namespace Watch_Precision.Data
{
    internal class WatchPrecisionContext : DbContext
    {
        public DbSet<Watch> Watches { get; set; } = null!;
        public DbSet<Measurement> Measurements { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // For some reason this doesn't work.
            // optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["WatchDBConnection"].ConnectionString);

             optionsBuilder.UseSqlite("Data Source=.\\watch.db;");
        }
    }
}
