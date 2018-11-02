using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Lacey.Medusa.Common.DataAnnotations.Attributes.Data
{
    public sealed class IntIdsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return ((IEnumerable<int>)value).All(id => id > 0);
        }
    }
}