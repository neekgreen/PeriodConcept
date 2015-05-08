using System;
using System.Data.Entity;
using System.Linq;

namespace PeriodConcept.Models
{
    public interface ICommonDbContext
    {
        DbSet<Period> Periods { get; }

        int SaveChanges();
    }
}