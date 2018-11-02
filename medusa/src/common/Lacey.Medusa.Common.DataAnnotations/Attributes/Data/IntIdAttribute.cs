using System.ComponentModel.DataAnnotations;

namespace Lacey.Medusa.Common.DataAnnotations.Attributes.Data
{
    public sealed class IntIdAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return (int)value > 0;
        }
    }
}