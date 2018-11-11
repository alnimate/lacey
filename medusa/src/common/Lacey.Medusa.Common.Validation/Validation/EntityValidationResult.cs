using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

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

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var error in this.Errors)
            {
                sb.AppendLine($"{error.FieldName} : \"{error.ErrorMessage}\"");
            }

            return sb.ToString();
        }
    }
}