using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.DataAnotation.Email
{
    public class ValidacaoEmail : ValidationAttribute
    {
        private const string errorMessage = "Email inválido, verifique se todos digitos estão corretos.";

        protected override ValidationResult? IsValid(object value, ValidationContext context)
        {
            bool isEmailValido = false;

            if (value != null)
                isEmailValido = RegexUtilities.isEmailValido((string)value);

            return isEmailValido ? ValidationResult.Success : new ValidationResult(errorMessage);
        }
    }
}