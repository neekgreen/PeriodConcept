using System;
using System.Linq;
using MediatR;

namespace PeriodConcept.Notifications
{
    public class PeriodDeleted : INotification
    {
        public int PeriodID { get; set; }
    }
}