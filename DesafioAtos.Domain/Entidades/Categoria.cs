namespace DesafioAtos.Domain.Entidades
{
    public partial class Categoria : EntidadeBase
    {
        public Categoria()
        {
            UsuarioEmpresaCategoria = new HashSet<UsuarioEmpresaCategoria>();
        }
     
        public string Nome { get; set; } = null!;

        public virtual ICollection<UsuarioEmpresaCategoria> UsuarioEmpresaCategoria { get; set; }
    }
}
