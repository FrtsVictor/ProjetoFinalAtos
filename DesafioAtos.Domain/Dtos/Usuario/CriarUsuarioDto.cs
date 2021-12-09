using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.Dtos
{
    public class CriarUsuarioDto : LoginDto
    {
        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        public int RoleId { get; set; }
    }
}