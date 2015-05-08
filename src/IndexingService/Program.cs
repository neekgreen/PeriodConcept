using System;
using System.Linq;
using IndexingService.Models;
using Nest;

namespace IndexingService
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"), "periods");
            var client = new ElasticClient(settings);

            using (var context = new CommonDbContext())
            {
                foreach(var period in context.Periods)
                {
                    Console.WriteLine(period.PeriodID);
                }
            }
        }
    }
}