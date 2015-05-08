using System;
using System.Linq;
using MediatR;
using Nest;
using PeriodConcept.Models;
using PeriodConcept.Notifications;

namespace PeriodConcept.Elastic.Notifications
{
    public class PeriodReindexingRequestedHandler : INotificationHandler<PeriodReindexingRequested>
    {
        private readonly ICommonDbContext dbContext;

        public PeriodReindexingRequestedHandler(ICommonDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        void INotificationHandler<PeriodReindexingRequested>.Handle(PeriodReindexingRequested notification)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"), "periods");
            var client = new ElasticClient(settings);

            client.DeleteIndex("periods");                
        }
    }
}