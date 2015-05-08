using System;
using System.Linq;
using MediatR;
using PeriodConcept.Common;
using PeriodConcept.Models;

namespace PeriodConcept.Queries
{
    public class PeriodsSearchableDatabaseQueryHandler : IRequestHandler<PeriodsSearchableDatabaseQuery, IPaginable<Period>>
    {
        private readonly ICommonDbContext dbContext;
        private readonly IMediator mediator;

        public PeriodsSearchableDatabaseQueryHandler(ICommonDbContext dbContext, IMediator mediator)
        {
            this.dbContext = dbContext;
            this.mediator = mediator;
        }

        IPaginable<Period> IRequestHandler<PeriodsSearchableDatabaseQuery, IPaginable<Period>>.Handle(PeriodsSearchableDatabaseQuery message)
        {
            if (string.IsNullOrWhiteSpace(message.QueryText))
            {
                var query = new PeriodsPaginableDatabaseQuery
                {
                    PageNumber = message.PageNumber,
                    ItemCountPerPage = message.ItemCountPerPage,
                };

                return this.mediator.Send(query);
            }

            var paginable =
                this.dbContext.Periods
                    .Where(t => t.MonthName.Contains(message.QueryText) || t.WeekdayName.Contains(message.QueryText))
                    .OrderBy(t => t.PeriodID)
                    .ToPaginable(message.PageNumber, message.ItemCountPerPage);

            return paginable;
        }
    }
}