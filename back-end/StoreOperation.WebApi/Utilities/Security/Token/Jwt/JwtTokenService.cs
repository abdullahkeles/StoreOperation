using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using StoreOperation.WebApi.Configuration.Context;

namespace StoreOperation.WebApi.Utilities.Security.Token.Jwt
{
    public class JwtTokenService : ITokenService
    {
        private readonly IStoreOperationConfigurationContext checkListConfigurationContext;


        public JwtTokenService(IStoreOperationConfigurationContext checkListConfigurationContext)
        {
            this.checkListConfigurationContext = checkListConfigurationContext;
        }

        //  ValidateIssuer = Token’ı oluşturan server adresini doğrula anlamına gelir.
        //  ValidateAudience = Token’ı almaya yetkili olan token alıcısını doğrula.
        //  ValidateLifetime = Token’ın süresinin veya yayıncının imzalama anahtarının geçerliliğini doğrula.
        //  ValidateIssuerSigninKey = Token’ın imzasını doğrula.
        //  Issuer, audience, signing key için farklı şekillerde belirtebilirsiniz. Ben
        //  appsettings.json dosyasında tutmayı tercih ettim.
        
        public TokenInfo CreateToken(Guid userId, Guid shoppeStoreId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(checkListConfigurationContext.JwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("UserId",userId.ToString()),
                    new Claim("StoreId",shoppeStoreId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(checkListConfigurationContext.JwtSecretExpirationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = checkListConfigurationContext.JwtValidIssuer,
                Audience = checkListConfigurationContext.JwtValidAudience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            tokenHandler.WriteToken(token);

            return new TokenInfo
            {
                Token = tokenHandler.WriteToken(token),
                ExpiredDate = DateTime.Now.AddMinutes(checkListConfigurationContext.JwtSecretExpirationInMinutes)
            };
        }

        public ResolveTokenResult ResolveToken(string token)
        {
            var resolveTokenResult = new ResolveTokenResult();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(checkListConfigurationContext.JwtSecret);
            var securityKey = new SymmetricSecurityKey(key);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = checkListConfigurationContext.JwtValidAudience,
                    ValidIssuer = checkListConfigurationContext.JwtValidIssuer,
                    IssuerSigningKey = securityKey
                }, out SecurityToken validatedToken);

                resolveTokenResult.ExpiryDate = validatedToken.ValidTo;
                resolveTokenResult.IsValid = true;
                resolveTokenResult.Claims = tokenHandler.ReadJwtToken(token).Claims;
            }

            catch (Exception ex)
            {
                resolveTokenResult.IsValid = false;
                resolveTokenResult.ErrorMessage = ex.Message;
            }

            return resolveTokenResult;
        }
    }
}
