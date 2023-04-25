using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.Common.Validations
{
    public class FirstCapital : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var first = value.ToString()[0].ToString();
            if (first != first.ToUpper())
            {
                return new ValidationResult("Initial must be capital");
            }
            return ValidationResult.Success;
        }
    }
}
