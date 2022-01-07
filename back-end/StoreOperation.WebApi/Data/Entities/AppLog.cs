using System;

namespace StoreOperation.WebApi.Data.Entities
{
    public partial class AppLog
    {
        public Guid Id { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
