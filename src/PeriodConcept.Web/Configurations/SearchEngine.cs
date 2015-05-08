//using System;
//using System.Linq;
//using PeriodConcept.Common;
//using PeriodConcept.Models;
//using PeriodConcept.Queries;

//namespace PeriodConcept.Web.Configurations
//{
//    public class SearchEngine : ISearchEngine
//    {
//        private string hostName = "";

//        public SearchEngine()
//        {
//            this.hostName = "http://localhost:9200/";
//        }

//        IPaginable<Period> ISearchEngine.Search(string queryText, int pageNumber, int itemCountPerPage)
//        {
//            return 
//                Enumerable.Empty<Period>()
//                    .AsQueryable()
//                    .ToPaginable(pageNumber, itemCountPerPage);
//        }
//    }
//}