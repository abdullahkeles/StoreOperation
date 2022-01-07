namespace StoreOperation.WebApi.Utilities.File
{
    public class ReadImageResult
    {

        public ReadImageResult(string contentType, byte[] bytes)
        {
            IsSuccess = true;
            ContentType = contentType;
            Bytes = bytes;
        }

        public ReadImageResult(string errorMessage)
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string ContentType { get; set; }
        public byte[] Bytes { get; set; }
    }
}