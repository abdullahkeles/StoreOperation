namespace StoreOperation.WebApi.CustomEntities.Request.App
{
    public class CreateStore
    {
        public string Name { get; set; }
        //[StringLength(10,ErrorMessage = "{0} alanı {1} karakter olmalıdır.")]
        public string VergiKimlikNo { get; set; }
        public int IlId { get; set; }
        public int IlceId { get; set; }
        public string Adress { get; set; }
        //[StringLength(10,ErrorMessage = "{0} alanı {1} karakter olmalıdır.")]
        public string OfficePhone { get; set; }
        //[StringLength(10,ErrorMessage = "{0} alanı {1} karakter olmalıdır.")]
        public string OfficeFax { get; set; }
        public string Email { get; set; }
        public bool StoreState { get; set; }
        public int CategoryId { get; set; }
    }
}