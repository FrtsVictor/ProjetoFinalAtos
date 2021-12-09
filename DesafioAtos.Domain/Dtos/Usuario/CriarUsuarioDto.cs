using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.Dtos
{
    public class CriarUsuarioDto
    {
        [MaxLength(20, ErrorMessage = "Login inv�lido maximum {1} characters allowed")]
        public string? Login { get; set; } = null;

        [MaxLength(20, ErrorMessage = "Senha invalida maximum {1} characters allowed")]
        public string? Senha { get; set; }

        public int RoleId { get; set; }
    }
}