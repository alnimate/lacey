using System.ComponentModel.DataAnnotations;

namespace Lacey.Medusa.Common.DataAnnotations.Attributes.Numbers
{
    public sealed class MinIntValueAttribute : ValidationAttribute
    {
        private readonly int minValue;

        public MinIntValueAttribute(int minValue)
        {
            this.minValue = minValue;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return (int)value >= this.minValue;
        }
    }
}