using System.Collections.Generic;
using System.Linq;
using Lacey.Medusa.Common.Validation.Validation;

namespace Lacey.Medusa.Common.Validation.Extensions
{
    public static class ValidationExtensions
    {
        public static IEnumerable<T> ValidationFilter<T>(
            this IEnumerable<T> models,
            out IEnumerable<T> invalidList)
            where T : ValidatableModel
        {
            invalidList = new List<T>();
            var validList = new List<T>();
            foreach (var model in models)
            {
                var result = EntityValidator.Validate(model);
                model.ValidationResult = result;
                if (result.Errors.Any())
                {
                    ((IList<T>) invalidList).Add(model);
                }
                else
                {
                    ((IList<T>)validList).Add(model);
                }
            }

            return validList;
        }
    }
}