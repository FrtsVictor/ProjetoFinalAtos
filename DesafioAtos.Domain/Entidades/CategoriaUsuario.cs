namespace DesafioAtos.Domain.Entidades
{
    public class CategoriaUsuario : EntidadeBase
    {
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;
        public virtual Categoria Categoria { get; set; } = null!;
    }
}