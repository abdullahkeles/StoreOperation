namespace StoreOperation.WebApi.Utilities.Security.Hash
{
    public interface IHashService
    {
        string CreateHash(string plainText,string salt=null);
        bool CompareHash(string hashedText, string plainText,string salt=null);
    }
}