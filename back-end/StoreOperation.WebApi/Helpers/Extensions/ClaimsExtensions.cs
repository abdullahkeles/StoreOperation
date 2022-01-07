using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace StoreOperation.WebApi.Helpers.Extensions
{
    public static class ClaimsExtensions
    {
        public static Guid GetUserId(this IEnumerable<Claim> claims)
        {
            Claim userIdClaim = claims.FirstOrDefault(i => i.Type == "UserId");
            return userIdClaim == default ? default : Guid.Parse(userIdClaim.Value);
        }
        
        public static Guid GetUserStoreId(this IEnumerable<Claim> claims)
        {
            Claim userIdClaim = claims.FirstOrDefault(i => i.Type == "StoreId");
            return userIdClaim == default ? default : Guid.Parse(userIdClaim.Value);
        }
    }
}
