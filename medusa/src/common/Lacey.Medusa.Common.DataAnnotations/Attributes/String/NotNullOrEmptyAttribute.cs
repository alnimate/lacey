using System.ComponentModel.DataAnnotations;

namespace Lacey.Medusa.Common.DataAnnotations.Attributes.String
{
    public sealed class NotNullOrEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return !string.IsNullOrEmpty((string)value);
        }
    }
}