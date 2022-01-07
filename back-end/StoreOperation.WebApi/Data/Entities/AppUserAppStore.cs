using System;

namespace StoreOperation.WebApi.Data.Entities
{
    public partial class AppUserAppStore
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public Guid StoreId { get; set; }
        public AppStore Store { get; set; }
        
        /// <summary>
        /// burada enum sabiti tanımlanmalı - personel,yönetiçi,yönetiçi yardımcısı,
        /// todo persdnelin mağazada hangi pozisyonda çalıştığını belirten enum tanımla 16/9/2021 abdullah 
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// personelin aktif, pasif veya askıda gibi tanımlanması
        /// todo state enumun tanımlanması [aktif,pasif,askıda,ücresiz izinli] 16/9/2021 abdullah
        /// </summary>
        public int State { get; set; }

        public DateTime StarDate { get; set; }
        public DateTime FinishDate { get; set; }
        
    }
}