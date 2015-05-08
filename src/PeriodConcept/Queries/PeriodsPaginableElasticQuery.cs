using System;
using System.Linq;
using MediatR;
using PeriodConcept.Common;
using PeriodConcept.Models;

namespace PeriodConcept.Queries
{
    public class PeriodsPaginableElasticQuery : IRequest<IPaginable<Period>>
    {
        public PeriodsPaginableElasticQuery()
        {
            this.PageNumber = 1;
            this.ItemCountPerPage = 20;
        }

        public int PageNumber { get; set; }
        public int ItemCountPerPage { get; set; }
    }
}