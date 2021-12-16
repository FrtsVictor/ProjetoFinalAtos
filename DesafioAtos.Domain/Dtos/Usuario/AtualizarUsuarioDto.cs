using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.Dtos
{
    public class AtualizarUsuarioDto : LogarUsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
    }
}
