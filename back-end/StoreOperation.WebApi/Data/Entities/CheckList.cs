using System;
using System.Collections.Generic;

namespace StoreOperation.WebApi.Data.Entities
{
    public partial class CheckList
    {
        public CheckList()
        {
            Questions = new HashSet<CheckListQuestionAnswer>();
        }
        public Guid CheckListId { get; set; }
        public ICollection<CheckListQuestionAnswer> Questions { get; set; }
        public string Note { get; set; }
        public int Rank { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser Certifying { get; set; }
        public DateTime TimeSpan { get; set; }
        public Guid CheckListDayId { get; set; }
        public CheckListDay CheckListDay { get; set; }
        /// <summary>
        /// kaydın aktif/pasifini tutması için
        /// </summary>
        public bool State { get; set; }
    }
}
