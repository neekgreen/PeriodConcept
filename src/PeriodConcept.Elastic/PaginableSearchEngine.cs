using System;
using System.Linq;
using Nest;
using PeriodConcept.Common;
using PeriodConcept.Models;
using PeriodConcept.Queries;

namespace PeriodConcept.Elastic
{
    public class PaginableSearchEngine : IPaginableSearchEngine
    {
        IPaginable<Period> IPaginableSearchEngine.Search(string queryText, int pageNumber, int itemCountPerPage)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"), "periods");
            var client = new ElasticClient(settings);

            var results =
                client.Search<Period>(s => s
                    .Query(q => q.QueryString(d => d.Query(queryText).DefaultOperator(Operator.And)))
                    .SortAscending(t => t.PeriodID)
                    .From((pageNumber - 1) * itemCountPerPage)
                    .Size(itemCountPerPage)
                );

            return new StaticPaginable<Period>(results.Hits.Select(t => t.Source), pageNumber, itemCountPerPage, (int)results.Total);
        }
    }
}