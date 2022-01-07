using StoreOperation.WebApi.Enums;

namespace StoreOperation.WebApi.Common.Responses
{
    public class ApiResponse : IApiResponse
    {
        public ApiResponse(ResultState resultType)
        {
            ResultType = resultType;
        }

        public ApiResponse(ResultState resultType, string message)
        {
            ResultType = resultType;
            Message = message;
            Success = ResultType == ResultState.Success;
        }

        public ResultState ResultType { get; }

        public bool Success { get; }
        public string Message { get; }
    }
}