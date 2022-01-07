namespace StoreOperation.WebApi.Common.Responses
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">geri dönüş türünü bağımsız hale getiriyoruz.
    ///nesnemizin kendisini veya dizini geri döndüre biliceğiz IList/Entity/ </typeparam>
    public interface IDataResponse<out T>:IApiResponse
    {
        public T Data { get; }
        public int? Count { get;}
    }
}