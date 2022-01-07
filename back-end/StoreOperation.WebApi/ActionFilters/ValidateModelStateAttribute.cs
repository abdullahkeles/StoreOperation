using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreOperation.WebApi.Common.Api;

namespace StoreOperation.WebApi.ActionFilters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var modelStateValue in context.ModelState.Values)
                {
                    foreach (var error in modelStateValue.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                context.Result = new BadRequestObjectResult(new ErrorApiResponse(String.Join(",", errors)));
            }
        }
    }
}