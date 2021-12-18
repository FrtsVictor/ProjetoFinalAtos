using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.DataAnotation
{
    public class ValidacaoCnpj : ValidationAttribute
    {
        private const string errorMessage = "Cnpj inválido, verifique se todos digitos estão corretos.";

        protected override ValidationResult? IsValid(object value, ValidationContext context)
        {
            bool isCnpjValido = false;

            if (value != null)
                isCnpjValido = VerificadorCnpj.IsCnpj((string)value);

            return isCnpjValido ? ValidationResult.Success : new ValidationResult(errorMessage);
        }
    }
}