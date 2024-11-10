using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Services.CommonServices.ValidationService
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Mật khẩu không được để trống");

            var password = value.ToString();
            var errors = new List<string>();

            if (password.Length < 6)
                errors.Add("Mật khẩu phải có ít nhất 6 ký tự");

            if (!password.Any(char.IsUpper))
                errors.Add("Mật khẩu phải chứa ít nhất 1 chữ in hoa");

            if (!password.Any(char.IsLower))
                errors.Add("Mật khẩu phải chứa ít nhất 1 chữ thường");

            if (!password.Any(char.IsDigit))
                errors.Add("Mật khẩu phải chứa ít nhất 1 số");

            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                errors.Add("Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt");

            if (errors.Any())
                return new ValidationResult(string.Join(", ", errors));

            return ValidationResult.Success;
        }
    }
}
