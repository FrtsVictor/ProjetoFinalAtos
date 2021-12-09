using DesafioAtos.Domain.Enums;

namespace DesafioAtos.Domain.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public ERole Role { get; set; }
    }
}
