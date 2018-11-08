using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Lacey.Medusa.Common.Validation.Validation
{
    public sealed class EntityValidationResult
    {
        public readonly IEnumerable<ValidationError> Errors;

        public EntityValidationResult(IEnumerable<ValidationResult> results)
        {
            this.Errors = results.Where(r => r != ValidationResult.Success)
                .Select(r => new ValidationError(r.MemberNames.First(), r.ErrorMessage));
        }
    }
}