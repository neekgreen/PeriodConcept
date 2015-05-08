using System;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using PeriodConcept.Models;

namespace PeriodConcept.EntityFramework.Configurations
{
    internal class PeriodEntityTypeConfiguration : EntityTypeConfiguration<Period>
    {
        public PeriodEntityTypeConfiguration()
        {
            this
                .ToTable("[dbo].[Period]")
                .HasKey(t => t.PeriodID);
        }
    }
}