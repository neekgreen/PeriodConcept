using System;
using System.Linq;

namespace PeriodConcept.Web.Models
{
    public interface ISearchableViewModel  
    {
        string QueryText { get; set; }
    }
}