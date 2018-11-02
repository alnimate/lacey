using System.ComponentModel.DataAnnotations;

namespace Lacey.Medusa.Common.DataAnnotations.Attributes.Common
{
    public sealed class InvalidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return false;
        }
    }
}