using System;
using StoreOperation.WebApi.Enums;

namespace StoreOperation.WebApi.Common.Responses
{
    public class DataResponse<T> : IDataResponse<T>
    {
        public DataResponse(ResultState resultType, string message, Exception exception, T date, int count)
        {
            ResultType = resultType;
            Message = message;
            Exception = exception;
            Data = date;
            Count = count;
        }

        public DataResponse(ResultState resultType, T data, int count)
        {
            ResultType = resultType;
            Data = data;
            Count = count;
        }
        public DataResponse(ResultState resultType, string message, T data, int count)
        {
            ResultType = resultType;
            Message = message;
            Data = data;
            Count = count;
        }
        public DataResponse(ResultState resultType, string message, T data)
        {
            ResultType = resultType;
            Message = message;
            Data = data;
        }
        public DataResponse(ResultState resultType, string message)
        {
            ResultType = resultType;
            Message = message;
        }
        public DataResponse(ResultState resultType, Exception exception)
        {
            ResultType = resultType;
            Exception = exception;
        }
        public DataResponse(ResultState resultType, string message, Exception exception)
        {
            ResultType = resultType;
            Message = message;
            Exception = exception;
        }
        public ResultState ResultType { get; }
        public string Message { get; }
        public Exception Exception { get; }
        public T Data { get; }
        public virtual int? Count { get; }
    }
}