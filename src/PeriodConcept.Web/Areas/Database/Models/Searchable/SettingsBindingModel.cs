﻿using System;
using System.Linq;

namespace PeriodConcept.Web.Areas.Database.Models.Searchable
{
    public class SettingsBindingModel
    {
        public int? PageNumber { get; set; }
        public int? ItemCountPerPage { get; set; }

        public string QueryText { get; set; }
    }
}