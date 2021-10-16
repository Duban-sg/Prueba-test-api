using System.ComponentModel.DataAnnotations;

namespace Prueba_test_api.Validators
{
    public class HouseValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            switch (value)
            {
                case "Gryffindor":
                    return ValidationResult.Success;
                case "Hufflepuff":
                    return ValidationResult.Success;
                case "Ravenclaw":
                    return ValidationResult.Success;
                case "Slytherin":
                    return ValidationResult.Success;
                default:
                    return new ValidationResult(ErrorMessage);

            }
        }
    }
}
