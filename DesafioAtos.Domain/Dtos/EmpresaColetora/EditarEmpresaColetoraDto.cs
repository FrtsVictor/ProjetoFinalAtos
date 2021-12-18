using System.ComponentModel.DataAnnotations;
using DesafioAtos.Domain.DataAnotation;
using DesafioAtos.Domain.DataAnotation.Email;

namespace DesafioAtos.Domain.Dtos
{
    public class EditarEmpresaColetoraDto
    {
        [StringLength(maximumLength: 200, MinimumLength = 4, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string? Nome { get; set; }

        [ValidacaoCnpj]
        public string? Cnpj { get; set; }

        [Phone]
        [StringLength(maximumLength: 14, MinimumLength = 9, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string? Telefone { get; set; }


        [ValidacaoEmail]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(200, MinimumLength = 5)]
        public string? Senha { get; set; }
    }
}