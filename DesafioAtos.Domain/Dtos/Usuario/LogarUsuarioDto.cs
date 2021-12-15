using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.Dtos
{
    public class LogarUsuarioDto
    {
        public string Login { get; set; } = null!;

        public string Senha { get; set; } = null!;
    }
}