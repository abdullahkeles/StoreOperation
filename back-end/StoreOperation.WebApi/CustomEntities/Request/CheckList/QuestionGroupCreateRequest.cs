namespace StoreOperation.WebApi.CustomEntities.Request.CheckList
{
    public class QuestionGroupCreateRequest
    {
        public string Name { get; set; }
        public bool State { get; set; }
        public int? Sort { get; set; }
    }
}