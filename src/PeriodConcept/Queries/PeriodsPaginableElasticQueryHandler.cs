using System;
using System.Linq;
using MediatR;
using PeriodConcept.Common;
using PeriodConcept.Models;

namespace PeriodConcept.Queries
{
    public class PeriodsPaginableElasticQueryHandler : IRequestHandler<PeriodsPaginableElasticQuery, IPaginable<Period>>
    {
        private readonly IMediator mediator;
        private readonly IPaginableSearchEngine searchEngine;

        public PeriodsPaginableElasticQueryHandler(IPaginableSearchEngine searchEngine, IMediator mediator)
        {
            this.searchEngine = searchEngine;
            this.mediator = mediator;
        }

        IPaginable<Period> IRequestHandler<PeriodsPaginableElasticQuery, IPaginable<Period>>.Handle(PeriodsPaginableElasticQuery message)
        {
            var paginable =
                this.searchEngine.Search(null, message.PageNumber, message.ItemCountPerPage);

            return paginable;
        }
    }
}