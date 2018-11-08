using System.ComponentModel.DataAnnotations;

namespace Lacey.Medusa.Common.DataAnnotations.Attributes.DateTime
{
    public class MinYearAttribute : ValidationAttribute
    {
        private readonly int minYear;

        public MinYearAttribute(int minYear)
        {
            this.minYear = minYear;
        }

        public override bool IsValid(object value)
        {
            return (System.DateTime)value >= new System.DateTime(this.minYear, 1, 1);
        }
    }
}