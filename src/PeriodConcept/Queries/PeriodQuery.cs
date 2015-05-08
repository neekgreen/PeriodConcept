using System;
using System.Linq;
using MediatR;
using PeriodConcept.Models;

namespace PeriodConcept.Queries
{
    public class PeriodQuery : IRequest<Period>
    {
        public int PeriodID { get; set; }
    }
}