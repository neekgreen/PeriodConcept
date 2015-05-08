using System;
using System.Linq;
using MediatR;
using PeriodConcept.Common;
using PeriodConcept.Models;

namespace PeriodConcept.Queries
{
    public class PeriodsPaginableDatabaseQueryHandler : IRequestHandler<PeriodsPaginableDatabaseQuery, IPaginable<Period>>
    {
        private readonly ICommonDbContext dbContext;
        private readonly IMediator mediator;

        public PeriodsPaginableDatabaseQueryHandler(ICommonDbContext dbContext, IMediator mediator)
        {
            this.dbContext = dbContext;
            this.mediator = mediator;
        }

        IPaginable<Period> IRequestHandler<PeriodsPaginableDatabaseQuery, IPaginable<Period>>.Handle(PeriodsPaginableDatabaseQuery message)
        {
            var paginable =
                this.dbContext.Periods
                    .OrderBy(t => t.PeriodID)
                    .ToPaginable(message.PageNumber, message.ItemCountPerPage);

            return paginable;
        }
    }
}