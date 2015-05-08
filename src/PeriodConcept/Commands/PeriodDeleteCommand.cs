using System;
using System.Linq;
using MediatR;
using PeriodConcept.Models;

namespace PeriodConcept.Commands
{
    public class PeriodDeleteCommand : IRequest<Period>
    {
        public int PeriodID { get; set; }
    }
}