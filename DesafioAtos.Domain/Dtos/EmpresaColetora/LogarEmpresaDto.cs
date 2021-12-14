using System.ComponentModel.DataAnnotations;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Dtos
{
    public class LogarEmpresaDto
    {
        [Required(ErrorMessage = "Propriedade {0} � obrigat�ria.")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Propriedade {0} � obrigat�ria.")]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string Senha { get; set; } = null!;
    }
}
