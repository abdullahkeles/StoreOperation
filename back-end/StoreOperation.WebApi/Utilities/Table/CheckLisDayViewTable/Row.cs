using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StoreOperation.WebApi.Utilities.Table.CheckLisDayViewTable
{
    public class Row
    {
        public string id { get; set; }
        public List<Col> Type { get; set; }
    }
}