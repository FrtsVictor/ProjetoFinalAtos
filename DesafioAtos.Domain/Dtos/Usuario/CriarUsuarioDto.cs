using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.Dtos
{
    public class CriarUsuarioDto : LogarUsuarioDto
    {
        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        [StringLength(maximumLength: 50, MinimumLength = 4,
            ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string Nome { get; set; } = null!;
    }
}