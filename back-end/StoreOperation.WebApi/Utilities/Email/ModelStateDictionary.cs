using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace StoreOperation.WebApi.Utilities.Email
{
    public static class ModelStateDictionaryExtensions
    {
        /// <summary>
        /// bu extension test amaçlı yazılmıştır. 18/08/2021 abdullah
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetAllErrorMessage(this ModelStateDictionary modelState)
        {
            var sb = new StringBuilder();
            if (!modelState.IsValid)
            {
                var errorProperies = modelState.Values.Where(x => x.ValidationState == ModelValidationState.Invalid)
                    .ToArray();
                return modelState.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                    .Select(e => String.Join(" ", e.Value.Errors.Select(x => x.ErrorMessage)));
            }

            return Enumerable.Empty<string>();
        }
    }
}