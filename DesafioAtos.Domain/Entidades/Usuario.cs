using DesafioAtos.Domain.Enums;

namespace DesafioAtos.Domain.Entidades
{
    public partial class Usuario : EntidadeBase
    {
        public Usuario()
        {
            UsuarioEmpresaCategoria = new HashSet<UsuarioEmpresaCategoria>();
        }
      
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public ERole Role { get; set; }

        public virtual ICollection<UsuarioEmpresaCategoria> UsuarioEmpresaCategoria { get; set; }
    }
}
