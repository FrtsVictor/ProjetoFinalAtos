using System.ComponentModel.DataAnnotations;

namespace DesafioAtos.Domain.Dtos
{
    public class CriarUsuarioDto : LogarUsuarioDto
    {
              public string Nome { get; set; } = null!;
    }
}