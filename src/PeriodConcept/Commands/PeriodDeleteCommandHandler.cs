using System;
using System.Linq;
using MediatR;
using PeriodConcept.Models;

namespace PeriodConcept.Commands
{
    public class PeriodDeleteCommandHandler : IRequestHandler<PeriodDeleteCommand, Period>
    {
        private readonly ICommonDbContext dbContext;

        public PeriodDeleteCommandHandler(ICommonDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        Period IRequestHandler<PeriodDeleteCommand, Period>.Handle(PeriodDeleteCommand message)
        {
            var period =
                dbContext.Periods
                    .Single(t => t.PeriodID == message.PeriodID);

            period.IsArchived = true;
            period.LastUpdated = DateTimeOffset.Now;

            return period;
        }
    }
}