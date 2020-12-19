using LanguageExt;
using System;
using System.ComponentModel.DataAnnotations;

namespace EarlyPay.Primitives.ValidationAttributes
{
    public class OptionValidatorAttribute : ValidationAttribute
    {
        private readonly Type _validatorAttribute;
        private ValidationAttribute _instance;

        public OptionValidatorAttribute(Type validatorAttribute, params object[] args)
        {
            _instance = Activator.CreateInstance(validatorAttribute, args) as ValidationAttribute;
            _validatorAttribute = validatorAttribute;
        }
        public override bool IsValid(object value)
        {
            var optional = (IOptional)value;
            var isValid = optional.MatchUntyped(o => _instance.IsValid(o), () => false);
            return isValid;
        }
    }
}
