using DesafioAtos.Domain.Enums;

namespace DesafioAtos.Domain.Entidades
{
    public partial class Usuario : EntidadeBase
    {
        public Usuario()
        {
            CategoriaUsuarios = new HashSet<CategoriaUsuario>();
        }
      
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public ERole Role { get; private set; } = ERole.Usuario;
        public DateTime? DataCriacao { get; private set; } = DateTime.Now;

        public virtual ICollection<CategoriaUsuario> CategoriaUsuarios { get; set; }
    }
}
