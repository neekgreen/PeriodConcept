using System;
using System.Linq;
using MediatR;
using PeriodConcept.Models;

namespace PeriodConcept.Queries
{
    public class PeriodQueryHandler : IRequestHandler<PeriodQuery, Period>
    {
        private readonly ICommonDbContext dbContext;

        public PeriodQueryHandler(ICommonDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        Period IRequestHandler<PeriodQuery, Period>.Handle(PeriodQuery message)
        {
            var period =
                dbContext.Periods
                    .Single(t => t.PeriodID == message.PeriodID);

            return period;
        }
    }
}