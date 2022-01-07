using StoreOperation.WebApi.Enums;

namespace StoreOperation.WebApi.Common.Responses
{
    public interface IApiResponse
    {
        public ResultState ResultType { get; }
        public string Message { get; }
    }
}