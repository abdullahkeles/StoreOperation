using System;

namespace StoreOperation.WebApi.Utilities.Security.Token
{
    public class TokenInfo
    {
        public string Token { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
