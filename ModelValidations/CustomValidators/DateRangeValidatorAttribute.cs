using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidations.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }

        public DateRangeValidatorAttribute() { }
        public DateRangeValidatorAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                //get to_date
                DateTime toDate = Convert.ToDateTime(value);

                //get from_date
                PropertyInfo? property = validationContext.ObjectType.GetProperty(OtherPropertyName);

                if (property != null)
                {
                    DateTime fromDate = Convert.ToDateTime(property.GetValue(validationContext.ObjectInstance));

                    if (fromDate > toDate)
                        return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName });
                    else
                        return ValidationResult.Success;
                }

                return null;
            }

            return null;
        }
    }
}
