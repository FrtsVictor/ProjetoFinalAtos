using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.Dtos
{
    public class LogarUsuarioDto
    {
        [Required(ErrorMessage = "Propriedade {0} � obrigat�ria.")]
        [StringLength(maximumLength: 20, MinimumLength = 4,
             ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string Login { get; set; } = null!;

        [Required(ErrorMessage = "Propriedade {0} � obrigat�ria.")]
        [StringLength(maximumLength: 30, MinimumLength = 5,
            ErrorMessage = "A propriedade {0}  deve conter entre {1} e {2} caracteres")]
        public string Senha { get; set; } = null!;
    }
}