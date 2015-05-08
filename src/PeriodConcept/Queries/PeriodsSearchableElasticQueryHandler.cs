using System;
using System.Linq;
using MediatR;
using PeriodConcept.Common;
using PeriodConcept.Models;

namespace PeriodConcept.Queries
{
    public class PeriodsSearchableElasticQueryHandler : IRequestHandler<PeriodsSearchableElasticQuery, IPaginable<Period>>
    {
        private readonly IMediator mediator;
        private readonly IPaginableSearchEngine searchEngine;

        public PeriodsSearchableElasticQueryHandler(IPaginableSearchEngine searchEngine, IMediator mediator)
        {
            this.searchEngine = searchEngine;
            this.mediator = mediator;
        }

        IPaginable<Period> IRequestHandler<PeriodsSearchableElasticQuery, IPaginable<Period>>.Handle(PeriodsSearchableElasticQuery message)
        {
            var paginable =
                this.searchEngine.Search(message.QueryText, message.PageNumber, message.ItemCountPerPage);

            return paginable;
        }
    }
}