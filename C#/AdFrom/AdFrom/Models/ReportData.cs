using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AdFrom.Models
{
    public class ReportData
    {
        public IList<string> ColumnHeaders { get; set; }
        public IList<Column> Columns { get; set; }
        public IList<IList<object>> Rows { get; set; }
    }
}
