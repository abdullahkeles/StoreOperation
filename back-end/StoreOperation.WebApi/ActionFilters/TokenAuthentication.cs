using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreOperation.WebApi.Common.Api;
using StoreOperation.WebApi.Utilities.Security.Token;

namespace StoreOperation.WebApi.ActionFilters
{
    public class TokenAuthentication:ActionFilterAttribute
    {
        private readonly ITokenService _tokenService;

        public TokenAuthentication(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var tokenWithBearerKeyword = context.HttpContext.Request.Headers["Authorization"].ToString();

            if (String.IsNullOrEmpty(tokenWithBearerKeyword))
            {
                context.Result = new UnauthorizedObjectResult(new ErrorApiResponse(ResultMessage.TokenCanNotBeEmptyOrNull));
                return;
            }

            if (!tokenWithBearerKeyword.StartsWith("Bearer "))
            {
                context.Result = new UnauthorizedObjectResult(new ErrorApiResponse(ResultMessage.InvalidToken));
                return;
            }

            try
            {
                var tokenWithoutBearerKeyword = tokenWithBearerKeyword.Split("Bearer ")[1];

                var resolveTokenResult = _tokenService.ResolveToken(tokenWithoutBearerKeyword);

                if (!resolveTokenResult.IsValid)
                {
                    context.Result = new UnauthorizedObjectResult(new ErrorApiResponse(ResultMessage.TokenCanNotBeEmptyOrNull));
                }

                var claimsIdentity = new ClaimsIdentity(resolveTokenResult.Claims);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                context.HttpContext.User = claimsPrincipal;
            }
            catch
            {
                context.Result = new UnauthorizedObjectResult(new ErrorApiResponse(ResultMessage.TokenMustStartWithBearerKeyword));
            }
        }
    }
}