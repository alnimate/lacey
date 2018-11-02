using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lacey.Medusa.Common.Web.Validation
{
    internal static class ModelExtensions
    {
        public static IEnumerable<Validation.ModelError> GetErrors(this ModelStateDictionary modelState)
        {
            return (from key in modelState.Keys
                    let value = modelState[key] where 
                    value.Errors.Any()
                    select new Validation.ModelError(key, value.AttemptedValue, 
                        value.Errors.Select(e => e.ErrorMessage)))
                        .ToList();
        }
    }
}