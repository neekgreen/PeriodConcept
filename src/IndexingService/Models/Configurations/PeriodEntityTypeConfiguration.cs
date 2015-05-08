using System;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace IndexingService.Models.Configurations
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