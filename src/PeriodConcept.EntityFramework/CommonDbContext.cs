using System;
using System.Data.Entity;
using System.Linq;
using PeriodConcept.EntityFramework.Configurations;
using PeriodConcept.Models;

namespace PeriodConcept.EntityFramework
{
    public class CommonDbContext : DbContext, ICommonDbContext
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