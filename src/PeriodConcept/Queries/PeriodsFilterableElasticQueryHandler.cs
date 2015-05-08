using System;
using System.Linq;
using MediatR;
using PeriodConcept.Common;
using PeriodConcept.Models;

namespace PeriodConcept.Queries
{
    public class PeriodsFilterableElasticQueryHandler : IRequestHandler<PeriodsFilterableElasticQuery, IFilterable<Period>>
    {
        private readonly IMediator mediator;
        private readonly IFilterableSearchService searchEngine;

        public PeriodsFilterableElasticQueryHandler(IFilterableSearchService searchEngine, IMediator mediator)
        {
            this.searchEngine = searchEngine;
            this.mediator = mediator;
        }

        IFilterable<Period> IRequestHandler<PeriodsFilterableElasticQuery, IFilterable<Period>>.Handle(PeriodsFilterableElasticQuery message)
        {
            var filterable =
                this.searchEngine.Search(message.QueryText, message.PageNumber, message.ItemCountPerPage);

            return filterable;
        }
    }
}