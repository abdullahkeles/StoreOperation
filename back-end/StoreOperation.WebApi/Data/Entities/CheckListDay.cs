using System;
using System.Collections.Generic;

namespace StoreOperation.WebApi.Data.Entities
{
    public partial class CheckListDay
    {
        public CheckListDay()
        {
            CheckLists = new HashSet<CheckList>();
        }
        public Guid CheckListDayId { get; set; }
        public DateTime Day { get; set; }
        public Guid StoreId { get; set; }
        public AppStore Store { get; set; }
        public ICollection<CheckList> CheckLists { get; set; }

        public int Rank { get; set; }
        /// <summary>
        /// aktif/pasif
        /// </summary>
        public bool State { get; set; }
    }
}
