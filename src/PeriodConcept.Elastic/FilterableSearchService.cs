using System;
using System.Collections.Generic;
using System.Linq;
using Nest;
using PeriodConcept.Common;
using PeriodConcept.Models;
using PeriodConcept.Queries;

namespace PeriodConcept.Elastic
{
    public class FilterableSearchService : IFilterableSearchService
    {
        IFilterable<Period> IFilterableSearchService.Search(string queryText, int pageNumber, int itemCountPerPage)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"), "periods");
            var client = new ElasticClient(settings);

            var results =
                client.Search<Period>(s => s
                    .MatchAll()
                    .SortAscending(t => t.PeriodID)
                    .From((pageNumber - 1) * itemCountPerPage)
                    .Size(itemCountPerPage)

                    .Aggregations(a => a
                        .Terms("Calendar Month", e => e.Field(f => f.MonthName).Size(12))
                        .Terms("Day Of Week", e => e.Field(f => f.WeekdayName))
                        .Terms("Calendar Year", e => e.Field(f => f.YearValue))
                    )
                );

            var filters = new List<Filter>();

            foreach (var aggregation in results.Aggregations)
            {
                var dimension = new Filter { CommonName = aggregation.Key };
                foreach (var bucketItem in (aggregation.Value as Bucket).Items)
                {
                    var keyItem = bucketItem as KeyItem;

                    var dimensionItem = new FilterItem  { Value = keyItem.Key, ItemCount = (int)keyItem.DocCount };
                    dimension.Items.Add(dimensionItem);
                }

                if (dimension.Items.Any())
                    filters.Add(dimension);
            }

            return new StaticFilterable<Period>(results.Hits.Select(t => t.Source), filters, pageNumber, itemCountPerPage, (int)results.Total);
        }
    }
}