namespace StoreOperation.WebApi.Utilities.Security.Hash
{
    public class Sha512HashService:IHashService
    {
        public string CreateHash(string plainText,string salt)
        {
            // Parametreler
            //     password String
            //        Anahtarın türetileceğini belirten parola.
            //
            //     salt Byte[]
            //         Anahtar türetme sürecinde kullanılacak olan anahtar.
            //
            //     prf KeyDerivationPrf
            //         Anahtar türetme işleminde kullanılacak sözde rastgele işlev.
            //
            //     iterationCount Int32
            //         Anahtar türetme işlemi sırasında uygulanacak sözde rastgele işlevin yineleme sayısı.
            //
            //     numBytesRequested Int32
            //         Türetilmiş anahtarın istenen uzunluğu (bayt cinsinden).
            var valueBytes = Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivation.Pbkdf2(
                password: plainText,
                salt: System.Text.Encoding.UTF8.GetBytes(salt),
                prf: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);

            return System.Convert.ToBase64String(valueBytes);
        }
       
        public bool CompareHash(string hashedText, string plainText, string salt) =>
            CreateHash(plainText, salt) == hashedText;

    }
}