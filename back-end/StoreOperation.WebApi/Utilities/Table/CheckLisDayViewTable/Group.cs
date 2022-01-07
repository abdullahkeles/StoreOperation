using System.Collections.Generic;

namespace StoreOperation.WebApi.Utilities.Table.CheckLisDayViewTable
{
    public class Group
    {
        public string id { get; set; }
        public string name { get; set; }
        public int totalSkor { get; set; }
        public Header header { get; set; }
        public List<Row> rows { get; set; }
    }
}