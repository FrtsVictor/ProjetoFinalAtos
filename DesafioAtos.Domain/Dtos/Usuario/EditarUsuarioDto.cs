using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.Dtos
{
    public class EditarUsuarioDto
    {

        [StringLength(maximumLength: 20, MinimumLength = 4, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string? Login { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 4, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string? Nome { get; set; }

        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string? Senha { get; set; }
    }
}
