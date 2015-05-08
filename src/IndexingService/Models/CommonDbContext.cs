using System;
using System.Data.Entity;
using System.Linq;
using IndexingService.Models.Configurations;

namespace IndexingService.Models
{
    public class CommonDbContext : DbContext
    {
        public CommonDbContext()
            : base("name=CommonDbContext") { }

        public DbSet<Period> Periods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                .Add(new PeriodEntityTypeConfiguration());
        }
    }
}