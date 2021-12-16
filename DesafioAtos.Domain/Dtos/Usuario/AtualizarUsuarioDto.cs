using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.Dtos
{
    public class AtualizarUsuarioDto : LogarUsuarioDto
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 200, MinimumLength = 4, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string Nome { get; set; } = null!;
    }
}
