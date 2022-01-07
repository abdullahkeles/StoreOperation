using System.Security.Cryptography;
using System.Text;

namespace StoreOperation.WebApi.Utilities.Security.Hash
{
    public class Sha256HashService : IHashService
    {
        public string CreateHash(string plainText, string salt = null)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public bool CompareHash(string hashedText, string plainText, string salt = null)
        {
            return CreateHash(plainText, null) == hashedText;
        }
    }
}