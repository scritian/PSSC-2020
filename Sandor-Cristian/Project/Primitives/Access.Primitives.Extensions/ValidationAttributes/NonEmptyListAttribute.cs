using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EarlyPay.Primitives.ValidationAttributes
{
    public class NonEmptyListAttribute : ValidationAttribute
    {
        public NonEmptyListAttribute() : base("The field [{0}] should not be an empty list") { }

        public override bool IsValid(object value)
        {
            if (value is IEnumerable list)
            {
                return list.Cast<object>().Any();
            }
            return false;
        }
    }
}
